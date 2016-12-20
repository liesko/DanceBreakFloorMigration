using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_product_subtypes:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_product_subtypes;");
            pMysql.Message = "tbl_store_product_subtypes - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_product_subtypes(product_subtypes_id, name, product_types_id) " +
                                 "values("+dataReader["id"]+",'"+dataReader["name"]+"',"+dataReader["typeid"] +");");
            }
            pPostgres.Message = "tbl_store_product_subtypes - extraction - FINISH";
        }
    }
}