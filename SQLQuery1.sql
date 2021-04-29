create database OnlineInstrumentsStore
go

use OnlineInstrumentsStore



create table Manufacturer
(
	IDManufacturer UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	ManufacturerName varchar(100) not null,
	
)

create table Customer
(
	IDCustomer UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	CustomerName varchar(250) not null,
	Email varchar(250) not null,
	Address varchar(250) not null,
	Phone varchar(250) not null, 

	
	
)
CREATE TABLE Instrument
(
	IDInstrument UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,	
	InstrumentName varchar(250) not null,
	IDManufacturer UNIQUEIDENTIFIER not null,
	InstrumentType varchar(250) not null,
	Description varchar(1000) null,
	Price money not null

	CONSTRAINT [FK_Manufacturer] FOREIGN KEY (IDManufacturer) REFERENCES [Manufacturer](IDManufacturer),
)

create table Orders
(
	IDOrder UNIQUEIDENTIFIER NOT NULL PRIMARY KEY,
	IDCustomer UNIQUEIDENTIFIER not null,
	DeliveryAdress varchar(250),
	IDInstrument UNIQUEIDENTIFIER not null,
	Quantity int not null,
	Date datetime not null,
	TotalPrice money not null
	
	CONSTRAINT [FK_Customer] FOREIGN KEY (IDCustomer) REFERENCES [Customer](IDCustomer),
	CONSTRAINT [FK_Instrument] FOREIGN KEY (IDInstrument) REFERENCES [Instrument](IDInstrument),

)

