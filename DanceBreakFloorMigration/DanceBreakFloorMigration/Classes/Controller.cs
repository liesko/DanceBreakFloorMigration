using System;
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
           //Pgdbbreakthefloor =  new PostgreSQL_DB("pgdbbreakthefloor", _form);    
           // Mybreak_db = new MySQL_DB("mybreak_db", _form);
        }
        public bool Connect()
        {
            Pgdbbreakthefloor = new PostgreSQL_DB(_form.textPostgreDbName.Text, _form.textBoxPostgreServerName.Text, _form.textBoxPostgreUID.Text, 
                _form.textBoxPostgresPortName.Text, _form.textBoxPostgresPassword.Text, _form);

            DanceteaManager = new MySQL_DB(_form.textTeaDbName.Text,_form.textTeaServerName.Text, _form.textTeaUID.Text, _form.textTeaPassword.Text, _form);
            Mybreak_db = new MySQL_DB(_form.textMyBreakDbName.Text, _form.textMyBreakServerName.Text, _form.textMyBreakUID.Text, _form.textMyBreakPassword.Text, _form);

            if (DanceteaManager.OpenConnection() && Mybreak_db.OpenConnection() && Pgdbbreakthefloor.OpenConnection())
            {     
                return true;
            }
            return false;
        }

        public void Remigration()
        {
            /*   
               DeleteTable("tbl_award_nominations_has_teacher");   // M:N          
               DeleteTable("tbl_tda_bestdancer_data");
               DeleteTable("tbl_tda_peopleschoice_votes");
               DeleteTable("tbl_tda_award_nominations");            
               DeleteTable("tbl_competition_awards");            
               DeleteTable("tbl_dts_attendees");            
               DeleteTable("tbl_store_promocodes");                                             
               DeleteTable("tbl_tda_award_types");            
               DeleteTable("tbl_dts_fees");            
               DeleteTable("tbl_date_dancers");                        
               DeleteTable("tbl_dts_registrations");            
               DeleteTable("tbl_event_registrations");                       
               DeleteTable("tbl_user_registrations_soty");                        
               DeleteTable("tbl_user_registrations_specialty");                        
               DeleteTable("tbl_registrations_routines_dancers");                        
               DeleteTable("tbl_registrations_dancers");                        
               DeleteTable("tbl_registrations_routines");                        
               DeleteTable("tbl_registrations_best_dancers");            
               DeleteTable("tbl_registrations_attendees_dts");
               DeleteTable("tbl_event_attendees"); 
               DeleteTable("tbl_registration");                                             
               DeleteTable("tbl_waivers");            
               DeleteTable("tbl_date_scholarships"); 

               DeleteTable("tbl_schedule_workshops_rooms");                        
               */
               DeleteTable("tbl_date_schedule_workshops");   
               /*         
               DeleteTable("tbl_dts_reg_types");                        
               DeleteTable("tbl_admin");            
               DeleteTable("tbl_online_scoring_has_faculty");
               DeleteTable("tbl_online_scoring");            
               DeleteTable("tbl_date_studios");            
               DeleteTable("tbl_date_studio_awards");            
               DeleteTable("tbl_date_special_awards");
               DeleteTable("tbl_special_awards");
               DeleteTable("tbl_studio_awards");
               DeleteTable("tbl_awards_type");
               DeleteTable("tbl_workshop_levels");            
               DeleteTable("tbl_faculty_playlists");            
               DeleteTable("tbl_date_playlists");
               DeleteTable("tbl_date_mybtf_exceptions");
               DeleteTable("tbl_competition_cash_awards");            
               DeleteTable("tbl_staff");
               DeleteTable("tbl_staff_types");

               DeleteTable("tbl_jobs");

               DeleteTable("tbl_store_products_inventory");
               DeleteTable("tbl_store_giftcards");            
               DeleteTable("tbl_user_hearts");            
               DeleteTable("Tbl_store_hearts");
               DeleteTable("tbl_date_routines");                        
               DeleteTable("tbl_perf_div_types");
               // table has been removed from model
               // DeleteTable("tbl_events_has_promo_code");  

               DeleteTable("tbl_event_reg_types");                        
               DeleteTable("tbl_event_reg_type_names");

               DeleteTable("tbl_promo_codes");
               DeleteTable("tbl_routine_categories");            
               DeleteTable("tbl_store_orders");
                       // table has been removed from model
                       // DeleteTable("tbl_unregistered_buyer");
               DeleteTable("tbl_user_stats");            
               DeleteTable("tbl_store_product_colors");            
               DeleteTable("tbl_store_products_has_size");
               DeleteTable("tbl_store_products");
               DeleteTable("tbl_store_product_subtypes");
               DeleteTable("tbl_faculty_playlists");  // order of importing is different                        
               DeleteTable("faculty_has_performance");  // added later
               DeleteTable("tbl_faculty");
               DeleteTable("tbl_date_routine_dancers");            
               DeleteTable("tbl_routines_has_teacher");
               DeleteTable("tbl_routines");            
               DeleteTable("tbl_online_critiques_judges");
               DeleteTable("tbl_scholarships");
               DeleteTable("tbl_online_critiques_access");
               DeleteTable("tbl_date_schedule_competition");            
               DeleteTable("tbl_user_has_dancer");            
               DeleteTable("tbl_studios_has_dancer");
               DeleteTable("tbl_dancer");            
               DeleteTable("person_has_contact_type");
               DeleteTable("studios_has_person");
                 DeleteTable("tbl_user");
                 DeleteTable("tbl_person");
               DeleteTable("tbl_studio_contacts");  
                 DeleteTable("tbl_studios");
                 DeleteTable("venue_contact_type");
                 DeleteTable("hotel_contact_type");
                 DeleteTable("tour_dates_workshop_room");
                 DeleteTable("tbl_levels");
                 DeleteTable("tbl_tour_dates");
                 DeleteTable("tbl_hotels");
                 DeleteTable("tbl_venues");
                 DeleteTable("tbl_addresses");            
                           // DeleteTable("tbl_fee_types");       //deleted table
                 DeleteTable("tbl_season_events");
                 DeleteTable("tbl_soty_type");
                 DeleteTable("tbl_routine_types");
                           //DeleteTable("tbl_time_type");         //deleted table
                           //DeleteTable("tbl_score");             //deleted table
               DeleteTable("tbl_songs");
                 DeleteTable("tbl_performance_divisions");
                 DeleteTable("tbl_category");
                 DeleteTable("tbl_age_divisions");
                 DeleteTable("tbl_playlist_workshop_levels");
                           // DeleteTable("tbl_current_season");
                 DeleteTable("tbl_events");
                 DeleteTable("tbl_promo_codes_type");
                 DeleteTable("tbl_seasons");
                 DeleteTable("tbl_payment_method");
                 DeleteTable("tbl_workshop_rooms");
                 DeleteTable("tbl_event_types");
                 DeleteTable("tbl_contact_type");
                 DeleteTable("tbl_states");
                 DeleteTable("tbl_gender");
                 DeleteTable("tbl_store_colors");
                 DeleteTable("tbl_person_types");
                 DeleteTable("tbl_store_sizes");
                 DeleteTable("tbl_store_product_types");
                 DeleteTable("tbl_countries");
                 DeleteTable("tbl_cities");
               */
            /* 
            Tbl_city tab0 = new Tbl_city();
            tab0.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
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

          // Tbl_score tab19 = new Tbl_score();                     // deleted table
          // tab19.Remigration(DanceteaManager, Pgdbbreakthefloor);

          //Tbl_time_type tab20 = new Tbl_time_type();              // deleted table
          //tab20.Remigration(DanceteaManager, Pgdbbreakthefloor);

          Tbl_routine_types tab21 = new Tbl_routine_types();
          tab21.Remigration(DanceteaManager, Pgdbbreakthefloor);

          Tbl_soty_type tab22 = new Tbl_soty_type();
          tab22.Remigration(DanceteaManager, Pgdbbreakthefloor);

          Tbl_season_events tab23 = new Tbl_season_events();
          tab23.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
          //Tbl_fee_types tab24 = new Tbl_fee_types();              // deleted table
          //tab24.Remigration(DanceteaManager, Pgdbbreakthefloor);
          
          Tbl_tour_dates tab25 = new Tbl_tour_dates();
          tab25.Remigration(DanceteaManager, Pgdbbreakthefloor);

           Tbl_level tab27 = new Tbl_level();
           tab27.Remigration(DanceteaManager, Pgdbbreakthefloor);

           Tour_dates_workshop_room tab26 = new Tour_dates_workshop_room();
           tab26.Remigration(DanceteaManager, Pgdbbreakthefloor);

           Tbl_studios tab28 = new Tbl_studios();
           tab28.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_users tab29 = new Tbl_users();
            tab29.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_studio_has_person tab30 = new Tbl_studio_has_person();
            tab30.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            
            Tbl_dancer tab31=new Tbl_dancer();
            tab31.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_dancer_II tab32 = new Tbl_dancer_II();
            tab32.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_user_has_dancer tab33 = new Tbl_user_has_dancer();
            tab33.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            DummyData1 Dummy1 = new DummyData1();
            Dummy1.Remigration(Mybreak_db, Pgdbbreakthefloor);            
            
            Tbl_date_schedule_competition tab34 = new Tbl_date_schedule_competition();
            tab34.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_online_critiques_access tab35 = new Tbl_online_critiques_access();
            tab35.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_scholarships tab36 = new Tbl_scholarships();
            tab36.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_online_critiques_judges tab37 = new Tbl_online_critiques_judges();
            tab37.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_routines tab38 = new Tbl_routines();
            tab38.Remigration(DanceteaManager, Pgdbbreakthefloor);

            DummyData2 Dummy2 = new DummyData2();
            Dummy2.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_date_routine_dancers tab39 = new Tbl_date_routine_dancers();
            tab39.Remigration(DanceteaManager, Pgdbbreakthefloor);
             
            Tbl_faculty tab40 = new Tbl_faculty();
            tab40.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_store_product_subtypes tab41 = new Tbl_store_product_subtypes();
            tab41.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_store_products tab42 = new Tbl_store_products();
            tab42.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_store_products_has_size tab43 = new Tbl_store_products_has_size();
            tab43.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_store_product_colors tab44 = new Tbl_store_product_colors();
            tab44.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_user_stats tab45 = new Tbl_user_stats();
            tab45.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_store_orders tab46 = new Tbl_store_orders();
            tab46.Remigration(Mybreak_db, Pgdbbreakthefloor);
           
            Tbl_routine_categories tab47 = new Tbl_routine_categories();
            tab47.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_promo_codes tab48 = new Tbl_promo_codes();
            tab48.Remigration(DanceteaManager, Pgdbbreakthefloor);
            

            Tbl_event_reg_type_names tab49x = new Tbl_event_reg_type_names();
            tab49x.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_event_reg_types tab49 = new Tbl_event_reg_types();
            tab49.Remigration(DanceteaManager, Pgdbbreakthefloor);
            

            
                    // table has been removed from model !!!!!!!!!
                    //Tbl_events_has_promo_code tab50 = new Tbl_events_has_promo_code();
                    //tab50.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_perf_div_type tab51 = new Tbl_perf_div_type();
            tab51.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_date_routines tab52 = new Tbl_date_routines();
            tab52.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_store_hearts tab53 = new Tbl_store_hearts();
            tab53.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_user_hearts tab54 = new Tbl_user_hearts();
            tab54.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_store_giftcards tab55 = new Tbl_store_giftcards();
            tab55.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_store_products_inventory tab56 = new Tbl_store_products_inventory();
            tab56.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_jobs tab57 = new Tbl_jobs();
            tab57.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_staff_types tab58 = new Tbl_staff_types();
            tab58.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_staff tab59 = new Tbl_staff();
            tab59.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_competition_cash_awards tab60 = new Tbl_competition_cash_awards();
            tab60.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_date_mybtf_exceptions tab61 = new Tbl_date_mybtf_exceptions();
            tab61.Remigration(DanceteaManager, Pgdbbreakthefloor);            
            
            Tbl_date_playlists tab62 = new Tbl_date_playlists();
            tab62.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_faculty_playlists tab63 = new Tbl_faculty_playlists();
            tab63.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_workshop_levels tab64 = new Tbl_workshop_levels();
            tab64.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_awards_type tab65 = new Tbl_awards_type();
            tab65.Remigration(DanceteaManager, Pgdbbreakthefloor);
           
            Tbl_studio_awards tab66 = new Tbl_studio_awards();
            tab66.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_special_awards tab67 = new Tbl_special_awards();
            tab67.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_date_special_awards tab68 = new Tbl_date_special_awards();
            tab68.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_date_studio_awards tab69 = new Tbl_date_studio_awards();
            tab69.Remigration(DanceteaManager, Pgdbbreakthefloor);
             
            Tbl_date_studios tab70 = new Tbl_date_studios();
            tab70.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_online_scoring tab71 = new Tbl_online_scoring();
            tab71.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_online_scoring_has_faculty tab72 = new Tbl_online_scoring_has_faculty();
            tab72.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_admin tab73 = new Tbl_admin();
            tab73.Remigration(DanceteaManager, Pgdbbreakthefloor);
                        
            Tbl_dts_reg_types tab75 = new Tbl_dts_reg_types();
            tab75.Remigration(DanceteaManager, Pgdbbreakthefloor);
            */
                        
            Tbl_date_schedule_workshops tab77 = new Tbl_date_schedule_workshops();
            tab77.SupRemigration(DanceteaManager, Pgdbbreakthefloor);
            /*
            tbl_schedule_workshops_room tab78 = new tbl_schedule_workshops_room();
            tab78.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_date_scholarships tab79 = new Tbl_date_scholarships();
            tab79.Remigration(DanceteaManager, Pgdbbreakthefloor);            
            
            Tbl_waivers tab81 = new Tbl_waivers();
            tab81.Remigration(DanceteaManager, Pgdbbreakthefloor);
            

            //  START TBL_REGISTRATION ----------------------------------
            
            Tbl_registration tab74 = new Tbl_registration();
            tab74.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
                        
            Tbl_registration2 tab82 = new Tbl_registration2();
            tab82.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            // END TBL_REGISTRATION --------------------------------------
            
            Tbl_event_attendees tab76 = new Tbl_event_attendees();
            tab76.Remigration(DanceteaManager, Pgdbbreakthefloor);            
            
            Tbl_registrations_attendees_dts tab83 = new Tbl_registrations_attendees_dts();
            tab83.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_registrations_best_dancers tab84 = new Tbl_registrations_best_dancers();
            tab84.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_registrations_routines tab85 = new Tbl_registrations_routines();
            tab85.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_registrations_dancers tab86 = new Tbl_registrations_dancers();
            tab86.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Registrations_routines_dancers tab87 = new Registrations_routines_dancers();
            tab87.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_user_registrations_specialty tab88 = new Tbl_user_registrations_specialty();
            tab88.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_user_registrations_soty tab89 = new Tbl_user_registrations_soty();
            tab89.Remigration(Mybreak_db, Pgdbbreakthefloor);            
            
            Tbl_event_registrations tab90 = new Tbl_event_registrations();
            tab90.Remigration(DanceteaManager, Pgdbbreakthefloor);
             
            Tbl_dts_registrations tab91 = new Tbl_dts_registrations();
            tab91.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            
            Tbl_date_dancers tab92 = new Tbl_date_dancers();
            tab92.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_dts_fees tab93 = new Tbl_dts_fees();
            tab93.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_tda_award_types tab94 = new Tbl_tda_award_types();
            tab94.Remigration(DanceteaManager, Pgdbbreakthefloor);
                                    
            Tbl_store_promocodes tab96 = new Tbl_store_promocodes();
            tab96.Remigration(Mybreak_db, Pgdbbreakthefloor);
            
            Tbl_dts_attendees tab97 = new Tbl_dts_attendees();
            tab97.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_competition_awards tab98 = new Tbl_competition_awards();
            tab98.Remigration(DanceteaManager, Pgdbbreakthefloor);
            
            Tbl_tda_award_nominations tab99 = new Tbl_tda_award_nominations();
            tab99.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_tda_peopleschoice_votes tab95 = new Tbl_tda_peopleschoice_votes();
            tab95.Remigration(DanceteaManager, Pgdbbreakthefloor);

            Tbl_tda_bestdancer_data tab100 = new Tbl_tda_bestdancer_data();
            tab100.Remigration(DanceteaManager, Pgdbbreakthefloor);     
            */

        }

        public void SuplementRemigration(string pSuplementDateFrom)
        {
            Mybreak_db.Message = pSuplementDateFrom;
            Tbl_jobs tab57supl = new Tbl_jobs();
            tab57supl.SupRemigration(DanceteaManager, Pgdbbreakthefloor, pSuplementDateFrom);

            
            Tbl_events tabEventssupl = new Tbl_events();
            tabEventssupl.SupRemigration(DanceteaManager, Pgdbbreakthefloor, pSuplementDateFrom);
        }

        private void DeleteTable(string pTableName)
        {
            Pgdbbreakthefloor.Delete(pTableName);
        }
    }
}
 