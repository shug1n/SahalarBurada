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

            var allControls = new System.Collections.Generic.List<Control>();
            foreach (Control c in pnlScroll.Controls) allControls.Add(c);
            UIHelper.CenterControlsInCard(pnlScroll, allControls.ToArray(), false);

            SetupLogic();
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

            int cardHeightNeeded = lblAciklamaDeger.Bottom + 30;
            pnlKart.Height = Math.Max(pnlKart.Height, cardHeightNeeded);
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
