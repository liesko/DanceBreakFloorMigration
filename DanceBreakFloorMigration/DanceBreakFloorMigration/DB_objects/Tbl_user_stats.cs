using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_user_stats : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_user_stats;");
            pMysql.Message = "tbl_user_stats - extraction - START";
            while (dataReader.Read())
            {
                string time_signup=(dataReader["time_signup"].ToString()=="")? "null" : "'"+FromUnixTime(Convert.ToInt64(dataReader["time_signup"])).ToString().Replace(". ", ".")+"'";
                string time_activate = (dataReader["time_activate"].ToString() == "")? "null" : "'" + FromUnixTime(Convert.ToInt64(dataReader["time_activate"])).ToString().Replace(". ", ".") + "'";
                string time_last_login = (dataReader["time_last_login"].ToString() == "")? "null" : "'" + FromUnixTime(Convert.ToInt64(dataReader["time_last_login"])).ToString().Replace(". ", ".") + "'";
                string time_disable = (dataReader["time_disable"].ToString() == "")? "null" : "'" + FromUnixTime(Convert.ToInt64(dataReader["time_disable"])).ToString().Replace(". ", ".") + "'";

                pPostgres.Insert("insert into tbl_user_stats(id, user_id, activation_code, time_signup, time_activate, time_last_login, time_disable, login_count, ips, dontshow1) " +
                                 "values('"+dataReader["id"]+"','"+dataReader["userid"] +"','"+dataReader["activation_code"] +"'," +
                                 "" + time_signup + "," + time_activate + "," +
                                 "" + time_last_login + "," + time_disable + "," +
                                 "" + dataReader["login_count"] + ",'" + dataReader["ips"] + "'," +
                                 "'" + CheckBool(dataReader["dontshow1"].ToString()) + "')");
            }
            pPostgres.Message = "tbl_user_stats - extraction - FINISH";
        }
    }
}