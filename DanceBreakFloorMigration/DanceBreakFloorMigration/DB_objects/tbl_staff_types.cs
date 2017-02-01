using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_staff_types : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_staff_types;");
            pMysql.Message = "tbl_staff_types - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_staff_types(id, name) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["name"] + "')");
            }
            pPostgres.Message = "tbl_staff_types - extraction - FINISH";
        }
    }
}