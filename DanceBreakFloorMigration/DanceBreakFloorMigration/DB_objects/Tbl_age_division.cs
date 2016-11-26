using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_age_division:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select id, cast(`range` as CHAR), minimum_age, name " +
                                                       "from tbl_age_divisions;");
            pMysql.Message = "tbl_age_divisions - extraction - START";
            string pom;
            while (dataReader.Read())
            {
                pom = GetId(dataReader[3].ToString(), pPostgres);
               
                 pPostgres.Insert("insert into tbl_age_divisions(age_divisions_id, range, minimum_age,playlist_workshop_levels_id) " +
                                 "values('" + dataReader[0] + "','" + dataReader[1] + "','"+ dataReader[2] + "','"+ pom + "');");
            }
            pPostgres.Message = "tbl_age_divisions - extraction - FINISH";
        }

        private string GetId(string pParam, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            query=pPostgres.Select("select distinct playlist_workshop_levels_id " +
                                   "from tbl_playlist_workshop_levels where name like '"+ pParam + "';");
            string pom;
            while (query.Read())
            {
                pom= query[0].ToString();
                query.Dispose();
                return pom;
            }
            
            return null;
        }
    }
}