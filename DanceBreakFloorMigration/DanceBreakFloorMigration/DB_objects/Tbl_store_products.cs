using System;
using System.IO;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_products:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_products;");
            pMysql.Message = "tbl_store_products - extraction - START";
            while (dataReader.Read())
            {
                string tourdateid = (dataReader["tourdateid"].ToString() == "")? "null": dataReader["tourdateid"].ToString();
                string eventid = (dataReader["eventid"].ToString() == "") ? "null" : dataReader["eventid"].ToString();
                pPostgres.Insert(
                    "insert into tbl_store_products(store_products_id, tour_dates_id, events_id, product_subtypes_id, product, description, price, shipping, featured, timeadded, " +
                    "instock, showonsite, onsale, sale_price, weight, trending, short_description, sort) " +
                    "values(" + dataReader["id"]+ "," + tourdateid + "," + eventid + "," + dataReader["subtypeid"] + ",'" + dataReader["product"].ToString().Replace("'","''") + "'," +
                    "'" + dataReader["description"].ToString().Replace("'", "''") +"','" + dataReader["price"] + "','" + dataReader["shipping"] + "'," +
                    "" + CheckBool(dataReader["featured"].ToString()) + ",'" + FromUnixTime(Convert.ToInt64(dataReader["timeadded"])).ToString().Replace(". ",".") + "'," + CheckBool(dataReader["instock"].ToString()) + "," +
                    ""+ CheckBool(dataReader["showonsite"].ToString()) +"," + CheckBool(dataReader["onsale"].ToString()) + ",'" + dataReader["sale_price"] + "','" + dataReader["weight"].ToString().Replace(",",".") + "'," +
                    "" + CheckBool(dataReader["trending"].ToString()) + "," +
                    "'" + dataReader["short_description"].ToString().Replace("'","''") + "'," + dataReader["sort"]+");");
            }
            pPostgres.Message = "tbl_store_products - extraction - FINISH";
        }
        private int CheckBool(string pValue)
        {
            if (pValue == "True")
            {
                return 1;
            }
            return 0;
        }
        public DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
    }
}