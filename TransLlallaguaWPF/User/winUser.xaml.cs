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
using TransLlallaguaDAO.Utils;
using TransLlallaguaWPF.Menus;
using TransLlallaguaWPF.Messages;


namespace TransLlallaguaWPF.User
{
    /// <summary>
    /// Lógica de interacción para winUser.xaml
    /// </summary>
    public partial class winUser : Window
    {
        UserImpl userImpl = new UserImpl();
        UserR user;
        string username,password;
        byte focus = 0;
        SelectWindow select = new SelectWindow();
        StringHandling util = new StringHandling();
        Toast toast;
        Wrong error;
        Success exito;
        Caution advertencia;
        public winUser()
        {
            InitializeComponent();
            btnSave.IsEnabled = true;
            txtUsername.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            toast = new Toast(lblToast);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtNames.Text) && !string.IsNullOrWhiteSpace(txtSurname.Text) &&
                    !string.IsNullOrWhiteSpace(txtEmail.Text) && !string.IsNullOrWhiteSpace(txtAdress.Text) && !string.IsNullOrWhiteSpace(txtPhone.Text) && 
                    cmbRole.SelectedIndex!=-1 && cmbGender.SelectedIndex!=-1)
                {
                    string names = util.DeleteExtraSpaces(txtNames.Text.Trim());
                    string surname = util.DeleteExtraSpaces(txtSurname.Text.Trim());
                    string secondSurname = util.DeleteExtraSpaces(txtSecondSurname.Text.Trim());
                    string email = util.StringWithoutSpaces(txtEmail.Text.Trim());
                    string adress = util.DeleteExtraSpaces(txtAdress.Text.Trim());
                    username = userImpl.CreateUsername(util.StringWithoutSpaces(txtSurname.Text), util.StringWithoutSpaces(txtNames.Text), 0);
                    password = userImpl.CreatePassword();
                    user = new UserR(names,
                                     surname,
                                     secondSurname,
                                     email,
                                     txtPhone.Text.Trim(),
                                     SessionControl.UserID,
                                     adress,
                                     char.Parse(cmbGender.Text),
                                     username, password, cmbRole.Text
                                     );
                    int res = userImpl.Insert(user);
                    if (res > 0)
                    {       
                        userImpl.SendEmail(email, username, password);
                        exito = new Success("Insercion con exito");
                        exito.ShowDialog();
                        tbControl.SelectedIndex = 0;
                        Select();
                    }
                    else
                    {
                        error = new Wrong("Ningun registro fue INSERTADO");
                        error.ShowDialog();
                    }
                }
                else
                {
                    error = new Wrong("Le falta ingresar campos");
                    error.ShowDialog();
                }
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void dvgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dvgData.Items.Count > 0 && dvgData.SelectedItem != null)
            {
                focus = 1;
                user = null;
                DataRowView dataRow = (DataRowView)dvgData.SelectedItem;
                byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                try
                {
                    user = userImpl.Get(id);
                    if (user != null)
                    {
                        txtNames.Text = user.Name;
                        txtSurname.Text = user.Surname;
                        txtSecondSurname.Text = user.SecondSurname;
                        txtEmail.Text = user.Email;
                        txtAdress.Text = user.Adress;
                        cmbGender.Text = user.Gender.ToString();
                        txtPhone.Text = user.Phone;
                        cmbRole.Text = user.Role;
                        txtUsername.Text = user.Username;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error en el Get" + ex.Message);
                }
            }              
        }


        private void btnUpdate_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtNames.Text) && !string.IsNullOrWhiteSpace(txtSurname.Text) &&
                   !string.IsNullOrWhiteSpace(txtEmail.Text) && !string.IsNullOrWhiteSpace(txtAdress.Text) && !string.IsNullOrWhiteSpace(txtPhone.Text) &&
                   cmbRole.SelectedIndex != -1 && cmbGender.SelectedIndex != -1)
                {
                    user.Name = util.DeleteExtraSpaces(txtNames.Text.Trim());
                    user.Surname = util.DeleteExtraSpaces(txtSurname.Text.Trim());
                    user.SecondSurname = util.DeleteExtraSpaces(txtSecondSurname.Text.Trim());
                    user.Email = util.StringWithoutSpaces(txtEmail.Text.Trim());
                    user.Adress = util.DeleteExtraSpaces(txtAdress.Text.Trim());
                    user.Phone = util.StringWithoutSpaces(txtPhone.Text);
                    user.Gender = char.Parse(cmbGender.Text);
                    user.Role = cmbRole.Text;
                    username = util.StringWithoutSpaces(txtUsername.Text);
                    if (userImpl.ExistsUsernameUpdate(username, user.Id))
                    {
                        error = new Wrong("Ingrese otro nombre de usuario");
                        error.ShowDialog();
                        txtUsername.Clear();
                    }
                    else
                    {
                        int res = userImpl.Update(user);
                        if (res > 0)
                        {
                            Select();
                            exito = new Success("Registro ACTUALIZADO con exito");
                            exito.ShowDialog();
                            tbControl.SelectedIndex = 0;
                            btnSave.IsEnabled = true;
                            btnUpdate.IsEnabled = false;
                            txtUsername.IsEnabled = false;
                        }
                        else
                        {
                            error = new Wrong("Ningun registro fue ACTUALIZADO");
                            error.ShowDialog();
                        }
                    }                 
                }
                else
                {
                    error = new Wrong("Le falta ingresar campos");
                    error.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (focus == 1)
            {
                tbControl.SelectedIndex = 1;
                btnSave.IsEnabled = false;
                btnUpdate.IsEnabled = true;
                txtUsername.IsEnabled = true;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            advertencia = new Caution("¿Esta realmente seguro de eliminar el registro?");
            advertencia.ShowDialog();
            if (advertencia.IsConfirmed)
            {
                if (user != null)
                {
                    int n = userImpl.Delete(user);
                    if (n > 0)
                    {
                        Select();
                        exito = new Success("Registro eliminado");
                        exito.ShowDialog();
                        txtNames.Clear();
                        txtSurname.Clear();
                        txtSecondSurname.Clear();
                        txtEmail.Clear();
                        txtAdress.Clear();
                        txtPhone.Clear();
                        txtUsername.Clear();
                        cmbGender.SelectedItem = null;
                        cmbRole.SelectedItem = null;
                    }
                    else
                    {
                        error = new Wrong("No se realizarion cambios");
                        error.ShowDialog();
                    }
                }
                else
                {
                    error = new Wrong("No se seleccionaron registros");
                    error.ShowDialog();
                }
            }
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window window = select.GetWindow();
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void LetterValidation(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(char.Parse(e.Text)))
            {
                e.Handled = true;
                toast.ShowToast("SOLO SE PUEDE INGRESAR LETRAS", 2);
            }
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(char.Parse(e.Text)))
            {
                e.Handled = true;
                toast.ShowToast("SOLO SE PUEDE INGRESAR NUMEROS", 2);
            }
        }

        private void txtPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            string phone = util.StringWithoutSpaces(txtPhone.Text);
            if (phone.Length != 8)
            {
                toast.ShowToast("INGRESE UN NUMERO DE CELULAR VALIDO", 2);
                txtPhone.Clear();
            }
        }

        private void txtEmail_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!util.ValidationEmail(txtEmail.Text))
            {
                toast.ShowToast("INGRESE UN CORREO ELECTRONICO VALIDO", 2);
                txtEmail.Clear();
            }
        }

        void Select()
        {
            try
            {
                dvgData.ItemsSource=null;
                dvgData.ItemsSource = userImpl.Select().DefaultView;
                dvgData.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
