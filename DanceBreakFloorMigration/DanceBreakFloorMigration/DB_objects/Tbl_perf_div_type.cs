using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_perf_div_type:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            pPostgres.Message = "tbl_perf_div_type - creation - START";
            pPostgres.Insert("insert into tbl_perf_div_type(perf_div_type_id, name) values('1','Combined Top 3');");
            pPostgres.Insert("insert into tbl_perf_div_type(perf_div_type_id, name) values('2','Combined Top 1');");
            pPostgres.Insert("insert into tbl_perf_div_type(perf_div_type_id, name) values('3','Individual Top 3');");
            pPostgres.Insert("insert into tbl_perf_div_type(perf_div_type_id, name) values('4','Individual Top 1');");
            pPostgres.Insert("insert into tbl_perf_div_type(perf_div_type_id, name) values('0','Nothing');");
            pPostgres.Message = "tbl_perf_div_type - creation - FINISH";
        }
    }
}