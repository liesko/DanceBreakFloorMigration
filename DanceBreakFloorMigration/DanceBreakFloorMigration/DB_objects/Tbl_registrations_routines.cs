using System;
using System.Globalization;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_registrations_routines : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_user_registrations_routines;");
            pMysql.Message = "tbl_registrations_routines - extraction - START ";
            while (dataReader.Read())
            {
                string RegId = GetId("select id from tbl_registration  where old_user_reg_id='" + dataReader["regid"] + "' limit 1;", pPostgres);
                string pFee = dataReader["fee"].ToString();
                if (pFee.Length>15)
                {
                    pFee = ReturnNumber(pFee);
                }

                pPostgres.Insert("insert into tbl_registrations_routines(id, registration_id, performance_division_id, routine, routine_category_id, age_division_id, teacher, " +
                                 "type, time, fee, award_type) " +
                                 "values("+dataReader["id"]+", "+ RegId + ", "+dataReader["perfdivisionid"] +", '"+dataReader["routinename"].ToString().Replace("'","''") +"', " +
                                 ""+dataReader["routinecategoryid"] +", "+dataReader["agedivisionid"] +",'"+dataReader["teacher"].ToString().Replace("'","''") +"'," +
                                 "'"+Get_json_type(dataReader["is_finals"].ToString(), dataReader["is_prelims"].ToString(), dataReader["is_vips"].ToString(), dataReader["is_free_ballet"].ToString()) +"'," +
                                 "'"+Get_json_time(dataReader["extended_time"].ToString(), dataReader["extra_time"].ToString()) +"', "+NVL(pFee) + ",'"+dataReader["routine_awardtype"].ToString().Replace("'","''") +"');");
            }
            pPostgres.Insert("insert into tbl_registrations_routines(id, routine) values(118,'DUMMY');");
            pPostgres.Insert("insert into tbl_registrations_routines(id, routine) values(83269,'DUMMY');");

            pPostgres.Insert("insert into tbl_registrations_routines(id, routine) values(43491,'DUMMY');");
            pPostgres.Insert("insert into tbl_registrations_routines(id, routine) values(102887,'DUMMY');");

            pPostgres.Message = "tbl_registrations_routines - extraction - FINISH";
        }
        private string Get_json_type(string pFinals, string pPrelims, string pVips, string pFree_ballet)
        {
            dynamic type = new JObject();
            type.finals = pFinals;
            type.prelims = pPrelims;
            type.vips = pVips;
            type.free_ballet = pFree_ballet;
            return type.ToString();
        }
        private string Get_json_time(string pExtended, string pExtra)
        {
            dynamic time = new JObject();
            time.extended = pExtended;
            time.prelims = pExtra;
            return time.ToString();
        }
        public  string ReturnNumber(string param)
        {
            string test = param;
            test = test.Replace(" ", "");
            string tag = "<br/>";
            int first = test.LastIndexOf(tag) + tag.Length;
            double res = Convert.ToDouble(test.Substring(first), CultureInfo.InvariantCulture);
            return test.Substring(first).ToString();
        }
    }
}