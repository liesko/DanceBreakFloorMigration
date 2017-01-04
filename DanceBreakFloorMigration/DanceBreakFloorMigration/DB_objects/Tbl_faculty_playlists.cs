using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_faculty_playlists : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select id, facultyid1 as faculty " +
                                                       "from tbl_date_playlists where facultyid1!='0' and facultyid1 is not null " +
                                                       "union " +
                                                       "select id, facultyid2 as faculty " +
                                                       "from tbl_date_playlists  where facultyid2!='0' and facultyid2 is not null;");
            pMysql.Message = "tbl_faculty_playlists - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_faculty_playlists(date_playlists_id, faculty_id) " +
                                 "values('"+dataReader["id"]+"','"+dataReader["faculty"] +"')");
            }
            pPostgres.Message = "tbl_faculty_playlists - extraction - FINISH";
        }
    }
}