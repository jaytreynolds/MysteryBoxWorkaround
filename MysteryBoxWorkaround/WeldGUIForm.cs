using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MysteryBoxWorkaround
{
    public partial class WeldGUIForm : Form
    {
        String WeldName;
        private int counter = 0;
        ParameterControl[] Param = new ParameterControl[50];
        public WeldGUIForm(string Name)
        {
            WeldName = Name;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(Program.MainForm.Width, 0);
        }

        private void WeldGUIForm_Load(object sender, EventArgs e)
        {
            counter = 0;
            string line;
            try
            {
                char[] delimiterChars = { '\t' };
                System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\J\Desktop\Weld Param Forms\" + WeldName + ".txt");
                file.ReadLine();//throw out first line
                line=file.ReadLine();//read in weld file name
                int fileExtPos = line.LastIndexOf(".");
                if (fileExtPos >= 0)
                    line = line.Substring(0, fileExtPos);
                textBox1.Text = line;
                this.Text = line;
                file.ReadLine();//throw out first line
                while ((line = file.ReadLine()) != null)
                {
                    string[] words = line.Split(delimiterChars);
                    Param[counter] = new ParameterControl();
                    Param[counter].label.Text = words[0];
                    Param[counter].MatlabParam = words[1];
                    Param[counter].NM.Value = decimal.Parse(words[2]);
                    Param[counter].NM.Minimum = decimal.Parse(words[3]);
                    Param[counter].NM.Maximum = decimal.Parse(words[4]);
                    Param[counter].NM.DecimalPlaces = int.Parse(words[5]);
                    flowLayoutPanel1.Controls.Add(Param[counter]);
                    counter++;
                }
                file.Close();
                this.Height = flowLayoutPanel1.Height + 285;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show("File not found, have you created the csv for this weld? Is it in the right location? " + ex.ToString());
                this.Close();
            }
            catch (System.IO.IOException ex)
            {
                MessageBox.Show("Cannot open file, is it open somewhere else? Check file permisssions? " + ex.ToString());
                this.Close();
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Tab deliminated file has incorrectly formated vales check to see if you have strings where there should be numbers " + ex.ToString());
                this.Close();
            }
            Program.MainForm.WriteMatlabQueue(@"cd('C:\Users\J\Desktop\Simulink Weld Files')");
            string path = @textBox1.Text;
            path = "open_system('" + path + "')";
            Program.MainForm.MatlabExecute(path);
            //%Form2.Height = 226 + counter * 100;
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
            Program.MainForm.SoftStop = 1;
        }
        private void btnStartWeld_Click(object sender, EventArgs e)
        {
            Program.MainForm.StopAllMotors();
            Program.MainForm.SoftStop = 0;
            string path = @textBox1.Text;
            string mstring, sign = "";
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
                Program.MainForm.MatlabExecute("Date='" + DateTime.Now.ToString("g") + "'");
                WriteParameters();
                Program.MainForm.MatlabExecute("set_param('" + path + "', 'ExtModeMexArgs', '');");//reset mex file arugments to zero
                //Program.MainForm.MatlabExecute("slbuild(bdroot(gcs));");//need to run weldcontroller as an admin, note do not need to rebuild unless you change simulink file
                Program.MainForm.MatlabExecute("set_param('" + path + "', 'SimulationMode', 'external');");
                Program.MainForm.MatlabExecute("set_param('" + path + "', 'SimulationCommand', 'connect');");
                Program.MainForm.MatlabExecute("set_param('" + path + "', 'SimulationCommand', 'start');");
                Program.MainForm.ControlThreadStarter(Program.MainForm.SimulinkReciveLoop, "Simulink Recieve");
                Program.MainForm.WriteMessageQueue("Building and Compiling Simulink Model, be paitent");
            }
        }
        private void btnAbort_Click(object sender, EventArgs e)
        {
            Program.MainForm.btnAbort_Click(new object(), new EventArgs());
            Program.MainForm.SoftStop = 0;
        }
        private void btnBuild_Click(object sender, EventArgs e)
        {
            string path = @textBox1.Text;
            Program.MainForm.MatlabExecute("clear");
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
            Program.MainForm.MatlabExecute("Tool='" + cbTool.Text + "'");
            for (int i = 0; i < counter; i++)
            {
                Program.MainForm.MatlabExecute(Param[i].MatlabParam + "=" + Param[i].NM.Value.ToString());
            }
        }
    }
}
