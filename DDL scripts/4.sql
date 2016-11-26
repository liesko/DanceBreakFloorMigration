CREATE TABLE "public"."_pgmdd_backup_tbl_store_orders_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_store_orders;

ALTER TABLE "tbl_store_orders" 
	ADD COLUMN "label_json" text;

ALTER TABLE "public"."tbl_store_orders" 
	DROP COLUMN "label_carrier" CASCADE;

ALTER TABLE "public"."tbl_store_orders" 
	DROP COLUMN "label_cost" CASCADE;

ALTER TABLE "public"."tbl_store_orders" 
	DROP COLUMN "label_made" CASCADE;

CREATE TABLE "public"."_pgmdd_backup_tbl_store_products_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_store_products;

ALTER TABLE "tbl_store_products" ALTER COLUMN "description" SET DEFAULT 'no desc';

CREATE TABLE "public"."_pgmdd_backup_schedule_workshops_room_2016-23-11_21:51" AS
	SELECT * FROM public.schedule_workshops_room;

ALTER TABLE "schedule_workshops_room" 
	RENAME COLUMN "workshop_room_id" TO "workshop_room_plan_id";

ALTER TABLE "public"."schedule_workshops_room" 
	DROP CONSTRAINT "schedule_workshops_room_pkey" CASCADE;

ALTER TABLE "schedule_workshops_room" 
	ADD PRIMARY KEY ("schedule_workshops_id","workshop_room_plan_id");

CREATE TABLE "public"."_pgmdd_backup_tbl_promo_codes_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_promo_codes;

ALTER TABLE "public"."tbl_promo_codes" 
	DROP COLUMN "events_id" CASCADE;

CREATE TABLE "public"."_pgmdd_backup_tbl_awards_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_awards;

ALTER TABLE "public"."tbl_awards" 
	DROP COLUMN "new_field0" CASCADE;

CREATE TABLE "public"."_pgmdd_backup_tbl_tour_dates_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_tour_dates;

ALTER TABLE "tbl_tour_dates" 
	RENAME COLUMN "workshop_notes" TO "json_mybtf";

ALTER TABLE "tbl_tour_dates" 
	RENAME COLUMN "competition_notes" TO "json_tda_dance";

ALTER TABLE "tbl_tour_dates" 
	RENAME COLUMN "web_critiques" TO "performance_divisions_id";

ALTER TABLE "tbl_tour_dates" 
	ADD COLUMN "json_workshop" text;

ALTER TABLE "tbl_tour_dates" 
	ADD COLUMN "json_competition" text;

ALTER TABLE "public"."tbl_tour_dates" 
	DROP COLUMN "mybtf_photovideo_active" CASCADE;

ALTER TABLE "public"."tbl_tour_dates" 
	DROP COLUMN "perfdivtype" CASCADE;

ALTER TABLE "public"."tbl_tour_dates" 
	DROP COLUMN "mybtf_no_competition" CASCADE;

ALTER TABLE "public"."tbl_tour_dates" 
	DROP COLUMN "mybtfregenabled" CASCADE;

ALTER TABLE "public"."tbl_tour_dates" 
	DROP COLUMN "tda_danceoff_judge_count" CASCADE;

ALTER TABLE "public"."tbl_tour_dates" 
	DROP COLUMN "tda_danceoff_bestdancer_counts" CASCADE;

ALTER TABLE "public"."tbl_tour_dates" 
	DROP COLUMN "competition_room_count" CASCADE;

ALTER TABLE "public"."tbl_tour_dates" 
	DROP COLUMN "workshop_updated" CASCADE;

ALTER TABLE "public"."tbl_tour_dates" 
	DROP COLUMN "no_hotel" CASCADE;

ALTER TABLE "public"."tbl_tour_dates" 
	DROP COLUMN "workshop_room_count" CASCADE;

CREATE TABLE "public"."_pgmdd_backup_tbl_fee_types_has_tbl_registration_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_fee_types_has_tbl_registration;

ALTER TABLE "tbl_fee_types_has_tbl_registration" 
	ADD PRIMARY KEY ("fee_types_id","registration_id");

CREATE TABLE "public"."_pgmdd_backup_tbl_registration_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_registration;

ALTER TABLE "tbl_registration" 
	ADD COLUMN "enteredby" int4;

CREATE TABLE "public"."_pgmdd_backup_tbl_events_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_events;

ALTER TABLE "tbl_events" ALTER COLUMN "name" DROP NOT NULL;

CREATE TABLE "public"."_pgmdd_backup_tbl_address_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_address;

ALTER TABLE "tbl_address" 
	ADD COLUMN "country_id" int4;

CREATE TABLE "public"."_pgmdd_backup_tbl_person_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_person;

ALTER TABLE "tbl_person" 
	ADD COLUMN "person_types_id" int4;

CREATE TABLE "public"."_pgmdd_backup_tbl_user_2016-23-11_21:51" AS
	SELECT * FROM public.tbl_user;

ALTER TABLE "public"."tbl_user" 
	DROP COLUMN "user_types_id" CASCADE;

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

DROP TABLE IF EXISTS "tbl_workshop_room_plan" CASCADE;
CREATE TABLE "tbl_workshop_room_plan" (
	"workshop_room_plan_id" int4 NOT NULL,
	"room_bold" int4 NOT NULL DEFAULT 0,
	"room_highlight" int4 NOT NULL DEFAULT 0,
	"description" varchar,
	PRIMARY KEY("workshop_room_plan_id")
);

DROP TABLE IF EXISTS "tbl_person_types" CASCADE;
CREATE TABLE "tbl_person_types" (
	"person_types_id" int4 NOT NULL,
	"name" varchar NOT NULL,
	PRIMARY KEY("person_types_id")
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

ALTER TABLE "tbl_person" ADD CONSTRAINT "tbl_person_types" FOREIGN KEY ("person_types_id")
	REFERENCES "tbl_person_types"("person_types_id")
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

ALTER TABLE "tbl_tour_dates" ADD CONSTRAINT "tbl_performance_divisions" FOREIGN KEY ("performance_divisions_id")
	REFERENCES "tbl_performance_divisions"("performance_divisions_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE public.schedule_workshops_room 
	DROP CONSTRAINT "tbl_workshop_room0" CASCADE;

ALTER TABLE "schedule_workshops_room" ADD CONSTRAINT "tbl_workshop_room_plan" FOREIGN KEY ("workshop_room_plan_id")
	REFERENCES "tbl_workshop_room_plan"("workshop_room_plan_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;
