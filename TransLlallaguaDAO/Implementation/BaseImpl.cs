using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace TransLlallaguaDAO.Implementation
{
    public class BaseImpl
    {
        //string connectionString = "Server=LAPTOP-LQALR3B5;Database=dbTransLlallagua;Trusted_Connection=True;";
        string connectionString = "Server=DESKTOP-6I0OB38;Database=dbTransLlallagua;User Id=pablo;Password=7457405Po;";
        protected string query;
        public SqlCommand CreateBasicCommand()
        {
            SqlConnection connection = new SqlConnection(connectionString); 
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connection;
            return cmd;
        }
        public SqlCommand CreateBasicCommand(string Query)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return new SqlCommand(Query,connection);
        }
        public string OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                return "Conexion exitosa";
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
        public int ExecuteBasicCommand(SqlCommand command)
        {
            try
            {
                command.Connection.Open();
                return command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
        }
        public DataTable ExecuteDataTableCommand(SqlCommand command)
        {
            DataTable dt = new DataTable();
            try
            {
                command.Connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dt);
                foreach (DataColumn column in dt.Columns)
                {
                    column.ColumnName = column.ColumnName.Trim(); // Eliminar espacios en blanco de los nombres de columna
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Connection.Close();
            }
            return dt;
        }
    }
}
