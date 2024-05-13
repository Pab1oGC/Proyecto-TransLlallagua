using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransLlallaguaDAO.Models;

namespace TransLlallaguaDAO.Interfaces
{
    public interface IBrand:IBase<Brand>
    {
        Brand Get(byte id);
    }
}
