using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TransLlallaguaWPF.Messages
{
    /// <summary>
    /// Lógica de interacción para Caution.xaml
    /// </summary>
    public partial class Caution : Window
    {
        public bool IsConfirmed { get; private set; }
        public Caution(string Mensaje)
        {
            InitializeComponent();
            lblInfo.Content = Mensaje;
        }

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = true;
            this.Close();
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            IsConfirmed = false;
            this.Close();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
