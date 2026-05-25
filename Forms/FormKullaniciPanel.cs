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
            // ── Header (Gradient yeşil) ──────────────────────────────────
            pnlHeader = UIHelper.HeaderPanelOlustur(
                $"👤  Kullanıcı Paneli",
                $"Hoş geldiniz, {Oturum.AktifKullanici.Ad} {Oturum.AktifKullanici.Soyad}  •  {Oturum.AktifKullanici.Eposta}"
            );

            btnYeniArama = new Button {
                Text = "⚽  Yeni Saha Ara",
                BackColor = UIHelper.CIkinci,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(165, 38),
                Location = new Point(this.Width - 310, 28),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnYeniArama.FlatAppearance.BorderSize = 0;
            btnYeniArama.FlatAppearance.MouseOverBackColor = UIHelper.CVurgu;
            btnYeniArama.Click += BtnYeniArama_Click;

            btnCikis = new Button {
                Text = "Çıkış Yap",
                BackColor = Color.FromArgb(185, 35, 35),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(105, 38),
                Location = new Point(this.Width - 135, 28),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnCikis.FlatAppearance.BorderSize = 0;
            btnCikis.FlatAppearance.MouseOverBackColor = Color.FromArgb(160, 20, 20);
            btnCikis.Click += BtnCikis_Click;

            pnlHeader.Controls.Add(btnYeniArama);
            pnlHeader.Controls.Add(btnCikis);
            this.Controls.Add(pnlHeader);

            // ── Toolbar ──────────────────────────────────────────────────
            pnlToolbar = new Panel { Dock = DockStyle.Top, Height = 52, BackColor = UIHelper.CArkaplan };
            pnlToolbar.Paint += (s, e) =>
            {
                using (var pen = new Pen(UIHelper.CBolme, 1))
                    e.Graphics.DrawLine(pen, 0, 51, pnlToolbar.Width, 51);
            };
            lblCount = new Label {
                Text = "Rezervasyonlarınız",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = UIHelper.CMetin,
                AutoSize = true,
                Location = new Point(35, 15)
            };
            pnlToolbar.Controls.Add(lblCount);
            this.Controls.Add(pnlToolbar);

            // ── DataGridView ─────────────────────────────────────────────
            dgvRezervasyonlar = new DataGridView {
                Dock = DockStyle.Fill,
                BackgroundColor = UIHelper.CKart,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = false,   // false olmalı: button column click çalışsın
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowHeadersVisible = false,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = UIHelper.CBolme,
                EnableHeadersVisualStyles = false
            };

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

            // Önce kolonları ekle, SONRA DGVAyarla çağır — header style sonra gelince geçerli olur
            UIHelper.DGVAyarla(dgvRezervasyonlar);
            dgvRezervasyonlar.CellContentClick += DgvRezervasyonlar_CellContentClick;

            var pnlGridContainer = new Panel {
                Dock = DockStyle.Fill,
                Padding = new Padding(30, 12, 30, 30),
                BackColor = UIHelper.CArkaplan
            };
            pnlGridContainer.Controls.Add(dgvRezervasyonlar);

            // Fill önce, toolbar ve header sonra (WinForms z-order)
            this.Controls.Clear();
            this.Controls.Add(pnlGridContainer);
            this.Controls.Add(pnlToolbar);
            this.Controls.Add(pnlHeader);

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
