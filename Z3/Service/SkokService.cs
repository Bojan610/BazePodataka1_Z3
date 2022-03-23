using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3.DAO;
using Z3.DAO.Impl;
using Z3.Model;

namespace Z3.Service
{
    public class SkokService
    {
        private static readonly ISkokDAO skokDAO = new SkokDAOImpl();

        public bool ExistsById(string id)
        {
            return skokDAO.ExistsById(id);
        }

        public Skok FindById(string id)
        {
            return skokDAO.FindById(id);
        }

        public int Save(Skok s)
        {
            return skokDAO.Save(s);
        }
    }
}
