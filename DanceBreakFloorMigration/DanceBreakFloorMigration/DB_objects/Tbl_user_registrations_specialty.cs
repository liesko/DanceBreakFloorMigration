using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_user_registrations_specialty : BaseClass, IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_user_registrations_specialty");
            pMysql.Message = "Tbl_user_registrations_specialty - extraction - START ";
            while (dataReader.Read())
            {
                string RegId = GetId("select id from tbl_registration  where old_user_reg_id='" + dataReader["regid"] + "' limit 1;", pPostgres);

                pPostgres.Insert("insert into tbl_user_registrations_specialty(id, user_id, registration_id, ota_mj_regroutineid, ota_ts_regroutineid, " +
                                 "ota_cd_regroutineid, bc_mj_regroutineid, bc_ts_regroutineid, peopleschoice_regroutineid, ota_m_regroutineid, ota_j_regroutineid, " +
                                 "ota_t_regroutineid, ota_s_regroutineid, bc_mj_cho, bc_ts_cho, ota_cd_cd) " +
                                 "values("+dataReader["id"]+","+ dataReader["userid"] + ","+RegId+","+NVL2(dataReader["ota_mj_regroutineid"].ToString()) + "," +
                                 ""+NVL2(dataReader["ota_ts_regroutineid"].ToString()) +","+NVL2(dataReader["ota_cd_regroutineid"].ToString()) +"," +
                                 ""+NVL2(dataReader["bc_mj_regroutineid"].ToString()) +","+NVL2(dataReader["bc_ts_regroutineid"].ToString()) +"," +
                                 ""+NVL2(dataReader["peopleschoice_regroutineid"].ToString()) +","+NVL2(dataReader["ota_m_regroutineid"].ToString()) +"," +
                                 ""+NVL2(dataReader["ota_j_regroutineid"].ToString()) +", "+NVL2(dataReader["ota_t_regroutineid"].ToString()) +"," +
                                 ""+NVL2(dataReader["ota_s_regroutineid"].ToString()) +",'"+ dataReader["bc_mj_cho"].ToString().Replace("'","''") + "'," +
                                 "'"+ dataReader["bc_ts_cho"].ToString().Replace("'","''") + "','"+ dataReader["ota_cd_cd"].ToString().Replace("'","''") + "');");
            }

            pPostgres.Message = "Tbl_user_registrations_specialty - extraction - FINISH";
        }
        public string NVL2(string pParam)
        {
            if (pParam == "" || pParam=="0")
            {
                return "null";
            }
            return "'" + pParam + "'";
        }
    }
}