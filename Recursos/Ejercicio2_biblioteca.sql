Create DATABASE Biblioteca

Go 

Use Biblioteca 

Create Table Socio
(
	CodigoSocio Int IDENTITY (1,1) Primary Key,
	Dni varchar (9) UNIQUE not null,
	Nombre varchar (32) not null,
	Apellidos varchar (32) not null,
	Direccion varchar (32) not null,
	Correo varchar (32) not null,
	Telefono varchar (32) not null
)

Create Table Libro 
(
	CodigoLibro Int IDENTITY (1,1) Primary Key,
	Isbn varchar (20) UNIQUE not null,
	Titulo varchar (32) not null,
	Editorial varchar (32) not null,
	Descripcion varchar (400) null 
) 

Create Table Ejemplar 
(
	CodigoLibro Int not null,
	NumeroEjemplar Int not null,
	FechaPublicacion Date not null,
	Estado varchar (32) null
)

Alter Table Ejemplar Add Constraint pk_Ejemplar Primary Key (CodigoLibro, NumeroEjemplar)
Alter Table Ejemplar Add Constraint fk_LibroEjemplar Foreign Key (CodigoLibro) References Libro(CodigoLibro)

Create Table Prestamo
(
	CodigoLibro Int not null,
	NumeroEjemplar Int not null,
	CodigoSocio Int not null,
	FechaPrestamo Date not null,
	FechaDevolucion Date null
)

Alter Table Prestamo Add Constraint pk_Prestamo Primary Key (CodigoLibro, NumeroEjemplar, FechaPrestamo)
Alter Table Prestamo Add Constraint fk_PrestamoEjemplar Foreign Key (CodigoLibro, NumeroEjemplar) References Ejemplar(CodigoLibro,NumeroEjemplar)
Alter Table Prestamo Add Constraint fk_PrestamoSocio Foreign Key (CodigoSocio) References Socio(CodigoSocio)
