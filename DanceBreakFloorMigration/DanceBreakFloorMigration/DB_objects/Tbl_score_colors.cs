using System.Runtime.InteropServices;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_score_colors: IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select id, name from store_colors;");
            pMysql.Message = "store_colors - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_store_colors(id, name) values(" + (int)dataReader[0] + ",'" + dataReader[1] + "')");
            }
            pPostgres.Message = "store_colors - extraction - FINISH";
        }
    }
}