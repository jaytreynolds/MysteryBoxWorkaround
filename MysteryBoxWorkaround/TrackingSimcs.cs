//#define M//define if using matlab outside of the one opened by the welding program
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MysteryBoxWorkaround
{
    public partial class TrackingSimcs : Form
    {
        public TrackingSimcs()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Program.MainForm.Width, 0);
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            WriteParameters();
            Program.MainForm.MatlabUpdateParameters();
        }
        private void btnLoad_Click(object sender, EventArgs e)
        {
            string path = @textBox1.Text;
            path = "open_system('" + path + "')";
            Program.MainForm.MatlabExecute(path);
        }
        private void btnEndWeld_Click(object sender, EventArgs e)
        {
            Program.MainForm.MatlabExecute("SoftStop=1;");
            Program.MainForm.MatlabUpdateParameters();
        }
        private void btnStartWeld_Click(object sender, EventArgs e)
        {
            Program.MainForm.StopAllMotors();
            #if M
            string path = @textBox1.Text;
            string mstring,sign="";
            if (tbRecGroup.ToString().Length <= 36 || tbRecFilename.ToString().Length <= 36)
                Program.MainForm.WriteMessageQueue("Did you give your save file a name?");
            else if (!Program.MainForm.isSenCon || !Program.MainForm.isTraCon || !Program.MainForm.isVerCon || !Program.MainForm.isDynCon || !Program.MainForm.isLatCon || !Program.MainForm.isSpiCon)
            {
                Program.MainForm.WriteMessageQueue("Connect Everything");
            }
            else if (!Program.MainForm.isPressure)
            {
                Program.MainForm.WriteMessageQueue("Gas Pressure to Low");
            }
            else
            {
                Program.MainForm.MatlabExecute("clear");
                Program.MainForm.MatlabExecute("SoftStop=0");
                Program.MainForm.MatlabExecute("Date='" + DateTime.Now.ToString("g") + "'");
                WriteParameters();
                Program.MainForm.MatlabExecute("set_param('" + path + "', 'ExtModeMexArgs', '');");//reset mex file arugments to zero
                //Program.MainForm.MatlabExecute("slbuild(bdroot(gcs));");//need to run weldcontroller as an admin, note do not need to rebuild unless you change simulink file
                Program.MainForm.MatlabExecute("set_param('"+path+"', 'SimulationMode', 'external');");
                Program.MainForm.MatlabExecute("set_param('" + path + "', 'SimulationCommand', 'connect');");
                Program.MainForm.MatlabExecute("set_param('"+path+"', 'SimulationCommand', 'start');");
                Program.MainForm.WriteMessageQueue("Building and Compiling Simulink Model, be paitent");
                Program.MainForm.ControlThreadStarter(Program.MainForm.SimulinkReciveLoop, "Simulink Recieve");
            }
#else
            Program.MainForm.ControlThreadStarter(Program.MainForm.SimulinkReciveLoop, "Simulink Recieve");
#endif
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            Program.MainForm.btnAbort_Click(new object(), new EventArgs());
        }
        private void btnBuild_Click(object sender, EventArgs e)
        {

            string path = @textBox1.Text;
            Program.MainForm.MatlabExecute("clear");
            Program.MainForm.MatlabExecute("SoftStop=0");
            WriteParameters();
            Program.MainForm.MatlabExecute("set_param('" + path + "', 'ExtModeMexArgs', '');");//reset mex file arugments to zero
                                                                                            //Program.MainForm.MatlabExecute("slbuild(bdroot(gcs));");//need to run weldcontroller as an admin, note do not need to rebuild unless you change simulink file
            Program.MainForm.MatlabExecute("set_param('" + path + "', 'SimulationMode', 'external');");
            Program.MainForm.MatlabExecute("slbuild('" + path + "')");
            Program.MainForm.WriteMessageQueue("Building and Compiling Simulink Model, be paitent");
        }
        private void WriteParameters()
        {
            string mstring, sign = "";
            Program.MainForm.MatlabExecute("SavePath=" + @"'C:\Users\J\Desktop\WeldData\" + tbRecGroup.Text + @"\" + tbRecFilename.Text + "'");
            Program.MainForm.MatlabExecute("Folder=" + @"'C:\Users\J\Desktop\WeldData\" + tbRecGroup.Text + "'");
            Program.MainForm.MatlabExecute("Date='" + DateTime.Now.ToString("g") + "'");
            double VerWeld = Program.MainForm.VerWeld;//get VerWeld from mainform
            mstring = "VerWeld=" + VerWeld.ToString("F5");
            Program.MainForm.MatlabExecute(mstring);
            Program.MainForm.MatlabExecute("VerPlunge=" + nmVerPlunge.Value.ToString("F5"));
            Program.MainForm.MatlabExecute("TraSpeed=" + nmTraIPM.Value.ToString());
            Program.MainForm.MatlabExecute("TiltAngle=" + nmTiltAngle.Value.ToString());
            Program.MainForm.MatlabExecute("Tool='" + cbTool.Text + "'");
            if (rbSpiCCW.Checked)
                sign = "-";
            Program.MainForm.MatlabExecute("SpiRPM=" + sign + nmSpiRPM.Value.ToString());
            Program.MainForm.MatlabExecute("TraEnd=" + nmTraEnd.Value.ToString());
            Program.MainForm.MatlabExecute("PlungeSpeed=" + nmPlungeSpeed.Value.ToString());
            Program.MainForm.MatlabExecute("GrooveLoc=" + nmGrooveLoc.Value.ToString());
        }
        private void Weld_Load(object sender, EventArgs e)
        {
#if M
            Program.MainForm.WriteMatlabQueue(@"cd('C:\Users\J\Desktop\Simulink Weld Files')");
            string path = @textBox1.Text;
            path = "open_system('" + path + "')";
            Program.MainForm.MatlabExecute(path);
#endif
        }
    }
}
