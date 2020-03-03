USE InLock_Games_Manha

SELECT * FROM Usuario;
SELECT * FROM Estudios;
SELECT * FROM Jogos;

SELECT IdJogos, NomeEstudio,NomeJogo,Descricao,DataLancamento,Valor FROM Jogos
INNER JOIN Estudios ON Estudios.IdEstudio = Jogos.IdEstudio;

SELECT * FROM Estudios
LEFT JOIN Jogos ON Estudios.IdEstudio = IdJogos;

SELECT * FROM Usuario WHERE Email LIKE 'admin%';
SELECT * FROM Jogos WHERE IdJogos LIKE '1';
SELECT * FROM Estudios WHERE IdEstudio LIKE '1';