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
    /// Lógica de interacción para Wrong.xaml
    /// </summary>
    public partial class Wrong : Window
    {
        public Wrong(string Mensaje)
        {
            InitializeComponent();
            lblInfo.Content = Mensaje;
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
