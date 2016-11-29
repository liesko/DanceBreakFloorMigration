using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_tour_dates:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select id, seasonid, eventid, stateid, cast(perfdivtype as char) from tbl_tour_dates;");
            pMysql.Message = "tbl_tour_dates - extraction - START";
            while (dataReader.Read())
            {
                try
                {
                    pPostgres.Insert("insert into tbl_tour_dates(tour_dates_id, season_id, events_id, state_id, performance_divisions_id) " +
                                "values('" + dataReader[0] + "','" + dataReader[1] + "','" + dataReader[2] + "','" + dataReader[3] + "','" + dataReader[4] + "');");
                }
                catch (Exception)
                {

                    pPostgres.Message = "tbl_tour_dates INVALID INSERT: insert into tbl_tour_dates(tour_dates_id, season_id, events_id, state_id, performance_divisions_id) " +
                                "values('" + dataReader[0] + "','" + dataReader[1] + "','" + dataReader[2] + "','" + dataReader[3] + "','" + dataReader[4] + "');";
                }
                
            }
            pPostgres.Message = "tbl_tour_dates - extraction - FINISH";
        }

        private string GetId(string pParam, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            query = pPostgres.Select("select distinct playlist_workshop_levels_id " +
                                   "from tbl_playlist_workshop_levels where name like '" + pParam + "';");
            string pom;
            while (query.Read())
            {
                pom = query[0].ToString();
                query.Dispose();
                return pom;
            }

            return null;
        }
    }
}