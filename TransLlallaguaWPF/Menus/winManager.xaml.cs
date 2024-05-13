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
using TransLlallaguaWPF.Login;
using TransLlallaguaWPF.ChangePassword;
using TransLlallaguaWPF.Bus;
namespace TransLlallaguaWPF.Menus
{
    /// <summary>
    /// Lógica de interacción para winManager.xaml
    /// </summary>
    public partial class winManager : Window
    {
        public winManager()
        {
            InitializeComponent();
        }
        private void busImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            winBus winBus = new winBus();
            winBus.Show();
            this.Close();
        }

        private void historyImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
        }

        private void off2Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            winLogin winLogin = new winLogin();
            winLogin.Show();
            this.Close();
        }

        private void keyImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            winChangePassword winChangePassword = new winChangePassword();
            winChangePassword.Show();
            this.Close();
        }
    }
}
