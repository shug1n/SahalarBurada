using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormSahaAra : BaseChildForm
    {

        public FormSahaAra()
        {
            InitializeComponent();
            SetupLogic();
        }

        private void SetupLogic()
        {
            this.Shown += (s, e) =>
                lblKullanici.Text = Oturum.GirisYapildi
                    ? $"👤 Hoş geldiniz, {Oturum.AktifKullanici.Ad} {Oturum.AktifKullanici.Soyad}"
                    : "👤 Misafir olarak arama yapıyorsunuz";

            dtpTarih.MinDate = DateTime.Today;

            dtpTarih.ValueChanged += (s, e) => SaatleriGuncelle();
            SaatleriGuncelle();

            // İl listesi (“Tümüllü” + alfabetik)
            cmbSehir.Items.Add("— Tüm Şehirler —");
            foreach (var il in TurkiyeVerisi.Iller())
                cmbSehir.Items.Add(il);
            cmbSehir.SelectedIndex = 0;

            // İl değişince ilçe listesini güncelle
            cmbSehir.SelectedIndexChanged += (s, e) =>
            {
                cmbIlce.Items.Clear();
                cmbIlce.Items.Add("— Tüm İlçeler —");
                if (cmbSehir.SelectedIndex > 0)
                    foreach (var ilce in TurkiyeVerisi.Ilceler(cmbSehir.SelectedItem.ToString()))
                        cmbIlce.Items.Add(ilce);
                cmbIlce.SelectedIndex = 0;
            };

            // İlk yüklemede ilçe listesi
            cmbIlce.Items.Add("— Tüm İlçeler —");
            cmbIlce.SelectedIndex = 0;

            btnGeri.Click += (s, e) => { IsBackButtonClicked = true; this.Close(); };
        }

        private void SaatleriGuncelle()
        {
            var secili = cmbSaat.SelectedItem?.ToString();
            cmbSaat.Items.Clear();
            int baslangic = 8;
            
            if (dtpTarih.Value.Date == DateTime.Today)
            {
                int guncelSaat = DateTime.Now.Hour;
                if (guncelSaat + 1 > baslangic) 
                    baslangic = guncelSaat + 1;
            }

            for (int i = baslangic; i <= 22; i++)
                cmbSaat.Items.Add(i.ToString("D2") + ":00");

            if (cmbSaat.Items.Count > 0)
            {
                if (secili != null && cmbSaat.Items.Contains(secili))
                    cmbSaat.SelectedItem = secili;
                else
                    cmbSaat.SelectedIndex = 0;
            }
            else
            {
                cmbSaat.Items.Add("Bugün için saat kalmadı");
                cmbSaat.SelectedIndex = 0;
            }
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            lblHata.Visible = false;
            var tarih = dtpTarih.Value.Date;
            var saat  = cmbSaat.SelectedItem?.ToString();
            if (saat == null) { lblHata.Text = "Lütfen saat seçin."; lblHata.Visible = true; return; }

            var sehir = cmbSehir.SelectedIndex > 0 ? cmbSehir.SelectedItem?.ToString() : null;
            var ilce  = cmbIlce.SelectedIndex  > 0 ? cmbIlce.SelectedItem?.ToString()  : null;

            var sahalar = SahaServisi.UygunSahalariGetir(tarih, saat, sehir, ilce);
            if (sahalar.Count == 0)
            { lblHata.Text = "Seçilen kriterlere uygun müsait saha bulunmamaktadır."; lblHata.Visible = true; return; }

            var f = new FormSahaListesi(sahalar, tarih, saat);
            this.Hide();
            f.FormClosed += (s2, e2) =>
            {
                if (f.DialogResult == System.Windows.Forms.DialogResult.OK)
                { this.DialogResult = System.Windows.Forms.DialogResult.OK; this.IsBackButtonClicked = true; this.Close(); }
                else this.Show();
            };
            f.Show();
        }
    }
}
