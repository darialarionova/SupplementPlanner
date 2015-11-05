using System.Data;
using System.Data.SqlClient;
using SupplementsPlanner.Entities;

namespace SupplementsPlanner.Repository
{
    public class RelationInformationRepository
    {
        private const string ConnectionString = @"Data Source=(local);Initial Catalog=SupplementsPlanner;Persist Security Info=True;User ID=SupplementsPlanner;Password=123456789";

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
    }
}
