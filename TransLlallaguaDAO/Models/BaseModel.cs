using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class BaseModel
    {
        public BaseModel(int userId)
        {
            UserId = userId;
        }

        public BaseModel(byte status, DateTime registerDate, DateTime lastUpdate, int userId)
        {
            Status = status;
            RegisterDate = registerDate;
            LastUpdate = lastUpdate;
            UserId = userId;
        }
        public BaseModel() { }
        public byte Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int UserId { get; set; }
    }
}
