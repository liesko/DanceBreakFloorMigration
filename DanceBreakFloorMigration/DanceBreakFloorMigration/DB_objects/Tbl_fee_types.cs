using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_fee_types:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            pPostgres.Message = "tbl_fee_types - extraction - START";
            pPostgres.Insert("insert into tbl_fee_types(fee_types_id, name) values('1','workshop_fee')");
            pPostgres.Insert("insert into tbl_fee_types(fee_types_id, name) values('2','competition_fee')");
            pPostgres.Insert("insert into tbl_fee_types(fee_types_id, name) values('3','attendee_fee')");
            pPostgres.Insert("insert into tbl_fee_types(fee_types_id, name) values('4','total_fees')");
            pPostgres.Insert("insert into tbl_fee_types(fee_types_id, name) values('5','bestdancer_fee')");
            pPostgres.Insert("insert into tbl_fee_types(fee_types_id, name) values('6','observers_fee')");
            pPostgres.Insert("insert into tbl_fee_types(fee_types_id, name) values('7','offers_fee')");
            pPostgres.Insert("insert into tbl_fee_types(fee_types_id, name) values('8','observers_fee2')");
            pPostgres.Message = "tbl_fee_types - extraction - FINISH";
        }
    }
}