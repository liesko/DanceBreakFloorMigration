using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_dts_registrations : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_dts_registrations");
            pMysql.Message = "tbl_dts_registrations - extraction - START ";
            while (dataReader.Read())
            {
                string PersonId = GetPersonId(dataReader["address"].ToString().Replace("'", "''"), dataReader["city"].ToString().Replace("'", "''"),
                    dataReader["state"].ToString().Replace("'", "''"), dataReader["zip"].ToString(),
                    dataReader["countryid"].ToString(), dataReader["fname"].ToString().Replace("'", "''"), dataReader["lname"].ToString().Replace("'", "''"),
                    dataReader["email"].ToString(),
                    dataReader["contact_type"].ToString(), dataReader["phone"].ToString(),
                    dataReader["phone2"].ToString(), dataReader["fax"].ToString(),pPostgres);
                string studioid = GetStudioId(dataReader["organization"].ToString(),
                    pPostgres);

                pPostgres.Insert(
                    "insert into tbl_dts_registrations(id,tour_dates_id,studios_id,person_id,registration_id,user_id,admin_id," +
                    "heard,notes,total_fees,fees_paid,balance_due,boxsets, extra, edu) " +
                    "values(" + dataReader["id"]+", "+NVL(dataReader["tourdateid"].ToString()) + ", " + studioid + ", " + PersonId + ", " +
                    "" +NVL(dataReader["onlineregid"].ToString()) + ", " +NVL(dataReader["onlineuserid"].ToString()) + ", " +NVL(dataReader["enteredbyid"].ToString()) + ", '" + dataReader["heard"].ToString().Replace("'","''") + "', " +
                    "'" + dataReader["notes"].ToString().Replace("'","''") + "', " + NVL(dataReader["totalfees"].ToString()) + ", " +NVL(dataReader["feespaid"].ToString()) + ", " +NVL(dataReader["balancedue"].ToString()) + ", " +
                    "'" +Get_json_boxsets(dataReader["boxsets_2009"].ToString(), dataReader["boxsets_2010"].ToString(), dataReader["boxsets_0910_combo"].ToString())  + "'," +
                    "'" + Get_json_extra(dataReader["extra_dvdpre"].ToString(), dataReader["extra_gala"].ToString(), dataReader["extra_ff"].ToString(), dataReader["extra_ace"].ToString()) + "', " +
                    "'" + Get_json_edu(dataReader["edu_studioco"].ToString(), dataReader["edu_nostudioco"].ToString(), dataReader["edu_college"].ToString(), 
                    dataReader["edu_k12"].ToString(), dataReader["edu_danceteam"].ToString(), dataReader["edu_other"].ToString(), dataReader["edu_other_val"].ToString()) + "')")
                ;
            }
            pPostgres.Message = "tbl_dts_registrations - extraction - FINISH";
        }
        public string GetStudioId(string pStudio_name, PostgreSQL_DB pPostgres)
        {            
            if (String.IsNullOrEmpty(pStudio_name))
            {
                return "null";
            }
            else
            {
                string studioId =
                    GetId("select id from tbl_studios where name like '" + pStudio_name.Replace("'", "''") + "'",
                        pPostgres);
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

        private string GetAddressId(string pAddress, string pCity, string pState, string pZip, string pCountryId,
            PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            string p_city_id = GetId("select id from tbl_cities where name like '" + pCity.Replace("'", "''") + "'",
                pPostgres);
            query = pPostgres.Select("select distinct id " +
                                     "from tbl_addresses where address like '" + pAddress.Replace("'", "''") +
                                     "' and city_id = " + p_city_id + " and zip like '" + pZip + "' and country_id=" + NVL(pCountryId) + ";");
            string pom;
            while (query.Read())
            {
                pom = query[0].ToString();
                query.Dispose();
                return "'" + pom + "'";
            }
            query.Dispose();
            if (pAddress != "")
            {
                string city_id = GetId("select id from tbl_cities where name like '" + pCity.Replace("'", "''") + "'",
                    pPostgres);
                string pomStateId = GetId("select id from tbl_states where name like '" + pState + "'", pPostgres);
                pPostgres.Insert("insert into tbl_addresses(state_id, address, city_id, zip) values(" + pomStateId +
                                 ",'" + pAddress.Replace("'", "''") + "'," + city_id + ",'" + pZip + "');");
                string p_address_id = GetId("select max(id) from tbl_addresses", pPostgres);
                return p_address_id;
            }
            else
            {
                return "null";
            }
        }

        private string GetPersonId(string pAddress, string pCity, string pState, string pZip, string pCountryId,
            string pFname, string pLname, string pEmail,
            string pContactType, string pPhone, string pPhone2, string pFax, PostgreSQL_DB pPostgres)
        {
            string AddressId = GetAddressId(pAddress, pCity, pState, pZip, pCountryId, pPostgres);
            string GenderId = "null";
            string PersonType = GetId("select id from tbl_person_types where name like '" + pContactType + "' limit 1;", pPostgres);

            // into person
            string birthdate = "null";
            pPostgres.Insert(
                "insert into tbl_person(address_id, gender_id, fname, lname, birthdate, person_types_id) " +
                "values(" + AddressId + ", " + GenderId + ",'" + pFname.Replace("'", "''") + "'," +
                "'" + pLname.Replace("'", "''") + "'," + birthdate + "," + PersonType + ")");
            string Max_person_id = GetId("select max(id) from tbl_person", pPostgres);


            string phone_1 = pPhone;
            string phone_2 = pPhone2;
            var c = new[] { '(', ')', '-', ' ' };
            // insert into studio_has_contact_type
            if (phone_1 != "")
            {
                pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type_id, value)" +
                                 "values(" + Max_person_id + ",2,'" + Remove(phone_1, c) + "')");
            }
            if (phone_2 != "")
            {
                pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type_id, value)" +
                                 "values(" + Max_person_id + ",2,'" + Remove(phone_2, c) + "')");
            }
            if (pEmail != "")
            {
                pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type_id, value)" +
                                 "values(" + Max_person_id + ",1,'" + pEmail.Replace("'", "''") + "')");
            }
            if (pFax != "")
            {
                pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type_id, value)" +
                                 "values(" + Max_person_id + ",8,'" + Remove(pFax, c) + "')");
            }
            return Max_person_id;
        }
        private string Get_json_boxsets(string b2009, string b2010, string b0910_combo)
        {
            dynamic boxsets = new JObject();
            boxsets.b2009 = b2009;
            boxsets.b2010 = b2010;
            boxsets.b0910_combo = b0910_combo;
            return boxsets.ToString();
        }
        private string Get_json_extra(string dvdpre, string gala, string ff, string ace)
        {
            dynamic extra = new JObject();
            extra.dvdpre = dvdpre;
            extra.gala = gala;
            extra.ff = ff;
            extra.ace = ace;
            return extra.ToString();
        }
        private string Get_json_edu(string studioco, string nostudioco, string college, string k12, string danceteam, string other, string other_val)
        {
            dynamic edu = new JObject();
            edu.studioco = studioco;
            edu.nostudioco = nostudioco;
            edu.college = college;
            edu.k12 = k12;
            edu.danceteam = danceteam;
            edu.other = other;
            edu.other_val = other_val;
            return edu.ToString();
        }
    }
}