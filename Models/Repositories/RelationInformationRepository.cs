using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SupplementsPlanner;
using SupplementsPlannerWeb.Entities;
using System.Collections.Generic;

namespace SupplementsPlannerWeb.Models.Repositories
{
    public class RelationInformationRepository
    {
        private readonly string ConnectionString = ConfigurationManager.ConnectionStrings[Consts.Settings.ConnectionStringName].ConnectionString;

        public void SetSupplementsRelation(SupplementsRelation supplements)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "SetSupplementsRelation";

                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@FirstSupplementNotation",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = supplements.First
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@SecondSupplementNotation",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = supplements.Second
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@RelationType",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = supplements.RelationType
                    });

                    command.ExecuteNonQuery();
                }
            }
        }

        public IEnumerable<object> GetSupplementRelations(int id, string type)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "GetSupplementRelationsByIdAndType";

                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Id",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input,
                        Value = id
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Language",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = Consts.Settings.CurrentLanguage
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@Type",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = type
                    });
                   
                    using (var reader = command.ExecuteReader())
                    {
                        var supplements = new List<object>();
                        while (reader.Read())
                        {
                            supplements.Add(new 
                            {
                                Id = int.Parse(reader["Id"].ToString()),
                                FullName = reader["FullName"].ToString(),
                                Notation = reader["Notation"].ToString(),
                                Type = reader["Type"].ToString(),
                                RelationType = reader["RelationType"].ToString()
                            });
                        }
                        return supplements;
                    }
                }
            }
        }
    }
}
