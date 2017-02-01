using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_dts_attendees : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_dts_attendees;");
            pMysql.Message = "tbl_dts_attendees - extraction - START ";
            while (dataReader.Read())
            {
                if (!String.IsNullOrEmpty(dataReader["promocodeid"].ToString()))
                {
                    CreateDummyPromoCode(NVL(dataReader["promocodeid"].ToString()), pPostgres);
                }

                string pPersonId= AddNewPerson(dataReader["fname"].ToString(), dataReader["lname"].ToString(), dataReader["email"].ToString(), dataReader["title"].ToString(), pPostgres);

                pPostgres.Insert("insert into tbl_dts_attendees(id, fee, custom_fee, note, canceled, person_id, dts_registrations_id, promo_codes_id) " +
                                 "values("+dataReader["id"]+ "," + NVL(dataReader["fee"].ToString()) + "," + CheckBool(dataReader["custom_fee"].ToString()) + "," +
                                 "'" + dataReader["note"].ToString().Replace("'", "''") + "'," + CheckBool(dataReader["canceled"].ToString()) + ","+ pPersonId + ","+dataReader["registrationid"] +","+NVL(dataReader["promocodeid"].ToString()) + ");");
            }
            pPostgres.Message = "tbl_dts_attendees - extraction - FINISH";
        }

        public string AddNewPerson(string pName, string pLname, string pEmail, string pTitle, PostgreSQL_DB pPostgres)
        {
            string PersonType = GetId("select id from tbl_person_types where name like '" + pTitle + "' limit 1;", pPostgres);
            pPostgres.Insert("insert into tbl_person(fname, lname, person_types_id) " +
                                 "values('"+ pName.ToString().Replace("'", "''") + "'," +
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