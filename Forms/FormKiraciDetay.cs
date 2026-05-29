using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormKiraciDetay : BaseChildForm
    {
        private readonly Rezervasyon _rezervasyon;
        private Label lblKisiSayisiLabel;
        private Label lblKisiSayisiValue;

        public FormKiraciDetay(Rezervasyon rezervasyon)
        {
            _rezervasyon = rezervasyon ?? throw new ArgumentNullException(nameof(rezervasyon));
            InitializeComponent();
            
            this.ClientSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Programmatically change pnlKart size to fit KisiSayisi
            pnlKart.Size = new Size(515, 350);

            // Programmatically add KisiSayisi label and value
            lblKisiSayisiLabel = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(95, 110, 95),
                Location = new Point(275, 295),
                Name = "lblKisiSayisiLabel",
                Size = new Size(81, 15),
                Text = "👥 Katılacak Kişi Sayısı"
            };

            lblKisiSayisiValue = new Label
            {
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(28, 36, 28),
                Location = new Point(275, 315),
                Name = "lblKisiSayisiValue",
                Size = new Size(87, 19),
                Text = "1 kişi"
            };

            pnlKart.Controls.Add(lblKisiSayisiLabel);
            pnlKart.Controls.Add(lblKisiSayisiValue);

            // Dynamically manage btnGeri location and layout
            this.Controls.Remove(btnGeri);
            this.Controls.Add(btnGeri);
            this.Resize += (s, e) => btnGeri.Location = new Point(30, this.ClientSize.Height - 60);
            btnGeri.Location = new Point(30, this.ClientSize.Height - 60);

            UIHelper.CenterControlsInCard(this, new Control[] { pnlKart }, false);

            SetupDynamics();
            
            this.Load += FormKiraciDetay_Load;
        }

        private void SetupDynamics()
        {
            pnlHeader.Paint += (s, e) =>
            {
                var g = e.Graphics;
                using (var br = new System.Drawing.Drawing2D.LinearGradientBrush(pnlHeader.ClientRectangle,
                    UIHelper.CHeaderGradStart, UIHelper.CHeaderGradEnd,
                    System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                    g.FillRectangle(br, pnlHeader.ClientRectangle);
                using (var pen = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
                    g.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            };

            pnlKart.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Draw card border
                using (var pen = new Pen(UIHelper.CBolme, 1))
                    g.DrawRectangle(pen, 1, 1, pnlKart.Width - 3, pnlKart.Height - 3);

                // Sol yeşil vurgu çizgisi
                using (var br = new SolidBrush(UIHelper.CVurgu))
                    g.FillRectangle(br, 0, 0, 4, pnlKart.Height);

                // Dikey orta ayraç çizgisi
                using (var pen = new Pen(UIHelper.CBolme, 1))
                    g.DrawLine(pen, 255, 20, 255, pnlKart.Height - 20);
            };
        }

        private void FormKiraciDetay_Load(object sender, EventArgs e)
        {
            // Set basic details
            lblSahaValue.Text = _rezervasyon.SahaAdi;
            lblTarihValue.Text = _rezervasyon.Tarih.ToString("dd MMMM yyyy dddd");
            lblSaatValue.Text = _rezervasyon.Saat;
            lblUcretValue.Text = _rezervasyon.ToplamFiyat.ToString("N0") + " ₺";
            lblKisiSayisiValue.Text = $"{_rezervasyon.KisiSayisi} Kişi";

            if (!string.IsNullOrEmpty(_rezervasyon.KullaniciId))
            {
                // Registered user logic
                var user = DatabaseServisi.GetUserById(_rezervasyon.KullaniciId);
                if (user != null)
                {
                    lblAdSoyadValue.Text = $"{user.Ad} {user.Soyad}";
                    lblContactLabel.Text = "E-posta Adresi";
                    lblContactValue.Text = user.Eposta;
                    
                    lblTypeLabel.Text = "Telefon Numarası";
                    string phone = !string.IsNullOrEmpty(_rezervasyon.MisafirTelefon) ? _rezervasyon.MisafirTelefon : (!string.IsNullOrEmpty(user.Telefon) ? user.Telefon : "Belirtilmemiş");
                    lblTypeValue.Text = phone;
                    lblTypeValue.ForeColor = UIHelper.CMetin;
                    
                    lblDateLabel.Text = "Üyelik Durumu";
                    lblDateLabel.Visible = true;
                    lblDateValue.Visible = true;
                    lblDateValue.Text = "Kayıtlı Üye (Kayıt: " + user.KayitTarihi.ToString("dd.MM.yyyy") + ")";
                }
                else
                {
                    SetGuestDetails();
                }
            }
            else
            {
                SetGuestDetails();
            }
        }

        private void SetGuestDetails()
        {
            lblAdSoyadValue.Text = !string.IsNullOrEmpty(_rezervasyon.MisafirAd) ? _rezervasyon.MisafirAd : "Bilinmeyen Misafir";
            lblContactLabel.Text = "Telefon Numarası";
            lblContactValue.Text = !string.IsNullOrEmpty(_rezervasyon.MisafirTelefon) ? _rezervasyon.MisafirTelefon : "Belirtilmemiş";
            
            lblTypeLabel.Text = "Üyelik Durumu";
            lblTypeValue.Text = "Misafir (Hızlı Kiralama)";
            lblTypeValue.ForeColor = UIHelper.CMetinAcik;

            lblDateLabel.Visible = false;
            lblDateValue.Visible = false;
        }

        private void BtnGeri_Click(object sender, EventArgs e)
        {
            this.IsBackButtonClicked = true;
            this.Close();
        }

        private void lblUcretLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
