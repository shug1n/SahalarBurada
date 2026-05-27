using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormSahaEkle : BaseChildForm
    {

        public FormSahaEkle()
        {
            InitializeComponent();
            this.ClientSize = new Size(1000, 700);

            pnlScroll.Controls.Remove(btnGeri);
            pnlScroll.Controls.Remove(btnOzet);
            this.Controls.Add(btnGeri);
            this.Controls.Add(btnOzet);
            btnGeri.BringToFront();
            btnOzet.BringToFront();

            this.Resize += (s, e) => {
                btnGeri.Location = new Point(30, this.ClientSize.Height - 60);
                btnOzet.Location = new Point(190, this.ClientSize.Height - 60);
            };
            btnGeri.Location = new Point(30, this.ClientSize.Height - 60);
            btnOzet.Location = new Point(190, this.ClientSize.Height - 60);

            var allControls = new List<Control>();
            foreach (Control c in pnlScroll.Controls) allControls.Add(c);
            UIHelper.CenterControlsInCard(pnlScroll, allControls.ToArray());

            UIHelper.SetPlaceholder(txtFiyat, "3000");
            SetupLogic();
        }

        private void SetupLogic()
        {
            foreach (var g in new[] { "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar" })
                clbGunler.Items.Add(g, true);

            var saatlerListesi = new List<string>
            {
                "15:00-16:00", "16:00-17:00", "17:00-18:00", "18:00-19:00",
                "19:00-20:00", "20:00-21:00", "21:00-22:00", "22:00-23:00",
                "23:00-00:00", "00:00-01:00"
            };
            foreach (var s in saatlerListesi)
                clbSaatler.Items.Add(s, true);

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

            if (SahaServisi.SahaIsmiVarMi(Oturum.AktifOrganizator.Id, txtAd.Text.Trim()))
            { lblHata.Text = "Bu isimde bir sahanız zaten mevcut."; lblHata.Visible = true; return; }

            if (cmbSehir.SelectedItem == null || cmbIlce.SelectedItem == null)
            { lblHata.Text = "Şehir ve ilçe seçimi zorunludur."; lblHata.Visible = true; return; }

            var gunler  = new List<string>();
            var saatler = new List<string>();
            foreach (var item in clbGunler.CheckedItems)  gunler.Add(item.ToString());
            foreach (var item in clbSaatler.CheckedItems) saatler.Add(item.ToString());
            if (gunler.Count == 0 || saatler.Count == 0)
            { lblHata.Text = "En az bir gün ve bir saat seçmelisiniz."; lblHata.Visible = true; return; }

            double fiyat = 3000;
            if (!string.IsNullOrWhiteSpace(txtFiyat.Text))
            {
                if (!double.TryParse(txtFiyat.Text.Trim(), out fiyat) || fiyat <= 0)
                {
                    lblHata.Text = "Saatlik fiyat alanına geçerli bir pozitif sayı girmelisiniz.";
                    lblHata.Visible = true;
                    return;
                }
            }

            var saha = new HaliSaha
            {
                OrganizatorId = Oturum.AktifOrganizator.Id,
                Ad            = txtAd.Text.Trim(),
                Sehir         = cmbSehir.SelectedItem?.ToString(),
                Ilce          = cmbIlce.SelectedItem?.ToString(),
                Adres         = txtAdres.Text.Trim(),
                FiyatSaat     = fiyat,
                MüsaitGunler  = gunler,
                MüsaitSaatler = saatler,
                Aciklama      = txtAciklama.Text.Trim(),
                Telefon       = txtTelefon.Text.Trim()
            };
            var f = new FormSahaOzet(saha);
            this.Hide();
            f.FormClosed += (s, ev) => { if (f.DialogResult == System.Windows.Forms.DialogResult.OK) { this.IsBackButtonClicked = true; this.Close(); } else this.Show(); };
            f.Show();
        }
    }
}
