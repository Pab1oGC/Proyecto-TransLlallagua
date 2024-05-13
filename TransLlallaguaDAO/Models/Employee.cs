using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Employee:Person
    {
        public Employee(int id, string name, string surname, string secondSurname, string email, string phone,string adress, char gender ,byte status, DateTime registerDate, DateTime lastUpdate,int userId)
            :base(id,name,surname,secondSurname,email,phone,status,registerDate,lastUpdate,userId)
        {
            Adress = adress;
            Gender = gender;
        }
        public Employee(string name, string surname, string secondSurname, string email, string phone, int userId, string adress, char gender)
            : base(name, surname, secondSurname, email, phone, userId)
        {
            Adress = adress;
            Gender = gender;
        }

        public string Adress { get; set; }
        public char Gender { get; set; }
    }
}
