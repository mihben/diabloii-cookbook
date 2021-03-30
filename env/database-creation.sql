CREATE EXTENSION IF NOT EXISTS "uuid-ossp";

CREATE TABLE public.runes
(
    id uuid NOT NULL,
    name text COLLATE pg_catalog."default" NOT NULL,
    level integer NOT NULL,
    "order" integer NOT NULL,
    in_weapon text COLLATE pg_catalog."default" NOT NULL,
    in_helm text COLLATE pg_catalog."default" NOT NULL,
    in_armor text COLLATE pg_catalog."default" NOT NULL,
    in_shield text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_runes" PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE public.runes
    OWNER to admin;

CREATE TABLE public.item_types
(
    id uuid NOT NULL,
    flag text COLLATE pg_catalog."default" NOT NULL,
    name text COLLATE pg_catalog."default" NOT NULL,
    item_group text COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT "PK_item_types" PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE public.item_types
    OWNER to admin;

CREATE UNIQUE INDEX "IX_item_types_flag"
    ON public.item_types USING btree
    (flag COLLATE pg_catalog."default" ASC NULLS LAST)
    TABLESPACE pg_default;
	
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('0dd9b0be-af67-41e3-9bf6-5861321246fd', 'El', 11, 1, '+50 Attack Rating, +1 Light Radius', '+1 Light Radius, +15 Defense', '+1 Light Radius, +15 Defense', '+1 Light Radius, +15 Defense');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('231d1911-ad45-4c2b-8476-45992e2017a2', 'Eld', 11, 4, '+75% Damage vs. Undead, +50 Attack Rating vs. Undead', 'Lowers Stamina drain by 15%', 'Lowers Stamina drain by 15%', '+7% Blocking');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('a0ec93e3-cf73-46e9-a650-575c15b182dd', 'Tir', 13, 7, '+2 Mana Per Kill', '+2 Mana Per Kill.', '+2 Mana Per Kill.', '+2 Mana Per Kill.');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('f1fba027-ed97-4920-96e3-07935c2c60b5', 'Nef', 13, 10, 'Knockback', '+30 Defense vs. Missile', '+30 Defense vs. Missile', '+30 Defense vs. Missile');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('386c395b-e1af-497c-a3c2-9ca21242a808', 'Eth', 15, 13, '-25% Target Defense', 'Regenerate Mana 15%', 'Regenerate Mana 15%', 'Regenerate Mana 15%');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('7fd0ccca-b35e-43f9-a159-ea9a1a613a55', 'Ith', 15, 16, '+9 to Maximum Damage', '15% Damage Taken Goes to Mana', '15% Damage Taken Goes to Mana', '15% Damage Taken Goes to Mana');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('b6d295f1-dc2f-4d06-82ae-86c7e6a80be7', 'Tal', 17, 19, '75 Poison damage over 5 seconds', '+35% Poison Resistance', '+35% Poison Resistance', '+35% Poison Resistance');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('0538ca1d-3fc5-4192-ac84-b396313554e1', 'Ral', 19, 22, '+5-30 Fire Damage', '+35% Fire Resistance', '+35% Fire Resistance', '+35% Fire Resistance');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('b3af078c-dffb-461f-978f-0f78cfb733d0', 'Ort', 21, 25, '+1-50 Lightning Damage', '+35% Lightning Resistance', '+35% Lightning Resistance', '+35% Lightning Resistance');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('e62ceb3e-2f47-478e-b7ad-0bed53df3ee2', 'Thul', 23, 28, '+3-14 Cold Damage (Cold Length 3 seconds)', '+35% Cold Resistance', '+35% Cold Resistance', '+35% Cold Resistance');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('ccc8f705-fe73-4762-8ce5-5a75b6680cbd', 'Amn', 25, 31, '7% Life Stolen Per Hit', 'Attacker takes 14 damage', 'Attacker takes 14 damage', 'Attacker takes 14 damage');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('b5eda6e9-2022-4995-b1e0-73c0daad6bed', 'Sol', 27, 2, '+9 to Minimum Damage', '-7 Damage Taken', '-7 Damage Taken', '-7 Damage Taken');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('62c34cba-f2ea-4025-a72a-af1c7c280464', 'Shael', 29, 5, 'Faster Attack Rate (+20)', 'Faster Hit Recovery (+20)', 'Faster Hit Recovery (+20)', 'Faster Block Rate (+20)');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('f9de59f0-c327-43a4-9bed-587088c32e83', 'Dol', 21, 8, '25% Chance that Hit Causes Monster to Flee', '+7 Replenish Life', '+7 Replenish Life', '+7 Replenish Life');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('b6f0419f-72eb-46e0-94a2-d8481e43ff17', 'Hel', 0, 11, '-20% Requirements', '-15% Requirements', '-15% Requirements', '-15% Requirements');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('15d1e10f-96c8-4939-aad0-a9bc7e72be07', 'Io', 35, 14, '+10 Vitality', '+10 Vitality', '+10 Vitality', '+10 Vitality');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('15a73f1d-d33d-43b2-b466-d793287b88b2', 'Lum', 37, 17, '+10 Energy', '+10 Energy', '+10 Energy', '+10 Energy');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('12148ff0-02d4-4a27-b42e-2185882ce146', 'Ko', 39, 20, '+10 Dexterity', '+10 Dexterity', '+10 Dexterity', '+10 Dexterity');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('674bb0d9-04e4-4959-9885-629815774273', 'Fal', 41, 23, '+10 Strength', '+10 Strength', '+10 Strength', '+10 Strength');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('ac4642b4-2306-4819-86db-34e10cf2ede6', 'Lem', 43, 26, '+75% Extra Gold from Monsters', '+50% Extra Gold from Monsters', '+50% Extra Gold from Monsters', '+50% Extra Gold from Monsters');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('d81f26da-8654-4594-b653-769c6fe29914', 'Pul', 45, 29, '+75% Damage to Demons, +100 AR against Demons', '+30% Defense', '+30% Defense', '+30% Defense');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('b990946c-1265-48af-b7b0-16a0f8cb76c7', 'Um', 47, 32, '25% Chance of Open Wounds', '+15% Resist All', '+15% Resist All', '+22% Resist All');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('786b17a8-31e8-4baf-8192-405cd12eb443', 'Mal', 49, 3, 'Prevent Monster Healing', 'Reduce Magic Damage by 7', 'Reduce Magic Damage by 7', 'Reduce Magic Damage by 7');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('df94c072-aa75-44c5-9766-32cdd439e34e', 'Ist', 51, 6, '+30% Better Chance of Finding Magical Items', '+25% Better Chance of Finding Magical Items', '+25% Better Chance of Finding Magical Items', '+25% Better Chance of Finding Magical Items');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('dfaf9d20-6f51-411f-a14a-6569c11f06f8', 'Gul', 53, 9, '+20% Attack Rating', '+5 to Max Resist Poison', '+5 to Max Resist Poison', '+5 to Max Resist Poison');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('21ab17cb-9c64-4aa5-b95c-06efcd75c24a', 'Vex', 55, 12, '7% Mana Leech', '+5 to Max Fire Resist', '+5 to Max Fire Resist', '+5 to Max Fire Resist');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('8f438d9a-c031-4227-becc-f274e7c11af4', 'Ohm', 57, 15, '+50% Damage', '+5 to Max. Resist Cold', '+5 to Max. Resist Cold', '+5 to Max. Resist Cold');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('43d2e635-1c6c-4896-a0fd-a355478e5dfb', 'Lo', 59, 18, '20% Chance of Deadly Strike', '+5 to Max. Resist Lightning', '+5 to Max. Resist Lightning', '+5 to Max. Resist Lightning');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('e7067c4e-9fd0-4e6a-9b2d-153652ce5c1c', 'Sur', 61, 21, '20% Chance of Hit Blinds Target', '+5% total Mana', '+5% total Mana', '+50 Mana');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('547e5f0f-6478-463f-9fb2-f7c0effa02e1', 'Ber', 63, 24, '20% Chance of Crushing Blow', 'Damage Reduced by 8%', 'Damage Reduced by 8%', 'Damage Reduced by 8%');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('438a1645-a8c1-4702-8119-abe764376405', 'Jah', 65, 27, 'Ignores Target Defense', '+5% of total Hit Points', '+5% of total Hit Points', '+50 Hit Points');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('5d0c695e-272d-42b3-ab67-eba45fb108fe', 'Cham', 67, 30, '32% Chance of Hit Freezing Target for 3 seconds', 'Cannot be Frozen', 'Cannot be Frozen', 'Cannot be Frozen');
INSERT INTO runes(id, name, "level", "order", in_weapon, in_helm, in_armor, in_shield) VALUES('3ad5bf94-4216-46e2-a946-c0390046ddb1', 'Zod', 69, 33, 'Indestructible', 'Indestructible', 'Indestructible', 'Indestructible');


INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Body armor', 'Armor');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Shield' , 'Armor');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Helmet' , 'Armor');

INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Sword', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Dagger', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Club', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Mace', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Hammer', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Scepter', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Staff', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Wand', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Spear', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Polearm', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Bow', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Crossbow', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Katar', 'Weapon');
INSERT INTO item_types(id, name, item_group) VALUES(uuid_generate_v4(), 'Orb', 'Weapon');