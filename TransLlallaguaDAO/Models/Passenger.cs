using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Passenger
    {
        public Passenger(string nit, string corporateName, int id, string name, string surname, string secondSurname, string ci, string email, string phone, byte status, DateTime registerDate, DateTime lastUpdate, int employeeId)
            //:base(id,name,surname,secondSurname,ci,email,phone,status, registerDate, lastUpdate, employeeId)
        {
            Nit = nit;
            CorporateName = corporateName;
        }

        public string Nit { get; set; }
        public string CorporateName { get; set; }
    }
}
