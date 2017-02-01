using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_workshop_room:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            pPostgres.Message = "tbl_workshop_rooms - extraction - START";
            pPostgres.Insert("insert into tbl_workshop_rooms(id, name) values('1','workshop room 1')");
            pPostgres.Insert("insert into tbl_workshop_rooms(id, name) values('2','workshop room 2')");
            pPostgres.Insert("insert into tbl_workshop_rooms(id, name) values('3','workshop room 3')");
            pPostgres.Insert("insert into tbl_workshop_rooms(id, name) values('4','workshop room 4')");
            pPostgres.Insert("insert into tbl_workshop_rooms(id, name) values('5','workshop room 5')");
            pPostgres.Insert("insert into tbl_workshop_rooms(id, name) values('6','workshop room 6')");
            pPostgres.Insert("insert into tbl_workshop_rooms(id, name) values('7','workshop room 7')");
            pPostgres.Message = "tbl_workshop_rooms - extraction - FINISH";
        }
    }
}