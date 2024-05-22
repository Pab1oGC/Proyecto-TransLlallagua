using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class Off1ce:BaseModel
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="name"></param>
        /// <param name="adress"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="phone"></param>
        /// <param name="localityId"></param>
        /// <param name="managerId"></param>
        public Off1ce(string name, string adress, double latitude, double longitude, string phone, byte localityId, short managerId)
        {
            Name = name;
            Adress = adress;
            Latitude = latitude;
            Longitude = longitude;
            Phone = phone;
            LocalityId = localityId;
            ManagerId = managerId;
        }
        /// <summary>
        /// Select,Update,Delete
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="adress"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="phone"></param>
        /// <param name="localityId"></param>
        /// <param name="managerId"></param>
        /// <param name="status"></param>
        /// <param name="registerDate"></param>
        /// <param name="lastUpdate"></param>
        /// <param name="userId"></param>
        public Off1ce(byte id, string name, string adress, double latitude, double longitude, string phone, byte localityId, short managerId, byte status, DateTime registerDate, DateTime lastUpdate, int userId)
            :base(status,registerDate,lastUpdate,userId)
        {
            Id = id;
            Name = name;
            Adress = adress;
            Latitude = latitude;
            Longitude = longitude;
            Phone = phone;
            LocalityId = localityId;
            ManagerId = managerId;
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Phone { get; set; }
        public byte LocalityId { get; set; }
        public short ManagerId { get; set; }
    }
}
