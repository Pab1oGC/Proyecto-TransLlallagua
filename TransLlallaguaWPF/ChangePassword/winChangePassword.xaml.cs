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
using TransLlallaguaDAO.Models;
using TransLlallaguaDAO.Utils;
using TransLlallaguaWPF.Login;
using TransLlallaguaWPF.Messages;

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
        Wrong error;
        Success exito;
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
                                exito = new Success("Contraseña actualizada con exito");
                                exito.ShowDialog();
                                winLogin winLogin = new winLogin();
                                winLogin.Show();
                                this.Close();
                            }
                            else
                            {
                                error = new Wrong("No se logro cambiar la contraseña");
                                error.ShowDialog();
                            }
                        }
                        else
                        {
                            error = new Wrong("Las nuevas contraseñas no coinciden");
                            error.ShowDialog();
                            txtNew.Clear();
                            txtRepeat.Clear();
                        }
                    }
                    else
                    {
                        error = new Wrong("La seguridad de la contraseña no cumple con: mínimo 8 caracteres, al menos 1 Mayúsucla, minúscula y carácter especial");
                        error.ShowDialog();
                        txtNew.Clear();
                        txtRepeat.Clear();
                    }
                }
                else
                {
                    error = new Wrong("Contraseña antigua incorrecta");
                    error.ShowDialog();
                    txtOld.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (SessionControl.StatusLogin==0)
            {
                winLogin winLogin=new winLogin();
                winLogin.Show();
                this.Close();
            }
            else
            {
                Window window = select.GetWindow();
                window.Show();
                this.Close();
            }
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
