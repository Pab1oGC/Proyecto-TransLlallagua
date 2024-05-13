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
using TransLlallaguaWPF.Menus;

namespace TransLlallaguaWPF.Login
{
    /// <summary>
    /// Lógica de interacción para winLogin.xaml
    /// </summary>
    public partial class winLogin : Window
    {
        UserImpl userImpl = new UserImpl();
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
                SessionControl.Password = dt.Rows[0][3].ToString();
                switch (SessionControl.Role)
                {
                    case "ADMINISTRADOR":
                        winAdminMenu winAdminMenu = new winAdminMenu();
                        winAdminMenu.Show();
                        this.Close();
                        break;
                    case "CAJERO":
                        winEmployeeMenu winEmployeeMenu = new winEmployeeMenu();
                        winEmployeeMenu.Show();
                        this.Close();
                        break;
                    case "ENCARGADO SUCURSAL":
                        winManager winManager = new winManager();
                        winManager.Show();
                        this.Close();
                        break;
                }
            }
            else
                MessageBox.Show("Nombre de usuario y/o contraseña incorrecto", "CONTRASEÑA", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
