using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_contact_type:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            pPostgres.Message = "tbl_contact_type - extraction - START";
            pPostgres.Insert("insert into tbl_contact_type(id, name) values('1','email')");
            pPostgres.Insert("insert into tbl_contact_type(id, name) values('2','phone')");
            pPostgres.Insert("insert into tbl_contact_type(id, name) values('3','twitter')");
            pPostgres.Insert("insert into tbl_contact_type(id, name) values('4','facebook')");
            pPostgres.Insert("insert into tbl_contact_type(id, name) values('5','web')");
            pPostgres.Insert("insert into tbl_contact_type(id, name) values('6','linkedin')");
            pPostgres.Insert("insert into tbl_contact_type(id, name) values('7','instagram')");
            pPostgres.Insert("insert into tbl_contact_type(id, name) values('8','fax')");
            pPostgres.Message = "tbl_contact_type - extraction - FINISH";
        }
    }
}