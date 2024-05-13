using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransLlallaguaDAO.Models;

namespace TransLlallaguaDAO.Interfaces
{
    public interface IUser:IBase<UserR>
    {
        DataTable Login(string username, string password);
        bool ExistsUsername(string username);
        string CreateUsername(string surname,string names,int i);
        string CreatePassword();
        UserR Get(int id);
        bool EqualPassword(string password);
        bool SecurePassword(string password);
        int UpdatePassword(string password);
    }
}
