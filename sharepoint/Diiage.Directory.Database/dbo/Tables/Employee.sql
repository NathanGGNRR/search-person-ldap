CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL IDENTITY(1,1) CONSTRAINT PK_Employee PRIMARY KEY,
	[DirectoryId] VARCHAR(256) NOT NULL CONSTRAINT UQ_Employee_DirectoryId UNIQUE,

	[Surname] VARCHAR(100) NOT NULL,
	[Firstname] VARCHAR(100) NOT NULL,
	[StartDate] DATE NOT NULL,
	[Position] VARCHAR(100) NOT NULL,
	[PositionLevel] VARCHAR(20) NOT NULL,
	[AnnualGrossIncome] INT NOT NULL,

	[Email] VARCHAR(255) NOT NULL,
	[PersonalEmail] VARCHAR(255) NULL,
	[Phone] VARCHAR(20) NULL,
	[PersonalPhone] VARCHAR(20) NULL,
	[BirthDate] DATE NOT NULL,

	[PersonalAddressStreet] VARCHAR(200) NULL,
	[PersonalAddressPostCode] VARCHAR(10) NOT NULL,
	[PersonalAddressCity] VARCHAR(100) NOT NULL,
	[PersonalAddressCountry] VARCHAR(100) NULL,

	[AddressStreet] VARCHAR(200) NULL,
	[AddressPostCode] VARCHAR(10) NOT NULL,
	[AddressCity] VARCHAR(100) NOT NULL,
	[AddressCountry] VARCHAR(100) NULL,

	[Comments] VARCHAR(2048) NULL
);
