using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_users:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct id, email, password, active  from tbl_users where typeid='1';");
            pMysql.Message = "tbl_users - extraction - START - studio OWNERS";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_person(person_types_id) values('1');");
                string pom = GetId("select max(person_id) from tbl_person;", pPostgres);
                pPostgres.Insert("insert into tbl_user(user_id, email, password, active, person_id) " +
                                "values('" + dataReader["id"] + "','" + dataReader["email"] + "','" + dataReader["password"].ToString().Replace("'","''") + "','" + CheckBool(dataReader["active"].ToString()) + "','"+pom+"');");
            }
            pPostgres.Message= "tbl_users - extraction - FINISH - studio OWNERS";
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

            return null;
        }
        private int CheckBool(string pValue)
        {
            if (pValue == "True")
            {
                return 1;
            }
            return 0;
        }
    }
}