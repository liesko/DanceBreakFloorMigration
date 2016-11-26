DROP TABLE IF EXISTS "tbl_staff_types" CASCADE;
CREATE TABLE "tbl_staff_types" (
	"staff_types_id" int4 NOT NULL,
	"name" int4,
	PRIMARY KEY("staff_types_id")
);

DROP TABLE IF EXISTS "tbl_staff" CASCADE;
CREATE TABLE "tbl_staff" (
	"staff_id" int4 NOT NULL,
	"fname" varchar,
	"lname" varchar,
	"staff_types_id" int4 NOT NULL,
	PRIMARY KEY("staff_id")
);

DROP TABLE IF EXISTS "tbl_online_scoring" CASCADE;
CREATE TABLE "tbl_online_scoring" (
	"online_scoring_id" int4 NOT NULL,
	"### routineid" int4,
	"### tourdateid" int4,
	"### studioid" int4,
	"facultyid_json" text,
	"data_json" text,
	"compgroup" varchar,
	"total_score" int4,
	"dropped_score" int4,
	"### awardid" int4,
	PRIMARY KEY("online_scoring_id")
);

DROP TABLE IF EXISTS "tbl_online_critiques_access" CASCADE;
CREATE TABLE "tbl_online_critiques_access" (
	"online_critiques_access_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"studios_id" int4 NOT NULL,
	"accesscode" varchar,
	PRIMARY KEY("online_critiques_access_id")
);

DROP TABLE IF EXISTS "tbl_online_critiques_judges" CASCADE;
CREATE TABLE "tbl_online_critiques_judges" (
	"online_critiques_judges_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"startnumberhasa" int4,
	"endnumber" int4,
	"endnumberhasa" int4,
	"judge_json" int4,
	PRIMARY KEY("online_critiques_judges_id")
);

DROP TABLE IF EXISTS "tbl_jobs" CASCADE;
CREATE TABLE "tbl_jobs" (
	"jobs_id" int4 NOT NULL,
	"title" varchar,
	"jobtype" varchar,
	"description" text,
	"views" int4,
	"showonsite" int4,
	PRIMARY KEY("jobs_id")
);

DROP TABLE IF EXISTS "tbl_competition_cash_awards" CASCADE;
CREATE TABLE "tbl_competition_cash_awards" (
	"competition_cash_awards_id" int4 NOT NULL,
	"highscoretype" varchar,
	"place" int4,
	"amount" int4,
	"description" varchar,
	"date_routines_id" int4 NOT NULL,
	PRIMARY KEY("competition_cash_awards_id")
);

DROP TABLE IF EXISTS "tbl_events_has_promo_code" CASCADE;
CREATE TABLE "tbl_events_has_promo_code" (
	"promo_codes_id" int4 NOT NULL,
	"events_id" int4 NOT NULL,
	"tbl_event_reg_types_id" int4 NOT NULL,
	"discount_fee" int4,
	"fee" int4,
	PRIMARY KEY("promo_codes_id","events_id","tbl_event_reg_types_id")
);

DROP TABLE IF EXISTS "tbl_event_reg_types" CASCADE;
CREATE TABLE "tbl_event_reg_types" (
	"tbl_event_reg_types_id" int4 NOT NULL,
	"name" varchar,
	PRIMARY KEY("tbl_event_reg_types_id")
);

DROP TABLE IF EXISTS "tbl_store_orders" CASCADE;
CREATE TABLE "tbl_store_orders" (
	"store_orders_id" int4 NOT NULL,
	"user_id" int4,
	"unregistered_buyer_id" int4,
	"order_hash" varchar,
	"submitted" varchar,
	"shipped" int4,
	"statsuser" varchar,
	"digitalonly" int4 DEFAULT 0,
	"fees_paid" varchar,
	"tracking" varchar DEFAULT 0,
	"transactionid" varchar,
	"label_json" text,
	PRIMARY KEY("store_orders_id")
);

DROP TABLE IF EXISTS "tbl_soty_type_routine" CASCADE;
CREATE TABLE "tbl_soty_type_routine" (
	"user_registrations_soty_id" int4 NOT NULL,
	"soty_type_id" int4 NOT NULL,
	"date_routines_id" int4 NOT NULL
);

DROP TABLE IF EXISTS "tbl_soty_type" CASCADE;
CREATE TABLE "tbl_soty_type" (
	"soty_type_id" int4 NOT NULL,
	"name" int4 NOT NULL,
	PRIMARY KEY("soty_type_id")
);

DROP TABLE IF EXISTS "tbl_user_registrations_soty" CASCADE;
CREATE TABLE "tbl_user_registrations_soty" (
	"user_registrations_soty_id" int4 NOT NULL,
	"registration_id" int4 NOT NULL,
	"has_soty" int4 NOT NULL DEFAULT 0,
	PRIMARY KEY("user_registrations_soty_id")
);

DROP TABLE IF EXISTS "tbl_brochure_requests" CASCADE;
CREATE TABLE "tbl_brochure_requests" (
	"brochure_requests_id" int4 NOT NULL,
	"???" int4,
	PRIMARY KEY("brochure_requests_id")
);

DROP TABLE IF EXISTS "tbl_unregistered_buyer" CASCADE;
CREATE TABLE "tbl_unregistered_buyer" (
	"unregistered_buyer_id" int4 NOT NULL,
	"fname" varchar,
	"lname" varchar,
	"email" varchar,
	PRIMARY KEY("unregistered_buyer_id")
);

DROP TABLE IF EXISTS "tbl_store_products_has_size" CASCADE;
CREATE TABLE "tbl_store_products_has_size" (
	"store_products_has_size" SERIAL NOT NULL,
	"store_sizes_id" int4 NOT NULL,
	"store_products_id" int4 NOT NULL,
	PRIMARY KEY("store_products_has_size","store_sizes_id","store_products_id")
);

DROP TABLE IF EXISTS "tbl_store_sizes" CASCADE;
CREATE TABLE "tbl_store_sizes" (
	"store_sizes_id" int4 NOT NULL,
	"size" varchar NOT NULL,
	PRIMARY KEY("store_sizes_id")
);

DROP TABLE IF EXISTS "faculty_has_performance" CASCADE;
CREATE TABLE "faculty_has_performance" (
	"faculty_id" int4 NOT NULL,
	"performance_divisions_id" int4 NOT NULL
);

DROP TABLE IF EXISTS "tbl_registration_has_dancer" CASCADE;
CREATE TABLE "tbl_registration_has_dancer" (
	"registration_id" int4 NOT NULL,
	"dancer_id" int4 NOT NULL,
	PRIMARY KEY("registration_id","dancer_id")
);

DROP TABLE IF EXISTS "tbl_studios_has_dancer" CASCADE;
CREATE TABLE "tbl_studios_has_dancer" (
	"dancer_id" int4 NOT NULL,
	"studios_id" int4 NOT NULL,
	PRIMARY KEY("dancer_id","studios_id")
);

DROP TABLE IF EXISTS "tbl_user_has_dancer" CASCADE;
CREATE TABLE "tbl_user_has_dancer" (
	"dancer_id" int4 NOT NULL,
	"user_id" int4 NOT NULL,
	PRIMARY KEY("dancer_id","user_id")
);

DROP TABLE IF EXISTS "tbl_songs" CASCADE;
CREATE TABLE "tbl_songs" (
	"songs_id" int4 NOT NULL,
	"song_name" varchar NOT NULL,
	"artist_name" varchar,
	PRIMARY KEY("songs_id")
);

DROP TABLE IF EXISTS "tbl_store_product_colors" CASCADE;
CREATE TABLE "tbl_store_product_colors" (
	"store_colors_id" int4 NOT NULL,
	"store_products_id" int4 NOT NULL,
	PRIMARY KEY("store_colors_id","store_products_id")
);

DROP TABLE IF EXISTS "tbl_store_product_types" CASCADE;
CREATE TABLE "tbl_store_product_types" (
	"product_types_id" int4 NOT NULL,
	"name" varchar,
	PRIMARY KEY("product_types_id")
);

DROP TABLE IF EXISTS "tbl_store_product_subtypes" CASCADE;
CREATE TABLE "tbl_store_product_subtypes" (
	"product_subtypes_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"product_types_id" int4 NOT NULL,
	PRIMARY KEY("product_subtypes_id")
);

DROP TABLE IF EXISTS "tbl_store_products_inventory" CASCADE;
CREATE TABLE "tbl_store_products_inventory" (
	"products_inventory_id" int4 NOT NULL,
	"store_products_id" int4 NOT NULL,
	"store_colors_id" int4 DEFAULT 0,
	"store_sizes_id" int4 DEFAULT 0,
	"qty_onsite" int4,
	"qty_warehouse" int4,
	PRIMARY KEY("products_inventory_id")
);

DROP TABLE IF EXISTS "tbl_store_products" CASCADE;
CREATE TABLE "tbl_store_products" (
	"store_products_id" int4 NOT NULL,
	"tour_dates_id" int4,
	"events_id" int4 NOT NULL,
	"product_subtypes_id" int4,
	"product" varchar NOT NULL,
	"description" text NOT NULL DEFAULT 'no desc',
	"price" float4,
	"shipping" float4,
	"featured" int4 DEFAULT 0,
	"timeadded" int4 DEFAULT 1349326800,
	"instock" int4 DEFAULT 1,
	"showonsite" int4 DEFAULT 1,
	"onsale" int4 DEFAULT 0,
	"sale_price" int4 DEFAULT 0,
	"weight" int4 DEFAULT 0,
	"trending" int4 DEFAULT 0,
	"short_description" text,
	"sort" int4,
	PRIMARY KEY("store_products_id")
);

COMMENT ON COLUMN "tbl_store_products"."weight" IS 'weight';

DROP TABLE IF EXISTS "tbl_store_hearts" CASCADE;
CREATE TABLE "tbl_store_hearts" (
	"store_hearts_id" int4 NOT NULL,
	"routine_id" int4 NOT NULL DEFAULT 0,
	"individual_id" int4 DEFAULT 0,
	"is_video" int4 NOT NULL DEFAULT 0,
	"hearts" int4 NOT NULL DEFAULT 0,
	"url" varchar,
	PRIMARY KEY("store_hearts_id")
);

DROP TABLE IF EXISTS "tbl_store_giftcards" CASCADE;
CREATE TABLE "tbl_store_giftcards" (
	"store_giftcards_id" int4 NOT NULL,
	"code" varchar NOT NULL,
	"initial_balance" float4,
	"balance" float4,
	"created" int4,
	PRIMARY KEY("store_giftcards_id")
);

DROP TABLE IF EXISTS "tbl_faculty_tweets" CASCADE;
CREATE TABLE "tbl_faculty_tweets" (
	"faculty_tweets_id" int4 NOT NULL,
	"handle" varchar,
	"tweet" varchar,
	PRIMARY KEY("faculty_tweets_id")
);

DROP TABLE IF EXISTS "tbl_store_colors" CASCADE;
CREATE TABLE "tbl_store_colors" (
	"store_colors_id" int4 NOT NULL,
	"name" varchar(100) NOT NULL,
	PRIMARY KEY("store_colors_id")
);

DROP TABLE IF EXISTS "tbl_user_hearts" CASCADE;
CREATE TABLE "tbl_user_hearts" (
	"user_hearts_id" int4 NOT NULL,
	"user_id" int4 NOT NULL,
	"store_hearts_id" int4 NOT NULL,
	PRIMARY KEY("user_hearts_id")
);

DROP TABLE IF EXISTS "tbl_user_stats" CASCADE;
CREATE TABLE "tbl_user_stats" (
	"user_stats_id" int4 NOT NULL,
	"user_id" int4 NOT NULL,
	"activation_code" varchar,
	"time_signup" varchar,
	"time_activate" varchar,
	"time_last_login" varchar,
	"time_disable" varchar,
	"login_count" int4 DEFAULT 0,
	"ips" text,
	"dontshow1" int4 DEFAULT 0,
	PRIMARY KEY("user_stats_id")
);

DROP TABLE IF EXISTS "tbl_date_studio_awards" CASCADE;
CREATE TABLE "tbl_date_studio_awards" (
	"studio_awards_id" int4 NOT NULL,
	"studios_id" int4 NOT NULL,
	"awards_type_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"winner" int4 NOT NULL DEFAULT 0,
	PRIMARY KEY("studio_awards_id")
);

DROP TABLE IF EXISTS "tbl_awards_type" CASCADE;
CREATE TABLE "tbl_awards_type" (
	"awards_type_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("awards_type_id")
);

DROP TABLE IF EXISTS "tbl_date_special_awards" CASCADE;
CREATE TABLE "tbl_date_special_awards" (
	"special_awards_id" int4 NOT NULL,
	"awards_id" int4 NOT NULL,
	"date_routines_id" int4 NOT NULL,
	PRIMARY KEY("special_awards_id")
);

DROP TABLE IF EXISTS "tbl_scholarships" CASCADE;
CREATE TABLE "tbl_scholarships" (
	"scholarships_id" int4 NOT NULL,
	"active" int4,
	"report_order" int4 DEFAULT 999,
	"isclass" int4,
	"name" varchar,
	"events_id" int4 NOT NULL,
	PRIMARY KEY("scholarships_id")
);

DROP TABLE IF EXISTS "tbl_date_scholarships" CASCADE;
CREATE TABLE "tbl_date_scholarships" (
	"tour_dates_id" int4 NOT NULL,
	"scholarships_id" int4 NOT NULL,
	"winner" int4 NOT NULL DEFAULT 0,
	"code" varchar,
	PRIMARY KEY("scholarships_id","tour_dates_id")
);

DROP TABLE IF EXISTS "schedule_workshops_room" CASCADE;
CREATE TABLE "schedule_workshops_room" (
	"schedule_workshops_id" int4 NOT NULL,
	"workshop_room_plan_id" int4 NOT NULL,
	"description" int4,
	PRIMARY KEY("schedule_workshops_id","workshop_room_plan_id")
);

DROP TABLE IF EXISTS "tbl_workshop_room_plan" CASCADE;
CREATE TABLE "tbl_workshop_room_plan" (
	"workshop_room_plan_id" int4 NOT NULL,
	"room_bold" int4 NOT NULL DEFAULT 0,
	"room_highlight" int4 NOT NULL DEFAULT 0,
	"description" varchar,
	PRIMARY KEY("workshop_room_plan_id")
);

DROP TABLE IF EXISTS "tbl_date_schedule_workshops" CASCADE;
CREATE TABLE "tbl_date_schedule_workshops" (
	"schedule_workshops_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"date" varchar,
	"start_time" varchar,
	"duration" int4,
	"span" int4,
	PRIMARY KEY("schedule_workshops_id")
);

DROP TABLE IF EXISTS "tbl_date_schedule_competition" CASCADE;
CREATE TABLE "tbl_date_schedule_competition" (
	"schedule_competition_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"last_update" varchar,
	"dates" text,
	"awards" text,
	PRIMARY KEY("schedule_competition_id")
);

DROP TABLE IF EXISTS "tbl_date_studios" CASCADE;
CREATE TABLE "tbl_date_studios" (
	"tbl_date_studios_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"studios_id" int4 NOT NULL,
	"total_fees" int4,
	"fees_paid" int4,
	"credit" int4 DEFAULT 0,
	"full_rates" int4,
	"independent" int4 DEFAULT 0,
	"invoice_note" text,
	"ftv" int4,
	"ftc" int4,
	"??studiocode" text,
	"#statsregid" int4,
	"??emailer_count" int4,
	"??confirmdate" int4,
	PRIMARY KEY("tbl_date_studios_id")
);

DROP TABLE IF EXISTS "tbl_promo_codes_type" CASCADE;
CREATE TABLE "tbl_promo_codes_type" (
	"promo_codes_type_id" int4 NOT NULL,
	"name" int4 NOT NULL,
	PRIMARY KEY("promo_codes_type_id")
);

DROP TABLE IF EXISTS "tbl_promo_codes" CASCADE;
CREATE TABLE "tbl_promo_codes" (
	"promo_codes_id" int4 NOT NULL,
	"promo_codes_type_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"description" text,
	"value" int4,
	"charges" int4,
	"uses" int4 NOT NULL DEFAULT 0,
	"active" int4,
	"noncommuteronly" int4 DEFAULT 0,
	"onceperreg" int4 DEFAULT 0,
	"#intensiveid" int4,
	PRIMARY KEY("promo_codes_id")
);

DROP TABLE IF EXISTS "tbl_event_attendees" CASCADE;
CREATE TABLE "tbl_event_attendees" (
	"event_attendees_id" int4 NOT NULL,
	"registration_id" int4 NOT NULL,
	"samt" varchar DEFAULT 0,
	"sfrom" varchar,
	"note" text,
	"canceled" int4 DEFAULT 0,
	"audition_number" int4 DEFAULT 0,
	"#intensiveid" int4,
	"promo_codes_id" int4,
	PRIMARY KEY("event_attendees_id")
);

DROP TABLE IF EXISTS "tbl_awards" CASCADE;
CREATE TABLE "tbl_awards" (
	"awards_id" int4 NOT NULL,
	"awards_type_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"lowest" int4,
	"highest" int4,
	"report_order" int4,
	PRIMARY KEY("awards_id")
);

DROP TABLE IF EXISTS "tbl_date_routine_dancers" CASCADE;
CREATE TABLE "tbl_date_routine_dancers" (
	"tour_dates_id" int4 NOT NULL,
	"routine_id" int4 NOT NULL,
	"dancer_id" int4 NOT NULL,
	PRIMARY KEY("tour_dates_id","routine_id","dancer_id")
);

DROP TABLE IF EXISTS "tbl_date_mybtf_exceptions" CASCADE;
CREATE TABLE "tbl_date_mybtf_exceptions" (
	"mybtf_exceptions_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"user_id" int4 NOT NULL,
	"level" int4,
	PRIMARY KEY("mybtf_exceptions_id")
);

DROP TABLE IF EXISTS "routines_time_type" CASCADE;
CREATE TABLE "routines_time_type" (
	"date_routines_id" int4 NOT NULL,
	"time_type_id" int4 NOT NULL,
	"value" int4 NOT NULL,
	PRIMARY KEY("date_routines_id","time_type_id")
);

DROP TABLE IF EXISTS "tbl_time_type" CASCADE;
CREATE TABLE "tbl_time_type" (
	"time_type_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("time_type_id")
);

DROP TABLE IF EXISTS "tbl_date_routines_score" CASCADE;
CREATE TABLE "tbl_date_routines_score" (
	"date_routines_id" int4 NOT NULL,
	"score_id" int4 NOT NULL,
	"value" int4 NOT NULL,
	PRIMARY KEY("date_routines_id","score_id")
);

DROP TABLE IF EXISTS "tbl_score" CASCADE;
CREATE TABLE "tbl_score" (
	"score_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("score_id")
);

DROP TABLE IF EXISTS "tbl_routine_types" CASCADE;
CREATE TABLE "tbl_routine_types" (
	"routine_types_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("routine_types_id")
);

DROP TABLE IF EXISTS "tbl_perf_div_type" CASCADE;
CREATE TABLE "tbl_perf_div_type" (
	"perf_div_type_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("perf_div_type_id")
);

DROP TABLE IF EXISTS "tbl_routine_categories" CASCADE;
CREATE TABLE "tbl_routine_categories" (
	"routine_categories_id" int4 NOT NULL,
	"category_id" int4 NOT NULL,
	"new_field0" int4,
	"min_dancers" int4,
	"full_fee_per_dancer" varchar,
	"duration" int4,
	"new_field1" int4,
	"abbreviation" varchar,
	"discount_fee_per_dancer" varchar,
	"finale_fee_per_dancer" varchar,
	"finale_prelim_fee_per_dancer" varchar,
	PRIMARY KEY("routine_categories_id","category_id")
);

DROP TABLE IF EXISTS "tbl_category" CASCADE;
CREATE TABLE "tbl_category" (
	"category_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("category_id")
);

DROP TABLE IF EXISTS "tbl_age_divisions" CASCADE;
CREATE TABLE "tbl_age_divisions" (
	"age_divisions_id" int4 NOT NULL,
	"range" varchar,
	"minimum_age" int4,
	"playlist_workshop_levels_id" int4 NOT NULL,
	PRIMARY KEY("age_divisions_id")
);

DROP TABLE IF EXISTS "tbl_date_routines" CASCADE;
CREATE TABLE "tbl_date_routines" (
	"date_routines_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"routine_id" int4 NOT NULL,
	"studios_id" int4,
	"age_divisions_id" int4,
	"routine_categories_id" int4,
	"category_id" int4,
	"performance_divisions_id" int4,
	"perf_div_type_id" int4,
	"routine_types_id" int4,
	"prelims" int4 DEFAULT 0,
	"vips" int4 DEFAULT 0,
	"finals" int4 DEFAULT 1,
	"fee" int4,
	"finals_time" varchar,
	"canceled" int4 DEFAULT 0,
	"custom_dancer_count" int4 DEFAULT 0,
	"number_finals" int4 DEFAULT 0,
	"number_prelims" int4 DEFAULT 0,
	"number_vips" int4 DEFAULT 0,
	"finals_has_a" int4 DEFAULT 0,
	"prelims_has_a" int4 DEFAULT 0,
	"vips_has_a" int4 DEFAULT 0,
	"duration" int4,
	"custom_fee" int4 DEFAULT 0,
	"place_hsa" int4 DEFAULT 0,
	"place_hsp" int4 DEFAULT 0,
	"room_finals" int4 DEFAULT 1,
	"award_typename" int4,
	"room_prelims" int4,
	"room_vips" int4,
	"uploaded_duration" int4,
	"uploaded" int4,
	PRIMARY KEY("date_routines_id")
);

DROP TABLE IF EXISTS "tbl_faculty_playlists" CASCADE;
CREATE TABLE "tbl_faculty_playlists" (
	"date_playlists_id" int4 NOT NULL,
	"faculty_id" int4 NOT NULL,
	PRIMARY KEY("date_playlists_id","faculty_id")
);

DROP TABLE IF EXISTS "tbl_date_playlists" CASCADE;
CREATE TABLE "tbl_date_playlists" (
	"date_playlists_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"songs_id" int4 NOT NULL,
	"workshop_levels_id" int4,
	"playlist_workshop_levels_id" int4,
	PRIMARY KEY("date_playlists_id")
);

DROP TABLE IF EXISTS "tbl_faculty" CASCADE;
CREATE TABLE "tbl_faculty" (
	"faculty_id" int4 NOT NULL,
	"events_id" int4 NOT NULL,
	"dancer_id" int4 NOT NULL,
	"bio" varchar,
	"website" varchar,
	"director" varchar,
	"twitter" varchar,
	"instagram" varchar,
	"youtube" varchar,
	PRIMARY KEY("faculty_id")
);

DROP TABLE IF EXISTS "tbl_performance_divisions" CASCADE;
CREATE TABLE "tbl_performance_divisions" (
	"performance_divisions_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("performance_divisions_id")
);

DROP TABLE IF EXISTS "tbl_workshop_levels" CASCADE;
CREATE TABLE "tbl_workshop_levels" (
	"workshop_levels_id" int4 NOT NULL,
	"playlist_workshop_levels_id" int4 NOT NULL,
	"discount_fee" int4,
	"full_fee" int4,
	"finale_discount_fee" int4,
	"finale_full_fee" int4,
	"one_day_full_fee" int4,
	"one_day_discount_fee" int4,
	PRIMARY KEY("workshop_levels_id","playlist_workshop_levels_id")
);

DROP TABLE IF EXISTS "tbl_playlist_workshop_levels" CASCADE;
CREATE TABLE "tbl_playlist_workshop_levels" (
	"playlist_workshop_levels_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("playlist_workshop_levels_id")
);

DROP TABLE IF EXISTS "tbl_vip_type" CASCADE;
CREATE TABLE "tbl_vip_type" (
	"vip_type_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("vip_type_id")
);

DROP TABLE IF EXISTS "tbl_waivers" CASCADE;
CREATE TABLE "tbl_waivers" (
	"waivers_id" int4 NOT NULL,
	"dancer_id" int4 NOT NULL,
	PRIMARY KEY("waivers_id")
);

DROP TABLE IF EXISTS "tour_dates_workshop_room" CASCADE;
CREATE TABLE "tour_dates_workshop_room" (
	"workshop_room_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	PRIMARY KEY("workshop_room_id","tour_dates_id")
);

DROP TABLE IF EXISTS "tbl_workshop_room" CASCADE;
CREATE TABLE "tbl_workshop_room" (
	"workshop_room_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("workshop_room_id")
);

DROP TABLE IF EXISTS "hotel_contact_type" CASCADE;
CREATE TABLE "hotel_contact_type" (
	"hotel_contact_type_id" SERIAL NOT NULL,
	"contact_type_id" int4 NOT NULL,
	"hotel_id" int4 NOT NULL,
	"value" varchar NOT NULL,
	PRIMARY KEY("hotel_contact_type_id","contact_type_id","hotel_id")
);

DROP TABLE IF EXISTS "tbl_hotel" CASCADE;
CREATE TABLE "tbl_hotel" (
	"hotel_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"address_id" int4 NOT NULL,
	"hotel_website" int4,
	PRIMARY KEY("hotel_id")
);

DROP TABLE IF EXISTS "venue_contact_type" CASCADE;
CREATE TABLE "venue_contact_type" (
	"venue_contact_type_id" SERIAL NOT NULL,
	"venue_id" int4 NOT NULL,
	"contact_type_id" int4 NOT NULL,
	"value" varchar NOT NULL,
	PRIMARY KEY("venue_contact_type_id","venue_id","contact_type_id")
);

DROP TABLE IF EXISTS "tbl_venue" CASCADE;
CREATE TABLE "tbl_venue" (
	"venue_id" int4 NOT NULL,
	"address_id" int4 NOT NULL,
	"name" varchar,
	"venue_website" varchar,
	PRIMARY KEY("venue_id")
);

DROP TABLE IF EXISTS "tbl_tour_dates" CASCADE;
CREATE TABLE "tbl_tour_dates" (
	"tour_dates_id" int4 NOT NULL,
	"season_id" int4 NOT NULL,
	"events_id" int4 NOT NULL,
	"state_id" int4,
	"venue_id" int4,
	"hotel_id" int4,
	"performance_divisions_id" int4,
	"city" varchar,
	"start_date" date,
	"end_date" date,
	"cutoff_start_date" date,
	"cutoff_end_date" date,
	"room_rate" varchar,
	"notes" varchar,
	"is_finals" int4,
	"entry_limits" varchar,
	"weather_link" int4,
	"hotel_alt" varchar,
	"custom_routine_durations" int4,
	"default_category_order" varchar,
	"routine_dist" int4,
	"roomreservations" varchar,
	"webcast_this_city" int4,
	"hotel_notes" text,
	"online_balance_payments_enabled" int4,
	"event_date_status" int4,
	"results_solo_display_count" int4,
	"show_time" varchar,
	"use_online_scoring" int4,
	"json_web_info" text,
	"json_entry_info" text,
	"json_workshop" text,
	"json_competition" text,
	"json_tda_dance" text,
	"json_mybtf" text,
	PRIMARY KEY("tour_dates_id")
);

DROP TABLE IF EXISTS "tbl_fee_types_has_tbl_registration" CASCADE;
CREATE TABLE "tbl_fee_types_has_tbl_registration" (
	"fee_types_id" int4 NOT NULL,
	"registration_id" int4 NOT NULL,
	"value" numeric NOT NULL,
	PRIMARY KEY("fee_types_id","registration_id")
);

DROP TABLE IF EXISTS "tbl_fee_types" CASCADE;
CREATE TABLE "tbl_fee_types" (
	"fee_types_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("fee_types_id")
);

DROP TABLE IF EXISTS "tbl_payment_method" CASCADE;
CREATE TABLE "tbl_payment_method" (
	"payment_method_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("payment_method_id")
);

DROP TABLE IF EXISTS "tbl_registration" CASCADE;
CREATE TABLE "tbl_registration" (
	"registration_id" int4 NOT NULL,
	"user_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"independent" int4 NOT NULL,
	"nicedate" date,
	"niceupdate" date,
	"mkupdate" numeric,
	"leftoffphp" varchar,
	"observers" int4 NOT NULL,
	"waiver" int4 NOT NULL,
	"statsregid" numeric,
	"ftc" int4,
	"ftv" int4,
	"creditamt" numeric,
	"creditfrom" varchar,
	"date" date,
	"heard" varchar,
	"details" varchar,
	"completed" bool NOT NULL DEFAULT False,
	"confirmed" bool NOT NULL DEFAULT False,
	"boxsets" text,
	"extra " text,
	"education" text,
	"payment_method_id" int4,
	"studios_id" int4,
	"enteredby" int4,
	PRIMARY KEY("registration_id")
);

COMMENT ON COLUMN "tbl_registration"."date" IS 'entry date when application has been submited';

DROP TABLE IF EXISTS "tbl_season_events" CASCADE;
CREATE TABLE "tbl_season_events" (
	"season_id" int4 NOT NULL,
	"events_id" int4 NOT NULL,
	PRIMARY KEY("season_id","events_id")
);

DROP TABLE IF EXISTS "tbl_season" CASCADE;
CREATE TABLE "tbl_season" (
	"season_id" int4 NOT NULL,
	"start_year" int4 NOT NULL,
	"end_year" int4,
	PRIMARY KEY("season_id")
);

DROP TABLE IF EXISTS "tbl_events" CASCADE;
CREATE TABLE "tbl_events" (
	"events_id" int4 NOT NULL,
	"event_types_id" int4 NOT NULL,
	"name" varchar,
	"link" varchar NOT NULL,
	"web_home_webcast_banner" numeric,
	"facebook_link" varchar,
	"ageasofyear" numeric,
	"intopmenu" numeric,
	PRIMARY KEY("events_id")
);

DROP TABLE IF EXISTS "tbl_event_types" CASCADE;
CREATE TABLE "tbl_event_types" (
	"event_types_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("event_types_id")
);

DROP TABLE IF EXISTS "tbl_dancer" CASCADE;
CREATE TABLE "tbl_dancer" (
	"dancer_id" int4 NOT NULL,
	"person_id" int4 NOT NULL,
	"parent_guardian" varchar,
	"email_parents" int4,
	PRIMARY KEY("dancer_id")
);

DROP TABLE IF EXISTS "person_has_contact_type" CASCADE;
CREATE TABLE "person_has_contact_type" (
	"person_has_contact_type_id" SERIAL NOT NULL,
	"person_id" int4 NOT NULL,
	"contact_type_id" int4 NOT NULL,
	"value" varchar,
	PRIMARY KEY("person_has_contact_type_id","person_id","contact_type_id")
);

DROP TABLE IF EXISTS "tbl_address" CASCADE;
CREATE TABLE "tbl_address" (
	"address_id" int4 NOT NULL,
	"state_id" int4,
	"address" varchar,
	"city" varchar,
	"zip" varchar,
	"country_id" int4,
	PRIMARY KEY("address_id")
);

DROP TABLE IF EXISTS "tbl_person" CASCADE;
CREATE TABLE "tbl_person" (
	"person_id" int4 NOT NULL,
	"address_id" int4,
	"gender_id" int4,
	"fname" varchar,
	"lname" varchar,
	"title" varchar,
	"birthdate" date,
	"person_types_id" int4,
	PRIMARY KEY("person_id")
);

DROP TABLE IF EXISTS "tbl_user" CASCADE;
CREATE TABLE "tbl_user" (
	"user_id" int4 NOT NULL,
	"person_id" int4 NOT NULL,
	"email" varchar,
	"password" varchar,
	"active" int4,
	PRIMARY KEY("user_id")
);

DROP TABLE IF EXISTS "tbl_person_types" CASCADE;
CREATE TABLE "tbl_person_types" (
	"person_types_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("person_types_id")
);

DROP TABLE IF EXISTS "tbl_studios" CASCADE;
CREATE TABLE "tbl_studios" (
	"studios_id" int4 NOT NULL,
	"address_id" int4 NOT NULL,
	"name" varchar,
	"notes" varchar,
	"contacts" varchar,
	PRIMARY KEY("studios_id")
);

DROP TABLE IF EXISTS "tbl_gender" CASCADE;
CREATE TABLE "tbl_gender" (
	"gender_id" int4 NOT NULL,
	"value" varchar,
	PRIMARY KEY("gender_id")
);

DROP TABLE IF EXISTS "tbl_studio_contacts" CASCADE;
CREATE TABLE "tbl_studio_contacts" (
	"studio_contacts_id" int4 NOT NULL,
	"contact_type_id" int4 NOT NULL,
	"studios_id" int4 NOT NULL,
	"value" varchar,
	PRIMARY KEY("studio_contacts_id","contact_type_id","studios_id")
);

DROP TABLE IF EXISTS "tbl_contact_type" CASCADE;
CREATE TABLE "tbl_contact_type" (
	"contact_type_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("contact_type_id")
);

DROP TABLE IF EXISTS "tbl_teacher" CASCADE;
CREATE TABLE "tbl_teacher" (
	"teacher_id" int4 NOT NULL,
	"fname" varchar NOT NULL,
	"lname" varchar NOT NULL,
	PRIMARY KEY("teacher_id")
);

DROP TABLE IF EXISTS "tbl_routines" CASCADE;
CREATE TABLE "tbl_routines" (
	"routine_id" int4 NOT NULL,
	"studios_id" int4,
	"teacher_id" int4,
	"name" varchar NOT NULL,
	CONSTRAINT "teacher_id" PRIMARY KEY("routine_id")
);

DROP TABLE IF EXISTS "tbl_states" CASCADE;
CREATE TABLE "tbl_states" (
	"state_id" int4 NOT NULL,
	"country_id" int4,
	"name" varchar NOT NULL,
	"abbr" varchar,
	PRIMARY KEY("state_id")
);

DROP TABLE IF EXISTS "tbl_countries" CASCADE;
CREATE TABLE "tbl_countries" (
	"country_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"abbr" varchar,
	PRIMARY KEY("country_id")
);

DROP TABLE IF EXISTS "tbl_dts_reg_types" CASCADE;
CREATE TABLE "tbl_dts_reg_types" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"fee" int4 NOT NULL,
	PRIMARY KEY("id")
);

ALTER TABLE "tbl_staff" ADD CONSTRAINT "tbl_staff_types" FOREIGN KEY ("staff_types_id")
	REFERENCES "tbl_staff_types"("staff_types_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_critiques_access" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_critiques_access" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("studios_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_critiques_judges" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_competition_cash_awards" ADD CONSTRAINT "tbl_date_routines" FOREIGN KEY ("date_routines_id")
	REFERENCES "tbl_date_routines"("date_routines_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_events_has_promo_code" ADD CONSTRAINT "tbl_promo_codes" FOREIGN KEY ("promo_codes_id")
	REFERENCES "tbl_promo_codes"("promo_codes_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_events_has_promo_code" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("events_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_events_has_promo_code" ADD CONSTRAINT "tbl_event_reg_types" FOREIGN KEY ("tbl_event_reg_types_id")
	REFERENCES "tbl_event_reg_types"("tbl_event_reg_types_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_orders" ADD CONSTRAINT "tbl_unregistered_buyer" FOREIGN KEY ("unregistered_buyer_id")
	REFERENCES "tbl_unregistered_buyer"("unregistered_buyer_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_orders" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("user_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_soty_type_routine" ADD CONSTRAINT "tbl_user_registrations_soty" FOREIGN KEY ("user_registrations_soty_id")
	REFERENCES "tbl_user_registrations_soty"("user_registrations_soty_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_soty_type_routine" ADD CONSTRAINT "tbl_soty_type" FOREIGN KEY ("soty_type_id")
	REFERENCES "tbl_soty_type"("soty_type_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_soty_type_routine" ADD CONSTRAINT "tbl_date_routines" FOREIGN KEY ("date_routines_id")
	REFERENCES "tbl_date_routines"("date_routines_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("registration_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products_has_size" ADD CONSTRAINT "tbl_store_sizes" FOREIGN KEY ("store_sizes_id")
	REFERENCES "tbl_store_sizes"("store_sizes_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products_has_size" ADD CONSTRAINT "tbl_store_products" FOREIGN KEY ("store_products_id")
	REFERENCES "tbl_store_products"("store_products_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "faculty_has_performance" ADD CONSTRAINT "tbl_faculty" FOREIGN KEY ("faculty_id")
	REFERENCES "tbl_faculty"("faculty_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "faculty_has_performance" ADD CONSTRAINT "tbl_performance_divisions" FOREIGN KEY ("performance_divisions_id")
	REFERENCES "tbl_performance_divisions"("performance_divisions_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registration_has_dancer" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("registration_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registration_has_dancer" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("dancer_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studios_has_dancer" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("dancer_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studios_has_dancer" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("studios_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_has_dancer" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("dancer_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_has_dancer" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("user_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_product_colors" ADD CONSTRAINT "tbl_store_colors" FOREIGN KEY ("store_colors_id")
	REFERENCES "tbl_store_colors"("store_colors_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_product_colors" ADD CONSTRAINT "tbl_store_products" FOREIGN KEY ("store_products_id")
	REFERENCES "tbl_store_products"("store_products_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_product_subtypes" ADD CONSTRAINT "store_product_types" FOREIGN KEY ("product_types_id")
	REFERENCES "tbl_store_product_types"("product_types_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products_inventory" ADD CONSTRAINT "tbl_store_products" FOREIGN KEY ("store_products_id")
	REFERENCES "tbl_store_products"("store_products_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products_inventory" ADD CONSTRAINT "tbl_store_colors" FOREIGN KEY ("store_colors_id")
	REFERENCES "tbl_store_colors"("store_colors_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products_inventory" ADD CONSTRAINT "tbl_store_sizes" FOREIGN KEY ("store_sizes_id")
	REFERENCES "tbl_store_sizes"("store_sizes_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("events_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products" ADD CONSTRAINT "tbl_store_product_subtypes" FOREIGN KEY ("product_subtypes_id")
	REFERENCES "tbl_store_product_subtypes"("product_subtypes_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_hearts" ADD CONSTRAINT "tbl_routines" FOREIGN KEY ("routine_id")
	REFERENCES "tbl_routines"("routine_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_hearts" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("user_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_hearts" ADD CONSTRAINT "tbl_store_hearts" FOREIGN KEY ("store_hearts_id")
	REFERENCES "tbl_store_hearts"("store_hearts_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_stats" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("user_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_studio_awards" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("studios_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_studio_awards" ADD CONSTRAINT "tbl_awards_type" FOREIGN KEY ("awards_type_id")
	REFERENCES "tbl_awards_type"("awards_type_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_studio_awards" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_special_awards" ADD CONSTRAINT "tbl_awards" FOREIGN KEY ("awards_id")
	REFERENCES "tbl_awards"("awards_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_special_awards" ADD CONSTRAINT "tbl_date_routines" FOREIGN KEY ("date_routines_id")
	REFERENCES "tbl_date_routines"("date_routines_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_scholarships" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("events_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_scholarships" ADD CONSTRAINT "tbl_scholarships" FOREIGN KEY ("scholarships_id")
	REFERENCES "tbl_scholarships"("scholarships_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_scholarships" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "schedule_workshops_room" ADD CONSTRAINT "tbl_date_schedule_workshops" FOREIGN KEY ("schedule_workshops_id")
	REFERENCES "tbl_date_schedule_workshops"("schedule_workshops_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "schedule_workshops_room" ADD CONSTRAINT "tbl_workshop_room_plan" FOREIGN KEY ("workshop_room_plan_id")
	REFERENCES "tbl_workshop_room_plan"("workshop_room_plan_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_schedule_workshops" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_schedule_competition" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_studios" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("studios_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_studios" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_promo_codes" ADD CONSTRAINT "tbl_promo_codes_type" FOREIGN KEY ("promo_codes_type_id")
	REFERENCES "tbl_promo_codes_type"("promo_codes_type_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_attendees" ADD CONSTRAINT "tbl_promo_codes" FOREIGN KEY ("promo_codes_id")
	REFERENCES "tbl_promo_codes"("promo_codes_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_attendees" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("registration_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_awards" ADD CONSTRAINT "tbl_awards_type" FOREIGN KEY ("awards_type_id")
	REFERENCES "tbl_awards_type"("awards_type_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routine_dancers" ADD CONSTRAINT "tbl_routines" FOREIGN KEY ("routine_id")
	REFERENCES "tbl_routines"("routine_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routine_dancers" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("dancer_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routine_dancers" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_mybtf_exceptions" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("user_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_mybtf_exceptions" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "routines_time_type" ADD CONSTRAINT "tbl_date_routines" FOREIGN KEY ("date_routines_id")
	REFERENCES "tbl_date_routines"("date_routines_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "routines_time_type" ADD CONSTRAINT "tbl_time_type" FOREIGN KEY ("time_type_id")
	REFERENCES "tbl_time_type"("time_type_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines_score" ADD CONSTRAINT "tbl_vip_score" FOREIGN KEY ("score_id")
	REFERENCES "tbl_score"("score_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines_score" ADD CONSTRAINT "tbl_date_routines" FOREIGN KEY ("date_routines_id")
	REFERENCES "tbl_date_routines"("date_routines_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_routine_categories" ADD CONSTRAINT "tbl_category" FOREIGN KEY ("category_id")
	REFERENCES "tbl_category"("category_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_age_divisions" ADD CONSTRAINT "tbl_playlist_workshop_levels" FOREIGN KEY ("playlist_workshop_levels_id")
	REFERENCES "tbl_playlist_workshop_levels"("playlist_workshop_levels_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_routines" FOREIGN KEY ("routine_id")
	REFERENCES "tbl_routines"("routine_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("studios_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_age_divisions" FOREIGN KEY ("age_divisions_id")
	REFERENCES "tbl_age_divisions"("age_divisions_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_routine_categories" FOREIGN KEY ("routine_categories_id", "category_id")
	REFERENCES "tbl_routine_categories"("routine_categories_id", "category_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_performance_divisions" FOREIGN KEY ("performance_divisions_id")
	REFERENCES "tbl_performance_divisions"("performance_divisions_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_perf_div_type" FOREIGN KEY ("perf_div_type_id")
	REFERENCES "tbl_perf_div_type"("perf_div_type_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_routine_types" FOREIGN KEY ("routine_types_id")
	REFERENCES "tbl_routine_types"("routine_types_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_faculty_playlists" ADD CONSTRAINT "tbl_date_playlists" FOREIGN KEY ("date_playlists_id")
	REFERENCES "tbl_date_playlists"("date_playlists_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_faculty_playlists" ADD CONSTRAINT "tbl_faculty" FOREIGN KEY ("faculty_id")
	REFERENCES "tbl_faculty"("faculty_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_playlists" ADD CONSTRAINT "tbl_workshop_levels" FOREIGN KEY ("workshop_levels_id", "playlist_workshop_levels_id")
	REFERENCES "tbl_workshop_levels"("workshop_levels_id", "playlist_workshop_levels_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_playlists" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_playlists" ADD CONSTRAINT "tbl_songs" FOREIGN KEY ("songs_id")
	REFERENCES "tbl_songs"("songs_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_faculty" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("dancer_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_faculty" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("events_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_workshop_levels" ADD CONSTRAINT "tbl_playlist_workshop_levels" FOREIGN KEY ("playlist_workshop_levels_id")
	REFERENCES "tbl_playlist_workshop_levels"("playlist_workshop_levels_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_waivers" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("dancer_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tour_dates_workshop_room" ADD CONSTRAINT "tbl_workshop_room" FOREIGN KEY ("workshop_room_id")
	REFERENCES "tbl_workshop_room"("workshop_room_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tour_dates_workshop_room" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "hotel_contact_type" ADD CONSTRAINT "tbl_contact_type" FOREIGN KEY ("contact_type_id")
	REFERENCES "tbl_contact_type"("contact_type_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "hotel_contact_type" ADD CONSTRAINT "tbl_hotel" FOREIGN KEY ("hotel_id")
	REFERENCES "tbl_hotel"("hotel_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_hotel" ADD CONSTRAINT "tbl_address" FOREIGN KEY ("address_id")
	REFERENCES "tbl_address"("address_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "venue_contact_type" ADD CONSTRAINT "tbl_venue" FOREIGN KEY ("venue_id")
	REFERENCES "tbl_venue"("venue_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "venue_contact_type" ADD CONSTRAINT "tbl_contact_type" FOREIGN KEY ("contact_type_id")
	REFERENCES "tbl_contact_type"("contact_type_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_venue" ADD CONSTRAINT "tbl_address" FOREIGN KEY ("address_id")
	REFERENCES "tbl_address"("address_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_season" FOREIGN KEY ("season_id")
	REFERENCES "tbl_season"("season_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("events_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_states" FOREIGN KEY ("state_id")
	REFERENCES "tbl_states"("state_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_venue" FOREIGN KEY ("venue_id")
	REFERENCES "tbl_venue"("venue_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_hotel" FOREIGN KEY ("hotel_id")
	REFERENCES "tbl_hotel"("hotel_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_performance_divisions" FOREIGN KEY ("performance_divisions_id")
	REFERENCES "tbl_performance_divisions"("performance_divisions_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_fee_types_has_tbl_registration" ADD CONSTRAINT "tbl_fee_types" FOREIGN KEY ("fee_types_id")
	REFERENCES "tbl_fee_types"("fee_types_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_fee_types_has_tbl_registration" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("registration_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registration" ADD CONSTRAINT "tbl_payment_method" FOREIGN KEY ("payment_method_id")
	REFERENCES "tbl_payment_method"("payment_method_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registration" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("studios_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registration" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("user_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registration" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("tour_dates_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_season_events" ADD CONSTRAINT "tbl_season" FOREIGN KEY ("season_id")
	REFERENCES "tbl_season"("season_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_season_events" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("events_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_events" ADD CONSTRAINT "tbl_event_types" FOREIGN KEY ("event_types_id")
	REFERENCES "tbl_event_types"("event_types_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dancer" ADD CONSTRAINT "tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("person_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "person_has_contact_type" ADD CONSTRAINT "tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("person_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "person_has_contact_type" ADD CONSTRAINT "tbl_contact_type" FOREIGN KEY ("contact_type_id")
	REFERENCES "tbl_contact_type"("contact_type_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_address" ADD CONSTRAINT "tbl_states" FOREIGN KEY ("state_id")
	REFERENCES "tbl_states"("state_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_address" ADD CONSTRAINT "tbl_countries" FOREIGN KEY ("country_id")
	REFERENCES "tbl_countries"("country_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_person" ADD CONSTRAINT "tbl_address" FOREIGN KEY ("address_id")
	REFERENCES "tbl_address"("address_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_person" ADD CONSTRAINT "tbl_gender" FOREIGN KEY ("gender_id")
	REFERENCES "tbl_gender"("gender_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_person" ADD CONSTRAINT "tbl_person_types" FOREIGN KEY ("person_types_id")
	REFERENCES "tbl_person_types"("person_types_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user" ADD CONSTRAINT "tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("person_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studios" ADD CONSTRAINT "tbl_address" FOREIGN KEY ("address_id")
	REFERENCES "tbl_address"("address_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studio_contacts" ADD CONSTRAINT "Ref_tbl_studio_contacts_to_tbl_contact_type" FOREIGN KEY ("contact_type_id")
	REFERENCES "tbl_contact_type"("contact_type_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studio_contacts" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("studios_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_routines" ADD CONSTRAINT "Ref_tbl_routines_to_tbl_teacher" FOREIGN KEY ("teacher_id")
	REFERENCES "tbl_teacher"("teacher_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_routines" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("studios_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_states" ADD CONSTRAINT "Ref_tbl_states_to_tbl_countries" FOREIGN KEY ("country_id")
	REFERENCES "tbl_countries"("country_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;
