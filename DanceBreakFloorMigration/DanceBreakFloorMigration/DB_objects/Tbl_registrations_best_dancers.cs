using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Newtonsoft.Json.Linq;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_registrations_best_dancers : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_user_registrations_best_dancers;");
            pMysql.Message = "tbl_registrations_best_dancers - extraction - START ";
            while (dataReader.Read())
            {
                string RegId = GetId("select id from tbl_registration  where old_user_reg_id='" + dataReader["regid"] + "' limit 1;", pPostgres);

                pPostgres.Insert("insert into tbl_registrations_best_dancers(id, dancer_id, registration_id, competing, jacket, routine, choreographer, photo_file, jacket_only, fee) " +
                                 "values("+dataReader["id"]+", "+dataReader["profileid"] +","+ RegId + ", "+dataReader["bestdancer_competing"] +"," +
                                 "'"+Get_json_jacket(dataReader["bestdancer_jacketsize"].ToString(),dataReader["bestdancer_jacketname"].ToString()) +"'," +
                                 "'"+dataReader["bestdancer_routinename"].ToString().Replace("'","''") +"','"+dataReader["bestdancer_choreographer"].ToString().Replace("'", "''") + "'," +
                                 "'"+dataReader["photofile"] +"',"+CheckBool(dataReader["notcompeting_jacketonly"].ToString()) + ","+NVL(dataReader["bestdancer_fee"].ToString()) + " );");
            }

            pPostgres.Message = "tbl_registrations_best_dancers - extraction - FINISH";
        }
        private string Get_json_jacket(string pSize, string pName)
        {
            dynamic jacket = new JObject();
            jacket.size = pSize.Replace("'", "''");
            jacket.name = pName.Replace("'","''");
            return jacket.ToString();
        }
    }
}