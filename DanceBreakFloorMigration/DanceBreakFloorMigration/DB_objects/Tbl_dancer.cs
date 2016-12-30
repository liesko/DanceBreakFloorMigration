using System;
using System.Linq;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_dancer : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            // all dancers related to the any studio...
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_profiles " +
                                                       "where typeid is null " +
                                                       "and studioid is not null " +
                                                       "and studioid !=0");
            pMysql.Message = "tbl_dancers - extraction - START";
            while (dataReader.Read())
            {
                // insert new address of dancer (person)
                // private string GetAddressId(string pAddress, string pCity, string pState, string pZip, string pCountryId, PostgreSQL_DB pPostgres)
                string AddressId = GetAddressId(dataReader["address"].ToString(), dataReader["city"].ToString(),
                    dataReader["state"].ToString(), dataReader["zip"].ToString(), dataReader["countryid"].ToString(),
                    pPostgres);
                string GenderId = GetId("select gender_id from tbl_gender where value like '"+dataReader["gender"]+"'", pPostgres);

                // inser dancer into person
                string birthdate = (dataReader["birth_date"].Equals("")) ? "null" : "'"+dataReader["birth_date"]+"'";
                pPostgres.Insert("insert into tbl_person(address_id, gender_id, fname, lname, birthdate, person_types_id) " +
                                 "values("+ AddressId + ", "+ GenderId + ",'"+dataReader["fname"].ToString().Replace("'","''")+"'," +
                                 "'"+dataReader["lname"].ToString().Replace("'", "''") + "',"+birthdate+",'8')");
                string Max_person_id = GetId("select max(person_id) from tbl_person", pPostgres);

                // insert into tbl_dancer
                string parent_guardian = (dataReader["parent_guardian"] == "") ? "null" : dataReader["parent_guardian"].ToString();
                string email_parents = (dataReader["email_parents"] == "") ? "null" : dataReader["email_parents"].ToString();
                if (email_parents.Equals("''"))
                {
                    email_parents = "null";
                }
                pPostgres.Insert("insert into tbl_dancer(dancer_id, person_id, parent_guardian, email_parents) " +
                                 "values('" + dataReader["id"] + "',"+Max_person_id+",'"+ parent_guardian.Replace("'","''") + "','"+ email_parents.Replace("'", "''") + "')");

                var phone_1 = dataReader["phone"].ToString();
                var phone_2 = dataReader["phone2"].ToString();
                var fax = dataReader["fax"].ToString();
                var c = new[] { '(', ')', '-', ' ' };
                // insert into studio_has_contact_type
                if (dataReader["phone"].ToString()!="")
                {
                    pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type_id, value)" +
                                     "values(" + Max_person_id + ",2,'" + Remove(phone_1, c) + "')");
                }
                if (dataReader["phone2"].ToString() != "")
                {
                    pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type_id, value)" +
                                     "values(" + Max_person_id + ",2,'" + Remove(phone_2, c) + "')");
                }
                if (dataReader["fax"].ToString()!="")
                {
                    pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type_id, value)" +
                                     "values(" + Max_person_id + ",8,'" + Remove(fax, c) + "')");
                }
                if (dataReader["email"].ToString() != "")
                {
                    pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type_id, value)" +
                                     "values(" + Max_person_id + ",1,'" + dataReader["email"].ToString().Replace("'","''") + "')");
                }

                // insert into tbl_studio has dancer
                try
                {
                    pPostgres.Insert("insert into tbl_studios_has_dancer(dancer_id, studios_id) values('" + dataReader["id"] + "','" + dataReader["studioid"] + "')");
                }
                catch (Exception)
                {
                    
                 //   pPostgres.Message= "ERROR: insert into tbl_studios_has_dancer(dancer_id, studios_id) values('" + dataReader["id"] + "', '" + dataReader["studioid"] + "')";
                }
                // insert tbl_user_has_dancer

            }
            pPostgres.Message = "tbl_dancers - extraction - FINISH";
        }
        private string GetAddressId(string pAddress, string pCity, string pState, string pZip, string pCountryId, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            string p_city_id = GetId("select city_id from tbl_city where name like '" + pCity.Replace("'", "''") + "'", pPostgres);
            query = pPostgres.Select("select distinct address_id " +
                                   "from tbl_address where address like '" + pAddress.Replace("'", "''") + "' and city_id = " + p_city_id + " and zip like '" + pZip + "' and country_id='" + pCountryId + "';");
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
                string city_id = GetId("select city_id from tbl_city where name like '" + pCity.Replace("'", "''") + "'", pPostgres);
                string pomStateId = GetId("select state_id from tbl_states where name like '" + pState + "'", pPostgres);
                pPostgres.Insert("insert into tbl_address(state_id, address, city_id, zip) values(" + pomStateId + ",'" + pAddress.Replace("'", "''") + "'," + city_id + ",'" + pZip + "');");
                string p_address_id = GetId("select max(address_id) from tbl_address", pPostgres);
                return p_address_id;
            }
            else
            {
                return "null";
            }
        }
    }
}