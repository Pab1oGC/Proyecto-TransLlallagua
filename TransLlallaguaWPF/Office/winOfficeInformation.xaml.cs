using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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

namespace TransLlallaguaWPF.Office
{
    /// <summary>
    /// Lógica de interacción para winOfficeInformation.xaml
    /// </summary>
    public partial class winOfficeInformation : Window
    {
        Off1ce c;
        LocalityImpl localityImpl = new LocalityImpl();
        UserImpl userImpl = new UserImpl();
        public winOfficeInformation(Off1ce oficina)
        {
            InitializeComponent();
            c = oficina;
            ViewInformation();
        }
        void ViewInformation()
        {
            lblName.Content=c.Name;
            lblAddress.Content=c.Adress;
            lblPhone.Content = c.Phone;
            imgLocation.Source = new BitmapImage(new Uri(c.Image,UriKind.RelativeOrAbsolute));
            Location location = new Location(c.Latitude, c.Longitude);
            Pushpin pin = new Pushpin();
            pin.Location = location;
            map.Children.Add(pin);
            map.Center = location;
            DataTable dt = localityImpl.SelectLocality(c.LocalityId);
            DataTable dtM = userImpl.SelectManager(c.ManagerId);
            lblLocation.Content = dt.Rows[0][0].ToString();
            lblCharge.Content = dtM.Rows[0][0].ToString();
        }

        private void btnBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            map.ZoomLevel++;
        }

        private void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            map.ZoomLevel--;
        }
    }
}
