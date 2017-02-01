using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_studio_has_person:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            pMysql.Message = "studios_has_person - extraction - START";
                pPostgres.Insert("insert into studios_has_person(studios_id, person_id) select c.studios_id, a.id from tbl_person a join tbl_user b on (a.id=b.person_id) " +
                                 "join tbl_studio_contacts c on(b.email = c.value) where a.person_types_id in('1','2','3','4','5','6') and c.contact_type_id = 1;");
            pPostgres.Message = "studios_has_person - extraction - FINISH";
        }
    }
}   