namespace SahalarBurada.Forms
{
    partial class FormOrganizatorRezervasyonlar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrganizatorRezervasyonlar));
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlFilters = new System.Windows.Forms.Panel();
            this.lblSahaSec = new System.Windows.Forms.Label();
            this.cbSahalar = new System.Windows.Forms.ComboBox();
            this.lblTarihSec = new System.Windows.Forms.Label();
            this.dtpTarih = new System.Windows.Forms.DateTimePicker();
            this.btnKapat = new System.Windows.Forms.Button();
            this.dgvRezervasyonlar = new System.Windows.Forms.DataGridView();
            this.pnlGridContainer = new System.Windows.Forms.Panel();
            this.pnlFilters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervasyonlar)).BeginInit();
            this.pnlGridContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(88)))), ((int)(((byte)(30)))));
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(950, 95);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlFilters
            // 
            this.pnlFilters.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.pnlFilters.Controls.Add(this.lblSahaSec);
            this.pnlFilters.Controls.Add(this.cbSahalar);
            this.pnlFilters.Controls.Add(this.lblTarihSec);
            this.pnlFilters.Controls.Add(this.dtpTarih);
            this.pnlFilters.Controls.Add(this.btnKapat);
            this.pnlFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFilters.Location = new System.Drawing.Point(0, 95);
            this.pnlFilters.Name = "pnlFilters";
            this.pnlFilters.Size = new System.Drawing.Size(950, 70);
            this.pnlFilters.TabIndex = 1;
            this.pnlFilters.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlFilters_Paint);
            // 
            // lblSahaSec
            // 
            this.lblSahaSec.AutoSize = true;
            this.lblSahaSec.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSahaSec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(28)))));
            this.lblSahaSec.Location = new System.Drawing.Point(30, 24);
            this.lblSahaSec.Name = "lblSahaSec";
            this.lblSahaSec.Size = new System.Drawing.Size(84, 19);
            this.lblSahaSec.TabIndex = 0;
            this.lblSahaSec.Text = "Saha Seçin:";
            // 
            // cbSahalar
            // 
            this.cbSahalar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSahalar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbSahalar.Location = new System.Drawing.Point(120, 20);
            this.cbSahalar.Name = "cbSahalar";
            this.cbSahalar.Size = new System.Drawing.Size(240, 25);
            this.cbSahalar.TabIndex = 1;
            this.cbSahalar.SelectedIndexChanged += new System.EventHandler(this.FiltreDegisti);
            // 
            // lblTarihSec
            // 
            this.lblTarihSec.AutoSize = true;
            this.lblTarihSec.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTarihSec.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(36)))), ((int)(((byte)(28)))));
            this.lblTarihSec.Location = new System.Drawing.Point(390, 24);
            this.lblTarihSec.Name = "lblTarihSec";
            this.lblTarihSec.Size = new System.Drawing.Size(85, 19);
            this.lblTarihSec.TabIndex = 2;
            this.lblTarihSec.Text = "Tarih Seçin:";
            // 
            // dtpTarih
            // 
            this.dtpTarih.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpTarih.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpTarih.Location = new System.Drawing.Point(480, 20);
            this.dtpTarih.Name = "dtpTarih";
            this.dtpTarih.Size = new System.Drawing.Size(150, 25);
            this.dtpTarih.TabIndex = 3;
            this.dtpTarih.ValueChanged += new System.EventHandler(this.FiltreDegisti);
            // 
            // btnKapat
            // 
            this.btnKapat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(110)))), ((int)(((byte)(100)))));
            this.btnKapat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnKapat.ForeColor = System.Drawing.Color.White;
            this.btnKapat.Location = new System.Drawing.Point(810, 18);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Size = new System.Drawing.Size(100, 32);
            this.btnKapat.TabIndex = 4;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = false;
            this.btnKapat.Click += new System.EventHandler(this.BtnKapat_Click);
            // 
            // dgvRezervasyonlar
            // 
            this.dgvRezervasyonlar.AllowUserToAddRows = false;
            this.dgvRezervasyonlar.AllowUserToDeleteRows = false;
            this.dgvRezervasyonlar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRezervasyonlar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(254)))), ((int)(((byte)(252)))));
            this.dgvRezervasyonlar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvRezervasyonlar.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvRezervasyonlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRezervasyonlar.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(220)))), ((int)(((byte)(210)))));
            this.dgvRezervasyonlar.Location = new System.Drawing.Point(30, 20);
            this.dgvRezervasyonlar.Name = "dgvRezervasyonlar";
            this.dgvRezervasyonlar.ReadOnly = true;
            this.dgvRezervasyonlar.RowHeadersVisible = false;
            this.dgvRezervasyonlar.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRezervasyonlar.Size = new System.Drawing.Size(890, 465);
            this.dgvRezervasyonlar.TabIndex = 0;
            this.dgvRezervasyonlar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvRezervasyonlar_CellContentClick);
            this.dgvRezervasyonlar.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.DgvRezervasyonlar_CellFormatting);
            this.dgvRezervasyonlar.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.DgvRezervasyonlar_CellPainting);
            // 
            // pnlGridContainer
            // 
            this.pnlGridContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.pnlGridContainer.Controls.Add(this.dgvRezervasyonlar);
            this.pnlGridContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGridContainer.Location = new System.Drawing.Point(0, 165);
            this.pnlGridContainer.Name = "pnlGridContainer";
            this.pnlGridContainer.Padding = new System.Windows.Forms.Padding(30, 20, 30, 30);
            this.pnlGridContainer.Size = new System.Drawing.Size(950, 515);
            this.pnlGridContainer.TabIndex = 2;
            // 
            // FormOrganizatorRezervasyonlar
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(248)))), ((int)(((byte)(245)))));
            this.ClientSize = new System.Drawing.Size(950, 680);
            this.Controls.Add(this.pnlGridContainer);
            this.Controls.Add(this.pnlFilters);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOrganizatorRezervasyonlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SahalarBurada — Saha Rezervasyon & Doluluk Durumu";
            this.pnlFilters.ResumeLayout(false);
            this.pnlFilters.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRezervasyonlar)).EndInit();
            this.pnlGridContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlFilters;
        private System.Windows.Forms.Label lblSahaSec;
        private System.Windows.Forms.ComboBox cbSahalar;
        private System.Windows.Forms.Label lblTarihSec;
        private System.Windows.Forms.DateTimePicker dtpTarih;
        private System.Windows.Forms.DataGridView dgvRezervasyonlar;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Panel pnlGridContainer;
    }
}
