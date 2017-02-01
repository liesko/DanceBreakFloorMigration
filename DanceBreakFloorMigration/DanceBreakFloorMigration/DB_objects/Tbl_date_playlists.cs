using System.Net;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_playlists : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_playlists;");
            pMysql.Message = "tbl_date_playlists - extraction - START";
            while (dataReader.Read())
            {
                string p_songs_id=GetId("select id from tbl_songs " +
                                        "where " +
                                        "song_name like '"+ WebUtility.UrlDecode(dataReader["song"].ToString()).Replace("'", "''") + "' and " +
                                        "artist_name like '"+ WebUtility.UrlDecode(dataReader["artist"].ToString()).Replace("'", "''") + "' LIMIT 1;", pPostgres);

                string p_playlist_workshop_levels_id = GetId("select id from tbl_playlist_workshop_levels where name like '"+dataReader["workshoplevel"] +"' limit 1", pPostgres);

                pPostgres.Insert("insert into tbl_date_playlists(id, tour_dates_id, songs_id, playlist_workshop_levels_id) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["tourdateid"] + "'," + p_songs_id + "," + p_playlist_workshop_levels_id + ")");
            }
            pPostgres.Message = "tbl_date_playlists - extraction - FINISH";
        }
    }
}