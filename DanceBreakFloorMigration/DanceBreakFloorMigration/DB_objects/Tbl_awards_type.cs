using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_awards_type : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select name as name from tbl_special_awards " +
                                                       "union " +
                                                       "select awardname as name from tbl_studio_awards " +
                                                       "union " +
                                                       "select name as name from tbl_competition_awards");

            pMysql.Message = "tbl_awards_type - extraction - START";
            int pcounter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_awards_type(id, name) " +
                                 "values(" + ++pcounter + ",'" + dataReader["name"].ToString().Replace("'","''")  +"')");
            }
            pPostgres.Message = "tbl_awards_type - extraction - FINISH";
        }
    }
}