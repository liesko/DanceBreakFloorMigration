using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_registration : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            // tbl_registration from dancetea.registration
            // ----------------------------------------------------------
            MySqlDataReader dataReader = pMysql.Select("select * from registrations;");
            pMysql.Message = "Tbl_registration (dancetea.registration) - extraction - START ";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_registration(id, tour_dates_id, studios_id, user_id, date, completed, confirmed, heard, details, enteredby_id, viewed, deleted, payment_method) " +
                                 "values('"+dataReader["id"]+"','"+dataReader["tourdateid"] +"',"+ GetStudioId(dataReader["studio"].ToString(),pPostgres) +"," +
                                 ""+UserIdManage(dataReader["fname"].ToString().Replace("'","''"), dataReader["lname"].ToString().Replace("'", "''"), dataReader["email"].ToString(),dataReader["title"].ToString() ,pPostgres) +"," +
                                 "'"+Get_json_date(dataReader["date"].ToString(), dataReader["confirmdate"].ToString()) +"','1',"+CheckBool(dataReader["confirmed"].ToString()) + "," +
                                 "'"+dataReader["heard"].ToString().Replace("'","''") +"'," +
                                 "'"+dataReader["details"].ToString().Replace("'", "''") + "',"+NVL(dataReader["enteredby"].ToString()) + ", "+CheckBool(dataReader["viewed"].ToString()) + ", " +
                                 ""+CheckBool(dataReader["deleted"].ToString()) + ",'"+dataReader["payment_method"] +"');");
            }
            pPostgres.Insert("insert into tbl_registration(id) values(22996);");
            pPostgres.Insert("insert into tbl_registration(id) values(23035);");
            pPostgres.Insert("insert into tbl_registration(id) values(23127);");
            pPostgres.Insert("insert into tbl_registration(id) values(24225);");
            pPostgres.Insert("insert into tbl_registration(id) values(31298);");

            pPostgres.Message = "Tbl_registration (dancetea.registration) - extraction - FINISH";
        }

        public string GetStudioId(string pStudio_name, PostgreSQL_DB pPostgres)
        {
            if (pStudio_name == null || pStudio_name == "")
            {
                return "null";
            }
            else
            {
                string studioId = GetId("select id from tbl_studios where name like '" + pStudio_name.Replace("'","''") + "'", pPostgres);
                if (studioId != null)
                {
                    return studioId;
                }
                else
                {
                    return AddNewStudio(pStudio_name, pPostgres);
                }
            }
        }
        private string UserIdManage(string pname, string lname, string pemail, string pTitle, PostgreSQL_DB pPostgres)
        {
            string UserId = GetId("select id from tbl_user where email like '" + pemail + "' limit 1;", pPostgres);
            string personType = GetId("select id from tbl_person_types where name like '"+pTitle+"' limit 1;", pPostgres);
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
        private string Get_json_date(string pFirst_date, string pSecond_date)
        {
            dynamic date = new JObject();
            date.completed = pFirst_date;
            date.confirmed = pSecond_date;
            return date.ToString();
        }

    }
}