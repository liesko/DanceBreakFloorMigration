using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_online_scoring : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_online_scoring");

            pMysql.Message = "tbl_online_scoring - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_online_scoring(id, awardid, tour_dates_id, studios_id, compgroup, total_score, dropped_score, routines_id) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["awardid"] + "','" + dataReader["tourdateid"] + "','" + dataReader["studioid"] +"'," +
                                 "'" + dataReader["compgroup"] + "','" + dataReader["total_score"] + "','" + dataReader["dropped_score"] + "','" + dataReader["routineid"] + "')");
            }
            pPostgres.Message = "tbl_online_scoring - extraction - FINISH";
        }
    }
}