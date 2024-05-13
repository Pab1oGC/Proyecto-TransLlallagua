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
    public class InsuranceImpl : BaseImpl, IInsurance
    {
        public int Delete(Insuranc c)
        {
            query = @"UPDATE Insurance SET status=0, lastUpdate=CURRENT_TIMESTAMP, userId=@userId
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

        public Insuranc Get(byte id)
        {
            Insuranc c = null;
            query = @" SELECT id, name, price, description, status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP),userId
                    FROM Insurance
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    c = new Insuranc(byte.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), double.Parse(table.Rows[0][2].ToString()), table.Rows[0][3].ToString(),
                        byte.Parse(table.Rows[0][4].ToString()), DateTime.Parse(table.Rows[0][5].ToString()), DateTime.Parse(table.Rows[0][6].ToString()), short.Parse(table.Rows[0][7].ToString()));

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return c;
        }

        public int Insert(Insuranc c)
        {
            query = @"INSERT INTO Insurance(name, price, description, userId)
                     VALUES (@name, @price, @description, @userId)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", c.Name);
            command.Parameters.AddWithValue("@price", c.Price).SqlDbType=SqlDbType.Decimal;
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
            query = @"SELECT id,name AS Nombre, price AS 'Precio Bs', description AS Descripción
                      FROM Insurance
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

        public int Update(Insuranc c)
        {
            query = @"UPDATE Insurance SET name=@name, price=@price, description=@description,
			                         lastUpdate=CURRENT_TIMESTAMP, userId=@userId
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", c.Name);
            command.Parameters.AddWithValue("@price", c.Price);
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
