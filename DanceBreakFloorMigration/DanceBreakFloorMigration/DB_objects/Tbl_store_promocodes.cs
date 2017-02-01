using System;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.Classes
{
    public class Tbl_store_promocodes : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_promocodes;");
            pMysql.Message = "tbl_store_promocodes - extraction - START ";
            while (dataReader.Read())
            {
                string TypeId = GetId("select id, name from tbl_promo_codes_type where name like '"+dataReader["type"]+"';", pPostgres);
                pPostgres.Insert("insert into tbl_store_promocodes(id, name, description, value, charges, uses, active, expires, promo_codes_type_id) " +
                                 "values("+dataReader["id"]+ ",'" + dataReader["name"] + "','" + dataReader["description"] + "'" +
                                 "," + dataReader["value"] + "," + dataReader["charges"] + "," + dataReader["uses"] + "" +
                                 "," + dataReader["active"] + ",'"+FromUnixTime(Convert.ToInt64(dataReader["expires"]))+"'," + TypeId + ");");
            }

            pPostgres.Message = "tbl_store_promocodes - extraction - FINISH";
        }
    }
}