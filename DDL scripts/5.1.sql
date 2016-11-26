CREATE TABLE "public"."_pgmdd_backup_tbl_store_products_2016-25-11_19:32" AS
	SELECT * FROM public.tbl_store_products;

ALTER TABLE "tbl_store_products" ALTER COLUMN "description" SET DEFAULT 'no desc';

CREATE TABLE "public"."_pgmdd_backup_tbl_events_2016-25-11_19:32" AS
	SELECT * FROM public.tbl_events;

ALTER TABLE "tbl_events" 
	ADD COLUMN "workshoponly" int4
		DEFAULT 0;

DROP TABLE IF EXISTS "tbl_current_season" CASCADE;
CREATE TABLE "tbl_current_season" (
	"season_id" int4 NOT NULL,
	"events_id" int4 NOT NULL,
	"is_current_season" bool DEFAULT True,
	PRIMARY KEY("season_id","events_id")
);

ALTER TABLE "tbl_current_season" ADD CONSTRAINT "tbl_season" FOREIGN KEY ("season_id")
	REFERENCES "tbl_seasons"("seasons_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;

ALTER TABLE "tbl_current_season" ADD CONSTRAINT "tbl_events" FOREIGN KEY ("events_id")
	REFERENCES "tbl_events"("events_id")
	MATCH SIMPLE
	ON DELETE NO ACTION
	ON UPDATE NO ACTION
	NOT DEFERRABLE;
