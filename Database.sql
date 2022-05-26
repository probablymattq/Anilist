CREATE DATABASE AnilistCSharp;
USE AnilistCSharp;


CREATE TABLE LOGINDATA(
email varchar(50) not null primary key,
username varchar(30) not null,
pass varchar(30) not null);


CREATE TABLE CURRENTSESSION(
email varchar(50) not null primary key, 
username varchar(30) not null);

CREATE TABLE STUDIO
(idstudio INT NOT NULL PRIMARY KEY,
numestudio VARCHAR(30) NOT NULL,);


CREATE TABLE GEN
(idgen INT NOT NULL PRIMARY KEY,
numegen VARCHAR(30) NOT NULL,);


CREATE TABLE SEZON
(idsezon INT NOT NULL PRIMARY KEY,
numesezon VARCHAR(6) NOT NULL);


CREATE TABLE ANIMEDATA
(idanime INT NOT NULL PRIMARY KEY,
numeanime VARCHAR(50) NOT NULL,
nrepisoade INT,
status CHAR(16) NOT NULL,
dataaparitie DATE,
idstudio INT NOT NULL,
idgen INT NOT NULL, 
idsezon INT,
animeimage varchar(300),
CHECK (idsezon >= 1 AND idsezon <=4),
CHECK (nrepisoade >= 0));
ALTER TABLE ANIMEDATA ADD FOREIGN KEY (idstudio) REFERENCES STUDIO(idstudio);
ALTER TABLE ANIMEDATA ADD FOREIGN KEY (idgen) REFERENCES GEN(idgen);
ALTER TABLE ANIMEDATA ADD FOREIGN KEY (idsezon) REFERENCES SEZON(idsezon);


CREATE TABLE ANIMEDATAPERSONAL
(idanime INT NOT NULL,
email_user VARCHAR(50) NOT NULL,
numeanime VARCHAR(50) NOT NULL,
nrepisoade INT,
status CHAR(16) NOT NULL,
dataaparitie DATE,
idstudio INT NOT NULL,
idgen INT NOT NULL, 
idsezon INT,
animeimage varchar(300),
CHECK (idsezon >= 1 AND idsezon <=4),
CHECK (nrepisoade >= 0));
ALTER TABLE ANIMEDATAPERSONAL ADD FOREIGN KEY (idstudio) REFERENCES STUDIO(idstudio);
ALTER TABLE ANIMEDATAPERSONAL ADD FOREIGN KEY (idgen) REFERENCES GEN(idgen);
ALTER TABLE ANIMEDATAPERSONAL ADD FOREIGN KEY (idsezon) REFERENCES SEZON(idsezon);


INSERT INTO STUDIO (idstudio, numestudio)
VALUES
(1, 'Ufotable'),
(2, 'A-1 Pictures'),
(3, 'Studio Pierrot'),
(4, 'P.A. Works'),
(5, 'Science SARU'),
(6, 'MAPPA'),
(7, 'White Fox'),
(8, 'Studio Bind'),
(9, 'SILVER LINK.'),
(10, 'LIFENFILMS'),
(11, 'MADHOUSE'),
(12, 'feel.'),
(13, 'Kyoto Animation'),
(14, 'Production I.G'),
(15, 'J.C. Staff');

INSERT INTO GEN (idgen, numegen) 
VALUES
(1, 'Shounen'),
(2, 'Battle Royale'),
(3, 'Demons'),
(4, 'Super Power'),
(5, 'Age Regression'),
(6, 'Afterlife'),
(7, 'Assassins'),
(8, 'Isekai'),
(9, 'Drama'),
(10, 'Gangs'),
(11, 'War'),
(12, 'Sports'),
(13, 'Anti-Hero');

INSERT INTO SEZON (idsezon, numesezon)
VALUES
(1, 'Spring'),
(2, 'Summer'),
(3, 'Fall'),
(4, 'Winter');

INSERT INTO ANIMEDATA (idanime, numeanime, nrepisoade, status, dataaparitie, idstudio, idgen, idsezon, animeimage)
VALUES 
(1, 'Sousei no Onmyouji', 50, 'Finished', '2016-04-06', 3, 1, 1, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx21499-JCxvIXc27mVT.jpg'),
(2, 'Fate/stay night: Unlimited Blade Works', 13, 'Finished', '2014-10-04', 1, 2, 3, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/nx19603-pc0lrFinBpTg.jpg'),
(3, 'DEVILMAN crybaby', 10, 'Finished', '2018-01-05', 5, 3, 4, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/nx98460-WTidxsFZrHfv.jpg'),
(4, 'Jahy-sama wa Kujikenai!', 20, 'Finished', '2021-08-01', 9, 8, 2, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx132456-wxTCgdXnZMMQ.jpg'),
(5, 'Mushoku Tensei', 11, 'Finished', '2021-01-11', 8, 8, 4, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx108465-B9S9zC68eS5j.jpg'),
(6, 'Akame ga Kill', 24, 'Finished', '2014-07-07', 7, 7, 2, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx20613-4VGGPacciJBL.jpg'),
(7, 'Dororo', 24, 'Finished', '2019-01-07', 6, 3, 4, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/nx101347-2J2p8qJpxpfZ.jpg'),
(8, 'Charlotte', 13, 'Finished', '2015-07-05', 4, 4, 2, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/nx20997-FGhaAtfnXCsH.jpg'),
(9, 'Erased', 12, 'Finished', '2016-01-08', 2, 5, 4, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/nx21234-v2NMgPyoVRoM.jpg'),
(10, 'Angel Beats!', 13, 'Finished', '2016-06-03', 4, 6, 1, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx6547-3jWzWyXg34Et.png'),
(11, 'Koi to Uso', 12, 'Finished', '2018-07-04', 10, 9, 2, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx98320-VwCcTBeEs08J.jpg'),
(12, 'Heion Sedai no Idatentachi', 11, 'Finished', '2021-07-23', 6, 3, 2, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx122434-HmMGLaGk2v4j.jpg'),
(13, 'Tokyo Revengers', 24, 'Finished', '2021-04-11', 10, 10, 1, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx120120-mBmQUtMloszF.jpg'),
(14, 'No Game No Life Zero', 1, 'Finished', '2017-06-15', 10, 11, 2, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/nx21875-ybSgx75MgRMM.png'),
(15, 'One Punch Man', 12, 'Finished', '2015-10-05', 11, 4, 3, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx21087-UV2tu6exrfXz.jpg'),
(16, 'Tsuki ga Kirei', 12, 'Finished', '2017-04-07', 12, 9, 1, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx98202-H6RtsIMZPALF.png'),
(17, 'Violet Evergarden', 13, 'Finished', '2018-01-11', 13, 9, 4, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/nx21827-10F6m50H4GJK.png'),
(18, 'BTOOOM!', 12, 'Finished', '2012-10-04', 11, 2, 3, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx14345-JGV1lFS9XW9w.jpg'),
(19, 'Haikyuu!!', 25, 'Finished', '2014-04-06', 14, 12, 1, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx20464-eW7ZDBOcn74a.png'),
(20, 'Satsuriku no Tenshi', 12, 'Finished', '2018-07-06', 15, 13, 2, 'https://s4.anilist.co/file/anilistcdn/media/anime/cover/large/bx99629-BXyAJ6PDq4sr.jpg');
