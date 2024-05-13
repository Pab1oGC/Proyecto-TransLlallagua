using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Insuranc:BaseModel
    {
        public Insuranc(string name, double price, string description)
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public Insuranc(byte id, string name, double price, string description,byte status, DateTime registerDate, DateTime lastUpdate, short userId)
            : base(status, registerDate, lastUpdate, userId)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
