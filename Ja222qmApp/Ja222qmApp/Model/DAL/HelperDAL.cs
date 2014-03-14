using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Ja222qmApp.Model.DAL
{
    public class HelperDAL
    {
        private static string _connectionString;

        static HelperDAL()
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["MemberConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public IEnumerable<Helper> GetHelperAreas(int helperId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var helperAreas = new List<Helper>(1000);

                    var cmd = new SqlCommand("appSchema.usp_ShowHelperAreas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4).Value = helperId;                    

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var helperIdIndex = reader.GetOrdinal("HelperID");
                        var memberIdIndex = reader.GetOrdinal("MemberID");
                        var areaIdIndex = reader.GetOrdinal("AreaID");
                        var areaNameIndex = reader.GetOrdinal("Area");

                        while (reader.Read())
                        {
                            helperAreas.Add(new Helper
                            {
                                HelperId = reader.GetInt32(helperIdIndex),
                                MemberId = reader.GetInt32(memberIdIndex),
                                AreaId = reader.GetInt32(areaIdIndex),
                                HelperAreaName = reader.GetString(areaNameIndex)                                
                            });
                        }
                    }

                    helperAreas.TrimExcess();

                    return helperAreas;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle hämtas från databasen");
                }
            }

        }

        public int DeleteHelperArea(int helperId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteHelper", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@HelperID", SqlDbType.Int, 4).Value = helperId;
                    cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteReader();

                    int memberId = (int)cmd.Parameters["@MemberID"].Value;

                    return memberId;
                }
                catch (Exception)
                {

                    throw new ApplicationException("Ett fel inträffade då medlemmen skulle raderas från databasen");
                }
            }
        }
    }
}