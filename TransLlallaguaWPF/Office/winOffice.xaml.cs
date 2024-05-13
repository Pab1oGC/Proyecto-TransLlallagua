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

namespace TransLlallaguaWPF.Office
{
    /// <summary>
    /// Lógica de interacción para winOffice.xaml
    /// </summary>
    public partial class winOffice : Window
    {
        public winOffice()
        {
            InitializeComponent();
            //dgvTable.Columns[0].Visibility = Visibility.Collapsed;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 1;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 0;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 0;
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
