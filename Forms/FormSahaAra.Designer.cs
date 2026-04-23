using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    partial class FormSahaAra
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && components != null) components.Dispose(); base.Dispose(disposing); }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            UIHelper.FormAyarla(this, "Saha Ara", 540, 470);

            pnlSahaAraHeader = UIHelper.HeaderPanelOlustur("📅  Saha Ara", "Tarih ve saat seçerek müsait sahaları listeleyin");

            pnlSahaAraContent = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan };

            // Kullanıcı bilgisi — çalışma zamanında güncellenir
            lblKullaniciBilgi = new Label
            {
                Name = "lblKullaniciBilgi",
                Text = "👤 Misafir olarak arama yapıyorsunuz",
                Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik,
                AutoSize = true, Location = new Point(50, 20)
            };

            lblTarihLbl = new Label { Text = "Tarih Seçin:", Location = new Point(50, 55), Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, AutoSize = true };
            dtpTarih = new DateTimePicker
            {
                Name = "dtpTarih", Location = new Point(50, 80), Width = 440,
                Font = UIHelper.FNormal, Format = DateTimePickerFormat.Long, MinDate = DateTime.Today
            };

            lblSaatLbl = new Label { Text = "Saat Seçin:", Location = new Point(50, 130), Font = UIHelper.FNormalKalin, ForeColor = UIHelper.CMetin, AutoSize = true };
            cmbSaat = new ComboBox
            {
                Name = "cmbSaat", Location = new Point(50, 155), Width = 440,
                Font = UIHelper.FNormal, DropDownStyle = ComboBoxStyle.DropDownList
            };
            for (int i = 8; i <= 22; i++) cmbSaat.Items.Add(i.ToString("D2") + ":00");
            cmbSaat.SelectedIndex = 6; // 14:00

            lblSahaAraHata = new Label { Name = "lblSahaAraHata", Location = new Point(50, 205), AutoSize = true, Font = UIHelper.FKucuk, ForeColor = UIHelper.CHata, Visible = false };

            btnListele = UIHelper.BtnPrimary("🔍   Sahaları Listele", 50, 230, 440, 52);
            btnListele.Name = "btnListele";
            btnListele.Font = new Font("Segoe UI", 12, System.Drawing.FontStyle.Bold);

            btnSahaAraGeri = UIHelper.BtnSecondary("← Geri", 50, 302, 130, 38);
            btnSahaAraGeri.Name = "btnSahaAraGeri";

            pnlSahaAraContent.Controls.AddRange(new Control[] { lblKullaniciBilgi, lblTarihLbl, dtpTarih, lblSaatLbl, cmbSaat, lblSahaAraHata, btnListele, btnSahaAraGeri });

            this.Controls.Add(pnlSahaAraContent);
            this.Controls.Add(pnlSahaAraHeader);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        protected override void OnShown(System.EventArgs e)
        {
            base.OnShown(e);
            // Kullanıcı bilgisini güncelle
            lblKullaniciBilgi.Text = Oturum.GirisYapildi
                ? $"👤 Hoş geldiniz, {Oturum.AktifKullanici.Ad} {Oturum.AktifKullanici.Soyad}"
                : "👤 Misafir olarak arama yapıyorsunuz";
        }

        private Panel pnlSahaAraHeader, pnlSahaAraContent;
        private Label lblKullaniciBilgi, lblTarihLbl, lblSaatLbl, lblSahaAraHata;
        private DateTimePicker dtpTarih;
        private ComboBox cmbSaat;
        private Button btnListele, btnSahaAraGeri;
    }
}
