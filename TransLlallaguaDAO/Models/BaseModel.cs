﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class BaseModel
    {
        public BaseModel(byte status, DateTime registerDate, DateTime lastUpdate, int employeeId)
        {
            Status = status;
            RegisterDate = registerDate;
            LastUpdate = lastUpdate;
            EmployeeId = employeeId;
        }

        public byte Status { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime LastUpdate { get; set; }
        public int EmployeeId { get; set; }
    }
}