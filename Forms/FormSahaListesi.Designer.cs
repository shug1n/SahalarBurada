using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    partial class FormSahaListesi
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            UIHelper.FormAyarla(this, "Uygun Sahalar", 880, 690);

            // Header (içeriği YukleKartlar içinde güncellenir)
            pnlSahaListesiHeader = new Panel { Dock = DockStyle.Top, Height = 95, BackColor = UIHelper.CAna };

            // Scroll alanı
            pnlScroll = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan, AutoScroll = true };
            flowSahalar = new FlowLayoutPanel
            {
                Name = "flowSahalar",
                AutoSize = true, FlowDirection = FlowDirection.TopDown,
                WrapContents = false, Padding = new System.Windows.Forms.Padding(20, 12, 20, 12),
                BackColor = System.Drawing.Color.Transparent
            };
            pnlScroll.Controls.Add(flowSahalar);

            // Alt bar
            pnlAltBar = new Panel { Dock = DockStyle.Bottom, Height = 52, BackColor = System.Drawing.Color.White };
            pnlAltBar.Paint += (s, e) => e.Graphics.DrawLine(new System.Drawing.Pen(UIHelper.CBolme), 0, 0, ((Panel)s).Width, 0);
            btnListGeri = UIHelper.BtnSecondary("← Geri", 20, 7, 130, 38);
            btnListGeri.Name = "btnListGeri";
            btnListGeri.Click += (s, e) => this.Close();
            pnlAltBar.Controls.Add(btnListGeri);

            this.Controls.Add(pnlScroll);
            this.Controls.Add(pnlAltBar);
            this.Controls.Add(pnlSahaListesiHeader);
            this.ResumeLayout(false);
        }

        private Panel pnlSahaListesiHeader, pnlScroll, pnlAltBar;
        private FlowLayoutPanel flowSahalar;
        private Button btnListGeri;
    }
}
