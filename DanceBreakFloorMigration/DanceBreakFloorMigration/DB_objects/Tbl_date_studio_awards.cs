using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_studio_awards : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from Tbl_date_studio_awards");

            pMysql.Message = "Tbl_date_studio_awards - extraction - START";
            int pcounter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into Tbl_date_studio_awards(id, tour_dates_id, studios_id, studio_awards_id, winner) " +
                                 "values('" + dataReader["id"] + "','" + dataReader["tourdateid"] + "','" + dataReader["studioid"] + "','" + dataReader["awardtypeid"] + "','"+CheckBool(dataReader["winner"].ToString()) + "')");
            }
            pPostgres.Message = "Tbl_date_studio_awards - extraction - FINISH";
        }
    }
}