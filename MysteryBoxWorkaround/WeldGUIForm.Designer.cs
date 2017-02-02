namespace MysteryBoxWorkaround
{
    partial class WeldGUIForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbRecFilename = new System.Windows.Forms.TextBox();
            this.tbRecGroup = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLwUpdate = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnLwLoad = new System.Windows.Forms.Button();
            this.btnLwAbort = new System.Windows.Forms.Button();
            this.btnLwStartWeld = new System.Windows.Forms.Button();
            this.cbTool = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnLwEndWeld = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.btnLwEndWeld);
            this.groupBox1.Controls.Add(this.btnLwUpdate);
            this.groupBox1.Controls.Add(this.btnBuild);
            this.groupBox1.Controls.Add(this.btnLwLoad);
            this.groupBox1.Controls.Add(this.btnLwAbort);
            this.groupBox1.Controls.Add(this.btnLwStartWeld);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 208);
            this.groupBox1.TabIndex = 143;
            this.groupBox1.TabStop = false;
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(135, 17);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "GrooveTracking";
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
            // cbTool
            // 
            this.cbTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbTool.FormattingEnabled = true;
            this.cbTool.Location = new System.Drawing.Point(116, 4);
            this.cbTool.Name = "cbTool";
            this.cbTool.Size = new System.Drawing.Size(121, 21);
            this.cbTool.TabIndex = 149;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(82, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 148;
            this.label8.Text = "Tool";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(8, 8);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1.TabIndex = 150;
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
            // WeldGUIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 240);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.cbTool);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Name = "WeldGUIForm";
            this.Text = "WeldGUIForm";
            this.Load += new System.EventHandler(this.WeldGUIForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbRecFilename;
        private System.Windows.Forms.TextBox tbRecGroup;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLwUpdate;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.Button btnLwLoad;
        private System.Windows.Forms.Button btnLwAbort;
        private System.Windows.Forms.Button btnLwStartWeld;
        private System.Windows.Forms.ComboBox cbTool;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnLwEndWeld;
    }
}