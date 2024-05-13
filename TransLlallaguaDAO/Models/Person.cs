using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Person:BaseModel
    {
        public Person(int id, string name, string surname, string secondSurname, string ci, string phone, byte status, DateTime registerDate, DateTime lastUpdate, int userId)
            :base(status,registerDate,lastUpdate,userId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            SecondSurname = secondSurname;
            Ci = ci;
            Phone = phone;
        }
        public Person(string name, string surname, string secondSurname, string ci, string phone, int userId)
            : base(userId)
        {
            Name = name;
            Surname = surname;
            SecondSurname = secondSurname;
            Ci = ci;
            Phone = phone;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string Ci { get; set; }
        public string Phone { get; set; }
    }
}
