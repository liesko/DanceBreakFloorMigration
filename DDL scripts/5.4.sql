CREATE TABLE "public"."_pgmdd_backup_tbl_store_products_2016-26-11_14:14" AS
	SELECT * FROM public.tbl_store_products;

ALTER TABLE "tbl_store_products" ALTER COLUMN "description" SET DEFAULT 'no desc';

CREATE TABLE "public"."_pgmdd_backup_tbl_age_divisions_2016-26-11_14:14" AS
	SELECT * FROM public.tbl_age_divisions;

ALTER TABLE "tbl_age_divisions" 
	ALTER COLUMN "range" TYPE bytea;
