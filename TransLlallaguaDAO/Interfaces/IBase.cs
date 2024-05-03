using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransLlallaguaDAO.Interfaces
{
    public interface IBase<C>
    {
        int Insert(C c);
        int Update(C c);
        int Delete(C c);
        DataTable Select();
    }
}
