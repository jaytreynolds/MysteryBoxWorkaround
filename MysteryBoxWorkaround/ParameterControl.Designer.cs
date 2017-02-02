namespace MysteryBoxWorkaround
{
    partial class ParameterControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.NM = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NM)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(4, 4);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(35, 13);
            this.label.TabIndex = 0;
            this.label.Text = "label1";
            // 
            // NM
            // 
            this.NM.Cursor = System.Windows.Forms.Cursors.Default;
            this.NM.DecimalPlaces = 10;
            this.NM.Location = new System.Drawing.Point(123, 2);
            this.NM.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.NM.Minimum = new decimal(new int[] {
            99999999,
            0,
            0,
            -2147483648});
            this.NM.Name = "NM";
            this.NM.Size = new System.Drawing.Size(93, 20);
            this.NM.TabIndex = 1;
            // 
            // ParameterControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NM);
            this.Controls.Add(this.label);
            this.Name = "ParameterControl";
            this.Size = new System.Drawing.Size(218, 25);
            this.Load += new System.EventHandler(this.ParameterControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label;
        public System.Windows.Forms.NumericUpDown NM;
        public string MatlabParam;
    }
}
