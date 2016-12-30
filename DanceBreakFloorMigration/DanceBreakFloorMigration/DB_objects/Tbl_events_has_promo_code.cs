using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_events_has_promo_code:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select a.id codeid, b.name name, b.discount_fee discount_fee, b.fee fee, b.eventid eventid " +
                                                       "from tbl_event_reg_types_18 b join promo_codes a using(eventid) " +
                                                       "union " +
                                                       "select a.id codeid, b.name name, b.discountfee discount_fee, b.fee fee, b.eventid eventid " +
                                                       "from tbl_event_reg_types_12 b join promo_codes a using(eventid) " +
                                                       "union " +
                                                       "select a.id codeid, b.name, b.discountfee discount_fee, b.fee, b.eventid " +
                                                       "from tbl_event_reg_types_16 b join promo_codes a using(eventid) " +
                                                       "union " +
                                                       "select a.id codeid, b.name, b.discount_fee discount_fee, b.fee, b.eventid " +
                                                       "from tbl_event_reg_types_21 b join promo_codes a using(eventid) " +
                                                       "union " +
                                                       "select a.id codeid, b.name, b.discount_fee discount_fee, b.fee, b.eventid " +
                                                       "from tbl_event_reg_types_23 b join promo_codes a using(eventid)");
            pMysql.Message = "tbl_events_has_promo_code - extraction - START";
            while (dataReader.Read())
            {
                string regTypId = GetId("select tbl_event_reg_types_id from tbl_event_reg_types where name like '"+dataReader["name"] +"'", pPostgres);

                pPostgres.Insert("insert into tbl_events_has_promo_code(promo_codes_id, events_id, tbl_event_reg_types_id, discount_fee, fee) " +
                                 "values('"+dataReader["codeid"] + "','" + dataReader["eventid"] + "','" + regTypId + "','" + dataReader["discount_fee"] + "','" + dataReader["fee"] + "');");
            }
            pPostgres.Message = "tbl_events_has_promo_code - extraction - FINISH";
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
            query.Dispose();
            return "null";
        }
    }
}