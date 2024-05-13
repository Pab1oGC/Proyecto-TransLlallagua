using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Bus : BaseModel
    {


        public int Id { get; set; }
        public int Capacity { get; set; }
        public int Soat { get; set; }
        public string LicensePlate { get; set; }
        public int BrandId { get; set; }

        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="soat"></param>
        /// <param name="licensePlate"></param>
        public Bus(int capacity, int soat, string licensePlate)
        {
            Capacity = capacity;
            Soat = soat;
            LicensePlate = licensePlate;
        }
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <param name="capacity"></param>
        /// <param name="soat"></param>
        /// <param name="licensePlate"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="userId"></param>
        /// /// <param name="brandId"></param>
        public Bus(byte id, int capacity, int soat, string licensePlate, byte status, DateTime registerDate, DateTime lastUpdate, short userId, int brandId)
            : base(status, registerDate, lastUpdate, userId)
        {
            Id = id;
            Capacity = capacity;
            Soat = soat;
            LicensePlate = licensePlate;
            BrandId = brandId;
        }
    }
}
