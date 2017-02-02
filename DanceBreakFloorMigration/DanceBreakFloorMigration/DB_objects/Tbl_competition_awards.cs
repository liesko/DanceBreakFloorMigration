using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_competition_awards : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_competition_awards;");

            pMysql.Message = "Tbl_competition_awards - extraction - START";
            int pcounter = 0;
            while (dataReader.Read())
            {
                string p_award_id = GetId("select id from Tbl_awards_type where name like '" + dataReader["name"].ToString().Replace("'", "''") + "' limit 1", pPostgres);

                pPostgres.Insert("insert into tbl_competition_awards(id, lowest, highest, awards_type_id, events_id) " +
                                 "values("+dataReader["id"]+", "+dataReader["lowest"] +", "+dataReader["highest"] +","+ p_award_id + ","+dataReader["eventid"] +")");
            }
            pPostgres.Message = "Tbl_competition_awards - extraction - FINISH";
        }
    }
}