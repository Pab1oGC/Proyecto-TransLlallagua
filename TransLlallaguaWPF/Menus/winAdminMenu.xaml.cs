﻿using System;
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
using TransLlallaguaWPF.Passengers;
using TransLlallaguaWPF.Login;
namespace TransLlallaguaWPF.Menus
{
    /// <summary>
    /// Lógica de interacción para winAdminMenu.xaml
    /// </summary>
    public partial class winAdminMenu : Window
    {
        public winAdminMenu()
        {
            InitializeComponent();
        }
        private void ListViewItem_MouseEnter(object sender, MouseEventArgs e)
        {
            // Set tooltip visibility

            if (Tg_Btn.IsChecked == true)
            {
                tt_home.Visibility = Visibility.Collapsed;
                tt_contacts.Visibility = Visibility.Collapsed;
                tt_messages.Visibility = Visibility.Collapsed;
                tt_maps.Visibility = Visibility.Collapsed;
                tt_settings.Visibility = Visibility.Collapsed;
                tt_signout.Visibility = Visibility.Collapsed;
            }
            else
            {
                tt_home.Visibility = Visibility.Visible;
                tt_contacts.Visibility = Visibility.Visible;
                tt_messages.Visibility = Visibility.Visible;
                tt_maps.Visibility = Visibility.Visible;
                tt_settings.Visibility = Visibility.Visible;
                tt_signout.Visibility = Visibility.Visible;
            }
        }

        private void Tg_Btn_Unchecked(object sender, RoutedEventArgs e)
        {
            //img_bg.Opacity = 1;
        }

        private void Tg_Btn_Checked(object sender, RoutedEventArgs e)
        {
            //img_bg.Opacity = 0.3;
        }

        private void BG_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Tg_Btn.IsChecked = false;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        private void animacionCompleta(object sender, EventArgs e)
        {
            // Reinicia la animación cuando haya terminado
            animacion.Seek(TimeSpan.Zero);
            animacion.Begin();
        }

        private void lvPasajeros_Selected(object sender, RoutedEventArgs e)
        {
            if (Tg_Btn.IsChecked == true)
            {
                winPassengers winPassenger = new winPassengers();
                winPassenger.Show();
                this.Close();
            }
        }

        private void lvSignout_Selected(object sender, RoutedEventArgs e)
        {
            if (Tg_Btn.IsChecked == true)
            {
                winLogin winLogin = new winLogin();
                winLogin.Show();
                this.Close();
            }
        }
    }
}
