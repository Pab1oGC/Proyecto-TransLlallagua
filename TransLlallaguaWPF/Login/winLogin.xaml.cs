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

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            /*User user = new User(txtUsername.Text,txtPassword.Text);
            if (userImpl.Select(user))
            {
                winAdminMenu winAdminMenu = new winAdminMenu();
                winAdminMenu.Show();
                this.Close();
            }*/
        }
    }
}
