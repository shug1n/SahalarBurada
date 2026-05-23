using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;

namespace SahalarBurada.Forms
{
    public partial class FormSahaEkle : BaseChildForm
    {

        public FormSahaEkle()
        {
            InitializeComponent();
            SetupLogic();
        }

        private void SetupLogic()
        {
            foreach (var g in new[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" })
                clbGunler.Items.Add(g, true);

            for (int i = 8; i <= 22; i++)
                clbSaatler.Items.Add(i.ToString("D2") + ":00", true);

            // İl listesini yükle
            cmbSehir.Items.Clear();
            foreach (var il in TurkiyeVerisi.Iller())
                cmbSehir.Items.Add(il);

            // İl değişince ilçeleri güncelle
            cmbSehir.SelectedIndexChanged += (s, e) =>
            {
                cmbIlce.Items.Clear();
                if (cmbSehir.SelectedItem != null)
                    foreach (var ilce in TurkiyeVerisi.Ilceler(cmbSehir.SelectedItem.ToString()))
                        cmbIlce.Items.Add(ilce);
                if (cmbIlce.Items.Count > 0) cmbIlce.SelectedIndex = 0;
            };
        }

        private void BtnGeri_Click(object sender, EventArgs e) { IsBackButtonClicked = true; this.Close(); }

        private void BtnOzet_Click(object sender, EventArgs e)
        {
            lblHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtAd.Text) || string.IsNullOrWhiteSpace(txtAdres.Text))
            { lblHata.Text = "Saha adı ve adres zorunludur."; lblHata.Visible = true; return; }

            if (cmbSehir.SelectedItem == null || cmbIlce.SelectedItem == null)
            { lblHata.Text = "Şehir ve ilçe seçimi zorunludur."; lblHata.Visible = true; return; }

            var gunler  = new List<string>();
            var saatler = new List<string>();
            foreach (var item in clbGunler.CheckedItems)  gunler.Add(item.ToString());
            foreach (var item in clbSaatler.CheckedItems) saatler.Add(item.ToString());
            if (gunler.Count == 0 || saatler.Count == 0)
            { lblHata.Text = "En az bir gün ve bir saat seçmelisiniz."; lblHata.Visible = true; return; }

            var saha = new HaliSaha
            {
                OrganizatorId = Oturum.AktifOrganizator.Id,
                Ad            = txtAd.Text.Trim(),
                Sehir         = cmbSehir.SelectedItem?.ToString(),
                Ilce          = cmbIlce.SelectedItem?.ToString(),
                Adres         = txtAdres.Text.Trim(),
                FiyatSaat     = (double)nudFiyat.Value,
                MüsaitGunler  = gunler,
                MüsaitSaatler = saatler,
                Aciklama      = txtAciklama.Text.Trim()
            };
            var f = new FormSahaOzet(saha);
            this.Hide();
            f.FormClosed += (s, ev) => { if (f.DialogResult == System.Windows.Forms.DialogResult.OK) this.Close(); else this.Show(); };
            f.Show();
        }
    }
}
