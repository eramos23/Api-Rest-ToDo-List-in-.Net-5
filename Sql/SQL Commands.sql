Create database ToDoList_DB;
Go;

use ToDoList_DB;

CREATE TABLE Lista (
	Id			int not null IDENTITY(1,1) PRIMARY KEY,
	Titulo		varchar(100) not null,
	Descripcion	varchar(500),
	Eliminado	bit not null default 0
)
GO

CREATE TABLE Item (
	Id				int not null IDENTITY(1,1) PRIMARY KEY,
	IdLista			int not null,
	Descripcion		varchar(200) not null,
	Completado		bit not null default 0,
	Eliminado		bit not null default 0,
	FOREIGN KEY (IdLista) REFERENCES Lista(Id)
)
GO

/*USP LISTA*/
CREATE PROCEDURE uspListaCrear
	@titulo varchar(100),
	@descripcion varchar(100),
	@id int OUTPUT
AS
BEGIN
	INSERT INTO Lista(Titulo, Descripcion)
	VALUES (@titulo, @descripcion)

	SELECT @id = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE uspListaUpdate
    @id int,
	@titulo varchar(100),
	@descripcion varchar(500)
AS
BEGIN
	UPDATE Lista
	SET Titulo = @titulo, 
		Descripcion = @descripcion
	WHERE Id = @id 
END
GO

CREATE PROCEDURE uspListaEliminar
    @id int
AS
BEGIN
	DELETE FROM Item
	WHERE IdLista = @id

	DELETE FROM Lista
	WHERE Id = @id 
END
GO

CREATE PROCEDURE uspListaEliminacionLogica
    @id int
AS
BEGIN
	UPDATE Lista
	SET Eliminado = 1
	WHERE Id = @id 
END
GO

alter PROCEDURE uspListaPaginada
	@pagina int,
	@tamanioPagina int
AS
BEGIN
	SELECT 
		Id,
		Titulo,
		Descripcion,
		Eliminado
	FROM Lista
	WHERE 
		Eliminado = 0
	ORDER BY Id
	OFFSET @tamanioPagina * (@pagina-1) ROWS FETCH NEXT @tamanioPagina ROWS ONLY
END
GO
/*END USP LISTA*/


/*USP ITEM*/
CREATE PROCEDURE uspItemCrear
	@idLista int,
	@descripcion varchar(200),
	@completado bit,
	@id int OUTPUT
AS
BEGIN
	INSERT INTO Item(IdLista, Descripcion, Completado)
	VALUES (@idLista, @descripcion, @completado)

	SELECT @id = SCOPE_IDENTITY()
END
GO

CREATE PROCEDURE uspItemUpdate
	@id int,
    @idLista int,
	@descripcion varchar(200),
	@completado bit
AS
BEGIN
	UPDATE Item
	SET IdLista = @idLista, 
		Descripcion = @descripcion,
		Completado = @completado
	WHERE Id = @id
END
GO

CREATE PROCEDURE uspItemEliminar
    @id int
AS
BEGIN
	DELETE FROM Item
	WHERE Id = @id
END
GO

CREATE PROCEDURE uspItemEliminacionLogica
    @id int
AS
BEGIN
	UPDATE Item
	SET Eliminado = 1
	WHERE Id = @id 
END
GO
/*END USP ITEM*/

--INDEX
CREATE NONCLUSTERED INDEX cl_ListaTitulo ON Lista (Titulo)
CREATE NONCLUSTERED INDEX cl_ListaDescripcion ON Lista (Descripcion)

CREATE NONCLUSTERED INDEX cl_ItemTabla ON Item (Descripcion, Completado)
--END INDEX

--exec sp_helpindex  'Lista'
/*
exec uspListaPaginada @pagina = 2, @tamanioPagina = 3
select * from Lista
go
*/
