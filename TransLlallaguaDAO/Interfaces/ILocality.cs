using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Interfaces
{
    public interface ILocality
    {
        DataTable SelectIDName();
        DataTable SelectLocality(byte id);
    }
}
