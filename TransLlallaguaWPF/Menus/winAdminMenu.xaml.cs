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
    }
}
