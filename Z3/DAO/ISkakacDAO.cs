using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3.Model;

namespace Z3.DAO
{
    public interface ISkakacDAO : ICRUDDao<Skakac, int>
    {
        List<Skakac> FindByIdd(string idd);
    }
}
