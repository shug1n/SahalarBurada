using System;
using System.Drawing;
using System.Windows.Forms;

namespace SahalarBurada.Helpers
{
    public static class TrayManager
    {
        private static NotifyIcon _notifyIcon;
        private static Form _currentForm;

        public static void Initialize()
        {
            if (_notifyIcon != null) return;

            _notifyIcon = new NotifyIcon();
            _notifyIcon.Icon = SystemIcons.Application; // Default icon, can be changed later
            _notifyIcon.Text = "SahalarBurada";
            _notifyIcon.Visible = false;

            _notifyIcon.DoubleClick += (s, e) => Restore();

            var menu = new ContextMenu();
            menu.MenuItems.Add("Çıkış (Quit)", (s, e) => Application.Exit());
            _notifyIcon.ContextMenu = menu;
        }

        public static void MinimizeToTray(Form form)
        {
            _currentForm = form;
            form.Hide();
            _notifyIcon.Visible = true;
        }

        public static void Restore()
        {
            if (_currentForm != null)
            {
                _currentForm.Show();
                if (_currentForm.WindowState == FormWindowState.Minimized)
                {
                    _currentForm.WindowState = FormWindowState.Normal;
                }
                _currentForm.Activate();
            }
            _notifyIcon.Visible = false;
        }
    }
}
