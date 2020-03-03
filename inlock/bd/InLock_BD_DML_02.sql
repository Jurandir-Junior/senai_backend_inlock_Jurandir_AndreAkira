USE InLock_Games_Manha

INSERT INTO TipoUsuario(Titulo)
VALUES
		('ADMINISTRADOR'),
		('FUNCIONARIO'),
		('CLIENTE');

INSERT INTO Usuario(Email,Senha,IdTipoUsuario)
VALUES
		('admin@admin.com','admin',1),
		('cliente@cliente.com','cliente',3);

INSERT INTO Estudios(NomeEstudio)
VALUES
		('Blizzard'),
		('Rockstar Studio'),
		('Square Enix');

INSERT INTO Jogos(NomeJogo,Descricao,DataLancamento,Valor,IdEstudio)
VALUES
		('Diablo 3', 'É um jogo que contém bastante ação e é viciente, seja você um novate ou um fã.', '2012-05-15','99.00','1'),
		('Red Dead Redemption II','Jogo eletrônico de ação-aventura western.','2018-10-26','120.00','2');

