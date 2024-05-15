using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
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
using System.Windows.Threading;
using TransLlallaguaDAO.Implementation;
using TransLlallaguaDAO.Models;
using TransLlallaguaDAO.Utils;
using TransLlallaguaWPF.Menus;
using TransLlallaguaWPF.Messages;

namespace TransLlallaguaWPF.Insurance
{
    /// <summary>
    /// Lógica de interacción para winInsurance.xaml
    /// </summary>
    public partial class winInsurance : Window
    {
        InsuranceImpl insuranceImpl = new InsuranceImpl();
        Insuranc c;
        byte typeSave = 0;
        StringHandling util = new StringHandling();
        private DispatcherTimer _toastTimer;
        SelectWindow select = new SelectWindow();
        Wrong error;
        Success exito;
        Caution advertencia;
        public winInsurance()
        {
            InitializeComponent();
        }
        void Select()
        {
            try
            {
                dgvTable.ItemsSource = null;
                dgvTable.ItemsSource = insuranceImpl.Select().DefaultView;
                dgvTable.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        void CleanInputs()
        {
            txtName.Clear();
            txtPrice.Clear();
            txtDescription.Clear();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (typeSave == 0)
                {
                    if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text) && !string.IsNullOrWhiteSpace(txtPrice.Text))
                    {
                        string name = util.DeleteExtraSpaces(txtName.Text.Trim());
                        string description = util.DeleteExtraSpaces(txtDescription.Text.Trim());
                        double pri = double.Parse(txtPrice.Text.Trim(), CultureInfo.InvariantCulture);
                        double price = Math.Round(pri, 2);
                        if (price > 0)
                        {
                            c = new Insuranc(name, price, description);

                            int n = insuranceImpl.Insert(c);
                            if (n > 0)
                            {
                                Select();
                                exito = new Success("Insercion con exito");
                                exito.ShowDialog();
                                tbControl.SelectedIndex = 0;
                            }
                            else
                            {
                                error = new Wrong("Ningun registro fue INSERTADO");
                                error.ShowDialog();
                            }
                            CleanInputs();
                        }
                        else
                        {
                            error = new Wrong("Ingrese un precio mayor a cero");
                            error.ShowDialog();
                            txtPrice.Clear();
                        }
                    }
                    else
                    {
                        error = new Wrong("Le falta ingresar campos");
                        error.ShowDialog();
                    }            
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text) && !string.IsNullOrWhiteSpace(txtPrice.Text))
                    {
                        string name = util.DeleteExtraSpaces(txtName.Text.Trim());
                        string description = util.DeleteExtraSpaces(txtDescription.Text.Trim());
                        double pri = double.Parse(txtPrice.Text.Trim(), CultureInfo.InvariantCulture);
                        double price = Math.Round(pri, 2);
                        c.Name = name;
                        c.Description = description;
                        c.Price = price;
                        int n = insuranceImpl.Update(c);
                        if (n > 0)
                        {
                            Select();
                            exito = new Success("Registro ACTUALIZADO con exito");
                            exito.ShowDialog();
                        }
                        else
                        {
                            error = new Wrong("Ningun registro fue ACTUALIZADO");
                            error.ShowDialog();
                        }
                        typeSave = 0;
                        CleanInputs();
                    }
                    else
                    {
                        error = new Wrong("Le falta ingresar campos");
                        error.ShowDialog();
                    }
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

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            advertencia = new Caution("¿Esta realmente seguro de eliminar el registro?");
            advertencia.ShowDialog();
            if (advertencia.IsConfirmed)
            {
                if (c != null)
                {
                    int n = insuranceImpl.Delete(c);
                    if (n > 0)
                    {
                        Select();
                        exito = new Success("Registro eliminado");
                        exito.ShowDialog();
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

        private void dgvTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvTable.Items.Count > 0 && dgvTable.SelectedItem != null)
            {
                c = null;
                DataRowView dataRow = (DataRowView)dgvTable.SelectedItem;
                byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                try
                {
                    c = insuranceImpl.Get(id);
                    if (c != null)
                    {
                        txtName.Text = c.Name;
                        txtPrice.Text = c.Price.ToString();
                        txtDescription.Text = c.Description;
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error en el Get" + ex.Message);
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
        }

        private void txtName_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsLetter(char.Parse(e.Text)))
            {
                e.Handled = true;
                ShowToast("SOLO INGRESAR LETRAS", 2);
            }
        }

        private void txtPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!util.IsSpecialCharacterNotPoint(char.Parse(e.Text)))
            {
                e.Handled = true;
                ShowToast("FORMATO INVALIDO DE PRECIO", 2);
            }
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window window = select.GetWindow();
            window.Show();
            this.Close();
        }
        private void ShowToast(string message, int durationSeconds)
        {
            ToastLabel.Content = message;
            ToastLabel.Visibility = Visibility.Visible;
            _toastTimer = new DispatcherTimer();
            _toastTimer.Interval = TimeSpan.FromSeconds(durationSeconds);
            _toastTimer.Tick += ToastTimer_Tick;
            _toastTimer.Start();
        }
        private void ToastTimer_Tick(object sender, EventArgs e)
        {
            _toastTimer.Stop();
            ToastLabel.Visibility = Visibility.Collapsed;
        }
    }
}
