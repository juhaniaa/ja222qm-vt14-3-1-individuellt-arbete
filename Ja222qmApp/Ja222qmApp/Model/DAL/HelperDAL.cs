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

        // hämta ut en medlems ansvarsområden med hjälp av id
        public IEnumerable<Helper> GetHelperAreas(int helperId)
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    // lista för medhjälpare och lagrad procedur med parameter
                    var helperAreas = new List<Helper>(1000);
                    var cmd = new SqlCommand("appSchema.usp_ShowHelperAreas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4).Value = helperId;                    

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        // hämta ut databasindex
                        var helperIdIndex = reader.GetOrdinal("HelperID");
                        var memberIdIndex = reader.GetOrdinal("MemberID");
                        var areaIdIndex = reader.GetOrdinal("AreaID");
                        var areaNameIndex = reader.GetOrdinal("Area");

                        // för varje rad i databasen
                        // lägg till medhjälpare i databasen
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

                    // kapa överflöd och returnera listan
                    helperAreas.TrimExcess();
                    return helperAreas;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle hämtas från databasen");
                }
            }

        }

        // ta bort ett ansvarsområde från medlem
        public int DeleteHelperArea(int helperId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // lagrad procedur med parametrar
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteHelper", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@HelperID", SqlDbType.Int, 4).Value = helperId;
                    cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteReader();

                    // returnera id för den medlem som ett ansvar tagits bort från
                    int memberId = (int)cmd.Parameters["@MemberID"].Value;
                    return memberId;
                }
                catch (Exception)
                {

                    throw new ApplicationException("Ett fel inträffade då medlemmen skulle raderas från databasen");
                }
            }
        }

        // lägg till ansvarsområde till medlem
        public void AddAreaToMember(int memberId, int areaId) 
        { 
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // lagrad procedur med parametrar
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddHelper", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4).Value = memberId;
                    cmd.Parameters.Add("@AreaID", SqlDbType.VarChar, 15).Value = areaId;

                    conn.Open();

                    cmd.ExecuteReader();                    
                }

                catch 
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle läggas till i databasen");
                }
            }        
        }

        // hämta ut alla medlemmar inom ett ansvarsområde
        public IEnumerable<Member> GetMembersByArea(int areaId) 
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    // lista för medlemmar och lagrad procedur med parameter
                    var members = new List<Member>(1000);
                    SqlCommand cmd = new SqlCommand("appSchema.usp_ShowMembersByArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AreaId", SqlDbType.Int).Value = areaId;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        // hämta index från databasen
                        var memberIdIndex = reader.GetOrdinal("MemberID");
                        var nameIndex = reader.GetOrdinal("Name");

                        // för varje rad i databasen lägg till medlem i listan
                        while (reader.Read())
                        {
                            members.Add(new Member
                            {
                                MemberId = reader.GetInt32(memberIdIndex),
                                Name = reader.GetString(nameIndex)
                            });
                        }
                    }

                    // kapa överflöd och returnera listan
                    members.TrimExcess();
                    return members;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle hämtas från databasen");
                }
            }
        }
    }
}