CREATE TABLE "public"."_pgmdd_backup_tbl_store_products_2016-25-11_20:20" AS
	SELECT * FROM public.tbl_store_products;

ALTER TABLE "tbl_store_products" ALTER COLUMN "description" SET DEFAULT 'no desc';

CREATE TABLE "public"."_pgmdd_backup_tbl_events_2016-25-11_20:20" AS
	SELECT * FROM public.tbl_events;

ALTER TABLE "tbl_events" 
	ALTER COLUMN "intopmenu" TYPE int4;

ALTER TABLE "tbl_events" 
	ALTER COLUMN "web_home_webcast_banner" TYPE int4;
