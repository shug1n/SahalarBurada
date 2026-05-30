using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SahalarBurada.Helpers;
using SahalarBurada.Models;
using SahalarBurada.Services;

namespace SahalarBurada.Forms
{
    public partial class FormOrganizatorRezervasyonlar : BaseChildForm
    {
        private List<HaliSaha> _sahalar;

        public FormOrganizatorRezervasyonlar()
        {
            InitializeComponent();
            this.ClientSize = new Size(1000, 700);
            this.StartPosition = FormStartPosition.CenterScreen;
            
            // Custom setup and dynamics
            SetupDynamics();
            YukleSahalar();
        }

        private void SetupDynamics()
        {
            // Custom header styling (gradient setup and custom title/subtitle)
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

            var lblTitle = new Label
            {
                Text = "📅 Saha Rezervasyon & Doluluk Durumu",
                Font = UIHelper.FBaslik,
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(25, 16),
                BackColor = Color.Transparent
            };
            var lblSubtitle = new Label
            {
                Text = "Seçilen saha ve tarihe göre saatlik doluluk oranını ve kiralayan bilgilerini görün.",
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

            // Set read-only false to allow button column clicks
            dgvRezervasyonlar.ReadOnly = false;

            // Setup DGV columns and settings
            dgvRezervasyonlar.Columns.Add("Saat", "Saat");
            dgvRezervasyonlar.Columns.Add("Durum", "Durum");
            dgvRezervasyonlar.Columns.Add("Kiralayan", "Kiralayan (Ad Soyad)");
            dgvRezervasyonlar.Columns.Add("Iletisim", "İletişim Bilgisi");
            dgvRezervasyonlar.Columns.Add("Ucret", "Toplam Ücret");

            var btnDetayCol = new DataGridViewButtonColumn();
            btnDetayCol.Name = "btnDetay";
            btnDetayCol.HeaderText = "İşlem";
            btnDetayCol.Text = "🔍 Detay";
            btnDetayCol.UseColumnTextForButtonValue = true;
            btnDetayCol.FlatStyle = FlatStyle.Flat;
            btnDetayCol.DefaultCellStyle.BackColor = UIHelper.CKart;
            btnDetayCol.DefaultCellStyle.ForeColor = UIHelper.CAna;
            btnDetayCol.DefaultCellStyle.SelectionBackColor = Color.FromArgb(235, 245, 235);
            btnDetayCol.DefaultCellStyle.SelectionForeColor = UIHelper.CAna;
            btnDetayCol.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnDetayCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvRezervasyonlar.Columns.Add(btnDetayCol);

            // Kolon genişlik ayarları
            dgvRezervasyonlar.Columns["Saat"].Width = 100;
            dgvRezervasyonlar.Columns["Durum"].Width = 100;
            dgvRezervasyonlar.Columns["Kiralayan"].Width = 220;
            dgvRezervasyonlar.Columns["Iletisim"].Width = 180;
            dgvRezervasyonlar.Columns["Ucret"].Width = 120;
            dgvRezervasyonlar.Columns["btnDetay"].Width = 120;

            UIHelper.DGVAyarla(dgvRezervasyonlar);
        }

        private void PnlFilters_Paint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(UIHelper.CBolme, 1))
                e.Graphics.DrawLine(pen, 0, 69, pnlFilters.Width, 69);
        }

        private void BtnKapat_Click(object sender, EventArgs e)
        {
            this.IsBackButtonClicked = true;
            this.Close();
        }

        private void YukleSahalar()
        {
            _sahalar = SahaServisi.OrganizatorSahalari(Oturum.AktifOrganizator.Id);
            cbSahalar.Items.Clear();

            if (_sahalar.Count == 0)
            {
                cbSahalar.Items.Add("Kayıtlı saha yok");
                cbSahalar.SelectedIndex = 0;
                cbSahalar.Enabled = false;
                return;
            }

            foreach (var s in _sahalar)
            {
                cbSahalar.Items.Add(s.Ad);
            }
            cbSahalar.SelectedIndex = 0;
        }

        private void FiltreDegisti(object sender, EventArgs e)
        {
            RezervasyonlariGoster();
        }

        private void RezervasyonlariGoster()
        {
            dgvRezervasyonlar.Rows.Clear();

            if (_sahalar == null || _sahalar.Count == 0 || cbSahalar.SelectedIndex < 0)
                return;

            var secilenSaha = _sahalar[cbSahalar.SelectedIndex];
            var tarih = dtpTarih.Value.Date;

            // Veritabanındaki tüm rezervasyonlar içinden çakışanları bul
            var rezervasyonlar = DatabaseServisi.GetAllReservations()
                .Where(r => r.SahaId == secilenSaha.Id && r.Tarih.Date == tarih)
                .ToDictionary(r => r.Saat);

            // Sahanın tanımlı müsait saatleri üzerinden döngü kur
            foreach (var saat in secilenSaha.MüsaitSaatler.OrderBy(s => s))
            {
                string durum = "BOŞ";
                string kiralayan = "-";
                string iletisim = "-";
                string ucret = secilenSaha.FiyatSaat.ToString("N0") + " ₺";

                if (rezervasyonlar.TryGetValue(saat, out var r))
                {
                    durum = "DOLU";
                    if (!string.IsNullOrEmpty(r.KullaniciId))
                    {
                        var user = DatabaseServisi.GetUserById(r.KullaniciId);
                        if (user != null)
                        {
                            kiralayan = $"{user.Ad} {user.Soyad} (Üye)";
                            iletisim = !string.IsNullOrEmpty(user.Telefon) ? user.Telefon : (!string.IsNullOrEmpty(r.MisafirTelefon) ? r.MisafirTelefon : "Belirtilmemiş");
                        }
                        else
                        {
                            kiralayan = r.MisafirAd ?? "Kayıtlı Üye";
                            iletisim = !string.IsNullOrEmpty(r.MisafirTelefon) ? r.MisafirTelefon : "-";
                        }
                    }
                    else
                    {
                        kiralayan = r.MisafirAd ?? "Misafir";
                        iletisim = !string.IsNullOrEmpty(r.MisafirTelefon) ? r.MisafirTelefon : "-";
                    }
                    ucret = r.ToplamFiyat.ToString("N0") + " ₺";
                }

                int idx = dgvRezervasyonlar.Rows.Add(saat, durum, kiralayan, iletisim, ucret);
                if (rezervasyonlar.TryGetValue(saat, out var res))
                {
                    dgvRezervasyonlar.Rows[idx].Tag = res;
                }
                else
                {
                    dgvRezervasyonlar.Rows[idx].Tag = null;
                }
            }
        }

        private void DgvRezervasyonlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvRezervasyonlar.Columns[e.ColumnIndex].Name == "btnDetay")
            {
                var r = dgvRezervasyonlar.Rows[e.RowIndex].Tag as Rezervasyon;
                if (r != null)
                {
                    var f = new FormKiraciDetay(r);
                    this.Hide();
                    f.FormClosed += (s, ev) => {
                        this.Location = f.Location;
                        this.Show();
                        RezervasyonlariGoster();
                    };
                    f.Show();
                }
                else
                {
                    MessageBox.Show("Bu saat dilimi boş olduğu için ayrıntı bulunmamaktadır.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void DgvRezervasyonlar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var colName = dgvRezervasyonlar.Columns[e.ColumnIndex].Name;
                if (colName == "Saat")
                {
                    e.CellStyle.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
                    e.CellStyle.ForeColor = UIHelper.CMetin;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                else if (colName == "Kiralayan" && e.Value != null)
                {
                    if (e.Value.ToString() == "-")
                    {
                        e.CellStyle.ForeColor = UIHelper.CMetinAcik;
                    }
                    else
                    {
                        e.CellStyle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                        e.CellStyle.ForeColor = UIHelper.CMetin;
                    }
                }
                else if (colName == "Iletisim" && e.Value != null)
                {
                    if (e.Value.ToString() == "-")
                    {
                        e.CellStyle.ForeColor = UIHelper.CMetinAcik;
                    }
                    else
                    {
                        e.CellStyle.Font = new Font("Consolas", 10f, FontStyle.Regular);
                        e.CellStyle.ForeColor = UIHelper.CIkinci;
                    }
                }
                else if (colName == "Ucret" && e.Value != null)
                {
                    e.CellStyle.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
                    e.CellStyle.ForeColor = UIHelper.CAna;
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        private void DgvRezervasyonlar_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 && dgvRezervasyonlar.Columns[e.ColumnIndex].Name == "Durum" && e.Value != null)
            {
                // Seçim durumuna ve satır stiline göre arka plan rengini belirle
                bool isSelected = (e.State & DataGridViewElementStates.Selected) == DataGridViewElementStates.Selected;
                Color cellBgColor = isSelected ? e.CellStyle.SelectionBackColor : e.CellStyle.BackColor;

                // Hücre arka planını temizle ve doğru renkle boya
                using (var bgBrush = new SolidBrush(cellBgColor))
                {
                    e.Graphics.FillRectangle(bgBrush, e.CellBounds);
                }

                // Kenarlıkları standart olarak çiz
                e.Paint(e.CellBounds, DataGridViewPaintParts.Border);

                string val = e.Value.ToString();
                bool isBos = val == "BOŞ";

                // Pill parametreleri
                int pillW = 85;
                int pillH = 24;
                int pillX = e.CellBounds.X + (e.CellBounds.Width - pillW) / 2;
                int pillY = e.CellBounds.Y + (e.CellBounds.Height - pillH) / 2;

                Color bgPill = isBos 
                    ? Color.FromArgb(232, 245, 233) 
                    : Color.FromArgb(253, 237, 237);
                
                Color fgText = isBos 
                    ? Color.FromArgb(46, 125, 50) 
                    : Color.FromArgb(198, 40, 40);

                var g = e.Graphics;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                // Pill Arka Planı (Yuvarlatılmış Dikdörtgen)
                using (var path = GetRoundedRectPath(new Rectangle(pillX, pillY, pillW, pillH), 6))
                using (var br = new SolidBrush(bgPill))
                {
                    g.FillPath(br, path);
                }

                // Pill Yazısı
                string text = isBos ? "BOŞ" : "DOLU";
                using (var font = new Font("Segoe UI", 9f, FontStyle.Bold))
                using (var brText = new SolidBrush(fgText))
                {
                    var size = g.MeasureString(text, font);
                    float textX = pillX + (pillW - size.Width) / 2;
                    float textY = pillY + (pillH - size.Height) / 2 + 1;
                    g.DrawString(text, font, brText, textX, textY);
                }

                e.Handled = true;
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRectPath(Rectangle bounds, int radius)
        {
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(bounds.X, bounds.Y, diameter, diameter, 180, 90);
            path.AddArc(bounds.X + bounds.Width - diameter, bounds.Y, diameter, diameter, 270, 90);
            path.AddArc(bounds.X + bounds.Width - diameter, bounds.Y + bounds.Height - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.X, bounds.Y + bounds.Height - diameter, diameter, diameter, 90, 90);
            path.CloseAllFigures();
            return path;
        }
    }
}
