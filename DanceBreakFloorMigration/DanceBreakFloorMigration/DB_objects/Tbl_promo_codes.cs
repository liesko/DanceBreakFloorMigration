using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;
using Npgsql;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_promo_codes : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select id, type, name, description, value, charges, uses, active, noncommuteronly, onceperreg,intensiveid  " +
                                                       "from promo_codes group by id, type, name, description, value, charges, uses, active, noncommuteronly, onceperreg,intensiveid");
            pMysql.Message = "tbl_promo_codes - extraction - START";
            while (dataReader.Read())
            {
                string codeTypeId = GetId("select id from tbl_promo_codes_type where name like '" + dataReader["type"]+"'", pPostgres);
                pPostgres.Insert("insert into tbl_promo_codes(id, promo_codes_type_id, name, description, value, charges, uses, active, noncommuteronly, onceperreg, intensiveid) " +
                                 "values("+dataReader["id"]+","+ codeTypeId + ",'"+dataReader["name"]+ "','" + dataReader["description"] + "','" + dataReader["value"] + "','" +
                                 "" + dataReader["charges"] + "','" + dataReader["uses"] + "','" +CheckBool(dataReader["active"].ToString()) + "','" +CheckBool(dataReader["noncommuteronly"].ToString()) + "'," +
                                 "'" +CheckBool(dataReader["onceperreg"].ToString()) + "','" + dataReader["intensiveid"] + "');");
            }
            pPostgres.Insert("insert into tbl_promo_codes(id, promo_codes_type_id, name, uses) values(0,1, 'DUMMY PROMO CODE', 0);");
            pPostgres.Message = "tbl_promo_codes - extraction - FINISH";
        }
    }
}