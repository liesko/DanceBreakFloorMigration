using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_score:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            pPostgres.Message = "tbl_score - extraction - FINISH";
            pPostgres.Insert("insert into tbl_score(score_id, name) values('1','finals_score')");
            pPostgres.Insert("insert into tbl_score(score_id, name) values('2','finals_total_score')");
            pPostgres.Insert("insert into tbl_score(score_id, name) values('3','finals_dropped_score')");
            pPostgres.Insert("insert into tbl_score(score_id, name) values('4','vips_score')");
            pPostgres.Insert("insert into tbl_score(score_id, name) values('5','vips_dropped_score')");
            pPostgres.Insert("insert into tbl_score(score_id, name) values('6','vips_total_score')");
            pPostgres.Insert("insert into tbl_score(score_id, name) values('7','prelims_score')");
            pPostgres.Insert("insert into tbl_score(score_id, name) values('8','prelims_total_score')");
            pPostgres.Insert("insert into tbl_score(score_id, name) values('9','prelims_dropped_score')");
            pPostgres.Message = "tbl_score - extraction - FINISH";
        }
    }
}