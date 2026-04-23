using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    partial class FormAnaEkran
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            // ── Form ────────────────────────────────────────────────────────
            this.SuspendLayout();
            UIHelper.FormAyarla(this, "Ana Sayfa", 1020, 690);
            this.Text = "SahalarBurada — Halı Saha Kiralama Platformu";

            // ── Header ──────────────────────────────────────────────────────
            pnlHeader = new Panel { Dock = DockStyle.Top, Height = 155, BackColor = UIHelper.CAna };
            pnlHeader.Paint += PnlHeader_Paint;

            lblLogo = new Label
            {
                Text = "⚽ SahalarBurada",
                Font = new Font("Segoe UI", 32, FontStyle.Bold),
                ForeColor = System.Drawing.Color.White, AutoSize = true,
                Location = new System.Drawing.Point(50, 28), BackColor = System.Drawing.Color.Transparent
            };
            lblSlogan = new Label
            {
                Text = "Türkiye'nin Hızlı Halı Saha Kiralama Platformu",
                Font = new Font("Segoe UI", 11.5f),
                ForeColor = System.Drawing.Color.FromArgb(200, 255, 255, 255),
                AutoSize = true, Location = new System.Drawing.Point(53, 90),
                BackColor = System.Drawing.Color.Transparent
            };
            pnlHeader.Controls.Add(lblLogo);
            pnlHeader.Controls.Add(lblSlogan);

            // ── İçerik tablo ────────────────────────────────────────────────
            tblCards = new TableLayoutPanel
            {
                Dock = DockStyle.Fill, ColumnCount = 2, RowCount = 1,
                BackColor = UIHelper.CArkaplan, Padding = new System.Windows.Forms.Padding(40, 30, 40, 30)
            };
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));
            tblCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50));

            // ── Kiracı kartı ─────────────────────────────────────────────────
            pnlKiraci = new Panel { Dock = DockStyle.Fill, BackColor = System.Drawing.Color.White, Margin = new System.Windows.Forms.Padding(0, 0, 14, 0) };
            pnlKiraci.Paint += PnlKart_Paint;

            lblKiraciIkon  = new Label { Text = "🧑‍🤝‍🧑", Font = new Font("Segoe UI Emoji", 36), AutoSize = true, Location = new System.Drawing.Point(35, 30), BackColor = System.Drawing.Color.Transparent };
            lblKiraciBaslik = new Label { Text = "Halı Saha Kirala", Font = UIHelper.FBaslik, ForeColor = UIHelper.CAna, AutoSize = true, Location = new System.Drawing.Point(35, 108) };
            lblKiraciAciklama = new Label
            {
                Text = "Müsait sahaları kolayca bul ve hemen rezervasyon yap.\nGiriş yapmadan da saha arayabilirsin!",
                Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik,
                AutoSize = true, MaximumSize = new System.Drawing.Size(340, 0), Location = new System.Drawing.Point(35, 148)
            };
            pnlKiraciSep = new Panel { Location = new System.Drawing.Point(35, 215), Size = new System.Drawing.Size(340, 1), BackColor = UIHelper.CBolme };

            btnMacAra = UIHelper.BtnPrimary("⚽   Maç Ara / Kirala  (Giriş Gerektirmez)", 35, 232, 350, 50);
            btnMacAra.Name = "btnMacAra";
            btnKiraciGiris = UIHelper.BtnSecondary("👤   Giriş Yap / Kayıt Ol", 35, 298, 350, 44);
            btnKiraciGiris.Name = "btnKiraciGiris";

            pnlKiraci.Controls.Add(lblKiraciIkon);
            pnlKiraci.Controls.Add(lblKiraciBaslik);
            pnlKiraci.Controls.Add(lblKiraciAciklama);
            pnlKiraci.Controls.Add(pnlKiraciSep);
            pnlKiraci.Controls.Add(btnMacAra);
            pnlKiraci.Controls.Add(btnKiraciGiris);

            // ── Organizatör kartı ────────────────────────────────────────────
            pnlOrg = new Panel { Dock = DockStyle.Fill, BackColor = System.Drawing.Color.White, Margin = new System.Windows.Forms.Padding(14, 0, 0, 0) };
            pnlOrg.Paint += PnlKart_Paint;

            lblOrgIkon    = new Label { Text = "🏢", Font = new Font("Segoe UI Emoji", 36), AutoSize = true, Location = new System.Drawing.Point(35, 30), BackColor = System.Drawing.Color.Transparent };
            lblOrgBaslik  = new Label { Text = "Organizatör Girişi", Font = UIHelper.FBaslik, ForeColor = UIHelper.CAna, AutoSize = true, Location = new System.Drawing.Point(35, 108) };
            lblOrgAciklama = new Label
            {
                Text = "İşletmenizi sisteme kaydedin, halı sahalarınızı\nyönetin ve rezervasyonları takip edin.",
                Font = UIHelper.FNormal, ForeColor = UIHelper.CMetinAcik,
                AutoSize = true, MaximumSize = new System.Drawing.Size(340, 0), Location = new System.Drawing.Point(35, 148)
            };
            pnlOrgSep = new Panel { Location = new System.Drawing.Point(35, 215), Size = new System.Drawing.Size(340, 1), BackColor = UIHelper.CBolme };

            btnOrgGiris = UIHelper.BtnPrimary("🏢   Giriş Yap / Kayıt Ol", 35, 232, 350, 50);
            btnOrgGiris.Name = "btnOrgGiris";
            lblOrgNot   = new Label { Text = "ℹ  İşletme girişi zorunludur", Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CUyari, AutoSize = true, Location = new System.Drawing.Point(35, 300) };
            lblOrgDemo  = new Label { Text = "Demo: demo@org.com  /  123456", Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new System.Drawing.Point(35, 322) };

            pnlOrg.Controls.Add(lblOrgIkon);
            pnlOrg.Controls.Add(lblOrgBaslik);
            pnlOrg.Controls.Add(lblOrgAciklama);
            pnlOrg.Controls.Add(pnlOrgSep);
            pnlOrg.Controls.Add(btnOrgGiris);
            pnlOrg.Controls.Add(lblOrgNot);
            pnlOrg.Controls.Add(lblOrgDemo);

            tblCards.Controls.Add(pnlKiraci, 0, 0);
            tblCards.Controls.Add(pnlOrg,    1, 0);

            // ── Form kontrollerini ekle ──────────────────────────────────────
            this.Controls.Add(tblCards);
            this.Controls.Add(pnlHeader);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ── Tasarım değişkenleri ─────────────────────────────────────────────
        private Panel pnlHeader;
        private Label lblLogo, lblSlogan;
        private TableLayoutPanel tblCards;
        private Panel pnlKiraci, pnlOrg;
        private Panel pnlKiraciSep, pnlOrgSep;
        private Label lblKiraciIkon, lblKiraciBaslik, lblKiraciAciklama;
        private Label lblOrgIkon,    lblOrgBaslik,    lblOrgAciklama, lblOrgNot, lblOrgDemo;
        private Button btnMacAra, btnKiraciGiris, btnOrgGiris;
    }
}
