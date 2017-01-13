using System;
using System.Windows.Forms;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_orders : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_orders;");
            pMysql.Message = "tbl_store_orders - extraction - START";
            int p_IsUnregistered = 1;
            while (dataReader.Read())
            {
                if (dataReader["userid"].ToString()=="0")
                {
                    string buyerid=UnregisteredBuyerManage(dataReader["fname"].ToString(), dataReader["lname"].ToString(), dataReader["email"].ToString(), pPostgres);
                    pPostgres.Insert("insert into tbl_store_orders(id, user_id, order_hash, submitted, shipped, statsuser, " +
                                     "digitalonly, fees_paid, tracking, transactionid, label) " +
                                     "values('"+dataReader["id"]+"','"+ buyerid + "','"+dataReader["order_hash"]+ "','" + FromUnixTime(Convert.ToInt64(dataReader["submitted"])).ToString().Replace(". ", ".") + "'" +
                                     ",'" + CheckBool(dataReader["shipped"].ToString()) + "','" + dataReader["statsuser"] + "','" + CheckBool(dataReader["digitalonly"].ToString()) + "'," +
                                     "'" + dataReader["fees_paid"] + "','" + dataReader["tracking"] + "','" + dataReader["transactionid"] + "','" +
                                     "" + Get_json_label(CheckBool(dataReader["label_made"].ToString()).ToString(), dataReader["label_cost"].ToString(), dataReader["label_carrier"].ToString()) + "')");
                }
                else
                {
                    pPostgres.Insert("insert into tbl_store_orders(id, user_id, order_hash, submitted, shipped, statsuser, " +
                                     "digitalonly, fees_paid, tracking, transactionid, label) " +
                                     "values('" + dataReader["id"] + "','" + dataReader["userid"] + "','" + dataReader["order_hash"] + "','" + FromUnixTime(Convert.ToInt64(dataReader["submitted"])).ToString().Replace(". ", ".") + "'" +
                                     ",'" + CheckBool(dataReader["shipped"].ToString()) + "','" + dataReader["statsuser"] + "','" + CheckBool(dataReader["digitalonly"].ToString()) + "'," +
                                     "'" + dataReader["fees_paid"] + "','" + dataReader["tracking"] + "','" + dataReader["transactionid"] + "','" +
                                     "" + Get_json_label(CheckBool(dataReader["label_made"].ToString()).ToString(), dataReader["label_cost"].ToString(), dataReader["label_carrier"].ToString()) + "')");
                }
            }
            pPostgres.Message = "tbl_store_orders - extraction - FINISH";
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
            /*
             1. select ID from users based on pemail
             2. if id is not null - make reference on user
             3. else add person and add user
             4. return buyerId - sign into the user_id
             */
            string buyerId = GetId("select id from tbl_user where email like '"+pemail+"' limit 1;", pPostgres);
            string personType = GetId("select id from tbl_person_types where name like 'Other' limit 1;", pPostgres);
            if (buyerId=="null")
            {
                pPostgres.Insert("insert into tbl_person(address_id, gender_id, fname, lname, birthdate, person_types_id) " +
                                 "values(null,null,'"+pname+"','"+lname+"',null, '"+ personType + "') ");
                string Max_person_id = GetId("select max(id) from tbl_person", pPostgres);

                int Max_user_id = Convert.ToInt32(GetId("select max(id) from tbl_user", pPostgres));
                pPostgres.Insert("insert into tbl_user(id, email, password, active, person_id, unregistered) " +
                                 "values('"+ ++Max_user_id + "','"+pemail+"',null,null,'"+Max_person_id+"','1')");

                buyerId = Max_user_id.ToString();
            }
            return buyerId;
        }
    }
}