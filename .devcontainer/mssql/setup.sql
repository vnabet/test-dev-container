CREATE DATABASE VincentDB;
GO

create table table_test
(
    id   int identity
        constraint table_test_pk
            primary key,
    name varchar(255) not null
)

use VincentDB
insert into table_test (name)
values ('tutu');
insert into table_test (name)
values ('tata');
insert into table_test (name)
values ('toto');
insert into table_test (name)
values ('titi');
go
