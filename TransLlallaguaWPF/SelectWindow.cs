using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TransLlallaguaDAO.Models;
using TransLlallaguaWPF.Menus;
namespace TransLlallaguaWPF
{
    public class SelectWindow
    {
        public Window GetWindow()
        {
            switch (SessionControl.Role)
            {
                case "ADMINISTRADOR":                   
                    return new winAdminMenu();
                case "CAJERO":
                    return new winCashierMenu();
                case "ENCARGADO DE SUCURSAL":
                    return new winManagerMenu();
                default:
                    return null;
            }
        }
    }
}
