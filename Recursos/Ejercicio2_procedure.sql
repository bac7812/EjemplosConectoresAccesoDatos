CREATE TABLE [dbo].[historicoLibro](
	[CodigoLibro] [int]  ,
	[Isbn] [varchar](12) NULL,
	[Titulo] [varchar](50) NULL,
	[Editorial] [varchar](50) NULL,
	[Descripcion] [text] NULL
	[numEjemplares] int null,
)

CREATE TABLE [dbo].[historicoPrestamo](
	[codigo] [int] NOT NULL,
	[numeroEjemp] [smallint] NOT NULL,
	[codigoSocio] [char](5) NULL,
	[fechaPrestamo] [smalldatetime] NOT NULL,
	[fechaDevolucion] [smalldatetime] NULL
)

CREATE PROCEDURE historico (@parametro int) as

BEGIN TRANSACTION -- O solo BEGIN TRAN
BEGIN TRY

/*Insertar libro y prestamo a historico*/
INSERT historicoPrestamos SELECT CodigoLibro, numeroEjemplar, CodigoSocio, FechaPrestamo, FechaDevolucion FROM Prestamo WHERE CodigoLibro = @parametro
INSERT historicoLibros SELECT CodigoLibro, Isbn, Titulo, Editorial, Descripcion, (SELECT COUNT(*) FROM Ejemplar WHERE Ejemplar.CodigoLibro = Libro.CodigoLibro) FROM Libro WHERE CodigoLibro = @parametro

/*Eliminar libro y prestamo*/
DELETE FROM Prestamo WHERE CodigoLibro = @parametro
DELETE FROM Ejemplar WHERE CodigoLibro = @parametro
DELETE FROM Libro WHERE CodigoLibro = @parametro
 
/*Confirmamos la transaccion*/ 
COMMIT TRANSACTION -- O solo COMMIT
 
END TRY
BEGIN CATCH

/*Hay un error, deshacemos los cambios*/ 
ROLLBACK TRANSACTION -- O solo ROLLBACK

END CATCH

Exec historico @parametro
