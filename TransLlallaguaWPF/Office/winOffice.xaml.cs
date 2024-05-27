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
using TransLlallaguaDAO.Utils;
using TransLlallaguaDAO.Models;
using TransLlallaguaWPF.Messages;
using Microsoft.Maps.MapControl.WPF;
using Microsoft.Win32;
using System.IO;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Xml.Linq;
namespace TransLlallaguaWPF.Office
{
    /// <summary>
    /// Lógica de interacción para winOffice.xaml
    /// </summary>
    public partial class winOffice : Window
    {
        Toast toast,toast2;
        OfficeImpl officeImpl = new OfficeImpl();
        SelectWindow select = new SelectWindow();
        byte focus = 0;
        Off1ce office;
        Wrong error;
        Success exito;
        Caution advertencia;
        StringHandling util = new StringHandling();
        Location location = new Location();
        Pushpin pin = new Pushpin();
        string rutaImagen;
        BitmapImage bitmap;
        string search="";
        FilterInfoCollection devices;
        VideoCaptureDevice videoSource;
        Bitmap imagenCapturada = null;
        string photoPath = "";
        byte updatePhoto = 0;
        public winOffice()
        {
            InitializeComponent();
            StartCamera();
            toast = new Toast(lblToast);
            toast2 = new Toast(lblToast2);
        }
        void StartCamera()
        {
            devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (devices.Count == 0)
            {
                error = new Wrong("No se encontraron cámaras disponibles");
                error.ShowDialog();
            }
            else
            {
                videoSource = new VideoCaptureDevice(devices[0].MonikerString);
                videoSource.NewFrame += new NewFrameEventHandler(CapturarFrame);
                videoSource.Start();
            }
            
        }
        private void CapturarFrame(object sender, NewFrameEventArgs eventArgs)
        {
            imagenCapturada = (Bitmap)eventArgs.Frame.Clone();
            BitmapImage bitmapImage = BitmapToBitmapImage(imagenCapturada);

            if (imgPreviewPhoto.Dispatcher.CheckAccess())
            {
                imgPreviewPhoto.Source = bitmapImage;
            }
            else
            {
                imgPreviewPhoto.Dispatcher.Invoke(() =>
                {
                    imgPreviewPhoto.Source = bitmapImage;
                });
            }
        }
        private BitmapImage BitmapToBitmapImage(Bitmap bitmap)
        {
            BitmapImage bitmapImage = null;

            Dispatcher.Invoke(() =>
            {
                using (var memory = new System.IO.MemoryStream())
                {
                    bitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Bmp);
                    memory.Position = 0;

                    bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memory;
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.EndInit();
                }
            });

            return bitmapImage;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtAdress.Text) && !string.IsNullOrWhiteSpace(txtPhone.Text) && location.Longitude!=0 && location.Latitude!=0 && rutaImagen!=null && imgFinalPhoto.Source!=null)
                {
                    string name = util.DeleteExtraSpaces(txtName.Text.Trim());
                    string adress = util.DeleteExtraSpaces(txtAdress.Text.Trim());
                    string path = SaveImage(util.StringWithoutSpaces(name));
                    office = new Off1ce(name, adress, location.Latitude, location.Longitude, txtPhone.Text, path,photoPath,byte.Parse(cmbLocality.SelectedValue.ToString()), short.Parse(cmbManager.SelectedValue.ToString()));
                    int res = officeImpl.Insert(office);
                    if (res > 0)
                    {
                        exito = new Success("Registro INSERTADO con éxito");
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
                    if(string.IsNullOrWhiteSpace(txtName.Text))
                        lblObName.Visibility = Visibility.Visible;
                    if(string.IsNullOrWhiteSpace(txtPhone.Text))
                        lblObPhone.Visibility = Visibility.Visible;
                    if(string.IsNullOrWhiteSpace(txtAdress.Text))
                        lblObAdress.Visibility = Visibility.Visible;
                    if (location.Longitude == 0 || location.Latitude == 0)
                        toast.ShowToast("INGRESE UNA UBICACION VALIDA EN EL MAPA", 6);
                    if (rutaImagen == null)
                        toast.ShowToast("DEBE CARGAR UNA IMAGEN", 6);
                    if(imgFinalPhoto.Source==null)
                        toast.ShowToast("DEBE TOMAR UNA FOTO", 6);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (videoSource != null && videoSource.IsRunning)
            {
                await StopVideoSourceAsync();
            }
            Window window = select.GetWindow();
            window.Show();
            this.Close();
        }
        private Task StopVideoSourceAsync()
        {
            return Task.Run(() =>
            {
                videoSource.SignalToStop();
                videoSource.WaitForStop();
                videoSource.NewFrame -= new NewFrameEventHandler(CapturarFrame);
                videoSource = null;
            });
        }
        void Select()
        {
            try
            {
                dvgData.ItemsSource = null;
                dvgData.ItemsSource = officeImpl.Select().DefaultView;
                dvgData.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Select();
            LoadComboBoxManager();
            LoadComboBoxLocality();
            txtName.Focus();
            btnUpdate.IsEnabled = false;
        }

        private void dvgData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dvgData.Items.Count > 0 && dvgData.SelectedItem != null)
            {
                focus = 1;
                office = null;
                DataRowView dataRow = (DataRowView)dvgData.SelectedItem;
                byte id = byte.Parse(dataRow.Row.ItemArray[0].ToString());
                try
                {
                    office = officeImpl.Get(id);
                    if (office != null)
                    {
                        txtName.Text = office.Name;
                        txtAdress.Text = office.Adress;
                        txtPhone.Text = office.Phone;
                        cmbLocality.SelectedValue = office.LocalityId;
                        cmbManager.SelectedValue = office.ManagerId;
                        location.Longitude = office.Longitude;
                        location.Latitude = office.Latitude;
                        rutaImagen = office.Image;
                        bitmap = new BitmapImage(new Uri(rutaImagen, UriKind.RelativeOrAbsolute));
                        imgPhoto.Source = bitmap;
                        imgFinalPhoto.Source = new BitmapImage(new Uri(office.Photo, UriKind.RelativeOrAbsolute));
                        pin.Location = location;
                        map.Center = location;
                        map.Children.Clear();
                        map.Children.Add(pin);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error en el Get" + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text) && !string.IsNullOrWhiteSpace(txtAdress.Text) && !string.IsNullOrWhiteSpace(txtPhone.Text) && location.Longitude != 0 && location.Latitude != 0 && rutaImagen!=null && imgFinalPhoto.Source!=null)
                {
                    office.Name = util.DeleteExtraSpaces(txtName.Text.Trim());
                    office.Adress = util.DeleteExtraSpaces(txtAdress.Text.Trim());
                    office.Phone = txtPhone.Text;
                    office.Latitude = location.Latitude;
                    office.Longitude = location.Longitude;
                    office.LocalityId = byte.Parse(cmbLocality.SelectedValue.ToString());
                    office.ManagerId = short.Parse(cmbManager.SelectedValue.ToString());
                    if (rutaImagen != office.Image)
                    {
                        string path = UpdateImageUpload(util.StringWithoutSpaces(office.Name));
                        office.Image = path;
                    }
                    else
                    {
                        office.Image = rutaImagen;
                    }
                    office.Photo=photoPath;
                    
                    int res = officeImpl.Update(office);
                    if (res > 0)
                    {
                        Select();
                        exito = new Success("Registro ACTUALIZADO con exito");
                        exito.ShowDialog();
                        tbControl.SelectedIndex = 0;
                        btnRegister.IsEnabled = true;
                        btnUpdate.IsEnabled = false;
                        updatePhoto = 0;
                    }
                    else
                    {
                        error = new Wrong("Ningun registro fue ACTUALIZADO");
                        error.ShowDialog();
                    }

                }
                else
                {
                    if (string.IsNullOrWhiteSpace(txtName.Text))
                        lblObName.Visibility = Visibility.Visible;
                    if (string.IsNullOrWhiteSpace(txtPhone.Text))
                        lblObPhone.Visibility = Visibility.Visible;
                    if (string.IsNullOrWhiteSpace(txtAdress.Text))
                        lblObAdress.Visibility = Visibility.Visible;
                    if (location.Longitude == 0 || location.Latitude == 0)
                        toast.ShowToast("INGRESE UNA UBICACION VALIDA EN EL MAPA", 6);
                    if (rutaImagen == null)
                        toast.ShowToast("DEBE CARGAR UNA IMAGEN", 6);
                    if (imgFinalPhoto.Source == null)
                        toast.ShowToast("DEBE TOMAR UNA FOTO", 6);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnModify_Click(object sender, RoutedEventArgs e)
        {
            updatePhoto = 1;
            if (focus == 1)
            {
                tbControl.SelectedIndex = 1;
                btnRegister.IsEnabled = false;
                btnUpdate.IsEnabled = true;
            }
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            advertencia = new Caution("¿Esta realmente seguro de eliminar el registro?");
            advertencia.ShowDialog();
            if (advertencia.IsConfirmed)
            {
                if (office != null)
                {
                    int n = officeImpl.Delete(office);
                    if (n > 0)
                    {
                        Select();
                        exito = new Success("Registro eliminado");
                        exito.ShowDialog();
                        txtName.Clear();
                        txtAdress.Clear();
                        txtPhone.Clear();
                        cmbLocality.SelectedIndex = 0;
                        cmbManager.SelectedIndex = 0;
                        imgPhoto.Source = null;
                        rutaImagen = null;
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

        private void txtName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
                lblObName.Visibility = Visibility.Hidden;
            else
                lblObName.Visibility = Visibility.Visible;
        }

        private void txtPhone_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                lblObPhone.Visibility = Visibility.Hidden;
                if (!util.ValidationLandlinePhone(txtPhone.Text))
                {
                    txtPhone.Clear();
                    toast.ShowToast("INGRESE UN NUMERO DE TELEFONO FIJO VALIDO",6);
                }
            }
            else
                lblObPhone.Visibility = Visibility.Visible;
        }

        private void txtAdress_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAdress.Text))
                lblObAdress.Visibility = Visibility.Hidden;
            else
                lblObAdress.Visibility = Visibility.Visible;
        }

        private void txtPhone_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(char.Parse(e.Text)))
            {
                e.Handled = true;
                toast.ShowToast("SOLO SE PUEDE INGRESAR NUMEROS", 6);
            }
        }
        void LoadComboBoxLocality()
        {
            try
            {
                LocalityImpl localityImpl = new LocalityImpl();
                DataTable table = localityImpl.SelectIDName();
                cmbLocality.ItemsSource = null;
                cmbLocality.ItemsSource = table.DefaultView;
                cmbLocality.DisplayMemberPath = "Name";
                cmbLocality.SelectedValuePath = "id";
                cmbLocality.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        void LoadComboBoxManager()
        {
            try
            {
                UserImpl userImpl = new UserImpl();
                DataTable table = userImpl.SelectIDName();
                cmbManager.ItemsSource = null;
                cmbManager.ItemsSource = table.DefaultView;
                cmbManager.DisplayMemberPath = "Name";
                cmbManager.SelectedValuePath = "id";
                cmbManager.SelectedIndex = 0;
                ShowLocation();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void map_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
            var mouseClick = e.GetPosition((UIElement)sender);
            location = map.ViewportPointToLocation(mouseClick);
            pin.Location = location;
            map.Children.Clear();
            map.Children.Add(pin);
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            map.ZoomLevel++;
        }

        private void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            map.ZoomLevel--;
        }

        private void cmbLocality_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowLocation();
        }
        void ShowLocation()
        {
            if (cmbLocality.SelectedItem is DataRowView selectedRow)
            {
                double latitude = (double)selectedRow["latitude"];
                double longitude = (double)selectedRow["longitude"];
                Location location = new Location(latitude, longitude);
                map.Center = location;
            }
        }

        private void btnSpacial_Click(object sender, RoutedEventArgs e)
        {
            map.Focus();
            map.Mode = new AerialMode(true);
        }

        private void btnStreet_Click(object sender, RoutedEventArgs e)
        {
            map.Focus();
            map.Mode = new RoadMode();
        }

        private void btnUploadImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";
            openFileDialog.InitialDirectory = @"C:\imagenesTransLlallagua";
            if (openFileDialog.ShowDialog() == true)
            {
                rutaImagen = openFileDialog.FileName;
                bitmap = new BitmapImage(new Uri(rutaImagen,UriKind.RelativeOrAbsolute));
                imgPhoto.Source = bitmap;
            }
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            if (office != null)
            {
                winOfficeInformation info = new winOfficeInformation(office);
                info.ShowDialog();
            }
            else
                toast2.ShowToast("DEBE SELECCIONAR UN REGISTRO PARA MOSTRAR SU INFORMACION", 6);
        }
        private string SaveImage(string name)
        {
            string principalDirectory = @"C:\imagenesGuardadasTransLlallagua";
            string imagesDirectory = @"C:\imagenesGuardadasTransLlallagua\imagenesCargadas";
            string destination = "";
            try
            {
                if (!Directory.Exists(principalDirectory))
                {
                    Directory.CreateDirectory(principalDirectory);
                    Directory.CreateDirectory(imagesDirectory);
                }
                else
                {
                    if (!Directory.Exists(imagesDirectory))
                    {
                        Directory.CreateDirectory(imagesDirectory);
                    }
                }
                if (!officeImpl.FirstRegister())
                {
                    destination = $"{imagesDirectory}\\1{name}1.png";
                }
                else
                {
                    byte id = officeImpl.ScalarId();
                    destination = $"{imagesDirectory}\\{id + 1}{name}1.png";
                }
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                using (FileStream fileStream = new FileStream(destination, FileMode.Create))
                {
                    encoder.Save(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return destination;
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            search = textBox.Text;
            try
            {
                dvgData.ItemsSource = null;
                dvgData.ItemsSource = officeImpl.SelectFilter(search).DefaultView;
                dvgData.Columns[0].Visibility = Visibility.Collapsed;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string UpdateImageUpload(string name)
        {
            string destination = "";
            try
            {
                DataTable dt = officeImpl.UpdateImg(office.Id);
                string originalPath = dt.Rows[0][0].ToString();
                int idNuevo = int.Parse(originalPath.Substring(originalPath.Length - 5, 1));
                string imagesDirectory = @"C:\imagenesGuardadasTransLlallagua\imagenesCargadas";
                destination = $"{imagesDirectory}\\{office.Id}{name}{idNuevo + 1}.png";
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmap));
                using (FileStream fileStream = new FileStream(destination, FileMode.Create))
                {
                    encoder.Save(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return destination;
        }
        private void UpdatePhotoUpload()
        {
            try
            {
                DataTable dt = officeImpl.UpdatePhoto(office.Id);
                string originalPath = dt.Rows[0][0].ToString();
                int idNuevo = int.Parse(originalPath.Substring(originalPath.Length - 5, 1));
                string imagesDirectory = @"C:\imagenesGuardadasTransLlallagua\fotosTomadas";
                photoPath = $"{imagesDirectory}\\{office.Id}Foto{idNuevo + 1}.png";
                imagenCapturada.Save(photoPath, System.Drawing.Imaging.ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnPhoto_Click(object sender, RoutedEventArgs e)
        {
            if (videoSource.IsRunning)
            {
                if (imagenCapturada != null)
                {
                    if (updatePhoto == 1)
                    {
                        UpdatePhotoUpload();
                    }
                    else
                    {
                        GuardarImagen(imagenCapturada);
                    }
                    imgFinalPhoto.Source = BitmapToBitmapImage(imagenCapturada);
                }
            }
            else
            {
                error = new Wrong("La cámara no esta funcionamiento");
            }
        }

        private void GuardarImagen(Bitmap imagen)
        {
            try
            {
                string principalDirectory = @"C:\imagenesGuardadasTransLlallagua";
                string photosDirectory = @"C:\imagenesGuardadasTransLlallagua\fotosTomadas";
                if (!Directory.Exists(principalDirectory))
                {
                    Directory.CreateDirectory(principalDirectory);
                    Directory.CreateDirectory(photosDirectory);
                }
                else
                {
                    if (!Directory.Exists(photosDirectory))
                    {
                        Directory.CreateDirectory(photosDirectory);
                    }
                }
                byte id = officeImpl.ScalarId();
                if (imagen != null)
                {
                    photoPath = $"{photosDirectory}\\{id + 1}Foto1.png";
                    imagen.Save(photoPath, System.Drawing.Imaging.ImageFormat.Png);
                }
                else
                {
                    MessageBox.Show("La imagen para guardar es nula.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la imagen: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


    }
}
