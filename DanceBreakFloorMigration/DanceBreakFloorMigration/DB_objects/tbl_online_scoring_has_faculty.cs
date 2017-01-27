using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_online_scoring_has_faculty : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select id, facultyid1 as faculty, data1 as data from tbl_online_scoring where facultyid1!=0 " +
                                                       "union select id, facultyid2 as faculty, data2 as data from tbl_online_scoring where facultyid2!=0 " +
                                                       "union select id, facultyid3 as faculty, data3 as data from tbl_online_scoring where facultyid3!=0 " +
                                                       "union select id, facultyid4 as faculty, data4 as data from tbl_online_scoring where facultyid4!=0");

            pMysql.Message = "tbl_online_scoring_has_faculty - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_online_scoring_has_faculty(online_scoring_id, faculty_id, data) " +
                                 "values('"+dataReader["id"]+"','"+dataReader["faculty"]+"',"+NVL(dataReader["data"].ToString().Replace("'","''")) + ")");
            }
            pPostgres.Message = "tbl_online_scoring_has_faculty - extraction - FINISH";
        }
    }
}