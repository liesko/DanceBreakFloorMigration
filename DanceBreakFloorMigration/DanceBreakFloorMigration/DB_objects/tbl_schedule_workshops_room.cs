using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace DanceBreakFloorMigration.DB_objects
{
    public class tbl_schedule_workshops_room : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_schedule_workshops");
            pMysql.Message = "tbl_schedule_workshops_rooms - extraction - START ";
            while (dataReader.Read())
            {
                if (dataReader["room1"].ToString()!="")
                {
                    pPostgres.Insert("insert into tbl_schedule_workshops_rooms(id, schedule_workshops_id, room) " +
                                    "values(1," + dataReader["id"] + ", " + Get_json_room(dataReader["room1"].ToString(), dataReader["room1_bold"].ToString(), dataReader["room1_highlight"].ToString()) + ")");
                }
                if (dataReader["room2"].ToString() != "")
                {
                    pPostgres.Insert("insert into tbl_schedule_workshops_rooms(id, schedule_workshops_id, room) " +
                                    "values(2," + dataReader["id"] + ", " + Get_json_room(dataReader["room2"].ToString(), dataReader["room2_bold"].ToString(), dataReader["room2_highlight"].ToString()) + ")");
                }
                if (dataReader["room3"].ToString() != "")
                {
                    pPostgres.Insert("insert into tbl_schedule_workshops_rooms(id, schedule_workshops_id, room) " +
                                    "values(3," + dataReader["id"] + ", " + Get_json_room(dataReader["room3"].ToString(), dataReader["room3_bold"].ToString(), dataReader["room3_highlight"].ToString()) + ")");
                }
                if (dataReader["room4"].ToString() != "")
                {
                    pPostgres.Insert("insert into tbl_schedule_workshops_rooms(id, schedule_workshops_id, room) " +
                                    "values(4," + dataReader["id"] + ", " + Get_json_room(dataReader["room4"].ToString(), dataReader["room4_bold"].ToString(), dataReader["room4_highlight"].ToString()) + ")");
                }
                if (dataReader["room5"].ToString() != "")
                {
                    pPostgres.Insert("insert into tbl_schedule_workshops_rooms(id, schedule_workshops_id, room) " +
                                    "values(5," + dataReader["id"] + ", " + Get_json_room(dataReader["room5"].ToString(), dataReader["room5_bold"].ToString(), dataReader["room5_highlight"].ToString()) + ")");
                }
                if (dataReader["room6"].ToString() != "")
                {
                    pPostgres.Insert("insert into tbl_schedule_workshops_rooms(id, schedule_workshops_id, room) " +
                                    "values(6," + dataReader["id"] + ", " + Get_json_room(dataReader["room6"].ToString(), dataReader["room6_bold"].ToString(), dataReader["room6_highlight"].ToString()) + ")");
                }
                if (dataReader["room7"].ToString() != "")
                {
                    pPostgres.Insert("insert into tbl_schedule_workshops_rooms(id, schedule_workshops_id, room) " +
                                    "values(7," + dataReader["id"] + ", " + Get_json_room(dataReader["room7"].ToString(), dataReader["room7_bold"].ToString(), dataReader["room7_highlight"].ToString()) + ")");
                }
            }
            pPostgres.Message = "tbl_schedule_workshops_rooms - extraction - FINISH";
        }
        private string Get_json_room(string pRoom, string pBold, string pHighlight)
        {
                dynamic room = new JObject();
                room.room = pRoom.ToString().Replace("'","''");
                room.bold = CheckBool(pBold);
                room.highlight =CheckBool(pHighlight);
                return "'" + room.ToString() + "'";
        }
    }
}