using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Threading;
using TransLlallaguaDAO.Implementation;
using TransLlallaguaDAO.Models;
using TransLlallaguaDAO.Utils;
using TransLlallaguaWPF.Menus;

namespace TransLlallaguaWPF.Model
{
    /// <summary>
    /// Lógica de interacción para winModel.xaml
    /// </summary>
    public partial class winModel : Window
    {
        StringHandling util = new StringHandling();
        ModelImpl modelImpl = new ModelImpl();
        Mode1 c;
        byte typeSave=0;
        Toast toast;
        public winModel()
        {
            InitializeComponent();
            toast = new Toast(ToastLabel);
        }
        private void Validation(object sender, TextCompositionEventArgs e)
        {
            if (util.IsSpecialCharacterNotHyphen(char.Parse(e.Text)))
            {
                e.Handled = true;
            }
        }

        private void ValidationNumber(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(char.Parse(e.Text)) || util.IsSpecialCharacter(char.Parse(e.Text)))
            {
                e.Handled = true;
                toast.ShowToast("SOLO INGRESAR NUMEROS", 2);
            }
        }

        private void txtYear_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DateTime.Now.Year < int.Parse(txtYear.Text) || int.Parse(txtYear.Text) < 1920)
                {
                    txtYear.Clear();
                    MessageBox.Show("Año no valido");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                txtYear.Clear();
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Esta realmente seguro de eliminar el registro?", "Eminacion", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (c != null)
                {
                    int n = modelImpl.Delete(c);
                    if (n > 0)
                    {
                        Select();
                        MessageBox.Show("Registro eliminado");
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
        void Select()
        {
            try
            {
                dgvTable.ItemsSource = null;
                dgvTable.ItemsSource = modelImpl.Select().DefaultView;
                dgvTable.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvTable.Items.Count > 0 && dgvTable.SelectedItem != null)
            {
                c = null;
                DataRowView dataRow = (DataRowView)dgvTable.SelectedItem;
                byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                try
                {
                    c = modelImpl.Get(id);
                    if (c != null)
                    {
                        txtName.Text = c.Name;
                        txtBrand.Text = c.Brand;
                        txtYear.Text = c.Year.ToString();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error en el Get" + ex.Message);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (typeSave == 0)
                {
                    string name = util.DeleteExtraSpaces(txtName.Text.Trim());
                    string brand = util.DeleteExtraSpaces(txtBrand.Text.Trim());
                    short year = short.Parse(txtYear.Text);

                    c = new Mode1(name, brand, year);

                    int n = modelImpl.Insert(c);
                    if (n > 0)
                    {
                        Select();
                        MessageBox.Show("Registro insertado");
                        tbControl.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show("No se insertaron datos");
                    }
                    CleanInputs();
                }
                else
                {
                    string name = util.DeleteExtraSpaces(txtName.Text.Trim());
                    string brand = util.DeleteExtraSpaces(txtBrand.Text.Trim());
                    short year = short.Parse(txtYear.Text);
                    c.Name = name;
                    c.Brand = brand;
                    c.Year = year;
                    int n = modelImpl.Update(c);
                    if (n > 0)
                    {
                        Select();
                        MessageBox.Show("Registro modificado");
                    }
                    else
                    {
                        MessageBox.Show("No se registraron cambios");
                    }
                    typeSave = 0;
                    CleanInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            typeSave = 1;
            tbControl.SelectedIndex = 1;
        }
        void CleanInputs()
        {
            txtName.Clear();
            txtBrand.Clear();
            txtYear.Clear();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {           
            winAdminMenu winAdminMenu = new winAdminMenu();
            winAdminMenu.Show();
            this.Close();
        }
    }
}
