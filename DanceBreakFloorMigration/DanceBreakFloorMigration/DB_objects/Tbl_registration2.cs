using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_registration2 : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            // tbl_registration from dancetea.registration
            // ----------------------------------------------------------
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_user_registrations");
            int MaxRegId = Convert.ToInt32(GetId("select max(id) from tbl_registration;", pPostgres));

            pMysql.Message = "Tbl_registration (mybreak.tbl_user_registrations) - extraction - START ";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_registration(id, tour_dates_id, old_user_reg_id, user_id, left_off, date, completed, fees, observers, free_teacher, waiver, credit, payment_method ) " +
                                 "values('" + ++MaxRegId + "','" + dataReader["tourdateid"] + "', "+dataReader["id"]+", "+dataReader["userid"]+",'"+dataReader["leftoffphp"] +"'," +
                                 "'"+Get_json_date(dataReader["mktime"].ToString(),dataReader["mkupdate"].ToString()) +"','0'," +
                                 "'"+ Get_json_fees(dataReader["workshop_fee"].ToString(), dataReader["competition_fee"].ToString(), dataReader["attendee_fee"].ToString(), 
                                 dataReader["bestdancer_fee"].ToString(), dataReader["offers_fee"].ToString(), dataReader["offers_fee"].ToString(), 
                                 dataReader["observers_fee2"].ToString()) + "'," +
                                 "'"+ Get_json_observers(dataReader["observers"].ToString(),dataReader["observers2"].ToString()) + "'," +
                                 "'"+Get_json_free_teacher(dataReader["ftc"].ToString(), dataReader["ftv"].ToString()) +"',"+CheckBool(dataReader["waiver"].ToString()) + "," +
                                 "'"+Get_json_credit(dataReader["creditamt"].ToString(),dataReader["creditfrom"].ToString()) +"','"+dataReader["payment_method"] +"');");
            }

            pPostgres.Message = "Tbl_registration (mybreak.tbl_user_registrations) - extraction - FINISH";
        }

        public string GetStudioId(string pStudio_name, PostgreSQL_DB pPostgres)
        {
            if (pStudio_name == null || pStudio_name == "")
            {
                return "null";
            }
            else
            {
                string studioId = GetId("select id from tbl_studios where name like '" + pStudio_name.Replace("'", "''") + "'", pPostgres);
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
        private string Get_json_date(string pFirst_date, string pSecond_date)
        {
            dynamic date = new JObject();
            date.created = pFirst_date;
            date.updated = pSecond_date;
            return date.ToString();
        }
        private string Get_json_fees(string pWorkshop, string pCompetition, string pAttendee, string pBestDancer, string pOffers, string pObser1, string pObser2)
        {
            dynamic fees = new JObject();
            fees.workshop = pWorkshop;
            fees.competition = pCompetition;
            fees.attendee = pAttendee;
            fees.bestdancer = pBestDancer;
            fees.offers = pOffers;
            fees.observers1 = pObser1;
            fees.observers2 = pObser2;
            return fees.ToString();
        }
        private string Get_json_observers(string pObservers, string pObservers2)
        {
            dynamic observers = new JObject();
            observers.observers = pObservers;
            observers.observers2 = pObservers2;
            return observers.ToString();
        }
        private string Get_json_free_teacher(string pCount, string pValue)
        {
            dynamic free_teacher = new JObject();
            free_teacher.count = pCount;
            free_teacher.value = pValue;
            return free_teacher.ToString();
        }
        private string Get_json_credit(string pAmmount, string pFrom)
        {
            dynamic credit = new JObject();
            credit.amount = pAmmount;
            credit.from = pFrom.Replace("'","''");
            credit.used = "none";
            return credit.ToString();
        }
    }
}