Create table Users(	
id int identity primary key,
name nvarchar(200) not null,
phone nvarchar(50) not null,
roleId int foreign key references Roles(id)
)
Create table Roles(	
id int identity primary key,
name nvarchar(200) not null
)
create table Wares(
id int identity primary key,
name nvarchar(200) not null,
price int not null,
imgUrl nvarchar(100)
)



create table Salesman(
id int identity primary key,
name nvarchar(200) not null,
role nvarchar(500))

drop table orders

create table orders(
id int identity primary key,
pokupatelId int foreign key references Users(id), 
tovarId int foreign key references Wares(id),
prodavetsId int foreign key references Salesman(id))

insert into Users (name, phone, roleId) values ('Emlyn', '4128629353', 1);
insert into Users (name, phone, roleId) values ('Eamon', '7141583512', 2);
insert into Users (name, phone, roleId) values ('Korry', '6718289404', 3);
insert into Users (name, phone, roleId) values ('Modesty', '7171738465', 2);
insert into Users (name, phone, roleId) values ('Talia', '2651469406', 1);
insert into Users (name, phone, roleId) values ('Jandy', '8583284969', 1);
insert into Users (name, phone, roleId) values ('Coraline', '8601145942', 2);
insert into Users (name, phone, roleId) values ('Justen', '6392187141', 1);
insert into Users (name, phone, roleId) values ('Maggy', '5848899483', 2);
insert into Users (name, phone, roleId) values ('Bobby', '1337805089', 1);

insert into Roles (name) values ('Buyer');
insert into Roles (name) values ('Admin');
insert into Roles (name) values ('Salesman');

insert into Wares (name, price, imgUrl) values ('Dasypus novemcinctus', 327, 'https://i1.sndcdn.com/artworks-zyYqA8D0BdfuyH28-WeeHrw-t500x500.jpg');
insert into Wares (name, price, imgUrl) values ('Felis chaus', 386, 'https://i.pinimg.com/736x/ba/92/7f/ba927ff34cd961ce2c184d47e8ead9f6.jpg');
insert into Wares (name, price, imgUrl) values ('Stercorarius longicausus', 118, 'https://i.pinimg.com/564x/d1/83/8e/d1838ec5f0d188e962aff86c1502f619.jpg');

insert into Salesman (name, role) values ('Dusicyon thous', 'High Salesman');
insert into Salesman (name, role) values ('Mabuya spilogaster', 'Salesman knight');

insert into orders (pokupatelId, tovarId,prodavetsId) values (4, 2,1);
insert into orders (pokupatelId, tovarId,prodavetsId) values (6, 1,2);
insert into orders (pokupatelId, tovarId,prodavetsId) values (8, 1,1);
insert into orders (pokupatelId, tovarId,prodavetsId) values (4, 3,2);
insert into orders (pokupatelId, tovarId,prodavetsId) values (1, 1,1);

insert into orders (pokupatelId, tovarId, prodavetsId) values (7, 1, 1);
insert into orders (pokupatelId, tovarId, prodavetsId) values (5, 5, 1);
insert into orders (pokupatelId, tovarId, prodavetsId) values (9, 5, 2);
insert into orders (pokupatelId, tovarId, prodavetsId) values (6, 4, 1);
insert into orders (pokupatelId, tovarId, prodavetsId) values (3, 3, 2);
insert into orders (pokupatelId, tovarId, prodavetsId) values (6, 3, 2);
insert into orders (pokupatelId, tovarId, prodavetsId) values (1, 1, 2);
insert into orders (pokupatelId, tovarId, prodavetsId) values (9, 1, 2);
insert into orders (pokupatelId, tovarId, prodavetsId) values (9, 2, 2);
insert into orders (pokupatelId, tovarId, prodavetsId) values (4, 4, 2);
insert into orders (pokupatelId, tovarId, prodavetsId) values (5, 1, 1);
insert into orders (pokupatelId, tovarId, prodavetsId) values (2, 3, 2);
insert into orders (pokupatelId, tovarId, prodavetsId) values (5, 2, 2);
insert into orders (pokupatelId, tovarId, prodavetsId) values (5, 1, 2);
insert into orders (pokupatelId, tovarId, prodavetsId) values (3, 1, 2);

select u.name, w.name,s.name
from orders as o join users as u on o.pokupatelId = u.id join Wares as w on o.tovarId = w.id join Salesman as s on o.prodavetsId = s.id
