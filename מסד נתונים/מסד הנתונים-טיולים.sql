create database TheOrganizedTour
go
use TheOrganizedTour

create table tripType(
Id int primary key,
TripName varchar(20),
)
go
create table users(
Id int primary key,
firstName varchar(20),
lastName varchar(20),
phone varchar(20),
mail varchar(40),
password varchar(20),
firstAidCertificate bit default(0),
)
go
create table Trips(
Id int primary key,
destination varchar(30),
Type int references tripType,
date date,
departure time,
hours float,
Vacancys int,--מקומות פנוים
price float,
img varchar(100)
)
go
create table orderTicket(
Id int identity(1,1) primary key,
userId int references users,
date date,
orderTime time,
hours int,
tripId int references Trips,
tickets int
)

insert into tripType 
values(7,'attraction')
insert into tripType 
values(2,'dry')
insert into tripType 
values(3,'wet')
insert into tripType 
values(4,'challanging')
insert into tripType 
values(5,'easy')
go
insert into users 
values(11,'yael','shlanger','0556758937','yaelshlanger@gmail.com','2004',0)
insert into users 
values(22,'miryam','tzadok','0583202575','m0583202575@gmail.com','010203',1)
insert into users 
values(33,'ayala','fisher','0533162139','ayala11@gmail.com','123456',0)
insert into users 
values(44,'tamar','yaloz','0583273978','t978@gmail.com','789456',1)
insert into users 
values(55,'fraidy','zalmen','0597722158','025852@gmail.com','741852963',0)
go
insert into Trips 
values(111,'hermon','2','2023-10-02','16:00:00',6,15,1500,'D:\the user\Downloads\IMG_1912.JPG')
insert into Trips 
values(222,'jordan','3','2021-10-02','14:00:00',9,15,800,'D:\the user\Downloads\IMG_1912.JPG')
insert into Trips 
values(333,'onelolo','2','2020-10-02','16:00:00',8,0,78,'D:\the user\Downloads\IMG_1912.JPG')
insert into Trips 
values(444,'western wall','2','2001-10-02','09:00:00',6,15,5000,'D:\the user\Downloads\IMG_1912.JPG')
insert into Trips 
values(555,'inbal','2','2000-10-02','12:00:00',6,205,8000,'D:\the user\Downloads\IMG_1912.JPG')
go
insert into orderTicket 
values(11,'1859-10-02','16:00:00',9,444,5)
insert into orderTicket 
values(22,'2000-10-02','16:00:00',5,111,5)
insert into orderTicket 
values(33,'2054-10-02','16:00:00',10,222,5)
insert into orderTicket 
values(11,'1900-10-02','16:00:00',4,333,5)
insert into orderTicket 
values(11,'2020-10-02','16:00:00',5,111,5)
