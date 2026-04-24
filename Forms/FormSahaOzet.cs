using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormSahaOzet : Form
    {
        private readonly HaliSaha _saha;

        public FormSahaOzet(HaliSaha saha)
        {
            _saha = saha;
            InitializeComponent();
            SetupLogic();
        }

        private void SetupLogic()
        {
            lblAdDeger.Text = _saha.Ad;
            lblAdresDeger.Text = _saha.Adres;
            lblKapasiteDeger.Text = _saha.Kapasite + " kişi";
            lblFiyatDeger.Text = _saha.FiyatSaat.ToString("N0") + " ₺";
            lblGunlerDeger.Text = string.Join(", ", _saha.MüsaitGunler);
            lblSaatlerDeger.Text = $"{_saha.MüsaitSaatler.Count} dilim  ({_saha.MüsaitSaatler[0]} → {_saha.MüsaitSaatler[_saha.MüsaitSaatler.Count - 1]})";
            lblAciklamaDeger.Text = string.IsNullOrWhiteSpace(_saha.Aciklama) ? "—" : _saha.Aciklama;
        }

        private void pnlKart_Paint(object sender, PaintEventArgs e)
        {
            var p = (Panel)sender;
            e.Graphics.DrawRectangle(new Pen(UIHelper.CBolme, 1), 0, 0, p.Width - 1, p.Height - 1);
            e.Graphics.FillRectangle(new SolidBrush(UIHelper.CVurgu), 0, 0, 6, p.Height);
        }

        private void BtnDuzenle_Click(object sender, EventArgs e) => this.Close();

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SahaServisi.SahaEkle(_saha);
            MessageBox.Show($"'{_saha.Ad}' sahası başarıyla sisteme eklendi!\n\nMüsait günler: {_saha.MüsaitGunler.Count} gün\nMüsait saatler: {_saha.MüsaitSaatler.Count} dilim", "Saha Eklendi ✅", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
