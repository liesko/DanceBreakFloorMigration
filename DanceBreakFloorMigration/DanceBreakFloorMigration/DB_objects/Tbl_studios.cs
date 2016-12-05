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
                                 ","+GetAddressId(dataReader["address"].ToString(), dataReader["city"].ToString(), dataReader["state"].ToString(), dataReader["zip"].ToString(), dataReader["countryid"].ToString(), pPostgres) + ");");

            }
            pPostgres.Message = "tbl_studios - extraction - FINISH";
        }

        private string GetAddressId(string pAddress, string pCity, string pState, string pZip, string pCountryId , PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            query = pPostgres.Select("select distinct address_id " +
                                   "from tbl_address where address like '" + pAddress.Replace("'", "''") + "' and city like '" + pCity.Replace("'", "''") + "' and zip like '"+pZip+"' and country_id='"+pCountryId+"';");
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
                string pomStateId = GetId("select state_id from tbl_states where name like '" + pState + "'", pPostgres);
                pPostgres.Insert("insert into tbl_address(state_id, address, city, zip) values(" + pomStateId + ",'" + pAddress.Replace("'", "''") + "','" + pCity.Replace("'","''") + "','" + pZip + "');");
                string p_address_id = GetId("select max(address_id) from tbl_address", pPostgres);
                // insert for contacts-studio!!!
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
                return "'"+pom+"'";
            }
            query.Dispose();
            return "null";
        }
    }
}