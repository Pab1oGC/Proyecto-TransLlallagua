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
using TransLlallaguaWPF.Model;
using TransLlallaguaWPF.Insurance;
using TransLlallaguaDAO.Models;
using TransLlallaguaWPF.ChangePassword;
using TransLlallaguaWPF.Login;

namespace TransLlallaguaWPF.Menus
{
    /// <summary>
    /// Lógica de interacción para winCashierMenu.xaml
    /// </summary>
    public partial class winCashierMenu : Window
    {
        public winCashierMenu()
        {
            InitializeComponent();
            miUser.Header=SessionControl.Username;
        }
        private void Close_App_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void animacionCompleta(object sender, EventArgs e)
        {
            // Reinicia la animación cuando haya terminado
            animacion.Seek(TimeSpan.Zero);
            animacion.Begin();
        }

        private void miChange_Click(object sender, RoutedEventArgs e)
        {
            winChangePassword winChangePassword = new winChangePassword();
            winChangePassword.Show();
            this.Close();
        }

        private void miLogout_Click(object sender, RoutedEventArgs e)
        {
            winLogin winLogin = new winLogin();
            winLogin.Show();
            this.Close();
        }
    }
}
