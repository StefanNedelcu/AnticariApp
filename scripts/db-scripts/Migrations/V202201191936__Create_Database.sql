CREATE TABLE `TBUsers` (
  `IdUser` BIGINT NOT NULL AUTO_INCREMENT,
  `Email` VARCHAR(45) NOT NULL,
  `Password` VARCHAR(255) NOT NULL,
  `FirstName` VARCHAR(45) NOT NULL,
  `LastName` VARCHAR(45) NOT NULL,
  `UserRole` INT NOT NULL,
  `CreatedAt` DATETIME NOT NULL,
  PRIMARY KEY (`IdUser`),
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE);

CREATE TABLE `TBUserStatistics` (
  `IdUserStatistics` BIGINT NOT NULL AUTO_INCREMENT,
  `IdUser` BIGINT NOT NULL,
  `UserAvgRating` DECIMAL(2,2) NOT NULL DEFAULT 0,
  `SoldItems` INT NOT NULL DEFAULT 0,
  `ReadBooks` INT NOT NULL DEFAULT 0,
  `UpdatedAt` DATETIME NOT NULL,
  PRIMARY KEY (`IdUserStatistics`));

CREATE TABLE `TBUserAddresses` (
  `IdUserAddress` BIGINT NOT NULL AUTO_INCREMENT,
  `IdUser` BIGINT NOT NULL,
  `IdCity` BIGINT NOT NULL,
  `StreetName` VARCHAR(45) NOT NULL,
  `StreetNumber` INT NULL,
  `ZipCode` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdUserAddress`));

CREATE TABLE `TBCities` (
  `IdCity` BIGINT NOT NULL AUTO_INCREMENT,
  `IdCountry` BIGINT NOT NULL,
  `CityName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdCity`));

CREATE TABLE `TBCountries` (
  `IdCountry` BIGINT NOT NULL AUTO_INCREMENT,
  `CountryName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`IdCountry`));

CREATE TABLE `TBUserAuthorPreferences` (
  `IdAuthorPreference` BIGINT NOT NULL AUTO_INCREMENT,
  `IdUser` BIGINT NOT NULL,
  `IdAuthor` BIGINT NOT NULL,
  PRIMARY KEY (`IdAuthorPreference`));

CREATE TABLE `TBUserCategoryPreferences` (
  `IdCategoryPreference` BIGINT NOT NULL AUTO_INCREMENT,
  `IdUser` BIGINT NOT NULL,
  `IdCategory` BIGINT NOT NULL,
  PRIMARY KEY (`IdCategoryPreference`));

CREATE TABLE `TBAuthors` (
  `IdAuthor` BIGINT NOT NULL AUTO_INCREMENT,
  `AuthorName` VARCHAR(45) NOT NULL,
  `AuthorDescription` VARCHAR(1000) NULL,
  PRIMARY KEY (`IdAuthor`));

CREATE TABLE `TBCategories` (
  `IdCategory` BIGINT NOT NULL AUTO_INCREMENT,
  `CategoryName` VARCHAR(45) NOT NULL,
  `CategoryDescription` VARCHAR(1000) NULL,
  PRIMARY KEY (`IdCategory`));

CREATE TABLE `TBBooks` (
  `IdBook` BIGINT NOT NULL AUTO_INCREMENT,
  `IdAuthor` BIGINT NOT NULL,
  `BookTitle` VARCHAR(45) NOT NULL,
  `BookDescription` VARCHAR(1000) NULL,
  PRIMARY KEY (`IdBook`));

CREATE TABLE `TBBookCategories` (
  `IdBookCategory` BIGINT NOT NULL AUTO_INCREMENT,
  `IdCategory` BIGINT NOT NULL,
  `IdBook` BIGINT NOT NULL,
  PRIMARY KEY (`IdBookCategory`));

CREATE TABLE `TBPostings` (
  `IdPosting` BIGINT NOT NULL AUTO_INCREMENT,
  `IdOwnerUser` BIGINT NOT NULL,
  `IdBook` BIGINT NOT NULL,
  `PostingStatus` INT NOT NULL,
  `PostingDescription` VARCHAR(1000) NULL,
  `Price` DECIMAL(10,2) NULL,
  `CreatedAt` DATETIME NOT NULL,
  `UpdatedAt` DATETIME NOT NULL,
  PRIMARY KEY (`IdPosting`));

CREATE TABLE `TBExchangeOffers` (
  `IdExchangeOffer` BIGINT NOT NULL AUTO_INCREMENT,
  `IdPosting` BIGINT NOT NULL,
  `IdAuthor` BIGINT NULL,
  `IdCategory` BIGINT NULL,
  `IdBook` BIGINT NULL,
  PRIMARY KEY (`IdExchangeOffer`));

CREATE TABLE `TBPostingImages` (
  `IdPostingImage` BIGINT NOT NULL AUTO_INCREMENT,
  `IdPosting` BIGINT NOT NULL,
  `ImgSrc` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`IdPostingImage`));

ALTER TABLE `TBBookCategories` 
ADD INDEX `BookCategory_to_Category_FK_idx` (`IdCategory` ASC) VISIBLE,
ADD INDEX `BookCategory_to_Book_FK_idx` (`IdBook` ASC) VISIBLE;
;
ALTER TABLE `TBBookCategories` 
ADD CONSTRAINT `BookCategory_to_Category_FK`
  FOREIGN KEY (`IdCategory`)
  REFERENCES `TBCategories` (`IdCategory`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `BookCategory_to_Book_FK`
  FOREIGN KEY (`IdBook`)
  REFERENCES `TBBooks` (`IdBook`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `TBBooks` 
ADD INDEX `Book_to_Author_FK_idx` (`IdAuthor` ASC) VISIBLE;
;
ALTER TABLE `TBBooks` 
ADD CONSTRAINT `Book_to_Author_FK`
  FOREIGN KEY (`IdAuthor`)
  REFERENCES `TBAuthors` (`IdAuthor`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `TBCities` 
ADD INDEX `City_to_Country_FK_idx` (`IdCountry` ASC) VISIBLE;
;
ALTER TABLE `TBCities` 
ADD CONSTRAINT `City_to_Country_FK`
  FOREIGN KEY (`IdCountry`)
  REFERENCES `TBCountries` (`IdCountry`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `TBExchangeOffers` 
ADD INDEX `ExchangeOffer_to_Posting_FK_idx` (`IdPosting` ASC) VISIBLE,
ADD INDEX `ExchangeOffer_to_Author_idx` (`IdAuthor` ASC) VISIBLE,
ADD INDEX `ExchangeOffer_to_Category_idx` (`IdCategory` ASC) VISIBLE,
ADD INDEX `ExchangeOffer_to_Book_FK_idx` (`IdBook` ASC) VISIBLE;
;
ALTER TABLE `TBExchangeOffers` 
ADD CONSTRAINT `ExchangeOffer_to_Posting_FK`
  FOREIGN KEY (`IdPosting`)
  REFERENCES `TBPostings` (`IdPosting`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `ExchangeOffer_to_Author_FK`
  FOREIGN KEY (`IdAuthor`)
  REFERENCES `TBAuthors` (`IdAuthor`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `ExchangeOffer_to_Category_FK`
  FOREIGN KEY (`IdCategory`)
  REFERENCES `TBCategories` (`IdCategory`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `ExchangeOffer_to_Book_FK`
  FOREIGN KEY (`IdBook`)
  REFERENCES `TBBooks` (`IdBook`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `TBPostings` 
ADD INDEX `Posting_to_Owner_FK_idx` (`IdOwnerUser` ASC) VISIBLE,
ADD INDEX `Posting_to_Book_FK_idx` (`IdBook` ASC) VISIBLE;
;
ALTER TABLE `TBPostings` 
ADD CONSTRAINT `Posting_to_Owner_FK`
  FOREIGN KEY (`IdOwnerUser`)
  REFERENCES `TBUsers` (`IdUser`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `Posting_to_Book_FK`
  FOREIGN KEY (`IdBook`)
  REFERENCES `TBBooks` (`IdBook`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `TBPostingImages` 
ADD INDEX `PostingImage_to_Posting_FK_idx` (`IdPosting` ASC) VISIBLE;
;
ALTER TABLE `TBPostingImages` 
ADD CONSTRAINT `PostingImage_to_Posting_FK`
  FOREIGN KEY (`IdPosting`)
  REFERENCES `TBPostings` (`IdPosting`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `TBUserAddresses` 
ADD INDEX `Address_to_User_FK_idx` (`IdUser` ASC) VISIBLE,
ADD INDEX `Address_to_City_FK_idx` (`IdCity` ASC) VISIBLE;
;
ALTER TABLE `TBUserAddresses` 
ADD CONSTRAINT `Address_to_User_FK`
  FOREIGN KEY (`IdUser`)
  REFERENCES `TBUsers` (`IdUser`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `Address_to_City_FK`
  FOREIGN KEY (`IdCity`)
  REFERENCES `TBCities` (`IdCity`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `TBUserAuthorPreferences` 
ADD INDEX `AuthorPreference_to_User_FK_idx` (`IdUser` ASC) VISIBLE,
ADD INDEX `AuthorPreference_to_Author_FK_idx` (`IdAuthor` ASC) VISIBLE;
;
ALTER TABLE `TBUserAuthorPreferences` 
ADD CONSTRAINT `AuthorPreference_to_User_FK`
  FOREIGN KEY (`IdUser`)
  REFERENCES `TBUsers` (`IdUser`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `AuthorPreference_to_Author_FK`
  FOREIGN KEY (`IdAuthor`)
  REFERENCES `TBAuthors` (`IdAuthor`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `TBUserCategoryPreferences` 
ADD INDEX `CategoryPreference_to_User_FK_idx` (`IdUser` ASC) VISIBLE,
ADD INDEX `CategoryPreference_to_Category_FK_idx` (`IdCategory` ASC) VISIBLE;
;
ALTER TABLE `TBUserCategoryPreferences` 
ADD CONSTRAINT `CategoryPreference_to_User_FK`
  FOREIGN KEY (`IdUser`)
  REFERENCES `TBUsers` (`IdUser`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION,
ADD CONSTRAINT `CategoryPreference_to_Category_FK`
  FOREIGN KEY (`IdCategory`)
  REFERENCES `TBCategories` (`IdCategory`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

ALTER TABLE `TBUserStatistics` 
ADD INDEX `Statistics_to_User_FK_idx` (`IdUser` ASC) VISIBLE;
;
ALTER TABLE `TBUserStatistics` 
ADD CONSTRAINT `Statistics_to_User_FK`
  FOREIGN KEY (`IdUser`)
  REFERENCES `TBUsers` (`IdUser`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

CREATE TABLE `TBUserWishlistItems` (
  `IdWishlistItem` BIGINT NOT NULL AUTO_INCREMENT,
  `IdUser` BIGINT NOT NULL,
  `IdBook` BIGINT NOT NULL,
  PRIMARY KEY (`IdWishlistItem`),
  INDEX `WishlistItem_to_User_FK_idx` (`IdUser` ASC) VISIBLE,
  INDEX `WishlistItem_to_Book_FK_idx` (`IdBook` ASC) VISIBLE,
  CONSTRAINT `WishlistItem_to_User_FK`
    FOREIGN KEY (`IdUser`)
    REFERENCES `TBUsers` (`IdUser`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `WishlistItem_to_Book_FK`
    FOREIGN KEY (`IdBook`)
    REFERENCES `TBBooks` (`IdBook`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);