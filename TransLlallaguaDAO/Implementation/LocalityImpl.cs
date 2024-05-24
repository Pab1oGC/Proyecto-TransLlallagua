using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransLlallaguaDAO.Interfaces;

namespace TransLlallaguaDAO.Implementation
{
    public class LocalityImpl : BaseImpl, ILocality
    {
        public DataTable SelectIDName()
        {
            query = @"SELECT L.id, CONCAT(L.name,' - ',D.name) AS Name,L.latitude,L.longitude
                      FROM Locality L
                      INNER JOIN Department D ON D.id=L.departmentId
                      ORDER BY 2";
            SqlCommand cmd = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SelectLocality(byte id)
        {
            query = @"SELECT CONCAT(L.name,' - ',D.name)
                      FROM Locality L
                      INNER JOIN Department D ON D.id=L.departmentId
                      WHERE L.id=@id";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                return ExecuteDataTableCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
