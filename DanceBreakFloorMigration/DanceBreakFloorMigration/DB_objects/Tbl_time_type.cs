using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_time_type:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            pPostgres.Message = "tbl_time_type - extraction - FINISH";
            pPostgres.Insert("insert into tbl_time_type(id, name) values('1','extra');");
            pPostgres.Insert("insert into tbl_time_type(id, name) values('2','prelims');");
            pPostgres.Insert("insert into tbl_time_type(id, name) values('3','vips');");
            pPostgres.Insert("insert into tbl_time_type(id, name) values('4','finals');");
            pPostgres.Message = "tbl_time_type - extraction - FINISH";
        }
    }
}