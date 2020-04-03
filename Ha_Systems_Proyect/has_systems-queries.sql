CREATE DATABASE HA_SYSTEMS;

use HA_SYSTEMS;

CREATE TABLE CLIENTE(
	Id_cliente INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(25) NOT NULL,
	Apellido VARCHAR(25) NOT NULL,
	Celular VARCHAR(12),
	Cedula Varchar(11) unique,
	Correo VARCHAR(40),
	Direccion VARCHAR(50),
	Ciudad VARCHAR(50)
)

CREATE TABLE HABITACION(
	Id_habitacion INT IDENTITY(1,1) NOT NULL  PRIMARY KEY,
	Descripcion VARCHAR(60),
	Estado_habitacion int,
	Disponibilidad bit
)

CREATE TABLE HOSPEDAJE(
	Id_hospedaje INT IDENTITY(1,1) PRIMARY KEY,
	Cliente_id INT NOT NULL,
	Habitacion_id INT NOT NULL,
	Fecha_inicio DATE NOT NULL,
	Fecha_fin DATE,
	CONSTRAINT Cliente_fk FOREIGN KEY (Cliente_id) REFERENCES CLIENTE(Id_cliente),
	CONSTRAINT Habitacion_fk FOREIGN KEY (Habitacion_id) REFERENCES HABITACION(Id_habitacion)
)


CREATE TABLE INVENTARIO(
	Id_inventario INT IDENTITY(1,1)  PRIMARY KEY,
	Asignacion INT,
	Ubicacion VARCHAR(50),
	Marca VARCHAR(30),
	Numero_serie INT,
	Descripcion VARCHAR(50),
	Cantidad INT
)

CREATE TABLE FACTURA(
	Codigo INT IDENTITY(1,1)  PRIMARY KEY,
	Code_Factura Varchar(10) unique,
	Cedula_Cliente VARCHAR(11),
	Cliente	VARCHAR(100),
	Habitacion INT,
	Hospedaje_fk INT,
	Motivo VARCHAR(100),
	Fecha_Creacion DATE,
	Total INT
	CONSTRAINT Hospedaje_fK FOREIGN KEY (Hospedaje_fk) REFERENCES HOSPEDAJE(Id_hospedaje)
)


CREATE TABLE CUENTA_POR_COBRAR(
	Id_cuenta INT IDENTITY(1,1) PRIMARY KEY,
	Factura INT NOT NULL,
	Fecha_inicio DATE,
	Fecha_fin DATE
	CONSTRAINT Factura_fK FOREIGN KEY (Factura) REFERENCES FACTURA(Codigo)
)


CREATE TABLE USUARIO(
	Id_usuario INT IDENTITY(1,1) PRIMARY KEY,
	Usuario VARCHAR(40),
	Nombre VARCHAR(40),
	Tipo VARCHAR(49),
	Passwords VARCHAR(40),
	Password_V VARCHAR(34)
)


CREATE TABLE MONITOR_SESSION(
	Id_monitoreo INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	Usuario INT,
	Fecha_inicio DATE default (getdate()),
	Hora_inicio TIME,
	Hora_fin TIME,
	Fecha_fin DATE
	CONSTRAINT Usuario_fK FOREIGN KEY (Usuario) REFERENCES USUARIO(Id_usuario)
)