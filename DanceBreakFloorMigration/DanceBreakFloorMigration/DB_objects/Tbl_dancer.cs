﻿using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_dancer:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            // all dancers related to the any studio...
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_profiles where typeid is null and studioid is not null");
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
                string birthdate = (dataReader["birth_date"] == "") ? "null" : "+" + dataReader["birth_date"] + "'";
                pPostgres.Insert("insert into tbl_person(address_id, gender_id, fname, lname, birthdate, person_types_id) " +
                                 "values("+ AddressId + ", '"+ GenderId + "','"+dataReader["fname"]+"','"+dataReader["lname"]+"',"+birthdate+",'8')");
                string Max_person_id = GetId("select max(person_id) from tbl_person", pPostgres);

                // insert into tbl_dancer
                string parent_guardian = (dataReader["parent_guardian"] == "") ? "null" : "'" + dataReader["parent_guardian"] + "'";
                string email_parents = (dataReader["email_parents"] == "") ? "null" : "'" + dataReader["email_parents"] + "'";
                if (email_parents.Equals("''"))
                {
                    email_parents = "null";
                }
                pPostgres.Insert("insert into tbl_dancer(dancer_id, person_id, parent_guardian, email_parents) " +
                                 "values('" + dataReader["id"] + "','"+Max_person_id+"',"+ parent_guardian + ","+ email_parents +")");
            
                // insert into studio_has_contact_type
                // !!! nech zapisuje iba ked je to naplnene...
                pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type, value)" +
                                 "values("+Max_person_id+",2,'" + dataReader["phone"]+"')");
                pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type, value)" +
                                 "values("+Max_person_id+",2,'" + dataReader["phone2"] + "')");
                pPostgres.Insert("insert into person_has_contact_type(person_id, contact_type, value)" +
                                 "values(" + Max_person_id + ",8,'" + dataReader["fax"] +"')");

                // insert into tbl_studio has dancer
                pPostgres.Insert("insert into tbl_studios_has_dancer(dancer_id, studios_id) values('"+ dataReader["id"] + "','"+ dataReader["studioid"] + "')");

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
        private string GetId(string pParam, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            query = pPostgres.Select(pParam);
            string pom;
            while (query.Read())
            {
                pom = query[0].ToString();
                query.Dispose();
                return pom;
            }
            query.Dispose();
            return "null";
        }


    }
}