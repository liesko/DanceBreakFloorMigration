using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_promo_codes:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select id, type, name, description, value, charges, uses, active, noncommuteronly, onceperreg,intensiveid  " +
                                                       "from promo_codes group by id, type, name, description, value, charges, uses, active, noncommuteronly, onceperreg,intensiveid");
            pMysql.Message = "tbl_promo_codes - extraction - START";
            while (dataReader.Read())
            {
                string codeTypeId = GetId("select promo_codes_type_id from tbl_promo_codes_type where name like '" + dataReader["type"]+"'", pPostgres);
                pPostgres.Insert("insert into tbl_promo_codes(promo_codes_id, promo_codes_type_id, name, description, value, charges, uses, active, noncommuteronly, onceperreg, intensiveid) " +
                                 "values("+dataReader["id"]+","+ codeTypeId + ",'"+dataReader["name"]+ "','" + dataReader["description"] + "','" + dataReader["value"] + "','" +
                                 "" + dataReader["charges"] + "','" + dataReader["uses"] + "','" +CheckBool(dataReader["active"].ToString()) + "','" +CheckBool(dataReader["noncommuteronly"].ToString()) + "'," +
                                 "'" +CheckBool(dataReader["onceperreg"].ToString()) + "','" + dataReader["intensiveid"] + "');");
            }
            pPostgres.Message = "tbl_promo_codes - extraction - FINISH";
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