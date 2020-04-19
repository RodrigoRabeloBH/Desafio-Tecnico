# Desafio-Tecnico

Andes de executar a aplicação se assegure de executar o script abaixo:

/* CRIA O BANCO DE DADOS */

CREATE DATABASE STORE
GO

/* SELECIONA O BANCO */
USE STORE
GO

/* CRIA A TABELA*/
CREATE TABLE PRODUCT(
Id INT NOT NULL IDENTITY,
Name VARCHAR(60) NOT NULL,
Description VARCHAR(200) NOT NULL,
CreatedAt Date NOT NULL,
Price Float NOT NULL,
Quantity Float NOT NULL,
)
GO
