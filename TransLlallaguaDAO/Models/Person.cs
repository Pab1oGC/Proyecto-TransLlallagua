using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Person:BaseModel
    {
        public Person(int id, string name, string surname, string secondSurname, string ci, string email, string phone,byte status,DateTime registerDate,DateTime lastUpdate,int employeeId)
            :base(status,registerDate,lastUpdate,employeeId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            SecondSurname = secondSurname;
            Ci = ci;
            Email = email;
            Phone = phone;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string SecondSurname { get; set; }
        public string Ci { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
