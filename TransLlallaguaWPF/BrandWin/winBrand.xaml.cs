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
using TransLlallaguaWPF.Messages;

namespace TransLlallaguaWPF.BrandWin
{
    /// <summary>
    /// Lógica de interacción para winBrand.xaml
    /// </summary>
    public partial class winBrand : Window
    {
        BrandImpl brandImpl = new BrandImpl();
        Brand c;
        byte typeSave = 0;
        StringHandling util = new StringHandling();
        SelectWindow select = new SelectWindow();
        Wrong error;
        Success exito;
        Caution advertencia;
        public winBrand()
        {
            InitializeComponent();
        }
        void Select()
        {
            try
            {
                dgvTable.ItemsSource = null;
                dgvTable.ItemsSource = brandImpl.Select().DefaultView;
                dgvTable.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                error = new Wrong(ex.Message);
                error.ShowDialog();
            }
        }
        void CleanInputs()
        {
            txtName.Clear();
            cmbQuality.SelectedItem = null;
            txtDescription.Clear();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (typeSave == 0)
                {
                    if (!string.IsNullOrWhiteSpace(txtName.Text)&&!string.IsNullOrWhiteSpace(txtDescription.Text)&&cmbQuality.SelectedIndex!=-1)
                    {
                        string name = util.DeleteExtraSpaces(txtName.Text.Trim());
                        string description = util.DeleteExtraSpaces(txtDescription.Text.Trim());

                        c = new Brand(name, cmbQuality.Text, description);

                        int n = brandImpl.Insert(c);
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
                        error = new Wrong("Le falta ingresar campos");
                        error.ShowDialog();
                    }       
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtDescription.Text) && cmbQuality.SelectedIndex != -1)
                    {
                        string name = util.DeleteExtraSpaces(txtName.Text.Trim());
                        string description = util.DeleteExtraSpaces(txtDescription.Text.Trim());
                        c.Name = name;
                        c.Description = description;
                        c.Quality = cmbQuality.Text;
                        int n = brandImpl.Update(c);
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
                    int n = brandImpl.Delete(c);
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
                    c = brandImpl.Get(id);
                    if (c != null)
                    {
                        txtName.Text = c.Name;
                        cmbQuality.Text = c.Quality;
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

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Window window = select.GetWindow();
            window.Show();
            this.Close();
        }
        
    }
}
