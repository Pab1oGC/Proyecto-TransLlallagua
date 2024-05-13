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


namespace TransLlallaguaWPF.User
{
    /// <summary>
    /// Lógica de interacción para winUser.xaml
    /// </summary>
    public partial class winUser : Window
    {
        SolidColorBrush colorLbl = new SolidColorBrush();
        UserImpl userImpl = new UserImpl();
        UserR user;
        string username,password;
        byte focus = 0;
        public winUser()
        {
            InitializeComponent();
            btnSave.IsEnabled = false;
            txtUsername.IsEnabled = false;
            btnUpdate.IsEnabled = false;
            Select();
        }

        private void lblPassword_MouseEnter(object sender, MouseEventArgs e)
        {
            colorLbl.Color = Colors.White;
            lblPassword.Background = colorLbl;
        }

        private void lblPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            colorLbl.Color = Colors.Black;
            lblPassword.Background = colorLbl;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                user = new UserR(txtNames.Text.Trim(),
                             txtSurname.Text.Trim(),
                             txtSecondSurname.Text.Trim(),
                             txtCi.Text.Trim(),
                             txtPhone.Text.Trim(),
                             SessionControl.UserID,
                             txtAdress.Text.Trim(),
                             char.Parse(cmbGender.Text),
                             username, password, cmbRole.Text
                             );
                int res = userImpl.Insert(user);
                if (res > 0)
                {
                    Select();
                    MessageBox.Show("Registro insertado con exito");
                    tbControl.SelectedIndex = 1;
                    btnSave.IsEnabled = false;
                }
                else
                    MessageBox.Show("Ningun registro fue insertado");
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(txtNames.Text) && !string.IsNullOrWhiteSpace(txtSurname.Text))
            {
                username = userImpl.CreateUsername(txtSurname.Text, txtNames.Text, 0);
                password = userImpl.CreatePassword();
                txtUsername.Text = username;
                lblPassword.Content = password;
                btnSave.IsEnabled = true;
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
                        txtCi.Text = user.Ci;
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
                user = new UserR(txtNames.Text.Trim(),
                             txtSurname.Text.Trim(),
                             txtSecondSurname.Text.Trim(),
                             txtCi.Text.Trim(),
                             txtPhone.Text.Trim(),
                             SessionControl.UserID,
                             txtAdress.Text.Trim(),
                             char.Parse(cmbGender.Text),
                             username, cmbRole.Text
                             );
                int res = userImpl.Update(user);
                if (res > 0)
                {
                    Select();
                    MessageBox.Show("Registro insertado con exito");
                    tbControl.SelectedIndex = 1;
                    btnSave.IsEnabled = false;
                    btnModify.IsEnabled = false;
                    btnGenerate.IsEnabled = true;
                    txtUsername.IsEnabled = false;
                    lblPassword.IsEnabled = true;
                }
                else
                    MessageBox.Show("Ningun registro fue insertado");
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
                lblPassword.IsEnabled = false;
                tbControl.SelectedIndex = 0;
                btnSave.IsEnabled = false;
                btnUpdate.IsEnabled = true;
                btnGenerate.IsEnabled = false;
                txtUsername.IsEnabled = true;
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Esta realmente seguro de eliminar el registro?", "Eminacion", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (user != null)
                {
                    int n = userImpl.Delete(user);
                    if (n > 0)
                    {
                        Select();
                        MessageBox.Show("Registro eliminado");
                        txtNames.Clear();
                        txtSurname.Clear();
                        txtSecondSurname.Clear();
                        txtCi.Clear();
                        txtAdress.Clear();
                        txtPhone.Clear();
                        txtUsername.Clear();
                        cmbGender.SelectedIndex = -1;
                        cmbRole.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("No se realizarion cambios");
                    }
                }
                else
                {
                    MessageBox.Show("No se seleccionaron registros");
                }
            }
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
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

        void Select()
        {
            try
            {
                dvgData.ItemsSource=null;
                dvgData.ItemsSource = userImpl.Select().DefaultView;
                //dvgData.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
