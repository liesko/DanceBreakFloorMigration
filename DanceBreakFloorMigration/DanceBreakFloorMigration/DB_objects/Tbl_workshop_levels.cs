using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_workshop_levels : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select id, cast(name as char) name, discount_fee, full_fee, finale_discount_fee, finale_full_fee, one_day_full_fee, one_day_discount_fee, 11 season_id " +
                                                       "from tbl_workshop_levels_11 " +
                                                       "union " +
                                                       "select id, name, discount_fee, full_fee, finale_discount_fee, finale_full_fee, one_day_full_fee, one_day_discount_fee, 14 season_id " +
                                                       "from tbl_workshop_levels_14 " +
                                                       "union " +
                                                       "select id, name, discount_fee, full_fee, finale_discount_fee, finale_full_fee, one_day_full_fee, one_day_discount_fee, 17 season_id " +
                                                       "from tbl_workshop_levels_17 " +
                                                       "union " +
                                                       "select id, cast(name as char) name, discount_fee, full_fee, finale_discount_fee, finale_full_fee, one_day_full_fee, one_day_discount_fee, 2 season_id " +
                                                       "from tbl_workshop_levels_2 " +
                                                       "union " +
                                                       "select id, name, discount_fee, full_fee, finale_discount_fee, finale_full_fee, one_day_full_fee, one_day_discount_fee, 20 season_id " +
                                                       "from tbl_workshop_levels_20 " +
                                                       "union " +
                                                       "select id, name, discount_fee, full_fee, finale_discount_fee, finale_full_fee, one_day_full_fee, one_day_discount_fee, 22 season_id " +
                                                       "from tbl_workshop_levels_22;");

            pMysql.Message = "tbl_workshop_levels - extraction - START";
            int pcounter = 0;
            while (dataReader.Read())
            {                
                string p_playlist_workshop_levels_id = GetId("select id from tbl_playlist_workshop_levels where name like '" + dataReader["name"] + "' limit 1", pPostgres);

                pPostgres.Insert("insert into tbl_workshop_levels(id, playlist_workshop_levels_id, discount_fee, full_fee, finale_discount_fee, finale_full_fee, one_day_full_fee, one_day_discount_fee, season_id) " +
                                 "values("+ ++pcounter +","+ p_playlist_workshop_levels_id + ",'"+dataReader["discount_fee"] +"','" + dataReader["full_fee"] + "','" + dataReader["finale_discount_fee"] + "','" + dataReader["finale_full_fee"] + "','" + dataReader["one_day_full_fee"] + "','" + dataReader["one_day_discount_fee"] + "'," + dataReader["season_id"] + ")");
            }
            pPostgres.Message = "tbl_workshop_levels - extraction - FINISH";
        }
    }
}