using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_online_critiques_judges:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_online_critiques_judges;");
            pMysql.Message = "tbl_online_critiques_judges - extraction - START";
            while (dataReader.Read())
            {
                try
                {
                    pPostgres.Insert(
                        "insert into tbl_online_critiques_judges(online_critiques_judges_id, tour_dates_id, startnumber, startnumberhasa, endnumber, endnumberhasa, judge, compgroup) " +
                        "values('" + dataReader["id"] + "','" + dataReader["tourdateid"] + "','" + dataReader["startnumber"] + "'," +
                        "'" + CheckBool(dataReader["startnumberhasa"].ToString()) + "','" + dataReader["endnumber"] + "','" + CheckBool(dataReader["endnumberhasa"].ToString()) + "" +
                        "','"+Get_json_judge(dataReader["judge1"].ToString(), dataReader["judge2"].ToString(), dataReader["judge3"].ToString(), dataReader["judge4"].ToString())  +"'," +
                        "'"+dataReader["compgroup"] +"');");
                }
                catch (Exception)
                {

                    pPostgres.Message = "INVALID INSERT: insert into tbl_online_critiques_judges(online_critiques_judges_id, tour_dates_id, startnumber, startnumberhasa, endnumber, endnumberhasa, judge, compgroup) " +
                        "values('" + dataReader["id"] + "','" + dataReader["tourdateid"] + "','" + dataReader["startnumber"] + "'," +
                        "'" + CheckBool(dataReader["startnumberhasa"].ToString()) + "','" + dataReader["endnumber"] + "','" + CheckBool(dataReader["endnumberhasa"].ToString()) + "" +
                        "','" + Get_json_judge(dataReader["judge1"].ToString(), dataReader["judge2"].ToString(), dataReader["judge3"].ToString(), dataReader["judge4"].ToString()) + "'," +
                        "'" + dataReader["compgroup"] + "');";
                }

            }
            pPostgres.Message = "tbl_online_critiques_judges - extraction - FINISH";
        }
        private int CheckBool(string pValue)
        {
            if (pValue == "True")
            {
                return 1;
            }
            return 0;
        }
        private string Get_json_judge(string pjudge1, string pjudge2, string pjudge3, string pjudge4)
        {
            dynamic judge = new JObject();
            judge.judge1 = pjudge1;
            judge.judge2 = pjudge2;
            judge.judge3 = pjudge3;
            judge.judge4 = pjudge4;
            return judge.ToString();
        }
    }
}