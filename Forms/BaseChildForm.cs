using System;
using System.Windows.Forms;
using SahalarBurada.Helpers;

namespace SahalarBurada.Forms
{
    public class BaseChildForm : Form
    {
        public bool IsBackButtonClicked { get; set; } = false;

        public BaseChildForm()
        {
            this.Load += (s, e) => UIHelper.EnableEnterKeySelection(this);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Eğer kapanma nedeni kullanıcı kaynaklıysa (Çarpıya basma veya Geri tuşu ile Close() çağırma)
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Eğer geri tuşuna BASILMADIYSA (yani doğrudan formun çarpısına basıldıysa)
                if (!IsBackButtonClicked)
                {
                    e.Cancel = true; // Kapanmayı iptal et
                    TrayManager.MinimizeToTray(this); // Tepsiye küçült
                }
            }

            base.OnFormClosing(e);
        }
    }
}
