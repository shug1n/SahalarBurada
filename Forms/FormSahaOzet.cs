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
            DoldurOzet();
        }

        private void DoldurOzet()
        {
            lblOzetSahaAdi.Text   = _saha.Ad;
            lblOzetAdres.Text     = _saha.Adres;
            lblOzetKapasite.Text  = _saha.Kapasite + " kişi";
            lblOzetFiyat.Text     = _saha.FiyatSaat.ToString("N0") + " ₺";
            lblOzetGunler.Text    = string.Join(", ", _saha.MüsaitGunler);
            lblOzetSaatler.Text   = $"{_saha.MüsaitSaatler.Count} dilim  ({_saha.MüsaitSaatler[0]} → {_saha.MüsaitSaatler[_saha.MüsaitSaatler.Count - 1]})";
            lblOzetAciklama.Text  = string.IsNullOrWhiteSpace(_saha.Aciklama) ? "—" : _saha.Aciklama;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SahaServisi.SahaEkle(_saha);
            MessageBox.Show(
                $"'{_saha.Ad}' sahası başarıyla sisteme eklendi!\n\nMüsait günler: {_saha.MüsaitGunler.Count} gün\nMüsait saatler: {_saha.MüsaitSaatler.Count} dilim",
                "Saha Eklendi ✅", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
    }
}
