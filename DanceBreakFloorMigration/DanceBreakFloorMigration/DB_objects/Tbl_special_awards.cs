using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_special_awards : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_special_awards");

            pMysql.Message = "Tbl_special_awards - extraction - START";
            int pcounter = 0;
            while (dataReader.Read())
            {
                string p_award_name = GetId("select id from Tbl_awards_type where name like '" + dataReader["name"].ToString().Replace("'", "''") + "' limit 1", pPostgres);

                pPostgres.Insert("insert into tbl_special_awards(id, events_id, awards_type_id, report_order) " +
                                 "values('" + dataReader["id"] + "','" + dataReader["eventid"] + "','" + p_award_name + "','"+dataReader["report_order"] +"')");
            }
            pPostgres.Message = "Tbl_special_awards - extraction - FINISH";
        }
    }
}