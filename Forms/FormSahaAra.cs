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
            SetupLogic();
        }

        private void SetupLogic()
        {
            this.Shown += (s, e) => lblKullanici.Text = Oturum.GirisYapildi
                ? $"👤 Hoş geldiniz, {Oturum.AktifKullanici.Ad} {Oturum.AktifKullanici.Soyad}"
                : "👤 Misafir olarak arama yapıyorsunuz";

            dtpTarih.MinDate = DateTime.Today;

            for (int i = 8; i <= 22; i++) cmbSaat.Items.Add(i.ToString("D2") + ":00");
            cmbSaat.SelectedIndex = 6;

            btnGeri.Click += (s, e) => this.Close();
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            lblHata.Visible = false;
            var tarih = dtpTarih.Value.Date;
            var saat  = cmbSaat.SelectedItem?.ToString();
            if (saat == null) { lblHata.Text = "Lütfen saat seçin."; lblHata.Visible = true; return; }

            var sahalar = SahaServisi.UygunSahalariGetir(tarih, saat);
            if (sahalar.Count == 0)
            { lblHata.Text = "Seçilen tarih ve saatte müsait saha bulunmamaktadır."; lblHata.Visible = true; return; }

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
