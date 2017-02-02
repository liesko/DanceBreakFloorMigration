using System;
using System.IO;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_products : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_products;");
            pMysql.Message = "tbl_store_products - extraction - START";

            pPostgres.Insert("insert into tbl_store_products(id, product) values(1, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(6, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(7, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(8, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(9, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(12, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(2, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(4, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(32, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(31, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(30, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(34, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(35, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(36, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(37, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(38, 'DUMMY');");            
            pPostgres.Insert("insert into tbl_store_products(id, product) values(39, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(40, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(41, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(44, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(45, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(10, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(54, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(55, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(5759, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(60, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(61, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(62, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(63, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(64, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(65, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(11, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(58, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(71, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(79, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(72, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(80, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(73, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(70, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(74, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(75, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(76, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(77, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(56, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(3, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(114, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(133, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(33, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(53, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(57, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(59, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_products(id, product) values(198, 'DUMMY');");

            while (dataReader.Read())
            {
                string tourdateid = (dataReader["tourdateid"].ToString() == "")? "null": dataReader["tourdateid"].ToString();
                string eventid = (dataReader["eventid"].ToString() == "") ? "null" : dataReader["eventid"].ToString();
                pPostgres.Insert(
                    "insert into tbl_store_products(id, tour_dates_id, events_id, product_subtypes_id, product, description, price, shipping, featured, timeadded, " +
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
    }
}