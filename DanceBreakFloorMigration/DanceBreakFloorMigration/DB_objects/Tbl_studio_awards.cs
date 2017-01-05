using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_studio_awards : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from Tbl_studio_awards");

            pMysql.Message = "Tbl_studio_awards - extraction - START";
            int pcounter = 0;
            while (dataReader.Read())
            {
                string p_award_name = GetId("select id from Tbl_awards_type where name like '" + dataReader["awardname"].ToString().Replace("'","''")  + "' limit 1", pPostgres);

                pPostgres.Insert("insert into Tbl_studio_awards(id, events_id, awards_type_id) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["eventid"] + "','"+p_award_name+"')");
            }
            pPostgres.Message = "Tbl_studio_awards - extraction - FINISH";
        }
    }
}