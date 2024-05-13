using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Brand:BaseModel
    {
        public Brand(string name, string quality, string description)
        {
            Name = name;
            Quality = quality;
            Description = description;
        }

        public Brand(byte id, string name, string quality, string description,byte status, DateTime registerDate, DateTime lastUpdate, short userId)
            : base(status, registerDate, lastUpdate, userId)
        {
            Id = id;
            Name = name;
            Quality = quality;
            Description = description;
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Quality { get; set; }
        public string Description { get; set; }
    }
}
