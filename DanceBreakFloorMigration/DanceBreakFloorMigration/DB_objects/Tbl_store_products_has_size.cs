using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_products_has_size:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_product_sizes;");
            pMysql.Message = "tbl_store_products_has_size - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_products_has_size(store_products_id,store_sizes_id) values('" + dataReader["productid"] +"','"+dataReader["sizeid"] +"')");
            }
            pPostgres.Message = "tbl_store_products_has_size - extraction - FINISH";
        }
    }
}