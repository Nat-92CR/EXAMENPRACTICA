create database Examen2Progra2
go
use Examen2Progra2
go


--**--**--**--**--CREACION DE TABLAS--**--**--**--**--

------******Iniciando Creacion de Tablas******-----

create table Usuarios(
	UsuarioId			int identity(1,1) primary key,
	Nombre				varchar(50) not null,
	CorreoElectronico	varchar(50),
	Telefono			varchar(15) unique
)
go

create table Equipos(
	EquipoId		int identity(1,1) primary key,
	TipoEquipo		varchar(50) not null,
	Modelo			varchar(50),
	UsuarioId		int, 
	constraint fkEquiposUsuario foreign key(UsuarioId) references Usuarios (UsuarioId)
)
go

create table Reparaciones(
	ReparacionesId		int identity(1,1) primary key,
	EquipoId			int,
	FechaSolicitud		datetime,
	Estado				char,
	constraint fkReparacionesEquipo foreign key(EquipoId) references Equipos(EquipoId)
)
go

create table DetallesReparacion(
	DetalleId		int identity(1,1) primary key,
	ReparacionId	int,
	Descripcion		varchar(50),
	FechaInicio		datetime,
	FechaFin		datetime,
	constraint fkDetalleReparacion foreign key(ReparacionId) references Reparaciones(ReparacionesId)
)
go

create table Tecnicos(
	TecnicoId		int identity(1,1) primary key,
	Nombre			varchar(50),
	Especialidad	varchar(50),
)
go

create table Asignaciones(
	AsignacionId	int identity(1,1) primary key,
	ReparacionId	int,
	TecnicoId		int,
	FechaAsignacion	datetime,
	constraint fkAsignacionReparacion foreign key(ReparacionId) references Reparaciones(ReparacionesId),
	constraint fkAsignacionTecnico foreign key(TecnicoId) references Tecnicos(TecnicoId),

)
go


SELECT *FROM Usuarios
SELECT *FROM Equipos
SELECT *FROM Reparaciones
SELECT *FROM DetallesReparacion
SELECT *FROM Tecnicos
SELECT *FROM Asignaciones

INSERT INTO Usuarios(Nombre,CorreoElectronico,Telefono) values ('Natalia Tobal','nataliatobal3@gmail.com','61270000'),('Karen Rojas','karojas3@gmail.com','61270001')
INSERT INTO Equipos(TipoEquipo,Modelo,UsuarioId) values ('Portatil','DELL',1002),('Tablet','SAMSUNG',1003)
INSERT INTO Reparaciones(EquipoId,FechaSolicitud,Estado) values (1002,'2023-11-16','R'),(1003,'2023-12-16','P') --R: Reparado, P: Pendiente--
INSERT INTO DetallesReparacion(ReparacionId, Descripcion, FechaInicio, FechaFin) values(1002,'Cpu Quemado','2023-11-16', '2023-12-15'), (1003,'Pantalla Dañada','2023-11-16','2023-11-16')
INSERT INTO Tecnicos(Nombre, Especialidad) values ('Ronald Quiros','Informatica'),('Maria Rodriguez','Informatica')
INSERT INTO Asignaciones(ReparacionId,TecnicoId, FechaAsignacion) values(1003,1002,'2023-10-16'),(1003,1002, '2023-11-17')


--Ingresa la tabla que desea ver detallada (Usuarios,Equipos,Tecnicos,Reparaciones)--
SELECT *FROM Usuarios




--*****************************************************
--**********PROCEDIMIENTOS ALMACENADOS*****************
--*****************************************************

--***********************************************************************************--
--*------------*****-----Procedimiento Consultar con Filtro-----*****---------------*--
--***********************************************************************************--

------///////////////////////////////////////////////////////////////////////////////////------

--Usuarios--
CREATE PROCEDURE CONSULTAR_FILTRO_USUARIOS
@UsuarioId INT
AS	
	BEGIN
		SELECT *FROM Usuarios WHERE UsuarioId =@UsuarioId
	END
GO
--Fin Consultar con filtro Usuarios--
EXEC CONSULTAR_FILTRO_USUARIOS 3  --Codigo para ejecutar CONSULTAR_FILTRO_USUARIOS
SELECT *FROM Usuarios --Para verificar las lineas utilizadas en Usuarios--

------///////////////////////////////////////////////////////////////////////////////////------

--Equipos--
CREATE PROCEDURE CONSULTAR_FILTRO_EQUIPOS
@EquipoId INT
AS	
	BEGIN
		SELECT *FROM Equipos WHERE EquipoId = @EquipoId
	END
GO
--Fin Consultar con filtro Equipos--
EXEC CONSULTAR_FILTRO_EQUIPOS 8 --Codigo para ejecutar CONSULTAR_FILTRO_EQUIPOS


------///////////////////////////////////////////////////////////////////////////////////------

--Tecnicos--
CREATE PROCEDURE CONSULTAR_FILTRO_TECNICOS
@TecnicoId INT
AS	
	BEGIN
		SELECT *FROM Tecnicos WHERE TecnicoId =@TecnicoId
	END
GO
--Fin Consultar con filtro Tecnicos-
EXEC CONSULTAR_FILTRO_TECNICOS  5 --Codigo para ejecutar CONSULTAR_FILTRO_TECNICOS

--**************FIN CONSULTAR_FILTRO_USUARIOS,EQUIPOS,TECNICOS**************--
------///////////////////////////////////////////////////////////////////////////////////------





--***************************************************************************--
--*-----------*****-----Procedimiento Borrar-----*****---------------********--
--***************************************************************************--

------///////////////////////////////////////////////////////////////////////////////////------

--Usuarios--
CREATE PROCEDURE BORRAR_USUARIOS
@UsuarioId INT
AS	
	BEGIN
		DELETE FROM Usuarios WHERE UsuarioId = @UsuarioId
	END

--Fin Borrar--
EXEC BORRAR_USUARIOS 1004

SELECT *FROM Usuarios

------///////////////////////////////////////////////////////////////////////////////////------

--Equipos--
CREATE PROCEDURE BORRAR_EQUIPOS
@EquipoId INT
AS	
	BEGIN
		DELETE FROM Equipos WHERE EquipoId = @EquipoId
	END

--Fin Borrar--
EXEC BORRAR_EQUIPOS 14


SELECT *FROM Equipos

------///////////////////////////////////////////////////////////////////////////////////------

--Tecnicos--
CREATE PROCEDURE BORRAR_TECNICOS
@TecnicoId INT
AS	
	BEGIN
		DELETE FROM Tecnicos WHERE TecnicoId = @TecnicoId
	END

--Fin Borrar--
EXEC BORRAR_TECNICOS 9


SELECT *FROM Tecnicos

------///////////////////////////////////////////////////////////////////////////////////------

--Asignaciones--
CREATE PROCEDURE BORRAR_ASIGNACIONES
@AsignacionId INT
AS	
	BEGIN
		DELETE FROM Asignaciones WHERE AsignacionId =@AsignacionId
	END

--Fin Borrar--
EXEC BORRAR_ASIGNACIONES 7


SELECT *FROM Asignaciones

------///////////////////////////////////////////////////////////////////////////////////------

--Reparaciones--
CREATE PROCEDURE BORRAR_REPARACIONES
@ReparacionesId INT
AS	
	BEGIN
		DELETE FROM Reparaciones WHERE ReparacionesId = @ReparacionesId
	END

--Fin Borrar--
EXEC BORRAR_REPARACIONES 8

SELECT * FROM Reparaciones

------///////////////////////////////////////////////////////////////////////////////////------

--DetallesReparaciones--
ALTER PROCEDURE BORRAR_DETALLESREPARACION
@DetalleId INT
AS
BEGIN
    -- Eliminar Detalles de Reparación
    DELETE FROM DetallesReparacion WHERE DetalleId = @DetalleId;
END

--Fin Borrar--
EXEC BORRAR_DETALLESREPARACION 100

SELECT *FROM DetallesReparacion

--**************FIN BORRAR_FILTRO_USUARIOS,EQUIPOS,TECNICO...************--
------///////////////////////////////////////////////////////////////////////////////////------

--***************************************************************************--
--*-----------*****-----Procedimiento Agregar*****--------------********--
--***************************************************************************--

------///////////////////////////////////////////////////////////////////////////////////------

--Usuarios--
CREATE PROCEDURE AGREGAR_USUARIO
@Nombre VARCHAR(50),
@CorreoElectronico VARCHAR(50),
@Telefono VARCHAR(15)
AS	
BEGIN
	INSERT INTO Usuarios (Nombre, CorreoElectronico, Telefono)
	VALUES (@Nombre, @CorreoElectronico, @Telefono);
END

EXEC AGREGAR_USUARIO 'John Doe', 'john.doe@example.com', '123456789';

SELECT*FROM Usuarios

------///////////////////////////////////////////////////////////////////////////////////------

--Equipos--
CREATE PROCEDURE AGREGAR_EQUIPO
@TipoEquipo VARCHAR(50),
@Modelo VARCHAR(50),
@UsuarioId INT
AS	
BEGIN
	INSERT INTO Equipos (TipoEquipo, Modelo, UsuarioId)
	VALUES (@TipoEquipo, @Modelo, @UsuarioId);
END

EXEC AGREGAR_EQUIPO 'Laptop', 'HP', 6;

SELECT * FROM Equipos;

------///////////////////////////////////////////////////////////////////////////////////------

--Reparaciones--
CREATE PROCEDURE AGREGAR_REPARACION
@EquipoId INT,
@FechaSolicitud DATETIME,
@Estado CHAR
AS	
BEGIN
	INSERT INTO Reparaciones (EquipoId, FechaSolicitud, Estado)
	VALUES (@EquipoId, @FechaSolicitud, @Estado);
END

EXEC AGREGAR_REPARACION 14, '2023-01-01', 'R';

SELECT * FROM Reparaciones;

------///////////////////////////////////////////////////////////////////////////////////------

--DetalleReparaciones--
CREATE PROCEDURE AGREGAR_DETALLE_REPARACION
@ReparacionId INT,
@Descripcion VARCHAR(50),
@FechaInicio DATETIME,
@FechaFin DATETIME
AS	
BEGIN
	INSERT INTO DetallesReparacion (ReparacionId, Descripcion, FechaInicio, FechaFin)
	VALUES (@ReparacionId, @Descripcion, @FechaInicio, @FechaFin);
END

EXEC AGREGAR_DETALLE_REPARACION 8, 'Battery Replacement', '2023-01-02', '2023-01-03';

SELECT * FROM DetallesReparacion;

------///////////////////////////////////////////////////////////////////////////////////------

--Tecnicos--
CREATE PROCEDURE AGREGAR_TECNICO
@Nombre VARCHAR(50),
@Especialidad VARCHAR(50)
AS	
BEGIN
	INSERT INTO Tecnicos (Nombre, Especialidad)
	VALUES (@Nombre, @Especialidad);
END

EXEC AGREGAR_TECNICO 'Alice Smith', 'Hardware';

SELECT * FROM Tecnicos;

------///////////////////////////////////////////////////////////////////////////////////------

--Asignaciones--
CREATE PROCEDURE AGREGAR_ASIGNACION
@ReparacionId INT,
@TecnicoId INT,
@FechaAsignacion DATETIME
AS	
BEGIN
	INSERT INTO Asignaciones (ReparacionId, TecnicoId, FechaAsignacion)
	VALUES (@ReparacionId, @TecnicoId, @FechaAsignacion);
END

EXEC AGREGAR_ASIGNACION 8, 7, '2023-01-04';

SELECT * FROM Asignaciones;

--**************FIN AGREGAR_USUARIOS,EQUIPOS,TECNICOS...************--
------///////////////////////////////////////////////////////////////////////////////////------

--***************************************************************************--
--*-------------*****-----Procedimiento Modificar*****---------------********--
--***************************************************************************--

------///////////////////////////////////////////////////////////////////////////////////------

--Usuarios--
CREATE PROCEDURE MODIFICAR_USUARIO
@UsuarioId INT,
@Nombre VARCHAR(50),
@CorreoElectronico VARCHAR(50),
@Telefono VARCHAR(15)
AS	
BEGIN
	UPDATE Usuarios
	SET 
		Nombre = @Nombre,
		CorreoElectronico = @CorreoElectronico,
		Telefono = @Telefono
	WHERE UsuarioId = @UsuarioId;
END

EXEC MODIFICAR_USUARIO 9, 'Calamardo Tentaculos', 'updated.email@example.com', '987654321';

SELECT * FROM Usuarios;

------///////////////////////////////////////////////////////////////////////////////////------

--Equipos--
CREATE PROCEDURE MODIFICAR_EQUIPO
@EquipoId INT,
@TipoEquipo VARCHAR(50),
@Modelo VARCHAR(50),
@UsuarioId INT
AS	
BEGIN
	UPDATE Equipos
	SET 
		TipoEquipo = @TipoEquipo,
		Modelo = @Modelo,
		UsuarioId = @UsuarioId
	WHERE EquipoId = @EquipoId;
END

EXEC MODIFICAR_EQUIPO 4, 'Desktop', 'Updated Model', 2;

SELECT * FROM Equipos;

------///////////////////////////////////////////////////////////////////////////////////------

--Reparaciones--
CREATE PROCEDURE MODIFICAR_REPARACION
@ReparacionId INT,
@EquipoId INT,
@FechaSolicitud DATETIME,
@Estado CHAR
AS	
BEGIN
	UPDATE Reparaciones
	SET 
		EquipoId = @EquipoId,
		FechaSolicitud = @FechaSolicitud,
		Estado = @Estado
	WHERE ReparacionesId = @ReparacionId;
END

EXEC MODIFICAR_REPARACION 1, 3, '2023-01-05', 'P';

SELECT * FROM Reparaciones;

------///////////////////////////////////////////////////////////////////////////////////------

--DetalleReparaciones--
CREATE PROCEDURE MODIFICAR_DETALLE_REPARACION
@DetalleId INT,
@ReparacionId INT,
@Descripcion VARCHAR(50),
@FechaInicio DATETIME,
@FechaFin DATETIME
AS	
BEGIN
	UPDATE DetallesReparacion
	SET 
		ReparacionId = @ReparacionId,
		Descripcion = @Descripcion,
		FechaInicio = @FechaInicio,
		FechaFin = @FechaFin
	WHERE DetalleId = @DetalleId;
END

EXEC MODIFICAR_DETALLE_REPARACION 1, 1, 'Updated Description', '2023-01-06', '2023-01-07';

SELECT * FROM DetallesReparacion;

------///////////////////////////////////////////////////////////////////////////////////------

--Tecnicos--
CREATE PROCEDURE MODIFICAR_TECNICO
@TecnicoId INT,
@Nombre VARCHAR(50),
@Especialidad VARCHAR(50)
AS	
BEGIN
	UPDATE Tecnicos
	SET 
		Nombre = @Nombre,
		Especialidad = @Especialidad
	WHERE TecnicoId = @TecnicoId;
END

EXEC MODIFICAR_TECNICO 1, 'Updated Tech', 'Software';

SELECT * FROM Tecnicos;

------///////////////////////////////////////////////////////////////////////////////////------

--Asignaciones--
CREATE PROCEDURE MODIFICAR_ASIGNACION
@AsignacionId INT,
@ReparacionId INT,
@TecnicoId INT,
@FechaAsignacion DATETIME
AS	
BEGIN
	UPDATE Asignaciones
	SET 
		ReparacionId = @ReparacionId,
		TecnicoId = @TecnicoId,
		FechaAsignacion = @FechaAsignacion
	WHERE AsignacionId = @AsignacionId;
END

EXEC MODIFICAR_ASIGNACION 1, 2, 3, '2023-01-08';

SELECT * FROM Asignaciones;



---------------------------------------------Aca termina el script-------------------------------------------

--Verifica que tiene cada tabla--
SELECT *FROM Usuarios
SELECT *FROM Equipos
SELECT *FROM Reparaciones
SELECT *FROM DetallesReparacion
SELECT *FROM Tecnicos
SELECT *FROM Asignaciones
