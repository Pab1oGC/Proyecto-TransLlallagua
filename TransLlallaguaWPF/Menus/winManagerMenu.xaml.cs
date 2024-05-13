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
using TransLlallaguaWPF.BrandWin;
using TransLlallaguaWPF.ChangePassword;
using TransLlallaguaWPF.Insurance;
using TransLlallaguaWPF.Login;
using TransLlallaguaWPF.Model;

namespace TransLlallaguaWPF.Menus
{
    /// <summary>
    /// Lógica de interacción para winManagerMenu.xaml
    /// </summary>
    public partial class winManagerMenu : Window
    {
        public winManagerMenu()
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

        private void close_CLick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void miBrand_Click(object sender, RoutedEventArgs e)
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

        private void miChange_Click(object sender, RoutedEventArgs e)
        {
            winChangePassword winChangePassword = new winChangePassword();
            winChangePassword.Show();
            this.Close();
        }
    }
}
