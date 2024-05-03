using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class User:Employee
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        /// <summary>
        /// Log in
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }

    }
}
