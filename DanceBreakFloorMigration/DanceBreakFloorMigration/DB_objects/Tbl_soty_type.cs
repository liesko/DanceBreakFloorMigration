using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_soty_type:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            pPostgres.Message = "tbl_soty_type - extraction - FINISH";
            pPostgres.Insert("insert into tbl_soty_type(id, name) values('1','ts_ballet')");
            pPostgres.Insert("insert into tbl_soty_type(id, name) values('2','ts_jazz')");
            pPostgres.Insert("insert into tbl_soty_type(id, name) values('3','ts_mtspec')");
            pPostgres.Insert("insert into tbl_soty_type(id, name) values('4','ts_contemplyrical')");
            pPostgres.Insert("insert into tbl_soty_type(id, name) values('5','ts_hiphoptap')");
            pPostgres.Insert("insert into tbl_soty_type(id, name) values('6','mj_ballet')");
            pPostgres.Insert("insert into tbl_soty_type(id, name) values('7','mj_jazz')");
            pPostgres.Insert("insert into tbl_soty_type(id, name) values('8','mj_mtspec')");
            pPostgres.Insert("insert into tbl_soty_type(id, name) values('9','mj_contemplyrical')");
            pPostgres.Insert("insert into tbl_soty_type(id, name) values('10','mj_hiphoptap')");
            pPostgres.Message = "tbl_soty_type - extraction - FINISH";
        }
    }
}