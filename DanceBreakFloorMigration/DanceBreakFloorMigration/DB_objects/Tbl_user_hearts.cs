using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_user_hearts : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_user_hearts;");
            pMysql.Message = "tbl_user_hearts - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_user_hearts(id, user_id, store_hearts_id) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["heartid"] + "','" + dataReader["userid"] + "')");
            }
            pPostgres.Message = "tbl_user_hearts - extraction - FINISH";
        }
    }
}