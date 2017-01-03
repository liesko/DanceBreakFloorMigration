using System;
using System.Linq;
using System.Net;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;
using Npgsql;
using Microsoft.VisualBasic;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_tour_dates : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select id, seasonid, eventid, stateid, cast(perfdivtype as char) as perfdivtype," +
                                                       "cast(web_workshop as char), cast(web_competition as char), cast(web_playlist as char), cast(web_results as char), cast(web_city_webcast_banner as char), cast(web_no_competition as char), cast(web_videos as char), cast(web_personalpdfs as char)," +
                                                       "cast(entrylimit_total as char), cast(entrylimit_solos as char), cast(entrylimit_duotrios as char), cast(entrylimit_groups as char), cast(entrylimit_onesolo as char), cast(entrylimit_sologroup as char)," +
                                                       "cast(mybtfregenabled as char), cast(mybtf_no_competition as char), cast(mybtf_photovideo_active as char), " +
                                                       "hotel_name, hotel_website, hotel_address, hotel_city, hotel_stateid, hotel_zip, hotel_phone, " +
                                                       "venue_name, venue_address, venue_city, venue_stateid, venue_zip, venue_phone, venue_website, " +
                                                       "city, start_date, end_date, cutoff_date, cutoff_date2, room_rate, notes, is_finals,  entry_limits, weather_link, hotel_alt, " +
                                                       "custom_routine_durations, default_category_order, routine_dist, roomreservations, webcast_this_city, " +
                                                       "hotel_notes, online_balance_payments_enabled, event_date_status, show_time, use_online_scoring" +
                                                       " from tbl_tour_dates;");
            pMysql.Message = "tbl_tour_dates - extraction - START";
            while (dataReader.Read())
            {
                string state = (dataReader["stateid"] == "") ? "'"+dataReader["stateid"]+"'": "null";
                try
                {
                    pPostgres.Insert("insert into tbl_tour_dates(id, season_id, events_id, state_id, performance_divisions_id, web, entrylimit, mybtf, hotel_id, venue_id, " +
                                     "start_date, end_date, cutoff_start_date, cutoff_end_date, room_rate, notes, is_finals,  entry_limits, weather_link, hotel_alt, custom_routine_durations, " +
                                     "default_category_order, routine_dist, roomreservations, webcast_this_city, hotel_notes, online_balance_payments_enabled, event_date_status, show_time, use_online_scoring, city_id ) " +
                                "values('" + dataReader["id"] + "','" + dataReader["seasonid"] + "','" + dataReader["eventid"] + "'," + state + ",'" + dataReader["perfdivtype"] + "'," +
                                     "'" + Get_json_web_info(dataReader[5].ToString(), dataReader[6].ToString(), dataReader[7].ToString(), dataReader[8].ToString(), dataReader[9].ToString(), dataReader[10].ToString(), dataReader[11].ToString(), dataReader[12].ToString()) + "','" +
                                     "" + Get_json_entry_info(dataReader[13].ToString(), dataReader[14].ToString(), dataReader[15].ToString(), dataReader[16].ToString(), dataReader[17].ToString(), dataReader[18].ToString()) + "','" +
                                     "" + Get_json_mybtf(dataReader[19].ToString(), dataReader[20].ToString(), dataReader[21].ToString()) + "'," +
                                     "" + GetHotelId(dataReader[22].ToString(), dataReader[23].ToString(), dataReader[24].ToString(), dataReader[25].ToString(), dataReader[26].ToString(), dataReader[27].ToString(), dataReader[28].ToString(), pPostgres) + ", " +
                                     "" + GetVenueId(dataReader[29].ToString(), dataReader[30].ToString(), dataReader[31].ToString(), dataReader[32].ToString(), dataReader[33].ToString(), dataReader[34].ToString(), dataReader[35].ToString(), pPostgres)+ "," +
                                     ""+ NVL(dataReader["start_date"].ToString()) + ","+ NVL(dataReader["end_date"].ToString()) + ",'"+ dataReader["cutoff_date"].ToString().Replace("-", "") + "','"+ dataReader["cutoff_date2"].ToString().Replace("-", "") + "',"+ Get_room_rate(dataReader["room_rate"].ToString()) + "," +
                                     "'"+ dataReader["notes"].ToString().Replace("'", "''") + "','"+ CheckBool(dataReader["is_finals"].ToString()) + "','"+ dataReader["entry_limits"].ToString().Replace("'","''") + "','"+ dataReader["weather_link"].ToString().Replace("'", "''") + "'," +
                                     "'"+ dataReader["hotel_alt"].ToString().Replace("'", "''") + "','"+ dataReader["custom_routine_durations"].ToString().Replace("'", "''") + "','"+ dataReader["default_category_order"].ToString().Replace("'", "''") + "','"+ dataReader["routine_dist"] + "','"+ dataReader["roomreservations"].ToString().Replace("'", "''") + "','"+ CheckBool(dataReader["webcast_this_city"].ToString()) + "'" +
                                     ",'"+ dataReader["hotel_notes"].ToString().Replace("'", "''") + "','"+ CheckBool(dataReader["online_balance_payments_enabled"].ToString()) + "'" +
                                     ",'"+ dataReader["event_date_status"].ToString() +"','"+ dataReader["show_time"].ToString() + "','"+ CheckBool(dataReader["use_online_scoring"].ToString()) + "'," +
                                     ""+GetId("select id from tbl_city where name like '"+dataReader["city"].ToString().Replace("'", "''") + "';",pPostgres) + ");");
                }
                catch (Exception)
                {
                }

            }
            pPostgres.Message = "tbl_tour_dates - extraction - FINISH";
        }

        private string Get_json_web_info(string p_web_workshop, string p_web_competition, string p_web_playlist, string p_web_results, string p_web_city_webcast_banner, string p_web_no_competition, string p_web_videos, string p_web_personalpdfs)
        {
            dynamic web = new JObject();
            web.workshop = p_web_workshop;
            web.competition = p_web_competition;
            web.playlist = p_web_playlist;
            web.results = p_web_results;
            web.city_webcast_banner = p_web_city_webcast_banner;
            web.no_competition = p_web_no_competition;
            web.videos = p_web_videos;
            web.personalpdfs = p_web_personalpdfs;
            return web.ToString();
        }

        private string Get_json_entry_info(string p_entrylimit_total, string p_entrylimit_solos, string p_entrylimit_duotrios, string p_entrylimit_groups, string p_entrylimit_onesolo, string p_entrylimit_sologroup)
        {
            dynamic entrylimit = new JObject();
            entrylimit.total = p_entrylimit_total;
            entrylimit.solos = p_entrylimit_solos;
            entrylimit._duotrios = p_entrylimit_duotrios;
            entrylimit.groups = p_entrylimit_groups;
            entrylimit.onesolo = p_entrylimit_onesolo;
            entrylimit.sologroup = p_entrylimit_sologroup;
            return entrylimit.ToString();
        }

        private string Get_json_mybtf(string p_mybtfregenabled, string p_mybtf_no_competition, string p_mybtf_photovideo_active)
        {
            dynamic myftf = new JObject();
            myftf.regenabled = p_mybtfregenabled;
            myftf.no_competition = p_mybtf_no_competition;
            myftf.photovideo_active = p_mybtf_photovideo_active;
            return myftf.ToString();
        }

        private string Get_room_rate(string pParameter)
        {
            if (pParameter != "" && pParameter?[0].ToString() == "$")
            {
                try
                {
                    dynamic json_web_info = new JObject();
                    json_web_info.rate = pParameter.Substring(1, Strings.InStr(1, pParameter, " ") - 2);
                    int first_space = Strings.InStr(1, pParameter, " ");
                    int second_space = (Strings.InStr(first_space + 1, pParameter, " ") == 0) ? pParameter.Length : Strings.InStr(first_space + 1, pParameter, " ") - 1;
                    string next_string = pParameter.Substring(first_space, second_space - first_space);
                    Array test = next_string.Replace("/", "").ToArray();
                    json_web_info.room = JArray.FromObject(test);
                    return "'" + json_web_info.ToString() + "'";
                }
                catch
                {
                }
            }
            //return "'" + pParameter + "'";
            return "null";
        }

        private string GetHotelId(string p_hotel_name, string p_hotel_website, string p_hotel_address, string p_hotel_city, string p_hotel_stateid, string p_hotel_zip, string p_hotel_phone, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            query = pPostgres.Select("select distinct id " +
                                   "from tbl_hotel where name like '" + p_hotel_name.Replace("'", "''") + "' and hotel_website like '%" + WebUtility.UrlDecode(p_hotel_website) + "%';");
            string pom;
            while (query.Read())
            {
                pom = query[0].ToString();
                query.Dispose();
                return "'"+pom+"'";
            }
            query.Dispose();
            if (p_hotel_name != "")
            {
                string p_city_id = GetId("select id from tbl_city where name like '"+ p_hotel_city.Replace("'", "''") + "'", pPostgres);
                pPostgres.Insert("insert into tbl_address(state_id, address, city_id, zip) values('" + p_hotel_stateid + "','" + p_hotel_address + "'," + p_city_id + ",'" + p_hotel_zip + "');");
                string p_address_id = GetId("select max(id) from tbl_address", pPostgres);
                pPostgres.Insert("insert into tbl_hotel(name, hotel_website, address_id) values('" + p_hotel_name.Replace("'", "''") + "','" + WebUtility.UrlDecode(p_hotel_website) + "','" + p_address_id + "');");
                string p_hotel_id = GetId("select max(id) from tbl_hotel", pPostgres);

                var s = p_hotel_phone;
                var c = new[] { '(', ')', '-', ' ' };
                pPostgres.Insert("insert into hotel_contact_type(contact_type_id, hotel_id, value) values('2','" + p_hotel_id + "','" + Remove(s,c) + "');");
                return "'"+p_hotel_id+"'";
            }
            else
            {
                return "null";
            }
        }

        private string GetVenueId(string p_venue_name, string p_venue_address, string p_venue_city, string p_venue_stateid, string p_venue_zip, string p_venue_phone, string p_venue_website, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            query = pPostgres.Select("select distinct venue_id " +
                                   "from tbl_venue where name like '" + p_venue_name.Replace("'", "''") + "' and venue_website like '%" + WebUtility.UrlDecode(p_venue_website) + "%';");
            string pom;
            while (query.Read())
            {
                pom = query[0].ToString();
                query.Dispose();
                return "'" + pom + "'";
            }
            query.Dispose();
            if (p_venue_name != "")
            {
                string p_city_id = GetId("select id from tbl_city where name like '" + p_venue_city.Replace("'","''") + "'", pPostgres);
                pPostgres.Insert("insert into tbl_address(state_id, address, city_id, zip) values('" + p_venue_stateid + "','" + p_venue_address + "'," + p_city_id + ",'" + p_venue_zip + "');");
                string p_address_id = GetId("select max(id) from tbl_address", pPostgres);
                pPostgres.Insert("insert into tbl_venue(name, venue_website, address_id) values('" + p_venue_name.Replace("'", "''") + "','" + WebUtility.UrlDecode(p_venue_website) + "','" + p_address_id + "');");
                string p_venue_id = GetId("select max(venue_id) from tbl_venue", pPostgres);

                var s = p_venue_phone;
                var c = new[] { '(', ')', '-', ' ' };
                pPostgres.Insert("insert into venue_contact_type(contact_type_id, venue_id, value) values('2','" + p_venue_id + "','" + Remove(s, c) + "');");
                return "'" + p_venue_id + "'";
            }
            else
            {
                return "null";
            }
        }        
    }
}