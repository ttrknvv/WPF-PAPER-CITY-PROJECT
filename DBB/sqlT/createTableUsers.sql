create table ROLE
(
	ROLE_USER nvarchar(20) check(Role_user in ('admin', 'common')) primary key
) on forRole;

insert ROLE(ROLE_USER)
	values('admin'),
		  ('common')

create table USERS
(
	ID_USER int identity(1, 1) primary key,
	IMAGE_PROFILE nvarchar(100),
	LOGIN nvarchar(40) not null unique,
	NAME nvarchar(100) not null,
	PASSWORD nvarchar(50) not null,
	EMAIL nvarchar(70) not null,
	PHONE_NUMBER nvarchar(14),
	DATE_REGISTRATION date not null,
	ROLE nvarchar(20) foreign key references ROLE(ROLE_USER) not null
) on forUser;

create table TYPE_PRICE
(
	TYPE_PRICE nvarchar(10) primary key check(TYPE_PRICE in('free', 'paying')) not null
) on forTypePrice;

insert TYPE_PRICE(TYPE_PRICE)
		values('free'),
		      ('paying')

create table BOOKS
(
	ID_BOOK int identity(1, 1) primary key,
	IMAGE_BOOK nvarchar(100),
	NAME nvarchar(100) not null,
	AUTHOR nvarchar(100),
	POPULARITY int default(0),
	GENRE nvarchar(100),
	DESCRIPTION nvarchar(max),
	TYPE_PRICE nvarchar(10) foreign key references TYPE_PRICE(TYPE_PRICE) not null,
	COST int,
	PATH_DOWNLOAD nvarchar(max),
	DATE_PUBLICATION date
) on forBooks;

create table BUSKET
(
	ID_BUSKET int identity(1, 1) primary key,
	ID_USER int foreign key references USERS(ID_USER) not null
) on forBusket;

create table BUSKET_BOOKS
(
	ID_RECORD int primary key identity(1, 1),
	ID_BUSKET int foreign key references BUSKET(ID_BUSKET) not null,
	ID_BOOK int foreign key references BOOKS(ID_BOOK) not null
) on forBusketBooks;


create table PAYMENT
(
	ID_PAY int identity(1, 1),
	ID_USER int foreign key references USERS(ID_USER),
	NUMBER_CARD nvarchar(max),
	NAME_OWNER nvarchar(max),
	DATE nvarchar(max),
	ID_BOOK int foreign key references BOOKS(ID_BOOK),
	STATE nvarchar(max) check (STATE in ('waiting', 'confirmed', 'rejected'))
)

create table REVIEWS
(
	ID_REVIEW int identity(1, 1) primary key,
	LOGIN nvarchar(40) foreign key references USERS(LOGIN),
	ID_BOOK int foreign key references BOOKS(ID_BOOK),
	REVIEW_TEXT nvarchar(max),
	DATE datetime
)


create table REVIEW_PROBLEM
(
	ID_REVIEW int identity(1, 1) primary key,
	LOGIN nvarchar(40) foreign key references USERS(LOGIN),
	DATE date,
	REVIEW_TEXT nvarchar(max),
	STATE nvarchar(max) check (STATE in ('waiting', 'confirmed', 'rejected'))
)

