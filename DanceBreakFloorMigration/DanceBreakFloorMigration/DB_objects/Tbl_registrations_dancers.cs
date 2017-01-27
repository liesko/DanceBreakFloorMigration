using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_registrations_dancers : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_user_registrations_dancers;");
            pMysql.Message = "Tbl_registrations_dancers - extraction - START ";
            while (dataReader.Read())
            {
                string RegId = GetId("select id from tbl_registration  where old_user_reg_id='" + dataReader["regid"] + "' limit 1;", pPostgres);

                pPostgres.Insert(
                    "insert into tbl_registrations_dancers(id, registration_id, dancer_id, one_day, has_scholarship, attended_reg, is_commuter, " +
                    "non_commuter, classes_only, workshop_level_id, fees, promo_codes_id, scholarship, best_dancer, event_teacher, events_id, reg_type_id) " +
                    "values(" + dataReader["id"] + "," + RegId + "," + dataReader["profileid"] + "," +
                    CheckBool(dataReader["oneday"].ToString()) + "," + CheckBool(dataReader["hasscholarship"].ToString()) + ", " +
                    "" + CheckBool(dataReader["attendedreg"].ToString()) + ", " + CheckBool(dataReader["iscommuter"].ToString()) + "," + NVL(dataReader["noncommuterid"].ToString()) +
                    ", " + CheckBool(dataReader["classesonly"].ToString()) + ", " +
                    "" + dataReader["workshoplevelid"] + ",'" +
                    Get_json_fees(dataReader["workshopfee"].ToString(), dataReader["attendeefee"].ToString()) + "'," +
                    "" + NVL(dataReader["promocodeid"].ToString()) + ",'" +
                    Get_json_scholarship(dataReader["scholarshipamt"].ToString(),
                        dataReader["scholarshipfrom"].ToString()) + "'," +
                    "" + CheckBool(dataReader["bestdancer"].ToString()) + ", " + CheckBool(dataReader["event_teacher"].ToString()) + "," + NVL(dataReader["intensiveid"].ToString()) +
                    "," + NVL(dataReader["regtypeid"].ToString()) + ");");
            }

            pPostgres.Message = "Tbl_registrations_dancers - extraction - FINISH";
        }
        private string Get_json_fees(string pWorkshop, string pAttendee)
        {
            dynamic fees = new JObject();
            fees.extended = pWorkshop;
            fees.prelims = pAttendee;
            return fees.ToString();
        }
        private string Get_json_scholarship(string pAmount, string pFrom)
        {
            dynamic scholarship = new JObject();
            scholarship.extended = pAmount.Replace("'", "''");
            scholarship.prelims = pFrom.Replace("'","''");
            return scholarship.ToString();
        }
    }
}