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
            MySqlDataReader dataReader = pMysql.Select("select distinct id, email, password, active, " +
                                                       "substr(studioowner, 1,instr(studioowner,' ')) name,  " +
                                                       "substr(studioowner, instr(studioowner,' ')) surname, typeid " +
                                                       "from tbl_users where typeid in('1','2','3','4','5','6');");
            pMysql.Message = "tbl_users - extraction - START - studio OWNERS";
            while (dataReader.Read())
            {
                // tbl person
                pPostgres.Insert("insert into tbl_person(person_types_id, fname, lname) values('"+ dataReader["typeid"] + "','"+ dataReader["name"].ToString().Replace("'","''") + "','"+ dataReader["surname"].ToString().Replace("'", "''") + "');");
                string pom = GetId("select max(person_id) from tbl_person;", pPostgres);

                // tbl user
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