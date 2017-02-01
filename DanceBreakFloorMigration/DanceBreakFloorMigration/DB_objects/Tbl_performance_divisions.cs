using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_performance_divisions:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select id, name from tbl_performance_divisions;");
            pMysql.Message = "tbl_performance_divisions - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_performance_divisions(id, name) values(" + dataReader[0] + ",'" + dataReader[1] + "')");
            }
            pPostgres.Insert("insert into tbl_performance_divisions(id, name) values(0,'Nothing');");
            pPostgres.Message = "tbl_performance_divisions - extraction - FINISH";
        }
    }
}