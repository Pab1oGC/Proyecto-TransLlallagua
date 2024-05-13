using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using TransLlallaguaDAO.Interfaces;
using TransLlallaguaDAO.Models;

namespace TransLlallaguaDAO.Implementation
{
    public class PassengerImpl : BaseImpl,IPassenger
    {
        public int Delete(Passenger c)
        {
            throw new NotImplementedException();
        }

        public int Insert(Passenger c)
        {
            /*if (c.SecondSurname == null)
            {

            }
                
            SqlCommand cmd = CreateBasicCommand();*/
            return 1;
        }

        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(Passenger c)
        {
            throw new NotImplementedException();
        }
    }
}
