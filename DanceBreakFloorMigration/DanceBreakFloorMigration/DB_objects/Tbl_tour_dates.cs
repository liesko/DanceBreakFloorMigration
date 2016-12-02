using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_tour_dates : IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select id, seasonid, eventid, stateid, cast(perfdivtype as char)," +
                                                       "cast(web_workshop as char), cast(web_competition as char), cast(web_playlist as char), cast(web_results as char), cast(web_city_webcast_banner as char), cast(web_no_competition as char), cast(web_videos as char), cast(web_personalpdfs as char)," +
                                                       "cast(entrylimit_total as char), cast(entrylimit_solos as char), cast(entrylimit_duotrios as char), cast(entrylimit_groups as char), cast(entrylimit_onesolo as char), cast(entrylimit_sologroup as char)," +
                                                       "cast(mybtfregenabled as char), cast(mybtf_no_competition as char), cast(mybtf_photovideo_active as char), " +
                                                       "hotel_name, hotel_website, hotel_address, hotel_city, hotel_stateid, hotel_zip, hotel_phone" +
                                                       " from tbl_tour_dates;");
            pMysql.Message = "tbl_tour_dates - extraction - START";
            while (dataReader.Read())
            {
                try
                {
                    pPostgres.Insert("insert into tbl_tour_dates(tour_dates_id, season_id, events_id, state_id, performance_divisions_id, json_web_info, json_entry_info, json_mybtf, hotel_id) " +
                                "values('" + dataReader[0] + "','" + dataReader[1] + "','" + dataReader[2] + "','" + dataReader[3] + "','" + dataReader[4] + "'," +
                                     "'" + Get_json_web_info(dataReader[5].ToString(), dataReader[6].ToString(), dataReader[7].ToString(), dataReader[8].ToString(), dataReader[9].ToString(), dataReader[10].ToString(), dataReader[11].ToString(), dataReader[12].ToString()) + "','" +
                                     "" + Get_json_entry_info(dataReader[13].ToString(), dataReader[14].ToString(), dataReader[15].ToString(), dataReader[16].ToString(), dataReader[17].ToString(), dataReader[18].ToString()) + "','" +
                                     "" + Get_json_mybtf(dataReader[19].ToString(), dataReader[20].ToString(), dataReader[21].ToString()) + "'," +
                                     "" + GetHotelId(dataReader[22].ToString(), dataReader[23].ToString(), dataReader[24].ToString(), dataReader[25].ToString(), dataReader[26].ToString(), dataReader[27].ToString(), dataReader[28].ToString(), pPostgres) + ");");
                }
                catch (Exception)
                {

                    pPostgres.Message = "tbl_tour_dates INVALID INSERT:insert into tbl_tour_dates(tour_dates_id, season_id, events_id, state_id, performance_divisions_id, json_web_info, json_entry_info, json_mybtf, hotel_id) " +
                                "values('" + dataReader[0] + "','" + dataReader[1] + "','" + dataReader[2] + "','" + dataReader[3] + "','" + dataReader[4] + "'," +
                                     "'" + Get_json_web_info(dataReader[5].ToString(), dataReader[6].ToString(), dataReader[7].ToString(), dataReader[8].ToString(), dataReader[9].ToString(), dataReader[10].ToString(), dataReader[11].ToString(), dataReader[12].ToString()) + "','" +
                                     "" + Get_json_entry_info(dataReader[13].ToString(), dataReader[14].ToString(), dataReader[15].ToString(), dataReader[16].ToString(), dataReader[17].ToString(), dataReader[18].ToString()) + "','" +
                                     "" + Get_json_mybtf(dataReader[19].ToString(), dataReader[20].ToString(), dataReader[21].ToString()) + "'," +
                                     "" + GetHotelId(dataReader[22].ToString(), dataReader[23].ToString(), dataReader[24].ToString(), dataReader[25].ToString(), dataReader[26].ToString(), dataReader[27].ToString(), dataReader[28].ToString(), pPostgres) + ");";
                }

            }
            pPostgres.Message = "tbl_tour_dates - extraction - FINISH";
        }

        private string Get_json_web_info(string p_web_workshop, string p_web_competition, string p_web_playlist, string p_web_results, string p_web_city_webcast_banner, string p_web_no_competition, string p_web_videos, string p_web_personalpdfs)
        {
            dynamic json_web_info = new JObject();
            json_web_info.web_workshop = p_web_workshop;
            json_web_info.web_competition = p_web_competition;
            json_web_info.web_playlist = p_web_playlist;
            json_web_info.web_results = p_web_results;
            json_web_info.web_city_webcast_banner = p_web_city_webcast_banner;
            json_web_info.web_no_competition = p_web_no_competition;
            json_web_info.web_videos = p_web_videos;
            json_web_info.web_personalpdfs = p_web_personalpdfs;
            return json_web_info.ToString();
        }

        private string Get_json_entry_info(string p_entrylimit_total, string p_entrylimit_solos, string p_entrylimit_duotrios, string p_entrylimit_groups, string p_entrylimit_onesolo, string p_entrylimit_sologroup)
        {
            dynamic json_entry_info = new JObject();
            json_entry_info.entrylimit_total = p_entrylimit_total;
            json_entry_info.entrylimit_solos = p_entrylimit_solos;
            json_entry_info.entrylimit_duotrios = p_entrylimit_duotrios;
            json_entry_info.entrylimit_groups = p_entrylimit_groups;
            json_entry_info.entrylimit_onesolo = p_entrylimit_onesolo;
            json_entry_info.entrylimit_sologroup = p_entrylimit_sologroup;
            return json_entry_info.ToString();
        }

        private string Get_json_mybtf(string p_mybtfregenabled, string p_mybtf_no_competition, string p_mybtf_photovideo_active)
        {
            dynamic json_myftf = new JObject();
            json_myftf.mybtfregenabled = p_mybtfregenabled;
            json_myftf.mybtf_no_competition = p_mybtf_no_competition;
            json_myftf.mybtf_photovideo_active = p_mybtf_photovideo_active;
            return json_myftf.ToString();
        }

        private string GetHotelId(string p_hotel_name, string p_hotel_website, string p_hotel_address, string p_hotel_city, string p_hotel_stateid, string p_hotel_zip, string p_hotel_phone, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            query = pPostgres.Select("select distinct hotel_id " +
                                   "from tbl_hotel where name like '" + p_hotel_name + "' and hotel_website like '%" + p_hotel_website + "%';");
            string pom;
            while (query.Read())
            {
                pom = query[0].ToString();
                query.Dispose();
                return pom;
            }
            query.Dispose();
            if (p_hotel_name != "")
            {
                pPostgres.Insert("insert into tbl_address(state_id, address, city, zip) values('" + p_hotel_stateid + "','" + p_hotel_address + "','" + p_hotel_city + "','" + p_hotel_zip + "');");
                string p_address_id = GetId("select max(address_id) from tbl_address", pPostgres);
                pPostgres.Insert("insert into tbl_hotel(name, hotel_website, address_id) values('" + p_hotel_name + "','" + p_hotel_website + "','" + p_address_id + "');");
                string p_hotel_id = GetId("select max(hotel_id) from tbl_hotel", pPostgres);
                pPostgres.Insert("insert into hotel_contact_type(contact_type_id, hotel_id, value) values('2','" + p_hotel_id + "','" + p_hotel_phone + "');");
                return "'"+p_hotel_id+"'";
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
                return pom;
            }
            query.Dispose();
            return null;
        }
    }
}