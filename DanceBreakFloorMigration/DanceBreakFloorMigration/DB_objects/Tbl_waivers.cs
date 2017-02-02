using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_waivers : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_waivers;");
            pPostgres.Message = "tbl_waivers - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_waivers(id, dancer_id) " +
                                 "values("+dataReader["id"]+","+dataReader["profileid"]+")");
            }

            pPostgres.Insert("insert into tbl_waivers(id, dancer_id) values(0, 20797)");

            pPostgres.Message = "tbl_waivers - extraction - FINISH";
        }
    }
}