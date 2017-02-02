using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Registrations_routines_dancers : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_user_registrations_routines_dancers");
            pMysql.Message = "tbl_registrations_routines_dancers - extraction - START ";
            while (dataReader.Read())
            {
                string RegId = GetId("select id from tbl_registration  where old_user_reg_id='" + dataReader["regid"] + "' limit 1;", pPostgres);

                pPostgres.Insert("insert into tbl_registrations_routines_dancers(id, registration_id, registrations_routine_id, dancer_id, workshop_skip) " +
                                 "values("+dataReader["id"]+", "+RegId+","+dataReader["regroutineid"] +","+dataReader["profileid"] +","+CheckBool(dataReader["workshopskip"].ToString()) + ");");
            }

            pPostgres.Message = "tbl_registrations_routines_dancers - extraction - FINISH";
        }
    }
}