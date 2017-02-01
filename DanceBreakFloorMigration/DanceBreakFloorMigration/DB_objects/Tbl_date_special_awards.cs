using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_special_awards : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_special_awards");

            pMysql.Message = "tbl_date_special_awards - extraction - START";
            int pcounter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_date_special_awards(id, tour_dates_id, date_routines_id, special_awards_id) " +
                                 "values('" + dataReader["id"] + "','" + dataReader["tourdateid"] + "','" + dataReader["dateroutineid"] + "','" + dataReader["awardid"] + "')");
            }
            pPostgres.Message = "tbl_date_special_awards - extraction - FINISH";
        }
    }
}