using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_time_type:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            pPostgres.Message = "tbl_time_type - extraction - FINISH";
            pPostgres.Insert("insert into tbl_time_type(time_type_id, name) values('1','extra_time');");
            pPostgres.Insert("insert into tbl_time_type(time_type_id, name) values('2','prelims_time');");
            pPostgres.Insert("insert into tbl_time_type(time_type_id, name) values('3','vips_time');");
            pPostgres.Insert("insert into tbl_time_type(time_type_id, name) values('4','finals_time');");
            pPostgres.Message = "tbl_time_type - extraction - FINISH";
        }
    }
}