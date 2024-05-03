using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Employee:Person
    {
        public string Adress { get; set; }
        public string Photo { get; set; }
        public char Gender { get; set; }
    }
}
