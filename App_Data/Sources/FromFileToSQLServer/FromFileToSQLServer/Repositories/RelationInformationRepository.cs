using System.Data;
using System.Data.SqlClient;
using FromFileToSQLServer.Entities;
using System.Configuration;

namespace FromFileToSQLServer.Repositories
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
                        Value = supplements.FirstSupplementNotation
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@SecondSupplementNotation",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = supplements.SecondSupplementNotation
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@SecondSupplementType",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = supplements.SecondSupplementType
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
    }
}
