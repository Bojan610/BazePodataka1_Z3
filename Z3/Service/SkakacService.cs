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
    public class SkakacService
    {
        private static readonly ISkakacDAO skakacDAO = new SkakacDAOImpl();

        public int Count()
        {
            return skakacDAO.Count();
        }

        public int Delete(Skakac skakac)
        {
            return skakacDAO.Delete(skakac);
        }

        public int DeleteById(int id)
        {
            return skakacDAO.DeleteById(id);
        }

        public int DeleteAll()
        {
            return skakacDAO.DeleteAll();
        }

        public bool ExistsById(int id)
        {
            return skakacDAO.ExistsById(id);
        }

        public List<Skakac> FindAll()
        {
            return skakacDAO.FindAll().ToList();
        }

        public List<Skakac> FindAllById(IEnumerable<int> ids)
        {
            return skakacDAO.FindAllById(ids).ToList();
        }

        public Skakac FindById(int id)
        {
            return skakacDAO.FindById(id);
        }

        public int Save(Skakac s)
        {
            return skakacDAO.Save(s);
        }

        public int SaveAll(List<Skakac> skakacList)
        {
            return skakacDAO.SaveAll(skakacList);
        }
    }
}
