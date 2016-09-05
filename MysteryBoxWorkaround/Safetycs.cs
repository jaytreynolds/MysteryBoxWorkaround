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
    public partial class Safetycs : Form
    {
        public Safetycs()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateLimitsSafe();
        }
        public void UpdateLimitsSafe()
        {
            Program.MainForm.VerMax = (double)nmVerMax.Value;
            Program.MainForm.VerMin = (double)nmVerMin.Value;
            Program.MainForm.TraMax = (double)nmTraMax.Value;
            Program.MainForm.TraMin = (double)nmTraMin.Value;
            Program.MainForm.LatMax = (double)nmLatMax.Value;
            Program.MainForm.LatMin = (double)nmLatMin.Value;
            Program.MainForm.MaxZForce = (double)nmMaxZNotWelding.Value;
            Program.MainForm.MaxTForce = (double)nmMaxTNotWelding.Value;
            Program.MainForm.MaxXYForce = (double)nmMaxXYNotWelding.Value;
        }
        public void UpdateLimitsWelding()
        {
            Program.MainForm.VerMax = (double)nmVerMax.Value;
            Program.MainForm.VerMin = (double)nmVerMin.Value;
            Program.MainForm.TraMax = (double)nmTraMax.Value;
            Program.MainForm.TraMin = (double)nmTraMin.Value;
            Program.MainForm.LatMax = (double)nmLatMax.Value;
            Program.MainForm.LatMin = (double)nmLatMin.Value;
            Program.MainForm.MaxZForce = (double)nmMaxZWelding.Value;
            Program.MainForm.MaxTForce = (double)nmMaxTWelding.Value;
            Program.MainForm.MaxXYForce = (double)nmMaxXYWelding.Value;

        }

        private void SafteyFromClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}
