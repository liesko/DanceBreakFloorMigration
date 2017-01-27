using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_faculty : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_faculty;");
            pMysql.Message = "tbl_faculty - extraction - START";

            int MaxDancerId = Convert.ToInt32(GetId("select max(id) from tbl_dancer;", pPostgres));


            while (dataReader.Read())
            {
                string event_id = GetId("select id from tbl_events where lower(name) like lower('"+dataReader["tour"]+"')",pPostgres);

                string person_id = GetId("select id from tbl_person where lower(fname) like lower('" + dataReader["fname"].ToString().Replace("'", "''") + "') " +
                                         "and lower(lname) like lower('"+ dataReader["lname"].ToString().Replace("'", "''") + "')", pPostgres);
                
                string style_1 = GetId("select id from tbl_performance_divisions where name like '"+dataReader["style1"] +"'", pPostgres);
                string style_2 = GetId("select id from tbl_performance_divisions where name like '" + dataReader["style2"] + "'", pPostgres);
                string dancer_id = "null";
                if (person_id!="null")
                {
                    dancer_id = GetId("select id from tbl_dancer where person_id ='"+person_id+"'", pPostgres);
                    if (dancer_id=="null")
                    {
                        pPostgres.Insert("insert into tbl_dancer(id, person_id) values("+ ++MaxDancerId+", "+person_id+")");
                        dancer_id = MaxDancerId.ToString();
                    }
                }

                if (dancer_id == "null")
                {
                    pPostgres.Insert("insert into tbl_person(fname, lname) values('" + dataReader["fname"].ToString().Replace("'", "''") + "','" + dataReader["lname"].ToString().Replace("'", "''") + "')");
                    person_id = GetId("select max(id) from tbl_person;", pPostgres);
                    pPostgres.Insert("insert into tbl_dancer(id, person_id) values(" + ++MaxDancerId + ", " + person_id + ")");
                    dancer_id = MaxDancerId.ToString();
                }
                pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website, director, twitter, instagram, youtube) " +
                                "values(" + dataReader["id"] + "," + event_id + "," + dancer_id + ",'" + dataReader["bio"].ToString().Replace("'", "''") + "','" + dataReader["website"].ToString().Replace("'", "''") + "'" +
                                 ",'" + dataReader["director"].ToString().Replace("'", "''") + "','" + dataReader["twitter"].ToString().Replace("'", "''") + "','" + dataReader["instagram"].ToString().Replace("'", "''") + "'," +
                                 "'" + dataReader["youtube"].ToString().Replace("'", "''") + "');");
                if (style_1 != "null")
                {
                    pPostgres.Insert("insert into faculty_has_performance(faculty_id, performance_divisions_id) " +
                                     "values(" + dataReader["id"] + "," + style_1 + ");");
                }
                if (style_2 != "null")
                {
                    pPostgres.Insert("insert into faculty_has_performance(faculty_id, performance_divisions_id) " +
                                     "values(" + dataReader["id"] + "," + style_2 + ");");
                }
            }
            AddDummyFaculty(pPostgres);
            pPostgres.Message = "tbl_faculty - extraction - FINISH";
        }

        private void AddDummyFaculty(PostgreSQL_DB pPostgres)
        {
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(55,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(56,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(60,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(61,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(62,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(63,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(66,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(65,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(64,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(67,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(68,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(69,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(70,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(71,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(72,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(78,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(79,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(81,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(82,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(83,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(85,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(84,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(86,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(87,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(88,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(89,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(90,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(91,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(92,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(94,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(97,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(101,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(102,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(103,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(104,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(105,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(106,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(108,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(109,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(118,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(119,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(93,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(95,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(96,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(98,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(99,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(59,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(107,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(100,6,20797, 'DUMMY', 'DUMMY');");

            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(110,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(111,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(112,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(113,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(114,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(115,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(117,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(120,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(121,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(122,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(123,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(124,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(125,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(126,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(127,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(128,6,20797, 'DUMMY', 'DUMMY');");
            pPostgres.Insert("insert into tbl_faculty(id, events_id, dancer_id, bio, website) values(129,6,20797, 'DUMMY', 'DUMMY');");

        }
    }
}