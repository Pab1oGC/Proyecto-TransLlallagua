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
    public class BrandImpl : BaseImpl, IBrand
    {
        public int Delete(Brand c)
        {
            query = @"UPDATE Brand SET status=0, lastUpdate=CURRENT_TIMESTAMP, userId=@userId
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userId", SessionControl.UserID);
            command.Parameters.AddWithValue("@id", c.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Brand Get(byte id)
        {
            Brand c = null;
            query = @" SELECT id, name, quality, description, status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP),userId
                    FROM Brand
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    c = new Brand(byte.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), table.Rows[0][3].ToString(),
                        byte.Parse(table.Rows[0][4].ToString()), DateTime.Parse(table.Rows[0][5].ToString()), DateTime.Parse(table.Rows[0][6].ToString()), short.Parse(table.Rows[0][7].ToString()));

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return c;
        }

        public int Insert(Brand c)
        {
            query = @"INSERT INTO Brand(name, quality, description, userId)
                     VALUES (@name, @quality, @description, @userId)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", c.Name);
            command.Parameters.AddWithValue("@quality", c.Quality);
            command.Parameters.AddWithValue("@description", c.Description);
            command.Parameters.AddWithValue("@userId", SessionControl.UserID);

            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Select()
        {
            query = @"SELECT id,name AS Nombre, quality AS Calidad,description AS Descripción
                      FROM Brand
                      WHERE status=1
                      ORDER BY 2";

            SqlCommand command = CreateBasicCommand(query);
            try
            {
                return ExecuteDataTableCommand(command);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Update(Brand c)
        {
            query = @"UPDATE Brand SET name=@name, quality=@quality, description=@description,
			                         lastUpdate=CURRENT_TIMESTAMP, userId=@userId
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", c.Name);
            command.Parameters.AddWithValue("@quality", c.Quality);
            command.Parameters.AddWithValue("@description", c.Description);
            command.Parameters.AddWithValue("@userId", SessionControl.UserID);
            command.Parameters.AddWithValue("@id", c.Id);
            try
            {
                return ExecuteBasicCommand(command);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
