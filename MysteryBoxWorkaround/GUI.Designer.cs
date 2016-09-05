using System;//new 7/7/2016
namespace MysteryBoxWorkaround
{
    partial class GUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            #region old code as of 7/7/2016
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            #endregion
            #region new code 7/7/2016
            if (Disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }

                // be sure to release the memory buffer... 
                if (MemHandle != IntPtr.Zero)
                    MccDaq.MccService.WinBufFreeEx(MemHandle);
            }
            base.Dispose(Disposing);
            #endregion
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnVerCon = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSpiCon = new System.Windows.Forms.Button();
            this.btnLatCon = new System.Windows.Forms.Button();
            this.btnTraCon = new System.Windows.Forms.Button();
            this.btnDynCon = new System.Windows.Forms.Button();
            this.btnSenCon = new System.Windows.Forms.Button();
            this.BoxMotors = new System.Windows.Forms.GroupBox();
            this.boxSpi = new System.Windows.Forms.GroupBox();
            this.nmSpiRPM = new System.Windows.Forms.NumericUpDown();
            this.rbSpiCW = new System.Windows.Forms.RadioButton();
            this.rbSpiCCW = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSpiStop = new System.Windows.Forms.Button();
            this.btnSpiRun = new System.Windows.Forms.Button();
            this.boxTrav = new System.Windows.Forms.GroupBox();
            this.nmTraIPM = new System.Windows.Forms.NumericUpDown();
            this.label16 = new System.Windows.Forms.Label();
            this.lblTraLoc = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.btnTraStop = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnTraRun = new System.Windows.Forms.Button();
            this.boxLat = new System.Windows.Forms.GroupBox();
            this.nmLatIPM = new System.Windows.Forms.NumericUpDown();
            this.label25 = new System.Windows.Forms.Label();
            this.lblLatLoc = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.btnLatStop = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnLatRun = new System.Windows.Forms.Button();
            this.boxVer = new System.Windows.Forms.GroupBox();
            this.lblVerLoc = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.rbVerDiscrete = new System.Windows.Forms.RadioButton();
            this.rbVerContinuous = new System.Windows.Forms.RadioButton();
            this.nmVerTurns = new System.Windows.Forms.NumericUpDown();
            this.nmVerRet = new System.Windows.Forms.NumericUpDown();
            this.nmVerWeld = new System.Windows.Forms.NumericUpDown();
            this.nmVerAcc = new System.Windows.Forms.NumericUpDown();
            this.nmVerVel = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnVerStop = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnVerRun = new System.Windows.Forms.Button();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblTHistory = new System.Windows.Forms.Label();
            this.lblXYHistory = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnResetHistory = new System.Windows.Forms.Button();
            this.lblZHistory = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.boxLub = new System.Windows.Forms.GroupBox();
            this.btnLubOn = new System.Windows.Forms.Button();
            this.lblPreOn = new System.Windows.Forms.Label();
            this.btnAlarm = new System.Windows.Forms.Button();
            this.boxOperations = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.nmPinchForce = new System.Windows.Forms.NumericUpDown();
            this.btnAutoZero = new System.Windows.Forms.Button();
            this.btnZzero = new System.Windows.Forms.Button();
            this.btnAbort = new System.Windows.Forms.Button();
            this.boxForce = new System.Windows.Forms.GroupBox();
            this.lblExternalVolt = new System.Windows.Forms.Label();
            this.lblZForceStrain = new System.Windows.Forms.Label();
            this.label108 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lblTForce = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblYForce = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.lblXForce = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.lblZForce = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.weldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.linearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trackingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.safetyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.BoxMotors.SuspendLayout();
            this.boxSpi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSpiRPM)).BeginInit();
            this.boxTrav.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTraIPM)).BeginInit();
            this.boxLat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmLatIPM)).BeginInit();
            this.boxVer.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerTurns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerRet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerWeld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerAcc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerVel)).BeginInit();
            this.groupBox15.SuspendLayout();
            this.boxLub.SuspendLayout();
            this.boxOperations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPinchForce)).BeginInit();
            this.boxForce.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnVerCon
            // 
            this.btnVerCon.BackColor = System.Drawing.Color.Red;
            this.btnVerCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerCon.ForeColor = System.Drawing.Color.White;
            this.btnVerCon.Location = new System.Drawing.Point(6, 19);
            this.btnVerCon.Name = "btnVerCon";
            this.btnVerCon.Size = new System.Drawing.Size(75, 23);
            this.btnVerCon.TabIndex = 0;
            this.btnVerCon.Text = "Vertical";
            this.btnVerCon.UseVisualStyleBackColor = false;
            this.btnVerCon.Click += new System.EventHandler(this.btnVerCon_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSpiCon);
            this.groupBox1.Controls.Add(this.btnLatCon);
            this.groupBox1.Controls.Add(this.btnTraCon);
            this.groupBox1.Controls.Add(this.btnDynCon);
            this.groupBox1.Controls.Add(this.btnSenCon);
            this.groupBox1.Controls.Add(this.btnVerCon);
            this.groupBox1.Location = new System.Drawing.Point(5, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 199);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connections";
            // 
            // btnSpiCon
            // 
            this.btnSpiCon.BackColor = System.Drawing.Color.Red;
            this.btnSpiCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpiCon.ForeColor = System.Drawing.Color.White;
            this.btnSpiCon.Location = new System.Drawing.Point(6, 164);
            this.btnSpiCon.Name = "btnSpiCon";
            this.btnSpiCon.Size = new System.Drawing.Size(75, 23);
            this.btnSpiCon.TabIndex = 0;
            this.btnSpiCon.Text = "Spindel";
            this.btnSpiCon.UseVisualStyleBackColor = false;
            this.btnSpiCon.Click += new System.EventHandler(this.btnSpiCon_Click);
            // 
            // btnLatCon
            // 
            this.btnLatCon.BackColor = System.Drawing.Color.Red;
            this.btnLatCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLatCon.ForeColor = System.Drawing.Color.White;
            this.btnLatCon.Location = new System.Drawing.Point(6, 135);
            this.btnLatCon.Name = "btnLatCon";
            this.btnLatCon.Size = new System.Drawing.Size(75, 23);
            this.btnLatCon.TabIndex = 0;
            this.btnLatCon.Text = "Lateral";
            this.btnLatCon.UseVisualStyleBackColor = false;
            this.btnLatCon.Click += new System.EventHandler(this.btnLatCon_Click);
            // 
            // btnTraCon
            // 
            this.btnTraCon.BackColor = System.Drawing.Color.Red;
            this.btnTraCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraCon.ForeColor = System.Drawing.Color.White;
            this.btnTraCon.Location = new System.Drawing.Point(6, 106);
            this.btnTraCon.Name = "btnTraCon";
            this.btnTraCon.Size = new System.Drawing.Size(75, 23);
            this.btnTraCon.TabIndex = 0;
            this.btnTraCon.Text = "Traverse";
            this.btnTraCon.UseVisualStyleBackColor = false;
            this.btnTraCon.Click += new System.EventHandler(this.btnTraCon_Click);
            // 
            // btnDynCon
            // 
            this.btnDynCon.BackColor = System.Drawing.Color.Red;
            this.btnDynCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDynCon.ForeColor = System.Drawing.Color.White;
            this.btnDynCon.Location = new System.Drawing.Point(6, 77);
            this.btnDynCon.Name = "btnDynCon";
            this.btnDynCon.Size = new System.Drawing.Size(75, 23);
            this.btnDynCon.TabIndex = 0;
            this.btnDynCon.Text = "Dyno";
            this.btnDynCon.UseVisualStyleBackColor = false;
            this.btnDynCon.Click += new System.EventHandler(this.btnDynCon_Click);
            // 
            // btnSenCon
            // 
            this.btnSenCon.BackColor = System.Drawing.Color.Red;
            this.btnSenCon.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSenCon.ForeColor = System.Drawing.Color.White;
            this.btnSenCon.Location = new System.Drawing.Point(6, 48);
            this.btnSenCon.Name = "btnSenCon";
            this.btnSenCon.Size = new System.Drawing.Size(75, 23);
            this.btnSenCon.TabIndex = 0;
            this.btnSenCon.Text = "SensorBox";
            this.btnSenCon.UseVisualStyleBackColor = false;
            this.btnSenCon.Click += new System.EventHandler(this.btnBoxCon_Click);
            // 
            // BoxMotors
            // 
            this.BoxMotors.Controls.Add(this.boxSpi);
            this.BoxMotors.Controls.Add(this.boxTrav);
            this.BoxMotors.Controls.Add(this.boxLat);
            this.BoxMotors.Controls.Add(this.boxVer);
            this.BoxMotors.Location = new System.Drawing.Point(98, 39);
            this.BoxMotors.Name = "BoxMotors";
            this.BoxMotors.Size = new System.Drawing.Size(564, 281);
            this.BoxMotors.TabIndex = 13;
            this.BoxMotors.TabStop = false;
            this.BoxMotors.Text = "Motor Controls";
            // 
            // boxSpi
            // 
            this.boxSpi.Controls.Add(this.nmSpiRPM);
            this.boxSpi.Controls.Add(this.rbSpiCW);
            this.boxSpi.Controls.Add(this.rbSpiCCW);
            this.boxSpi.Controls.Add(this.label13);
            this.boxSpi.Controls.Add(this.btnSpiStop);
            this.boxSpi.Controls.Add(this.btnSpiRun);
            this.boxSpi.Location = new System.Drawing.Point(426, 15);
            this.boxSpi.Name = "boxSpi";
            this.boxSpi.Size = new System.Drawing.Size(133, 198);
            this.boxSpi.TabIndex = 6;
            this.boxSpi.TabStop = false;
            this.boxSpi.Text = "Spindle Controls";
            this.boxSpi.Visible = false;
            // 
            // nmSpiRPM
            // 
            this.nmSpiRPM.Location = new System.Drawing.Point(46, 174);
            this.nmSpiRPM.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.nmSpiRPM.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmSpiRPM.Name = "nmSpiRPM";
            this.nmSpiRPM.Size = new System.Drawing.Size(66, 20);
            this.nmSpiRPM.TabIndex = 31;
            this.nmSpiRPM.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nmSpiRPM.ValueChanged += new System.EventHandler(this.nmSpiRPM_ValueChanged);
            // 
            // rbSpiCW
            // 
            this.rbSpiCW.AutoSize = true;
            this.rbSpiCW.Checked = true;
            this.rbSpiCW.Location = new System.Drawing.Point(6, 152);
            this.rbSpiCW.Name = "rbSpiCW";
            this.rbSpiCW.Size = new System.Drawing.Size(76, 17);
            this.rbSpiCW.TabIndex = 30;
            this.rbSpiCW.TabStop = true;
            this.rbSpiCW.Text = "ClockWise";
            this.rbSpiCW.UseVisualStyleBackColor = true;
            // 
            // rbSpiCCW
            // 
            this.rbSpiCCW.AutoSize = true;
            this.rbSpiCCW.Location = new System.Drawing.Point(6, 129);
            this.rbSpiCCW.Name = "rbSpiCCW";
            this.rbSpiCCW.Size = new System.Drawing.Size(116, 17);
            this.rbSpiCCW.TabIndex = 29;
            this.rbSpiCCW.Text = "Counter-ClockWise";
            this.rbSpiCCW.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 176);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 13);
            this.label13.TabIndex = 28;
            this.label13.Text = "RPM:";
            // 
            // btnSpiStop
            // 
            this.btnSpiStop.BackColor = System.Drawing.Color.Red;
            this.btnSpiStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSpiStop.ForeColor = System.Drawing.Color.White;
            this.btnSpiStop.Location = new System.Drawing.Point(5, 74);
            this.btnSpiStop.Name = "btnSpiStop";
            this.btnSpiStop.Size = new System.Drawing.Size(119, 49);
            this.btnSpiStop.TabIndex = 27;
            this.btnSpiStop.Text = "Stop Spindle";
            this.btnSpiStop.UseVisualStyleBackColor = false;
            this.btnSpiStop.Click += new System.EventHandler(this.btnSpiStop_Click);
            // 
            // btnSpiRun
            // 
            this.btnSpiRun.Location = new System.Drawing.Point(5, 20);
            this.btnSpiRun.Name = "btnSpiRun";
            this.btnSpiRun.Size = new System.Drawing.Size(119, 49);
            this.btnSpiRun.TabIndex = 26;
            this.btnSpiRun.Text = "Run Spindle";
            this.btnSpiRun.UseVisualStyleBackColor = true;
            this.btnSpiRun.Click += new System.EventHandler(this.btnSpiRun_Click);
            // 
            // boxTrav
            // 
            this.boxTrav.Controls.Add(this.nmTraIPM);
            this.boxTrav.Controls.Add(this.label16);
            this.boxTrav.Controls.Add(this.lblTraLoc);
            this.boxTrav.Controls.Add(this.label14);
            this.boxTrav.Controls.Add(this.btnTraStop);
            this.boxTrav.Controls.Add(this.button3);
            this.boxTrav.Controls.Add(this.btnTraRun);
            this.boxTrav.Location = new System.Drawing.Point(224, 15);
            this.boxTrav.Name = "boxTrav";
            this.boxTrav.Size = new System.Drawing.Size(191, 123);
            this.boxTrav.TabIndex = 5;
            this.boxTrav.TabStop = false;
            this.boxTrav.Text = "Traversal Controls";
            this.boxTrav.Visible = false;
            // 
            // nmTraIPM
            // 
            this.nmTraIPM.DecimalPlaces = 1;
            this.nmTraIPM.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nmTraIPM.Location = new System.Drawing.Point(130, 73);
            this.nmTraIPM.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nmTraIPM.Name = "nmTraIPM";
            this.nmTraIPM.Size = new System.Drawing.Size(55, 20);
            this.nmTraIPM.TabIndex = 35;
            this.nmTraIPM.ValueChanged += new System.EventHandler(this.nmTraIPM_ValueChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(99, 77);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 32;
            this.label16.Text = "IPM:";
            // 
            // lblTraLoc
            // 
            this.lblTraLoc.AutoSize = true;
            this.lblTraLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTraLoc.Location = new System.Drawing.Point(140, 102);
            this.lblTraLoc.Name = "lblTraLoc";
            this.lblTraLoc.Size = new System.Drawing.Size(14, 13);
            this.lblTraLoc.TabIndex = 30;
            this.lblTraLoc.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(99, 101);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(46, 13);
            this.label14.TabIndex = 28;
            this.label14.Text = "Loc (In):";
            // 
            // btnTraStop
            // 
            this.btnTraStop.BackColor = System.Drawing.Color.Red;
            this.btnTraStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraStop.ForeColor = System.Drawing.Color.White;
            this.btnTraStop.Location = new System.Drawing.Point(6, 62);
            this.btnTraStop.Name = "btnTraStop";
            this.btnTraStop.Size = new System.Drawing.Size(87, 56);
            this.btnTraStop.TabIndex = 23;
            this.btnTraStop.Text = "Stop Traverse";
            this.btnTraStop.UseVisualStyleBackColor = false;
            this.btnTraStop.Click += new System.EventHandler(this.btnTraStop_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(99, 18);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 45);
            this.button3.TabIndex = 22;
            this.button3.Text = "Table Forward";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnTraRev_Click);
            // 
            // btnTraRun
            // 
            this.btnTraRun.Location = new System.Drawing.Point(5, 19);
            this.btnTraRun.Name = "btnTraRun";
            this.btnTraRun.Size = new System.Drawing.Size(88, 44);
            this.btnTraRun.TabIndex = 22;
            this.btnTraRun.Text = "Table Reverse";
            this.btnTraRun.UseVisualStyleBackColor = true;
            this.btnTraRun.Click += new System.EventHandler(this.btnTraRun_Click);
            // 
            // boxLat
            // 
            this.boxLat.Controls.Add(this.nmLatIPM);
            this.boxLat.Controls.Add(this.label25);
            this.boxLat.Controls.Add(this.lblLatLoc);
            this.boxLat.Controls.Add(this.label28);
            this.boxLat.Controls.Add(this.btnLatStop);
            this.boxLat.Controls.Add(this.button2);
            this.boxLat.Controls.Add(this.btnLatRun);
            this.boxLat.Location = new System.Drawing.Point(224, 148);
            this.boxLat.Name = "boxLat";
            this.boxLat.Size = new System.Drawing.Size(191, 127);
            this.boxLat.TabIndex = 6;
            this.boxLat.TabStop = false;
            this.boxLat.Text = "Lateral Controls";
            this.boxLat.Visible = false;
            // 
            // nmLatIPM
            // 
            this.nmLatIPM.DecimalPlaces = 1;
            this.nmLatIPM.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nmLatIPM.Location = new System.Drawing.Point(130, 80);
            this.nmLatIPM.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nmLatIPM.Name = "nmLatIPM";
            this.nmLatIPM.Size = new System.Drawing.Size(55, 20);
            this.nmLatIPM.TabIndex = 39;
            this.nmLatIPM.ValueChanged += new System.EventHandler(this.nmLatIPM_ValueChanged);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(95, 81);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(29, 13);
            this.label25.TabIndex = 38;
            this.label25.Text = "IPM:";
            // 
            // lblLatLoc
            // 
            this.lblLatLoc.AutoSize = true;
            this.lblLatLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLatLoc.Location = new System.Drawing.Point(139, 105);
            this.lblLatLoc.Name = "lblLatLoc";
            this.lblLatLoc.Size = new System.Drawing.Size(15, 15);
            this.lblLatLoc.TabIndex = 40;
            this.lblLatLoc.Text = "0";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(87, 107);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(46, 13);
            this.label28.TabIndex = 38;
            this.label28.Text = "Loc (In):";
            // 
            // btnLatStop
            // 
            this.btnLatStop.BackColor = System.Drawing.Color.Red;
            this.btnLatStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLatStop.ForeColor = System.Drawing.Color.White;
            this.btnLatStop.Location = new System.Drawing.Point(90, 15);
            this.btnLatStop.Name = "btnLatStop";
            this.btnLatStop.Size = new System.Drawing.Size(95, 59);
            this.btnLatStop.TabIndex = 25;
            this.btnLatStop.Text = "Stop Lateral";
            this.btnLatStop.UseVisualStyleBackColor = false;
            this.btnLatStop.Click += new System.EventHandler(this.btnLatStop_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(9, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 49);
            this.button2.TabIndex = 24;
            this.button2.Text = "Table Out";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnLatOut_Click);
            // 
            // btnLatRun
            // 
            this.btnLatRun.Location = new System.Drawing.Point(9, 16);
            this.btnLatRun.Name = "btnLatRun";
            this.btnLatRun.Size = new System.Drawing.Size(75, 49);
            this.btnLatRun.TabIndex = 24;
            this.btnLatRun.Text = "Table In";
            this.btnLatRun.UseVisualStyleBackColor = true;
            this.btnLatRun.Click += new System.EventHandler(this.btnLatRun_Click);
            // 
            // boxVer
            // 
            this.boxVer.Controls.Add(this.lblVerLoc);
            this.boxVer.Controls.Add(this.label9);
            this.boxVer.Controls.Add(this.groupBox9);
            this.boxVer.Controls.Add(this.nmVerRet);
            this.boxVer.Controls.Add(this.nmVerWeld);
            this.boxVer.Controls.Add(this.nmVerAcc);
            this.boxVer.Controls.Add(this.nmVerVel);
            this.boxVer.Controls.Add(this.label7);
            this.boxVer.Controls.Add(this.label6);
            this.boxVer.Controls.Add(this.label3);
            this.boxVer.Controls.Add(this.label2);
            this.boxVer.Controls.Add(this.btnVerStop);
            this.boxVer.Controls.Add(this.button1);
            this.boxVer.Controls.Add(this.btnVerRun);
            this.boxVer.Location = new System.Drawing.Point(6, 15);
            this.boxVer.Name = "boxVer";
            this.boxVer.Size = new System.Drawing.Size(212, 260);
            this.boxVer.TabIndex = 4;
            this.boxVer.TabStop = false;
            this.boxVer.Text = "Vertical Controls";
            this.boxVer.Visible = false;
            // 
            // lblVerLoc
            // 
            this.lblVerLoc.AutoSize = true;
            this.lblVerLoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerLoc.Location = new System.Drawing.Point(83, 240);
            this.lblVerLoc.Name = "lblVerLoc";
            this.lblVerLoc.Size = new System.Drawing.Size(14, 13);
            this.lblVerLoc.TabIndex = 24;
            this.lblVerLoc.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Height (In):";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.rbVerDiscrete);
            this.groupBox9.Controls.Add(this.rbVerContinuous);
            this.groupBox9.Controls.Add(this.nmVerTurns);
            this.groupBox9.Location = new System.Drawing.Point(6, 118);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(206, 59);
            this.groupBox9.TabIndex = 21;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Position Control";
            // 
            // rbVerDiscrete
            // 
            this.rbVerDiscrete.AutoSize = true;
            this.rbVerDiscrete.Location = new System.Drawing.Point(14, 16);
            this.rbVerDiscrete.Name = "rbVerDiscrete";
            this.rbVerDiscrete.Size = new System.Drawing.Size(110, 17);
            this.rbVerDiscrete.TabIndex = 4;
            this.rbVerDiscrete.Text = "Discrete (# Turns)";
            this.rbVerDiscrete.UseVisualStyleBackColor = true;
            // 
            // rbVerContinuous
            // 
            this.rbVerContinuous.AutoSize = true;
            this.rbVerContinuous.Checked = true;
            this.rbVerContinuous.Location = new System.Drawing.Point(14, 37);
            this.rbVerContinuous.Name = "rbVerContinuous";
            this.rbVerContinuous.Size = new System.Drawing.Size(78, 17);
            this.rbVerContinuous.TabIndex = 5;
            this.rbVerContinuous.TabStop = true;
            this.rbVerContinuous.Text = "Continuous";
            this.rbVerContinuous.UseVisualStyleBackColor = true;
            // 
            // nmVerTurns
            // 
            this.nmVerTurns.Location = new System.Drawing.Point(130, 16);
            this.nmVerTurns.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nmVerTurns.Name = "nmVerTurns";
            this.nmVerTurns.Size = new System.Drawing.Size(52, 20);
            this.nmVerTurns.TabIndex = 6;
            // 
            // nmVerRet
            // 
            this.nmVerRet.DecimalPlaces = 3;
            this.nmVerRet.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nmVerRet.Location = new System.Drawing.Point(113, 212);
            this.nmVerRet.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.nmVerRet.Name = "nmVerRet";
            this.nmVerRet.Size = new System.Drawing.Size(52, 20);
            this.nmVerRet.TabIndex = 20;
            this.nmVerRet.Value = new decimal(new int[] {
            45,
            0,
            0,
            65536});
            // 
            // nmVerWeld
            // 
            this.nmVerWeld.DecimalPlaces = 4;
            this.nmVerWeld.Location = new System.Drawing.Point(113, 183);
            this.nmVerWeld.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nmVerWeld.Name = "nmVerWeld";
            this.nmVerWeld.Size = new System.Drawing.Size(57, 20);
            this.nmVerWeld.TabIndex = 19;
            this.nmVerWeld.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nmVerAcc
            // 
            this.nmVerAcc.Location = new System.Drawing.Point(165, 98);
            this.nmVerAcc.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nmVerAcc.Name = "nmVerAcc";
            this.nmVerAcc.Size = new System.Drawing.Size(47, 20);
            this.nmVerAcc.TabIndex = 17;
            this.nmVerAcc.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // nmVerVel
            // 
            this.nmVerVel.DecimalPlaces = 2;
            this.nmVerVel.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nmVerVel.Location = new System.Drawing.Point(165, 75);
            this.nmVerVel.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nmVerVel.Name = "nmVerVel";
            this.nmVerVel.Size = new System.Drawing.Size(47, 20);
            this.nmVerVel.TabIndex = 14;
            this.nmVerVel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 214);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 16);
            this.label7.TabIndex = 13;
            this.label7.Text = "Return Height:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 185);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 16);
            this.label6.TabIndex = 12;
            this.label6.Text = "Weld Height:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(97, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Acceleration:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Velocity:";
            // 
            // btnVerStop
            // 
            this.btnVerStop.BackColor = System.Drawing.Color.Red;
            this.btnVerStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerStop.ForeColor = System.Drawing.Color.White;
            this.btnVerStop.Location = new System.Drawing.Point(95, 19);
            this.btnVerStop.Name = "btnVerStop";
            this.btnVerStop.Size = new System.Drawing.Size(94, 49);
            this.btnVerStop.TabIndex = 1;
            this.btnVerStop.Text = "Stop Vertical";
            this.btnVerStop.UseVisualStyleBackColor = false;
            this.btnVerStop.Click += new System.EventHandler(this.btnVerStop_Click);
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(14, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "Lower Table";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnVerLowerStage_Click);
            // 
            // btnVerRun
            // 
            this.btnVerRun.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnVerRun.Location = new System.Drawing.Point(14, 19);
            this.btnVerRun.Name = "btnVerRun";
            this.btnVerRun.Size = new System.Drawing.Size(75, 37);
            this.btnVerRun.TabIndex = 0;
            this.btnVerRun.Text = "Raise Table";
            this.btnVerRun.UseVisualStyleBackColor = true;
            this.btnVerRun.Click += new System.EventHandler(this.btnVerRun_Click);
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.label5);
            this.groupBox15.Controls.Add(this.lblTHistory);
            this.groupBox15.Controls.Add(this.lblXYHistory);
            this.groupBox15.Controls.Add(this.label4);
            this.groupBox15.Controls.Add(this.btnResetHistory);
            this.groupBox15.Controls.Add(this.lblZHistory);
            this.groupBox15.Controls.Add(this.label116);
            this.groupBox15.Location = new System.Drawing.Point(98, 326);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(395, 39);
            this.groupBox15.TabIndex = 134;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Max Load History";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(221, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 125;
            this.label5.Text = "T(Nm):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTHistory
            // 
            this.lblTHistory.AutoSize = true;
            this.lblTHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTHistory.Location = new System.Drawing.Point(256, 14);
            this.lblTHistory.Name = "lblTHistory";
            this.lblTHistory.Size = new System.Drawing.Size(16, 16);
            this.lblTHistory.TabIndex = 123;
            this.lblTHistory.Text = "0";
            // 
            // lblXYHistory
            // 
            this.lblXYHistory.AutoSize = true;
            this.lblXYHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXYHistory.Location = new System.Drawing.Point(151, 15);
            this.lblXYHistory.Name = "lblXYHistory";
            this.lblXYHistory.Size = new System.Drawing.Size(16, 16);
            this.lblXYHistory.TabIndex = 123;
            this.lblXYHistory.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(116, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 124;
            this.label4.Text = "XY(N):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnResetHistory
            // 
            this.btnResetHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetHistory.Location = new System.Drawing.Point(326, 11);
            this.btnResetHistory.Name = "btnResetHistory";
            this.btnResetHistory.Size = new System.Drawing.Size(60, 24);
            this.btnResetHistory.TabIndex = 122;
            this.btnResetHistory.Text = "Reset ";
            this.btnResetHistory.UseVisualStyleBackColor = true;
            this.btnResetHistory.Click += new System.EventHandler(this.btnResetZhistory_Click);
            // 
            // lblZHistory
            // 
            this.lblZHistory.AutoSize = true;
            this.lblZHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZHistory.Location = new System.Drawing.Point(41, 14);
            this.lblZHistory.Name = "lblZHistory";
            this.lblZHistory.Size = new System.Drawing.Size(16, 16);
            this.lblZHistory.TabIndex = 43;
            this.lblZHistory.Text = "0";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.Location = new System.Drawing.Point(6, 16);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(31, 13);
            this.label116.TabIndex = 43;
            this.label116.Text = "Z(N):";
            this.label116.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 373);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(196, 136);
            this.textBox1.TabIndex = 132;
            // 
            // boxLub
            // 
            this.boxLub.Controls.Add(this.btnLubOn);
            this.boxLub.Controls.Add(this.lblPreOn);
            this.boxLub.Location = new System.Drawing.Point(5, 228);
            this.boxLub.Name = "boxLub";
            this.boxLub.Size = new System.Drawing.Size(87, 55);
            this.boxLub.TabIndex = 133;
            this.boxLub.TabStop = false;
            this.boxLub.Visible = false;
            // 
            // btnLubOn
            // 
            this.btnLubOn.BackColor = System.Drawing.Color.Red;
            this.btnLubOn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLubOn.ForeColor = System.Drawing.Color.White;
            this.btnLubOn.Location = new System.Drawing.Point(6, 31);
            this.btnLubOn.Name = "btnLubOn";
            this.btnLubOn.Size = new System.Drawing.Size(75, 23);
            this.btnLubOn.TabIndex = 14;
            this.btnLubOn.Text = "Lubricator";
            this.btnLubOn.UseVisualStyleBackColor = false;
            this.btnLubOn.Click += new System.EventHandler(this.btnLubOn_Click);
            // 
            // lblPreOn
            // 
            this.lblPreOn.AutoSize = true;
            this.lblPreOn.Location = new System.Drawing.Point(10, 13);
            this.lblPreOn.Name = "lblPreOn";
            this.lblPreOn.Size = new System.Drawing.Size(74, 13);
            this.lblPreOn.TabIndex = 0;
            this.lblPreOn.Text = "Pressure: OFF";
            // 
            // btnAlarm
            // 
            this.btnAlarm.BackColor = System.Drawing.Color.Red;
            this.btnAlarm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarm.ForeColor = System.Drawing.Color.White;
            this.btnAlarm.Location = new System.Drawing.Point(2, 289);
            this.btnAlarm.Name = "btnAlarm";
            this.btnAlarm.Size = new System.Drawing.Size(87, 52);
            this.btnAlarm.TabIndex = 22;
            this.btnAlarm.Text = "Trigger Alarm";
            this.btnAlarm.UseVisualStyleBackColor = false;
            this.btnAlarm.Click += new System.EventHandler(this.btnAlarm_Click);
            // 
            // boxOperations
            // 
            this.boxOperations.Controls.Add(this.label30);
            this.boxOperations.Controls.Add(this.nmPinchForce);
            this.boxOperations.Controls.Add(this.btnAutoZero);
            this.boxOperations.Controls.Add(this.btnZzero);
            this.boxOperations.Controls.Add(this.btnAbort);
            this.boxOperations.Location = new System.Drawing.Point(205, 373);
            this.boxOperations.Name = "boxOperations";
            this.boxOperations.Size = new System.Drawing.Size(257, 136);
            this.boxOperations.TabIndex = 135;
            this.boxOperations.TabStop = false;
            this.boxOperations.Text = "Operations";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(94, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(100, 13);
            this.label30.TabIndex = 18;
            this.label30.Text = "Pre-Pinch Force (N)";
            // 
            // nmPinchForce
            // 
            this.nmPinchForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nmPinchForce.Location = new System.Drawing.Point(97, 30);
            this.nmPinchForce.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nmPinchForce.Name = "nmPinchForce";
            this.nmPinchForce.Size = new System.Drawing.Size(66, 23);
            this.nmPinchForce.TabIndex = 84;
            this.nmPinchForce.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // btnAutoZero
            // 
            this.btnAutoZero.Location = new System.Drawing.Point(11, 21);
            this.btnAutoZero.Name = "btnAutoZero";
            this.btnAutoZero.Size = new System.Drawing.Size(75, 32);
            this.btnAutoZero.TabIndex = 0;
            this.btnAutoZero.Text = "AutoZero";
            this.btnAutoZero.UseVisualStyleBackColor = true;
            this.btnAutoZero.Click += new System.EventHandler(this.btnAutoZero_Click);
            // 
            // btnZzero
            // 
            this.btnZzero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZzero.Location = new System.Drawing.Point(174, 42);
            this.btnZzero.Name = "btnZzero";
            this.btnZzero.Size = new System.Drawing.Size(75, 94);
            this.btnZzero.TabIndex = 88;
            this.btnZzero.Text = "Manual Zero ";
            this.btnZzero.UseVisualStyleBackColor = true;
            this.btnZzero.Click += new System.EventHandler(this.btnZzero_Click);
            // 
            // btnAbort
            // 
            this.btnAbort.BackColor = System.Drawing.Color.Red;
            this.btnAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbort.ForeColor = System.Drawing.Color.White;
            this.btnAbort.Location = new System.Drawing.Point(10, 59);
            this.btnAbort.Name = "btnAbort";
            this.btnAbort.Size = new System.Drawing.Size(158, 77);
            this.btnAbort.TabIndex = 32;
            this.btnAbort.Text = "Abort";
            this.btnAbort.UseVisualStyleBackColor = false;
            this.btnAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // boxForce
            // 
            this.boxForce.Controls.Add(this.lblExternalVolt);
            this.boxForce.Controls.Add(this.lblZForceStrain);
            this.boxForce.Controls.Add(this.label108);
            this.boxForce.Controls.Add(this.label51);
            this.boxForce.Controls.Add(this.lblTForce);
            this.boxForce.Controls.Add(this.label15);
            this.boxForce.Controls.Add(this.lblYForce);
            this.boxForce.Controls.Add(this.label40);
            this.boxForce.Controls.Add(this.lblXForce);
            this.boxForce.Controls.Add(this.label43);
            this.boxForce.Controls.Add(this.lblZForce);
            this.boxForce.Location = new System.Drawing.Point(502, 326);
            this.boxForce.Name = "boxForce";
            this.boxForce.Size = new System.Drawing.Size(160, 183);
            this.boxForce.TabIndex = 136;
            this.boxForce.TabStop = false;
            this.boxForce.Text = "Forces";
            // 
            // lblExternalVolt
            // 
            this.lblExternalVolt.AutoSize = true;
            this.lblExternalVolt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExternalVolt.Location = new System.Drawing.Point(88, 164);
            this.lblExternalVolt.Name = "lblExternalVolt";
            this.lblExternalVolt.Size = new System.Drawing.Size(16, 16);
            this.lblExternalVolt.TabIndex = 35;
            this.lblExternalVolt.Text = "0";
            // 
            // lblZForceStrain
            // 
            this.lblZForceStrain.AutoSize = true;
            this.lblZForceStrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZForceStrain.Location = new System.Drawing.Point(87, 136);
            this.lblZForceStrain.Name = "lblZForceStrain";
            this.lblZForceStrain.Size = new System.Drawing.Size(16, 16);
            this.lblZForceStrain.TabIndex = 34;
            this.lblZForceStrain.Text = "0";
            // 
            // label108
            // 
            this.label108.AutoSize = true;
            this.label108.Location = new System.Drawing.Point(6, 136);
            this.label108.Name = "label108";
            this.label108.Size = new System.Drawing.Size(64, 13);
            this.label108.TabIndex = 33;
            this.label108.Text = "Z Strain (N):";
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(6, 109);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(69, 13);
            this.label51.TabIndex = 31;
            this.label51.Text = "Torque (Nm):";
            // 
            // lblTForce
            // 
            this.lblTForce.AutoSize = true;
            this.lblTForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTForce.Location = new System.Drawing.Point(87, 109);
            this.lblTForce.Name = "lblTForce";
            this.lblTForce.Size = new System.Drawing.Size(16, 16);
            this.lblTForce.TabIndex = 32;
            this.lblTForce.Text = "0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 51);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 29;
            this.label15.Text = "Y Force (N):";
            // 
            // lblYForce
            // 
            this.lblYForce.AutoSize = true;
            this.lblYForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYForce.Location = new System.Drawing.Point(87, 51);
            this.lblYForce.Name = "lblYForce";
            this.lblYForce.Size = new System.Drawing.Size(16, 16);
            this.lblYForce.TabIndex = 30;
            this.lblYForce.Text = "0";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(6, 23);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(64, 13);
            this.label40.TabIndex = 1;
            this.label40.Text = "X Force (N):";
            // 
            // lblXForce
            // 
            this.lblXForce.AutoSize = true;
            this.lblXForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXForce.Location = new System.Drawing.Point(87, 21);
            this.lblXForce.Name = "lblXForce";
            this.lblXForce.Size = new System.Drawing.Size(16, 16);
            this.lblXForce.TabIndex = 2;
            this.lblXForce.Text = "0";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(6, 79);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(62, 13);
            this.label43.TabIndex = 3;
            this.label43.Text = "Z Dyno (N):";
            // 
            // lblZForce
            // 
            this.lblZForce.AutoSize = true;
            this.lblZForce.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZForce.Location = new System.Drawing.Point(87, 76);
            this.lblZForce.Name = "lblZForce";
            this.lblZForce.Size = new System.Drawing.Size(16, 16);
            this.lblZForce.TabIndex = 4;
            this.lblZForce.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.weldToolStripMenuItem,
            this.safetyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(660, 24);
            this.menuStrip1.TabIndex = 140;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // weldToolStripMenuItem
            // 
            this.weldToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linearToolStripMenuItem,
            this.spotToolStripMenuItem,
            this.trackingToolStripMenuItem});
            this.weldToolStripMenuItem.Name = "weldToolStripMenuItem";
            this.weldToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.weldToolStripMenuItem.Text = "Weld";
            // 
            // linearToolStripMenuItem
            // 
            this.linearToolStripMenuItem.Name = "linearToolStripMenuItem";
            this.linearToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.linearToolStripMenuItem.Text = "Linear";
            this.linearToolStripMenuItem.Click += new System.EventHandler(this.OpenLinearWeldfrm);
            // 
            // spotToolStripMenuItem
            // 
            this.spotToolStripMenuItem.Name = "spotToolStripMenuItem";
            this.spotToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.spotToolStripMenuItem.Text = "Spot";
            // 
            // trackingToolStripMenuItem
            // 
            this.trackingToolStripMenuItem.Name = "trackingToolStripMenuItem";
            this.trackingToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.trackingToolStripMenuItem.Text = "Tracking";
            this.trackingToolStripMenuItem.Click += new System.EventHandler(this.OpenTrackingWeldfrm);
            // 
            // safetyToolStripMenuItem
            // 
            this.safetyToolStripMenuItem.Name = "safetyToolStripMenuItem";
            this.safetyToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.safetyToolStripMenuItem.Text = "Safety";
            this.safetyToolStripMenuItem.Click += new System.EventHandler(this.Safety_click);
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 512);
            this.Controls.Add(this.boxForce);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.boxOperations);
            this.Controls.Add(this.btnAlarm);
            this.Controls.Add(this.boxLub);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.BoxMotors);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "GUI";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GUI_FormClosing);
            this.Load += new System.EventHandler(this.GUI_FormLoading);
            this.groupBox1.ResumeLayout(false);
            this.BoxMotors.ResumeLayout(false);
            this.boxSpi.ResumeLayout(false);
            this.boxSpi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmSpiRPM)).EndInit();
            this.boxTrav.ResumeLayout(false);
            this.boxTrav.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTraIPM)).EndInit();
            this.boxLat.ResumeLayout(false);
            this.boxLat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmLatIPM)).EndInit();
            this.boxVer.ResumeLayout(false);
            this.boxVer.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerTurns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerRet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerWeld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerAcc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerVel)).EndInit();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.boxLub.ResumeLayout(false);
            this.boxLub.PerformLayout();
            this.boxOperations.ResumeLayout(false);
            this.boxOperations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPinchForce)).EndInit();
            this.boxForce.ResumeLayout(false);
            this.boxForce.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnVerCon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSpiCon;
        private System.Windows.Forms.Button btnLatCon;
        private System.Windows.Forms.Button btnTraCon;
        private System.Windows.Forms.Button btnDynCon;
        private System.Windows.Forms.Button btnSenCon;
        private System.Windows.Forms.GroupBox BoxMotors;
        private System.Windows.Forms.GroupBox boxSpi;
        private System.Windows.Forms.NumericUpDown nmSpiRPM;
        private System.Windows.Forms.RadioButton rbSpiCW;
        private System.Windows.Forms.RadioButton rbSpiCCW;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSpiStop;
        private System.Windows.Forms.Button btnSpiRun;
        private System.Windows.Forms.GroupBox boxTrav;
        private System.Windows.Forms.NumericUpDown nmTraIPM;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblTraLoc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnTraStop;
        private System.Windows.Forms.Button btnTraRun;
        private System.Windows.Forms.GroupBox boxLat;
        private System.Windows.Forms.NumericUpDown nmLatIPM;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label lblLatLoc;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Button btnLatStop;
        private System.Windows.Forms.Button btnLatRun;
        private System.Windows.Forms.GroupBox boxVer;
        private System.Windows.Forms.Label lblVerLoc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.RadioButton rbVerDiscrete;
        private System.Windows.Forms.RadioButton rbVerContinuous;
        private System.Windows.Forms.NumericUpDown nmVerTurns;
        private System.Windows.Forms.NumericUpDown nmVerWeld;
        private System.Windows.Forms.NumericUpDown nmVerAcc;
        private System.Windows.Forms.NumericUpDown nmVerVel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnVerStop;
        private System.Windows.Forms.Button btnVerRun;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox boxLub;
        private System.Windows.Forms.Button btnLubOn;
        private System.Windows.Forms.Label lblPreOn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAlarm;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.Button btnResetHistory;
        private System.Windows.Forms.Label lblZHistory;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.GroupBox boxOperations;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.NumericUpDown nmPinchForce;
        private System.Windows.Forms.Button btnAutoZero;
        private System.Windows.Forms.Button btnZzero;
        private System.Windows.Forms.Button btnAbort;
        private System.Windows.Forms.GroupBox boxForce;
        private System.Windows.Forms.Label lblZForceStrain;
        private System.Windows.Forms.Label label108;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.Label lblTForce;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblYForce;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.Label lblXForce;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label lblZForce;
        private System.Windows.Forms.Label lblExternalVolt;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem weldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem linearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spotToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem safetyToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblXYHistory;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTHistory;
        private System.Windows.Forms.NumericUpDown nmVerRet;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ToolStripMenuItem trackingToolStripMenuItem;
    }
}

