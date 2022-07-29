USE [ricashowbot]
GO
PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Criação da tabela Form.');
IF EXISTS(
    SELECT TOP(1) 1
    FROM sys.all_objects 
    WHERE Object_ID = Object_ID(N'Form'))
BEGIN
	PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-.  já executado!');
	RETURN;
END

--INICIO DO SCRIPT

CREATE TABLE Form(
	FormId INT IDENTITY (1,1) PRIMARY KEY NOT NULL,
	Email NVARCHAR(40) NOT NULL,
	Senha NVARCHAR(40) NOT NULL,
	Nif VARCHAR(8) NOT NULL,
	DataNascimento DATE NOT NULL,
    DataInclusao DATE NOT NULL,
	Nome VARCHAR(40) NOT NULL
)

--FIM DO 

PRINT(DB_NAME() + ' .. ' + CONVERT(VARCHAR, GETDATE(), 20) + '.-. Executado com sucesso.');

