using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_playlists : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_playlists;");
            pMysql.Message = "tbl_date_playlists - extraction - START";
            while (dataReader.Read())
            {
                string p_songs_id=null; // GET
                string p_playlist_workshop_levels_id = null; // GET
                pPostgres.Insert("insert into tbl_date_playlists(id, tour_date_id, songs_id, playlist_workshop_levels_id)) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["tourdateid"] + "','" + p_songs_id + "','" + p_playlist_workshop_levels_id + "')");
            }
            pPostgres.Message = "tbl_date_playlists - extraction - FINISH";
        }
    }
}