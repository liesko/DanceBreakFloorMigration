using System;
using System.Windows.Forms;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_orders:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_orders;");
            pMysql.Message = "tbl_store_orders - extraction - START";
            while (dataReader.Read())
            {
                if (dataReader["userid"].ToString()=="0")
                {
                    string buyerid=UnregisteredBuyerManage(dataReader["fname"].ToString(), dataReader["lname"].ToString(), dataReader["email"].ToString(), pPostgres);
                    pPostgres.Insert("insert into tbl_store_orders(store_orders_id, user_id, unregistered_buyer_id, order_hash, submitted, shipped, statsuser, " +
                                     "digitalonly, fees_paid, tracking, transactionid, label) " +
                                     "values('"+dataReader["id"]+"',null,'"+ buyerid + "','"+dataReader["order_hash"]+ "','" + FromUnixTime(Convert.ToInt64(dataReader["submitted"])).ToString().Replace(". ", ".") + "'" +
                                     ",'" + CheckBool(dataReader["shipped"].ToString()) + "','" + dataReader["statsuser"] + "','" + CheckBool(dataReader["digitalonly"].ToString()) + "'," +
                                     "'" + dataReader["fees_paid"] + "','" + dataReader["tracking"] + "','" + dataReader["transactionid"] + "','" +
                                     "" + Get_json_label(CheckBool(dataReader["label_made"].ToString()).ToString(), dataReader["label_cost"].ToString(), dataReader["label_carrier"].ToString()) + "')");
                }
                else
                {
                    pPostgres.Insert("insert into tbl_store_orders(store_orders_id, user_id, unregistered_buyer_id, order_hash, submitted, shipped, statsuser, " +
                                     "digitalonly, fees_paid, tracking, transactionid, label) " +
                                     "values('" + dataReader["id"] + "','" + dataReader["userid"] + "',null,'" + dataReader["order_hash"] + "','" + FromUnixTime(Convert.ToInt64(dataReader["submitted"])).ToString().Replace(". ", ".") + "'" +
                                     ",'" + CheckBool(dataReader["shipped"].ToString()) + "','" + dataReader["statsuser"] + "','" + CheckBool(dataReader["digitalonly"].ToString()) + "'," +
                                     "'" + dataReader["fees_paid"] + "','" + dataReader["tracking"] + "','" + dataReader["transactionid"] + "','" +
                                     "" + Get_json_label(CheckBool(dataReader["label_made"].ToString()).ToString(), dataReader["label_cost"].ToString(), dataReader["label_carrier"].ToString()) + "')");
                }
            }
            pPostgres.Message = "tbl_store_orders - extraction - FINISH";
        }
        private int CheckBool(string pValue)
        {
            if (pValue == "True")
            {
                return 1;
            }
            return 0;
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
        private string Get_json_label(string label_made, string label_cost, string label_carrier)
        {
            dynamic label = new JObject();
            label.label_made = label_made;
            label.label_cost = label_cost;
            label.label_carrier = label_carrier;
            return label.ToString();
        }

        private string UnregisteredBuyerManage(string pname, string lname, string pemail, PostgreSQL_DB pPostgres)
        {
            string buyerId = GetId("select unregistered_buyer_id from tbl_unregistered_buyer where fname like '"+pname+"' and lname like '"+lname+"' and email like '"+pemail+"';", pPostgres);
            if (buyerId=="null")
            {
                pPostgres.Insert("insert into tbl_unregistered_buyer(fname, lname, email) values('"+pname+"','"+lname+"','"+pemail+"')");
                buyerId = GetId("select unregistered_buyer_id from tbl_unregistered_buyer where fname like '" + pname + "' and lname like '" + lname + "' and email like '" + pemail + "';", pPostgres);
            }
            return buyerId;
        }
        public DateTime FromUnixTime(long unixTime)
        {
            var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            return epoch.AddSeconds(unixTime);
        }
    }
}