using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormSahaOzet : BaseChildForm
    {
        private readonly HaliSaha _saha;

        public FormSahaOzet(HaliSaha saha)
        {
            _saha = saha;
            InitializeComponent();
            this.ClientSize = new Size(1000, 700);

            SetupLogic();

            var allControls = new System.Collections.Generic.List<Control>();
            foreach (Control c in pnlScroll.Controls) allControls.Add(c);
            UIHelper.CenterControlsInCard(pnlScroll, allControls.ToArray(), false);
        }

        private void SetupLogic()
        {
            lblAdDeger.Text       = _saha.Ad;
            lblAdresDeger.Text    = _saha.Adres;
            lblSehirDeger.Text    = _saha.Sehir ?? "—";
            lblIlceDeger.Text     = _saha.Ilce  ?? "—";
            lblFiyatDeger.Text    = _saha.FiyatSaat.ToString("N0") + " ₺ / saat";
            lblTelefonDeger.Text  = string.IsNullOrWhiteSpace(_saha.Telefon) ? "—" : _saha.Telefon;
            lblGunlerDeger.Text   = string.Join(", ", _saha.MüsaitGunler);

            lblSaatlerDeger.AutoSize = true;
            lblSaatlerDeger.MaximumSize = new Size(430, 0);
            lblSaatlerDeger.Text  = string.Join(", ", _saha.MüsaitSaatler);

            int hoursBottom = lblSaatlerDeger.Bottom;
            int newY = hoursBottom + 12;

            lblAciklamaLabel.Top = newY;
            lblAciklamaDeger.Top = newY;
            lblAciklamaDeger.Text = string.IsNullOrWhiteSpace(_saha.Aciklama) ? "—" : _saha.Aciklama;

            int currentY = lblAciklamaDeger.Bottom + 12;

            // Kamera
            var lblKameraLabel = new Label
            {
                Text = "Saha İçi Kamera:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(20, currentY),
                Size = new Size(145, 26)
            };
            var lblKameraVal = new Label
            {
                Text = _saha.Kamera == true ? "Var" : (_saha.Kamera == false ? "Yok" : "Belirtilmemiş"),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(170, currentY),
                Size = new Size(430, 26)
            };
            pnlKart.Controls.Add(lblKameraLabel);
            pnlKart.Controls.Add(lblKameraVal);
            currentY += 32;

            // Üstü Durumu
            var lblUstLabel = new Label
            {
                Text = "Saha Üstü Durumu:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(20, currentY),
                Size = new Size(145, 26)
            };
            var lblUstVal = new Label
            {
                Text = _saha.UstKapali == true ? "Üstü Kapalı" : (_saha.UstKapali == false ? "Üstü Açık" : "Belirtilmemiş"),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(170, currentY),
                Size = new Size(430, 26)
            };
            pnlKart.Controls.Add(lblUstLabel);
            pnlKart.Controls.Add(lblUstVal);
            currentY += 32;

            // Krampon
            var lblKramponLabel = new Label
            {
                Text = "Krampon Kiralama:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(20, currentY),
                Size = new Size(145, 26)
            };
            var lblKramponVal = new Label
            {
                Text = _saha.KramponKiralama == true ? "Krampon Kiralanıyor" : (_saha.KramponKiralama == false ? "Krampon Kiralanmıyor" : "Belirtilmemiş"),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(170, currentY),
                Size = new Size(430, 26)
            };
            pnlKart.Controls.Add(lblKramponLabel);
            pnlKart.Controls.Add(lblKramponVal);
            currentY += 32;

            // Büyüklük (m²)
            var lblBoyutLabel = new Label
            {
                Text = "Saha Büyüklüğü:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 30),
                Location = new Point(20, currentY),
                Size = new Size(145, 26)
            };
            var lblBoyutVal = new Label
            {
                Text = _saha.Metrekare.HasValue ? $"{_saha.Metrekare.Value} m²" : "Belirtilmemiş",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(170, currentY),
                Size = new Size(430, 26)
            };
            pnlKart.Controls.Add(lblBoyutLabel);
            pnlKart.Controls.Add(lblBoyutVal);
            currentY += 32;

            int cardHeightNeeded = currentY + 18;
            pnlKart.Height = Math.Max(pnlKart.Height, cardHeightNeeded);

            // Dynamically position info label and action buttons below the updated pnlKart
            lblBilgi.Top = pnlKart.Bottom + 12;
            btnDuzenle.Top = lblBilgi.Bottom + 12;
            btnKaydet.Top = lblBilgi.Bottom + 12;
        }

        private void pnlKart_Paint(object sender, PaintEventArgs e)
        {
            var p = (Panel)sender;
            e.Graphics.DrawRectangle(new Pen(UIHelper.CBolme, 1), 0, 0, p.Width - 1, p.Height - 1);
            e.Graphics.FillRectangle(new SolidBrush(UIHelper.CVurgu), 0, 0, 6, p.Height);
        }

        private void BtnDuzenle_Click(object sender, EventArgs e) { IsBackButtonClicked = true; this.Close(); }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            bool isNew = string.IsNullOrEmpty(_saha.Id);
            SahaServisi.SahaEkle(_saha);
            string title = isNew ? "Saha Eklendi ✅" : "Saha Güncellendi ✅";
            string msg = isNew 
                ? $"'{_saha.Ad}' sahası başarıyla sisteme eklendi!\n\nMüsait günler: {_saha.MüsaitGunler.Count} gün\nMüsait saatler: {_saha.MüsaitSaatler.Count} dilim"
                : $"'{_saha.Ad}' sahası başarıyla güncellendi!\n\nMüsait günler: {_saha.MüsaitGunler.Count} gün\nMüsait saatler: {_saha.MüsaitSaatler.Count} dilim";
            MessageBox.Show(msg, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.IsBackButtonClicked = true;
            this.Close();
        }
    }
}
