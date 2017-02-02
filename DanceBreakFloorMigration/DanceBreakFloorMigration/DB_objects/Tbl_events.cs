using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.Classes
{
    public class Tbl_events : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select 	id, name, link, type, web_home_webcast_banner, currentseason, facebook_link, ageasofyear, " +
                                                       "intopmenu, workshoponly from events; ");
            pMysql.Message = "tbl_events - extraction(from table events) - START";
            string pom1 = "null";
            string pom2 = "null";
            while (dataReader.Read())
            {
                pom1 = (dataReader[2].ToString() == "") ? "null" : "'"+dataReader[2].ToString()+"'";
                pom2 = (dataReader[6].ToString() == "") ? "null" : "'"+dataReader[6].ToString() + "'";
                pPostgres.Insert("insert into tbl_events(id, name, link, event_types_id, web_home_webcast_banner, facebook_link, " +
                                 "ageasofyear,intopmenu, currentseason, " +
                                 "workshoponly) values('"+ dataReader[0] + "','"+ dataReader[1].ToString().Replace("'", "''") + "',"+pom1+",'"+ dataReader[3] + "','"+ CheckBool(dataReader[4].ToString()) + "',"+pom2+"" +
                                 ",'"+ dataReader[7] + "','"+ CheckBool(dataReader[8].ToString()) + "','"+ dataReader[5] + "','"+ CheckBool(dataReader[9].ToString()) + "');");


                //pPostgres.Insert("insert into tbl_current_season(season_id, events_id, is_current_season) values('"+ dataReader[5] + "','"+ dataReader[0] + "',True);");
            }
            // this is DUMMY evenet with ID 6 - this event was missing in original DB
            pPostgres.Insert("insert into tbl_events(id, event_types_id, name) values(6,2, 'DUMMY EVENT');");
            pPostgres.Insert("insert into tbl_events(id, event_types_id, name) values(0,2,'DUMMY EVENT');");
            pPostgres.Message = "tbl_events - extraction - FINISH";
        }
    }
}