using System;
using DanceBreakFloorMigration.Classes;
using DanceBreakFloorMigration.Interfaces;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.DB_objects
{
    public class Tbl_date_routine_dancers:IMigration
    {
        public void Remigration(MySQL_DB pMysql, PostgreSQL_DB pPostgres)
        {
            MySqlDataReader dataReader = pMysql.Select("select routineid, profileid, tourdateid from tbl_date_routine_dancers group by routineid, profileid, tourdateid;");
            pMysql.Message = "tbl_date_routine_dancers - extraction - START";
            while (dataReader.Read())
            {
                pPostgres.Insert("insert into tbl_date_routine_dancers(tour_dates_id, routine_id, dancer_id) values(" + dataReader["tourdateid"] + "," + dataReader["routineid"] + "," + dataReader["profileid"] + ");");
            }
            pPostgres.Message = "tbl_date_routine_dancers - extraction - FINISH";
        }
    }
}