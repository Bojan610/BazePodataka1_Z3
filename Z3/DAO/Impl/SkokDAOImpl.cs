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
    public class SkokDAOImpl : ISkokDAO
    {
        public int Count()
        {
            throw new NotImplementedException();
        }

        public int Delete(Skok entity)
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
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return ExistsById(id, connection);
            }
        }

        private bool ExistsById(string id, IDbConnection connection)
        {
            string query = "select * from skok where idsk=:idsk";

            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;
                ParameterUtil.AddParameter(command, "idsk", DbType.String, 50);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "idsk", id);
                return command.ExecuteScalar() != null;
            }
        }

        public IEnumerable<Skok> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Skok> FindAllById(IEnumerable<string> ids)
        {
            throw new NotImplementedException();
        }

        public Skok FindById(string id)
        {
            string query = "select idsk, idsc, idsa, bduzina, bstil, bvetar " +
                        "from skok where idsk = :idsk";
            Skok skok = null;

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "idsk", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "idsk", id);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            skok = new Skok(reader.GetString(0), reader.GetInt32(1),
                                reader.GetString(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5));
                        }
                    }
                }
            }

            return skok;
        }

        public int Save(Skok entity)
        {
            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                return Save(entity, connection);
            }
        }

        private int Save(Skok skok, IDbConnection connection)
        {
            string insertSql = "insert into skok (idsc, idsa, bduzina, bstil, bvetar, idsk) " +
                "values (:idsc , :idsa, :bduzina, :bstil, :bvetar, :idsk)";
            string updateSql = "update skok set idsc=:idsc, idsa=:idsa, " +
                "bduzina=:bduzina, bstil=:bstil, bvetar=:bvetar where idsk=:idsk";
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = ExistsById(skok.Idsk, connection) ? updateSql : insertSql;
                ParameterUtil.AddParameter(command, "idsc", DbType.Int32);
                ParameterUtil.AddParameter(command, "idsa", DbType.String, 50);
                ParameterUtil.AddParameter(command, "bduzina", DbType.Double);
                ParameterUtil.AddParameter(command, "bstil", DbType.Double);
                ParameterUtil.AddParameter(command, "bvetar", DbType.Double);
                ParameterUtil.AddParameter(command, "idsk", DbType.String, 50);
                command.Prepare();
                ParameterUtil.SetParameterValue(command, "idsk", skok.Idsk);
                ParameterUtil.SetParameterValue(command, "idsc", skok.Idsc);
                ParameterUtil.SetParameterValue(command, "idsa", skok.Idsa);
                ParameterUtil.SetParameterValue(command, "bduzina", skok.Bduzina);
                ParameterUtil.SetParameterValue(command, "bstil", skok.Bstil);
                ParameterUtil.SetParameterValue(command, "bvetar", skok.Bvetar);
                return command.ExecuteNonQuery();
            }
        }

        public int SaveAll(IEnumerable<Skok> entities)
        {
            throw new NotImplementedException();
        }

        public List<Skok> FindAllByTypeDivingBoard(string type)
        {
            string query = "select idsk, idsc, sko.idsa, bduzina, bstil, bvetar" +
                           " from skakaonica sk, skok sko" +
                           " where sk.idsa = sko.idsa and sk.tipsa = :type";
            List<Skok> skokList = new List<Skok>();

            using (IDbConnection connection = ConnectionUtil_Pooling.GetConnection())
            {
                connection.Open();
                using (IDbCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;
                    ParameterUtil.AddParameter(command, "type", DbType.String);
                    command.Prepare();
                    ParameterUtil.SetParameterValue(command, "type", type);
                    using (IDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Skok skok = new Skok(reader.GetString(0), reader.GetInt32(1),
                                reader.GetString(2), reader.GetDouble(3), reader.GetDouble(4), reader.GetDouble(5));
                            skokList.Add(skok);
                        }
                    }
                }
            }

            return skokList;
        }
    }
}
