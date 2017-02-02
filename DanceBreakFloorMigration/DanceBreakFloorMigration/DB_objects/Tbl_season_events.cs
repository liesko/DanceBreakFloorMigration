using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_season_events:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select id, seasonid, eventid from tbl_season_events;");
            pMysql.Message = "tbl_season_events - extraction - START";
            while (dataReader.Read())
            {
                    pPostgres.Insert("insert into tbl_season_events(season_id, events_id) " +
                                 "values('" + dataReader[1] + "','" + dataReader[2] + "')");
            }
            pPostgres.Message = "tbl_season_events - extraction - FINISH";
        }
    }
}