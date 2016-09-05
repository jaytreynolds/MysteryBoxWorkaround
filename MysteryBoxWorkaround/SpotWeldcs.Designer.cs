namespace MysteryBoxWorkaround
{
    partial class SpotWeldcs
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbRecFilename = new System.Windows.Forms.TextBox();
            this.tbRecGroup = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLwEndWeld = new System.Windows.Forms.Button();
            this.btnLwUpdate = new System.Windows.Forms.Button();
            this.btnLwLoad = new System.Windows.Forms.Button();
            this.btnLwAbort = new System.Windows.Forms.Button();
            this.btnLwStartWeld = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.nmTraEnd = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.nmTraIPM = new System.Windows.Forms.NumericUpDown();
            this.nmSpiRPM = new System.Windows.Forms.NumericUpDown();
            this.nmVerPlunge = new System.Windows.Forms.NumericUpDown();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTraEnd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTraIPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSpiRPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerPlunge)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbRecFilename);
            this.groupBox4.Controls.Add(this.tbRecGroup);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Location = new System.Drawing.Point(24, 202);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(215, 60);
            this.groupBox4.TabIndex = 156;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(24, 137);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 64);
            this.textBox1.TabIndex = 155;
            this.textBox1.Text = "C:\\Users\\J\\Documents\\MATLAB\\LinearWeld";
            // 
            // btnLwEndWeld
            // 
            this.btnLwEndWeld.Location = new System.Drawing.Point(164, 298);
            this.btnLwEndWeld.Name = "btnLwEndWeld";
            this.btnLwEndWeld.Size = new System.Drawing.Size(75, 23);
            this.btnLwEndWeld.TabIndex = 154;
            this.btnLwEndWeld.Text = "End Weld";
            this.btnLwEndWeld.UseVisualStyleBackColor = true;
            // 
            // btnLwUpdate
            // 
            this.btnLwUpdate.Location = new System.Drawing.Point(165, 137);
            this.btnLwUpdate.Name = "btnLwUpdate";
            this.btnLwUpdate.Size = new System.Drawing.Size(74, 36);
            this.btnLwUpdate.TabIndex = 153;
            this.btnLwUpdate.Text = "Update";
            this.btnLwUpdate.UseVisualStyleBackColor = true;
            // 
            // btnLwLoad
            // 
            this.btnLwLoad.Location = new System.Drawing.Point(167, 179);
            this.btnLwLoad.Name = "btnLwLoad";
            this.btnLwLoad.Size = new System.Drawing.Size(72, 22);
            this.btnLwLoad.TabIndex = 152;
            this.btnLwLoad.Text = "Load";
            this.btnLwLoad.UseVisualStyleBackColor = true;
            // 
            // btnLwAbort
            // 
            this.btnLwAbort.BackColor = System.Drawing.Color.Red;
            this.btnLwAbort.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLwAbort.ForeColor = System.Drawing.Color.White;
            this.btnLwAbort.Location = new System.Drawing.Point(24, 268);
            this.btnLwAbort.Name = "btnLwAbort";
            this.btnLwAbort.Size = new System.Drawing.Size(134, 53);
            this.btnLwAbort.TabIndex = 151;
            this.btnLwAbort.Text = "Abort";
            this.btnLwAbort.UseVisualStyleBackColor = false;
            // 
            // btnLwStartWeld
            // 
            this.btnLwStartWeld.Location = new System.Drawing.Point(164, 268);
            this.btnLwStartWeld.Name = "btnLwStartWeld";
            this.btnLwStartWeld.Size = new System.Drawing.Size(75, 23);
            this.btnLwStartWeld.TabIndex = 150;
            this.btnLwStartWeld.Text = "Start Weld";
            this.btnLwStartWeld.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 111);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 13);
            this.label5.TabIndex = 149;
            this.label5.Text = "End Location";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 148;
            this.label4.Text = "Start Location";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 147;
            this.label3.Text = "Plunge Depth(inch):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 146;
            this.label2.Text = "Dwell Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 145;
            this.label1.Text = "Top Spindle RPM:";
            // 
            // nmTraEnd
            // 
            this.nmTraEnd.Location = new System.Drawing.Point(119, 111);
            this.nmTraEnd.Name = "nmTraEnd";
            this.nmTraEnd.Size = new System.Drawing.Size(120, 20);
            this.nmTraEnd.TabIndex = 143;
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.Location = new System.Drawing.Point(119, 85);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown4.TabIndex = 142;
            // 
            // nmTraIPM
            // 
            this.nmTraIPM.Location = new System.Drawing.Point(119, 59);
            this.nmTraIPM.Name = "nmTraIPM";
            this.nmTraIPM.Size = new System.Drawing.Size(120, 20);
            this.nmTraIPM.TabIndex = 141;
            // 
            // nmSpiRPM
            // 
            this.nmSpiRPM.Location = new System.Drawing.Point(119, 33);
            this.nmSpiRPM.Maximum = new decimal(new int[] {
            6000,
            0,
            0,
            0});
            this.nmSpiRPM.Name = "nmSpiRPM";
            this.nmSpiRPM.Size = new System.Drawing.Size(120, 20);
            this.nmSpiRPM.TabIndex = 144;
            this.nmSpiRPM.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // nmVerPlunge
            // 
            this.nmVerPlunge.Location = new System.Drawing.Point(119, 7);
            this.nmVerPlunge.Name = "nmVerPlunge";
            this.nmVerPlunge.Size = new System.Drawing.Size(120, 20);
            this.nmVerPlunge.TabIndex = 140;
            // 
            // SpotWeldcs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 327);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLwEndWeld);
            this.Controls.Add(this.btnLwUpdate);
            this.Controls.Add(this.btnLwLoad);
            this.Controls.Add(this.btnLwAbort);
            this.Controls.Add(this.btnLwStartWeld);
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
            this.Name = "SpotWeldcs";
            this.Text = "SpotWeldcs";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmTraEnd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmTraIPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmSpiRPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmVerPlunge)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbRecFilename;
        private System.Windows.Forms.TextBox tbRecGroup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLwEndWeld;
        private System.Windows.Forms.Button btnLwUpdate;
        private System.Windows.Forms.Button btnLwLoad;
        private System.Windows.Forms.Button btnLwAbort;
        private System.Windows.Forms.Button btnLwStartWeld;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmTraEnd;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.NumericUpDown nmTraIPM;
        private System.Windows.Forms.NumericUpDown nmSpiRPM;
        private System.Windows.Forms.NumericUpDown nmVerPlunge;
    }
}