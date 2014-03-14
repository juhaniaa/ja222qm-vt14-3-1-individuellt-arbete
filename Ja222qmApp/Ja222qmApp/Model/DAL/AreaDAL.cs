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

        public Area GetArea(int areaId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_GetArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaId", SqlDbType.Int).Value = areaId;

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int areaIdIndex = reader.GetOrdinal("AreaID");
                            int nameIdIndex = reader.GetOrdinal("Area");
                            

                            return new Area
                            {
                                AreaId = reader.GetInt32(areaIdIndex),
                                AreaName = reader.GetString(nameIdIndex),
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

        public IEnumerable<Area> GetAreas() 
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    var areas = new List<Area>(1000);

                    var cmd = new SqlCommand("appSchema.usp_ShowAreas", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        var areaIdIndex = reader.GetOrdinal("AreaID");
                        var areaNameIndex = reader.GetOrdinal("Area");
                        

                        while (reader.Read())
                        {
                            areas.Add(new Area
                            {
                                AreaId = reader.GetInt32(areaIdIndex),
                                AreaName = reader.GetString(areaNameIndex)                                
                            });
                        }
                    }

                    areas.TrimExcess();

                    return areas;
                }

                catch
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle hämtas från databasen");
                }
            }
        
        }

        public void InsertArea(Area area)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_AddArea", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Area", SqlDbType.VarChar, 40).Value = area.AreaName;                    
                    cmd.Parameters.Add("@AreaID", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    conn.Open();

                    cmd.ExecuteReader();

                    area.AreaId = (int)cmd.Parameters["@AreaID"].Value;

                }
                catch
                {
                    throw new ApplicationException("Ett fel inträffade då infon skulle läggas till i databasen");
                }
            }
        }

        public void UpdateArea(Area area)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
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

        public void DeleteArea(int areaId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
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