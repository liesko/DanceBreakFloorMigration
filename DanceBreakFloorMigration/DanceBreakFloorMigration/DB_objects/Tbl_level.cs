using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_level:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            pPostgres.Message = "tbl_levels - extraction - FINISH";
            pPostgres.Insert("insert into tbl_levels(id, name) values('1','Level 1');");
            pPostgres.Insert("insert into tbl_levels(id, name) values('2','Level 2');");
            pPostgres.Insert("insert into tbl_levels(id, name) values('3','Level 3');");
            pPostgres.Insert("insert into tbl_levels(id, name) values('4','Level 4');");
            pPostgres.Insert("insert into tbl_levels(id, name) values('5','Level 5');");
            pPostgres.Insert("insert into tbl_levels(id, name) values('6','Level 6');");
            pPostgres.Insert("insert into tbl_levels(id, name) values('7','Level 7');");
            pPostgres.Insert("insert into tbl_levels(id, name) values('8','Level 8');");
            pPostgres.Insert("insert into tbl_levels(id, name) values('9','Level 9');");
            pPostgres.Message = "tbl_levels - extraction - FINISH";
        }
    }
}