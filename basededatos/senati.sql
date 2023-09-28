
CREATE TABLE Alumno(  
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY,  
    dni varchar(8) NOT NULL,  
    nombres varchar(50) NOT NULL,  
    apellidos varchar(50) NOT NULL,
    CONSTRAINT uc_DNI UNIQUE (dni)  
)
GO
INSERT INTO Alumno VALUES('40689783','JUAN','PEREZ')
GO
CREATE TABLE Usuario(  
    id int IDENTITY(1,1) NOT NULL PRIMARY KEY,  
    usuario varchar(50) NOT NULL,  
    contrasenia varchar(50) NOT NULL  
)
GO
INSERT INTO Usuario VALUES('jorge','jorge1')
GO
--PROCEDIMIENTOS ALMACENADOS
CREATE PROCEDURE insertarAlumno 
(
    @Dni varchar(8),
    @Nombres varchar(50),
    @Apellidos varchar(50)
)   
AS  
BEGIN  
    
    SET NOCOUNT OFF;

    INSERT INTO Alumno VALUES(@Dni,@Nombres,@Apellidos)

END
GO
CREATE PROCEDURE Logeo
(
    @Usuario varchar(20),
    @Contrasenia varchar(20)
)    
AS  
BEGIN  
    
    SET NOCOUNT ON;

    SELECT *  FROM Usuario WHERE usuario=@Usuario and contrasenia=@Contrasenia

END
GO
CREATE PROCEDURE obtenerTodosAlumnos    
AS  
BEGIN  
    
    SET NOCOUNT ON;

    SELECT * from Alumno ORDER BY id DESC;

END  
GO
CREATE PROCEDURE buscarAlumnoByTipoAndParametro 
(
	@Tipo int,
    @Parametro varchar(50)
)   
AS  
BEGIN  
    
    SET NOCOUNT ON;

	-- DNI
	IF @Tipo = 1  
    BEGIN
		SELECT * FROM Alumno WHERE dni LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END
    IF @Tipo = 2  
    BEGIN
		SELECT * FROM Alumno WHERE nombres LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END
	IF @Tipo = 3  
    BEGIN
		SELECT * FROM Alumno WHERE apellidos LIKE '%'+@Parametro+'%' ORDER BY id DESC;
	END

END  
GO
CREATE PROCEDURE editarAlumno 
	-- Add the parameters for the stored procedure here
	@Id int,
	@Dni varchar(8),
    @Nombres varchar(50),
    @Apellidos varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT OFF;

    -- Insert statements for procedure here
	UPDATE Alumno SET dni =@Dni , nombres = @Nombres,apellidos=@Apellidos WHERE id=@Id
END
GO