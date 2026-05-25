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
    public class FormOrganizatorRezervasyonlar : Form
    {
        private Panel pnlHeader;
        private Panel pnlFilters;
        private Label lblSahaSec;
        private ComboBox cbSahalar;
        private Label lblTarihSec;
        private DateTimePicker dtpTarih;
        private DataGridView dgvRezervasyonlar;
        private Button btnKapat;

        private List<HaliSaha> _sahalar;

        public FormOrganizatorRezervasyonlar()
        {
            this.Text = "SahalarBurada — Saha Rezervasyon & Doluluk Durumu";
            this.ClientSize = new Size(950, 680);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.BackColor = UIHelper.CArkaplan;

            SetupUI();
            YukleSahalar();
        }

        private void SetupUI()
        {
            // ── Header Panel ─────────────────────────────────────────────
            pnlHeader = UIHelper.HeaderPanelOlustur(
                "📅 Saha Rezervasyon & Doluluk Durumu",
                "Seçilen saha ve tarihe göre saatlik doluluk oranını ve kiralayan bilgilerini görün."
            );
            this.Controls.Add(pnlHeader);

            // ── Filters Panel ─────────────────────────────────────────────
            pnlFilters = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = UIHelper.CKart
            };
            pnlFilters.Paint += (s, e) =>
            {
                using (var pen = new Pen(UIHelper.CBolme, 1))
                    e.Graphics.DrawLine(pen, 0, 69, pnlFilters.Width, 69);
            };

            lblSahaSec = new Label
            {
                Text = "Saha Seçin:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = UIHelper.CMetin,
                Location = new Point(30, 24),
                AutoSize = true
            };

            cbSahalar = new ComboBox
            {
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10),
                Width = 240,
                Location = new Point(120, 20)
            };
            cbSahalar.SelectedIndexChanged += FiltreDegisti;

            lblTarihSec = new Label
            {
                Text = "Tarih Seçin:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = UIHelper.CMetin,
                Location = new Point(390, 24),
                AutoSize = true
            };

            dtpTarih = new DateTimePicker
            {
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10),
                Width = 150,
                Location = new Point(480, 20)
            };
            dtpTarih.ValueChanged += FiltreDegisti;

            btnKapat = new Button
            {
                Text = "Kapat",
                BackColor = Color.FromArgb(100, 110, 100),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Size = new Size(100, 32),
                Location = new Point(810, 18),
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnKapat.FlatAppearance.BorderSize = 0;
            btnKapat.Click += (s, e) => this.Close();

            pnlFilters.Controls.Add(lblSahaSec);
            pnlFilters.Controls.Add(cbSahalar);
            pnlFilters.Controls.Add(lblTarihSec);
            pnlFilters.Controls.Add(dtpTarih);
            pnlFilters.Controls.Add(btnKapat);
            this.Controls.Add(pnlFilters);

            // ── DataGridView ─────────────────────────────────────────────
            dgvRezervasyonlar = new DataGridView
            {
                Dock = DockStyle.Fill,
                BackgroundColor = UIHelper.CKart,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                GridColor = UIHelper.CBolme,
                EnableHeadersVisualStyles = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgvRezervasyonlar.Columns.Add("Saat", "Saat");
            dgvRezervasyonlar.Columns.Add("Durum", "Durum");
            dgvRezervasyonlar.Columns.Add("Kiralayan", "Kiralayan (Ad Soyad)");
            dgvRezervasyonlar.Columns.Add("Iletisim", "İletişim Bilgisi");
            dgvRezervasyonlar.Columns.Add("Ucret", "Toplam Ücret");

            // Kolon genişlik ayarları
            dgvRezervasyonlar.Columns["Saat"].Width = 100;
            dgvRezervasyonlar.Columns["Durum"].Width = 120;
            dgvRezervasyonlar.Columns["Kiralayan"].Width = 250;
            dgvRezervasyonlar.Columns["Iletisim"].Width = 200;
            dgvRezervasyonlar.Columns["Ucret"].Width = 150;

            UIHelper.DGVAyarla(dgvRezervasyonlar);

            // Doluluk durumlarında BOŞ/DOLU renk hücre boyama ve özel çizim
            dgvRezervasyonlar.CellFormatting += DgvRezervasyonlar_CellFormatting;
            dgvRezervasyonlar.CellPainting += DgvRezervasyonlar_CellPainting;

            var pnlGridContainer = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(30, 20, 30, 30),
                BackColor = UIHelper.CArkaplan
            };
            pnlGridContainer.Controls.Add(dgvRezervasyonlar);
            this.Controls.Add(pnlGridContainer);

            // Layout sıralaması
            pnlFilters.BringToFront();
            pnlHeader.SendToBack();
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
                            iletisim = user.Eposta;
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

                dgvRezervasyonlar.Rows.Add(saat, durum, kiralayan, iletisim, ucret);
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
