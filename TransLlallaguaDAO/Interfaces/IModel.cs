using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransLlallaguaDAO.Models;

namespace TransLlallaguaDAO.Interfaces
{
    public interface IModel : IBase<Mode1>
    {
        Mode1 Get(byte id);
        DataTable SelecName();
    }
}
