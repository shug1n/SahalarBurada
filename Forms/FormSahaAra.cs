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
            this.ClientSize = new Size(1000, 700);
            pnlContent.Dock = DockStyle.None;
            
            // Extract btnGeri to put it outside the card
            pnlContent.Controls.Remove(btnGeri);
            this.Controls.Add(btnGeri);
            this.Resize += (s, e) => btnGeri.Location = new Point(30, this.ClientSize.Height - 60);
            btnGeri.Location = new Point(30, this.ClientSize.Height - 60);
            
            UIHelper.CenterControlsInCard(this, new Control[] { pnlContent });
            
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

            var tumSaatler = new System.Collections.Generic.List<(int baslangicSaat, string text)>
            {
                (15, "15:00-16:00"),
                (16, "16:00-17:00"),
                (17, "17:00-18:00"),
                (18, "18:00-19:00"),
                (19, "19:00-20:00"),
                (20, "20:00-21:00"),
                (21, "21:00-22:00"),
                (22, "22:00-23:00"),
                (23, "23:00-00:00"),
                (0, "00:00-01:00")
            };

            bool bugun = dtpTarih.Value.Date == DateTime.Today;
            int guncelSaat = DateTime.Now.Hour;

            foreach (var item in tumSaatler)
            {
                if (bugun)
                {
                    int slotBaslangic = item.baslangicSaat == 0 ? 24 : item.baslangicSaat;
                    if (guncelSaat >= slotBaslangic)
                        continue;
                }
                cmbSaat.Items.Add(item.text);
            }

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
