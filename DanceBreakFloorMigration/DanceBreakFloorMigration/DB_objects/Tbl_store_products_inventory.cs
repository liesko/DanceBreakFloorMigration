using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_store_products_inventory : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres, string pDate = "1.1.2500")
        {
            MySqlDataReader dataReader = pMysql.Select("select * from store_products_inventory;");
            pMysql.Message = "tbl_store_products_inventory - extraction - START";

            pPostgres.Insert("insert into tbl_store_colors(id, name) values(0, 'DUMMY');");
            pPostgres.Insert("insert into tbl_store_sizes(id, size) values(0, 'DUMMY');");

            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_products_inventory(id, store_products_id, store_sizes_id, qty_warehouse, qty_onsite, store_colors_id) " +
                                 "values('"+dataReader["id"]+ "','" + dataReader["productid"] + "','" + dataReader["sizeid"] + "','" + dataReader["qty_warehouse"] + "'," +
                                 "'" + dataReader["qty_onsite"] + "','" + dataReader["colorid"] + "')");
            }
            pPostgres.Message = "tbl_store_products_inventory - extraction - FINISH";
        }
    }
}