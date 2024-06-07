create database [TehnicalService]
go

use [TehnicalService]
go

create table [dbo].[user] (
	[login] varchar(64) not null primary key,
	[password] varchar(64) not null,
	[role] varchar(64) not null,
)
go

insert [dbo].[user] ([login], [password], [role])
values('CAXAP', '123', 'admin'),
('Misha', '123', 'user')
go

create table [dbo].[application] (
	[ID] int not null IDENTITY,
	[date_created] varchar(50) not null,
	[apportment] varchar(50) not null,
	[type_expection] varchar(50) not null,
	[description_bad_mark] varchar(50) not null,
	[status] varchar(50) not null,
	[user_id] varchar(64) not null,
	constraint [PK_Application] primary key ([ID]),
	FOREIGN KEY ([user_id]) REFERENCES [dbo].[user]([login])
)
go

