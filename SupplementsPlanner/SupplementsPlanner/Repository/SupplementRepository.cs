using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SupplementsPlanner.Entities;

namespace SupplementsPlanner.Repository
{
    public class SupplementRepository 
    {
        private const string ConnectionString = @"Data Source=(local);Initial Catalog=SupplementsPlanner;Persist Security Info=True;User ID=SupplementsPlanner;Password=123456789";

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
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Solvent",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = supplement.Solvent
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
                                Type = reader["Type"].ToString(),
                                Solvent = reader["Solvent"].ToString()
                            });
                        }
                        return supplements;
                    }
                }
            }
        }
    }
}
