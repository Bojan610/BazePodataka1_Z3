using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Z3.Connection;
using Z3.Model;
using Z3.Utils;

namespace Z3.DAO.Impl
{
    public class SkakaonicaDAOImpl : ISkakaonicaDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Skakaonica entity)
        {
            throw new NotImplementedException();
        }

        public int DeleteAll()
        {
            throw new NotImplementedException();
        }

        public int DeleteById(string id)
        {
            throw new NotImplementedException();
        }

        public bool ExistsById(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skakaonica> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skakaonica> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public List<Skakaonica> FindAllByTypeSnowingBoard(string tipsa)
        {
            string query = "select * from skakaonica where tipsa = :tipsa";
                          
            List<Skakaonica> skakaonice = new List<Skakaonica>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "tipsa", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "tipsa", tipsa);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skakaonica skakaonica = new Skakaonica(reader.GetString(0), reader.GetString(1),
                                reader.GetInt32(2), reader.GetString(3), reader.GetString(4));
                            skakaonice.Add(skakaonica);
                        }
                    }
                }
            }

            return skakaonice;
        }

        public Skakaonica FindById(string id)
        {
            throw new NotImplementedException();
        }

        public int Save(Skakaonica entity)
        {
            throw new NotImplementedException();
        }

        public int SaveAll(IEnumerable<Skakaonica> entities)
        {
            throw new NotImplementedException();
        }
    }
}
