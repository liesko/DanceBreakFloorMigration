using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_city:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select venue_city from tbl_tour_dates where venue_city not like '' " +
                                                       "union " +
                                                       "select hotel_city from tbl_tour_dates where hotel_city not like '' " +
                                                       "union " +
                                                       "select city from tbl_tour_dates where city not like ''");
            pMysql.Message = "tbl_city - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_city(name) values('"+dataReader[0]+"');");
            }
            pPostgres.Message = "tbl_city - extraction - FINISH";
        }
    }
}