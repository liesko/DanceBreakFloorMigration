using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_registrations_attendees_dts : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_user_registrations_attendees_dts;");
            pMysql.Message = "tbl_registrations_attendees_dts - extraction - START ";
            while (dataReader.Read())
            {
                string RegId = GetId("select id from tbl_registration  where old_user_reg_id='"+dataReader["regid"]+"' limit 1;", pPostgres);

                pPostgres.Insert("insert into tbl_registrations_attendees_dts(id, registration_id, user_id, tbl_dts_reg_types_id, promo_code, fee) " +
                                 "values("+dataReader["id"]+", "+RegId+"," +
                                 ""+ UserIdManage(dataReader["fname"].ToString().Replace("'","''"), dataReader["lname"].ToString().Replace("'", "''"), dataReader["email"].ToString(), dataReader["affiliation"].ToString(), pPostgres) + "," +
                                 ""+dataReader["regtypeid"] +", '"+dataReader["promocode"] +"',"+dataReader["fee"]+");");
            }

            pPostgres.Message = "tbl_registrations_attendees_dts - extraction - FINISH";
        }
        private string UserIdManage(string pname, string lname, string pemail, string pAffiliation, PostgreSQL_DB pPostgres)
        {
            string UserId = GetId("select id from tbl_user where email like '" + pemail + "' limit 1;", pPostgres);
            string personType = GetId("select id from tbl_person_types where name like '" + pAffiliation + "' limit 1;", pPostgres);
            if (UserId == "null")
            {
                pPostgres.Insert("insert into tbl_person(address_id, gender_id, fname, lname, birthdate, person_types_id) " +
                                 "values(null,null,'" + pname + "','" + lname + "',null, " + personType + ") ");
                string Max_person_id = GetId("select max(id) from tbl_person", pPostgres);

                int Max_user_id = Convert.ToInt32(GetId("select max(id) from tbl_user", pPostgres));
                pPostgres.Insert("insert into tbl_user(id, email, password, active, person_id, unregistered) " +
                                 "values('" + ++Max_user_id + "','" + pemail + "',null,null,'" + Max_person_id + "','1')");

                UserId = Max_user_id.ToString();
            }
            return UserId;
        }
    }
}