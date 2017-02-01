using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_user_registrations_soty : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_user_registrations_soty");
            pMysql.Message = "tbl_user_registrations_soty - extraction - START ";
            while (dataReader.Read())
            {
                string RegId = GetId("select id from tbl_registration  where old_user_reg_id='" + dataReader["regid"] + "' limit 1;", pPostgres);

                pPostgres.Insert("insert into tbl_user_registrations_soty(id, user_id, registration_id, ts_ballet, ts_jazz, ts_mtspec, " +
                                 "ts_contemplyrical, ts_hiphoptap, mj_ballet, mj_jazz, mj_mtspec, mj_contemplyrical, mj_hiphoptap, has_soty) " +
                                 "values("+dataReader["id"] +","+dataReader["userid"] +","+RegId+","+NVL2(dataReader["ts_ballet"].ToString()) +"," +
                                 ""+ NVL2(dataReader["ts_jazz"].ToString()) + ","+ NVL2(dataReader["ts_mtspec"].ToString()) + "," +
                                 ""+ NVL2(dataReader["ts_contemplyrical"].ToString()) + ","+ NVL2(dataReader["ts_hiphoptap"].ToString()) + "," +
                                 ""+ NVL2(dataReader["mj_ballet"].ToString()) + ","+ NVL2(dataReader["mj_jazz"].ToString()) + "," +
                                 ""+ NVL2(dataReader["mj_mtspec"].ToString()) + ","+ NVL2(dataReader["mj_contemplyrical"].ToString()) + "," +
                                 ""+ NVL2(dataReader["mj_hiphoptap"].ToString()) + ","+ CheckBool(dataReader["has_soty"].ToString()) + ")");
            }
            pPostgres.Message = "tbl_user_registrations_soty - extraction - FINISH";
        }
        public string NVL2(string pParam)
        {
            if (pParam == "" || pParam == "0")
            {
                return "null";
            }
            return "'" + pParam + "'";
        }
    }
}