using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using TransLlallaguaDAO.Utils;
using TransLlallaguaWPF.Login;

namespace TransLlallaguaWPF.ChangePassword
{
    /// <summary>
    /// Lógica de interacción para winChangePassword.xaml
    /// </summary>
    public partial class winChangePassword : Window
    {
        UserImpl userImpl = new UserImpl();
        SelectWindow select = new SelectWindow();
        StringHandling util = new StringHandling();
        SolidColorBrush colorLabel;
        public winChangePassword()
        {
            InitializeComponent();
        }

        private void btnChange_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (userImpl.EqualPassword(txtOld.Password))
                {
                    if (userImpl.SecurePassword(txtNew.Password))
                    {
                        if (txtNew.Password == txtRepeat.Password)
                        {
                            int cont = userImpl.UpdatePassword(txtRepeat.Password);
                            if (cont > 0)
                            {
                                MessageBox.Show("Contraseña actualizada con exito");
                                winLogin winLogin = new winLogin();
                                winLogin.Show();
                                this.Close();
                            }
                            else
                                MessageBox.Show("No se logro cambiar la contraseña");
                        }
                        else
                            MessageBox.Show("Las nuevas contraseñas no coinciden");
                    }
                    else
                        MessageBox.Show("La seguridad de la contraseña no cumple con: mínimo 8 caracteres, al menos 1 Mayúsucla, minúscula y carácter especial");
                }
                else
                    MessageBox.Show("Contraseña antigua incorrecta");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window window = select.GetWindow();
            window.Show();
            this.Close();
        }

        private void txtNew_PasswordChanged(object sender, RoutedEventArgs e)
        {
            string password = txtNew.Password;
            string strength = util.GetPasswordStrength(password);
            lblStrong.Content = $"La seguridad de la contraseña es: {strength}";
            switch (strength)
            {
                case "Fuerte":
                    lblStrong.Foreground = Brushes.Green;
                    break;
                case "Media":
                    lblStrong.Foreground = Brushes.Peru;
                    break;
                case "Débil":
                    lblStrong.Foreground= Brushes.Red;
                    break;
            }
        }
        
    }
}
