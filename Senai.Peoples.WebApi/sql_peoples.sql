CREATE DATABASE M_Peoples
USE M_Peoples

create table Funcionarios (
IdFuncionario INT PRIMARY KEY IDENTITY
,Nome VARCHAR(200) NOT NULL
,Sobrenome VARCHAR(200) 
);

INSERT INTO Funcionarios (Nome,Sobrenome)
VALUES ('Catarina', 'Strada'),('Tadeu', 'Vitelli'),('Roberta', 'Guimarães')

SELECT * FROM Funcionarios order by IdFuncionario desc

ALTER TABLE Funcionarios ADD DataNascimento DATETIME
 