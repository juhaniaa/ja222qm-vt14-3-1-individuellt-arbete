using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Ja222qmApp.Model.DAL
{
    public class MemberDAL
    {
        private static string _connectionString;

        static MemberDAL()
        { 
            _connectionString = WebConfigurationManager.ConnectionStrings["MemberConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public Member GetMember(int memberId) 
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_GetMember", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MemberId", SqlDbType.Int).Value = memberId;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int memberIdIndex = reader.GetOrdinal("MemberID");
                            int nameIdIndex = reader.GetOrdinal("Name");
                            int addressIdIndex = reader.GetOrdinal("Address");
                            int postnrIdIndex = reader.GetOrdinal("Postnr");
                            int cityIdIndex = reader.GetOrdinal("City");

                            return new Member
                            {
                                MemberId = reader.GetInt32(memberIdIndex),
                                Name = reader.GetString(nameIdIndex),
                                Address = reader.GetString(addressIdIndex),
                                Postnr = reader.GetString(postnrIdIndex),
                                City = reader.GetString(cityIdIndex)
                            };
                        }
                    }
                    return null;
                }
                catch (Exception)
                {

                    throw new ApplicationException("Ett fel inträffade då medlemsinfon skulle hämtas från databasen");
                }
            }
        }

        public IEnumerable<Member> GetMembers()         
        {
            using(var conn = CreateConnection())
	        {
                try
                {
                    var members = new List<Member>(1000);

                    var cmd = new SqlCommand("appSchema.usp_ShowMembers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var memberIdIndex = reader.GetOrdinal("MemberID");
                        var nameIndex = reader.GetOrdinal("Name");
                        var addressIndex = reader.GetOrdinal("Address");
                        var postnrIndex = reader.GetOrdinal("Postnr");
                        var cityIndex = reader.GetOrdinal("City");

                        while (reader.Read())
                        {
                            members.Add(new Member
                                {
                                    MemberId = reader.GetInt32(memberIdIndex),
                                    Name = reader.GetString(nameIndex),
                                    Address = reader.GetString(addressIndex),
                                    Postnr = reader.GetString(postnrIndex),
                                    City = reader.GetString(cityIndex)
                                });
                        }
                    }

                    members.TrimExcess();

                    return members;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle hämtas från databasen");
                }
	        }
        
        }

        public void DeleteMember(int memberId) 
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteMember", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4).Value = memberId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {

                    throw new ApplicationException("Ett fel inträffade då medlemmen skulle raderas från databasen");
                }
            }
        }


        public void InsertMember(Member member)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddMember", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = member.Name;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 30).Value = member.Address;
                    cmd.Parameters.Add("@Postnr", SqlDbType.VarChar, 5).Value = member.Postnr;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = member.City;
                    cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteReader();

                    member.MemberId = (int)cmd.Parameters["@MemberID"].Value;
                    
                }
                catch 
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle läggas till i databasen");
                }
            }
        }
        public void UpdateMember(Member member)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateMember", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MemberID", SqlDbType.Int, 4).Value = member.MemberId;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 40).Value = member.Name;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 30).Value = member.Address;
                    cmd.Parameters.Add("@Postnr", SqlDbType.VarChar, 5).Value = member.Postnr;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = member.City;

                    conn.Open();

                    cmd.ExecuteReader();


                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle uppdateras i databasen");
                }
            }
        }
    }
}