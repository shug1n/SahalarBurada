using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;

namespace SahalarBurada.Forms
{
    public partial class FormSahaEkle : Form
    {
        public FormSahaEkle()
        {
            InitializeComponent();
            btnSahaEkleGeri.Click += (s, e) => this.Close();
            btnSahaOzetGoster.Click += BtnOzet_Click;
        }

        private void BtnOzet_Click(object sender, EventArgs e)
        {
            lblSahaEkleHata.Visible = false;
            if (string.IsNullOrWhiteSpace(txtSahaAd.Text) || string.IsNullOrWhiteSpace(txtSahaAdres.Text))
            { lblSahaEkleHata.Text = "Saha adı ve adres zorunludur."; lblSahaEkleHata.Visible = true; return; }

            var gunler  = new List<string>();
            var saatler = new List<string>();
            foreach (var item in clbGunler.CheckedItems)  gunler.Add(item.ToString());
            foreach (var item in clbSaatler.CheckedItems) saatler.Add(item.ToString());

            if (gunler.Count == 0 || saatler.Count == 0)
            { lblSahaEkleHata.Text = "En az bir gün ve bir saat seçmelisiniz."; lblSahaEkleHata.Visible = true; return; }

            var saha = new HaliSaha
            {
                OrganizatorId   = Oturum.AktifOrganizator.Id,
                Ad              = txtSahaAd.Text.Trim(),
                Adres           = txtSahaAdres.Text.Trim(),
                Kapasite        = (int)nudKapasite.Value,
                FiyatSaat       = (double)nudFiyat.Value,
                MüsaitGunler    = gunler,
                MüsaitSaatler   = saatler,
                Aciklama        = txtSahaAciklama.Text.Trim()
            };

            var f = new FormSahaOzet(saha);
            this.Hide();
            f.FormClosed += (s, ev) =>
            {
                if (f.DialogResult == System.Windows.Forms.DialogResult.OK) this.Close();
                else this.Show();
            };
            f.Show();
        }
    }
}
