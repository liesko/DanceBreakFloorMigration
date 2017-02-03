using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_schedule_workshops : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_schedule_workshops");
            pMysql.Message = "tbl_date_schedule_workshops - extraction - START ";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_date_schedule_workshops(id, tour_dates_id, date, start_time, duration, span) " +
                                 "values("+dataReader["id"]+", "+NVL(dataReader["tourdateid"].ToString()) + ",'"+ RemoveFirstTwoOccurence(" ", FromUnixTime(Convert.ToInt64(dataReader["date"]))) + "'," +
                                 "'"+RemoveFirstTwoOccurence(" ", FromUnixTime(Convert.ToInt64(dataReader["start_time"]))) + "','"+RetSeconds(dataReader["duration"].ToString()) + "',"+dataReader["span"]+")");
            }
            pPostgres.Message = "tbl_date_schedule_workshops - extraction - FINISH";
        }
    }
}