-- Crear la base de datos si no existe
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'BdiExamen')
CREATE DATABASE BdiExamen;
GO

USE BdiExamen;
GO

-- drop table tblExamen
-- Crear la tabla tblExamen
CREATE TABLE tblExamen (
    idExamen INT NOT NULL PRIMARY KEY,
    Nombre VARCHAR(255) NULL,
    Descripcion VARCHAR(255) NULL
);

