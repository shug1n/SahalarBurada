using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    partial class FormOrganizatorPanel
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            UIHelper.FormAyarla(this, "Organizatör Paneli", 960, 690);

            // Header (içerik OnShown'da güncellenir)
            pnlOrgPanelHeader = new Panel { Dock = DockStyle.Top, Height = 95, BackColor = UIHelper.CAna };

            // Araç çubuğu
            pnlToolbar = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.White };
            pnlToolbar.Paint += (s, e) => e.Graphics.DrawLine(new System.Drawing.Pen(UIHelper.CBolme), 0, 59, ((Panel)s).Width, 59);

            btnYeniSaha  = UIHelper.BtnPrimary("➕   Yeni Saha Ekle", 20, 10, 185, 40);  btnYeniSaha.Name  = "btnYeniSaha";
            btnYenile    = UIHelper.BtnSecondary("🔄  Yenile", 218, 10, 110, 40);         btnYenile.Name    = "btnYenile";
            btnCikisYap  = UIHelper.BtnDanger("Çıkış Yap", 830, 10, 110, 40);             btnCikisYap.Name  = "btnCikisYap";
            pnlToolbar.Controls.AddRange(new Control[] { btnYeniSaha, btnYenile, btnCikisYap });

            // İçerik alanı
            pnlOrgPanelContent = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan };

            lblSahaBaslik = new Label { Text = "Sahalarım", Font = UIHelper.FAltBaslik, ForeColor = UIHelper.CMetin, AutoSize = true, Location = new System.Drawing.Point(22, 18) };
            lblSahaCount  = new Label { Name = "lblSahaCount", Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new System.Drawing.Point(22, 46) };

            dgvSahalar = new DataGridView
            {
                Name = "dgvSahalar",
                Location = new System.Drawing.Point(22, 72),
                Size     = new System.Drawing.Size(916, 490),
                TabIndex = 0, Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom
            };
            UIHelper.DGVAyarla(dgvSahalar);
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Saha Adı",       Width = 240 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Adres",           Width = 230 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Kapasite",        Width = 100 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fiyat/Saat",      Width = 120 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Eklenme Tarihi",  Width = 140 });

            pnlOrgPanelContent.Controls.AddRange(new Control[] { lblSahaBaslik, lblSahaCount, dgvSahalar });

            this.Controls.Add(pnlOrgPanelContent);
            this.Controls.Add(pnlToolbar);
            this.Controls.Add(pnlOrgPanelHeader);
            this.ResumeLayout(false);
        }

        private Panel pnlOrgPanelHeader, pnlToolbar, pnlOrgPanelContent;
        private Button btnYeniSaha, btnYenile, btnCikisYap;
        private Label lblSahaBaslik, lblSahaCount;
        private DataGridView dgvSahalar;
    }
}
