using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_person_types:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct title from tbl_dts_attendees where title !='';");
            pMysql.Message = "tbl_person_types (from tbl_dts_attendees.title)- extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_person_types(id, name) values('" + ++counter + "','" + dataReader[0] + "')");
            }
            pPostgres.Insert("insert into tbl_person_types(id, name) values('" + ++counter + "','undefined')");
            pPostgres.Insert("insert into tbl_person_types(id, name) values('" + ++counter + "','Costume Designer')");
            pPostgres.Message = "tbl_person_types - extraction - FINISH";
        }
    }
}