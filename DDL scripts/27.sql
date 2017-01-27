DROP TABLE IF EXISTS "tbl_event_reg_type_names" CASCADE;
CREATE TABLE "tbl_event_reg_type_names" (
	"id" int4 NOT NULL,
	"name" varchar,
	PRIMARY KEY("id")
);

DROP TABLE IF EXISTS "tbl_tda_bestdancer_data" CASCADE;
CREATE TABLE "tbl_tda_bestdancer_data" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4,
	"dancer_id" int4,
	"routines_id" int4,
	"person_id" int4,
	"studios_id" int4,
	"iscompeting" int4,
	"jacketname" varchar,
	"jacketsize" varchar,
	"hasphoto" int4,
	"ballet" int4,
	"danceoff" json,
	"groupid" int4,
	"perc" json,
	"place" json,
	"jazz" int4,
	PRIMARY KEY("id")
);

DROP TABLE IF EXISTS "tbl_award_nominations_has_teacher" CASCADE;
CREATE TABLE "tbl_award_nominations_has_teacher" (
	"tbl_person_id" int4,
	"tbl_tda_award_nominations_id" int4
);

DROP TABLE IF EXISTS "tbl_tda_award_nominations" CASCADE;
CREATE TABLE "tbl_tda_award_nominations" (
	"id" int4 NOT NULL,
	"studios_id" int4,
	"tour_dates_id" int4,
	"has_soty" int4,
	"soty_ts_ballet_routineid" int4,
	"soty_ts_jazz_routineid" int4,
	"soty_ts_musicaltheater_routineid" int4,
	"soty_ts_contemplyrical_routineid" int4,
	"soty_ts_hiphoptap_routineid" int4,
	"soty_mj_ballet_routineid" int4,
	"soty_mj_jazz_routineid" int4,
	"soty_mj_musicaltheater_routineid" int4,
	"soty_mj_contemplyrical_routineid" int4,
	"soty_mj_hiphoptap_routineid" int4,
	"sa_ts_ota_routineid" int4,
	"sa_ts_ota_no" int4,
	"sa_mj_ota_routineid" int4,
	"sa_mj_ota_no" int4,
	"sa_oacd_routineid" int4,
	"tbl_person_id_designer" int4,
	"sa_oacd_no" int4,
	"sa_ts_bc_routineid" int4,
	"sa_ts_bc_no" int4,
	"sa_mj_bc_routineid" int4,
	"sa_mj_bc_no" int4,
	"sa_peopleschoice_no" int4,
	"sa_peopleschoice_routineid" int4,
	"sa_s_ota_routineid" int4,
	"sa_s_ota_no" int4,
	"sa_t_ota_routineid" int4,
	"sa_t_ota_no" int4,
	"sa_j_ota_routineid" int4,
	"sa_j_ota_no" int4,
	"sa_m_ota_routineid" int4,
	"sa_m_ota_no" int4,
	PRIMARY KEY("id")
);

DROP TABLE IF EXISTS "tbl_competition_awards" CASCADE;
CREATE TABLE "tbl_competition_awards" (
	"id" int4 NOT NULL,
	"lowest" int4,
	"highest" int4,
	"awards_type_id" int4,
	"events_id" int4,
	PRIMARY KEY("id")
);

DROP TABLE IF EXISTS "tbl_dts_attendees" CASCADE;
CREATE TABLE "tbl_dts_attendees" (
	"id" int4 NOT NULL,
	"fee" float4,
	"custom_fee" int4,
	"note" text,
	"canceled" int4,
	"promo_codes_id" int4,
	"dts_registrations_id" int4 NOT NULL,
	"person_id" int4,
	PRIMARY KEY("id")
);

DROP TABLE IF EXISTS "tbl_store_promocodes" CASCADE;
CREATE TABLE "tbl_store_promocodes" (
	"id" int4 NOT NULL,
	"name" varchar,
	"description" text,
	"value" int4,
	"charges" int4,
	"uses" int4,
	"active" int4,
	"expires" varchar,
	"promo_codes_type_id" int4 NOT NULL,
	PRIMARY KEY("id")
);

DROP TABLE IF EXISTS "tbl_tda_peopleschoice_votes" CASCADE;
CREATE TABLE "tbl_tda_peopleschoice_votes" (
	"id" int4 NOT NULL,
	"ip" varchar,
	"routines_id" int4,
	"tour_dates_id" int4,
	"nomid" int4,
	PRIMARY KEY("id")
);

DROP TABLE IF EXISTS "tbl_tda_award_types" CASCADE;
CREATE TABLE "tbl_tda_award_types" (
	"id" int4 NOT NULL,
	"award" varchar,
	"hasplaces" int4,
	"awardtype" varchar,
	"reportorder" int4,
	PRIMARY KEY("id")
);

DROP TABLE IF EXISTS "tbl_dts_fees" CASCADE;
CREATE TABLE "tbl_dts_fees" (
	"id" int4 NOT NULL,
	"offername" varchar,
	"offerval" int4,
	PRIMARY KEY("id")
);

DROP TABLE IF EXISTS "tbl_date_dancers" CASCADE;
CREATE TABLE "tbl_date_dancers" (
	"id" int4 NOT NULL,
	"fee" float4,
	"age" int4,
	"one_day" int4,
	"has_scholarship" int4,
	"custom_fee" int4,
	"waiver" int4,
	"attended_reg" int4,
	"has_photo" int4,
	"vip" int4,
	"independent" int4,
	"vip_type" varchar,
	"scholarship_code" int4,
	"attended_reg_both" int4,
	"dancer_id" int4,
	"studios_id" int4,
	"tour_dates_id" int4,
	"statsregid" int4,
	"waivers_id" int4,
	"workshop_levels_id" int4,
	PRIMARY KEY("id")
);

DROP TABLE IF EXISTS "tbl_dts_registrations" CASCADE;
CREATE TABLE "tbl_dts_registrations" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4,
	"studios_id" int4,
	"person_id" int4,
	"registration_id" int4,
	"user_id" int4,
	"admin_id" int4,
	"heard" varchar,
	"notes" text,
	"total_fees" float4,
	"fees_paid" float4,
	"balance_due" float4,
	"boxsets" json,
	"extra" json,
	"edu" json,
	PRIMARY KEY("id")
);

CREATE INDEX "Index0tbl_dts_registrations" ON "tbl_dts_registrations" (
	"tour_dates_id"
);


CREATE INDEX "Index1tbl_dts_registrations" ON "tbl_dts_registrations" (
	"studios_id"
);


CREATE INDEX "Index2tbl_dts_registrations" ON "tbl_dts_registrations" (
	"person_id"
);


DROP TABLE IF EXISTS "venue_contact_type" CASCADE;
CREATE TABLE "venue_contact_type" (
	"id" SERIAL NOT NULL,
	"venue_id" int4 NOT NULL,
	"contact_type_id" int4 NOT NULL,
	"value" varchar,
	CONSTRAINT "venue_contact_type_pkey" PRIMARY KEY("id","venue_id","contact_type_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "venue_contact_type" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tour_dates_workshop_room" CASCADE;
CREATE TABLE "tour_dates_workshop_room" (
	"workshop_room_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"age_divisions_id" int4 NOT NULL,
	"level_id" int4,
	CONSTRAINT "tour_dates_workshop_room_pkey" PRIMARY KEY("workshop_room_id","tour_dates_id","age_divisions_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tour_dates_workshop_room" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_workshop_rooms" CASCADE;
CREATE TABLE "tbl_workshop_rooms" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_workshop_rooms_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_workshop_rooms" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_workshop_levels" CASCADE;
CREATE TABLE "tbl_workshop_levels" (
	"id" int4 NOT NULL,
	"playlist_workshop_levels_id" int4 NOT NULL,
	"season_id" int4 NOT NULL,
	"discount_fee" int4,
	"full_fee" int4,
	"finale_discount_fee" int4,
	"finale_full_fee" int4,
	"one_day_full_fee" int4,
	"one_day_discount_fee" int4,
	CONSTRAINT "tbl_workshop_levels_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_workshop_levels" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_waivers" CASCADE;
CREATE TABLE "tbl_waivers" (
	"id" int4 NOT NULL,
	"dancer_id" int4 NOT NULL,
	CONSTRAINT "tbl_waivers_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_waivers" ON "tbl_waivers" (
	"dancer_id"
);


ALTER TABLE "tbl_waivers" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_venues" CASCADE;
CREATE TABLE "tbl_venues" (
	"id" SERIAL NOT NULL,
	"address_id" int4,
	"name" varchar,
	"website" varchar,
	CONSTRAINT "tbl_venues_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_venues" ON "tbl_venues" (
	"name"
);


ALTER TABLE "tbl_venues" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_user_stats" CASCADE;
CREATE TABLE "tbl_user_stats" (
	"id" int4 NOT NULL,
	"user_id" int4 NOT NULL,
	"activation_code" varchar,
	"time_signup" date,
	"time_activate" date,
	"time_last_login" date,
	"time_disable" date,
	"login_count" int4 DEFAULT 0,
	"ips" text,
	"dontshow1" int4 DEFAULT 0,
	CONSTRAINT "tbl_user_stats_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_user_stats" ON "tbl_user_stats" (
	"user_id"
);


ALTER TABLE "tbl_user_stats" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_user_registrations_specialty" CASCADE;
CREATE TABLE "tbl_user_registrations_specialty" (
	"id" int4 NOT NULL,
	"ota_mj_regroutineid" int4,
	"ota_ts_regroutineid" int4,
	"ota_cd_regroutineid" int4,
	"bc_mj_regroutineid" int4,
	"bc_ts_regroutineid" int4,
	"peopleschoice_regroutineid" int4,
	"ota_m_regroutineid" int4,
	"ota_j_regroutineid" int4,
	"ota_t_regroutineid" int4,
	"ota_s_regroutineid" int4,
	"user_id" int4 NOT NULL,
	"registration_id" int4,
	"bc_mj_cho" varchar,
	"bc_ts_cho" varchar,
	"ota_cd_cd" varchar,
	CONSTRAINT "tbl_user_registrations_specialty_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_user_registrations_specialty" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_user_registrations_soty" CASCADE;
CREATE TABLE "tbl_user_registrations_soty" (
	"id" int4 NOT NULL,
	"registration_id" int4,
	"ts_ballet" int4,
	"ts_jazz" int4,
	"ts_mtspec" int4,
	"ts_contemplyrical" int4,
	"ts_hiphoptap" int4,
	"mj_ballet" int4,
	"mj_jazz" int4,
	"mj_mtspec" int4,
	"mj_contemplyrical" int4,
	"mj_hiphoptap" int4,
	"has_soty" int4 DEFAULT 0,
	"user_id" int4,
	CONSTRAINT "tbl_user_registrations_soty_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_user_registrations_soty" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_user_hearts" CASCADE;
CREATE TABLE "tbl_user_hearts" (
	"id" int4 NOT NULL,
	"user_id" int4 NOT NULL,
	"store_hearts_id" int4 NOT NULL,
	CONSTRAINT "tbl_user_hearts_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_user_hearts" ON "tbl_user_hearts" (
	"user_id"
);


ALTER TABLE "tbl_user_hearts" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_user_has_dancer" CASCADE;
CREATE TABLE "tbl_user_has_dancer" (
	"dancer_id" int4 NOT NULL,
	"user_id" int4 NOT NULL,
	CONSTRAINT "tbl_user_has_dancer_pkey" PRIMARY KEY("dancer_id","user_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_user_has_dancer" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_user" CASCADE;
CREATE TABLE "tbl_user" (
	"id" int4 NOT NULL,
	"person_id" int4,
	"email" varchar,
	"password" varchar,
	"active" int4,
	"unregistered" int4 DEFAULT 0,
	CONSTRAINT "tbl_user_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_user" ON "tbl_user" (
	"person_id"
);


CREATE INDEX "Index1tbl_user" ON "tbl_user" (
	"email"
);


ALTER TABLE "tbl_user" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_tour_dates" CASCADE;
CREATE TABLE "tbl_tour_dates" (
	"id" int4 NOT NULL,
	"season_id" int4 NOT NULL,
	"event_id" int4 NOT NULL,
	"state_id" int4,
	"venue_id" int4,
	"hotel_id" int4,
	"perf_div_types_id" int4,
	"city_id" int4,
	"start_date" date,
	"end_date" date,
	"cutoff_start_date" date,
	"cutoff_end_date" date,
	"room" json,
	"notes" text,
	"is_finals" int4 DEFAULT 0,
	"entry_limits" text,
	"weather_link" text,
	"hotel_alt" text,
	"custom_routine_durations" json,
	"default_category_order" json,
	"routine_dist" int4 DEFAULT 3,
	"webcast_this_city" int4 DEFAULT 0,
	"hotel_notes" text,
	"online_balance_payments_enabled" int4 DEFAULT 0,
	"event_date_status" varchar DEFAULT 'Available'::character varying,
	"results_solo_display_count" int4 DEFAULT 10,
	"show_time" varchar,
	"use_online_scoring" int4 DEFAULT 0,
	"web" json,
	"entrylimit" json,
	"competition" json,
	"tda_danceoff" json,
	"mybtf" json,
	"workshop_notes" text,
	CONSTRAINT "tbl_tour_dates_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_tour_dates" ON "tbl_tour_dates" (
	"event_id"
);


CREATE INDEX "Index1tbl_tour_dates" ON "tbl_tour_dates" (
	"city_id"
);


CREATE INDEX "Index2tbl_tour_dates" ON "tbl_tour_dates" (
	"season_id"
);


ALTER TABLE "tbl_tour_dates" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_studios_has_dancer" CASCADE;
CREATE TABLE "tbl_studios_has_dancer" (
	"dancer_id" int4 NOT NULL,
	"studios_id" int4 NOT NULL,
	CONSTRAINT "tbl_studios_has_dancer_pkey" PRIMARY KEY("dancer_id","studios_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_studios_has_dancer" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_studios" CASCADE;
CREATE TABLE "tbl_studios" (
	"id" int4 NOT NULL,
	"address_id" int4,
	"name" varchar,
	"notes" json,
	"contacts" json,
	CONSTRAINT "tbl_studios_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_studios" ON "tbl_studios" (
	"name"
);


ALTER TABLE "tbl_studios" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_studio_contacts" CASCADE;
CREATE TABLE "tbl_studio_contacts" (
	"id" SERIAL NOT NULL,
	"contact_type_id" int4 NOT NULL,
	"studios_id" int4 NOT NULL,
	"value" varchar,
	CONSTRAINT "tbl_studio_contacts_pkey" PRIMARY KEY("id","contact_type_id","studios_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_studio_contacts" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_studio_awards" CASCADE;
CREATE TABLE "tbl_studio_awards" (
	"id" int4 NOT NULL,
	"awards_type_id" int4 NOT NULL,
	"events_id" int4 NOT NULL,
	CONSTRAINT "tbl_studio_awards_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_studio_awards" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_sizes" CASCADE;
CREATE TABLE "tbl_store_sizes" (
	"id" int4 NOT NULL,
	"size" varchar NOT NULL,
	CONSTRAINT "tbl_store_sizes_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_store_sizes" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_products_inventory" CASCADE;
CREATE TABLE "tbl_store_products_inventory" (
	"id" int4 NOT NULL,
	"store_products_id" int4 NOT NULL,
	"store_colors_id" int4 DEFAULT 0,
	"store_sizes_id" int4 DEFAULT 0,
	"qty_onsite" int4,
	"qty_warehouse" int4,
	CONSTRAINT "tbl_store_products_inventory_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_store_products_inventory" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_products_has_size" CASCADE;
CREATE TABLE "tbl_store_products_has_size" (
	"store_sizes_id" int4 NOT NULL,
	"store_products_id" int4 NOT NULL,
	CONSTRAINT "tbl_store_products_has_size_pkey" PRIMARY KEY("store_sizes_id","store_products_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_store_products_has_size" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_products" CASCADE;
CREATE TABLE "tbl_store_products" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4,
	"events_id" int4,
	"product_subtypes_id" int4,
	"product" varchar NOT NULL,
	"description" text DEFAULT 'no desc'::text,
	"price" float4,
	"shipping" float4,
	"featured" int4 DEFAULT 0,
	"timeadded" date,
	"instock" int4 DEFAULT 1,
	"showonsite" int4 DEFAULT 1,
	"onsale" int4 DEFAULT 0,
	"sale_price" float4 DEFAULT 0,
	"weight" float4 DEFAULT 0,
	"trending" int4 DEFAULT 0,
	"short_description" text,
	"sort" int4,
	CONSTRAINT "tbl_store_products_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_store_products" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_product_types" CASCADE;
CREATE TABLE "tbl_store_product_types" (
	"id" int4 NOT NULL,
	"name" varchar,
	CONSTRAINT "tbl_store_product_types_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_store_product_types" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_product_subtypes" CASCADE;
CREATE TABLE "tbl_store_product_subtypes" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"product_types_id" int4 NOT NULL,
	CONSTRAINT "tbl_store_product_subtypes_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_store_product_subtypes" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_product_colors" CASCADE;
CREATE TABLE "tbl_store_product_colors" (
	"store_colors_id" int4 NOT NULL,
	"store_products_id" int4 NOT NULL,
	CONSTRAINT "tbl_store_product_colors_pkey" PRIMARY KEY("store_colors_id","store_products_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_store_product_colors" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_orders" CASCADE;
CREATE TABLE "tbl_store_orders" (
	"id" int4 NOT NULL,
	"user_id" int4,
	"order_hash" text,
	"submitted" date,
	"shipped" int4,
	"statsuser" varchar,
	"digitalonly" int4 DEFAULT 0,
	"fees_paid" varchar,
	"tracking" varchar DEFAULT 0,
	"transactionid" varchar,
	"label" json,
	CONSTRAINT "tbl_store_orders_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_store_orders" ON "tbl_store_orders" (
	"user_id"
);


CREATE INDEX "Index1tbl_store_orders" ON "tbl_store_orders" (
	"submitted"
);


ALTER TABLE "tbl_store_orders" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_hearts" CASCADE;
CREATE TABLE "tbl_store_hearts" (
	"id" int4 NOT NULL,
	"routine_id" int4 NOT NULL DEFAULT 0,
	"individual_id" int4 DEFAULT 0,
	"is_video" int4 NOT NULL DEFAULT 0,
	"hearts" int4 NOT NULL DEFAULT 0,
	"url" varchar,
	CONSTRAINT "tbl_store_hearts_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_store_hearts" ON "tbl_store_hearts" (
	"routine_id"
);


CREATE INDEX "Index1tbl_store_hearts" ON "tbl_store_hearts" (
	"individual_id"
);


ALTER TABLE "tbl_store_hearts" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_giftcards" CASCADE;
CREATE TABLE "tbl_store_giftcards" (
	"id" int4 NOT NULL,
	"code" varchar NOT NULL,
	"initial_balance" float4,
	"balance" float4,
	"created" date,
	CONSTRAINT "tbl_store_giftcards_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_store_giftcards" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_store_colors" CASCADE;
CREATE TABLE "tbl_store_colors" (
	"id" int4 NOT NULL,
	"name" varchar(100) NOT NULL,
	CONSTRAINT "tbl_store_colors_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_store_colors" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_states" CASCADE;
CREATE TABLE "tbl_states" (
	"id" int4 NOT NULL,
	"country_id" int4,
	"name" varchar NOT NULL,
	"abbr" varchar,
	CONSTRAINT "tbl_states_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_states" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_staff_types" CASCADE;
CREATE TABLE "tbl_staff_types" (
	"id" int4 NOT NULL,
	"name" varchar,
	CONSTRAINT "tbl_staff_types_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_staff_types" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_staff" CASCADE;
CREATE TABLE "tbl_staff" (
	"id" int4 NOT NULL,
	"fname" varchar,
	"lname" varchar,
	"staff_types_id" int4 NOT NULL,
	CONSTRAINT "tbl_staff_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_staff" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_special_awards" CASCADE;
CREATE TABLE "tbl_special_awards" (
	"id" int4 NOT NULL,
	"report_order" int4,
	"awards_type_id" int4 NOT NULL,
	"events_id" int4 NOT NULL,
	CONSTRAINT "tbl_special_awards_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_special_awards" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_soty_type" CASCADE;
CREATE TABLE "tbl_soty_type" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_soty_type_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_soty_type" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_songs" CASCADE;
CREATE TABLE "tbl_songs" (
	"id" int4 NOT NULL,
	"song_name" varchar NOT NULL,
	"artist_name" varchar,
	CONSTRAINT "tbl_songs_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_songs" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_seasons" CASCADE;
CREATE TABLE "tbl_seasons" (
	"id" int4 NOT NULL,
	"start_year" int4 NOT NULL,
	"end_year" int4,
	CONSTRAINT "tbl_seasons_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_seasons" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_season_events" CASCADE;
CREATE TABLE "tbl_season_events" (
	"season_id" int4 NOT NULL,
	"events_id" int4 NOT NULL,
	CONSTRAINT "tbl_season_events_pkey" PRIMARY KEY("season_id","events_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_season_events" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_scholarships" CASCADE;
CREATE TABLE "tbl_scholarships" (
	"id" int4 NOT NULL,
	"active" int4,
	"report_order" int4 DEFAULT 999,
	"isclass" int4,
	"name" varchar,
	"events_id" int4 NOT NULL,
	CONSTRAINT "tbl_scholarships_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_scholarships" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_schedule_workshops_rooms" CASCADE;
CREATE TABLE "tbl_schedule_workshops_rooms" (
	"schedule_workshops_id" int4 NOT NULL,
	"id" int4 NOT NULL,
	"room" json,
	CONSTRAINT "tbl_schedule_workshops_rooms_pkey" PRIMARY KEY("schedule_workshops_id","id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_schedule_workshops_rooms" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_routines_has_teacher" CASCADE;
CREATE TABLE "tbl_routines_has_teacher" (
	"person_id" int4 NOT NULL,
	"routine_id" int4 NOT NULL,
	CONSTRAINT "tbl_routines_has_teacher_pkey" PRIMARY KEY("person_id","routine_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_routines_has_teacher" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_routines" CASCADE;
CREATE TABLE "tbl_routines" (
	"id" int4 NOT NULL,
	"studios_id" int4,
	"name" varchar NOT NULL,
	CONSTRAINT "teacher_id" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_routines" ON "tbl_routines" (
	"studios_id"
);


ALTER TABLE "tbl_routines" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_routine_types" CASCADE;
CREATE TABLE "tbl_routine_types" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_routine_types_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_routine_types" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_routine_categories" CASCADE;
CREATE TABLE "tbl_routine_categories" (
	"category_id" int4 NOT NULL,
	"season_id" int4 NOT NULL,
	"min_dancers" int4,
	"full_fee_per_dancer" varchar,
	"duration" int4,
	"abbreviation" varchar,
	"discount_fee_per_dancer" varchar,
	"finale_fee_per_dancer" varchar,
	"finale_prelim_fee_per_dancer" varchar,
	CONSTRAINT "tbl_routine_categories_pkey" PRIMARY KEY("category_id","season_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_routine_categories" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_registrations_routines" CASCADE;
CREATE TABLE "tbl_registrations_routines" (
	"id" int4 NOT NULL,
	"registration_id" int4,
	"performance_division_id" int4,
	"routine" varchar,
	"routine_category_id" int4,
	"age_division_id" int4,
	"teacher" varchar,
	"type" json,
	"time" json,
	"fee" float4,
	"award_type" varchar,
	CONSTRAINT "tbl_registrations_routines_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_registrations_routines" ON "tbl_registrations_routines" (
	"registration_id"
);


ALTER TABLE "tbl_registrations_routines" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_registrations_dancers" CASCADE;
CREATE TABLE "tbl_registrations_dancers" (
	"id" int4 NOT NULL,
	"registration_id" int4,
	"dancer_id" int4,
	"one_day" int4,
	"has_scholarship" int4,
	"attended_reg" int4,
	"is_commuter" int4,
	"non_commuter" varchar,
	"classes_only" int4,
	"workshop_level_id" int4,
	"fees" json,
	"promo_codes_id" int4,
	"scholarship" json,
	"best_dancer" int4,
	"event_teacher" int4,
	"events_id" int4,
	"reg_type_id" int4,
	CONSTRAINT "tbl_registrations_dancers_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_registrations_dancers" ON "tbl_registrations_dancers" (
	"registration_id"
);


CREATE INDEX "Index1tbl_registrations_dancers" ON "tbl_registrations_dancers" (
	"dancer_id"
);


ALTER TABLE "tbl_registrations_dancers" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_registrations_best_dancers" CASCADE;
CREATE TABLE "tbl_registrations_best_dancers" (
	"id" int4 NOT NULL,
	"dancer_id" int4,
	"registration_id" int4,
	"competing" int4,
	"jacket" json,
	"routine" varchar,
	"choreographer" varchar,
	"photo_file" varchar,
	"jacket_only" int4,
	"fee" float4,
	CONSTRAINT "tbl_registrations_best_dancers_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_registrations_best_dancers" ON "tbl_registrations_best_dancers" (
	"dancer_id"
);


CREATE INDEX "Index1tbl_registrations_best_dancers" ON "tbl_registrations_best_dancers" (
	"registration_id"
);


ALTER TABLE "tbl_registrations_best_dancers" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_registrations_attendees_dts" CASCADE;
CREATE TABLE "tbl_registrations_attendees_dts" (
	"id" int4 NOT NULL,
	"registration_id" int4,
	"user_id" int4,
	"tbl_dts_reg_types_id" int4,
	"promo_code" varchar,
	"fee" int4,
	CONSTRAINT "tbl_registrations_attendees_dts_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_registrations_attendees_dts" ON "tbl_registrations_attendees_dts" (
	"registration_id"
);


CREATE INDEX "Index1tbl_registrations_attendees_dts" ON "tbl_registrations_attendees_dts" (
	"user_id"
);


ALTER TABLE "tbl_registrations_attendees_dts" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_registration" CASCADE;
CREATE TABLE "tbl_registration" (
	"id" int4 NOT NULL,
	"user_id" int4,
	"tour_dates_id" int4,
	"studios_id" int4,
	"waiver" int4,
	"left_off" varchar,
	"heard" varchar,
	"details" text,
	"full_rates" int4,
	"enteredby_id" int4,
	"viewed" int4,
	"deleted" int4,
	"old_user_reg_id" int4,
	"fees" json,
	"free_teacher" json,
	"credit" json,
	"observers" json,
	"confirmed" int4,
	"completed" int4,
	"date" json,
	"payment_method" varchar,
	CONSTRAINT "tbl_registration_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "ind_old_user_reg_id" ON "tbl_registration" USING BTREE (
	"old_user_reg_id"
);


CREATE INDEX "Index0tbl_registration" ON "tbl_registration" (
	"user_id"
);


CREATE INDEX "Index01tbl_registration" ON "tbl_registration" (
	"tour_dates_id"
);


CREATE INDEX "Index1tbl_registration" ON "tbl_registration" (
	"confirmed"
);


CREATE INDEX "Index2tbl_registration" ON "tbl_registration" (
	"completed"
);


CREATE INDEX "Index3tbl_registration" ON "tbl_registration" (
	"studios_id"
);


ALTER TABLE "tbl_registration" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_promo_codes_type" CASCADE;
CREATE TABLE "tbl_promo_codes_type" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_promo_codes_type_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_promo_codes_type" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_promo_codes" CASCADE;
CREATE TABLE "tbl_promo_codes" (
	"id" int4 NOT NULL,
	"promo_codes_type_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"description" text,
	"value" int4,
	"charges" int4,
	"uses" int4 NOT NULL DEFAULT 0,
	"active" int4,
	"noncommuteronly" int4 DEFAULT 0,
	"onceperreg" int4 DEFAULT 0,
	"intensiveid" int4,
	"expires" int4,
	CONSTRAINT "tbl_promo_codes_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_promo_codes" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_playlist_workshop_levels" CASCADE;
CREATE TABLE "tbl_playlist_workshop_levels" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_playlist_workshop_levels_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_playlist_workshop_levels" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_person_types" CASCADE;
CREATE TABLE "tbl_person_types" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_person_types_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_person_types" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_person" CASCADE;
CREATE TABLE "tbl_person" (
	"id" SERIAL NOT NULL,
	"address_id" int4,
	"gender_id" int4,
	"fname" varchar,
	"lname" varchar,
	"title" varchar,
	"birthdate" varchar,
	"person_types_id" int4,
	CONSTRAINT "tbl_person_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_person" ON "tbl_person" (
	"fname"
);


CREATE INDEX "Index1tbl_person" ON "tbl_person" (
	"lname"
);


CREATE INDEX "Index3" ON "tbl_person" (
	"fname", 
	"lname"
);


ALTER TABLE "tbl_person" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_performance_divisions" CASCADE;
CREATE TABLE "tbl_performance_divisions" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_performance_divisions_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_performance_divisions" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_perf_div_types" CASCADE;
CREATE TABLE "tbl_perf_div_types" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_perf_div_types_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_perf_div_types" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_payment_method" CASCADE;
CREATE TABLE "tbl_payment_method" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_payment_method_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_payment_method" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_online_scoring_has_faculty" CASCADE;
CREATE TABLE "tbl_online_scoring_has_faculty" (
	"online_scoring_id" int4 NOT NULL,
	"faculty_id" int4 NOT NULL,
	"data" json
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_online_scoring_has_faculty" ON "tbl_online_scoring_has_faculty" (
	"online_scoring_id"
);


ALTER TABLE "tbl_online_scoring_has_faculty" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_online_scoring" CASCADE;
CREATE TABLE "tbl_online_scoring" (
	"id" int4 NOT NULL,
	"compgroup" varchar,
	"total_score" int4,
	"dropped_score" int4,
	"awardid" int4,
	"tour_dates_id" int4,
	"studios_id" int4,
	"routines_id" int4,
	CONSTRAINT "tbl_online_scoring_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_online_scoring" ON "tbl_online_scoring" (
	"tour_dates_id"
);


CREATE INDEX "Index1tbl_online_scoring" ON "tbl_online_scoring" (
	"routines_id"
);


ALTER TABLE "tbl_online_scoring" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_online_critiques_judges" CASCADE;
CREATE TABLE "tbl_online_critiques_judges" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"startnumberhasa" int4,
	"endnumber" int4,
	"endnumberhasa" int4,
	"judge" json,
	"startnumber" int4,
	"compgroup" varchar,
	CONSTRAINT "tbl_online_critiques_judges_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_online_critiques_judges" ON "tbl_online_critiques_judges" (
	"tour_dates_id"
);


ALTER TABLE "tbl_online_critiques_judges" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_online_critiques_access" CASCADE;
CREATE TABLE "tbl_online_critiques_access" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"studios_id" int4 NOT NULL,
	"accesscode" varchar,
	CONSTRAINT "tbl_online_critiques_access_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_online_critiques_access" ON "tbl_online_critiques_access" (
	"tour_dates_id"
);


ALTER TABLE "tbl_online_critiques_access" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_levels" CASCADE;
CREATE TABLE "tbl_levels" (
	"id" int4 NOT NULL,
	"name" varchar,
	CONSTRAINT "tbl_levels_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_levels" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_jobs" CASCADE;
CREATE TABLE "tbl_jobs" (
	"id" int4 NOT NULL,
	"title" varchar,
	"jobtype" varchar,
	"description" text,
	"views" int4,
	"showonsite" int4,
	CONSTRAINT "tbl_jobs_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_jobs" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_hotels" CASCADE;
CREATE TABLE "tbl_hotels" (
	"id" SERIAL NOT NULL,
	"name" varchar NOT NULL,
	"address_id" int4,
	"hotel_website" varchar,
	CONSTRAINT "tbl_hotels_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_hotels" ON "tbl_hotels" (
	"name"
);


ALTER TABLE "tbl_hotels" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_gender" CASCADE;
CREATE TABLE "tbl_gender" (
	"id" int4 NOT NULL,
	"value" varchar,
	CONSTRAINT "tbl_gender_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_gender" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_faculty_playlists" CASCADE;
CREATE TABLE "tbl_faculty_playlists" (
	"date_playlists_id" int4 NOT NULL,
	"faculty_id" int4 NOT NULL,
	CONSTRAINT "tbl_faculty_playlists_pkey" PRIMARY KEY("date_playlists_id","faculty_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_faculty_playlists" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_faculty" CASCADE;
CREATE TABLE "tbl_faculty" (
	"id" int4 NOT NULL,
	"events_id" int4 NOT NULL,
	"dancer_id" int4 NOT NULL,
	"bio" text,
	"website" text,
	"director" varchar,
	"twitter" text,
	"instagram" text,
	"youtube" text,
	CONSTRAINT "tbl_faculty_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_faculty" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_events" CASCADE;
CREATE TABLE "tbl_events" (
	"id" int4 NOT NULL,
	"event_types_id" int4 NOT NULL,
	"name" varchar,
	"link" varchar,
	"web_home_webcast_banner" int4,
	"facebook_link" varchar,
	"ageasofyear" int4,
	"intopmenu" int4,
	"currentseason" int4,
	"workshoponly" int4,
	CONSTRAINT "tbl_events_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_events" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_event_types" CASCADE;
CREATE TABLE "tbl_event_types" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_event_types_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_event_types" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_event_registrations" CASCADE;
CREATE TABLE "tbl_event_registrations" (
	"id" int4 NOT NULL,
	"tour_date_id" int4,
	"studio_id" int4,
	"person_id" int4,
	"dates" json,
	"registration_id" int4,
	"user_id" int4,
	"entered_by_id" int4,
	"heard" text,
	"notes" text,
	"total_fees" float4,
	"fees_paid" float4,
	"balance_due" float4,
	"pay_choice" varchar,
	CONSTRAINT "tbl_event_registrations_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_event_registrations" ON "tbl_event_registrations" (
	"tour_date_id"
);


CREATE INDEX "Index1tbl_event_registrations" ON "tbl_event_registrations" (
	"studio_id"
);


CREATE INDEX "Index2tbl_event_registrations" ON "tbl_event_registrations" (
	"person_id"
);


ALTER TABLE "tbl_event_registrations" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_event_reg_types" CASCADE;
CREATE TABLE "tbl_event_reg_types" (
	"id" SERIAL NOT NULL,
	"old_id" int4,
	"seasons_id" int4,
	"fee" int4,
	"discountfee" int4,
	"events_id" int4,
	"event_reg_type_names_id" int4,
	PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_event_reg_types" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_event_attendees" CASCADE;
CREATE TABLE "tbl_event_attendees" (
	"id" int4 NOT NULL,
	"samt" varchar DEFAULT 0,
	"sfrom" varchar,
	"note" text,
	"canceled" int4 DEFAULT 0,
	"audition_number" int4 DEFAULT 0,
	"intensiveid" int4,
	"promo_codes_id" int4,
	"person_id" int4,
	"event_registrations_id" int4,
	CONSTRAINT "tbl_event_attendees_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_event_attendees" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_dts_reg_types" CASCADE;
CREATE TABLE "tbl_dts_reg_types" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"fee" int4 NOT NULL,
	CONSTRAINT "tbl_dts_reg_types_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_dts_reg_types" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_date_studios" CASCADE;
CREATE TABLE "tbl_date_studios" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"studios_id" int4 NOT NULL,
	"total_fees" float4,
	"fees_paid" float4,
	"credit" float4 DEFAULT 0,
	"full_rates" int4,
	"independent" int4 DEFAULT 0,
	"invoice_note" text,
	"ftv" int4,
	"ftc" int4,
	"studiocode" varchar,
	"statsregid" int4,
	"emailer_count" int4,
	"confirmdate" date,
	CONSTRAINT "tbl_date_studios_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_date_studios" ON "tbl_date_studios" (
	"tour_dates_id"
);


CREATE INDEX "Index1tbl_date_studios" ON "tbl_date_studios" (
	"studios_id"
);


ALTER TABLE "tbl_date_studios" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_date_studio_awards" CASCADE;
CREATE TABLE "tbl_date_studio_awards" (
	"id" int4 NOT NULL,
	"studios_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"winner" int4 NOT NULL DEFAULT 0,
	"studio_awards_id" int4 NOT NULL,
	CONSTRAINT "tbl_date_studio_awards_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index0tbl_date_studio_awards" ON "tbl_date_studio_awards" (
	"studios_id"
);


CREATE INDEX "Index1tbl_date_studio_awards" ON "tbl_date_studio_awards" (
	"tour_dates_id"
);


ALTER TABLE "tbl_date_studio_awards" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_date_special_awards" CASCADE;
CREATE TABLE "tbl_date_special_awards" (
	"id" int4 NOT NULL,
	"special_awards_id" int4 NOT NULL,
	"date_routines_id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	CONSTRAINT "tbl_date_special_awards_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index_tbl_date_special_awards" ON "tbl_date_special_awards" (
	"date_routines_id"
);


CREATE INDEX "Index2_tbl_date_special_awards" ON "tbl_date_special_awards" (
	"tour_dates_id"
);


ALTER TABLE "tbl_date_special_awards" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_date_scholarships" CASCADE;
CREATE TABLE "tbl_date_scholarships" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4,
	"scholarships_id" int4,
	"winner" int4 DEFAULT 0,
	"code" varchar,
	"faculty_id" int4,
	"dancer_id" int4,
	"date_dancer_id" int4,
	CONSTRAINT "tbl_date_scholarships_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index1tbl_date_scholarships" ON "tbl_date_scholarships" (
	"dancer_id"
);


ALTER TABLE "tbl_date_scholarships" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_date_schedule_workshops" CASCADE;
CREATE TABLE "tbl_date_schedule_workshops" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"date" varchar,
	"start_time" varchar,
	"duration" varchar,
	"span" int4,
	CONSTRAINT "tbl_date_schedule_workshops_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index_tbl_date_schedule_workshops" ON "tbl_date_schedule_workshops" (
	"tour_dates_id"
);


ALTER TABLE "tbl_date_schedule_workshops" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_date_schedule_competition" CASCADE;
CREATE TABLE "tbl_date_schedule_competition" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"last_update" json,
	"dates" json,
	"awards" json,
	CONSTRAINT "tbl_date_schedule_competition_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "indx_tbl_date_schedule_competition" ON "tbl_date_schedule_competition" (
	"tour_dates_id"
);


ALTER TABLE "tbl_date_schedule_competition" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_date_routines" CASCADE;
CREATE TABLE "tbl_date_routines" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4,
	"routine_id" int4,
	"studios_id" int4,
	"age_divisions_id" int4,
	"performance_divisions_id" int4,
	"perf_div_type_id" int4,
	"routine_types_id" int4,
	"category_id" int4,
	"finals" json,
	"vips" json,
	"prelims" json,
	"fee" float4,
	"canceled" int4 DEFAULT 0,
	"custom_dancer_count" int4 DEFAULT 0,
	"duration" int4,
	"custom_fee" int4 DEFAULT 0,
	"place_hsa" int4 DEFAULT 0,
	"place_hsp" int4 DEFAULT 0,
	"award_typename" varchar,
	"uploaded_duration" varchar,
	"uploaded" int4,
	"extra_time" int4,
	CONSTRAINT "tbl_date_routines_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index_tbl_date_routines1" ON "tbl_date_routines" (
	"tour_dates_id"
);


CREATE INDEX "Index_tbl_date_routines2" ON "tbl_date_routines" (
	"routine_id"
);


CREATE INDEX "Index_tbl_date_routines3" ON "tbl_date_routines" (
	"studios_id"
);


ALTER TABLE "tbl_date_routines" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_date_routine_dancers" CASCADE;
CREATE TABLE "tbl_date_routine_dancers" (
	"tour_dates_id" int4 NOT NULL,
	"routine_id" int4 NOT NULL,
	"dancer_id" int4 NOT NULL,
	CONSTRAINT "tbl_date_routine_dancers_pkey" PRIMARY KEY("tour_dates_id","routine_id","dancer_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_date_routine_dancers" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_date_playlists" CASCADE;
CREATE TABLE "tbl_date_playlists" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4,
	"songs_id" int4,
	"playlist_workshop_levels_id" int4,
	CONSTRAINT "tbl_date_playlists_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "Index_tbl_date_playlists1" ON "tbl_date_playlists" (
	"tour_dates_id"
);


CREATE INDEX "Index_tbl_date_playlists2" ON "tbl_date_playlists" (
	"songs_id"
);


ALTER TABLE "tbl_date_playlists" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_date_mybtf_exceptions" CASCADE;
CREATE TABLE "tbl_date_mybtf_exceptions" (
	"id" int4 NOT NULL,
	"tour_dates_id" int4 NOT NULL,
	"email" varchar NOT NULL,
	"level" int4,
	CONSTRAINT "tbl_date_mybtf_exceptions_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_date_mybtf_exceptions" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_dancer" CASCADE;
CREATE TABLE "tbl_dancer" (
	"id" int4 NOT NULL,
	"person_id" int4 NOT NULL,
	"parent_guardian" varchar,
	"email_parents" varchar,
	CONSTRAINT "tbl_dancer_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "indx_tbl_dancer" ON "tbl_dancer" (
	"person_id"
);


ALTER TABLE "tbl_dancer" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_countries" CASCADE;
CREATE TABLE "tbl_countries" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	"abbr" varchar,
	CONSTRAINT "tbl_countries_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "indx_countries" ON "tbl_countries" (
	"name"
);


ALTER TABLE "tbl_countries" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_contact_type" CASCADE;
CREATE TABLE "tbl_contact_type" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_contact_type_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_contact_type" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_competition_cash_awards" CASCADE;
CREATE TABLE "tbl_competition_cash_awards" (
	"id" int4 NOT NULL,
	"highscoretype" varchar,
	"place" int4,
	"amount" int4,
	"description" varchar,
	"tour_dates_id" int4 NOT NULL,
	CONSTRAINT "tbl_competition_cash_awards_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_competition_cash_awards" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_cities" CASCADE;
CREATE TABLE "tbl_cities" (
	"id" SERIAL NOT NULL,
	"name" varchar,
	CONSTRAINT "tbl_cities_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "indx_cities" ON "tbl_cities" (
	"name"
);


ALTER TABLE "tbl_cities" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_category" CASCADE;
CREATE TABLE "tbl_category" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_category_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_category" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_awards_type" CASCADE;
CREATE TABLE "tbl_awards_type" (
	"id" int4 NOT NULL,
	"name" varchar NOT NULL,
	CONSTRAINT "tbl_awards_type_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_awards_type" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_age_divisions" CASCADE;
CREATE TABLE "tbl_age_divisions" (
	"id" int4 NOT NULL,
	"range" int4,
	"minimum_age" int4,
	"playlist_workshop_levels_id" int4 NOT NULL,
	CONSTRAINT "tbl_age_divisions_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_age_divisions" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_admin" CASCADE;
CREATE TABLE "tbl_admin" (
	"id" int4 NOT NULL,
	"password" varchar,
	"last_login" varchar,
	"ip" varchar,
	"name" varchar,
	"theme" varchar,
	"financials" int4,
	"accesslevel" int4,
	CONSTRAINT "tbl_admin_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_admin" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_addresses" CASCADE;
CREATE TABLE "tbl_addresses" (
	"id" SERIAL NOT NULL,
	"state_id" int4,
	"address" varchar,
	"zip" varchar,
	"country_id" int4,
	"city_id" int4,
	CONSTRAINT "tbl_addresses_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

ALTER TABLE "tbl_addresses" OWNER TO "peterkim";

DROP TABLE IF EXISTS "studios_has_person" CASCADE;
CREATE TABLE "studios_has_person" (
	"studios_id" int4 NOT NULL,
	"person_id" int4 NOT NULL,
	CONSTRAINT "studios_has_person_pkey" PRIMARY KEY("studios_id","person_id")
)
WITH (
	OIDS = False
);

ALTER TABLE "studios_has_person" OWNER TO "peterkim";

DROP TABLE IF EXISTS "tbl_registrations_routines_dancers" CASCADE;
CREATE TABLE "tbl_registrations_routines_dancers" (
	"id" int4 NOT NULL,
	"registration_id" int4,
	"registrations_routine_id" int4 NOT NULL,
	"dancer_id" int4,
	"workshop_skip" int4,
	CONSTRAINT "registrations_routines_dancers_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "indx_1_registrations_routines_dancers" ON "tbl_registrations_routines_dancers" (
	"registration_id"
);


CREATE INDEX "indx2_registrations_routines_dancers" ON "tbl_registrations_routines_dancers" (
	"registrations_routine_id"
);


CREATE INDEX "indx3_registrations_routines_dancers" ON "tbl_registrations_routines_dancers" (
	"dancer_id"
);


ALTER TABLE "tbl_registrations_routines_dancers" OWNER TO "peterkim";

DROP TABLE IF EXISTS "person_has_contact_type" CASCADE;
CREATE TABLE "person_has_contact_type" (
	"id" SERIAL NOT NULL,
	"person_id" int4 NOT NULL,
	"contact_type_id" int4 NOT NULL,
	"value" varchar,
	CONSTRAINT "person_has_contact_type_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "indx_person_has_contact_type" ON "person_has_contact_type" (
	"person_id"
);


ALTER TABLE "person_has_contact_type" OWNER TO "peterkim";

DROP TABLE IF EXISTS "hotel_contact_type" CASCADE;
CREATE TABLE "hotel_contact_type" (
	"id" SERIAL NOT NULL,
	"contact_type_id" int4 NOT NULL,
	"hotel_id" int4 NOT NULL,
	"value" varchar,
	CONSTRAINT "hotel_contact_type_pkey" PRIMARY KEY("id")
)
WITH (
	OIDS = False
);

CREATE INDEX "hotel_id_indx" ON "hotel_contact_type" (
	"hotel_id"
);


ALTER TABLE "hotel_contact_type" OWNER TO "peterkim";

DROP TABLE IF EXISTS "faculty_has_performance" CASCADE;
CREATE TABLE "faculty_has_performance" (
	"faculty_id" int4 NOT NULL,
	"performance_divisions_id" int4 NOT NULL
)
WITH (
	OIDS = False
);

ALTER TABLE "faculty_has_performance" OWNER TO "peterkim";

ALTER TABLE "tbl_tda_bestdancer_data" ADD CONSTRAINT "Ref_tbl_tda_bestdancer_data_to_tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_bestdancer_data" ADD CONSTRAINT "Ref_tbl_tda_bestdancer_data_to_tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_bestdancer_data" ADD CONSTRAINT "Ref_tbl_tda_bestdancer_data_to_tbl_routines" FOREIGN KEY ("routines_id")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_bestdancer_data" ADD CONSTRAINT "Ref_tbl_tda_bestdancer_data_to_tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_bestdancer_data" ADD CONSTRAINT "Ref_tbl_tda_bestdancer_data_to_tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_award_nominations_has_teacher" ADD CONSTRAINT "Ref_tbl_person_has_tbl_tda_award_nominations_to_tbl_person" FOREIGN KEY ("tbl_person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_award_nominations_has_teacher" ADD CONSTRAINT "Ref_tbl_person_has_tbl_tda_award_nominations_to_tbl_tda_award_nominations" FOREIGN KEY ("tbl_tda_award_nominations_id")
	REFERENCES "tbl_tda_award_nominations"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines15" FOREIGN KEY ("soty_ts_ballet_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines16" FOREIGN KEY ("soty_ts_jazz_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines14" FOREIGN KEY ("soty_ts_musicaltheater_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines12" FOREIGN KEY ("soty_ts_contemplyrical_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines13" FOREIGN KEY ("soty_ts_hiphoptap_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines20" FOREIGN KEY ("soty_mj_ballet_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines21" FOREIGN KEY ("soty_mj_jazz_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines19" FOREIGN KEY ("soty_mj_musicaltheater_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines17" FOREIGN KEY ("soty_mj_contemplyrical_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines18" FOREIGN KEY ("soty_mj_hiphoptap_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines5" FOREIGN KEY ("sa_ts_ota_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines6" FOREIGN KEY ("sa_mj_ota_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines4" FOREIGN KEY ("sa_oacd_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_person" FOREIGN KEY ("tbl_person_id_designer")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines1" FOREIGN KEY ("sa_ts_bc_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines2" FOREIGN KEY ("sa_mj_bc_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines10" FOREIGN KEY ("sa_peopleschoice_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines11" FOREIGN KEY ("sa_s_ota_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines9" FOREIGN KEY ("sa_t_ota_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines7" FOREIGN KEY ("sa_j_ota_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_award_nominations" ADD CONSTRAINT "Ref_tbl_tda_award_nominations_to_tbl_routines8" FOREIGN KEY ("sa_m_ota_routineid")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_competition_awards" ADD CONSTRAINT "Ref_tbl_competition_awards_to_tbl_awards_type" FOREIGN KEY ("awards_type_id")
	REFERENCES "tbl_awards_type"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_competition_awards" ADD CONSTRAINT "Ref_tbl_competition_awards_to_tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dts_attendees" ADD CONSTRAINT "Ref_tbl_dts_attendees_to_tbl_promo_codes" FOREIGN KEY ("promo_codes_id")
	REFERENCES "tbl_promo_codes"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dts_attendees" ADD CONSTRAINT "Ref_tbl_dts_attendees_to_tbl_dts_registrations" FOREIGN KEY ("dts_registrations_id")
	REFERENCES "tbl_dts_registrations"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dts_attendees" ADD CONSTRAINT "Ref_tbl_dts_attendees_to_tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_promocodes" ADD CONSTRAINT "Ref_tbl_store_promocodes_to_tbl_promo_codes_type" FOREIGN KEY ("promo_codes_type_id")
	REFERENCES "tbl_promo_codes_type"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_peopleschoice_votes" ADD CONSTRAINT "Ref_tbl_tda_peopleschoice_votes_to_tbl_routines" FOREIGN KEY ("routines_id")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_peopleschoice_votes" ADD CONSTRAINT "Ref_tbl_tda_peopleschoice_votes_to_tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tda_peopleschoice_votes" ADD CONSTRAINT "Ref_tbl_tda_peopleschoice_votes_to_tbl_tda_award_nominations" FOREIGN KEY ("nomid")
	REFERENCES "tbl_tda_award_nominations"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_dancers" ADD CONSTRAINT "Ref_tbl_date_dancers_to_tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_dancers" ADD CONSTRAINT "Ref_tbl_date_dancers_to_tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_dancers" ADD CONSTRAINT "Ref_tbl_date_dancers_to_tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_dancers" ADD CONSTRAINT "Ref_tbl_date_dancers_to_tbl_registration" FOREIGN KEY ("statsregid")
	REFERENCES "tbl_registration"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_dancers" ADD CONSTRAINT "Ref_tbl_date_dancers_to_tbl_waivers" FOREIGN KEY ("waivers_id")
	REFERENCES "tbl_waivers"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_dancers" ADD CONSTRAINT "Ref_tbl_date_dancers_to_tbl_workshop_levels" FOREIGN KEY ("workshop_levels_id")
	REFERENCES "tbl_workshop_levels"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dts_registrations" ADD CONSTRAINT "Ref_tbl_dts_registrations_to_tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dts_registrations" ADD CONSTRAINT "Ref_tbl_dts_registrations_to_tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dts_registrations" ADD CONSTRAINT "Ref_tbl_dts_registrations_to_tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dts_registrations" ADD CONSTRAINT "Ref_tbl_dts_registrations_to_tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dts_registrations" ADD CONSTRAINT "Ref_tbl_dts_registrations_to_tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dts_registrations" ADD CONSTRAINT "Ref_tbl_dts_registrations_to_tbl_admin" FOREIGN KEY ("admin_id")
	REFERENCES "tbl_admin"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "venue_contact_type" ADD CONSTRAINT "tbl_venue" FOREIGN KEY ("venue_id")
	REFERENCES "tbl_venues"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "venue_contact_type" ADD CONSTRAINT "tbl_contact_type" FOREIGN KEY ("contact_type_id")
	REFERENCES "tbl_contact_type"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tour_dates_workshop_room" ADD CONSTRAINT "tbl_workshop_room" FOREIGN KEY ("workshop_room_id")
	REFERENCES "tbl_workshop_rooms"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tour_dates_workshop_room" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tour_dates_workshop_room" ADD CONSTRAINT "tbl_age_divisions" FOREIGN KEY ("age_divisions_id")
	REFERENCES "tbl_age_divisions"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tour_dates_workshop_room" ADD CONSTRAINT "tbl_level" FOREIGN KEY ("level_id")
	REFERENCES "tbl_levels"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_workshop_levels" ADD CONSTRAINT "tbl_playlist_workshop_levels" FOREIGN KEY ("playlist_workshop_levels_id")
	REFERENCES "tbl_playlist_workshop_levels"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_workshop_levels" ADD CONSTRAINT "tbl_season" FOREIGN KEY ("season_id")
	REFERENCES "tbl_seasons"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_waivers" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_venues" ADD CONSTRAINT "tbl_address" FOREIGN KEY ("address_id")
	REFERENCES "tbl_addresses"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_stats" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registrations_routines7" FOREIGN KEY ("ota_mj_regroutineid")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registrations_routines6" FOREIGN KEY ("ota_ts_regroutineid")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registrations_routines8" FOREIGN KEY ("ota_cd_regroutineid")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registrations_routines10" FOREIGN KEY ("bc_mj_regroutineid")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registrations_routines9" FOREIGN KEY ("bc_ts_regroutineid")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registrations_routines2" FOREIGN KEY ("peopleschoice_regroutineid")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registrations_routines1" FOREIGN KEY ("ota_m_regroutineid")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registrations_routines3" FOREIGN KEY ("ota_j_regroutineid")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registrations_routines5" FOREIGN KEY ("ota_t_regroutineid")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registrations_routines4" FOREIGN KEY ("ota_s_regroutineid")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_specialty" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registrations_routines" FOREIGN KEY ("ts_ballet")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registrations_routines20" FOREIGN KEY ("ts_jazz")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registrations_routines30" FOREIGN KEY ("ts_mtspec")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registrations_routines60" FOREIGN KEY ("ts_contemplyrical")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registrations_routines70" FOREIGN KEY ("ts_hiphoptap")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registrations_routines80" FOREIGN KEY ("mj_ballet")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registrations_routines90" FOREIGN KEY ("mj_jazz")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registrations_routines100" FOREIGN KEY ("mj_mtspec")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registrations_routines11" FOREIGN KEY ("mj_contemplyrical")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registrations_routines12" FOREIGN KEY ("mj_hiphoptap")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_registrations_soty" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_hearts" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_hearts" ADD CONSTRAINT "tbl_store_hearts" FOREIGN KEY ("store_hearts_id")
	REFERENCES "tbl_store_hearts"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_has_dancer" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user_has_dancer" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_user" ADD CONSTRAINT "tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_city" FOREIGN KEY ("city_id")
	REFERENCES "tbl_cities"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_performance_divisions" FOREIGN KEY ("perf_div_types_id")
	REFERENCES "tbl_performance_divisions"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_hotel" FOREIGN KEY ("hotel_id")
	REFERENCES "tbl_hotels"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_venue" FOREIGN KEY ("venue_id")
	REFERENCES "tbl_venues"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_season" FOREIGN KEY ("season_id")
	REFERENCES "tbl_seasons"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("event_id")
	REFERENCES "tbl_events"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_states" FOREIGN KEY ("state_id")
	REFERENCES "tbl_states"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studios_has_dancer" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studios_has_dancer" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studios" ADD CONSTRAINT "tbl_address" FOREIGN KEY ("address_id")
	REFERENCES "tbl_addresses"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studio_contacts" ADD CONSTRAINT "Ref_tbl_studio_contacts_to_tbl_contact_type" FOREIGN KEY ("contact_type_id")
	REFERENCES "tbl_contact_type"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studio_contacts" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studio_awards" ADD CONSTRAINT "tbl_awards_type" FOREIGN KEY ("awards_type_id")
	REFERENCES "tbl_awards_type"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_studio_awards" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products_inventory" ADD CONSTRAINT "tbl_store_products" FOREIGN KEY ("store_products_id")
	REFERENCES "tbl_store_products"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products_inventory" ADD CONSTRAINT "tbl_store_colors" FOREIGN KEY ("store_colors_id")
	REFERENCES "tbl_store_colors"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products_inventory" ADD CONSTRAINT "tbl_store_sizes" FOREIGN KEY ("store_sizes_id")
	REFERENCES "tbl_store_sizes"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products_has_size" ADD CONSTRAINT "tbl_store_sizes" FOREIGN KEY ("store_sizes_id")
	REFERENCES "tbl_store_sizes"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products_has_size" ADD CONSTRAINT "tbl_store_products" FOREIGN KEY ("store_products_id")
	REFERENCES "tbl_store_products"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_products" ADD CONSTRAINT "tbl_store_product_subtypes" FOREIGN KEY ("product_subtypes_id")
	REFERENCES "tbl_store_product_subtypes"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_product_subtypes" ADD CONSTRAINT "store_product_types" FOREIGN KEY ("product_types_id")
	REFERENCES "tbl_store_product_types"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_product_colors" ADD CONSTRAINT "tbl_store_colors" FOREIGN KEY ("store_colors_id")
	REFERENCES "tbl_store_colors"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_product_colors" ADD CONSTRAINT "tbl_store_products" FOREIGN KEY ("store_products_id")
	REFERENCES "tbl_store_products"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_orders" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_store_hearts" ADD CONSTRAINT "tbl_routines" FOREIGN KEY ("routine_id")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_states" ADD CONSTRAINT "Ref_tbl_states_to_tbl_countries" FOREIGN KEY ("country_id")
	REFERENCES "tbl_countries"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_staff" ADD CONSTRAINT "tbl_staff_types" FOREIGN KEY ("staff_types_id")
	REFERENCES "tbl_staff_types"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_special_awards" ADD CONSTRAINT "tbl_awards_type" FOREIGN KEY ("awards_type_id")
	REFERENCES "tbl_awards_type"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_special_awards" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_season_events" ADD CONSTRAINT "tbl_season" FOREIGN KEY ("season_id")
	REFERENCES "tbl_seasons"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_season_events" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_scholarships" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_schedule_workshops_rooms" ADD CONSTRAINT "tbl_date_schedule_workshops" FOREIGN KEY ("schedule_workshops_id")
	REFERENCES "tbl_date_schedule_workshops"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_routines_has_teacher" ADD CONSTRAINT "tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_routines_has_teacher" ADD CONSTRAINT "tbl_routines" FOREIGN KEY ("routine_id")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_routines" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_routine_categories" ADD CONSTRAINT "tbl_category" FOREIGN KEY ("category_id")
	REFERENCES "tbl_category"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_routine_categories" ADD CONSTRAINT "tbl_season" FOREIGN KEY ("season_id")
	REFERENCES "tbl_seasons"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_routines" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_routines" ADD CONSTRAINT "tbl_performance_divisions" FOREIGN KEY ("performance_division_id")
	REFERENCES "tbl_performance_divisions"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_dancers" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_dancers" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_dancers" ADD CONSTRAINT "tbl_promo_codes" FOREIGN KEY ("promo_codes_id")
	REFERENCES "tbl_promo_codes"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_dancers" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_best_dancers" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_best_dancers" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_attendees_dts" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_attendees_dts" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_attendees_dts" ADD CONSTRAINT "tbl_dts_reg_types" FOREIGN KEY ("tbl_dts_reg_types_id")
	REFERENCES "tbl_dts_reg_types"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registration" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registration" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registration" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_promo_codes" ADD CONSTRAINT "tbl_promo_codes_type" FOREIGN KEY ("promo_codes_type_id")
	REFERENCES "tbl_promo_codes_type"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_person" ADD CONSTRAINT "tbl_address" FOREIGN KEY ("address_id")
	REFERENCES "tbl_addresses"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_person" ADD CONSTRAINT "tbl_gender" FOREIGN KEY ("gender_id")
	REFERENCES "tbl_gender"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_person" ADD CONSTRAINT "tbl_person_types" FOREIGN KEY ("person_types_id")
	REFERENCES "tbl_person_types"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_scoring_has_faculty" ADD CONSTRAINT "tbl_faculty" FOREIGN KEY ("faculty_id")
	REFERENCES "tbl_faculty"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_scoring_has_faculty" ADD CONSTRAINT "tbl_online_scoring" FOREIGN KEY ("online_scoring_id")
	REFERENCES "tbl_online_scoring"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_scoring" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_scoring" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_scoring" ADD CONSTRAINT "Ref_tbl_online_scoring_to_tbl_routines3" FOREIGN KEY ("routines_id")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_critiques_judges" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_critiques_access" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_online_critiques_access" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_hotels" ADD CONSTRAINT "tbl_address" FOREIGN KEY ("address_id")
	REFERENCES "tbl_addresses"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_faculty_playlists" ADD CONSTRAINT "tbl_date_playlists" FOREIGN KEY ("date_playlists_id")
	REFERENCES "tbl_date_playlists"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_faculty_playlists" ADD CONSTRAINT "tbl_faculty" FOREIGN KEY ("faculty_id")
	REFERENCES "tbl_faculty"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_faculty" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_faculty" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_events" ADD CONSTRAINT "tbl_event_types" FOREIGN KEY ("event_types_id")
	REFERENCES "tbl_event_types"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_registrations" ADD CONSTRAINT "tbl_user" FOREIGN KEY ("user_id")
	REFERENCES "tbl_user"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_registrations" ADD CONSTRAINT "tbl_admin" FOREIGN KEY ("entered_by_id")
	REFERENCES "tbl_admin"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_registrations" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_registrations" ADD CONSTRAINT "tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_registrations" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studio_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_registrations" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_date_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_reg_types" ADD CONSTRAINT "Ref_tbl_event_reg_types_to_tbl_seasons" FOREIGN KEY ("seasons_id")
	REFERENCES "tbl_seasons"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_reg_types" ADD CONSTRAINT "Ref_tbl_event_reg_types_to_tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_reg_types" ADD CONSTRAINT "Ref_tbl_event_reg_types_to_tbl_event_reg_type_names" FOREIGN KEY ("event_reg_type_names_id")
	REFERENCES "tbl_event_reg_type_names"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_attendees" ADD CONSTRAINT "tbl_promo_codes" FOREIGN KEY ("promo_codes_id")
	REFERENCES "tbl_promo_codes"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_attendees" ADD CONSTRAINT "Ref_tbl_event_attendees_to_tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_event_attendees" ADD CONSTRAINT "Ref_tbl_event_attendees_to_tbl_event_registrations" FOREIGN KEY ("event_registrations_id")
	REFERENCES "tbl_event_registrations"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_studios" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_studios" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_studio_awards" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_studio_awards" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_studio_awards" ADD CONSTRAINT "tbl_studio_awards" FOREIGN KEY ("studio_awards_id")
	REFERENCES "tbl_studio_awards"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_special_awards" ADD CONSTRAINT "tbl_special_awards" FOREIGN KEY ("special_awards_id")
	REFERENCES "tbl_special_awards"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_special_awards" ADD CONSTRAINT "tbl_date_routines" FOREIGN KEY ("date_routines_id")
	REFERENCES "tbl_date_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_special_awards" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_scholarships" ADD CONSTRAINT "tbl_scholarships" FOREIGN KEY ("scholarships_id")
	REFERENCES "tbl_scholarships"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_scholarships" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_scholarships" ADD CONSTRAINT "Ref_tbl_date_scholarships_to_tbl_faculty" FOREIGN KEY ("faculty_id")
	REFERENCES "tbl_faculty"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_scholarships" ADD CONSTRAINT "Ref_tbl_date_scholarships_to_tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_scholarships" ADD CONSTRAINT "Ref_tbl_date_scholarships_to_tbl_date_dancers" FOREIGN KEY ("date_dancer_id")
	REFERENCES "tbl_date_dancers"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_schedule_workshops" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_schedule_competition" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_routine_types" FOREIGN KEY ("routine_types_id")
	REFERENCES "tbl_routine_types"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_perf_div_type" FOREIGN KEY ("perf_div_type_id")
	REFERENCES "tbl_perf_div_types"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_performance_divisions" FOREIGN KEY ("performance_divisions_id")
	REFERENCES "tbl_performance_divisions"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_category" FOREIGN KEY ("category_id")
	REFERENCES "tbl_category"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_age_divisions" FOREIGN KEY ("age_divisions_id")
	REFERENCES "tbl_age_divisions"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routines" ADD CONSTRAINT "tbl_routines" FOREIGN KEY ("routine_id")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routine_dancers" ADD CONSTRAINT "tbl_routines" FOREIGN KEY ("routine_id")
	REFERENCES "tbl_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routine_dancers" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_routine_dancers" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_playlists" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_playlists" ADD CONSTRAINT "tbl_songs" FOREIGN KEY ("songs_id")
	REFERENCES "tbl_songs"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_playlists" ADD CONSTRAINT "tbl_playlist_workshop_levels" FOREIGN KEY ("playlist_workshop_levels_id")
	REFERENCES "tbl_playlist_workshop_levels"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_date_mybtf_exceptions" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_dancer" ADD CONSTRAINT "tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_competition_cash_awards" ADD CONSTRAINT "tbl_tour_dates" FOREIGN KEY ("tour_dates_id")
	REFERENCES "tbl_tour_dates"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_age_divisions" ADD CONSTRAINT "tbl_playlist_workshop_levels" FOREIGN KEY ("playlist_workshop_levels_id")
	REFERENCES "tbl_playlist_workshop_levels"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_addresses" ADD CONSTRAINT "tbl_states" FOREIGN KEY ("state_id")
	REFERENCES "tbl_states"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_addresses" ADD CONSTRAINT "tbl_countries" FOREIGN KEY ("country_id")
	REFERENCES "tbl_countries"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_addresses" ADD CONSTRAINT "tbl_city" FOREIGN KEY ("city_id")
	REFERENCES "tbl_cities"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "studios_has_person" ADD CONSTRAINT "tbl_studios" FOREIGN KEY ("studios_id")
	REFERENCES "tbl_studios"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "studios_has_person" ADD CONSTRAINT "tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_routines_dancers" ADD CONSTRAINT "tbl_registration" FOREIGN KEY ("registration_id")
	REFERENCES "tbl_registration"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_routines_dancers" ADD CONSTRAINT "tbl_dancer" FOREIGN KEY ("dancer_id")
	REFERENCES "tbl_dancer"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_registrations_routines_dancers" ADD CONSTRAINT "tbl_registrations_routines" FOREIGN KEY ("registrations_routine_id")
	REFERENCES "tbl_registrations_routines"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "person_has_contact_type" ADD CONSTRAINT "tbl_person" FOREIGN KEY ("person_id")
	REFERENCES "tbl_person"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "person_has_contact_type" ADD CONSTRAINT "tbl_contact_type" FOREIGN KEY ("contact_type_id")
	REFERENCES "tbl_contact_type"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "hotel_contact_type" ADD CONSTRAINT "tbl_contact_type" FOREIGN KEY ("contact_type_id")
	REFERENCES "tbl_contact_type"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "hotel_contact_type" ADD CONSTRAINT "tbl_hotel" FOREIGN KEY ("hotel_id")
	REFERENCES "tbl_hotels"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "faculty_has_performance" ADD CONSTRAINT "tbl_performance_divisions" FOREIGN KEY ("performance_divisions_id")
	REFERENCES "tbl_performance_divisions"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "faculty_has_performance" ADD CONSTRAINT "tbl_faculty" FOREIGN KEY ("faculty_id")
	REFERENCES "tbl_faculty"("id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;
