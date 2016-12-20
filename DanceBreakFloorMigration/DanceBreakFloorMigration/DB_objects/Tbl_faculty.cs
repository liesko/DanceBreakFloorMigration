using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_faculty:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_faculty;");
            pMysql.Message = "tbl_faculty - extraction - START";
            while (dataReader.Read())
            {
                string event_id = GetId("select events_id from tbl_events where lower(name) like lower('"+dataReader["tour"]+"')",pPostgres);
                string person_id = GetId("select person_id from tbl_person where lower(fname) like lower('" + dataReader["fname"].ToString().Replace("'", "''") + "') and lower(lname) like lower('"+ dataReader["lname"].ToString().Replace("'", "''") + "')", pPostgres);
                string style_1 = GetId("select performance_divisions_id from tbl_performance_divisions where name like '"+dataReader["style1"] +"'", pPostgres);
                string style_2 = GetId("select performance_divisions_id from tbl_performance_divisions where name like '" + dataReader["style2"] + "'", pPostgres);
                string dancer_id = "null";
                if (person_id!="null")
                {
                    dancer_id = GetId("select dancer_id from tbl_dancer where person_id ='"+person_id+"'", pPostgres);
                }
                
                if (dancer_id=="null")
                {
                    pPostgres.Message = "THIS PERSON DOES NOT EXISTS - repair the data: "+dataReader["name"];
                }
                else
                {
                    pPostgres.Insert("insert into tbl_faculty(faculty_id, events_id, dancer_id, bio, website, director, twitter, instagram, youtube) " +
                                    "values("+dataReader["id"]+","+event_id+","+dancer_id+",'"+dataReader["bio"].ToString().Replace("'","''") +"','" + dataReader["website"].ToString().Replace("'", "''") + "'" +
                                     ",'" + dataReader["director"].ToString().Replace("'", "''") + "','" + dataReader["twitter"].ToString().Replace("'", "''") + "','" + dataReader["instagram"].ToString().Replace("'", "''") + "'," +
                                     "'" + dataReader["youtube"].ToString().Replace("'", "''") + "');");
                    if (style_1!="null")
                    {
                        pPostgres.Insert("insert into faculty_has_performance(faculty_id, performance_divisions_id) " +
                                         "values("+dataReader["id"]+","+style_1+");");
                    }
                    if (style_2!="null")
                    {
                        pPostgres.Insert("insert into faculty_has_performance(faculty_id, performance_divisions_id) " +
                                         "values(" + dataReader["id"] + "," + style_2 + ");");
                    }
                }
            }
            pPostgres.Message = "tbl_faculty - extraction - FINISH";
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
            return "null";
        }

        private void AddNewPersonAndDancer()
        {
        }
    }
}