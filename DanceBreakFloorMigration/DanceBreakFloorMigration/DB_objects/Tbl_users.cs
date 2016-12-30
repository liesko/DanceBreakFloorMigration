using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_users : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select distinct id, email, password, active, " +
                                                       "substr(studioowner, 1,instr(studioowner,' ')) name,  " +
                                                       "substr(studioowner, instr(studioowner,' ')) surname, typeid " +
                                                       "from tbl_users;");
            pMysql.Message = "tbl_users - extraction - START - studio OWNERS";
            while (dataReader.Read())
            {
                // tbl person
                string test = dataReader["email"].ToString();
                if (dataReader["email"].ToString() != "")
                {
                    string person_type_id = (dataReader["typeid"].ToString() == "") ? "null" : dataReader["typeid"].ToString();
                    pPostgres.Insert("insert into tbl_person(person_types_id, fname, lname) values(" + person_type_id + ",'" + dataReader["name"].ToString().Replace("'", "''") + "','" + dataReader["surname"].ToString().Replace("'", "''") + "');");
                    string pom = GetId("select max(person_id) from tbl_person;", pPostgres);

                    // tbl user
                    pPostgres.Insert("insert into tbl_user(user_id, email, password, active, person_id) " +
                                    "values('" + dataReader["id"] + "','" + dataReader["email"] + "','" + dataReader["password"].ToString().Replace("'", "''") + "','" + CheckBool(dataReader["active"].ToString()) + "','" + pom + "');");
                }
            }
            pPostgres.Message= "tbl_users - extraction - FINISH - studio OWNERS";
        }
    }
}