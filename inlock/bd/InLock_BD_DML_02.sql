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
		('Diablo 3', '� um jogo que cont�m bastante a��o e � viciente, seja voc� um novate ou um f�.', '2012-05-15','99.00','1'),
		('Red Dead Redemption II','Jogo eletr�nico de a��o-aventura western.','2018-10-26','120.00','2');

