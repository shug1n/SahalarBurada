using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormOrganizatorPanel : BaseChildForm
    {

        public FormOrganizatorPanel()
        {
            InitializeComponent();
            this.ClientSize = new Size(1000, 700);
            SetupLogic();
        }

        private void SetupLogic()
        {
            var org = Oturum.AktifOrganizator;
            lblHeaderBaslik.Text = $"🏢  {org.IsletmeAdi}";
            lblHeaderAltBaslik.Text = $"Hoş geldiniz, {org.Ad} {org.Soyad}  •  {org.Eposta}";

            // Premium Header Gradient
            pnlHeader.Paint += (s, e) =>
            {
                var g = e.Graphics;
                using (var br = new System.Drawing.Drawing2D.LinearGradientBrush(pnlHeader.ClientRectangle,
                    UIHelper.CHeaderGradStart, UIHelper.CHeaderGradEnd,
                    System.Drawing.Drawing2D.LinearGradientMode.Horizontal))
                    g.FillRectangle(br, pnlHeader.ClientRectangle);
                using (var pen = new Pen(Color.FromArgb(60, 255, 255, 255), 1))
                    g.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            };

            // ToolBar and button styling
            pnlToolbar.BackColor = UIHelper.CArkaplan;
            btnYeni.BackColor = UIHelper.CAna;
            btnYeni.FlatAppearance.MouseOverBackColor = UIHelper.CIkinci;
            
            btnYenile.BackColor = UIHelper.CKart;
            btnYenile.FlatAppearance.BorderColor = UIHelper.CBolme;
            btnYenile.FlatAppearance.MouseOverBackColor = Color.FromArgb(235, 245, 235);
            btnYenile.ForeColor = UIHelper.CAna;

            btnCikis.BackColor = UIHelper.CHata;
            btnCikis.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 20, 20);

            // Dynamically Add Rezervasyon Raporu Button
            if (pnlToolbar.Controls["btnRezervasyonlar"] == null)
            {
                var btnRezervasyonlar = new Button
                {
                    Name = "btnRezervasyonlar",
                    Text = "📅  Rezervasyon Raporu",
                    BackColor = UIHelper.CIkinci,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Size = new Size(200, 40),
                    Location = new Point(338, 10),
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Cursor = Cursors.Hand
                };
                btnRezervasyonlar.FlatAppearance.BorderSize = 0;
                btnRezervasyonlar.FlatAppearance.MouseOverBackColor = UIHelper.CVurgu;
                btnRezervasyonlar.Click += BtnRezervasyonlar_Click;
                pnlToolbar.Controls.Add(btnRezervasyonlar);
            }

            pnlContent.BackColor = UIHelper.CArkaplan;
            dgvSahalar.BackgroundColor = UIHelper.CKart;

            if (!dgvSahalar.Columns.Contains("btnSil"))
            {
                var btnSil = new DataGridViewButtonColumn();
                btnSil.Name = "btnSil";
                btnSil.HeaderText = "İşlem";
                btnSil.Text = "Sil";
                btnSil.UseColumnTextForButtonValue = true;
                btnSil.FlatStyle = FlatStyle.Flat;
                btnSil.DefaultCellStyle.BackColor = UIHelper.CKart;
                btnSil.DefaultCellStyle.ForeColor = Color.FromArgb(185, 35, 35);
                btnSil.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 240, 240);
                btnSil.DefaultCellStyle.SelectionForeColor = Color.FromArgb(185, 35, 35);
                btnSil.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                btnSil.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                btnSil.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
                dgvSahalar.Columns.Add(btnSil);
                dgvSahalar.CellContentClick += DgvSahalar_CellContentClick;
            }

            UIHelper.DGVAyarla(dgvSahalar);
            dgvSahalar.ReadOnly = false;
            foreach (DataGridViewColumn col in dgvSahalar.Columns)
            {
                if (col.Name != "btnSil") col.ReadOnly = true;
            }
            
            SahalariYukle();
        }

        private void DgvSahalar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvSahalar.Columns[e.ColumnIndex].Name == "btnSil")
            {
                if (MessageBox.Show("Bu sahayı ve tüm rezervasyonlarını silmek istediğinize emin misiniz?", "Saha Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string sahaId = dgvSahalar.Rows[e.RowIndex].Tag.ToString();
                    DatabaseServisi.DeleteField(sahaId);
                    SahalariYukle();
                }
            }
        }

        private void pnlToolbar_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 59, pnlToolbar.Width, 59);
        }

        private void BtnYenile_Click(object sender, EventArgs e) => SahalariYukle();
        private void BtnCikis_Click(object sender, EventArgs e) { Oturum.CikisYap(); IsBackButtonClicked = true; this.Close(); }

        private void SahalariYukle()
        {
            var sahalar = SahaServisi.OrganizatorSahalari(Oturum.AktifOrganizator.Id);
            dgvSahalar.Rows.Clear();
            foreach (var s in sahalar)
            {
                int idx = dgvSahalar.Rows.Add(s.Ad, s.Adres, (s.Sehir + " / " + s.Ilce).Trim(' ', '/'), s.FiyatSaat.ToString("N0") + " ₺", s.EklenmeTarihi.ToString("dd.MM.yyyy"));
                dgvSahalar.Rows[idx].Tag = s.Id;
            }
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

        private void BtnRezervasyonlar_Click(object sender, EventArgs e)
        {
            var f = new FormOrganizatorRezervasyonlar();
            this.Hide();
            f.FormClosed += (s, ev) => this.Show();
            f.ShowDialog();
        }
    }
}
