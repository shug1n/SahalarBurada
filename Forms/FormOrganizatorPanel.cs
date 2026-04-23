using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormOrganizatorPanel : Form
    {
        private DataGridView dgvSahalar;
        private Label lblSahaCount;

        public FormOrganizatorPanel()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            UIHelper.FormAyarla(this, "Organizatör Paneli", 960, 690);
            var org = Oturum.AktifOrganizator;
            this.Controls.Add(UIHelper.HeaderPanelOlustur($"🏢  {org.IsletmeAdi}", $"Hoş geldiniz, {org.Ad} {org.Soyad}  •  {org.Eposta}"));

            // Araç çubuğu
            var toolbar = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = Color.White };
            toolbar.Paint += (s, e) => e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 59, ((Panel)s).Width, 59);
            var btnYeni   = UIHelper.BtnPrimary("➕   Yeni Saha Ekle", 20, 10, 185, 40);
            btnYeni.Click += BtnYeniSaha_Click;
            var btnYenile = UIHelper.BtnSecondary("🔄  Yenile", 218, 10, 110, 40);
            btnYenile.Click += (s, e) => SahalariYukle();
            var btnCikis  = UIHelper.BtnDanger("Çıkış Yap", 840, 10, 110, 40);
            btnCikis.Click += (s, e) => { Oturum.CikisYap(); this.Close(); };
            toolbar.Controls.AddRange(new Control[] { btnYeni, btnYenile, btnCikis });

            // İçerik alanı
            var content = new Panel { Dock = DockStyle.Fill, BackColor = UIHelper.CArkaplan };
            content.Controls.Add(new Label { Text = "Sahalarım", Font = UIHelper.FAltBaslik, ForeColor = UIHelper.CMetin, AutoSize = true, Location = new Point(22, 18) });
            lblSahaCount = new Label { Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik, AutoSize = true, Location = new Point(22, 46) };
            content.Controls.Add(lblSahaCount);

            dgvSahalar = new DataGridView { Location = new Point(22, 72), Size = new Size(912, 470), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom };
            UIHelper.DGVAyarla(dgvSahalar);
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Saha Adı",      Width = 240 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Adres",          Width = 230 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Kapasite",       Width = 100 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fiyat/Saat",     Width = 120 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Eklenme Tarihi", Width = 140 });
            content.Controls.Add(dgvSahalar);

            this.Controls.Add(content);
            this.Controls.Add(toolbar);

            SahalariYukle();
        }

        private void SahalariYukle()
        {
            var sahalar = SahaServisi.OrganizatorSahalari(Oturum.AktifOrganizator.Id);
            dgvSahalar.Rows.Clear();
            foreach (var s in sahalar)
                dgvSahalar.Rows.Add(s.Ad, s.Adres, s.Kapasite + " kişi", s.FiyatSaat.ToString("N0") + " ₺", s.EklenmeTarihi.ToString("dd.MM.yyyy"));
            lblSahaCount.Text = sahalar.Count > 0
                ? $"Toplam {sahalar.Count} saha kayıtlı"
                : "Henüz saha eklenmemiş. 'Yeni Saha Ekle' butonu ile başlayın.";
        }

        private void BtnYeniSaha_Click(object sender, EventArgs e)
        {
            var f = new FormSahaEkle();
            this.Hide();
            f.FormClosed += (s, ev) => { this.Show(); SahalariYukle(); };
            f.Show();
        }
    }
}
