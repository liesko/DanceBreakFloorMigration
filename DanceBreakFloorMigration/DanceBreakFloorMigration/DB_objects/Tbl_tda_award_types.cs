using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_tda_award_types : BaseClass, IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select * from tbl_tda_award_types;");
            pMysql.Message = "tbl_tda_award_types - extraction - START ";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_tda_award_types(id, award, hasplaces, awardtype, reportorder) " +
                                 "values("+dataReader["id"]+ ",'" + dataReader["award"].ToString().Replace("'","''") + "'," + CheckBool(dataReader["hasplaces"].ToString()) + ",'" + dataReader["awardtype"] + "'," + NVL(dataReader["reportorder"].ToString()) + ");");
            }

            pPostgres.Message = "tbl_tda_award_types - extraction - FINISH";
        }
    }
}