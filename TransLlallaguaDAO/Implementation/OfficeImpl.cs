using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransLlallaguaDAO.Interfaces;
using TransLlallaguaDAO.Models;

namespace TransLlallaguaDAO.Implementation
{
    public class OfficeImpl : BaseImpl, IOffice
    {
        public int Delete(Off1ce c)
        {
            query = @"UPDATE Office SET status=0,lastUpdate=CURRENT_TIMESTAMP, userId=@userId
                      WHERE id=@id";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("@id", c.Id);
            cmd.Parameters.AddWithValue("@userId", SessionControl.UserID);
            try
            {
                return ExecuteBasicCommand(cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Off1ce Get(byte id)
        {
            Off1ce c = null;
            query = @"SELECT id,name,adress,latitude,longitude,phone,localityId,managerId,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP),userId
                      FROM Office
                      WHERE id=@id";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(cmd);
                if (table.Rows.Count > 0)
                {
                    c = new Off1ce(byte.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), double.Parse(table.Rows[0][3].ToString()),
                                   double.Parse(table.Rows[0][4].ToString()), table.Rows[0][5].ToString(), byte.Parse(table.Rows[0][6].ToString()), short.Parse(table.Rows[0][7].ToString()),
                                   byte.Parse(table.Rows[0][8].ToString()), DateTime.Parse(table.Rows[0][9].ToString()), DateTime.Parse(table.Rows[0][10].ToString()),
                                   int.Parse(table.Rows[0][11].ToString()));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return c;
        }

        public int Insert(Off1ce c)
        {
            query = @"INSERT INTO Office (name,adress,latitude,longitude,phone,userId,localityId,managerId)
                      VALUES (@name,@adress,@latitude,@longitude,@phone,@userId,@localityId,@managerId)";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("@name", c.Name);
            cmd.Parameters.AddWithValue("@adress", c.Adress);
            cmd.Parameters.AddWithValue("@latitude", c.Latitude);
            cmd.Parameters.AddWithValue("@longitude", c.Longitude);
            cmd.Parameters.AddWithValue("@phone", c.Phone);
            cmd.Parameters.AddWithValue("@userId", SessionControl.UserID);
            cmd.Parameters.AddWithValue("@localityId", c.LocalityId);
            cmd.Parameters.AddWithValue("@managerId", c.ManagerId);
            try
            {
                return ExecuteBasicCommand(cmd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT O.id,O.name AS Nombre,O.adress AS 'Dirección',O.latitude AS Latitud,O.longitude AS Longitud,O.phone AS 'Teléfono',L.name AS Localidad,CONCAT(U.surname,' ',U.names) AS Encargado
                    FROM Office O
                    INNER JOIN Locality L ON L.id=O.localityId
                    INNER JOIN UserR U ON U.id=O.managerId
                    WHERE O.status=1";
            SqlCommand cmd = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(cmd);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int Update(Off1ce c)
        {
            query = @"UPDATE Office SET name=@name,adress=@adress,latitude=@latitude,longitude=@longitude,phone=@phone,localityId=@localityId,managerId=@managerId,
                      lastUpdate=CURRENT_TIMESTAMP,userId=@userId
                      WHERE id=@id";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("id", c.Id);
            cmd.Parameters.AddWithValue("@name", c.Name);
            cmd.Parameters.AddWithValue("@adress", c.Adress);
            cmd.Parameters.AddWithValue("@latitude", c.Latitude);
            cmd.Parameters.AddWithValue("@longitude", c.Longitude);
            cmd.Parameters.AddWithValue("@phone", c.Phone);
            cmd.Parameters.AddWithValue("@userId", SessionControl.UserID);
            cmd.Parameters.AddWithValue("@localityId", c.LocalityId);
            cmd.Parameters.AddWithValue("@managerId", c.ManagerId);
            try
            {
                return ExecuteBasicCommand(cmd);
            }
            catch (Exception ex) 
            { 
                throw ex;
            }
        }
    }
}
