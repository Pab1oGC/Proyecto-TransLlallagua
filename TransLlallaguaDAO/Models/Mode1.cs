using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Mode1 : BaseModel
    {

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public short Year { get; set; }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        public Mode1(string name, string model, short year)
        {
            Name = name;
            Brand = model;
            Year = year;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="model"></param>
        /// <param name="year"></param>
        public Mode1(byte id, string name, string model, short year, byte status, DateTime registerDate, DateTime lastUpdate, short userId)
            : base(status, registerDate, lastUpdate, userId)
        {
            Id = id;
            Name = name;
            Brand = model;
            Year = year;
        }
    }
}
