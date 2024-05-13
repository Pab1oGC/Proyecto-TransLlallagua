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
    public class BusImpl : BaseImpl, IBus
    {
        public int Delete(Bus c)
        {
            query = @"UPDATE Bus SET status=0, lastUpdate=CURRENT_TIMESTAMP, userId=@userId
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@userId", 1);
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

        public Bus Get(byte id)
        {
            Bus c = null;
            query = @" SELECT id, capacity, soat,licensePlate,status,registerDate,ISNULL(lastUpdate,CURRENT_TIMESTAMP),userId,brandId
                    FROM Bus
                    WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@id", id);
            try
            {
                DataTable table = ExecuteDataTableCommand(command);
                if (table.Rows.Count > 0)
                {
                    c = new Bus(byte.Parse(table.Rows[0][0].ToString()), byte.Parse(table.Rows[0][1].ToString()), int.Parse(table.Rows[0][2].ToString()), table.Rows[0][3].ToString(),
                        byte.Parse(table.Rows[0][4].ToString()), DateTime.Parse(table.Rows[0][5].ToString()), DateTime.Parse(table.Rows[0][6].ToString()), short.Parse(table.Rows[0][7].ToString()), short.Parse(table.Rows[0][8].ToString()));

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return c;
        }

        public int Insert(Bus c)
        {
            query = @"INSERT INTO bus(capacity, soat, licensePlate, userId,brandId)
                     VALUES (@capacity, @soat, @licensePlate, @userId,@brandId)";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@capacity", c.Capacity);
            command.Parameters.AddWithValue("@soat", c.Soat);
            command.Parameters.AddWithValue("@licensePlate", c.LicensePlate);
            command.Parameters.AddWithValue("@userId", SessionControl.UserID);
            command.Parameters.AddWithValue("@brandId", 1);
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
            query = @"SELECT id,capacity AS 'Capacidad',soat AS Soat, licensePlate AS Placa
                      FROM Bus
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

        public int Update(Bus c)
        {
            query = @"UPDATE Bus SET capacity=@capacity, soat=@soat, licensePlate=@licensePlate,
			                         lastUpdate=CURRENT_TIMESTAMP, userId=@userId, brandId=@brandId
                      WHERE id=@id";
            SqlCommand command = CreateBasicCommand(query);
            command.Parameters.AddWithValue("@capacity", c.Capacity);
            command.Parameters.AddWithValue("@soat", c.Soat);
            command.Parameters.AddWithValue("@licensePlate", c.LicensePlate);
            command.Parameters.AddWithValue("@userId", 1);
            command.Parameters.AddWithValue("@brandId", 1);
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

