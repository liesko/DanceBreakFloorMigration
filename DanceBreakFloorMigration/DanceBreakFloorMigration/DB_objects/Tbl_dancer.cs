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
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            pPostgres.Insert("insert into tbl_person(id, fname, lname) values(0, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_dancer(id, person_id) values(20797,0);");
            pPostgres.Insert("insert into tbl_dancer(id, person_id) values(20862,0);");
            pPostgres.Insert("insert into tbl_dancer(id, person_id) values(18040,0);");
            pPostgres.Insert("insert into tbl_dancer(id, person_id) values(19862,0);");
            pPostgres.Insert("insert into tbl_dancer(id, person_id) values(20881,0);");
            pPostgres.Insert("insert into tbl_dancer(id, person_id) values(23182,0);");
            pPostgres.Insert("insert into tbl_dancer(id, person_id) values(23183,0)");
            pPostgres.Insert("insert into tbl_dancer(id, person_id) values(37996,0);");

            pPostgres.Insert("insert into tbl_dancer(id, person_id) values(12992,0);");
            pPostgres.Insert("insert into tbl_dancer(id, person_id) values(15804,0);");

            // all dancers related to the any studio...
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_profiles where studioid is not null;");
            pMysql.Message = "tbl_dancers - extraction - START";
            while (dataReader.Read())
            {
                // insert new address of dancer (person)
                // private string GetAddressId(string pAddress, string pCity, string pState, string pZip, string pCountryId, PostgreSQL_DB pPostgres)
                string AddressId = GetAddressId(dataReader["address"].ToString(), dataReader["city"].ToString(),
                    dataReader["state"].ToString(), dataReader["zip"].ToString(), dataReader["countryid"].ToString(),
                    pPostgres);
                string GenderId = GetId("select id from tbl_gender where value like '"+dataReader["gender"]+"'", pPostgres);

                // inser dancer into person
                string birthdate = (dataReader["birth_date"].Equals("")) ? "null" : "'"+dataReader["birth_date"]+"'";
                pPostgres.Insert("insert into tbl_person(address_id, gender_id, fname, lname, birthdate, person_types_id) " +
                                 "values("+ AddressId + ", "+ GenderId + ",'"+dataReader["fname"].ToString().Replace("'","''")+"'," +
                                 "'"+dataReader["lname"].ToString().Replace("'", "''") + "',"+birthdate+",'8')");
                string Max_person_id = GetId("select max(id) from tbl_person", pPostgres);

                // insert into tbl_dancer
                string parent_guardian = (dataReader["parent_guardian"] == "") ? "null" : dataReader["parent_guardian"].ToString();
                string email_parents = (dataReader["email_parents"] == "") ? "null" : dataReader["email_parents"].ToString();
                if (email_parents.Equals("''"))
                {
                    email_parents = "null";
                }
                pPostgres.Insert("insert into tbl_dancer(id, person_id, parent_guardian, email_parents) " +
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

                // insert into tbl_studio has dancer // exception has been deleted

                pPostgres.Insert("insert into tbl_studios_has_dancer(dancer_id, studios_id) values('" + dataReader["id"] + "','" + dataReader["studioid"] + "')");

                // insert tbl_user_has_dancer

            }
            pPostgres.Message = "tbl_dancers - extraction - FINISH";
        }
        private string GetAddressId(string pAddress, string pCity, string pState, string pZip, string pCountryId, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            string p_city_id = GetId("select id from tbl_cities where name like '" + pCity.Replace("'", "''") + "'", pPostgres);
            query = pPostgres.Select("select distinct id " +
                                   "from tbl_addresses where address like '" + pAddress.Replace("'", "''") + "' and city_id = " + p_city_id + " and zip like '" + pZip + "' and country_id='" + pCountryId + "';");
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
                string city_id = GetId("select id from tbl_cities where name like '" + pCity.Replace("'", "''") + "'", pPostgres);
                string pomStateId = GetId("select id from tbl_states where name like '" + pState + "'", pPostgres);
                pPostgres.Insert("insert into tbl_addresses(state_id, address, city_id, zip) values(" + pomStateId + ",'" + pAddress.Replace("'", "''") + "'," + city_id + ",'" + pZip + "');");
                string p_address_id = GetId("select max(id) from tbl_addresses", pPostgres);
                return p_address_id;
            }
            else
            {
                return "null";
            }
        }
    }
}