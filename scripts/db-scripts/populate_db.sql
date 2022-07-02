DELETE FROM TBUserWishlistItems WHERE IdWishlistItem > 0;
DELETE FROM TBUserStatistics WHERE IdUserStatistics > 0;
DELETE FROM TBUserAddresses WHERE IdUserAddress > 0;
DELETE FROM TBUserAuthorPreferences WHERE IdAuthorPreference > 0;
DELETE FROM TBUserCategoryPreferences WHERE IdCategoryPreference > 0;
DELETE FROM TBPostingImages WHERE IdPostingImage > 0;
DELETE FROM TBPostings WHERE IdPosting > 0;
DELETE FROM TBUsers WHERE IdUser > 0;
DELETE FROM TBBookCategories WHERE IdBookCategory > 0;
DELETE FROM TBBooks WHERE IdBook > 0;
DELETE FROM TBAuthors WHERE IdAuthor > 0;
DELETE FROM TBCategories WHERE IdCategory > 0;


INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('Liviu Rebreanu');
INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('George Calinescu');
INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('Camil Petrescu');
INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('Robert Kiyosaki');
INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('J. K. Rowling');
INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('Agatha Christie');
INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('George R. R. Martin');
INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('James Clear');
INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('Sun Tzu');
INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('Ioan Slavici');
INSERT INTO `TBAuthors` (`AuthorName`) VALUES ('Mircea Eliade');

INSERT INTO `TBCategories` (`CategoryName`) VALUES ('Beletristică');
INSERT INTO `TBCategories` (`CategoryName`) VALUES ('Dezvoltare personală');
INSERT INTO `TBCategories` (`CategoryName`) VALUES ('Fantastic');
INSERT INTO `TBCategories` (`CategoryName`) VALUES ('Acțiune');
INSERT INTO `TBCategories` (`CategoryName`) VALUES ('Istoric');

INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('1', 'Ion'); -- 13
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('2', 'Enigma Otiliei'); -- 5
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('3', 'Ultima noapte de dragoste, întâia noapte de război'); -- 9
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('4', 'Tată bogat, tată sărac'); -- 12
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('4', 'Cadranul banilor'); -- 1
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('5', 'Harry Potter și piatra filosofală'); -- 11
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('6', 'Moarte pe Nil'); -- 3
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('7', 'Foc și sânge'); -- 4
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('8', 'Atomic Habits'); -- 10
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('9', 'Arta războiului'); -- 2
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('10', 'Mara'); -- 8
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('11', 'Maitreyi'); -- 6
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('7', 'Încleștarea regilor'); -- 14
INSERT INTO `TBBooks` (`IdAuthor`, `BookTitle`) VALUES ('6', 'Primele cazuri ale lui Poirot'); -- 7

INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('1', '1');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('1', '2');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('1', '3');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('2', '4');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('2', '5');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('3', '6');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('1', '7');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('3', '8');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('2', '9');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('5', '10');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('1', '11');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('1', '12');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('4', '13');
INSERT INTO `TBBookCategories` (`IdCategory`, `IdBook`) VALUES ('1', '14');

INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '5', '0', 'Ati observat ca multi dintre cei mai sclipitori absolventi ai universitatilor isi doresc sa lucreze pentru cei care nu si-au terminat studiile... oameni precum Bill Gates, Richard Branson, Michael Dell si Ted Turner? Acesti oameni fara studii superioare sunt astazi ultra-bogatii lumii.', '10', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '10', '0', 'Noua editie din Arta razboiului contine un amplu dosar de receptare a acestei carti fundamentale pentru gandirea strategica, volum utilizat frecvent in afaceri, in managementul crizelor, in trainingul leaderilor, in politica si in teoriile jocului.', '7', now(), now()); 
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '7', '0', 'Linnet Ridgeway a dus pana acum o viata ca-n povesti. Binecuvantata cu frumusete, avere enorma si un sot devotat, are tot ce ti-ai putea dori.Dar, atunci cand proaspatul cuplu pleaca intr-o croaziera pe Nil, nori de furtuna incep sa se adune.', '15', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '8', '0', 'Cu sute de ani inainte de Urzeala Tronurilor, Casa Targaryen – singura familie de stapani ai dragonilor care supravietuieste decaderii Valyriei, se stabileste la Piatra Dragonului.', '20', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '2', '0', '\"In literatura romana, \'Enigma Otiliei\' trece, astfel, drept cel mai notabil roman balzacian - atat ca influenta, cat si ca referinta (referenta).', '17', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '12', '0', '\"Maitreyi este un roman viu, substantial, cu o deschidere noua spre problematica omului modern (un spirit, intre altele, voiajor, confruntat in experientele lui existentiale cu mentalitati inradacinate in ceea ce antropologii numesc cultura de profunzime).', '5', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '14', '0', 'Hercule Poirot, omuletul cu mustata rasucita si cu capul in forma de ou care se considera \"cel mai faimos detectiv\", isi face, in aceste povestiri, o intrare glorioasa, rezolvand, in stilul sau caracteristic, unele dintre cele mai dificile cazuri din cariera lui.', '22', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '11', '0', 'Mara este un roman social scris de Ioan Slavici și publicat pentru prima oară sub formă de foileton în perioada ianuarie-decembrie 1894 în revista bucureșteană Vatra.', '13', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '3', '0', 'Ultima noapte de dragoste, întâia noapte de război este un roman scris de Camil Petrescu și publicat în 1930.', '10', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '9', '0', 'O cale ușoară și eficientă de a-ți forma obiceiuri bune și a scăpa de cele proasteSchimbări mici, rezultate remarcabile', '18', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '6', '0', '\"Hogwarts va fi mereu aici sa-ti ureze bun-venit.\"-J.K. Rowling', '24', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '4', '0', 'Susține importanța alfabetizării financiare, a independenței financiare și a dezvoltării bogăției prin investiții în active, investiții imobiliare, pornirea și deținerea de afaceri, precum și creșterea inteligenței financiare.', '15', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '1', '0', 'Ion este un roman social scris de Liviu Rebreanu și apărut în anul 1920.', '13', now(), now());
INSERT INTO `TBPostings` (`IdOwnerUser`, `IdBook`, `PostingStatus`, `PostingDescription`, `Price`, `CreatedAt`, `UpdatedAt`) VALUES ('1', '13', '0', 'Încleștarea regilor este al doilea roman din seria Cântec de gheață și foc, o epopee fantasy scrisă de autorul american George R. R. Martin.', '30', now(), now());

INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('13', 'https://i.imgur.com/nWMBXRh.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('5', 'https://i.imgur.com/oR0mMeh.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('9', 'https://i.imgur.com/iw9Garc.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('12', 'https://i.imgur.com/bh1g3vw.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('1', 'https://i.imgur.com/VnqFZZR.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('11', 'https://i.imgur.com/X3S10el.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('3', 'https://i.imgur.com/CNwFx4A.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('4', 'https://i.imgur.com/cGcP4dm.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('10', 'https://i.imgur.com/wulkHZO.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('2', 'https://i.imgur.com/EfAMUOn.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('8', 'https://i.imgur.com/kWj9x5I.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('6', 'https://i.imgur.com/i2WDSv1.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('14', 'https://i.imgur.com/ExvA8PS.jpeg');
INSERT INTO `TBPostingImages` (`IdPosting`, `ImgSrc`) VALUES ('7', 'https://i.imgur.com/aQELbTC.png');
