Create database Usuarios;

use Usuarios;

Create table Usuarios(
	Id int identity(1,1) primary key not null,
	Dni varchar(9) not null,
	Nombre varchar(30) not null,
	Apellidos varchar(30) not null,
	Correo varchar(30) not null,
	Contraseña varchar(30) not null,
	Fecha_nacimiento date not null,
	Fecha_registro date not null,
	Estado varchar(30) not null,
	Telefono varchar(30) not null,
	constraint ck_Estado check(Estado in('Activo', 'Bloqueado', 'Deshabilitado')),
	constraint u_Dni unique (Dni))
