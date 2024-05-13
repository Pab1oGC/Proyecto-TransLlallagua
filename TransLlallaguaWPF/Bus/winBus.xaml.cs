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
using TransLlallaguaDAO.Models;
using TransLlallaguaWPF.Menus;
namespace TransLlallaguaWPF.Bus
{
    /// <summary>
    /// Lógica de interacción para winBus.xaml
    /// </summary>
    public partial class winBus : Window
    {
        SelectWindow select = new SelectWindow();
        public winBus()
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
            Window window = select.GetWindow();
            window.Show();
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
