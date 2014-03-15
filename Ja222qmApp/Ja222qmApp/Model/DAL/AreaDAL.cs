using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Ja222qmApp.Model.DAL
{
    public class AreaDAL
    {
        private static string _connectionString;

        static AreaDAL() 
        {
            _connectionString = WebConfigurationManager.ConnectionStrings["MemberConnectionString"].ConnectionString;
        }

        private static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // hämta ut specifikt ansvarsområde med hjälp av id
        public Area GetArea(int areaId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // lagrad procedur med parameter
                    SqlCommand cmd = new SqlCommand("appSchema.usp_GetArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AreaId", SqlDbType.Int).Value = areaId;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // hämta index
                            int areaIdIndex = reader.GetOrdinal("AreaID");
                            int nameIdIndex = reader.GetOrdinal("Area");                            

                            // returnera nytt Area objekt
                            return new Area
                            {
                                AreaId = reader.GetInt32(areaIdIndex),
                                AreaName = reader.GetString(nameIdIndex),
                            };
                        }
                    }

                    // om området på det idt inte finns kastas ett undantag
                    throw new ApplicationException("Ansvarsområdet existerar inte!");
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel inträffade då medlemsinfon skulle hämtas från databasen");
                }
            }
        }

        // hämta ut alla ansvarsområden
        public IEnumerable<Area> GetAreas() 
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    // lista för områden och lagrad procedur
                    var areas = new List<Area>(1000);
                    var cmd = new SqlCommand("appSchema.usp_ShowAreas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        // hämta index
                        var areaIdIndex = reader.GetOrdinal("AreaID");
                        var areaNameIndex = reader.GetOrdinal("Area");
                        
                        // för varje rad i databasen lägg till nytt Area objekt i listan
                        while (reader.Read())
                        {
                            areas.Add(new Area
                            {
                                AreaId = reader.GetInt32(areaIdIndex),
                                AreaName = reader.GetString(areaNameIndex)                                
                            });
                        }
                    }

                    // kapa överflöd och returnera listan
                    areas.TrimExcess();
                    return areas;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle hämtas från databasen");
                }
            }
        
        }

        // lägg till nytt ansvarsområde
        public void InsertArea(Area area)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // lagrad procedur med parametrar
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Area", SqlDbType.VarChar, 40).Value = area.AreaName;                    
                    cmd.Parameters.Add("@AreaID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteReader();

                    // spara det nya områdes idt
                    area.AreaId = (int)cmd.Parameters["@AreaID"].Value;

                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle läggas till i databasen");
                }
            }
        }

        // uppdatera ansvarsområde
        public void UpdateArea(Area area)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // lagrad procedur med parametrar
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AreaID", SqlDbType.Int, 4).Value = area.AreaId;
                    cmd.Parameters.Add("@Area", SqlDbType.VarChar, 40).Value = area.AreaName;                    

                    conn.Open();

                    cmd.ExecuteReader();
                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle uppdateras i databasen");
                }
            }
        }

        // radera ansvarsområde
        public void DeleteArea(int areaId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    // lagrad procedur med parmeter
                    SqlCommand cmd = new SqlCommand("appSchema.usp_DeleteArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@AreaID", SqlDbType.Int, 4).Value = areaId;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw new ApplicationException("Ett fel inträffade då ansvarsområdet skulle raderas från databasen");
                }
            }
        }
    }
}