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
using TransLlallaguaWPF.Login;

namespace TransLlallaguaWPF.ChangePassword
{
    /// <summary>
    /// Lógica de interacción para winChangePassword.xaml
    /// </summary>
    public partial class winChangePassword : Window
    {
        UserImpl userImpl = new UserImpl();
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
                    }
                    else
                        MessageBox.Show("La seguridad de la contraseña es debil: mínimo 8 caracteres, al menos 1 Mayúsucla, minúscula y carácter especial");
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

        }
    }
}
