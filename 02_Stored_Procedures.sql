CREATE PROCEDURE spAgregar
    @Id INT,
    @Nombre VARCHAR(255),
    @Descripcion VARCHAR(255)
AS
BEGIN
    DECLARE @CodigoRetorno INT;
    DECLARE @DescripcionRetorno NVARCHAR(255);

    BEGIN TRY
        INSERT INTO tblExamen (idExamen, Nombre, Descripcion)
        VALUES (@Id, @Nombre, @Descripcion);

        SET @CodigoRetorno = 0;
        SET @DescripcionRetorno = 'Registro insertado satisfactoriamente';
    END TRY
    BEGIN CATCH
        SET @CodigoRetorno = ERROR_NUMBER();
        SET @DescripcionRetorno = ERROR_MESSAGE();
    END CATCH

    -- Devolver resultados
    SELECT @CodigoRetorno AS CodigoRetorno, @DescripcionRetorno AS DescripcionRetorno;
END;
GO

CREATE PROCEDURE spActualizar
    @Id INT,
    @Nombre VARCHAR(255),
    @Descripcion VARCHAR(255)
AS
BEGIN
    DECLARE @CodigoRetorno INT;
    DECLARE @DescripcionRetorno NVARCHAR(255);

    BEGIN TRY
        UPDATE tblExamen
        SET Nombre = @Nombre,
            Descripcion = @Descripcion
        WHERE idExamen = @Id;

        SET @CodigoRetorno = 0;
        SET @DescripcionRetorno = 'Registro actualizado satisfactoriamente';
    END TRY
    BEGIN CATCH
        SET @CodigoRetorno = ERROR_NUMBER();
        SET @DescripcionRetorno = ERROR_MESSAGE();
    END CATCH

    -- Devolver resultados
    SELECT @CodigoRetorno AS CodigoRetorno, @DescripcionRetorno AS DescripcionRetorno;
END;
GO


CREATE PROCEDURE spEliminar
    @Id INT
AS
BEGIN
    DECLARE @CodigoRetorno INT;
    DECLARE @DescripcionRetorno NVARCHAR(255);

    BEGIN TRY
        DELETE FROM tblExamen
        WHERE idExamen = @Id;

        SET @CodigoRetorno = 0;
        SET @DescripcionRetorno = 'Registro eliminado satisfactoriamente';
    END TRY
    BEGIN CATCH
        SET @CodigoRetorno = ERROR_NUMBER();
        SET @DescripcionRetorno = ERROR_MESSAGE();
    END CATCH

    -- Devolver resultados
    SELECT @CodigoRetorno AS CodigoRetorno, @DescripcionRetorno AS DescripcionRetorno;
END;
GO

CREATE PROCEDURE spConsultar
    @Nombre VARCHAR(255) = NULL,
    @Descripcion VARCHAR(255) = NULL
AS
BEGIN
    SELECT idExamen, Nombre, Descripcion
    FROM tblExamen
    WHERE (@Nombre IS NULL OR Nombre = @Nombre)
      AND (@Descripcion IS NULL OR Descripcion = @Descripcion);
END;
GO

/*

	select * from tblExamen
	Uso de los procedimientos almacenados

	EXEC spAgregar 
    @Id = 1,
    @Nombre = 'NombreEjemplo',
    @Descripcion = null
    ;

	EXEC spActualizar 
    @Id = 1,
    @Nombre = 'NuevoNombre',
    @Descripcion = 'NuevaDescripcion'
    ;

	EXEC spEliminar 
    @Id = 1;

	EXEC spConsultar 
    @Nombre = 'NombreEjemplo',
    @Descripcion = 'DescripcionEjemplo';

*/

