using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_schedule_workshops : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_schedule_workshops");
            pMysql.Message = "tbl_date_schedule_workshops - extraction - START ";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_date_schedule_workshops(id, tour_dates_id, date, start_time, duration, span) " +
                                 "values("+dataReader["id"]+", "+NVL(dataReader["tourdateid"].ToString()) + ",'"+FromUnixTime(Convert.ToInt64(dataReader["date"])) + "'," +
                                 "'"+FromUnixTime(Convert.ToInt64(dataReader["start_time"])) + "','"+dataReader["duration"]+"',"+dataReader["span"]+")");
            }
            pPostgres.Message = "tbl_date_schedule_workshops - extraction - FINISH";
        }
    }
}