using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormSahaAra : Form
    {
        public FormSahaAra()
        {
            InitializeComponent();
            btnListele.Click += BtnListele_Click;
            btnSahaAraGeri.Click += (s, e) => this.Close();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            lblSahaAraHata.Visible = false;
            var tarih = dtpTarih.Value.Date;
            var saat  = cmbSaat.SelectedItem?.ToString();
            if (saat == null) { lblSahaAraHata.Text = "Lütfen saat seçin."; lblSahaAraHata.Visible = true; return; }

            var sahalar = SahaServisi.UygunSahalariGetir(tarih, saat);
            if (sahalar.Count == 0)
            { lblSahaAraHata.Text = "Seçilen tarih ve saatte müsait saha bulunmamaktadır."; lblSahaAraHata.Visible = true; return; }

            var f = new FormSahaListesi(sahalar, tarih, saat);
            this.Hide();
            f.FormClosed += (s2, e2) =>
            {
                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                { this.DialogResult = System.Windows.Forms.DialogResult.OK; this.Close(); }
                else this.Show();
            };
            f.Show();
        }
    }
}
