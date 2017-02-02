using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_dts_reg_types : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_dts_reg_types;");
            pMysql.Message = "tbl_dts_reg_types - extraction - START ";
            while (dataReader.Read())
            {
                    pPostgres.Insert("insert into tbl_dts_reg_types(id, name, fee) " +
                                     "values('"+dataReader["id"]+"','"+dataReader["name"]+"','"+dataReader["fee"]+"');");
            }
            pPostgres.Message = "tbl_dts_reg_types - extraction - FINISH";
        }
    }
}