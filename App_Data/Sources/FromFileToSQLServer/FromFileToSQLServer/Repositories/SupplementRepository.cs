using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using FromFileToSQLServer.Entities;
using System.Configuration;

namespace FromFileToSQLServer.Repositories
{
    public class SupplementRepository 
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings[Consts.Settings.ConnectionStringName].ConnectionString;
        
        //todo: simplify stored procedure, using merge and inner join instead of select
        public void SetSupplement(Supplement supplement)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SetSupplement";

                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Language",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = Consts.Settings.CurrentLanguage
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@FullName",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = supplement.FullName
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Notation",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = supplement.Notation
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Type",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = supplement.Type
                    });

                    command.ExecuteNonQuery();
                }
            }
        }
        public IEnumerable<Supplement> GetSupplements()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetSupplements";

                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Language",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = Consts.Settings.CurrentLanguage
                    });

                    using (var reader = command.ExecuteReader())
                    {
                        var supplements = new List<Supplement>();
                        while (reader.Read())
                        {
                            supplements.Add(new Supplement
                            {
                                Id = int.Parse(reader["Id"].ToString()),
                                FullName = reader["FullName"].ToString(),
                                Notation = reader["Notation"].ToString(),
                                Type = reader["Type"].ToString()
                            });
                        }
                        return supplements;
                    }
                }
            }
        }
    }
}
