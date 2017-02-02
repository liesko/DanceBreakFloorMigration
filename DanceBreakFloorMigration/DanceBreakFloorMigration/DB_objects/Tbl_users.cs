using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_users : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
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
                    string pom = GetId("select max(id) from tbl_person;", pPostgres);

                    // tbl user
                    pPostgres.Insert("insert into tbl_user(id, email, password, active, person_id) " +
                                    "values('" + dataReader["id"] + "','" + dataReader["email"] + "','" + dataReader["password"].ToString().Replace("'", "''") + "','" + CheckBool(dataReader["active"].ToString()) + "','" + pom + "');");
                }
            }
            InsertDummyUsers(pPostgres);
            pPostgres.Message= "tbl_users - extraction - FINISH - studio OWNERS";
        }

        private void InsertDummyUsers(PostgreSQL_DB pPostgres)
        {
            pPostgres.Insert("insert into tbl_user(id, email) values(4,'DUMMY USER');");
            pPostgres.Insert("insert into tbl_user(id, email) values(7,'DUMMY USER');");
            pPostgres.Insert("insert into tbl_user(id, email) values(9,'DUMMY USER');");
            pPostgres.Insert("insert into tbl_user(id, email) values(12,'DUMMY USER');");
            pPostgres.Insert("insert into tbl_user(id, email) values(11,'DUMMY USER');");
            pPostgres.Insert("insert into tbl_user(id, email) values(14,'DUMMY USER');");
            pPostgres.Insert("insert into tbl_user(id, email) values(2370,'DUMMY USER');");
            pPostgres.Insert("insert into tbl_user(id, email) values(3, 'DUMMY');");
            //pPostgres.Insert("insert into tbl_user(id, email) values(9, 'DUMMY');");
            // pPostgres.Insert("insert into tbl_user(id, email) values(14, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(73992, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(73996, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(105790, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(92902, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(62577, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(62579, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(62580, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(62603, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(62609, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(62629, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(67212, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(67213, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(132279, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(149103, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(152828, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(152831, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(213675, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(174652, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(175301, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(178172, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(174804, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(224601, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(216242, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(236145, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(243593, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(243595, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(243833, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(243837, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(243841, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(279771, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(323750, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(323613, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(323629, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(323631, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(323664, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(354883, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(354109, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(354095, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(354093, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(354092, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(354145, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(356486, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(354669, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(354670, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(282113, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359814, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359820, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359645, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(444117, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(444133, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(360061, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359400, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359418, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359397, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359815, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359821, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359644, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359647, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359398, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359399, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359401, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359402, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359404, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(359419, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(367422, 'DUMMY');");

            pPostgres.Insert("insert into tbl_user(id, email) values(5, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(8, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(22, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(188, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(854, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(1182, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(1186, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(1452, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(1576, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(1716, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(13083, 'DUMMY');");
            pPostgres.Insert("insert into tbl_user(id, email) values(13084, 'DUMMY');");

            pPostgres.Insert("insert into tbl_user(id, email) values(44399, 'DUMMY');");
        }
    }
}