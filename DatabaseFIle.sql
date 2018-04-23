


create database SH;
use SH;

CREATE TABLE ResourceType
(
 ResourceID  INT NOT NULL ,
 Description NVARCHAR(128) NOT NULL ,

 CONSTRAINT PK_ResourceType PRIMARY KEY CLUSTERED (ResourceID ASC)
);




CREATE TABLE User
(
 UserID   INT NOT NULL auto_increment ,
 userName VARCHAR(64) NOT NULL ,
 Password VARCHAR(32) NOT NULL ,

 CONSTRAINT PK_User PRIMARY KEY CLUSTERED (UserID ASC)
);




CREATE TABLE Eve
(
 EventID     INT NOT NULL auto_increment,
 Description VARCHAR(256) NOT NULL ,
 UserID      INT NOT NULL ,

 CONSTRAINT PK_Event PRIMARY KEY CLUSTERED (EventID ASC),
 CONSTRAINT FK_294 FOREIGN KEY (UserID)
  REFERENCES User(UserID)
);




CREATE TABLE UserAddress
(
 AddID    int NOT NULL auto_increment,
 Street  VARCHAR(128) NOT NULL ,
 Street2 VARCHAR(128)  ,
 city    VARCHAR(32) NOT NULL ,
 state   VARCHAR(32) NOT NULL ,
 zipcode VARCHAR(15) NOT NULL ,
 UserID  INT NOT NULL ,

 CONSTRAINT PK_UserAddress PRIMARY KEY CLUSTERED (AddID ASC),
 CONSTRAINT FK_282 FOREIGN KEY (UserID)
  REFERENCES User(UserID)
);




CREATE TABLE UserInformation
(
 UiID          int  NOT NULL auto_increment ,
 FirstName     VARCHAR(64) NOT NULL ,
 LastName      VARCHAR(64) NOT NULL ,
 MiddleInitial VARCHAR(1), 
 Phone         VARCHAR(11) NOT NULL ,
 Email         VARCHAR(64) NOT NULL ,
 UserID        INT NOT NULL ,

 CONSTRAINT PK_UserInformation PRIMARY KEY CLUSTERED (UiID ASC),
 CONSTRAINT FK_278 FOREIGN KEY (UserID)
  REFERENCES User(UserID)
);





CREATE TABLE EventAddress
(
 EventAddID INT NOT NULL auto_increment,
 Street     VARCHAR(128) NOT NULL ,
 Street2    VARCHAR(128)  ,
 city       VARCHAR(32) NOT NULL ,
 state      VARCHAR(32) NOT NULL ,
 zipcode    VARCHAR(15) NOT NULL ,
 EventID    INT NOT NULL ,

 CONSTRAINT PK_EventAddress PRIMARY KEY CLUSTERED (EventAddID ASC),
 CONSTRAINT FK_267 FOREIGN KEY (EventID)
  REFERENCES Eve(EventID)
);








CREATE TABLE RequestResources
(
 RequestID   INT NOT NULL auto_increment,
 Amount      INT NOT NULL ,
 Description VARCHAR(256)  ,
 Delivered   INT NOT NULL ,
 EventID     INT NOT NULL ,
 ResourceID  INT NOT NULL ,
 userID      INT  ,

 CONSTRAINT PK_RequestResources PRIMARY KEY CLUSTERED (RequestID ASC),
 CONSTRAINT FK_254 FOREIGN KEY (EventID)
  REFERENCES Eve(EventID),
 CONSTRAINT FK_259 FOREIGN KEY (ResourceID)
  REFERENCES ResourceType(ResourceID)
);







CREATE TABLE VolunteerResources 
(
 VRID        int NOT NULL auto_increment,
 Amount      INT NOT NULL ,
 Description VARCHAR(256)  ,
 Delivered   INT NOT NULL ,
 UserID      INT NOT NULL ,
 ResourceID  INT NOT NULL ,
 EventID     INT NOT NULL ,

 CONSTRAINT PK_VolunteerResources  PRIMARY KEY CLUSTERED (VRID ASC),
 CONSTRAINT FK_286 FOREIGN KEY (UserID)
  REFERENCES User(UserID),
 CONSTRAINT FK_290 FOREIGN KEY (ResourceID)
  REFERENCES ResourceType(ResourceID),
 CONSTRAINT FK_298 FOREIGN KEY (EventID)
  REFERENCES Eve(EventID)
);





CREATE TABLE RequsetAddress
(
 ReqAddID  INT NOT NULL auto_increment,
 street    VARCHAR(128) NOT NULL ,
 street2   VARCHAR(128) ,
 city      VARCHAR(32) NOT NULL ,
 state     VARCHAR(32) NOT NULL ,
 zipcode   VARCHAR(15) NOT NULL ,
 RequestID INT NOT NULL ,

 CONSTRAINT PK_RequsetAddress PRIMARY KEY CLUSTERED (ReqAddID ASC),
 CONSTRAINT FK_263 FOREIGN KEY (RequestID)
  REFERENCES RequestResources(RequestID)
);


