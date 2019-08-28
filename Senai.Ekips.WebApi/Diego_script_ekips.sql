--DDL
create database M_Ekips
use M_Ekips

create table Cargos (
IdCargo INT PRIMARY KEY IDENTITY,
Cargo VARCHAR(200) UNIQUE NOT NULL,
Ativo VARCHAR (200) NOT NULL
);

create table Departamentos (
IdDepartamento INT PRIMARY KEY IDENTITY,
Departamento VARCHAR(200)
);

create table Usuarios (
IdUsuario INT PRIMARY KEY IDENTITY,
Email VARCHAR(200) NOT NULL UNIQUE,
Senha VARCHAR(200) NOT NULL,
Permissao VARCHAR(200) NOT NULL
);

create table Funcionarios (
IdFuncionario INT PRIMARY KEY IDENTITY,
Nome VARCHAR(200) NOT NULL,
CPF INT UNIQUE,
DataNascimento DATE,
Salario INT NOT NULL,
IdDepartamento INT FOREIGN KEY REFERENCES Departamentos (IdDepartamento),
IdCargo INT FOREIGN KEY REFERENCES Cargos (IdCargo),
IdUsuario INT FOREIGN KEY REFERENCES Usuarios (IdUsuario)
);

--///////////////////////////////////////////////////////////////////////////////////////////

--DML
insert into Departamentos (Departamento) values('Administração'),('Segurança'),('Limpeza'),('Manutenção')

insert into Cargos (Cargo, Ativo) values ('Limpeza de interiores','ATIVO'),('Limpeza externa','DESATIVADO'),('Admnistração geral','ATIVO'),('Ronda externa','ATIVO'),('Manutenção de eletrônicos','ATIVO'),('Manutenção de banheiros','DESATIVADO')

insert into Usuarios (Email, Senha, Permissao) values ('diego@gmail.com','12345','ADMINISTRADOR'),('raul@gmail.com','54321','USUARIO'),('renata@gmail.com','55555','USUARIO')

insert into Funcionarios (Nome,CPF, DataNascimento, Salario, IdDepartamento ,IdCargo, IdUsuario) values ('Roberta',222222222,'1990-07-10',3000,3,2,2),
																										('Everton',333333333,'1985-05-09',1500,4,5,3)


--///////////////////////////////////////////////////////////////////////////////////////////

--DQL
select * from Departamentos
select * from Cargos
select * from Usuarios
select * from Funcionarios

select Funcionarios.Nome, Funcionarios.CPF, Funcionarios.DataNascimento, Funcionarios.Salario, Departamentos.Departamento, Cargos.Cargo, Usuarios.Email
from Funcionarios
join Departamentos
on Funcionarios.IdDepartamento = Departamentos.IdDepartamento
join Cargos
on Funcionarios.IdCargo = Cargos.IdCargo
join Usuarios
on Funcionarios.IdUsuario = Usuarios.IdUsuario
																										
																										

