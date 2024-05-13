using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransLlallaguaDAO.Interfaces;
using TransLlallaguaDAO.Models;

namespace TransLlallaguaDAO.Implementation
{
    public class ModelImpl : BaseImpl, IModel
    {
        public DataTable SelecName()
        {
            query = @"SELECT id, name
                      FROM Model
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

        public int Delete(Mode1 c)
        {
            query = @"UPDATE Model SET status=0, lastUpdate=CURRENT_TIMESTAMP, userId=@userId
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

        public Mode1 Get(byte id)
        {
            Mode1 c = null;
            query = @" SELECT id, name, brand, year, status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP),userId
                    FROM Model
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    c = new Mode1(byte.Parse(table.Rows[0][0].ToString()), table.Rows[0][1].ToString(), table.Rows[0][2].ToString(), short.Parse(table.Rows[0][3].ToString()),
                        byte.Parse(table.Rows[0][4].ToString()), DateTime.Parse(table.Rows[0][5].ToString()), DateTime.Parse(table.Rows[0][6].ToString()), short.Parse(table.Rows[0][7].ToString()));

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return c;
        }

        public int Insert(Mode1 c)
        {
            query = @"INSERT INTO Model(name, brand, year, userId)
                     VALUES (@name, @brand, @year, @userId)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", c.Name);
            command.Parameters.AddWithValue("@brand", c.Brand);
            command.Parameters.AddWithValue("@year", c.Year);
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
            query = @"SELECT id,name AS Nombre, year AS Año
                      FROM Model
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

        public int Update(Mode1 c)
        {
            query = @"UPDATE Model SET name=@name, brand=@brand, year=@year,
			                         lastUpdate=CURRENT_TIMESTAMP, userId=@userId
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@name", c.Name);
            command.Parameters.AddWithValue("@brand", c.Brand);
            command.Parameters.AddWithValue("@year", c.Year);
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

