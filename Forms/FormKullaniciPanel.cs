using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormKullaniciPanel : BaseChildForm
    {
        public FormKullaniciPanel()
        {
            InitializeComponent();
            
            // Custom setup and z-order dynamics
            SetupDynamics();
            this.Load += (s, e) => RezervasyonlariYukle();
        }

        private void SetupDynamics()
        {
            // Custom header styling (gradient setup and custom subtitle)
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

            // Custom header label additions
            var lblTitle = new Label
            {
                Text = "👤  Kullanıcı Paneli",
                Font = UIHelper.FBaslik,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(25, 16),
                BackColor = Color.Transparent
            };
            var lblSubtitle = new Label
            {
                Text = $"Hoş geldiniz, {Oturum.AktifKullanici.Ad} {Oturum.AktifKullanici.Soyad}  •  {Oturum.AktifKullanici.Eposta}",
                Font = UIHelper.FKucuk,
                ForeColor = Color.FromArgb(180, 255, 255, 255),
                AutoSize = true,
                Location = new Point(27, 54),
                BackColor = Color.Transparent
            };
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            lblTitle.BringToFront();
            lblSubtitle.BringToFront();
            btnYeniArama.BringToFront();
            btnCikis.BringToFront();

            pnlToolbar.Paint += (s, e) =>
            {
                using (var pen = new Pen(UIHelper.CBolme, 1))
                    e.Graphics.DrawLine(pen, 0, 51, pnlToolbar.Width, 51);
            };

            // Setup DGV columns and settings
            dgvRezervasyonlar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Saha",  HeaderText = "Saha Adı",  ReadOnly = true });
            dgvRezervasyonlar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Konum", HeaderText = "İl / İlçe", ReadOnly = true });
            dgvRezervasyonlar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Adres", HeaderText = "Adres",    ReadOnly = true });
            dgvRezervasyonlar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Tarih", HeaderText = "Tarih",    ReadOnly = true });
            dgvRezervasyonlar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Saat",  HeaderText = "Saat",     ReadOnly = true });
            dgvRezervasyonlar.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fiyat", HeaderText = "Fiyat",    ReadOnly = true });

            var btnIptal = new DataGridViewButtonColumn();
            btnIptal.Name = "btnIptal";
            btnIptal.HeaderText = "İşlem";
            btnIptal.Text = "✕  İptal Et";
            btnIptal.UseColumnTextForButtonValue = true;
            btnIptal.FlatStyle = FlatStyle.Flat;
            btnIptal.DefaultCellStyle.BackColor = UIHelper.CKart;
            btnIptal.DefaultCellStyle.ForeColor = Color.FromArgb(185, 35, 35);
            btnIptal.DefaultCellStyle.SelectionBackColor = Color.FromArgb(255, 240, 240);
            btnIptal.DefaultCellStyle.SelectionForeColor = Color.FromArgb(185, 35, 35);
            btnIptal.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnIptal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            btnIptal.DefaultCellStyle.Padding = new Padding(6, 4, 6, 4);
            dgvRezervasyonlar.Columns.Add(btnIptal);

            UIHelper.DGVAyarla(dgvRezervasyonlar);

            this.Resize += (s, e) => {
                btnCikis.Location = new Point(this.Width - 145, 28);
                btnYeniArama.Location = new Point(this.Width - 322, 28);
            };
        }

        private void RezervasyonlariYukle()
        {
            dgvRezervasyonlar.Rows.Clear();
            var list = DatabaseServisi.GetAllReservations();
            var sahalar = System.Linq.Enumerable.ToDictionary(DatabaseServisi.GetAllFields(), s => s.Id);
            
            int count = 0;
            foreach (var r in list)
            {
                if (r.KullaniciId == Oturum.AktifKullanici.Id)
                {
                    string konum = "-";
                    string adres = "-";
                    if (sahalar.TryGetValue(r.SahaId, out var saha))
                    {
                        konum = (saha.Sehir + " / " + saha.Ilce).Trim(' ', '/');
                        adres = saha.Adres;
                    }
                    int idx = dgvRezervasyonlar.Rows.Add(r.SahaAdi, konum, adres, r.Tarih.ToString("dd MMMM yyyy"), r.Saat, r.ToplamFiyat.ToString("N0") + " ₺");
                    dgvRezervasyonlar.Rows[idx].Tag = r.Id;
                    count++;
                }
            }
            lblCount.Text = count > 0 
                ? $"Toplam {count} rezervasyonunuz bulunuyor." 
                : "Henüz bir rezervasyonunuz yok. Yeni saha ara butonuna tıklayarak arama yapabilirsiniz.";
        }

        private void DgvRezervasyonlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRezervasyonlar.Columns[e.ColumnIndex].Name == "btnIptal")
            {
                if (MessageBox.Show("Bu rezervasyonu iptal etmek istediğinize emin misiniz?", "Rezervasyon İptali", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string id = dgvRezervasyonlar.Rows[e.RowIndex].Tag.ToString();
                    var (basarili, mesaj) = SahaServisi.RezervasyonIptalEt(id);
                    if (basarili)
                    {
                        MessageBox.Show(mesaj, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RezervasyonlariYukle();
                    }
                    else
                    {
                        MessageBox.Show(mesaj, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void BtnYeniArama_Click(object sender, EventArgs e)
        {
            var f = new FormSahaAra();
            this.Hide();
            f.FormClosed += (s, ev) => { 
                this.Show(); 
                RezervasyonlariYukle(); 
            };
            f.Show();
        }

        private void BtnCikis_Click(object sender, EventArgs e)
        {
            Oturum.CikisYap();
            IsBackButtonClicked = true;
            this.Close();
        }
    }
}
