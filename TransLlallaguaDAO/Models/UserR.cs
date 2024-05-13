using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Models
{
    public class UserR:Employee
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="role"></param>
        public UserR(string name, string surname, string secondSurname, string ci, string phone, int userId, string adress, char gender, string username, string password, string role)
            : base(name, surname, secondSurname, ci, phone, userId,adress,gender)
        {
            Username = username;
            Password = password;
            Role = role;
        }
        public UserR(int id, string name, string surname, string secondSurname, string ci, string adress, char gender, string phone, string username,string role, byte status, DateTime registerDate, DateTime lastUpdate, int userId)
            :base(id, name, surname, secondSurname, ci, phone,adress,gender, status, registerDate, lastUpdate, userId)
        {
            Username=username;
            Role = role;
        }
        public UserR(string name, string surname, string secondSurname, string ci, string phone, int userId, string adress, char gender, string username, string role)
            : base(name, surname, secondSurname, ci, phone, userId, adress, gender)
        {
            Username = username;
            Role = role;
        }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        
    }
}
