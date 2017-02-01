using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_event_reg_types:  BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("SELECT id, name, fee, eventid, discountfee, 12 AS season FROM tbl_event_reg_types_12 " +
                                                       "union " +
                                                       "SELECT id, name, fee, eventid, discountfee, 16 AS season FROM tbl_event_reg_types_16 " +
                                                       "union " +
                                                       "SELECT id, name, fee, eventid, discount_fee as discountfee, 18 AS season FROM tbl_event_reg_types_18 " +
                                                       "union " +
                                                       "SELECT id, name, fee, eventid, discount_fee as discountfee, 21 AS season FROM tbl_event_reg_types_21 " +
                                                       "union " +
                                                       "SELECT id, name, fee, eventid, discount_fee as discountfee, 23 AS season FROM tbl_event_reg_types_23");

            pMysql.Message = "tbl_event_reg_types - extraction - START";
            int counter = 0;
            while (dataReader.Read())
            {
                string pEventNameId = GetId("select id from tbl_event_reg_type_names where name like '"+dataReader["name"]+"' limit 1;", pPostgres);

                pPostgres.Insert("insert into tbl_event_reg_types(id, old_id, seasons_id, fee, discountfee, events_id, event_reg_type_names_id) " +
                                 "values("+ ++counter+","+dataReader["id"]+ "," + dataReader["season"] + "," + dataReader["fee"] + "," + dataReader["discountfee"] + "," +
                                 "" + dataReader["eventid"] + ","+ pEventNameId + ");");
            }
            pPostgres.Message = "tbl_event_reg_types - extraction - FINISH";
        }
    }
}