create table "DictGenres"(
"Id" bigint primary key,
"Genre" nvarchar(MAX) not null
)


create table "Films"(
"Id" bigint primary key,
"GenreType" bigint,
"Name" nvarchar(MAX) not null,
"DateOfStart" datetime not null,
"DateOfFinish" datetime,
"Actual" int,
foreign key (GenreType) references DictGenres(Id)
)
