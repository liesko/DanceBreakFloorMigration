using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_event_attendees : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_event_attendees;");
            pMysql.Message = "tbl_event_attendees - extraction - START ";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_event_attendees(id, registration_id, samt, sfrom, note, canceled, audition_number, intensiveid, promo_codes_id) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader[""] + "','" + dataReader[""] + "','" + dataReader[""] + "','" + dataReader[""] + "','" + dataReader[""] + "','" + dataReader[""] + "','" + dataReader[""] + "','" + dataReader[""] + "');");
            }
            pPostgres.Message = "tbl_event_attendees - extraction - FINISH";
        }
    }
}