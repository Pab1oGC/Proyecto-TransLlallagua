using System;
using System.Collections.Generic;
using System.Data;
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
using TransLlallaguaDAO.Implementation;
using TransLlallaguaDAO.Models;
using TransLlallaguaWPF.ChangePassword;
using TransLlallaguaWPF.Menus;
using TransLlallaguaWPF.Messages;

namespace TransLlallaguaWPF.Login
{
    /// <summary>
    /// Lógica de interacción para winLogin.xaml
    /// </summary>
    public partial class winLogin : Window
    {
        UserImpl userImpl = new UserImpl();
        SelectWindow select = new SelectWindow();
        Wrong error;
        Success exito;
        public winLogin()
        {
            InitializeComponent();
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click_1(object sender, RoutedEventArgs e)
        {
            DataTable dt = userImpl.Login(txtUsername.Text, pwbPassword.Password);
            if (dt.Rows.Count > 0)
            {
                SessionControl.UserID = short.Parse(dt.Rows[0][0].ToString());
                SessionControl.Username = dt.Rows[0][1].ToString();
                SessionControl.Role = dt.Rows[0][2].ToString();
                SessionControl.StatusLogin = byte.Parse(dt.Rows[0][3].ToString());
                if (SessionControl.StatusLogin == 0)
                {
                    exito = new Success("Por seguridad cambie su contraseña");
                    exito.ShowDialog();
                    winChangePassword winChangePassword = new winChangePassword();
                    winChangePassword.Show();
                    this.Close();
                }
                else
                {
                    Window window = select.GetWindow();
                    window.Show();
                    this.Close();
                }               
            }
            else
            {
                error = new Wrong("Nombre de usuario y/o contraseña incorrecto");
                error.ShowDialog();
            }
        }

        private void txtUsername_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                pwbPassword.Focus();
                pwbPassword.SelectAll();
            }
        }

        private void pwbPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                btnLogin.Focus();
                btnLogin.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }
}
