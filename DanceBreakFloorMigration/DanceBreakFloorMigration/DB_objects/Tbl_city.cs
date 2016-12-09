using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_city:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct city as name from tbl_tour_dates");
            pMysql.Message = "tbl_city - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_city(name) values('"+dataReader[0]+"');");
            }
            pPostgres.Message = "tbl_city - extraction - FINISH";
        }
    }
}