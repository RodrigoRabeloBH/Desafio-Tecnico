# Desafio-Tecnico

## Andes de executar a aplicação se assegure de executar o script abaixo:

### /* CRIA O BANCO DE DADOS */

 1. CREATE DATABASE STORE
 2. GO
### /* SELECIONA O BANCO */
 3. USE STORE
 4. GO

### /* CRIA A TABELA*/
6. CREATE TABLE PRODUCT(
7. Id INT NOT NULL IDENTITY,
8. Name VARCHAR(60) NOT NULL,
9. Description VARCHAR(200) NOT NULL,
10. CreatedAt Date NOT NULL,
11. Price Float NOT NULL,
12. Quantity Float NOT NULL,
13. )
13. GO

