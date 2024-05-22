using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Locality
    {
        public Locality(byte id, string name)
        {
            Id = id;
            Name = name;
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public byte DepartmentId { get; set; }
    }
}
