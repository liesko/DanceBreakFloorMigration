CREATE TABLE "public"."_pgmdd_backup_tbl_store_orders_2016-19-11_19:16" AS
	SELECT * FROM public.tbl_store_orders;

ALTER TABLE "tbl_store_orders" ALTER COLUMN "label_cost" SET DEFAULT -;

CREATE TABLE "public"."_pgmdd_backup_tbl_store_products_2016-19-11_19:16" AS
	SELECT * FROM public.tbl_store_products;

ALTER TABLE "tbl_store_products" ALTER COLUMN "description" SET DEFAULT no desc;
