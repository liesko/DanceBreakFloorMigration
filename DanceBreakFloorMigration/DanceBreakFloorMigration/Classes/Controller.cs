using DanceBreakFloorMigration.DB_objects;
using MySql.Data.MySqlClient;

namespace DanceBreakFloorMigration.Classes
{
    public class Controller
    {
        public static MySQL_DB DanceteaManager; 
        public static MySQL_DB Mybreak_db;
        public static PostgreSQL_DB Pgdbbreakthefloor;
        private Form1 _form;
        public Controller(Form1 form)
        {
            _form = form;
            Pgdbbreakthefloor =  new PostgreSQL_DB("pgdbbreakthefloor", _form);
            DanceteaManager= new MySQL_DB("dancetea_manager", _form);
            Mybreak_db = new MySQL_DB("mybreak_db", _form);
        }
        public bool Connect()
        {
            if (DanceteaManager.OpenConnection() && Mybreak_db.OpenConnection() && Pgdbbreakthefloor.OpenConnection())
            {     
                return true;
            }
            return false;
        }

        public void Remigration()
        {

            DeleteTable("tbl_studios");
            DeleteTable("venue_contact_type");
            DeleteTable("hotel_contact_type");
            DeleteTable("tour_dates_workshop_room");
            DeleteTable("tbl_level");
            DeleteTable("tbl_tour_dates");
            DeleteTable("tbl_hotel");
            DeleteTable("tbl_venue");
            DeleteTable("tbl_address");
            DeleteTable("tbl_fee_types");
            DeleteTable("tbl_season_events");
            DeleteTable("tbl_soty_type");
            DeleteTable("tbl_routine_types");
            DeleteTable("tbl_time_type");
            DeleteTable("tbl_score");
            DeleteTable("tbl_songs");
            DeleteTable("tbl_performance_divisions");
            DeleteTable("tbl_category");
            DeleteTable("tbl_age_divisions");
            DeleteTable("tbl_playlist_workshop_levels");
         //   DeleteTable("tbl_current_season");
            DeleteTable("tbl_events");
            DeleteTable("tbl_event_types");
            DeleteTable("tbl_promo_codes_type");
            DeleteTable("tbl_season");
            DeleteTable("tbl_payment_method");
            DeleteTable("tbl_workshop_room");
            DeleteTable("tbl_event_types");
            DeleteTable("tbl_contact_type");
            DeleteTable("tbl_states");
            DeleteTable("tbl_gender");
            DeleteTable("tbl_store_colors");
            DeleteTable("tbl_person_types");
            DeleteTable("tbl_store_sizes");
            DeleteTable("tbl_store_product_types");
            DeleteTable("tbl_countries");

            Tbl_score_colors tab = new Tbl_score_colors();
            tab.Remigration(Mybreak_db, Pgdbbreakthefloor);

            Tbl_gender tab1 = new Tbl_gender();
            tab1.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_person_types tab2 = new Tbl_person_types();
            tab2.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_store_size tab3 = new Tbl_store_size();
            tab3.Remigration(Mybreak_db, Pgdbbreakthefloor);

            Tbl_store_product_type tab4 = new Tbl_store_product_type();
            tab4.Remigration(Mybreak_db, Pgdbbreakthefloor);

            Tbl_countries tab5 = new Tbl_countries();
            tab5.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_states tab6 = new Tbl_states();
            tab6.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_contact_type tab7 = new Tbl_contact_type();
            tab7.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_event_types tab8 = new Tbl_event_types();
            tab8.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_workshop_room tab9 = new Tbl_workshop_room();
            tab9.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_payment_method tab10 = new Tbl_payment_method();
            tab10.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_season tab11 = new Tbl_season();
            tab11.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_promo_codes_type tab12 = new Tbl_promo_codes_type();
            tab12.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_events tab13 = new Tbl_events();
            tab13.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_playlist_workshop_levels tab14=new Tbl_playlist_workshop_levels();
            tab14.Remigration(DanceteaManager,Pgdbbreakthefloor);

            Tbl_age_division tab15 = new Tbl_age_division();
            tab15.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_category tab16 = new Tbl_category();
            tab16.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_performance_divisions tab17 = new Tbl_performance_divisions();
            tab17.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_songs tab18 = new Tbl_songs();
            tab18.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_score tab19 = new Tbl_score();
            tab19.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_time_type tab20 = new Tbl_time_type();
            tab20.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_routine_types tab21 = new Tbl_routine_types();
            tab21.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_soty_type tab22 = new Tbl_soty_type();
            tab22.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_season_events tab23 = new Tbl_season_events();
            tab23.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_fee_types tab24 = new Tbl_fee_types();
            tab24.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_tour_dates tab25 = new Tbl_tour_dates();
            tab25.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_level tab27 = new Tbl_level();
            tab27.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tour_dates_workshop_room tab26 = new Tour_dates_workshop_room();
            tab26.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_studios tab28 = new Tbl_studios();
            tab28.Remigration(DanceteaManager, Pgdbbreakthefloor);
        }
        private void DeleteTable(string pTableName)
        {
            Pgdbbreakthefloor.Delete(pTableName);
        }
    }
}