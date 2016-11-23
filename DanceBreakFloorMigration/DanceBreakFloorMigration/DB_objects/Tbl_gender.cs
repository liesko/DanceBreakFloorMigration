using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_gender:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct gender from tbl_profiles where gender is not null;");
            pMysql.Message = "tbl_gender (from tbl_profile)- extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_gender(gender_id, value) values('" + ++counter + "','" + dataReader[0] + "')");
            }
            pPostgres.Message = "tbl_gender - extraction - FINISH";
        }
    }
}