using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_fee_types:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            pPostgres.Message = "tbl_fee_types - extraction - START";
            pPostgres.Insert("insert into tbl_fee_types(id, name) values('1','workshop')");
            pPostgres.Insert("insert into tbl_fee_types(id, name) values('2','competition')");
            pPostgres.Insert("insert into tbl_fee_types(id, name) values('3','attendee')");
            pPostgres.Insert("insert into tbl_fee_types(id, name) values('4','total')");
            pPostgres.Insert("insert into tbl_fee_types(id, name) values('5','bestdancer')");
            pPostgres.Insert("insert into tbl_fee_types(id, name) values('6','observers')");
            pPostgres.Insert("insert into tbl_fee_types(id, name) values('7','offers')");
            pPostgres.Message = "tbl_fee_types - extraction - FINISH";
        }
    }
}