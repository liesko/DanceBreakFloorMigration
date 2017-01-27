using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_playlist_workshop_levels:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select name from tbl_playlist_workshop_levels " +
                                                       "union select name from tbl_age_divisions " +
                                                       "union select name from tbl_workshop_levels_14 " +
                                                       "union select name from tbl_workshop_levels_17 " +
                                                       "union select name from tbl_workshop_levels_20 " +
                                                       "union select name from tbl_workshop_levels_22 ;");
            pMysql.Message = "tbl_playlist_workshop_levels - extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_playlist_workshop_levels(id, name) values(" + ++counter + ",'" + dataReader[0] + "')");
            }
            pPostgres.Insert("insert into tbl_playlist_workshop_levels(id, name) values(0,'DUMMY')");
            pPostgres.Message = "tbl_playlist_workshop_levels - extraction - FINISH";
        }
    }
}