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
    public class UserImpl : BaseImpl, IUser
    {
        public int Delete(User user)
        {
            throw new NotImplementedException();
        }

        public int Insert(User user)
        {
            throw new NotImplementedException();
        }
        
        public DataTable Select()
        {
            throw new NotImplementedException();
        }

        public int Update(User user)
        {
            throw new NotImplementedException();
        }
        public bool Select(User user)
        {
            string query = @"SELECT username FROM [User] WHERE username=@username AND [password]=HASHBYTES('MD5',@password)";
            //string query = @"SELECT username FROM [User] WHERE [password]=HASHBYTES('MD5',@password)";
            SqlCommand cmd = CreateBasicCommand(query);
            cmd.Parameters.AddWithValue("@username", user.Username);
            cmd.Parameters.AddWithValue("@password", user.Password).SqlDbType = SqlDbType.VarChar; 
            try
            {
                cmd.Connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Connection.Close();
            }
        }
    }
}
