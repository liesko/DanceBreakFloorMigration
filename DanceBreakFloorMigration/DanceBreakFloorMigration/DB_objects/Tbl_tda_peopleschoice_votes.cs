using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_tda_peopleschoice_votes : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_tda_peopleschoice_votes;");
            pMysql.Message = "tbl_tda_peopleschoice_votes - extraction - START ";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_tda_peopleschoice_votes(id, nomid, ip, routines_id, tour_dates_id) " +
                                 "values("+dataReader["id"]+ "," + NVL(dataReader["nomid"].ToString()) + ",'" + dataReader["ip"] + "'," +
                                 "" + NVL(dataReader["routineid"].ToString()) + "," + NVL(dataReader["tourdateid"].ToString()) + ");");
            }

            pPostgres.Message = "tbl_tda_peopleschoice_votes - extraction - FINISH";
        }
    }
}