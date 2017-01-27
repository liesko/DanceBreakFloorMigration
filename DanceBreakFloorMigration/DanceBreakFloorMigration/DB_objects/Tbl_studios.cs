using System;
using System.Linq;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_studios : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_studios;");
            pMysql.Message = "tbl_studios - extraction - START";
            while (dataReader.Read())
            {
                string notes = (dataReader["notes"].ToString() == "") ? "null" : "'" + dataReader["notes"].ToString().Replace(Environment.NewLine, "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "") + "'";
                string contacts = (dataReader["contacts"].ToString() == "") ? "null" : "'" + dataReader["contacts"].ToString().Replace("'", "''").Replace(Environment.NewLine, "").Replace("\r\n", "").Replace("\r", "").Replace("\n", "") + "'";
                pPostgres.Insert("insert into tbl_studios(id, name, notes, contacts, address_id) " +
                                "values('" + dataReader["id"] + "','" + dataReader["name"].ToString().Replace("'", "''") + "',"+notes+ ","+ contacts + "" +
                                 ","+GetAddressId(dataReader["address"].ToString(), dataReader["city"].ToString(), dataReader["state"].ToString(), 
                                 dataReader["zip"].ToString(), dataReader["countryid"].ToString(), pPostgres) + ");");

                InsertContacts(dataReader["phone"].ToString(), dataReader["phone2"].ToString(), dataReader["fax"].ToString(), dataReader["email"].ToString(), dataReader["id"].ToString(), pPostgres);

            }
            pPostgres.Message = "tbl_studios - extraction - FINISH";
            DummyStudioCreation(pMysql, pPostgres);
            ;
        }

        private string GetAddressId(string pAddress, string pCity, string pState, string pZip, string pCountryId, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            string p_city_id = GetId("select id from tbl_cities where name like '" + pCity.Replace("'", "''") + "'", pPostgres);
            query = pPostgres.Select("select distinct id " +
                                   "from tbl_addresses where address like '" + pAddress.Replace("'", "''") + "' and city_id = " + p_city_id + " and zip like '"+pZip+"' and country_id='"+pCountryId+"';");
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
        public static string Remove(string source, char[] oldChar)
        {
            return String.Join("", source.ToCharArray().Where(a => !oldChar.Contains(a)).ToArray());
        }

        private void InsertContacts(string pPhone, string pPhone2, string pFax, string pEmail, string pStudioId, PostgreSQL_DB pPostgres)
        {
            var c = new[] { '(', ')', '-', ' ' };

            if (pPhone != "")
                pPostgres.Insert("insert into tbl_studio_contacts(contact_type_id, studios_id, value) values('" + 2 + "','" + pStudioId + "','" + Remove(pPhone, c) + "');");
            if (pPhone2 != "")
                pPostgres.Insert("insert into tbl_studio_contacts(contact_type_id, studios_id, value) values('" + 2 + "','" + pStudioId + "','" + Remove(pPhone2, c) + "');");
            if (pFax != "")
                pPostgres.Insert("insert into tbl_studio_contacts(contact_type_id, studios_id, value) values('" + 8 + "','" + pStudioId + "','" + Remove(pFax, c) + "');");
            if (pEmail != "")
                pPostgres.Insert("insert into tbl_studio_contacts(contact_type_id, studios_id, value) values('" + 1 + "','" + pStudioId + "','" + pEmail.Replace("'","''") + "');");
        }

        private void DummyStudioCreation(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct studioid from tbl_profiles where studioid not in (select id from tbl_studios);");
            pMysql.Message = "DUMMY tbl_studios - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_studios(id, name) values('"+dataReader[0]+"','DUMMY DANCE STUDIO')");

            }
            pPostgres.Message = "DUMMY tbl_studios - extraction - FINISH";
        }
    }
}