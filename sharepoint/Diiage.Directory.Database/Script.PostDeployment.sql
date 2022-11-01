﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
IF NOT EXISTS (SELECT TOP 1 1 FROM Employee)
BEGIN
INSERT INTO Employee([DirectoryId], [Surname], [Firstname], [StartDate], [Position], [PositionLevel], [AnnualGrossIncome], [Email], [PersonalEmail], [Phone], [PersonalPhone], [BirthDate], [PersonalAddressStreet], [PersonalAddressPostCode], [PersonalAddressCity], [PersonalAddressCountry], [AddressStreet], [AddressPostCode], [AddressCity], [AddressCountry], [Comments])
VALUES
('881539A0-99F4-5D57-CA27-6A352ED0BBB4','Kim','Madeline','2018-08-05','Stagiaire','2.1 105',37238,'penatibus.et@lectuspedeultrices.ca','sit@nonnisiAenean.co.uk','(649) 178-7234','(972) 817-3471','1977-01-05','5998 Metus Avenue','28353','Châlons-en-Champagne','France','609-7825 Vel, Road','03669','Joué-lès-Tours','France','non enim commodo hendrerit. Donec'),
('7FBC59E6-3525-6DD6-DF5C-59CD0CC7900F','Hinton','Velma','2021-05-29','Chef de projet','2.1 105',29303,'tellus.lorem.eu@maurisSuspendisse.org','dictum.magna.Ut@pharetra.org','(214) 578-1194','(346) 545-0484','1975-01-13','P.O. Box 180, 7026 Tempus Road','71137','Tourcoing','France','P.O. Box 310, 5612 Libero St.','22481','Paris','France','ullamcorper. Duis cursus,'),
('E1275B8C-55A2-84B2-A778-E8C1BEF3774E','Mayo','Isaac','2021-03-10','Chef de projet','1.1 95',27913,'massa@egettincidunt.net','elit.erat.vitae@volutpat.org','(559) 872-8455','(275) 825-5956','1975-07-22','P.O. Box 183, 8384 Neque Ave','20412','Châlons-en-Champagne','France','P.O. Box 692, 4075 Nullam Rd.','42967','Troyes','France','nostra, per inceptos hymenaeos. Mauris ut quam vel'),
('3AA280A4-1E1C-DE36-2BA1-850BC7B624DC','Santana','Slade','2009-05-08','Consultant','2.3 130',38473,'Aenean.gravida.nunc@cursusvestibulumMauris.net','facilisis@orciluctuset.org','(521) 231-5386','(137) 404-4616','1992-09-05','421-5106 Aliquam Rd.','70015','Lunel','France','Ap #896-7956 Mauris Ave','15033','Cherbourg-Octeville','France','mauris elit, dictum eu, eleifend'),
('AA75AF3F-4FB3-F541-F4A7-202DBB31713B','Wise','Hermione','2011-12-31','Architecte','2.2 110',41428,'sit@laciniaorci.edu','Mauris.blandit@rutrumeuultrices.ca','(191) 328-1270','(298) 723-2942','1998-12-17','Ap #669-8537 Phasellus St.','49731','Ajaccio','France','P.O. Box 605, 4834 Purus Rd.','16930','Lanester','France','ut'),
('B9923AD5-76E8-924A-B3AC-2937455DF236','Miranda','Odette','2008-10-29','Testeur','2.3 130',34791,'libero.nec.ligula@convallisconvallis.ca','vestibulum@dolorquamelementum.ca','(313) 837-8535','(942) 456-1857','1997-06-06','788-5179 Arcu Av.','52504','Le Petit-Quevilly','France','515 Dui. Street','41996','Mâcon','France','dictum sapien. Aenean massa. Integer vitae nibh. Donec est mauris,'),
('220EC0B3-4A05-9499-6D03-4B116898AF1A','Reyes','Allistair','2016-07-01','Développeur','2.3 130',38328,'Sed@utpharetra.co.uk','et.magnis@Classaptent.com','(565) 544-7870','(527) 795-0469','1983-02-27','P.O. Box 159, 3009 Libero St.','63674','Albi','France','366-334 Ornare Street','33363','Pessac','France','varius. Nam porttitor'),
('2B4CB61B-E945-48E0-17AF-752099CA5FF7','Frazier','Erin','2020-10-09','Testeur','1.1 95',28859,'sodales@utsem.edu','nunc.sit@elitpedemalesuada.co.uk','(848) 458-7073','(236) 347-8899','1990-01-29','3612 Et Rd.','02439','La Rochelle','France','284-1693 Etiam Street','62525','Cagnes-sur-Mer','France','posuere at, velit. Cras'),
('DA28F1E4-625E-DCA8-E73A-765CCF5EF76B','Bender','Indira','2011-08-31','Chef de projet','1.1 95',35472,'ligula.elit.pretium@tempor.net','amet.diam@nostra.net','(537) 225-2144','(260) 392-6781','1999-01-08','205-1920 Vitae, St.','82768','La Roche-sur-Yon','France','878-1048 Etiam Street','82326','La Rochelle','France','ac risus. Morbi metus.'),
('7BD32E92-1563-C020-9C6A-4FDC6B8E06C4','Richardson','Yuli','2015-10-08','Testeur','2.3 130',25862,'vulputate.nisi.sem@justofaucibus.com','Mauris.non.dui@Curabitur.net','(435) 790-1266','(317) 377-2794','1989-11-19','Ap #980-8551 Consectetuer St.','32371','Vichy','France','7731 Hendrerit Avenue','23861','Mulhouse','France','in faucibus orci luctus et ultrices'),
('5765AB95-7FD5-4CF3-96F8-595E9FA933C3','Hughes','Maisie','2014-11-08','Testeur','2.2 110',26962,'a@Maurisnulla.com','aliquet.diam@ultrices.org','(265) 202-2053','(708) 710-5971','1986-08-07','P.O. Box 467, 3154 Magna. St.','89957','Abbeville','France','Ap #189-385 Et, Rd.','04220','Wattrelos','France','pharetra ut, pharetra sed, hendrerit a, arcu. Sed'),
('523C37BB-4EC3-D38B-AE9D-087C15357B65','Snow','Hedda','2015-08-08','Chef de projet','2.3 130',28627,'a.nunc.In@accumsannequeet.ca','primis.in@sitametmetus.org','(854) 535-4059','(308) 866-7965','1984-05-15','9703 Ultrices Avenue','41622','Dijon','France','Ap #282-2173 Dolor St.','15420','Tours','France','sapien, cursus in, hendrerit consectetuer, cursus et, magna. Praesent interdum'),
('EEB0B5B6-7D6C-5C85-9407-384F9845EA14','Ortiz','Lars','2010-05-21','Consultant','2.1 105',41140,'et.tristique.pellentesque@eros.org','Proin.ultrices@lectuspede.co.uk','(157) 592-4420','(645) 397-7475','1993-01-12','988-133 Magna Street','76547','Niort','France','8987 Sed St.','25466','Vannes','France','Vivamus euismod'),
('2639B426-5A46-DB82-B718-2ABD7EF4C194','Gomez','Brady','2008-05-10','Testeur','2.3 130',30237,'Donec@Duissitamet.ca','molestie.in.tempus@blanditenim.ca','(777) 384-3995','(747) 562-6585','1983-12-20','360-1636 Neque Rd.','54518','Bastia','France','Ap #750-3434 Dapibus St.','89442','Béthune','France','Mauris quis turpis vitae purus gravida sagittis. Duis'),
('A56A7B6E-3A0C-508F-52D2-419B633219F8','Webster','Rajah','2011-03-10','Chef de projet','2.2 110',26234,'hymenaeos.Mauris@sitamet.edu','ornare.elit@infelisNulla.edu','(695) 991-2209','(175) 691-5678','1998-04-06','P.O. Box 983, 3524 Risus. Road','49893','Cholet','France','1143 Vel, Avenue','95567','Abbeville','France','facilisis'),
('78BBE2DC-01C6-CFB7-394F-432E98D35D17','Holmes','Rhona','2008-08-23','Chef de projet','2.3 130',26996,'tempus.non@eget.com','feugiat@vestibulumMauris.co.uk','(260) 435-8220','(556) 196-7233','1982-04-17','310-767 Nunc St.','01359','Saint-Malo','France','790-961 Adipiscing Avenue','10710','Alès','France','sed, sapien. Nunc pulvinar arcu et pede. Nunc sed orci'),
('EF9CDA69-297B-2AFE-5FAB-06806502E331','Jackson','Cruz','2021-01-18','Testeur','2.3 130',28565,'Duis.at.lacus@Inmi.edu','eget.lacus@magna.org','(466) 137-9699','(370) 631-9576','1992-04-08','2848 Suspendisse Road','33059','Le Petit-Quevilly','France','728-8345 Elit St.','81165','Brive-la-Gaillarde','France','sed, hendrerit a, arcu. Sed et'),
('8C56487D-977A-2B21-0A2E-11251CC2549E','Horton','Mona','2013-10-29','Testeur','1.1 95',25997,'consectetuer.adipiscing.elit@ornarelectus.co.uk','eu.euismod@risusat.edu','(320) 506-3042','(482) 672-8916','1995-11-08','Ap #696-6569 Placerat Rd.','37671','Sète','France','594-4289 Et Road','15689','Strasbourg','France','Cras dictum ultricies ligula. Nullam enim.'),
('B3105A0F-AD4F-69D6-7D23-2806B3A74938','Turner','Emery','2021-07-14','Stagiaire','1.1 95',29589,'non.dapibus@Morbi.com','justo@tempus.ca','(674) 105-8057','(754) 278-2302','1983-09-19','8468 Nec Street','02090','Haguenau','France','640-9965 Tincidunt Road','16027','Vandoeuvre-lès-Nancy','France','eu'),
('CD0999ED-FF00-AA92-7245-5CCEDCE07C03','Joseph','Kato','2014-04-07','Chef de projet','2.3 130',36717,'Curabitur@convallisconvallisdolor.co.uk','vehicula.Pellentesque@dolorquamelementum.com','(759) 846-4420','(119) 145-3497','1983-07-01','7900 Neque Ave','39264','Le Petit-Quevilly','France','692-1871 Aliquam Road','84459','Nantes','France','ligula. Donec luctus aliquet odio.'),
('98DB4ADA-CE3A-DED1-9DEA-AC189DC22EDB','Snyder','Edan','2019-11-27','Développeur','2.1 105',31744,'blandit.viverra.Donec@Nullaeu.ca','lorem.vehicula@eu.ca','(751) 166-8183','(763) 339-6923','1993-12-30','Ap #590-1009 Ornare, Road','84376','Courbevoie','France','P.O. Box 664, 1963 Scelerisque Av.','55730','Dijon','France','Mauris blandit enim consequat purus. Maecenas libero est,'),
('34E1F38E-DBA9-B3C6-8947-AC382266FFA6','Puckett','Sylvester','2021-07-10','Testeur','2.2 110',26833,'fringilla.euismod.enim@Phaselluselit.ca','Integer.vulputate.risus@neceleifendnon.com','(599) 267-0268','(219) 972-0104','1995-09-20','Ap #729-6000 Dolor. Avenue','85421','Aurillac','France','P.O. Box 181, 3540 Proin Avenue','00560','Colomiers','France','non lorem vitae odio sagittis semper. Nam'),
('6772ACE3-CC75-CC41-75AA-F7037EB4A19D','Hodges','Berk','2019-03-07','Développeur','1.1 95',29470,'auctor.velit.eget@sodalespurusin.com','tempus.lorem.fringilla@dignissimMaecenas.net','(443) 256-4968','(547) 994-1971','1999-03-07','Ap #482-1042 Scelerisque, Av.','50739','Vernon','France','Ap #515-8441 Fringilla. Avenue','78516','Haguenau','France','Duis a'),
('0681681A-8D99-35CA-6A76-B4ED927F9F93','Mcgowan','Jena','2021-11-26','Développeur','2.2 110',40207,'tincidunt@sapien.com','nonummy.ut@rhoncusNullam.com','(730) 452-0977','(968) 476-3889','1992-03-23','1973 A Road','98822','Bayonne','France','P.O. Box 931, 9335 Lorem St.','43754','Saint-Dizier','France','arcu. Nunc mauris. Morbi non'),
('646D4923-62C6-73CF-6060-82CD5F7B4952','Meyer','Craig','2015-10-22','Consultant','1.1 95',38576,'nunc@penatibusetmagnis.net','augue.malesuada.malesuada@ultrices.net','(358) 831-1277','(108) 213-8190','1998-05-17','268-7681 Feugiat St.','07244','Bergerac','France','386-4422 Vel Avenue','67593','Ajaccio','France','turpis egestas. Fusce aliquet magna a'),
('3BEC84EB-39B0-21E4-DFBE-3DEC5A1C6984','Blanchard','Uriah','2020-10-06','Testeur','1.1 95',26697,'sed.dui.Fusce@antedictum.co.uk','velit@ornareegestas.net','(855) 688-4486','(356) 891-9314','1978-04-24','P.O. Box 569, 5736 Elit Street','69439','Tournefeuille','France','967-6738 Maecenas St.','61985','Limoges','France','et ipsum cursus vestibulum. Mauris magna. Duis dignissim tempor'),
('7848C196-1573-D031-DCC9-9C5BE3B1BAD2','Acosta','Norman','2014-10-05','Chef de projet','2.2 110',40055,'semper.auctor.Mauris@semper.co.uk','erat.volutpat@eget.co.uk','(635) 953-0338','(173) 965-1781','1980-01-28','P.O. Box 257, 9240 Sed Ave','68176','Alençon','France','Ap #152-3495 A, Rd.','76466','Bastia','France','ut erat. Sed nunc est, mollis non,'),
('5EC56AEC-8467-B085-847C-6E93103BB852','Shields','Randall','2008-03-03','Chef de projet','1.1 95',29148,'augue.ac.ipsum@a.co.uk','consectetuer.rhoncus@Craseu.ca','(136) 490-7599','(835) 851-7098','1993-06-06','9227 Viverra. Street','23228','Amiens','France','P.O. Box 690, 8219 Nec, Ave','98752','Rennes','France','mauris ipsum'),
('8EA6D29E-AE76-336A-E8E6-74DABF827619','Peters','Odessa','2017-02-01','Développeur','2.1 105',35784,'Quisque.varius@facilisisvitae.org','urna.convallis.erat@Integervitae.com','(975) 202-9427','(309) 457-5331','1981-03-02','8339 Ultricies Ave','21205','Besançon','France','P.O. Box 130, 2187 Eu Road','62591','Saint-Sébastien-sur-Loire','France','pellentesque, tellus sem mollis dui, in sodales elit erat vitae'),
('40340297-E365-0394-4CAF-FB38CD481187','Guerrero','Kamal','2011-07-05','Chef de projet','2.2 110',25303,'libero.Proin@nislelementumpurus.com','purus.Nullam@velit.com','(399) 204-0541','(866) 148-4103','1979-06-10','Ap #804-1154 Risus. Street','30794','Limoges','France','1877 Tincidunt. Rd.','49191','Drancy','France','dictum eu, placerat'),
('0D528AA8-6858-2B9E-1822-C1BD4F7E6ABF','Finley','Althea','2012-04-30','Stagiaire','2.2 110',30183,'turpis.vitae@quispede.ca','sollicitudin@arcu.co.uk','(120) 489-2408','(237) 603-2597','1983-01-31','9271 At Rd.','68815','Montbéliard','France','Ap #692-5956 Phasellus Avenue','14370','Talence','France','consequat purus.'),
('4733573D-56D9-D296-93F8-A1AB6F760BAF','Henry','Trevor','2017-06-21','Architecte','2.1 105',31060,'non.arcu.Vivamus@ipsumnon.ca','senectus.et@semconsequatnec.ca','(723) 841-6815','(149) 246-3339','1994-06-09','Ap #481-2951 Libero. Avenue','26981','Pontarlier','France','362 Ut Rd.','27098','Bourges','France','consequat, lectus sit amet luctus vulputate,'),
('83CE0D50-77A1-9478-2BBC-776959E79D7E','Castro','Maggie','2008-07-20','Architecte','1.1 95',28270,'ornare.In@lacusEtiam.ca','lorem.Donec@amet.co.uk','(937) 679-2161','(323) 997-3546','1984-09-03','551-8519 Luctus Av.','10856','Fréjus','France','1459 Erat. Rd.','70282','Chartres','France','gravida. Praesent eu nulla'),
('7AD47850-7B0C-0EF1-1509-ECBEFFDC166B','Butler','Allen','2009-10-07','Consultant','2.2 110',31010,'Proin.nisl.sem@necimperdietnec.co.uk','ipsum@sagittisaugue.ca','(623) 737-4482','(295) 369-8678','1997-05-01','6670 Mollis Ave','28101','Brive-la-Gaillarde','France','P.O. Box 128, 3287 Nulla Ave','82306','Le Puy-en-Velay','France','Donec'),
('07277829-2375-9A4E-F178-E0DB03A76889','Mcclain','Jacob','2019-10-16','Chef de projet','1.1 95',33059,'imperdiet.non@mi.edu','at.libero@tortornibh.edu','(884) 766-2914','(502) 943-3725','1997-11-14','P.O. Box 845, 3803 Eget Avenue','80814','Le Petit-Quevilly','France','Ap #204-6562 Amet Ave','98602','Quimper','France','volutpat. Nulla dignissim. Maecenas ornare egestas ligula. Nullam feugiat placerat'),
('A3E0AFEF-3BDE-BEFC-9F05-AD82A6661495','Snider','Malachi','2016-09-19','Stagiaire','1.1 95',29179,'metus.In@variuseteuismod.edu','lectus@enimgravida.com','(459) 276-2253','(450) 305-6163','1998-01-23','2044 Parturient Street','03114','Mâcon','France','162-5107 Auctor. Ave','01746','Montreuil','France','vel, faucibus'),
('087A6224-508F-0F60-9BA4-2E39094E34BD','Erickson','Ira','2009-04-23','Consultant','1.1 95',41071,'eget@ornareIn.com','mus.Donec.dignissim@luctusaliquetodio.net','(105) 668-7571','(752) 188-1196','1984-01-16','P.O. Box 348, 8150 Ultrices Rd.','98510','Brive-la-Gaillarde','France','959-6094 Habitant Avenue','30833','Bastia','France','at arcu.'),
('0743CFC5-14F8-43C9-6C9C-206ACA1EAAB4','Goodwin','Price','2019-09-17','Chef de projet','2.2 110',28808,'ac@mauris.net','in@consectetuercursus.net','(374) 960-2371','(423) 926-5418','1982-12-04','P.O. Box 487, 4708 Ornare Ave','49420','Bourges','France','7109 Nec Av.','50863','Arras','France','condimentum eget, volutpat ornare, facilisis'),
('852953E7-2AC1-331E-0F54-5E881596081E','Kirk','Hoyt','2009-11-24','Chef de projet','2.3 130',35891,'ac.libero@litoratorquentper.net','metus.In@gravida.co.uk','(653) 111-9775','(616) 186-1167','1979-12-12','Ap #180-4342 Velit. St.','81378','Châtellerault','France','P.O. Box 361, 6978 Et St.','62101','Dieppe','France','eros non enim commodo hendrerit. Donec'),
('A2A3CF28-EA4D-6474-70AC-8666A423ED24','Neal','Isabelle','2018-08-08','Testeur','2.2 110',32216,'massa.Vestibulum@venenatislacus.ca','suscipit.nonummy@ipsum.co.uk','(832) 602-9024','(364) 597-6099','1989-05-02','481-4962 Sit Avenue','97096','Illkirch-Graffenstaden','France','9200 Luctus. Street','99650','Mulhouse','France','nonummy ipsum non'),
('4DCBC262-F41F-DFCD-E6A1-3BEFF7C3B92F','Wells','Leilani','2014-06-15','Développeur','2.1 105',27169,'tristique.pellentesque.tellus@ProinmiAliquam.co.uk','orci@ProinultricesDuis.org','(557) 717-7932','(542) 785-2057','1994-12-11','Ap #955-7192 Auctor. Rd.','41841','Tours','France','2610 Faucibus St.','04099','Colomiers','France','a, magna. Lorem ipsum dolor sit amet, consectetuer adipiscing elit.'),
('999211CD-44F6-EB15-DEE8-0818DCE1224A','Riggs','Brett','2019-04-22','Stagiaire','2.3 130',28711,'scelerisque.sed.sapien@semeget.org','commodo@Suspendisse.org','(249) 539-8889','(808) 456-1549','1983-12-07','P.O. Box 884, 4603 Neque Avenue','74475','Saint-Louis','France','2335 Integer Road','38565','Châteauroux','France','eu tellus.'),
('FF62995B-B007-370C-4BB0-D9CFE83B9B9A','Kirby','Denise','2014-05-29','Testeur','2.3 130',34246,'purus.in@Pellentesquehabitant.net','tristique@ridiculusmus.net','(676) 514-3950','(123) 869-8384','1978-06-15','708-816 Lacinia St.','45999','Arles','France','8639 Magna. Road','78399','Douai','France','eget metus. In nec orci. Donec nibh. Quisque'),
('86553B93-40BC-628A-3DBD-ACEC865E2374','Hinton','Axel','2008-03-07','Consultant','1.1 95',34265,'lorem.auctor.quis@velitegestas.com','porttitor.eros@vitae.org','(770) 802-3951','(438) 501-8359','1985-05-26','8241 Nec, Rd.','60494','Brive-la-Gaillarde','France','3311 Litora Av.','58571','Ajaccio','France','dis parturient montes, nascetur ridiculus mus.'),
('69B3DDD0-521D-0DCB-654C-538C7F01546E','Flowers','Ross','2012-08-17','Développeur','1.1 95',33756,'quis.tristique.ac@tristiquepharetra.com','neque@Donec.edu','(575) 165-9895','(488) 917-0166','1999-03-08','P.O. Box 154, 2403 Ultrices Avenue','28289','Laon','France','455-1975 Tellus. Rd.','56103','La Seyne-sur-Mer','France','neque. Nullam ut nisi'),
('DF444B22-52DD-D028-35DD-BEE180C58D83','Wade','Francis','2009-06-13','Stagiaire','1.1 95',25807,'egestas.lacinia@nequenon.co.uk','vestibulum@a.co.uk','(539) 114-4132','(537) 605-4276','1998-12-03','265-6432 Morbi Street','78388','Lisieux','France','9887 Mauris Avenue','11890','Ajaccio','France','Duis sit amet diam eu dolor egestas rhoncus.'),
('4C6B2245-DD56-2B96-CC33-3BD8D21659B1','Baxter','Benjamin','2016-08-14','Chef de projet','2.1 105',28226,'lacinia.vitae@Cras.net','Donec.est@vitaesemper.com','(165) 761-0288','(101) 837-7674','1989-05-31','Ap #461-242 Lectus Ave','56978','Istres','France','9039 Id, Av.','63667','Laon','France','Vivamus molestie dapibus ligula.'),
('93F21AF1-8690-D932-C179-F6934E1075FF','Mays','Kessie','2011-11-20','Chef de projet','2.2 110',28565,'pede.ultrices.a@malesuada.net','vel@diamnunc.edu','(795) 118-4231','(628) 988-4728','1998-11-02','208-9041 Dictum St.','36795','Strasbourg','France','2558 Morbi Avenue','41409','Saintes','France','ridiculus mus. Proin vel arcu'),
('739C03DE-EBC4-4BCF-D2C6-FBBB3D9A4069','Blevins','Orli','2020-11-10','Chef de projet','2.3 130',25529,'ullamcorper.magna@nisiAeneaneget.com','lectus@ante.org','(423) 187-1932','(775) 659-3077','1990-09-23','Ap #126-9895 Quisque St.','61047','Illkirch-Graffenstaden','France','1371 Non Rd.','57533','Brive-la-Gaillarde','France','mi lorem, vehicula et, rutrum'),
('7704D1C6-4C1C-1B64-99FE-9572D760BFB0','Drake','Wayne','2016-03-11','Consultant','2.2 110',41185,'non.vestibulum.nec@Uttinciduntorci.com','neque.tellus@lectuspedeet.net','(793) 944-0324','(265) 325-8198','1997-08-21','P.O. Box 445, 1235 Justo Rd.','72371','Ajaccio','France','Ap #942-5237 Pharetra St.','39528','Bastia','France','augue eu tellus. Phasellus elit pede,'),
('F8C9E2CD-84F9-1E10-4A4F-E5D2414F3518','Shaw','Nelle','2010-04-06','Consultant','1.1 95',27938,'cursus.Integer.mollis@tincidunt.edu','tellus.Suspendisse.sed@Cum.net','(218) 980-6578','(473) 840-0285','1990-01-02','Ap #604-9022 Lorem Road','89888','Lisieux','France','Ap #114-9950 Lobortis Rd.','99301','Agen','France','lectus rutrum'),
('8E3E05DB-FADF-3328-FDC5-16A437B87445','Gilliam','Janna','2012-08-28','Stagiaire','1.1 95',40771,'Suspendisse@arcuetpede.edu','blandit.enim.consequat@facilisisSuspendisse.org','(441) 711-4827','(284) 400-9743','1977-07-09','P.O. Box 653, 4027 In Rd.','86951','Liévin','France','2360 Semper Road','04170','Clermont-Ferrand','France','orci. Ut sagittis lobortis mauris. Suspendisse aliquet molestie'),
('CA9C0B15-9D84-FB8B-0B70-76B78A81F757','Chaney','Cally','2011-10-07','Testeur','1.1 95',28192,'et.arcu.imperdiet@dolordolortempus.net','aliquet.sem.ut@ac.net','(716) 118-2095','(414) 285-3933','1999-07-07','389 Mauris Av.','41403','Mulhouse','France','P.O. Box 789, 975 Tincidunt St.','73486','Ajaccio','France','natoque penatibus et magnis dis parturient montes, nascetur'),
('3861AD4B-95AC-FBCA-BDEE-ED3DB456C6A3','Perkins','Breanna','2018-05-11','Testeur','2.2 110',37663,'lorem@sagittis.edu','Mauris.molestie@eget.ca','(353) 237-2666','(187) 468-9284','1977-12-16','Ap #169-3793 Adipiscing Road','87474','Saint-Louis','France','264-6610 Erat Ave','62436','Montreuil','France','gravida sit amet, dapibus id, blandit'),
('B935BA2D-38D6-6D0E-6592-DC2491C3FE7F','Luna','Abigail','2019-05-12','Testeur','2.3 130',37833,'ipsum.sodales@accumsanlaoreetipsum.co.uk','magna.Lorem@arcu.net','(547) 562-4172','(556) 730-6096','1989-04-13','P.O. Box 879, 5923 Iaculis Ave','56564','Bordeaux','France','740-914 Sociis St.','68337','Reims','France','luctus'),
('A94B755C-B640-B3C9-6B0A-34F7D90A0AB7','Gibbs','Teagan','2012-04-21','Testeur','1.1 95',28192,'Suspendisse.dui.Fusce@faucibusMorbi.ca','eget.massa.Suspendisse@sem.com','(620) 400-0152','(132) 532-9070','1994-11-14','215-7979 Quis St.','91576','Le Grand-Quevilly','France','Ap #673-8361 Eu St.','11495','Rezé','France','metus. In lorem. Donec elementum, lorem ut aliquam iaculis,'),
('B3726C53-6A86-4CFC-B6B1-5EC1C905501C','Todd','Germane','2009-01-12','Chef de projet','2.3 130',33831,'amet.metus@estacfacilisis.net','et@amet.co.uk','(351) 288-1891','(530) 379-5133','1983-07-23','845-8758 Augue St.','25380','Saint-Louis','France','P.O. Box 511, 3753 Dui Av.','85335','Nanterre','France','sollicitudin commodo ipsum. Suspendisse'),
('C182C417-8230-D23E-4BA6-91CBC117F7F2','Travis','Anthony','2010-04-03','Développeur','2.3 130',30316,'sem@massaVestibulum.co.uk','netus.et@non.edu','(246) 389-1506','(170) 310-0406','1984-08-28','8457 Tempor Street','03903','Tourcoing','France','1210 Proin Road','91238','Bastia','France','orci sem eget massa. Suspendisse eleifend. Cras'),
('F2E0841D-7A25-6646-E9FE-244B19B4D918','Underwood','Madeson','2012-02-16','Chef de projet','2.3 130',30319,'laoreet@facilisiseget.com','erat@Etiamlaoreet.net','(742) 577-6213','(230) 246-8194','1998-04-12','9197 Arcu. Street','57522','Auxerre','France','1658 Auctor St.','12890','Poitiers','France','ornare lectus justo eu'),
('F8F32180-5E8D-63EE-F4F3-7163EE18089D','Melton','Carl','2015-05-15','Chef de projet','1.1 95',29511,'parturient@nec.ca','quam@augue.com','(675) 418-8502','(624) 653-9170','1999-06-12','P.O. Box 190, 7533 Nunc Ave','07220','Épernay','France','805-1402 Aliquet. Road','56096','Alès','France','Nam consequat'),
('7B983915-B5E2-1A80-6E9D-2CF1DBD221B6','Mckenzie','Paula','2018-09-07','Chef de projet','1.1 95',31440,'eu@placeratCras.co.uk','bibendum@velitdui.com','(911) 301-7245','(104) 488-0291','1975-12-12','P.O. Box 682, 5776 Vitae St.','25826','Illkirch-Graffenstaden','France','P.O. Box 906, 6789 Tristique Rd.','25758','Vannes','France','cursus purus. Nullam scelerisque neque'),
('36E93A09-49A3-A935-79B2-EE13C42971A3','Padilla','Cheyenne','2010-12-05','Architecte','2.1 105',33341,'lacinia.at.iaculis@adipiscing.net','Donec.vitae.erat@odioAliquam.net','(521) 884-6486','(313) 691-3562','1989-07-28','Ap #654-740 Montes, Rd.','03516','Lisieux','France','888-1222 Proin Ave','08371','Drancy','France','orci. Donec nibh. Quisque'),
('D7549426-2923-2E28-B062-AA807515891E','Robertson','Kamal','2012-11-23','Chef de projet','2.3 130',26415,'Phasellus.dolor@vitaedolor.com','pede@elitfermentum.net','(505) 515-0902','(308) 966-1041','1977-03-22','350-3670 Sed Street','62221','Cholet','France','512-6882 Nec, Street','47695','Argenteuil','France','augue, eu'),
('D0FE6105-55CD-3404-DB42-22C261BFE87B','Larson','Piper','2020-11-16','Développeur','2.1 105',28511,'Donec.est.Nunc@sodales.ca','Ut@eleifend.net','(974) 751-3842','(922) 463-4617','1992-03-16','Ap #487-506 Donec Rd.','51495','Mont-de-Marsan','France','Ap #672-6627 Sed Road','28335','Châtellerault','France','augue ut lacus. Nulla'),
('5E792771-01F4-937E-2A80-2B080A3B9E82','Farmer','Vladimir','2021-10-04','Architecte','2.1 105',28862,'rhoncus.Nullam@neccursusa.com','mauris.rhoncus@necimperdietnec.com','(984) 269-5283','(228) 885-9590','1996-02-28','5452 Duis St.','35325','Albi','France','1662 Dictum Avenue','86417','Abbeville','France','montes, nascetur ridiculus mus. Donec'),
('E3E7527C-AA84-B4D3-CC9D-3B3E0E65E26A','Foley','Naomi','2015-10-26','Développeur','2.3 130',36335,'luctus.Curabitur@ametrisus.com','In@nonvestibulumnec.com','(554) 764-5675','(404) 306-9983','1978-10-16','Ap #106-4031 In Rd.','82015','Brest','France','Ap #977-2764 Non, Street','56853','Évreux','France','vel nisl. Quisque fringilla euismod enim. Etiam'),
('F4E62FE8-997F-06CD-19D3-A90A4F925647','Huffman','Hall','2012-04-10','Stagiaire','2.2 110',25828,'dolor@Sedet.edu','amet.consectetuer.adipiscing@litoratorquent.edu','(680) 179-0678','(474) 684-4178','1981-08-23','Ap #661-617 Curabitur Rd.','06414','Saumur','France','P.O. Box 682, 5046 Libero. Avenue','14352','Saint-Nazaire','France','consequat nec,'),
('0860DF2C-6C8E-26F3-504C-5D5FE956AE06','Wilson','Forrest','2014-09-04','Chef de projet','2.3 130',32188,'ante.dictum@natoquepenatibuset.ca','fringilla.purus.mauris@milaciniamattis.com','(197) 741-4397','(823) 378-9583','1985-11-01','P.O. Box 986, 2930 Tortor. Av.','32732','Bergerac','France','P.O. Box 317, 6494 Vel St.','64422','Épernay','France','Donec sollicitudin adipiscing ligula. Aenean gravida nunc sed pede.'),
('C78ADD32-BDA5-4E59-83F5-0BE5A5CDE82C','Singleton','Brenda','2011-06-15','Chef de projet','2.2 110',25286,'fringilla@ametmassaQuisque.co.uk','tristique@orci.net','(694) 908-9920','(969) 370-6812','1991-01-31','3637 Nunc Ave','16203','Argenteuil','France','663-3304 Mauris. Street','61891','Tours','France','tincidunt aliquam'),
('67B7336F-6A1B-FE69-1D9D-D447AF995CBB','William','Hannah','2014-05-07','Consultant','2.3 130',37176,'fames@doloregestas.com','scelerisque.dui.Suspendisse@id.edu','(445) 820-2688','(537) 101-4365','1981-09-28','404-8160 Nunc Ave','53511','Saint-Maur-des-Fossés','France','2439 Magna. Rd.','53985','Forbach','France','feugiat non, lobortis quis, pede. Suspendisse dui.'),
('DB04CA9D-BFB3-9F8E-2D52-34C15EA6E94F','Delaney','Quinn','2015-09-25','Testeur','2.3 130',31935,'hendrerit@gravidasagittis.com','amet.ornare.lectus@augueporttitorinterdum.org','(835) 213-8350','(851) 265-2149','1990-02-01','P.O. Box 212, 4988 Pede, St.','15293','Rennes','France','835-633 Sit St.','41278','Nancy','France','Proin eget odio. Aliquam vulputate ullamcorper magna. Sed eu'),
('2C2BDD76-6E46-B9D7-0941-C1A98B81C1AC','Cotton','Ocean','2008-06-22','Consultant','2.3 130',40738,'risus.Donec@lobortisquispede.org','sociis@ullamcorperviverraMaecenas.ca','(935) 368-3683','(580) 786-0789','1990-03-10','888-3488 Fringilla Rd.','05331','Nancy','France','589-7144 Nibh St.','62976','Auxerre','France','pede, ultrices a, auctor non, feugiat'),
('908A709B-6BDA-E154-039E-6AA29CA7E526','Flores','Leigh','2011-09-20','Chef de projet','2.1 105',30289,'non.sollicitudin.a@laciniaat.com','sem@lobortis.com','(723) 227-4370','(543) 915-0346','1980-12-20','8765 Et St.','84002','Angoulême','France','P.O. Box 158, 8363 A St.','48869','Le Havre','France','tristique aliquet. Phasellus fermentum convallis ligula. Donec luctus aliquet odio.'),
('6B8719B7-7B4E-637B-92B8-FAB59ADAE12E','Fry','Mariam','2017-01-05','Développeur','2.3 130',41842,'velit.eget@auctorvitae.com','Donec.nibh@lobortisrisus.com','(560) 471-0787','(996) 858-2058','1981-09-30','7641 Neque Road','26264','Aubervilliers','France','P.O. Box 401, 1989 Mollis Street','61295','Dole','France','eu turpis. Nulla aliquet.'),
('9410D892-6D23-B230-E85E-4DCC32D7B6CA','Pickett','Wesley','2021-05-09','Testeur','1.1 95',37265,'lorem.fringilla@magnaaneque.com','eu@idliberoDonec.org','(564) 694-0949','(202) 913-5115','1989-02-27','9839 Velit Avenue','25076','Colmar','France','6532 Sollicitudin St.','70528','Besançon','France','ullamcorper eu, euismod ac, fermentum vel, mauris. Integer sem'),
('6E390CF2-08C2-E900-6C94-27F8559ABF62','Gray','Fitzgerald','2009-01-08','Chef de projet','1.1 95',35929,'volutpat@purusDuiselementum.com','Cras.eget@dui.com','(183) 454-3907','(849) 506-8234','1993-12-24','765-6400 Ipsum. St.','61777','Biarritz','France','P.O. Box 774, 634 Elit, Ave','52390','Grasse','France','vel, faucibus id, libero. Donec consectetuer'),
('0164870E-246A-05FC-8286-393B104F1858','Frederick','Neve','2019-08-21','Testeur','2.1 105',38584,'libero@Etiamimperdietdictum.edu','quis.turpis@viverra.edu','(342) 658-4819','(141) 962-8972','1994-05-11','P.O. Box 416, 9084 Erat, Rd.','60369','Paris','France','7976 Ullamcorper Street','37021','Saintes','France','id,'),
('C93343D5-9E34-1257-3ED3-9BA9BAF1B824','Santos','Stuart','2015-06-29','Architecte','2.3 130',41402,'nec.euismod@nonenim.edu','tortor@etmalesuada.co.uk','(481) 676-1241','(133) 363-4122','1992-06-06','P.O. Box 144, 6621 Id Rd.','33332','Bourges','France','163-7348 Hendrerit St.','46858','Colomiers','France','varius. Nam porttitor scelerisque neque. Nullam nisl. Maecenas'),
('18F50A02-EDA3-E73C-C44D-7D92B9A1EE88','Grant','Felix','2012-07-07','Testeur','2.3 130',32288,'vel@nuncsit.org','sed.pede@quispedeSuspendisse.co.uk','(240) 136-5068','(861) 524-5527','1984-09-14','Ap #576-3826 Integer Street','42448','Reims','France','P.O. Box 367, 5749 Blandit. St.','73491','Châtellerault','France','massa lobortis ultrices. Vivamus'),
('1DF92DB5-852D-A884-6BDD-17FCBC6F86AD','Gay','Ingrid','2008-06-27','Chef de projet','2.1 105',37458,'ligula@dolorsit.edu','sagittis.lobortis@Integervulputaterisus.org','(336) 536-7657','(884) 198-9221','1977-08-15','Ap #417-2886 Dolor. Road','57467','Pontarlier','France','454-7620 Justo Rd.','03736','Limoges','France','enim commodo hendrerit. Donec porttitor tellus non magna. Nam'),
('889C4436-D32E-7D15-14FF-651556086645','Rojas','Casey','2018-11-14','Architecte','2.3 130',33925,'volutpat.ornare@euismodest.co.uk','est@intempus.net','(911) 870-0021','(626) 193-7611','1976-08-25','P.O. Box 179, 6308 Elit Rd.','12682','Châlons-en-Champagne','France','3612 Curae; St.','68688','Saint-Médard-en-Jalles','France','posuere cubilia'),
('C463B314-937B-15FD-ADCA-1A4BF8C784DD','Carpenter','Mark','2020-10-10','Stagiaire','1.1 95',33930,'interdum.Nunc.sollicitudin@magna.edu','turpis.vitae.purus@odioNam.ca','(438) 378-1538','(895) 254-9659','1993-11-18','783-2698 Sollicitudin Av.','95419','Auxerre','France','1341 A, Rd.','78856','Colomiers','France','Vestibulum'),
('0676D908-8CFB-5087-B4F3-96474607D1F7','Montgomery','Hamilton','2011-07-23','Testeur','2.2 110',31910,'libero@egestasadui.net','Suspendisse@massa.ca','(139) 450-0771','(309) 658-6853','1986-01-27','2954 Posuere Road','31725','Carcassonne','France','Ap #766-571 Montes, Rd.','37548','Le Havre','France','odio a purus. Duis elementum,'),
('ECC91108-2B09-4060-7825-F4C5A0901E4C','Carver','Ashely','2009-10-17','Testeur','2.3 130',26430,'mi.enim.condimentum@auctorMauris.com','vitae.erat@Phasellusdapibusquam.org','(860) 309-2184','(158) 868-4582','1982-05-26','7590 Fringilla St.','03639','Rennes','France','Ap #709-7788 Eleifend Road','94186','Limoges','France','mauris blandit mattis. Cras'),
('0FB27741-0E47-D876-5E32-A75E4C827DB6','Barber','Hakeem','2017-12-22','Chef de projet','1.1 95',39222,'at.velit@metuseuerat.ca','aliquet.odio@fringilla.com','(491) 507-0962','(477) 734-7392','1995-12-10','Ap #309-2166 Sociosqu Ave','62748','Dijon','France','714-5805 Non, Rd.','10555','Albi','France','Pellentesque habitant'),
('DC2CF642-8592-5D94-C791-31AB4EB4FD61','Everett','Ava','2020-08-22','Testeur','2.1 105',31945,'vel.arcu.Curabitur@volutpatornare.org','orci.Ut@odioAliquamvulputate.com','(202) 350-3758','(799) 446-3558','1978-08-30','P.O. Box 525, 3507 Euismod Rd.','45948','Quimper','France','963 Id, Avenue','85980','Mâcon','France','enim.'),
('8D558C77-1A7F-B1B8-BF7D-ED22132BFA6F','Compton','Chase','2011-10-10','Développeur','2.2 110',26584,'nisl.Maecenas.malesuada@aliquet.com','viverra@dictummiac.net','(346) 830-8300','(937) 224-7381','1995-05-16','117-5926 Mauris Ave','36462','Saint-Dizier','France','4628 Per Road','85566','Vandoeuvre-lès-Nancy','France','magna. Phasellus dolor elit, pellentesque a, facilisis non, bibendum sed,'),
('A7034381-14FB-708B-61B9-48EADD5E7248','Drake','Colin','2016-06-05','Chef de projet','2.2 110',35124,'tempus.scelerisque@arcu.com','magna.sed@vitaevelitegestas.com','(761) 338-8179','(253) 192-9347','1990-09-09','P.O. Box 493, 8995 Dictum Avenue','69402','Besançon','France','2798 Nam Road','23641','Toulouse','France','rutrum. Fusce dolor'),
('84B80952-F84E-0361-0650-68F9EE05F00F','Bray','Frances','2019-12-18','Architecte','2.2 110',36643,'sociis@ipsumnon.com','cursus.non@Utsagittislobortis.org','(477) 397-6648','(950) 289-4226','1981-01-01','339-1333 Suspendisse Ave','08800','Rodez','France','2081 Odio Ave','73356','La Rochelle','France','ipsum non arcu.'),
('16BAAD1A-ED22-16E6-170A-7496119F5C07','Haney','Philip','2017-03-12','Consultant','2.2 110',26106,'sem@convallis.ca','Nullam@felis.org','(863) 882-4838','(850) 966-3016','1994-06-06','444 Lorem, St.','39393','Bourges','France','P.O. Box 373, 5138 Velit St.','08235','Vandoeuvre-lès-Nancy','France','enim mi tempor lorem, eget mollis'),
('4841F402-63E6-B26B-F102-DDD5C8BCB74D','Garrison','Kane','2020-01-11','Développeur','2.1 105',30256,'ultrices.posuere.cubilia@variusultricesmauris.org','Nulla@posuerevulputate.co.uk','(138) 830-6047','(552) 435-3286','1984-10-13','329 In Street','49120','Périgueux','France','Ap #598-9560 Felis. St.','73845','Dijon','France','nec urna et arcu imperdiet'),
('33C998B7-B66C-5D10-A931-94AB57682CF2','Berger','Vaughan','2015-05-30','Architecte','2.3 130',40054,'tempus@placerataugueSed.edu','quam.Curabitur.vel@orciadipiscingnon.org','(548) 503-5658','(783) 527-9353','1980-11-01','Ap #763-7065 Orci, Avenue','10581','Brive-la-Gaillarde','France','P.O. Box 634, 5256 Ultricies St.','90652','Lille','France','dolor vitae'),
('E458EE55-3E94-74F2-0676-C2C0D5E80F95','Goodman','Fleur','2019-02-24','Consultant','1.1 95',41623,'elit@eleifendegestas.net','accumsan@sedorcilobortis.net','(472) 718-2269','(981) 238-4331','1983-05-19','719-8718 Mauris Avenue','40307','Montigny-lès-Metz','France','P.O. Box 250, 3976 Gravida. Avenue','45882','Brest','France','libero. Proin mi. Aliquam gravida mauris ut mi.'),
('7BEBE7C8-BF78-CFF3-9EC1-EA64A7C60E57','Foreman','Yoshi','2021-10-06','Testeur','1.1 95',39859,'sit@liberomaurisaliquam.com','Donec@felis.edu','(296) 979-2631','(449) 174-4656','1980-03-17','981-5318 Tincidunt Ave','85089','Haguenau','France','P.O. Box 291, 3139 Egestas. Road','85718','Argenteuil','France','ullamcorper magna. Sed eu eros. Nam'),
('2A08CED7-E8EF-825F-DE0C-48082CC27C5E','Huff','Ezra','2017-05-06','Testeur','1.1 95',30500,'cursus.purus@purus.net','sagittis.lobortis@felispurusac.com','(485) 911-2993','(882) 692-6856','1987-03-24','Ap #443-4208 Nisl Ave','39595','Vitrolles','France','909-4547 Sem Avenue','88168','Niort','France','fames ac turpis egestas. Aliquam fringilla cursus purus. Nullam'),
('04B1FC3C-7A49-600F-3E5C-3EAF97A776B7','Bond','Ainsley','2009-10-16','Consultant','1.1 95',33718,'tincidunt.neque.vitae@hendrerita.com','Ut.tincidunt.vehicula@Aeneanegetmagna.com','(383) 734-5302','(663) 527-3521','1996-04-05','9588 Vestibulum. St.','73714','Alençon','France','Ap #782-8544 Ultrices. Street','15132','Vernon','France','aliquam'),
('5B725F8B-0DD8-34EC-60B1-372922D078C0','Colon','Harding','2011-11-08','Testeur','1.1 95',39801,'arcu.imperdiet.ullamcorper@quam.ca','sed.hendrerit.a@loremloremluctus.edu','(944) 547-0650','(440) 921-8253','1997-02-10','Ap #463-1448 Feugiat Rd.','66150','Joué-lès-Tours','France','P.O. Box 121, 5980 Proin Avenue','07115','Saint-Médard-en-Jalles','France','Curae; Phasellus ornare. Fusce mollis. Duis'),
('DEDA07B2-999E-2E52-AECC-6B1FCC1AD600','Bryan','Oscar','2016-09-12','Testeur','2.1 105',25168,'Maecenas.libero@porttitortellusnon.ca','In@Donec.net','(978) 196-8120','(362) 142-7765','1997-04-14','Ap #109-6480 Duis St.','03608','Bastia','France','265 Id, Rd.','86050','Saint-Maur-des-Fossés','France','risus quis diam luctus'),
('6D913B32-E211-70AA-57AA-4DC12E777EDD','Williamson','Adam','2014-07-05','Architecte','2.2 110',40620,'tincidunt@inaliquetlobortis.ca','ligula.consectetuer@Vestibulumut.net','(157) 304-3907','(578) 940-9885','1981-07-24','Ap #806-2018 Quis, St.','98015','Saint-Sébastien-sur-Loire','France','P.O. Box 380, 1065 Malesuada. St.','21291','Orvault','France','Duis'),
('11E65B3F-6440-E3E8-D7E7-038552429084','Combs','Phoebe','2015-06-17','Architecte','1.1 95',27597,'Integer@cursusa.net','varius.orci.in@augueeu.ca','(400) 480-5271','(903) 907-0133','1980-11-16','103-5209 Ornare Street','28506','Orvault','France','971-4763 Donec St.','10794','Montluçon','France','montes, nascetur ridiculus mus. Aenean eget magna. Suspendisse');
END