using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_product_subtypes:IMigration
    {
        public void SupRemigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_product_subtypes;");
            pMysql.Message = "tbl_store_product_subtypes - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_product_subtypes(id, name, product_types_id) " +
                                 "values("+dataReader["id"]+",'"+dataReader["name"]+"',"+dataReader["typeid"] +");");
            }
            pPostgres.Message = "tbl_store_product_subtypes - extraction - FINISH";
        }
    }
}