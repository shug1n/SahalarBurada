namespace SahalarBurada.Forms
{
    partial class FormAnaEkran
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Tasarımcı tarafından oluşturulan bu yöntem — yalnızca form boyutunu tanımlar.
        /// Tüm kontrol kodları FormAnaEkran.cs → SetupUI() içindedir.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.ClientSize = new System.Drawing.Size(1020, 660);
            this.Name = "FormAnaEkran";
            this.Text = "SahalarBurada — Ana Sayfa";
            this.ResumeLayout(false);
        }
    }
}
