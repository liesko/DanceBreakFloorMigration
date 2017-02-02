using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_event_attendees : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_event_attendees;");
            pMysql.Message = "tbl_event_attendees - extraction - START ";
            while (dataReader.Read())
            {
                string pPersonId = AddNewPerson(dataReader["fname"].ToString(), dataReader["lname"].ToString(), dataReader["email"].ToString(), dataReader["title"].ToString(), pPostgres);

                string NewIdFromReg = GetId("select id from tbl_event_registrations where id='" + dataReader["registrationid"]+"'", pPostgres);

                pPostgres.Insert("insert into tbl_event_attendees(id, event_registrations_id, samt, sfrom, note, canceled, audition_number, intensiveid, promo_codes_id, person_id) " +
                                 "values('"+dataReader["id"]+ "'," + NewIdFromReg + ",'" + dataReader["samt"].ToString().Replace("'", "''") + "','" + dataReader["sfrom"].ToString().Replace("'","''") + "'," +
                                 "'" + dataReader["note"].ToString().Replace("'", "''") + "','" +CheckBool(dataReader["canceled"].ToString()) + "'," +
                                 "" + NVL(dataReader["audition_number"].ToString()) + "," + NVL(dataReader["intensiveid"].ToString()) + "," + NVL(dataReader["promocodeid"].ToString()) + ", "+ pPersonId + ");");
            }
            pPostgres.Message = "tbl_event_attendees - extraction - FINISH";
        }
        public string AddNewPerson(string pName, string pLname, string pEmail, string pTitle, PostgreSQL_DB pPostgres)
        {
            string PersonType = GetId("select id from tbl_person_types where name like '" + pTitle + "' limit 1;", pPostgres);
            pPostgres.Insert("insert into tbl_person(fname, lname, person_types_id) " +
                                 "values('" + pName.ToString().Replace("'", "''") + "'," +
                                 "'" + pLname.ToString().Replace("'", "''") + "'," + PersonType + ")");
            string Max_person_id = GetId("select max(id) from tbl_person", pPostgres);

            if (!String.IsNullOrEmpty(pEmail.ToString()))
            {
                pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type_id, value)" +
                                 "values(" + Max_person_id + ",1,'" + pEmail.Replace("'", "''") + "')");
            }
            return Max_person_id;
        }
    }
}