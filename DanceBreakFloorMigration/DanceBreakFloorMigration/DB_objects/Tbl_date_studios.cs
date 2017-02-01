using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_studios : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_date_studios");

            pMysql.Message = "tbl_date_studios - extraction - START";
            int pcounter = 0;
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_date_studios(id, tour_dates_id, studios_id, " +
                                 "total_fees, fees_paid, credit, " +
                                 "full_rates, independent, invoice_note, " +
                                 "ftv, ftc, statsregid, emailer_count, " +
                                 "studiocode, confirmdate) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["tourdateid"] + "','" + dataReader["studioid"] + "'," +
                                 "'" + dataReader["total_fees"] + "'," + NVL(dataReader["fees_paid"].ToString().Replace(",","")) + "," +NVL(dataReader["credit"].ToString().Replace("$","")) + "," +
                                 "'" + CheckBool(dataReader["full_rates"].ToString()) + "','" + CheckBool(dataReader["independent"].ToString()) + "'," + NVL(dataReader["invoice_note"].ToString().Replace("'","''")) + "," +
                                 "" + NVL(dataReader["free_teacher_value"].ToString()) + "," + NVL(dataReader["free_teacher_count"].ToString()) + "," +NVL(dataReader["statsregid"].ToString()) + "," +
                                 "'" + dataReader["emailer_count"] + "'," + NVL(dataReader["studiocode"].ToString()) + ",'" + FromUnixTime(Convert.ToInt64(dataReader["confirmdate"])).ToString().Replace(". ", ".") + "')");
            }
            pPostgres.Message = "tbl_date_studios - extraction - FINISH";
        }
    }
}