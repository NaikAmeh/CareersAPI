create database JobDB

CREATE TABLE [dbo].[Department](
        [DepartmentID]        INT IDENTITY(1,1) NOT NULL,
        [DepartmentName]      varchar(100)  NOT NULL

		CONSTRAINT pk_Department PRIMARY KEY (DepartmentID)
        )

		CREATE TABLE [dbo].[Location](
		[LocationID]        INT IDENTITY(1,1) NOT NULL,
		[LocationName]        VARCHAR(100) NOT NULL,
		[LocationCity]        VARCHAR(50) NOT NULL,
		[LocationState]        VARCHAR(100) NOT NULL,
		[LocationCountry]      VARCHAR(100) NOT NULL,
		[LocationZip]          INT  NOT NULL

		CONSTRAINT pk_Location PRIMARY KEY (LocationID)
		)

		CREATE TABLE [dbo].[Jobs](
		[JobID]                   INT IDENTITY(1,1) NOT NULL,
		[JobName]                 VARCHAR(100) NOT NULL,
		[JobCode]                 VARCHAR(100) NOT NULL,
		[JobDescription]          VARCHAR(100) NOT NULL,
		[LocationID]              INT NOT NULL,
		[DepartmentID]            INT NOT NULL,
		[PostedDate]              [datetime2](7) NOT NULL,
		[ClosingDate]             [datetime2](7) NOT NULL,
		[IsActive]                bit not null default 0

		 CONSTRAINT pk_Job PRIMARY KEY (JobID),
        CONSTRAINT fk_Job_Department   FOREIGN KEY(DepartmentID) REFERENCES dbo.Department(DepartmentID),
		CONSTRAINT fk_Job_Location   FOREIGN KEY(LocationID) REFERENCES dbo.[Location](LocationID)
		)


insert into Department
values('HR'),
('Management'),
('Testing'),
('Development')

insert into [Location]
values('Borda','Margao','Goa','India',403004),
('Verna','Margao','Goa','India',403006),
('Privika','Bangalore','Karnataka','India',400087),
('Mayami','Pune','Maharashtra','India',408594)
