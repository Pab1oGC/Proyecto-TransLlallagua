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
using TransLlallaguaWPF.Passengers;
using TransLlallaguaWPF.Login;
using TransLlallaguaWPF.Model;
using TransLlallaguaWPF.Bus;
using TransLlallaguaWPF.User;
using TransLlallaguaWPF.ChangePassword;
using TransLlallaguaWPF.Insurance;
using TransLlallaguaDAO.Models;
using TransLlallaguaWPF.BrandWin;
namespace TransLlallaguaWPF.Menus
{
    /// <summary>
    /// Lógica de interacción para winAdminMenu.xaml
    /// </summary>
    public partial class winAdminMenu : Window
    {
        public winAdminMenu()
        {
            InitializeComponent();
            miUser.Header = SessionControl.Username;
        }

        
        private void animacionCompleta(object sender, EventArgs e)
        {
            // Reinicia la animación cuando haya terminado
            animacion.Seek(TimeSpan.Zero);
            animacion.Begin();
        }

        private void model_click(object sender, RoutedEventArgs e)
        {
            winModel winModel = new winModel();
            winModel.Show();
            this.Close();
        }

        private void security_click(object sender, RoutedEventArgs e)
        {
            winInsurance winInsurance = new winInsurance();
            winInsurance.Show();
            this.Close();
        }

        

        private void miAddUser_Click(object sender, RoutedEventArgs e)
        {
            winUser winUser = new winUser();
            winUser.Show();
            this.Close();
        }

        private void miAddBrand_Click(object sender, RoutedEventArgs e)
        {
            winBrand winBrand = new winBrand();
            winBrand.Show();
            this.Close();
        }

        private void miLogout_Click(object sender, RoutedEventArgs e)
        {
            winLogin winLogin = new winLogin();
            winLogin.Show();
            this.Close();
        }

        private void miChangePassword_Click(object sender, RoutedEventArgs e)
        {
            winChangePassword winChangePassword = new winChangePassword();
            winChangePassword.Show();
            this.Close();
        }

        private void cerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
