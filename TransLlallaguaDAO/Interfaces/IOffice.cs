using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransLlallaguaDAO.Models;

namespace TransLlallaguaDAO.Interfaces
{
    public interface IOffice:IBase<Off1ce>
    {
        Off1ce Get(byte id);
        bool ValidateImagePath(string path);
    }
}
