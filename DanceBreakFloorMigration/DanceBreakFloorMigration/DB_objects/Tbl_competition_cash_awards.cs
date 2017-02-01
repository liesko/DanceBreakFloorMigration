using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_competition_cash_awards : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_competition_cash_awards;");
            pMysql.Message = "tbl_competition_cash_awards - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_competition_cash_awards(id, tour_dates_id, highscoretype, place, amount, description) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["tourdateid"] + "','" + dataReader["highscoretype"] + "','" + dataReader["place"] + "','" + dataReader["amount"] + "','" + dataReader["description"] + "')");
            }
            pPostgres.Message = "tbl_competition_cash_awards - extraction - FINISH";
        }
    }
}