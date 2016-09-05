using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NationalInstruments.DAQmx;
using System.Text;
using System.Collections; //for queues
using System.IO.Ports;
using MccDaq; //Using MccDaq to read dyno
using System.Drawing;
using System.Diagnostics;

namespace MysteryBoxWorkaround
{
    public partial class GUI : Form
    {
        #region Global Variables
        #region Dynamometer
        public bool isDynCon = false;
        //Dynamometer Structures
        MccDaq.MccBoard DaqBoard;
        MccDaq.ErrorInfo ULStat;
        MccDaq.Range Range;
        MccDaq.ScanOptions Options;
        SerialPort DynoControlPort;
        private IntPtr MemHandle = IntPtr.Zero;//JNEW 
        const int NumPoints = 8;    //  Number of data points to collect //JNEW
        const int FirstPoint = 0;     //  set first element in buffer to transfer to array //JNEW
        private ushort[] ADData = new ushort[NumPoints];//JNEW
        //Variables for reading dyno
        short[] DatVal = new short[8];
        float[] VoltVal = new float[8];
        double[] ForceVal = new double[8];
        double XForce, YForce, ZForceDyno, TForce, VAngle,XYForce, MaxXYForceHistory, MaxTForceHistory, XYForceAverage;
        public double MaxTForce=20, MaxXYForce=20;
        #endregion
        #region Modbus
        Semaphore ModBusQueueSemaphore = new Semaphore(0, 50);
        Queue ModBusQueue = new Queue();
        SerialPort ModbusPort;
        Semaphore ModBusQueueMutex = new Semaphore(1,1);//I know, it is not a mutex, but had some weird issues using mutex and multiple threads so this is my hackish solution to use a sempafore as a mutex
        Thread ModBusWriteThread;
        #endregion
        #region UDP Communication
        public bool isSimControl = false;
        UdpClient SimulinkReviceUDP = new UdpClient(12005);//recieves from 12000
        UdpClient SimulinkSendUDP = new UdpClient(12006);//sends to 12010 //rapid info sent in this channel, like position forces etc
        Byte[] Zbytes = new Byte[8];
        Byte[] Verbytes = new Byte[8];
        Byte[] Latbytes = new Byte[8];
        Byte[] Trabytes = new Byte[8];
        Byte[] XForcebytes = new Byte[8];
        Byte[] YForcebytes = new Byte[8];
        Byte[] ZForceDynobytes = new Byte[8];
        Byte[] TForcebytes = new Byte[8];
        Byte[] VAnglebytes = new Byte[8];
        Byte[] SpiCurrentbytes = new Byte[8];
        Byte[] BytesOutMat = new Byte[256];

        Byte[] VerWeldbytes = new Byte[8];
        Byte[] VerPlungebytes = new Byte[8];
        IPEndPoint IPSendtoSimulink, IPRecivefromSimulink, IPSendtoSimulinkCommands;
        #endregion
        #region SensorBox
        public bool isSenCon = false;
        //Declare buffers for data
        Byte[] BytesOut = new Byte[256];
        Byte[] BytesIn = new Byte[256];
        TcpClient SenClient;
        NetworkStream SenStream;
        String SendData;
        bool isLubWanted = false;
        public bool isPressure = false;
        bool isEmergencyButton = false;
        bool isLubOn=false;
        bool isDoorClosed = false;
        #endregion
        #region Vertical Motor
        public bool isVerCon=false;
        bool isSetVerWeld = false;
        SerialPort VerPort;
        //Values for describing locations in the vertical
        int VerCount = 0;
        double VerLoc = -1;
        public double VerMax = 7.0;
        public double VerMin = 1.0;
        public double VerWeld = 0;//location of the material's surface
        double VerPlunge = 0;//how far the tool should plunge into the material
        Mutex SendMutex = new Mutex();
        #endregion
        #region Lateral Motor
        public bool isLatCon = false;
        bool isLatOn = false;
        bool isLatIn = false;
        //Values for describing locations in the lateral direction
        double LatVolt = 0;
        double LatLoc = -3;
        public double LatMax = 3.5;
        public double LatMin = 1.5;
        #endregion
        #region Traverse Motor
        public bool isTraCon = false;
        bool isTraOn = false;
        //Values for describing locations in the traverse
        double TraVolt = 0;
        double TraLoc = -2;
        public double TraMax = 27;
        public double TraMin = 9.0;
        #endregion
        #region Spindle Motor
        public bool isSpiCon = false;
        bool isSpiOn = false;
        #endregion
        #region Strain Gauge
        double NIMaxVolt = 1;
        private NationalInstruments.DAQmx.Task strainTask;
        double Zvolt, SpiCurrent, Ztemp, ZForce, Zoffset, ZMaxHistory;
        public double MaxZForce = 18000;
        AnalogMultiChannelReader strainReader;
        #endregion
        bool isAlarm = false;
        #region Threads
        Thread CommSenDynEncThread,MysteryBoxConnection;
        //mutex to let only one thread have control of machine at a time
        Semaphore ControlSemaphore = new Semaphore(1,1);
        Thread MachineControlThread;
        bool isAbort = false;
        #endregion
        Semaphore MessageQueueSemaphore = new Semaphore(0, 50);
        Queue MessageQueue = new Queue();
        Mutex MessageQueueMutex = new Mutex();

        #region Matlab
        Semaphore MatlabQueueSemaphore = new Semaphore(0, 50);
        Queue MatlabQueue = new Queue();
        Mutex MatlabQueueMutex = new Mutex();
        Thread MatlabWriteThread;
        #endregion
        #endregion
        public GUI()
        {
            #region Setup MC Daq
            //Initialize Error Handling
            ULStat = MccDaq.MccService.ErrHandling(MccDaq.ErrorReporting.PrintAll, MccDaq.ErrorHandling.StopAll);

            //Create an object for board 0
            DaqBoard = new MccDaq.MccBoard(0);

            //Set the range
            Range = MccDaq.Range.Bip10Volts;
            //  return scaled data
            Options = MccDaq.ScanOptions.ScaleData;
            #endregion
            #region Setup Serial Ports
            try
            {
                //Set up the Modbus Port
                ModbusPort = new SerialPort();
                ModbusPort.BaudRate = 38400;
                ModbusPort.PortName = "COM5";
                ModbusPort.Parity = System.IO.Ports.Parity.None;
                ModbusPort.StopBits = System.IO.Ports.StopBits.Two;
                ModbusPort.Open();

                //Set up the port for the vertical motor
                VerPort = new SerialPort();
                VerPort.BaudRate = 9600;
                VerPort.PortName = "COM4";
                VerPort.DataBits = 8;
                VerPort.Parity = System.IO.Ports.Parity.None;
                VerPort.StopBits = System.IO.Ports.StopBits.One;
                VerPort.Open();

                //Set up port for controlling the dyno
                DynoControlPort = new SerialPort();
                DynoControlPort.PortName = "COM3";
                DynoControlPort.BaudRate = 4800;
                DynoControlPort.Parity = Parity.None;
                DynoControlPort.StopBits = StopBits.One;
                DynoControlPort.DataBits = 8;
                DynoControlPort.Open();
            }
            catch(System.IO.IOException e)
            {
                MessageBox.Show("Open device manager in windows and the 'Setup Serial Ports' section of the C# code and check the serial port names and settings are correct\n\n"+e.ToString(),"Serial Port Error");
                Process.GetCurrentProcess().Kill();

            }
            catch(System.UnauthorizedAccessException e)
            {
                MessageBox.Show("Something is wrong? maybe try to restart computer?\n\nHere is some error message stuff...\n\n" + e.ToString(), "Serial Port Error");
                Process.GetCurrentProcess().Kill();
            }
            #endregion
            #region Setup NI USB-6008
            try
            {
                //Setting up NI DAQ for Axial Force Measurment via Strain Circuit and current Measurment of Spindle Motor for torque 
                strainTask = new NationalInstruments.DAQmx.Task();
                AIChannel strainChannel, CurrentChannel;
                strainChannel = strainTask.AIChannels.CreateVoltageChannel(
                    "dev2/ai0",  //Physical name of channel
                    "strainChannel",  //The name to associate with this channel
                    AITerminalConfiguration.Differential,  //Differential Wiring
                    -0.1,  //-0.1v minimum
                    NIMaxVolt,  //1v maximum
                    AIVoltageUnits.Volts  //Use volts
                    );

                ///////////////////////////////ADD by JAY 10/22/2014
                CurrentChannel = strainTask.AIChannels.CreateVoltageChannel(
                   "dev2/ai1",  //Physical name of channel
                   "CurrentChannel",  //The name to associate with this channel
                   AITerminalConfiguration.Differential,  //Differential Wiring
                   -0.1,  //-0.1v minimum
                   10,  //10v maximum
                   AIVoltageUnits.Volts  //Use volts
                   );
                ////////////////////////////////////////////////////////////
                strainReader = new AnalogMultiChannelReader(strainTask.Stream);
            }
            catch(NationalInstruments.DAQmx.DaqException e)
            {
                MessageBox.Show("Error?\n\n" + e.ToString(), "NI USB 6008 Error");
            }
            #endregion
            #region Setup UDP
            IPSendtoSimulink = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12010);
            IPRecivefromSimulink = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 12000);
            SimulinkSendUDP.Connect(IPSendtoSimulink);
            SimulinkReviceUDP.Connect(IPRecivefromSimulink);
            #endregion
            #region Start Threads
            //
            //thread that communicates with mystery box, daq, and matlab?
            CommSenDynEncThread = new Thread(new ThreadStart(CommSenDynEnc));
            CommSenDynEncThread.Start();

            //Start the Modbus Writer thread
            ModBusWriteThread = new Thread(new ThreadStart(WriteModbus));
            ModBusWriteThread.Start();

            //Start Matlab thread, sends matlab commands so that long function like opening or compiling a model do not hang up the rest of the user interface
            MatlabWriteThread= new Thread(new ThreadStart(MatlabCom));
            MatlabWriteThread.Start();
            #endregion
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(0, 0);
        }
        #region Threads
        //Thread that reads in data and sends over UDP
        private void MatlabCom()
        {
            MLApp.MLApp matlab = new MLApp.MLApp();//Start matlab
            while (true)
            {
                try
                {
                    MatlabQueueSemaphore.WaitOne();
                    MatlabQueueMutex.WaitOne();
                    matlab.Execute((string)MatlabQueue.Dequeue());
                    MatlabQueueMutex.ReleaseMutex();
                }
                catch(System.InvalidOperationException e)
                {
                    MessageBox.Show(e.ToString(), "Whoops");
                }

            }
            
        }
        public void WriteMatlabQueue(string message)
        {
            message = message + "\r\n";
            MatlabQueueMutex.WaitOne();
            MatlabQueue.Enqueue(message);
            MatlabQueueMutex.ReleaseMutex();
            MatlabQueueSemaphore.Release(1);
        }
        public void MatlabExecute(string message)
        {
            WriteMessageQueue(message);
            WriteMatlabQueue(message);
        }
        private void CommSenDynEnc()
        {
            MemHandle = MccDaq.MccService.ScaledWinBufAllocEx(NumPoints);//JNEW
            const int FilterLength = 5;
            double[] XYForceData = new double[FilterLength];
            int count = 0;
            double dummy=0;
            int LowChan = 0, HighChan = 7, Rate = 1250, Count = 8;//JNEW
            String RecieveData;
            int ByteCount;
            int TermIndex;
            while (true)
            {
                double[] data = strainReader.ReadSingleSample();
                Zvolt = data[0];
                SpiCurrent = data[1] * 10;
                Ztemp = 21050 * (Zvolt-Zoffset);  //Subtract offset and multiply gain....Recalibrated from 17760 N/V on 9/16/2011, Recalibrated from 18843 N/V on 10/5/2011, Recalibrated from 19785 N/V on 5/7/2012
                ZForce = Ztemp; //BG commented out above 4 lines and added this to report full range (+ and -) Z values for Russ's bobbin welding
                //the first part is done if connected to sensor box
                #region If Mystery is connected
                if (isSenCon)
                {
                     
                    try
                    {
                        //Apend end code to Send Data
                        SendData += "X";

                        //Clear BytesOut
                        //Translate the passed message
                        BytesOut = Encoding.ASCII.GetBytes(SendData);

                        //Clear out Send Data
                        SendData = "A";

                        //Send the message to the sensor client

                        SenStream.Write(BytesOut, 0, BytesOut.Length);

                        //Read the incoming data
                        ByteCount = SenStream.Read(BytesIn, 0, BytesIn.Length);
                        RecieveData = Encoding.ASCII.GetString(BytesIn, 0, ByteCount);
                        //Parse and process the incoming data

                        //Get and check the vertical
                        TermIndex = RecieveData.IndexOf("X");
                        VerCount = int.Parse(RecieveData.Substring(22, TermIndex - 22));
                        VerLoc = (VerCount * -.000393700787) + 2.79;

                        //Get and check the traverse
                        TraVolt = double.Parse(RecieveData.Substring(6, 7));
                        TraLoc = (4.29 * TraVolt) - 2.317;

                        //Get and check the lateral
                        LatVolt = double.Parse(RecieveData.Substring(14, 7));
                        LatLoc = (1.075945 * LatVolt) - 7.1; //Recalibrated by BG, 2/8/13, for use with 4X loop on sensor

                        //Check the pressure, door, and E-stop button
                        //isDoorClosed = (int.Parse(RecieveData.Substring(0, 1)) == 1);
                        isDoorClosed = true;
                        isPressure = (int.Parse(RecieveData.Substring(2, 1)) == 1);
                        isEmergencyButton = (int.Parse(RecieveData.Substring(4, 1)) == 1);
                    }
                    catch (ArgumentNullException ex)
                    {
                        MessageBox.Show("Error Receiving Data From Mystery Box, I would try to disconecct and power cycle the Mystery Box and connect again. -J\n\n"+ex.Message.ToString(), "Error Receiving Data From Mystery Box");
                    }
                    

                }
                #endregion
                #region If Dyno is connected
                if (isDynCon)
                {
                    #region Old ADC code
                    ////read in data from DaqBoard
                    //DaqBoard.AIn(0, Range, out DatVal[0]);
                    //DaqBoard.AIn(1, Range, out DatVal[1]);
                    //DaqBoard.AIn(2, Range, out DatVal[2]);
                    //DaqBoard.AIn(3, Range, out DatVal[3]);
                    //DaqBoard.AIn(7, Range, out DatVal[7]);
                    ////Convert data to voltage
                    //DaqBoard.ToEngUnits(Range, DatVal[0], out VoltVal[0]);
                    //DaqBoard.ToEngUnits(Range, DatVal[1], out VoltVal[1]);
                    //DaqBoard.ToEngUnits(Range, DatVal[2], out VoltVal[2]);
                    //DaqBoard.ToEngUnits(Range, DatVal[3], out VoltVal[3]);
                    //DaqBoard.ToEngUnits(Range, DatVal[7], out VoltVal[7]);
                    ////Scale voltages to match forces
                    //ForceVal[0] = 487.33 * (double)VoltVal[0];
                    //ForceVal[1] = 479.85 * (double)VoltVal[1];
                    //ForceVal[2] = 2032.52 * (double)VoltVal[2];
                    //ForceVal[3] = 18.91 * (double)VoltVal[3];
                    ////Copy into local variables
                    //XForce = ForceVal[0];
                    //YForce = ForceVal[1];
                    //ZForceDyno = ForceVal[2];
                    //TForce = ForceVal[3];
                    //VAngle = VoltVal[7];
                    #endregion
                    #region New ADC code?
                    //  return scaled data
                    Options = MccDaq.ScanOptions.ConvertData | MccDaq.ScanOptions.SingleIo;
                    //Options = MccDaq.ScanOptions.ScaleData;
                    Range = MccDaq.Range.Bip5Volts; // set the range

                    ULStat = DaqBoard.AInScan(LowChan, HighChan, Count, ref Rate, Range, MemHandle, Options);
                    if (ULStat.Value == MccDaq.ErrorInfo.ErrorCode.BadRange)
                    {
                        MessageBox.Show("Change the Range argument to one supported by this board.", "Unsupported Range", 0);
                    }
                    //  Transfer the data from the memory buffer set up by Windows to an array
                    ULStat = MccDaq.MccService.WinBufToArray(MemHandle, ADData, FirstPoint, Count);


                    //Copy into local variables
                    XForce = 487.33 * Count2Volt(ADData[0]);
                    YForce = 479.85 * Count2Volt(ADData[1]);
                    ZForceDyno = 2032.52 * Count2Volt(ADData[2]);
                    TForce = 18.91 * Count2Volt(ADData[3]);
                    VAngle = Count2Volt(ADData[7]);
                    XYForce = Math.Sqrt(XForce * XForce + YForce * YForce);
                    XYForceData[count] = XYForce;
                    count = ++count % FilterLength;
                    dummy = 0;
                    for (int i=0;i<FilterLength;i++)
                    {
                        dummy = dummy + XYForceData[i];
                    }
                    XYForceAverage = dummy / FilterLength;
                    #endregion

                }
                #endregion
                #region Convert Data to Bytes and send over UDP
                Zbytes = BitConverter.GetBytes(ZForce);
                Verbytes = BitConverter.GetBytes(VerLoc);
                Latbytes = BitConverter.GetBytes(LatLoc);
                Trabytes = BitConverter.GetBytes(TraLoc);

                XForcebytes = BitConverter.GetBytes(XForce);
                YForcebytes = BitConverter.GetBytes(YForce);
                ZForceDynobytes = BitConverter.GetBytes(ZForceDyno);
                TForcebytes = BitConverter.GetBytes(TForce);
                VAnglebytes = BitConverter.GetBytes(VAngle);
                SpiCurrentbytes = BitConverter.GetBytes(SpiCurrent);

                for (int i = 0; i <= 7; i++) { BytesOutMat[i] = Zbytes[i]; }
                for (int i = 0; i <= 7; i++) { BytesOutMat[i+8] = Verbytes[i];}
                for (int i = 0; i <= 7; i++) { BytesOutMat[i + 16] = Latbytes[i]; }
                for (int i = 0; i <= 7; i++) { BytesOutMat[i + 24] = Trabytes[i]; }
                for (int i = 0; i <= 7; i++) { BytesOutMat[i + 32] = XForcebytes[i]; }
                for (int i = 0; i <= 7; i++) { BytesOutMat[i + 40] = YForcebytes[i]; }
                for (int i = 0; i <= 7; i++) { BytesOutMat[i + 48] = ZForceDynobytes[i]; }
                for (int i = 0; i <= 7; i++) { BytesOutMat[i + 56] = TForcebytes[i]; }
                for (int i = 0; i <= 7; i++) { BytesOutMat[i + 64] = VAnglebytes[i]; }
                for (int i = 0; i <= 7; i++) { BytesOutMat[i + 72] = SpiCurrentbytes[i]; }
                SimulinkSendUDP.Send(BytesOutMat, 80);
                #endregion
                SafetyCheck();
                Thread.Sleep(25);
            }
        }
        public void MatlabUpdateParameters()
        {
            MatlabExecute("set_param(bdroot(gcs), 'SimulationCommand', 'update');");
        }
        //Thread 'WriteModbus' that manages the commands given to the motors controled on the modbus
        #region Modbus functions
        ////Helper function to compute checksum
        ulong crc_chk(byte[] data, int length)
        {
            int j;
            int pos = 0;
            ulong reg_crc;
            reg_crc = 0xFFFF;
            while (length != 0)
            {
                length--;
                reg_crc ^= data[pos];
                pos++;
                for (j = 0; j < 8; j++)
                {
                    if ((reg_crc & 0x01) != 0)
                    {
                        reg_crc = (reg_crc >> 1) ^ 0xA001;
                    }
                    else
                        reg_crc = reg_crc >> 1;
                }
            }
            return reg_crc;
        }
        void WriteModbus()
        {
            byte[] RSMessage = { 0, 0, 0, 0, 0, 0, 0, 0 };
            while (true)
            {
                ModBusQueueSemaphore.WaitOne();//wait on something to be put into motor comand queue
                ModBusQueueMutex.WaitOne();
                RSMessage = (byte[])ModBusQueue.Dequeue();
                ModBusQueueMutex.Release();
                ModbusPort.Write(RSMessage, 0, 8);
                Thread.Sleep(30);//wait for a period of at least 25ms to send comands to motors on the modbus,
                // commands seem to be dropped if sent any faster. J 9/10/2015
            }
        }
        bool WriteModbusQueue(int motor, int address, int data, bool checkreturn)
        {
            int motorreturned = 0;
            //For write modbus
            byte[] Returned= { 0, 0, 0, 0, 0, 0, 0, 0 };//delete
            byte[] RSMessage = { 0, 0, 0, 0, 0, 0, 0, 0 };

            //some local declarations
            ulong chkval;

            //Slave ID and function code
            RSMessage[0] = (byte)motor;
            RSMessage[1] = (byte)0x06;

            //Address
            RSMessage[2] = (byte)(address >> 8);
            RSMessage[3] = (byte)(address & 0xFF);

            //Data
            RSMessage[4] = (byte)(data >> 8);
            RSMessage[5] = (byte)(data & 0xFF);

            //get crc info
            chkval = crc_chk(RSMessage, 6);

            RSMessage[6] = (byte)(chkval & 0xFF);
            RSMessage[7] = (byte)(chkval >> 8);

            ////Transmit
            //ModbusPort.Write(RSMessage, 0, 8); now will send to queue and another thread will transmit commands 9/10/2015

            if (!checkreturn)
            {
                //Send to Queue
                ModBusQueueMutex.WaitOne();
                ModBusQueue.Enqueue(RSMessage);
                ModBusQueueMutex.Release();
                ModBusQueueSemaphore.Release(1);//tell other thread message is available
            }

            if (checkreturn)
            {
                ModBusQueueMutex.WaitOne();
                //if the calling functions wants a check on whether the motor resonds
                ///must clear out and info in port
                ModbusPort.ReadExisting();
                ModbusPort.Write(RSMessage, 0, 8);
                for (int i = 0; i < 3; i++)
                {
                    if (ModbusPort.BytesToRead > 0)
                    {
                        //Check to see if the requested motor that responded matches the right motor
                        ModbusPort.Read(Returned, 0, ModbusPort.BytesToRead);
                        WriteMessageQueue(BitConverter.ToString(Returned));
                        motorreturned = Returned[0];
                        if (motor == motorreturned)
                        {
                            ModBusQueueMutex.Release();
                            return true;
                        }
                    }
                    Thread.Sleep(20);
                }
                ModBusQueueMutex.Release();
                return false;
            }
            return true;
        }
        #endregion
        #endregion
        #region Vertical Motor functions
        void btnVerRun_Click(object sender, EventArgs e)
        {
            String VerMessage;
            int VerPos = (int)nmVerTurns.Value;
            VerMessage = String.Empty;

            if (rbVerContinuous.Checked)
            {
                VerMessage = "E MC H";
                    VerMessage += "+";

                VerMessage += "A" + nmVerAcc.Value.ToString() + " V" + nmVerVel.Value.ToString() + " G\r";
            }
            else
            {
                VerMessage = "E MN A" + nmVerAcc.Value.ToString() + " V" + nmVerVel.Value.ToString() + " D";
                VerMessage += VerPos.ToString() + " G\r";
            }

            VerPort.Write(VerMessage);
        }
        void btnVerLowerStage_Click(object sender, EventArgs e)
        {
            String VerMessage;
            int VerPos = (int)nmVerTurns.Value;
            VerMessage = String.Empty;

            if (rbVerContinuous.Checked)
            {
                VerMessage = "E MC H";
                    VerMessage += "-";
                VerMessage += "A" + nmVerAcc.Value.ToString() + " V" + nmVerVel.Value.ToString() + " G\r";
            }
            else
            {
                VerMessage = "E MN A" + nmVerAcc.Value.ToString() + " V" + nmVerVel.Value.ToString() + " D";
                    VerMessage += "-";
                VerMessage += VerPos.ToString() + " G\r";
            }

            VerPort.Write(VerMessage);
        }
        void btnVerCon_Click(object sender, EventArgs e)
        {
            if (!isVerCon)//connect to vertical motor
            {
                VerConnect();
            }
            else//disconnect motor
            {
                VerDisconnect();
            }
        }
        void btnVerStop_Click(object sender, EventArgs e)
        {
            VerPort.Write("E S\r");
        }   
        void VerConnect()
        {
            string VerMessage;
            //Clear out port
            VerPort.ReadExisting(); //this was edited out

            //Query the motor and establish RS-232 control
            VerPort.Write("E ON 1R\r"); //this was edited out
            Thread.Sleep(300); //this was edited out

            //Turn off limits
            VerPort.Write("1LD3\r"); //this was edited out
            Thread.Sleep(30); //this was edited out

            //Initialize Now
            VerPort.Write("1E 1MN 1A10 1V10 1D0 G\r"); //this was edited out
            Thread.Sleep(30); //this was edited out

            //Clear out port and place in holding string
            VerMessage = VerPort.ReadExisting(); //this was edited out

            if (VerMessage.Length < 2) //this was edited out
            {
                WriteMessageQueue("Connection to vertical motor failed");
            }
            else //this was edited out
            {
                //Update the boolean
                isVerCon = true;

                //Show the connection label
                btnVerCon.BackColor = System.Drawing.Color.Green;


                //Show the vertical controls
                boxVer.Visible = true;

                //check to see if autozero should be allowed
                // if (isSenCon && isStrainCon) //IsDynCon removed Brian
                {
                    //btnAutoZero.Enabled = true;
                }
            }
        }//Connect to the Vertical Motor
        void VerDisconnect()
        {
            //Turn off the motor for starters
            VerPort.Write("S\r");
            Thread.Sleep(300);
            VerPort.Write("OFF\r");
            isVerCon = false;
            //show that vertical motor is disconected on gui
            btnVerCon.BackColor = System.Drawing.Color.Red;
            btnVerCon.ForeColor = System.Drawing.Color.White;
            boxVer.Visible = false;
            //btnAutoZero.Enabled = false;
        }//Disconect and turn off the Vertical Motor
        void StopVer() //Stop the vertical Motor
        {
            VerPort.Write("S\r");
        }
        #endregion
        #region Traverse Motor functions
        void btnTraCon_Click(object sender, EventArgs e)
        {
            if (!isTraCon)
            {
                //attempt to sync with motor
                    double hz = ((double)nmTraIPM.Value) * 5.3333;
                    if (WriteModbusQueue(2, 1798, 1, true))
                    {
                        isTraCon = true;
                        btnTraCon.BackColor = Color.Green;
                        boxTrav.Visible = true;
                    }
                    else
                        WriteMessageQueue("Connection to Traverse Motor Failed");

                
            }
            else
            {
                //Stop the motor
                //onTraStop(new object(), new EventArgs());

                isTraCon = false;
                btnTraCon.BackColor = Color.Red;
                boxTrav.Visible = false;
            }
        }
        void btnTraConnect()
        {

        }
        void btnTraDisconnect()
        {

        }
        void btnTraRun_Click(object sender, EventArgs e)
        {
            if (!isTraCon)
                MessageBox.Show("Traverse not connected");
            else
            {
                ChangeTraRef((double)nmTraIPM.Value);
                StartTraFor();
            }
        }
        void btnTraRev_Click(object sender, EventArgs e)
        {
            if (!isTraCon)
                MessageBox.Show("Traverse not connected");
            else
            {
                ChangeTraRef((double)nmTraIPM.Value);
                StartTraRev();
            }
        }
        void btnTraStop_Click(object sender, EventArgs e)
        {
            StopTra();
        }
        void nmTraIPM_ValueChanged(object sender, EventArgs e)
        {
            if (!isSimControl)
            {
                ChangeTraRef((double)nmTraIPM.Value);
            }
        }
        void StopTra()//Stop the traverse Motor
        {
            //if (isTraCon) Dont check to see if its connected safer to just try to stop it incase someting messes up
            {
                WriteModbusQueue(2, 1798, 1, false);
                isTraOn = false;
            }
        }
        void ChangeTraRef(double IPM)//Change the Traverse Reference
        {
            if (isTraCon)
            {
                    //double hz = (IPM) * 5.3333;
                    //double hz = IPM * 2.135;
                    //double hz = IPM * 4.2433;
                    double hz = IPM * 2.8599;  //Modified by Brian when larger pulley was installed on traverse drive.
                    WriteModbusQueue(2, 1797, ((int)(hz * 10)), false);
                
            }
            else
            {
                StopTra();
            }
        }
        void StartTraFor()//Start the traverse going forward
        {
            if (isTraCon)
            {
                WriteModbusQueue(2, 1798, 18, false);
                isTraOn = true;
            }
            else
            {
                StopTra();
            }
        }
        void StartTraRev()//Start the traverse going in reverse
        {
            if (isTraCon)
            {
                WriteModbusQueue(2, 1798, 34, false);
                isTraOn = true;
            }
            else
            {
                StopTra();
            }
        }
        #endregion
        #region Lateral Motor functions
        void btnLatCon_Click(object sender, EventArgs e)
        {
            if (!isLatCon)
            {
                //attempt to sync with motor
                double hz = (double)nmLatIPM.Value;
                int sendhz = (int)(hz * 10);

                if (WriteModbusQueue(3, 1797, sendhz, true))
                {
                    isLatCon = true;
                    btnLatCon.BackColor = Color.Green;
                    boxLat.Visible = true;
                }
                else
                    WriteMessageQueue("Connection to Lateral Motor Failed");
            }
            else
            {
                //Stop the motor
                StopLat();

                isLatCon = false;
                btnLatCon.BackColor = Color.Red;
                boxLat.Visible = false;
            }
        }
        void btnLatStop_Click(object sender, EventArgs e)
        {
            StopLat();
        }
        void btnLatRun_Click(object sender, EventArgs e)
        {
            if (!isLatCon)
                MessageBox.Show("Lateral not connected");
            else
            {
                ChangeLatRef((double)nmLatIPM.Value);
                StartLatIn();
            }
        }
        void btnLatOut_Click(object sender, EventArgs e)
        {
            if (!isLatCon)
                MessageBox.Show("Lateral not connected");
            else
            {
                ChangeLatRef((double)nmLatIPM.Value);
                StartLatOut();
            }
        }
        void nmLatIPM_ValueChanged(object sender, EventArgs e)
        {
            if (!isSimControl)
            {
                ChangeLatRef((double)nmLatIPM.Value);
            }
        }
        void ChangeLatRef(double IPM)//Change the Lateral Reference
        {
            if (isLatCon)
            {
                double LatinRPM = IPM * 54.5;
                double hz = LatinRPM / 60.0;
                WriteModbusQueue(3, 1797, ((int)(hz * 10)), false);
            }
        }
        void StopLat()//Stop the lateral Motor
        {
            WriteModbusQueue(3, 1798, 1, false);
            isLatOn = false;
        }
        void StartLatIn()//Start the lateral motor going inward
        {
            if (isLatCon)
            {
                /* Old code for dealing with backlash maybe?
                //take the mutex
                LatEncMutex.WaitOne();

                //reset LateralEncoder
                //myTask.Stop();
                //myTask.Start();
                //grab hold point
                LatEncCountHoldPoint = myCounterReader.ReadSingleSampleInt32();

                //Store some values
                LatEncBackLashHold = LatEncBackLash;
                LatEncBackLashLoss = LatEncBackLash * LatEncRatio;
                LatEncLocHold = LatEncLoc;
                LatEncRotHold = LatEncRot;

                //release the mutex
                LatEncMutex.ReleaseMutex();
                */

                WriteModbusQueue(3, 1798, 18, false);
                isLatOn = true;
                isLatIn = true;
            }
            else
            {
                StopLat();
            }

        }
        void StartLatOut()//Start the lateral motor going outward
        {
            if (isLatCon)
            {
                /* Old code for dealing with backlash?
                //take the mutex
                LatEncMutex.WaitOne();

                //reset LateralEncoder
                //myTask.Stop();
                //myTask.Start();
                //grab hold point
                LatEncCountHoldPoint = myCounterReader.ReadSingleSampleInt32();

                //Store some values
                LatEncBackLashHold = LatEncBackLash;
                LatEncBackLashLoss = (LatEncBackLashWidth - LatEncBackLash) * LatEncRatio;
                LatEncLocHold = LatEncLoc;
                LatEncRotHold = LatEncRot;

                //release the mutex
                LatEncMutex.ReleaseMutex();
                */

                WriteModbusQueue(3, 1798, 34, false);
                isLatOn = true;
                isLatIn = false;
            }
            else
            {
                StopLat();
            }
        }
        #endregion
        #region Spindle Motor functions
        void btnSpiCon_Click(object sender, EventArgs e)
        {
            if (!isSpiCon)
            {
                //attempt to sync with motor
                //int speed = (int)((double)nmSpiRPM.Value * 2.122);
                int speed = (int)((double)nmSpiRPM.Value * 3.772);
                //int speed = (int)((double)nmSpiRPM.Value * 3.7022); //Adjusted by BG and CC on 9/7/12
                if (WriteModbusQueue(1, 2000, 0, true))
                {
                    isSpiCon = true;
                    btnSpiCon.BackColor = Color.Green;
                    boxSpi.Visible = true;
                }
                else
                    WriteMessageQueue("Connection to Spindle Motor Failed");
            }
            else
            {
                StopSpi();//Stop the motor
                isSpiCon = false;
                btnSpiCon.BackColor = Color.Red;
                boxSpi.Visible = false;
            }
        }
        void nmSpiRPM_ValueChanged(object sender, EventArgs e)
        {
            if (!isSimControl)
            {
                ChangeSpiRef((double)nmSpiRPM.Value);
            }
        }
        void btnSpiRun_Click(object sender, EventArgs e)
        {
            //if (!isSpiCon)
            //{
            //    WriteMessageQueue("Spindle not connected");
            //}
            //else if (!isPressure)
            //{
            //    MessageBox.Show("No Pressure");
            //}
            //else if (!isLubOn)
            //{
            //    MessageBox.Show("The Lubricator is off");
            //}
            //else
            {
                //if vertical is high slow it down
                if (nmVerVel.Value > 1)
                    nmVerVel.Value = 1;

                if (rbSpiCW.Checked)
                    StartSpiCW();
                else
                    StartSpiCCW();
            }
            
        }
        private void btnSpiStop_Click(object sender, EventArgs e)
        {
            StopSpi();
        }
        void ChangeSpiRef(double RPM) //Change the Spindle Reference
        {
            if (isSpiCon)
            {
                //old pulley speed
                // int speed = (int)((double)nmSpiRPM.Value * 1.58);

                // int speed = (int)(RPM * 2.122);
                int speed = (int)(RPM * 3.772);
                //int speed = (int)(RPM * 3.7022); //Adjusted by BG and CC 9/7/12
                WriteModbusQueue(1, 2002, speed, false);
            }
            else
            {
                StopSpi();
            }
        }
        void StopSpi()//Stop the Spindle Motor
        {
            //Stop the spindle
            WriteModbusQueue(1, 2000, 0, false);
            isSpiOn = false;
        }
        void StartSpiCW()//Start the spindle motor going clockwise
        {
            if (isSpiCon)
            {
                WriteModbusQueue(1, 2000, 1, false);
                isSpiOn = true;
            }
            else
            {
                StopSpi();
            }
        }
        void StartSpiCCW()//Start the spindle motor going counter-clockwise
        {
            if (isSpiCon)
            {
                WriteModbusQueue(1, 2000, 3, false);
                isSpiOn = true;
            }
            else
            {
                StopSpi();
            }
        }
        #endregion
        #region MysteryBox
        void btnBoxCon_Click(object sender, EventArgs e)
        {
            if (!isSenCon)
            {
                WriteMessageQueue("In order to complete connection to sensor box, vertical sensor must pass over reference mark");
                ControlThreadStarter(MysteryBoxConnect, "MysteryBoxConnect");
                boxLub.Visible = true;
            }
            else
            {
                try
                {
                    isSenCon = false;
                    Thread.Sleep(500);
                    SenClient.Close();
                    SenClient = new TcpClient();
                    //Update Bools
                    isSenCon = false;
                    btnSenCon.BackColor = Color.Red;
                    boxLub.Visible = false;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error Trying to disconect from Myster Box\n\n"+ex.Message.ToString(), "Mystery Box Disconect Error");
                }
            }
        }
        private void btnLubOn_Click(object sender, EventArgs e)
        {
            if (isSenCon)
            {
                if (!isLubOn)
                {
                    LubOn();
                }
                else
                {
                    LubOff();
                }
            }
            else
            {
                WriteMessageQueue("Need to be connected to Sensor Box");
            }
        }
        void LubOn()
        {
            //Take control of Mutex
            SendMutex.WaitOne();
            SendData += "L1";
            SendMutex.ReleaseMutex();
            btnLubOn.BackColor = Color.Green;
            isLubOn = true;
        }
        void LubOff()
        {
            //Take control of Mutex
            SendMutex.WaitOne();
            SendData += "L0";
            SendMutex.ReleaseMutex();
            btnLubOn.BackColor = Color.Red;
            isLubOn = false;
        }
        void MysteryBoxConnect()
        {
            int ByteCount;
            String RecieveData;
            try
            {
                SenClient = new TcpClient();
                SenClient.Connect(IPAddress.Parse("10.10.6.100"), 23);
                SenStream = SenClient.GetStream();

                SendData = "A";
                SendData += "X";

                //Clear BytesOut
                //Translate the passed message
                BytesOut = Encoding.ASCII.GetBytes(SendData);
                //Send the message to the sensor client

                SenStream.Write(BytesOut, 0, BytesOut.Length);

                //Read the incoming data
                ByteCount = SenStream.Read(BytesIn, 0, BytesIn.Length);
                RecieveData = Encoding.ASCII.GetString(BytesIn, 0, ByteCount);
                isSenCon = true;
                btnSenCon.BackColor = Color.Green;
                StopVer();
            }
            catch (Exception ex)
            {
                StopVer();
                MessageBox.Show(ex.Message.ToString(), "Mystery Box Connect Error");
            }
            WriteMessageQueue("MysteryBoxConnect Completed");
            ControlSemaphore.Release(1);
        }
        #endregion
        #region DynoFunctions
        private void btnDynCon_Click(object sender, EventArgs e)
        {
            if (!isDynCon)
            {
                DynoConnect();
            }
            else
            {
                DynoDisconnect();
            }
        }
        void DynoDisconnect()
        {
            //Release Control of the Dyno
            DynoControlPort.Write("CR0\r");
            isDynCon = false;
            btnDynCon.BackColor = Color.Red;
        }
        void DynoConnect()
        {
            //Set up rs232 control:Set the range to one:Reset the Dyno
            DynoControlPort.Write("CR1:RG0:RO0\r");

            Thread.Sleep(100);

            //operate the Dyno
            DynoControlPort.Write("RO1\r");
            Thread.Sleep(100);

            isDynCon = true;
            btnDynCon.BackColor = Color.Green;
        }
        void DynoReset()
        {
            //Reset and then operate the Dyno
            DynoControlPort.Write("RO0\r");

            Thread.Sleep(500);

            DynoControlPort.Write("RO1\r");
        }
        double Count2Volt(ushort a)
        {
            //convert count given from PCIM-DAS 1602 DAQ Card to a voltage
            return ((double)a * 10.0 / 65535.0 - 5);
        }
        #endregion
        #region GUI Helper functions
        void GUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isVerCon)
            {
                //Clear out port
                VerPort.ReadExisting();
                //Turn off motor
                VerPort.Write("E S OFF 1R\r");
            }
            //turn back on the internet
            //System.Diagnostics.Process proc = new System.Diagnostics.Process();
            //proc.StartInfo.FileName = "C:\\Users\\J\\Desktop\\INTERNET_CONFIG.bat";
            //proc.Start();
            Process.GetCurrentProcess().Kill();
        }
        void timer1_Tick(object sender, EventArgs e)
        {
            if (isSetVerWeld)
            {
                nmVerWeld.Value = (decimal)VerLoc;
                isSetVerWeld = false;
            }
            textBox1.AppendText(ReadMessageQueue());
            lblZHistory.Text = ZMaxHistory.ToString("F0");
            lblXYHistory.Text = MaxXYForceHistory.ToString("F1");
            lblTHistory.Text = MaxTForceHistory.ToString("F2");
            lblZForce.Text = ZForceDyno.ToString("F1");
            lblZForceStrain.Text = ZForce.ToString("F1");
            lblXForce.Text = XForce.ToString("F1");
            lblYForce.Text = YForce.ToString("F1");
            lblTForce.Text = TForce.ToString("F2");
            lblExternalVolt.Text = XYForceAverage.ToString();
            if (isSenCon)
            {
                lblVerLoc.Text = VerLoc.ToString();
                lblTraLoc.Text = TraLoc.ToString();
                lblLatLoc.Text = LatLoc.ToString();
            }
            else
            {
                lblVerLoc.Text = "Connect MysteryBox";
                lblTraLoc.Text = "Connect MysteryBox";
                lblLatLoc.Text = "Connect MysteryBox";
            }
            if (isSenCon && isDynCon && VerLoc > 0 && isVerCon)
                btnAutoZero.Visible = true;
            else
                btnAutoZero.Visible = false;
            if(isAlarm)
            {
                btnAlarm.Text = "Clear Alarm";
                btnAlarm.BackColor = System.Drawing.SystemColors.Control;
                btnAlarm.ForeColor = SystemColors.ControlText;
                BackColor = Color.Red;
            }
            if (isSimControl)
            {
                if (isLubWanted)
                {
                    if (!isLubOn)
                    {
                        LubOn();
                    }
                }
                else
                {
                    if (isLubOn)
                    {
                        LubOff();
                    }
                }
            }
            if (isPressure)
                lblPreOn.Text = "Pressure: ON";
            else
                lblPreOn.Text = "Pressure: OFF";
        }
        private String ReadMessageQueue()
        {
            string mes = "";
            if (MessageQueueSemaphore.WaitOne(0))
            {
                MessageQueueMutex.WaitOne();
                mes = (string)MessageQueue.Dequeue();
                MessageQueueMutex.ReleaseMutex();
            }
            return mes;
        }
        public void WriteMessageQueue(string message)
        {
            message = message + "\r\n";
            MessageQueueMutex.WaitOne();
            MessageQueue.Enqueue(message);
            MessageQueueMutex.ReleaseMutex();
            MessageQueueSemaphore.Release(1);
        }
        private void GUI_FormLoading(object sender, EventArgs e)
        {
            btnZzero_Click(new object(), new EventArgs());
            btnResetZhistory_Click(new object(), new EventArgs());
            UpdateLimitValues();
        }


        #endregion
        #region Safety functions
        void SafetyCheck()
        {
            #region Check Safety Limits
            if (isSenCon)
            {
                if ((VerLoc > VerMax || VerLoc < VerMin) && !isAlarm)
                    onAlarm("Vertical Out of Bounds");
                if ((TraLoc > TraMax || TraLoc < TraMin) && !isAlarm)
                    onAlarm("Traverse Out of Bounds");
                if ((LatLoc < LatMin || LatLoc > LatMax) && !isAlarm)
                    onAlarm("Lateral Out of Bounds");
                if (isEmergencyButton && !isAlarm)
                    onAlarm("Emergency Button Pressed");
            }
            if (isDynCon)
            {
                //if (XYForce > MaxXYForce && !isAlarm) now using a 5 point moving average to reduce noise spikes J 8/29/2016
                if (XYForceAverage > MaxXYForce && !isAlarm)
                    onAlarm("XY force limit exceeded");
                if (Math.Abs(TForce) > MaxTForce && !isAlarm)
                    onAlarm("Torque limit exceeded");
                if (ZForceDyno > MaxZForce && !isAlarm)
                    onAlarm("ZForce limit exceeded");
            }
            else
            {
                if (ZForce > MaxZForce && !isAlarm)
                    onAlarm("ZForce limit exceeded");
            }
            #endregion
            #region Update Max Histories
            if (ZForce > ZMaxHistory)
                ZMaxHistory = ZForce;
            if (XYForce > MaxXYForceHistory)
                MaxXYForceHistory = XYForce;
            if (Math.Abs(TForce) > MaxTForceHistory)
                MaxTForceHistory = Math.Abs(TForce);
            #endregion
        }
        void onAlarm(string Message)
        {
            if (!isAlarm)
            {
                isAlarm = true;
                //Kill Process
                StopControlThread();
                if (isVerCon){ StopVer();}//stop the vertical motor if connected
                if (isTraCon){StopTra();}//stop the traverse motor
                if (isLatCon){StopLat();}
                if (isSpiCon){StopSpi();}//stop the spindle motor


                //Reset the motor speeds
                //Reset spindle, traverse and lateral speeds
                if (isSpiCon) {ChangeSpiRef(0.0); }//set speed to 0
                if (isTraCon){ChangeTraRef(0.0);}
                if (isLatCon) {ChangeLatRef(0.0);}
                StopAllMotors();
                WriteMessageQueue("Error:"+Message);//for debug
            }
        }
        private void btnAlarm_Click(object sender, EventArgs e)
        {
            if (!isAlarm)
            {
                onAlarm("Alarm button pushed");
            }
            else
            {
                isAlarm = false;
                BackColor = System.Drawing.SystemColors.Control;
                btnAlarm.Text = "Trigger Alarm";
                btnAlarm.BackColor = Color.Red;
                btnAlarm.ForeColor = Color.White;
            }
        }

        public void UpdateLimitValues()
        {
            VerWeld = (double)nmVerWeld.Value;
            Program.Safetyfrm.UpdateLimitsSafe();
        }

        private void Safety_click(object sender, EventArgs e)
        {
            Program.Safetyfrm.Show();
        }
        public void btnAbort_Click(object sender, EventArgs e)
        {
            if (!isAbort)
            {
                isAbort = true;
                btnAbort.BackColor = SystemColors.Control;
                btnAbort.ForeColor = SystemColors.ControlText;
                btnAbort.Text = "Stop Abort";
                if (isVerCon) { StopVer(); }//stop the vertical motor if connected
                if (isTraCon) { StopTra(); }//stop the traverse motor
                if (isLatCon) { StopLat(); }
                if (isSpiCon) { StopSpi(); }//stop the spindle motor
                isLubWanted = false;
                isSimControl = false;
                StopControlThread();
                StopAllMotors();//stop one more time just in case?
                MatlabExecute("set_param(bdroot(gcs), 'SimulationCommand', 'stop');");//stop matlab simulation
            }
            else
            {
                isAbort = false;
                btnAbort.BackColor = Color.Red;
                btnAbort.ForeColor = Color.White;
                btnAbort.Text = "Abort";
            }
        }
        void StopControlThread()
        {
            if (ControlSemaphore.WaitOne(0))
            {
                //if mutex can be grabed, no control threads should be running
                ControlSemaphore.Release(1);
            }
            else
            {
                //if mutex can not grabed the thread should abort 
                MachineControlThread.Abort();
                WriteMessageQueue("Thread Aborted");
                ControlSemaphore.Release(1);
            }
        }
        public void StopAllMotors()
        {
            StopVer();
            StopSpi();
            StopLat();
            StopTra();
        }
        #endregion
        private void btnZzero_Click(object sender, EventArgs e)
        {
            double ZoffestTemp = 0;
            double[] Zoffset1 = new double[5];
            if (isDynCon)
            {
                DynoReset();
            }
            for (int i = 0; i < 5; i++)
            {
                Zoffset1[i] = strainReader.ReadSingleSample()[0];
                ZoffestTemp += Zoffset1[i];
                Thread.Sleep(5);
            }
            ZoffestTemp = ZoffestTemp / 5;
            Zoffset = ZoffestTemp;
        }
        public void ControlThreadStarter(Action MethodName,string name)
        {
            if (!isAlarm)
            {
                if (!isAbort)
                {
                    if (ControlSemaphore.WaitOne(0))
                    {
                        WriteMessageQueue(name + " started");
                        MachineControlThread = new Thread(new ThreadStart(MethodName));
                        MachineControlThread.Start();
                    }
                    else
                    {
                        WriteMessageQueue("Thread already working");
                    }
                }
                else
                {
                    WriteMessageQueue("Turn off Abort");
                }
            }
            else
            {
                WriteMessageQueue("THE ALARM IS ON TURN OFF THE ALARM FIRST");
            }
        }
        private void btnResetZhistory_Click(object sender, EventArgs e)
        {
            ZMaxHistory = 0;
            MaxTForceHistory = 0;
            MaxXYForceHistory = 0;
        }
        private void btnAutoZero_Click(object sender, EventArgs e)
        {
                ControlThreadStarter(AutoAutoZeroLoop,"autoautozero");
        }
        private void AutoAutoZeroLoop()
        {
            MessageBox.Show("AutoAUTOzero:\nMake sure tool positioned over set piece\n");
            double autoautozerocurrent, autoautozeroprevious;
            bool isAutoAutoZeroZeroed;
            //*********Zero the axial force reading************
            btnZzero_Click(new object(), new EventArgs());
            if(MaxZForce<800)
                MaxZForce= 800;
            Thread.Sleep(1000);
            double azforce;
            azforce = (double)nmPinchForce.Value; //from the spot welding box added by chase on 4/9/12

            if (ZForce > 100) // This is a test for initial force
                MessageBox.Show("Force Already Exceeds Turn-On Force");
            else
            {
                WriteMessageQueue("The AutoAutoZero Process Will Now Begin\nNOTE:Currently using .0006 as tolerance");
                //Alert GUI of first upward motion
                //isAutoisfirstup = true;

                //initiate table raising
                VerPort.Write("MC H+ A10 V.3 G\r");

                while (ZForce < azforce) //changed from 100 to azforce by Chase 4/9/2012
                {
                    Thread.Sleep(0);//changed to sleep 0 by Jay 6/10/2015
                }
                //Stop the motor
                StopVer();

                Thread.Sleep(500);

                ////Alert GUI of first downward motion
                //isAutoisfirstdown = true;

                ////initiate table lowering
                VerPort.Write("MN A10 V2 D-3000 G\r");

                ////Sleep for one second
                Thread.Sleep(1000);

                ////Alert GUI of final upward motion
                //isAutoissecondup = true;
                autoautozerocurrent = -2;
                autoautozeroprevious = -1;
                bool LoopRepeat = true;
                isAutoAutoZeroZeroed = false;
                while (!isAutoAutoZeroZeroed)
                {
                    autoautozeroprevious = autoautozerocurrent;
                    ////Do final upward in a loop
                    LoopRepeat = true;

                    while (LoopRepeat)
                    {
                        //Wait for turn off signal
                        if (ZForce > azforce) //changed from ZForce changed by Chase on 11/21/11 //changed from 100 to azforce by Chase 4/9/2012
                        {
                            LoopRepeat = false;
                        }
                        else
                        {
                            VerPort.Write("MN A1 V1 D100 G\r");
                        }
                        Thread.Sleep(1000);
                    }

                    ////Sleep for stability
                    Thread.Sleep(500);
                    autoautozerocurrent = VerLoc;
                    if (Math.Abs(autoautozerocurrent - autoautozeroprevious) < .0006)
                    {
                        isAutoAutoZeroZeroed = true;
                    }
                    else
                    {
                        //move table down
                        VerPort.Write("MN A10 V2 D-3000 G\r");

                        ////Sleep for one second
                        Thread.Sleep(1000);
                    }
                    WriteMessageQueue(autoautozerocurrent.ToString("F4"));
                }
                ////Set weld height
                isSetVerWeld = true;
                VerWeld = VerLoc;


                ////Sleep for assurance of GUI update
                Thread.Sleep(1000);
                //move table down
                VerPort.Write("MN A10 V2 D-3000 G\r");
                Thread.Sleep(1000);
                //Clear out port
                VerPort.ReadExisting(); //this was edited out

                //Query the motor and establish RS-232 control
                VerPort.Write("E ON 1R\r"); //this was edited out
                Thread.Sleep(300); //this was edited out

                //Turn off limits
                VerPort.Write("1LD3\r"); //this was edited out
                Thread.Sleep(30); //this was edited out

                //Clear out port and place in holding string
                VerPort.ReadExisting(); //this was edited out
                double tempver = VerLoc;
                //initiate table raising
                VerPort.Write("MC H- A10 V2 G\r");
                while(VerLoc>(tempver-.125))
                {
                    Thread.Sleep(30);
                }
                StopVer();
                UpdateLimitValues();
                WriteMessageQueue("AutoAutoZero Completed");
                ControlSemaphore.Release(1);

            }

        }
        bool trueifpositive(double n)
        {
            if (n >= 0)
                return true;
            else
                return false;
        }
        public void SimulinkReciveLoop()
        {
            Program.Safetyfrm.UpdateLimitsWelding();
            bool isSimDone = false;
            isSimControl = true;
            Byte[] RecieveBytes = new Byte[256];
            double tempvar;
            #region Traverse
            bool isTrafor;
            bool isTraSpeedPositive = true;
            double[] TraSpeed = new double[2];
            double TraSpeedMagnitude = 0;
            double TraSpeedLimit = 12;
            ChangeTraRef(0);
            #endregion
            #region Lateral
            bool isLatout;
            bool isLatSpeedPositive = true;
            double[] LatSpeed = new double[2];
            double LatSpeedMagnitude = 0;
            double LatSpeedLimit = 12;
            ChangeLatRef(0);
            #endregion
            #region Vertical
            string VerMessage;
            bool isVerDown = true;
            double VerSpeedMagnitude = 0;
            double[] VerSpeed = new double[2];
            double VerSpeedLimit = 5;
            double VerAccel = 10;
            double VerSpeedMinimum = 0.00001;//from motor guide
            VerMessage = "E MC ";
            VerPort.Write(VerMessage);
            #endregion
            #region Spindle
            string SpiMessage;
            bool isSpiCW = true;
            bool isSpiSpeedCW = true;
            double SpiSpeedMagnitude = 0;
            double[] SpiSpeed = new double[2];
            double SpiSpeedLimit = 2000;
            ChangeSpiRef(0);
            StartSpiCW();
            #endregion
            while (SimulinkReviceUDP.Available > 0)//clear udp buffer, want to recieve latest packet
            {
                RecieveBytes = SimulinkReviceUDP.Receive(ref IPRecivefromSimulink);
            }
            RecieveBytes = SimulinkReviceUDP.Receive(ref IPRecivefromSimulink);
            TraSpeed[0] = BitConverter.ToDouble(RecieveBytes, 0);
            LatSpeed[0] = BitConverter.ToDouble(RecieveBytes, 8);
            VerSpeed[0] = BitConverter.ToDouble(RecieveBytes, 16);
            SpiSpeed[0] = BitConverter.ToDouble(RecieveBytes, 24);
            #region Initialize Traverse Speed
            isTraSpeedPositive = trueifpositive(TraSpeed[0]);
            if (isTraSpeedPositive)
            {
                StartTraFor();
                isTrafor = true;
            }
            else
            {
                StartTraRev();
                isTrafor = false;
            }
            #endregion
            #region Initialize Lateral Speed
            isLatSpeedPositive = trueifpositive(LatSpeed[0]);
            if (isLatSpeedPositive)
            {
                StartLatOut();
                isLatout = true;
            }
            else
            {
                StartLatIn();
                isLatout = false;
            }
            #endregion
            #region Initialize Spindle Speed
            isSpiSpeedCW = trueifpositive(SpiSpeed[0]);
            if (isSpiSpeedCW)
            {
                StartSpiCW();
                isSpiCW = true;
            }
            else
            {
                StartSpiCCW();
                isSpiCW = false;
            }
            #endregion
            TraSpeed[0] = -99.9;
            LatSpeed[0] = -99.9; 
            VerSpeed[0] = -99.9; 
            SpiSpeed[0] = -99.9; 
            while (!isAbort&&!isSimDone&&!isAlarm)
            {
                while (SimulinkReviceUDP.Available > 0)//clear udp buffer, want to recieve latest packet
                {
                    RecieveBytes = SimulinkReviceUDP.Receive(ref IPRecivefromSimulink);
                }
                RecieveBytes = SimulinkReviceUDP.Receive(ref IPRecivefromSimulink);
                TraSpeed[1] = TraSpeed[0];
                TraSpeed[0] = BitConverter.ToDouble(RecieveBytes, 0);
                LatSpeed[1] = LatSpeed[0];
                LatSpeed[0] = BitConverter.ToDouble(RecieveBytes, 8);
                VerSpeed[1] = VerSpeed[0];
                VerSpeed[0] = BitConverter.ToDouble(RecieveBytes, 16);
                SpiSpeed[1] = SpiSpeed[0];
                SpiSpeed[0]= BitConverter.ToDouble(RecieveBytes, 24);
                tempvar = BitConverter.ToDouble(RecieveBytes, 32);
                isSimDone = System.Convert.ToBoolean(tempvar);
                #region Updatae Traverse Speed
                if (TraSpeed[0] != TraSpeed[1])
                {
                    isTraSpeedPositive = trueifpositive(TraSpeed[0]);
                    TraSpeedMagnitude = Math.Abs(TraSpeed[0]);
                    //Saturate Traverse speed
                    if (TraSpeedMagnitude > TraSpeedLimit) TraSpeedMagnitude = TraSpeedLimit;
                    if (isTraSpeedPositive)
                    {
                        if (!isTrafor)
                        {
                            StartTraFor();
                            isTrafor = true;
                        }
                    }
                    else
                    {
                        if (isTrafor)
                        {
                            StartTraRev();
                            isTrafor = false;
                        }
                    }
                    ChangeTraRef(TraSpeedMagnitude);
                }
                #endregion
                #region Update Lateral Speed
                if (LatSpeed[0] != LatSpeed[1])
                {
                    isLatSpeedPositive = trueifpositive(LatSpeed[0]);
                    LatSpeedMagnitude = Math.Abs(LatSpeed[0]);
                    //Limit Latverse speed
                    if (LatSpeedMagnitude > LatSpeedLimit) LatSpeedMagnitude = LatSpeedLimit;
                    if (isLatSpeedPositive)
                    {
                        if (!isLatout)
                        {
                            StartLatOut();
                            isLatout = true;
                        }
                    }
                    else
                    {
                        if (isLatout)
                        {
                            StartLatIn();
                            isLatout = false;
                        }
                    }
                    ChangeLatRef(LatSpeedMagnitude);
                }
                #endregion
                #region Update Vertical Speed
                if (VerSpeed[0] != VerSpeed[1])
                {
                    isVerDown = trueifpositive(VerSpeed[0]);
                    VerSpeedMagnitude = Math.Abs(VerSpeed[0]);
                    if (VerSpeedMagnitude > VerSpeedLimit)
                        VerSpeedMagnitude = VerSpeedLimit;
                    if (VerSpeedMagnitude < VerSpeedMinimum)
                        VerSpeedMagnitude = VerSpeedMinimum;
                    VerMessage = "H";
                    if (isVerDown)
                        VerMessage += "+";
                    else
                        VerMessage += "-";

                    VerMessage += "A" + VerAccel.ToString("F2") + " V" + VerSpeedMagnitude.ToString("F5") + " G\r";
                    VerPort.Write(VerMessage);
                }
                #endregion
                #region Update Spindle Speed
                if (SpiSpeed[0] != SpiSpeed[1])
                {
                    isSpiSpeedCW = trueifpositive(SpiSpeed[0]);
                    SpiSpeedMagnitude = Math.Abs(SpiSpeed[0]);
                    if (SpiSpeedMagnitude > 100)
                        isLubWanted = true;
                    else
                        isLubWanted = false;
                    //Limit Spindle speed
                    if (SpiSpeedMagnitude > SpiSpeedLimit) SpiSpeedMagnitude = SpiSpeedLimit;
                    if (isSpiSpeedCW)
                    {
                        if (!isSpiCW)
                        {
                            StartSpiCW();
                            isSpiCW = true;
                        }
                        SpiMessage = "CW";
                    }
                    else
                    {
                        if (isSpiCW)
                        {
                            StartSpiCCW();
                            isSpiCW = false;
                        }
                        SpiMessage = "CCW";
                    }
                    ChangeSpiRef(SpiSpeedMagnitude);
                    WriteMessageQueue("Spi set to:" + SpiSpeedMagnitude.ToString("F0") + SpiMessage);

                }
                #endregion
                Thread.Sleep(5);
            }
            StopAllMotors();
            isLubWanted = false;
            btnZzero_Click(new object(), new EventArgs());
            Program.Safetyfrm.UpdateLimitsSafe();
            Thread.Sleep(25);
            isSimControl = false;
            WriteMessageQueue("SimulinkRecieve Completed");
            ControlSemaphore.Release(1);
        }
        private void OpenTrackingWeldfrm(object sender, EventArgs e)
        {
            TrackingSimcs frm = new TrackingSimcs();
            frm.Show();
        }
        private void OpenLinearWeldfrm(object sender, EventArgs e)
        {
            LinearWeldcs frm = new LinearWeldcs();
            frm.Show();
        }
    }
}   
