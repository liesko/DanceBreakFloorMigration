using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_staff : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_staff;");
            pMysql.Message = "tbl_staff - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_staff(id, fname, lname, staff_types_id) " +
                                 "values('" + dataReader["id"] + "','" + dataReader["fname"].ToString().Replace("'", "''") + "','" + dataReader["lname"].ToString().Replace("'","''") + "','" + dataReader["stafftypeid"] + "')");
            }
            pPostgres.Message = "tbl_staff - extraction - FINISH";
        }
    }
}