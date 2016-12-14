using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_studios:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_studios;");
            pMysql.Message = "tbl_studios - extraction - START";
            string pom;
            while (dataReader.Read())
            {
                string notes = (dataReader["notes"] == "") ? "null" : "'" + dataReader["notes"] + "'";
                string contacts = (dataReader["contacts"] == "") ? "null" : "'" + dataReader["contacts"].ToString().Replace("'", "''") + "'";
                pPostgres.Insert("insert into tbl_studios(studios_id, name, notes, contacts, address_id) " +
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
            string p_city_id = GetId("select city_id from tbl_city where name like '"+ pCity.Replace("'", "''") + "'", pPostgres);
            query = pPostgres.Select("select distinct address_id " +
                                   "from tbl_address where address like '" + pAddress.Replace("'", "''") + "' and city_id = " + p_city_id + " and zip like '"+pZip+"' and country_id='"+pCountryId+"';");
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

        private void InsertContacts(string pPhone, string pPhone2, string pFax, string pEmail, string pStudioId, PostgreSQL_DB pPostgres)
        {
            if (pPhone != "")
                pPostgres.Insert("insert into tbl_studio_contacts(contact_type_id, studios_id, value) values('" + 2 + "','" + pStudioId + "','" + pPhone + "');");
            if (pPhone2 != "")
                pPostgres.Insert("insert into tbl_studio_contacts(contact_type_id, studios_id, value) values('" + 2 + "','" + pStudioId + "','" + pPhone2 + "');");
            if (pFax != "")
                pPostgres.Insert("insert into tbl_studio_contacts(contact_type_id, studios_id, value) values('" + 8 + "','" + pStudioId + "','" + pFax + "');");
            if (pEmail != "")
                pPostgres.Insert("insert into tbl_studio_contacts(contact_type_id, studios_id, value) values('" + 1 + "','" + pStudioId + "','" + pEmail.Replace("'","''") + "');");
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

        private void DummyStudioCreation(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct studioid from tbl_profiles where studioid not in (select id from tbl_studios);");
            pMysql.Message = "DUMMY tbl_studios - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_studios(studios_id, name) values('"+dataReader[0]+"','DUMMY DANCE STUDIO')");

            }
            pPostgres.Message = "DUMMY tbl_studios - extraction - FINISH";
        }
    }
}