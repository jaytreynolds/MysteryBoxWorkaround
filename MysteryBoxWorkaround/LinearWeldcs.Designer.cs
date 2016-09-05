namespace MysteryBoxWorkaround
{
    partial class LinearWeldcs
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.nmVerPlunge = new System.Windows.Forms.NumericUpDown();
            this.nmSpiRPM = new System.Windows.Forms.NumericUpDown();
            this.nmTraIPM = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.nmTraEnd = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLwStartWeld = new System.Windows.Forms.Button();
            this.btnLwEndWeld = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLwLoad = new System.Windows.Forms.Button();
            this.btnLwAbort = new System.Windows.Forms.Button();
            this.btnLwUpdate = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbRecFilename = new System.Windows.Forms.TextBox();
            this.tbRecGroup = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.rbSpiCW = new System.Windows.Forms.RadioButton();
            this.rbSpiCCW = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuild = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.nmPlungeSpeed = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nmTiltAngle = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.cbTool = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerPlunge)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSpiRPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTraIPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTraEnd)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPlungeSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTiltAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // nmVerPlunge
            // 
            this.nmVerPlunge.DecimalPlaces = 4;
            this.nmVerPlunge.Location = new System.Drawing.Point(107, 12);
            this.nmVerPlunge.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nmVerPlunge.Name = "nmVerPlunge";
            this.nmVerPlunge.Size = new System.Drawing.Size(133, 20);
            this.nmVerPlunge.TabIndex = 0;
            // 
            // nmSpiRPM
            // 
            this.nmSpiRPM.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.nmSpiRPM.Location = new System.Drawing.Point(107, 38);
            this.nmSpiRPM.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.nmSpiRPM.Name = "nmSpiRPM";
            this.nmSpiRPM.Size = new System.Drawing.Size(133, 20);
            this.nmSpiRPM.TabIndex = 0;
            this.nmSpiRPM.ThousandsSeparator = true;
            this.nmSpiRPM.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // nmTraIPM
            // 
            this.nmTraIPM.DecimalPlaces = 2;
            this.nmTraIPM.Location = new System.Drawing.Point(107, 86);
            this.nmTraIPM.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.nmTraIPM.Name = "nmTraIPM";
            this.nmTraIPM.Size = new System.Drawing.Size(133, 20);
            this.nmTraIPM.TabIndex = 0;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 2;
            this.numericUpDown4.Location = new System.Drawing.Point(107, 112);
            this.numericUpDown4.Maximum = new decimal(new int[] {
            275,
            0,
            0,
            65536});
            this.numericUpDown4.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(133, 20);
            this.numericUpDown4.TabIndex = 0;
            this.numericUpDown4.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // nmTraEnd
            // 
            this.nmTraEnd.DecimalPlaces = 2;
            this.nmTraEnd.Location = new System.Drawing.Point(107, 138);
            this.nmTraEnd.Maximum = new decimal(new int[] {
            275,
            0,
            0,
            65536});
            this.nmTraEnd.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.nmTraEnd.Name = "nmTraEnd";
            this.nmTraEnd.Size = new System.Drawing.Size(133, 20);
            this.nmTraEnd.TabIndex = 0;
            this.nmTraEnd.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Spindle RPM:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Traverse IPM:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Plunge Depth(inch):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Start Location";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "End Location";
            // 
            // btnLwStartWeld
            // 
            this.btnLwStartWeld.Location = new System.Drawing.Point(144, 143);
            this.btnLwStartWeld.Name = "btnLwStartWeld";
            this.btnLwStartWeld.Size = new System.Drawing.Size(75, 23);
            this.btnLwStartWeld.TabIndex = 2;
            this.btnLwStartWeld.Text = "Start Weld";
            this.btnLwStartWeld.UseVisualStyleBackColor = true;
            this.btnLwStartWeld.Click += new System.EventHandler(this.btnStartWeld_Click);
            // 
            // btnLwEndWeld
            // 
            this.btnLwEndWeld.Location = new System.Drawing.Point(144, 173);
            this.btnLwEndWeld.Name = "btnLwEndWeld";
            this.btnLwEndWeld.Size = new System.Drawing.Size(75, 23);
            this.btnLwEndWeld.TabIndex = 2;
            this.btnLwEndWeld.Text = "End Weld";
            this.btnLwEndWeld.UseVisualStyleBackColor = true;
            this.btnLwEndWeld.Click += new System.EventHandler(this.btnEndWeld_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 17);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "LinearWeld";
            // 
            // btnLwLoad
            // 
            this.btnLwLoad.Location = new System.Drawing.Point(6, 42);
            this.btnLwLoad.Name = "btnLwLoad";
            this.btnLwLoad.Size = new System.Drawing.Size(61, 22);
            this.btnLwLoad.TabIndex = 2;
            this.btnLwLoad.Text = "Load";
            this.btnLwLoad.UseVisualStyleBackColor = true;
            this.btnLwLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnLwAbort
            // 
            this.btnLwAbort.BackColor = System.Drawing.Color.Red;
            this.btnLwAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLwAbort.ForeColor = System.Drawing.Color.White;
            this.btnLwAbort.Location = new System.Drawing.Point(4, 143);
            this.btnLwAbort.Name = "btnLwAbort";
            this.btnLwAbort.Size = new System.Drawing.Size(134, 53);
            this.btnLwAbort.TabIndex = 2;
            this.btnLwAbort.Text = "Abort";
            this.btnLwAbort.UseVisualStyleBackColor = false;
            this.btnLwAbort.Click += new System.EventHandler(this.btnAbort_Click);
            // 
            // btnLwUpdate
            // 
            this.btnLwUpdate.Location = new System.Drawing.Point(145, 12);
            this.btnLwUpdate.Name = "btnLwUpdate";
            this.btnLwUpdate.Size = new System.Drawing.Size(74, 52);
            this.btnLwUpdate.TabIndex = 2;
            this.btnLwUpdate.Text = "Update";
            this.btnLwUpdate.UseVisualStyleBackColor = true;
            this.btnLwUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbRecFilename);
            this.groupBox4.Controls.Add(this.tbRecGroup);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(4, 77);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(215, 60);
            this.groupBox4.TabIndex = 139;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Recording Info";
            // 
            // tbRecFilename
            // 
            this.tbRecFilename.Location = new System.Drawing.Point(70, 36);
            this.tbRecFilename.Name = "tbRecFilename";
            this.tbRecFilename.Size = new System.Drawing.Size(139, 20);
            this.tbRecFilename.TabIndex = 6;
            // 
            // tbRecGroup
            // 
            this.tbRecGroup.Location = new System.Drawing.Point(70, 12);
            this.tbRecGroup.Name = "tbRecGroup";
            this.tbRecGroup.Size = new System.Drawing.Size(139, 20);
            this.tbRecGroup.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(11, 39);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Filename:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Name:";
            // 
            // rbSpiCW
            // 
            this.rbSpiCW.AutoSize = true;
            this.rbSpiCW.Checked = true;
            this.rbSpiCW.Location = new System.Drawing.Point(157, 63);
            this.rbSpiCW.Name = "rbSpiCW";
            this.rbSpiCW.Size = new System.Drawing.Size(76, 17);
            this.rbSpiCW.TabIndex = 140;
            this.rbSpiCW.TabStop = true;
            this.rbSpiCW.Text = "ClockWise";
            this.rbSpiCW.UseVisualStyleBackColor = true;
            // 
            // rbSpiCCW
            // 
            this.rbSpiCCW.AutoSize = true;
            this.rbSpiCCW.Location = new System.Drawing.Point(27, 63);
            this.rbSpiCCW.Name = "rbSpiCCW";
            this.rbSpiCCW.Size = new System.Drawing.Size(116, 17);
            this.rbSpiCCW.TabIndex = 141;
            this.rbSpiCCW.Text = "Counter-ClockWise";
            this.rbSpiCCW.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnLwEndWeld);
            this.groupBox1.Controls.Add(this.btnLwUpdate);
            this.groupBox1.Controls.Add(this.btnBuild);
            this.groupBox1.Controls.Add(this.btnLwLoad);
            this.groupBox1.Controls.Add(this.btnLwAbort);
            this.groupBox1.Controls.Add(this.btnLwStartWeld);
            this.groupBox1.Location = new System.Drawing.Point(12, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 208);
            this.groupBox1.TabIndex = 142;
            this.groupBox1.TabStop = false;
            // 
            // btnBuild
            // 
            this.btnBuild.Location = new System.Drawing.Point(73, 42);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(68, 22);
            this.btnBuild.TabIndex = 2;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btnBuild_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 144;
            this.label6.Text = "Plunge Speed";
            // 
            // nmPlungeSpeed
            // 
            this.nmPlungeSpeed.DecimalPlaces = 2;
            this.nmPlungeSpeed.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nmPlungeSpeed.Location = new System.Drawing.Point(109, 164);
            this.nmPlungeSpeed.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            this.nmPlungeSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nmPlungeSpeed.Name = "nmPlungeSpeed";
            this.nmPlungeSpeed.Size = new System.Drawing.Size(133, 20);
            this.nmPlungeSpeed.TabIndex = 143;
            this.nmPlungeSpeed.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(52, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 146;
            this.label7.Text = "Tilt Angle";
            // 
            // nmTiltAngle
            // 
            this.nmTiltAngle.DecimalPlaces = 2;
            this.nmTiltAngle.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.nmTiltAngle.Location = new System.Drawing.Point(109, 190);
            this.nmTiltAngle.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nmTiltAngle.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            -2147483648});
            this.nmTiltAngle.Name = "nmTiltAngle";
            this.nmTiltAngle.Size = new System.Drawing.Size(133, 20);
            this.nmTiltAngle.TabIndex = 145;
            this.nmTiltAngle.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 220);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 146;
            this.label8.Text = "Tool";
            // 
            // cbTool
            // 
            this.cbTool.FormattingEnabled = true;
            this.cbTool.Location = new System.Drawing.Point(109, 217);
            this.cbTool.Name = "cbTool";
            this.cbTool.Size = new System.Drawing.Size(121, 21);
            this.cbTool.TabIndex = 147;
            // 
            // LinearWeldcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 443);
            this.Controls.Add(this.cbTool);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nmTiltAngle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.nmPlungeSpeed);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.rbSpiCCW);
            this.Controls.Add(this.rbSpiCW);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nmTraEnd);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.nmTraIPM);
            this.Controls.Add(this.nmSpiRPM);
            this.Controls.Add(this.nmVerPlunge);
            this.Name = "LinearWeldcs";
            this.Text = "LinearWeld";
            this.Load += new System.EventHandler(this.Weld_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmVerPlunge)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSpiRPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTraIPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTraEnd)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmPlungeSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTiltAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown nmVerPlunge;
        private System.Windows.Forms.NumericUpDown nmSpiRPM;
        private System.Windows.Forms.NumericUpDown nmTraIPM;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown nmTraEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLwStartWeld;
        private System.Windows.Forms.Button btnLwEndWeld;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLwLoad;
        private System.Windows.Forms.Button btnLwAbort;
        private System.Windows.Forms.Button btnLwUpdate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbRecFilename;
        private System.Windows.Forms.TextBox tbRecGroup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.RadioButton rbSpiCW;
        private System.Windows.Forms.RadioButton rbSpiCCW;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nmPlungeSpeed;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nmTiltAngle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbTool;
        private System.Windows.Forms.Button btnBuild;
    }
}