     create table "City" (
        Id  integer primary key autoincrement,
       Name TEXT not null,
       CountryId INTEGER not null,
       constraint FK_City_CountryId_Country_Id foreign key (CountryId) references "Country"
    )

    create table "Content" (
        Id  integer primary key autoincrement,
       Name TEXT not null,
       CreatorId INTEGER not null,
       DateTimeUtc TEXT not null,
       Category INTEGER not null,
       constraint FK_Content_CreatorId_User_Id foreign key (CreatorId) references "User"
    )

 create table Article (
        ContentId INTEGER not null,
       Text TEXT not null,
       primary key (ContentId),
       constraint FK_Article_ContentId_Content_Id foreign key (ContentId) references "Content"
    )

    create table Gallery (
        ContentId INTEGER not null,
       CoverUrl TEXT not null,
       primary key (ContentId),
       constraint FK_Gallery_ContentId_Content_Id foreign key (ContentId) references "Content"
    )

    create table Video (
        ContentId INTEGER not null,
       Url TEXT not null,
       primary key (ContentId),
       constraint FK_Video_ContentId_Content_Id foreign key (ContentId) references "Content"
    )

    create table "Country" (
        Id  integer primary key autoincrement,
       Name TEXT not null
    )

    create table "User" (
        Id  integer primary key autoincrement,
       Email TEXT not null,
       CityId INTEGER not null,
       constraint FK_User_CityId_City_Id foreign key (CityId) references "City"
    )

    create table "ContentRating" (
        Id  integer primary key autoincrement,
       DateTimeUtc TEXT not null,
       Rate INTEGER not null,
       UserId INTEGER not null,
       ContentId INTEGER,
       constraint FK_ContentRating_UserId_User_Id foreign key (UserId) references "User",
       constraint FK_ContentRating_ContentId_Content_Id foreign key (ContentId) references "Content"
    )

    create table "Image" (
        Id  integer primary key autoincrement,
       Url TEXT not null,
       GalleryId INTEGER,
       constraint FK_Image_GalleryId_Gallery_Id foreign key (GalleryId) references Gallery
    )