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

        public FormKiraciDetay(Rezervasyon rezervasyon)
        {
            _rezervasyon = rezervasyon ?? throw new ArgumentNullException(nameof(rezervasyon));
            InitializeComponent();
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
                    lblTypeValue.Text = !string.IsNullOrEmpty(user.Telefon) ? user.Telefon : "Belirtilmemiş";
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
