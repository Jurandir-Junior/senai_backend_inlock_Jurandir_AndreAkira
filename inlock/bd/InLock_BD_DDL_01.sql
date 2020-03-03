USE MASTER

DROP DATABASE InLock_Games_Manha

CREATE DATABASE InLock_Games_Manha

USE InLock_Games_Manha

CREATE TABLE Estudios(
	IdEstudio INT PRIMARY KEY IDENTITY NOT NULL,
	NomeEstudio VARCHAR (200) NOT NULL
);

CREATE TABLE Jogos(
	IdJogos INT PRIMARY KEY IDENTITY NOT NULL,
	NomeJogo VARCHAR (200) NOT NULL,
	Descricao VARCHAR (200) NOT NULL,
	DataLancamento DATE,
	Valor REAL,
	IdEstudio INT FOREIGN KEY REFERENCES Estudios (IdEstudio)
);

CREATE TABLE TipoUsuario(
	IdTipoUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	Titulo VARCHAR(200)
);

CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	Email VARCHAR(200) NOT NULL,
	Senha VARCHAR(200),
	IdTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (IdTipoUsuario)
);