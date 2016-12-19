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
                string event_id = GetId("select",pPostgres);
                string person_id = GetId("", pPostgres);
                string style_1 = GetId("", pPostgres);
                string style_2 = GetId("", pPostgres);
                string dancer_id = GetId("", pPostgres);
                if (dancer_id==null)
                {
                    // add new person and dancer
                }
                pPostgres.Insert("insert into tbl_faculty(faculty_id, events_id, dancer_id, bio, website, director, twitter, instagram, youtube) " +
                                 "values('','','','','','');");
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