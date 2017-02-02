using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tour_dates_workshop_room:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {

            pMysql.Message = "tour_dates_workshop_room - extraction - START";
            MySqlDataReader dataReader = pMysql.Select("select distinct a.id, '1' , b.id, b.name , substr(workshop_room_1 ,instr(workshop_room_1, 'Level'), 7) as level " +
                                                       "from tbl_tour_dates a, tbl_age_divisions b " +
                                                       "where 1=1 and a.workshop_room_1 is not null " +
                                                       "and (lower(a.workshop_room_1) like concat(lower(b.name)) or (a.workshop_room_1 like '%Level%'));");
            while (dataReader.Read())
            {

                pPostgres.Insert("insert into tour_dates_workshop_room(tour_dates_id, workshop_room_id,  age_divisions_id, level_id) " +
                                "values('" + dataReader[0].ToString() + "','" + dataReader[1].ToString() + "','" + dataReader[2].ToString() + "',"+ GetLevel(dataReader[4].ToString(), pPostgres) + ");");
            }
            
            // -----------------
            dataReader = pMysql.Select("select distinct a.id, '2' , b.id, b.name , substr(workshop_room_2 ,instr(workshop_room_2, 'Level'), 7) as level " +
                                                       "from tbl_tour_dates a, tbl_age_divisions b " +
                                                       "where 1=1 and a.workshop_room_2 is not null " +
                                                       "and (lower(a.workshop_room_2) like concat(lower(b.name)) or (a.workshop_room_2 like '%Level%'));");
            while (dataReader.Read())
            {

                pPostgres.Insert("insert into tour_dates_workshop_room(tour_dates_id, workshop_room_id,  age_divisions_id, level_id) " +
                                "values('" + dataReader[0].ToString() + "','" + dataReader[1].ToString() + "','" + dataReader[2].ToString() + "'," + GetLevel(dataReader[4].ToString(), pPostgres).ToString() + ");");
            }
            // -----------------
            dataReader = pMysql.Select("select distinct a.id, '3' , b.id, b.name , substr(workshop_room_3 ,instr(workshop_room_3, 'Level'), 7) as level " +
                                                       "from tbl_tour_dates a, tbl_age_divisions b " +
                                                       "where 1=1 and a.workshop_room_3 is not null " +
                                                       "and (lower(a.workshop_room_3) like concat(lower(b.name)) or (a.workshop_room_3 like '%Level%'));");
            while (dataReader.Read())
            {

                pPostgres.Insert("insert into tour_dates_workshop_room(tour_dates_id, workshop_room_id,  age_divisions_id, level_id) " +
                                "values('" + dataReader[0].ToString() + "','" + dataReader[1].ToString() + "','" + dataReader[2].ToString() + "'," + GetLevel(dataReader[4].ToString(), pPostgres).ToString() + ");");
            }
            // -----------------
            dataReader = pMysql.Select("select distinct a.id, '4' , b.id, b.name , substr(workshop_room_4 ,instr(workshop_room_4, 'Level'), 7) as level " +
                                                       "from tbl_tour_dates a, tbl_age_divisions b " +
                                                       "where 1=1 and a.workshop_room_4 is not null " +
                                                       "and (lower(a.workshop_room_4) like concat(lower(b.name)) or (a.workshop_room_4 like '%Level%'));");
            while (dataReader.Read())
            {

                pPostgres.Insert("insert into tour_dates_workshop_room(tour_dates_id, workshop_room_id,  age_divisions_id, level_id) " +
                                "values('" + dataReader[0].ToString() + "','" + dataReader[1].ToString() + "','" + dataReader[2].ToString() + "'," + GetLevel(dataReader[4].ToString(), pPostgres).ToString() + ");");
            }
            // -----------------
            dataReader = pMysql.Select("select distinct a.id, '5' , b.id, b.name , substr(workshop_room_5 ,instr(workshop_room_5, 'Level'), 7) as level " +
                                                       "from tbl_tour_dates a, tbl_age_divisions b " +
                                                       "where 1=1 and a.workshop_room_5 is not null " +
                                                       "and (lower(a.workshop_room_5) like concat(lower(b.name)) or (a.workshop_room_5 like '%Level%'));");
            while (dataReader.Read())
            {

                pPostgres.Insert("insert into tour_dates_workshop_room(tour_dates_id, workshop_room_id,  age_divisions_id, level_id) " +
                                "values('" + dataReader[0].ToString() + "','" + dataReader[1].ToString() + "','" + dataReader[2].ToString() + "'," + GetLevel(dataReader[4].ToString(), pPostgres).ToString() + ");");
            }
            // -----------------
            dataReader = pMysql.Select("select distinct a.id, '6' , b.id, b.name , substr(workshop_room_6 ,instr(workshop_room_6, 'Level'), 7) as level " +
                                                       "from tbl_tour_dates a, tbl_age_divisions b " +
                                                       "where 1=1 and a.workshop_room_6 is not null " +
                                                       "and (lower(a.workshop_room_6) like concat(lower(b.name)) or (a.workshop_room_6 like '%Level%'));");
            while (dataReader.Read())
            {

                pPostgres.Insert("insert into tour_dates_workshop_room(tour_dates_id, workshop_room_id,  age_divisions_id, level_id) " +
                                "values('" + dataReader[0].ToString() + "','" + dataReader[1].ToString() + "','" + dataReader[2].ToString() + "'," + GetLevel(dataReader[4].ToString(), pPostgres).ToString() + ");");
            }
            // -----------------
            dataReader = pMysql.Select("select distinct a.id, '7' , b.id, b.name , substr(workshop_room_7 ,instr(workshop_room_7, 'Level'), 7) as level " +
                                                       "from tbl_tour_dates a, tbl_age_divisions b " +
                                                       "where 1=1 and a.workshop_room_7 is not null " +
                                                       "and (lower(a.workshop_room_7) like concat(lower(b.name)) or (a.workshop_room_7 like '%Level%'));");
            while (dataReader.Read())
            {

                pPostgres.Insert(
                    "insert into tour_dates_workshop_room(tour_dates_id, workshop_room_id,  age_divisions_id, level_id) " +
                    "values('" + dataReader[0].ToString() + "','" + dataReader[1].ToString() + "','" +
                    dataReader[2].ToString() + "'," + GetLevel(dataReader[4].ToString(), pPostgres).ToString() + ");");

            }
            pPostgres.Message = "tour_dates_workshop_room - extraction - FINISH";
        }

        private string GetLevel(string pLevel, PostgreSQL_DB pPostgres)
        {
            NpgsqlDataReader query;
            query = pPostgres.Select("select distinct id from tbl_levels where name like '" + pLevel + "';");
            string pom;
            while (query.Read())
            {
                pom = query[0].ToString();
                query.Dispose();
                return "'"+pom+"'";
            }
            query.Dispose();
            return "null";
        }
    }
}