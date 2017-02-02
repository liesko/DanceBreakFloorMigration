using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_tda_bestdancer_data : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_tda_bestdancer_data;");
            pMysql.Message = "tbl_tda_bestdancer_data - extraction - START";
            while (dataReader.Read())
            {
                // -------------------
                if (!String.IsNullOrEmpty(dataReader["routineid"].ToString()))
                {
                    CreateDummyRoutines(NVL(dataReader["routineid"].ToString()), pPostgres);
                }

                string pChoreographer = "0";
                if (!String.IsNullOrEmpty(dataReader["choreographer"].ToString()))
                {
                    pChoreographer = AddNewPerson(dataReader["choreographer"].ToString(), pPostgres);
                }
                pPostgres.Insert("insert into tbl_tda_bestdancer_data(id, tour_dates_id, dancer_id, routines_id, person_id, studios_id, iscompeting, " +
                                 "jacketname, jacketsize, hasphoto, ballet, danceoff, groupid, perc, place, jazz) " +
                                 "values("+dataReader["id"]+ "," + NVL(dataReader["tourdateid"].ToString()) + "," + NVL(dataReader["profileid"].ToString()) + "," +
                                 "" + NVL(dataReader["routineid"].ToString()) + "," + pChoreographer + "," + NVL(dataReader["studioid"].ToString()) + "," +
                                 "" + dataReader["iscompeting"] + ",'" + dataReader["jacketname"].ToString().Replace("'","''") + "','" + dataReader["jacketsize"].ToString().Replace("'", "''") + "'," +
                                 "" + CheckBool(dataReader["hasphoto"].ToString()) + "," + NVL(dataReader["ballet"].ToString()) + "," +
                                 "'"+Get_json_danceoff(dataReader["danceoff"].ToString(), dataReader["danceoff_max"].ToString()) +"'," +
                                 "" + NVL(dataReader["groupid"].ToString()) + "," +
                                 "'"+Get_json_perc(dataReader["perc_solo"].ToString(), dataReader["perc_ballet"].ToString(), dataReader["perc_danceoff"].ToString(), dataReader["perc_round2"].ToString(), dataReader["perc_total"].ToString()) +"'," +
                                 "'"+Get_json_place(dataReader["round1_place"].ToString(), dataReader["round2_place"].ToString(), dataReader["round3_place"].ToString()) +"'," + NVL(dataReader["jazz"].ToString()) + ");");
            }
            pPostgres.Message = "tbl_tda_bestdancer_data - extraction - FINISH";
        }
        public string AddNewPerson(string pName, PostgreSQL_DB pPostgres)
        {
            string PersonType = GetId("select id from tbl_person_types where name like 'Teacher' limit 1;", pPostgres);
            pPostgres.Insert("insert into tbl_person(fname, person_types_id) " +
                                 "values('" + pName.ToString().Replace("'", "''") + "'," + PersonType + ")");
            string Max_person_id = GetId("select max(id) from tbl_person", pPostgres);
            return Max_person_id;
        }
        private string Get_json_danceoff(string pdanceoff, string pdanceoff_max)
        {
            dynamic danceoff = new JObject();
            danceoff.score = pdanceoff;
            danceoff.max = pdanceoff_max;
            return danceoff.ToString();
        }

        private string Get_json_perc(string perc_solo, string perc_ballet, string perc_danceoff, string perc_round2, string perc_total)
        {
            dynamic perc = new JObject();
            perc.solo = perc_solo;
            perc.ballet = perc_ballet;
            perc.danceoff = perc_danceoff;
            perc.round2 = perc_round2;
            perc.total = perc_total;
            return perc.ToString();
        }

        private string Get_json_place(string round1_place, string round2_place, string round3_place)
        {
            dynamic place = new JObject();
            place.round1 = round1_place;
            place.round2 = round2_place;
            place.round3 = round3_place;
            return place.ToString();
        }
    }
}