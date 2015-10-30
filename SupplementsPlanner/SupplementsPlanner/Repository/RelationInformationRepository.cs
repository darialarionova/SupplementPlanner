using System.Data;
using System.Data.SqlClient;
using SupplementsPlanner.Entities;

namespace SupplementsPlanner.Repository
{
    public class RelationInformationRepository
    {
        private const string ConnectionString = @"Data Source=(local);Initial Catalog=SupplementsPlanner;Persist Security Info=True;User ID=SupplementsPlanner;Password=123456789";

        //public Supplement[,] GetCompatibilityInformation()
        //{
        //    //  return compabilityMatrix;
        //}

        //todo: use setting by one query
        public void SetSupplementsRelation(Supplement first, Supplement second, string relationType)
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
                        ParameterName = "@FirstSupplementId",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input,
                        Value = first.Id
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@SecondSupplementId",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Input,
                        Value = second.Id
                    });
                    command.Parameters.Add(new SqlParameter
                    {
                        ParameterName = "@RelationType",
                        SqlDbType = SqlDbType.NVarChar,
                        Direction = ParameterDirection.Input,
                        Value = relationType
                    });

                    command.ExecuteNonQuery();
                }
            }
        }
        
    }
}
