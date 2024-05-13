using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows;
using System.Windows.Controls;
namespace TransLlallaguaDAO.Utils
{
    public class Toast
    {
        private DispatcherTimer _toastTimer;

        public Label ToastLabel { get; private set; }

        public Toast(Label toastLabel)
        {
            ToastLabel = toastLabel;
        }

        public void ShowToast(string message, int durationSeconds)
        {
            ToastLabel.Content = message;
            ToastLabel.Visibility = Visibility.Visible;
            _toastTimer = new DispatcherTimer();
            _toastTimer.Interval = TimeSpan.FromSeconds(durationSeconds);
            _toastTimer.Tick += ToastTimer_Tick;
            _toastTimer.Start();
        }

        private void ToastTimer_Tick(object sender, EventArgs e)
        {
            _toastTimer.Stop();
            ToastLabel.Visibility = Visibility.Collapsed;
        }
    }
}
