using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_routines : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_routines;");
            pMysql.Message = "tbl_date_routines - extraction - START";
            while (dataReader.Read())
            {
                string award_typename= string.IsNullOrWhiteSpace(dataReader["award_typename"].ToString()) ? "null" : "'"+dataReader["award_typename"].ToString().Replace("'", "''") + "'";
                string fee = string.IsNullOrWhiteSpace(dataReader["fee"].ToString()) ? "null" : dataReader["fee"].ToString();
                pPostgres.Insert("insert into tbl_date_routines(id, tour_dates_id, routine_id, studios_id, age_divisions_id, category_id, " +
                                 "performance_divisions_id, perf_div_type_id, routine_types_id, fee, canceled, custom_dancer_count, duration, " +
                                 "custom_fee, place_hsa, place_hsp, award_typename, uploaded_duration, extra_time, uploaded, prelims, vips, finals) " +
                                 "values("+dataReader["id"] + "," + dataReader["tourdateid"] + "," + dataReader["routineid"] + "," + dataReader["studioid"] + "," + dataReader["agedivisionid"] + "," +
                                 "" + dataReader["routinecategoryid"] + ","+ dataReader["perfcategoryid"] + " , "+ CheckBool(dataReader["perfdivtype"].ToString()) + "," + dataReader["routinetypeid"] + "," + fee + "," +CheckBool(dataReader["canceled"].ToString()) + "," +
                                 "" + dataReader["custom_dancer_count"] + "," + dataReader["duration"] + "," +CheckBool(dataReader["custom_fee"].ToString()) + "," + dataReader["place_hsa"] + "," + dataReader["place_hsp"] + "," +
                                 "" + award_typename + ",'" + dataReader["uploaded_duration"] + "'," + dataReader["extra_time"] + "," +CheckBool(dataReader["uploaded"].ToString()) + "" +
                                 ",'"+Get_json_Prelims(dataReader["prelims"].ToString(), dataReader["prelims_score1"].ToString(), dataReader["prelims_score2"].ToString(), dataReader["prelims_score3"].ToString(), dataReader["prelims_score4"].ToString(), 
                                 dataReader["prelims_score5"].ToString(), dataReader["prelims_score6"].ToString(), dataReader["prelims_awardid"].ToString(), dataReader["prelims_total_score"].ToString(), dataReader["prelims_dropped_score"].ToString(), 
                                 dataReader["prelims_time"].ToString(), dataReader["number_prelims"].ToString(), dataReader["prelims_has_a"].ToString(), dataReader["prelims_dropped_score2"].ToString(), 
                                 dataReader["room_prelims"].ToString())+ "'" +
                                  ",'"+Get_json_VIP(dataReader["vips"].ToString(), dataReader["vips_score1"].ToString(), dataReader["vips_score2"].ToString(), dataReader["vips_score3"].ToString(), 
                                  dataReader["vips_score4"].ToString(), dataReader["vips_score5"].ToString(), dataReader["vips_score6"].ToString(), dataReader["vips_awardid"].ToString(), 
                                  dataReader["vips_dropped_score"].ToString(), dataReader["vips_total_score"].ToString(), dataReader["vips_time"].ToString(), dataReader["vips_dropped_score2"].ToString(), 
                                  dataReader["number_vips"].ToString(), dataReader["vips_has_a"].ToString(), dataReader["room_vips"].ToString()) +"'" +
                                 ",'"+Get_json_final(dataReader["finals"].ToString(), dataReader["finals_score1"].ToString(), dataReader["finals_score2"].ToString(), dataReader["finals_score3"].ToString(), 
                                 dataReader["finals_score4"].ToString(), dataReader["finals_score5"].ToString(), dataReader["finals_score6"].ToString(), dataReader["finals_awardid"].ToString(), 
                                 dataReader["finals_total_score"].ToString(), dataReader["finals_dropped_score"].ToString(), dataReader["finals_time"].ToString(), dataReader["number_finals"].ToString(), 
                                 dataReader["finals_dropped_score2"].ToString(), dataReader["finals_has_a"].ToString(), dataReader["room_finals"].ToString()) +"')");
            }
            pPostgres.Message = "tbl_date_routines - extraction - FINISH";
        }

        private string Get_json_final(string pfinals, string pfinals_score1, string pfinals_score2, string pfinals_score3, string pfinals_score4, string pfinals_score5, string pfinals_score6, string pfinals_awardid, string pfinals_total_score, string pfinals_dropped_score, string pfinals_time, string pnumber_finals, string pfinals_dropped_score2, string pfinals_has_a, string proom_finals)
        {
            dynamic finals = new JObject();
            finals.finals = pfinals;
            finals.finals_score1 = pfinals_score1;
            finals.finals_score2 = pfinals_score2;
            finals.finals_score3 = pfinals_score3;
            finals.finals_score4 = pfinals_score4;
            finals.finals_score5 = pfinals_score5;
            finals.finals_score6 = pfinals_score6;
            finals.finals_awardid = pfinals_awardid;
            finals.finals_total_score = pfinals_total_score;
            finals.finals_dropped_score = pfinals_dropped_score;
            finals.finals_time = pfinals_time;
            finals.number_finals = pnumber_finals;
            finals.finals_dropped_score2 = pfinals_dropped_score2;
            finals.finals_has_a = pfinals_has_a;
            finals.room_finals = proom_finals;
            return finals.ToString();
        }

        private string Get_json_VIP(string pvips, string pvips_score1, string pvips_score2, string pvips_score3, string pvips_score4, string pvips_score5, string pvips_score6, string pvips_awardid, string pvips_dropped_score, string pvips_total_score, string pvips_time, string pvips_dropped_score2, string pnumber_vips, string pvips_has_a, string proom_vips)
        {
            dynamic vip = new JObject();
            vip.vips = pvips;
            vip.vips_score1 = pvips_score1;
            vip.vips_score2= pvips_score2;
            vip.vips_score3= pvips_score3;
            vip.vips_score4= pvips_score4;
            vip.vips_score5= pvips_score5;
            vip.vips_score6= pvips_score6;
            vip.vips_awardid = pvips_awardid;
            vip.vips_dropped_score = pvips_dropped_score;
            vip.vips_total_score = pvips_total_score;
            vip.vips_time = pvips_time;
            vip.vips_dropped_score2 = pvips_dropped_score2;
            vip.number_vips = pnumber_vips;
            vip.vips_has_a = pvips_has_a;
            vip.room_vips = proom_vips;
            return vip.ToString();
        }

        private string Get_json_Prelims(string pprelims, string pprelims_score1, string pprelims_score2, string pprelims_score3, string pprelims_score4, string pprelims_score5, string pprelims_score6, string pprelims_awardid, string pprelims_total_score, string pprelims_dropped_score, string pprelims_time, string pnumber_prelims, string pprelims_has_a, string pprelims_dropped_score2, string proom_prelims)
        {
            dynamic prelims = new JObject();
            prelims.prelims = pprelims;
            prelims.prelims_score1 = pprelims_score1;
            prelims.prelims_score2= pprelims_score2;
            prelims.prelims_score3= pprelims_score3;
            prelims.prelims_score4= pprelims_score4;
            prelims.prelims_score5= pprelims_score5;
            prelims.prelims_score6= pprelims_score6;
            prelims.prelims_awardid = pprelims_awardid;
            prelims.prelims_total_score = pprelims_total_score;
            prelims.prelims_dropped_score = pprelims_dropped_score;
            prelims.prelims_time = pprelims_time;
            prelims.number_prelims = pnumber_prelims;
            prelims.prelims_has_a = pprelims_has_a;
            prelims.prelims_dropped_score2 = pprelims_dropped_score2;
            prelims.room_prelims = proom_prelims;
            return prelims.ToString();
        }

    }
}