using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_season:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select id, year1, year2 from tbl_seasons;");
            pMysql.Message = "tbl_seasons - extraction - START";
            string pom = "null";
            while (dataReader.Read())
            {
                pom = (dataReader[2].ToString()=="")?"null": dataReader[2].ToString();
                pPostgres.Insert("insert into tbl_seasons(id, start_year,end_year) values('" + dataReader[0] + "',"+ dataReader[1] + ","+ pom + ")");
            }
            pPostgres.Insert("insert into tbl_seasons(id, start_year, end_year) values(0, 9999,9999)");
            pPostgres.Message = "tbl_seasons - extraction - FINISH";
        }
    }
}