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

namespace TransLlallaguaWPF.Menus
{
    /// <summary>
    /// Lógica de interacción para winEmployeeMenu.xaml
    /// </summary>
    public partial class winEmployeeMenu : Window
    {
        public winEmployeeMenu()
        {
            InitializeComponent();
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
