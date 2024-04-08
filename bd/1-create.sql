-- Crear la base de datos llamada 'prueba'
CREATE DATABASE IF NOT EXISTS prueba;

-- Usar la base de datos 'prueba'
USE prueba;

-- Crear la tabla 'departamentos'
CREATE TABLE IF NOT EXISTS departamentos (
id INT AUTO_INCREMENT PRIMARY KEY,
codigo VARCHAR(255),
nombre VARCHAR(255),
activo BOOLEAN,
idUsuarioCreacion INT
);

-- Crear la tabla 'cargos'
CREATE TABLE IF NOT EXISTS cargos (
id INT AUTO_INCREMENT PRIMARY KEY,
codigo VARCHAR(255),
nombre VARCHAR(255),
activo BOOLEAN,
idUsuarioCreacion INT
);

-- Crear la tabla 'users'
CREATE TABLE IF NOT EXISTS users (
id INT AUTO_INCREMENT PRIMARY KEY,
usuario VARCHAR(255),
primerNombre VARCHAR(255),
segundoNombre VARCHAR(255),
primerApellido VARCHAR(255),
segundoApellido VARCHAR(255),
email VARCHAR(255),
idDepartamento INT,
idCargo INT,
activo BOOLEAN
);