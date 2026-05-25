using System;
using System.Drawing;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public class FormKullaniciPanel : BaseChildForm
    {
        private Panel pnlHeader;
        private Label lblBaslik;
        private Label lblAltBaslik;
        private DataGridView dgvRezervasyonlar;
        private Button btnYeniArama;
        private Button btnCikis;
        private Panel pnlToolbar;
        private Label lblCount;

        public FormKullaniciPanel()
        {
            this.ClientSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Kullanıcı Paneli";
            this.BackColor = UIHelper.CArkaplan;
            this.Icon = SystemIcons.Application;

            SetupUI();
            this.Load += (s, e) => RezervasyonlariYukle();
        }

        private void SetupUI()
        {
            // Header
            pnlHeader = new Panel { Dock = DockStyle.Top, Height = 90, BackColor = Color.White };
            pnlHeader.Paint += (s, e) => e.Graphics.DrawLine(new Pen(UIHelper.CBolme), 0, 89, pnlHeader.Width, 89);
            
            lblBaslik = new Label { Text = "👤  Kullanıcı Paneli", Font = new Font("Segoe UI", 18, FontStyle.Bold), ForeColor = UIHelper.CAna, AutoSize = true, Location = new Point(35, 20) };
            lblAltBaslik = new Label { Text = $"Hoş geldiniz, {Oturum.AktifKullanici.Ad} {Oturum.AktifKullanici.Soyad}", Font = new Font("Segoe UI", 10, FontStyle.Regular), ForeColor = UIHelper.CMetin, AutoSize = true, Location = new Point(38, 55) };
            
            btnYeniArama = new Button { Text = "Yeni Saha Ara", BackColor = UIHelper.CAna, ForeColor = Color.White, FlatStyle = FlatStyle.Flat, Size = new Size(160, 40), Location = new Point(this.Width - 300, 25), Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand };
            btnYeniArama.FlatAppearance.BorderSize = 0;
            btnYeniArama.Click += BtnYeniArama_Click;

            btnCikis = new Button { Text = "Çıkış Yap", BackColor = Color.White, ForeColor = UIHelper.CMetin, FlatStyle = FlatStyle.Flat, Size = new Size(100, 40), Location = new Point(this.Width - 130, 25), Font = new Font("Segoe UI", 10, FontStyle.Bold), Cursor = Cursors.Hand };
            btnCikis.FlatAppearance.BorderColor = UIHelper.CBolme;
            btnCikis.Click += BtnCikis_Click;

            pnlHeader.Controls.Add(lblBaslik);
            pnlHeader.Controls.Add(lblAltBaslik);
            pnlHeader.Controls.Add(btnYeniArama);
            pnlHeader.Controls.Add(btnCikis);
            this.Controls.Add(pnlHeader);

            // Toolbar
            pnlToolbar = new Panel { Dock = DockStyle.Top, Height = 60, BackColor = UIHelper.CArkaplan };
            lblCount = new Label { Text = "Geçmiş ve Gelecek Rezervasyonlarınız", Font = new Font("Segoe UI", 11, FontStyle.Bold), ForeColor = UIHelper.CMetin, AutoSize = true, Location = new Point(35, 20) };
            pnlToolbar.Controls.Add(lblCount);
            this.Controls.Add(pnlToolbar);

            // DataGridView
            dgvRezervasyonlar = new DataGridView {
                Dock = DockStyle.Fill,
                BackgroundColor = UIHelper.CArkaplan,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = UIHelper.CBolme,
                EnableHeadersVisualStyles = false
            };
            
            dgvRezervasyonlar.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvRezervasyonlar.ColumnHeadersDefaultCellStyle.ForeColor = UIHelper.CMetin;
            dgvRezervasyonlar.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            dgvRezervasyonlar.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvRezervasyonlar.ColumnHeadersHeight = 50;

            dgvRezervasyonlar.DefaultCellStyle.BackColor = Color.White;
            dgvRezervasyonlar.DefaultCellStyle.ForeColor = UIHelper.CMetin;
            dgvRezervasyonlar.DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Regular);
            dgvRezervasyonlar.DefaultCellStyle.SelectionBackColor = Color.FromArgb(230, 245, 235);
            dgvRezervasyonlar.DefaultCellStyle.SelectionForeColor = UIHelper.CMetin;
            dgvRezervasyonlar.RowTemplate.Height = 50;

            dgvRezervasyonlar.Columns.Add("Saha", "Saha Adı");
            dgvRezervasyonlar.Columns.Add("Konum", "İl / İlçe");
            dgvRezervasyonlar.Columns.Add("Adres", "Adres");
            dgvRezervasyonlar.Columns.Add("Tarih", "Tarih");
            dgvRezervasyonlar.Columns.Add("Saat", "Saat");
            dgvRezervasyonlar.Columns.Add("Fiyat", "Fiyat");

            var btnIptal = new DataGridViewButtonColumn();
            btnIptal.Name = "btnIptal";
            btnIptal.HeaderText = "İşlem";
            btnIptal.Text = "İptal Et";
            btnIptal.UseColumnTextForButtonValue = true;
            btnIptal.FlatStyle = FlatStyle.Flat;
            dgvRezervasyonlar.Columns.Add(btnIptal);
            dgvRezervasyonlar.CellContentClick += DgvRezervasyonlar_CellContentClick;

            var padding = new Padding(35, 10, 35, 35);
            var pnlGridContainer = new Panel { Dock = DockStyle.Fill, Padding = padding };
            pnlGridContainer.Controls.Add(dgvRezervasyonlar);
            
            // Layout Order: Fill should be added first, then Toolbar, then Header so Header is at the very top.
            this.Controls.Clear();
            this.Controls.Add(pnlGridContainer);
            this.Controls.Add(pnlToolbar);
            this.Controls.Add(pnlHeader);

            this.Resize += (s, e) => {
                btnCikis.Location = new Point(this.Width - 140, 25);
                btnYeniArama.Location = new Point(this.Width - 320, 25);
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
                    SahaServisi.RezervasyonIptal(id);
                    RezervasyonlariYukle();
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
