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
Price Decimal NOT NULL,
Quantity Decimal NOT NULL,
)
GO


      