use master
create database PAPERDB
on primary
(name = N'PAPERDB_MDF', filename = N'D:\2k2s\COURSE_PROJECT\DB\MAINDB\PAPERDB.mdf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
(name = N'PAPERDB_NDF', filename = N'D:\2k2s\COURSE_PROJECT\DB\MAINDB\PAPERDB.ndf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
filegroup forUser
(name = N'PAPERDB_USER', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_USER_1.mdf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
(name = N'PAPERDB_USER_2', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_USER_2.ndf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
filegroup forRole
(name = N'PAPERDB_ROLE', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_ROLE_1.mdf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
(name = N'PAPERDB_ROLE_2', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_ROLE_2.ndf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
filegroup forTypePrice
(name = N'PAPERDB_TYPEPRICE', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_TYPEPRICE_1.mdf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
(name = N'PAPERDB_TYPEPRICE_2', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_TYPEPRICE_2.ndf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
filegroup forBooks
(name = N'PAPERDB_BOOK', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_BOOK_1.mdf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
(name = N'PAPERDB_BOOK_2', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_BOOK_2.ndf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
filegroup forBusket
(name = N'PAPERDB_BUSKET', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_BUSKET_1.mdf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
(name = N'PAPERDB_BUSKET_2', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_BUSKET_2.ndf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
filegroup forBusketBooks
(name = N'PAPERDB_BUSKETBOOKS', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_BUSKETBOOKS_1.mdf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb),
(name = N'PAPERDB_BUSKETBOOKS_2', filename = N'D:\2k2s\COURSE_PROJECT\DB\USERS\PAPERDB_BUSKETBOOKS_2.ndf',
size = 10240Kb, maxsize = UNLIMITED, filegrowth = 10240Kb)
log on
(name = N'T_MyBase_log', filename = N'D:\2k2s\COURSE_PROJECT\DB\LOG\T_MyBase_log.ldf',
size = 10240Kb, maxsize = 1Gb, filegrowth = 10%)