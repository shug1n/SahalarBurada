using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public class FormOrganizatorPanel : Form
    {
        private DataGridView dgvSahalar;
        private Label lblSahaCount;

        public FormOrganizatorPanel()
        {
            UIHelper.FormAyarla(this, "Organizatör Paneli", 960, 690);
            InitUI();
        }

        private void InitUI()
        {
            var org = Oturum.AktifOrganizator;
            this.Controls.Add(UIHelper.HeaderPanelOlustur(
                $"🏢  {org.IsletmeAdi}",
                $"Hoş geldiniz, {org.Ad} {org.Soyad}  •  {org.Eposta}"));

            // ── Araç çubuğu ─────────────────────────────────────────
            var toolbar = new Panel
            {
                Location = new Point(0, 95), Size = new Size(960, 60), BackColor = Color.White
            };
            toolbar.Paint += (s, e) =>
                e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 59, toolbar.Width, 59);

            var btnYeni = UIHelper.BtnPrimary("➕   Yeni Saha Ekle", 20, 10, 185, 40);
            btnYeni.Click += BtnYeniSaha_Click;
            toolbar.Controls.Add(btnYeni);

            var btnYenile = UIHelper.BtnSecondary("🔄  Yenile", 218, 10, 110, 40);
            btnYenile.Click += (s, e) => SahalariYukle();
            toolbar.Controls.Add(btnYenile);

            var btnCikis = UIHelper.BtnDanger("Çıkış Yap", 840, 10, 110, 40);
            btnCikis.Click += (s, e) => { Oturum.CikisYap(); this.Close(); };
            toolbar.Controls.Add(btnCikis);

            this.Controls.Add(toolbar);

            // ── Başlık + sayaç ───────────────────────────────────────
            this.Controls.Add(new Label
            {
                Text = "Sahalarım", Font = UIHelper.FAltBaslik,
                ForeColor = UIHelper.CMetin, AutoSize = true, Location = new Point(22, 172)
            });
            lblSahaCount = new Label
            {
                Font = UIHelper.FKucukItalik, ForeColor = UIHelper.CMetinAcik,
                AutoSize = true, Location = new Point(22, 200)
            };
            this.Controls.Add(lblSahaCount);

            // ── DataGridView ─────────────────────────────────────────
            dgvSahalar = new DataGridView
            {
                Location = new Point(22, 220),
                Size     = new Size(916, 420),
                TabIndex = 0
            };
            UIHelper.DGVAyarla(dgvSahalar);
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Saha Adı",       Width = 240 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Adres",           Width = 230 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Kapasite",        Width = 100 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Fiyat/Saat",      Width = 120 });
            dgvSahalar.Columns.Add(new DataGridViewTextBoxColumn { HeaderText = "Eklenme Tarihi",  Width = 140 });
            this.Controls.Add(dgvSahalar);

            SahalariYukle();
        }

        private void SahalariYukle()
        {
            var sahalar = SahaServisi.OrganizatorSahalari(Oturum.AktifOrganizator.Id);
            dgvSahalar.Rows.Clear();
            foreach (var s in sahalar)
                dgvSahalar.Rows.Add(s.Ad, s.Adres, s.Kapasite + " kişi",
                    s.FiyatSaat.ToString("N0") + " ₺", s.EklenmeTarihi.ToString("dd.MM.yyyy"));

            lblSahaCount.Text = sahalar.Count > 0
                ? $"Toplam {sahalar.Count} saha kayıtlı"
                : "Henüz saha eklenmemiş. 'Yeni Saha Ekle' butonu ile başlayın.";
        }

        private void BtnYeniSaha_Click(object sender, System.EventArgs e)
        {
            var f = new FormSahaEkle();
            this.Hide();
            f.FormClosed += (s, ev) => { this.Show(); SahalariYukle(); };
            f.Show();
        }
    }
}
