USE [RateMe]
GO
IF OBJECT_ID('Usuarios') IS  NULL
CREATE TABLE Usuarios(
	Id INT PRIMARY KEY IDENTITY(1,1), 
	Apelido VARCHAR(20) UNIQUE,
	Email VARCHAR(100) UNIQUE,
	Senha VARCHAR(64),
)
GO
IF OBJECT_ID('Sessao') IS  NULL
CREATE TABLE Sessao(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Id_Usuario INT,
	Chave VARCHAR(128),
	DataConexao DATETIME,

	CONSTRAINT FK_Sessao_Usuario FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id)
)
GO
IF OBJECT_ID('Categorias') IS  NULL
CREATE TABLE Categorias(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Descricao VARCHAR(100),
)
GO
IF OBJECT_ID('Genero') IS  NULL
CREATE TABLE Genero(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Descricao VARCHAR(100),
)
GO
IF OBJECT_ID('TipoParticipacaoElenco') IS  NULL
CREATE TABLE TipoParticipacaoElenco(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Descricao VARCHAR(100),
)
GO
IF OBJECT_ID('Elenco') IS  NULL
CREATE TABLE Elenco(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Nome VARCHAR(100),
)


GO
IF OBJECT_ID('Catalogo') IS  NULL
CREATE TABLE Catalogo(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Titulo VARCHAR(50),
	Descricao VARCHAR(800),
)

GO
IF OBJECT_ID('Catalogo_Genero') IS  NULL
CREATE TABLE Catalogo_Genero(
	Id_Catalogo INT,
	Id_Genero INT,

	CONSTRAINT FK_Catalogo__Genero_Catalogo FOREIGN KEY (Id_Catalogo) REFERENCES Catalogo(Id),
	CONSTRAINT FK_Catalogo__Genero_Genero FOREIGN KEY (Id_Genero) REFERENCES Genero(Id)
)
GO
IF OBJECT_ID('Catalogo_Categorias') IS  NULL
CREATE TABLE Catalogo_Categorias(
	Id_Catalogo INT,
	Id_Categoria INT,

	CONSTRAINT FK_Catalogo__Categorias_Catalogo FOREIGN KEY (Id_Catalogo) REFERENCES Catalogo(Id),
	CONSTRAINT FK_Catalogo__Categorias_Categoria FOREIGN KEY (Id_Categoria) REFERENCES Categorias(Id),
)
GO
IF OBJECT_ID('Catalogo_Elenco') IS  NULL
CREATE TABLE Catalogo_Elenco(
	Id_Catalogo INT,
	Id_Elenco INT,
	Id_TipoParticipacao INT,

	CONSTRAINT FK_Catalogo__Elenco_Catalogo FOREIGN KEY (Id_Catalogo) REFERENCES Catalogo(Id),
	CONSTRAINT FK_Catalogo__Elenco_Elenco FOREIGN KEY (Id_Elenco) REFERENCES  Elenco(Id),
	CONSTRAINT FK_Catalogo__TipoParticipacao FOREIGN KEY (Id_TipoParticipacao) REFERENCES TipoParticipacaoElenco(Id)
)
GO
IF NOT EXISTS(SELECT * FROM Categorias)
BEGIN
INSERT INTO Categorias(Descricao) VALUES ('Filme')
INSERT INTO Categorias(Descricao) VALUES ('Série')
INSERT INTO Categorias(Descricao) VALUES ('Anime')
END
GO
IF NOT EXISTS(SELECT * FROM Genero)
BEGIN
INSERT INTO Genero(Descricao) VALUES('Suspense')
INSERT INTO Genero(Descricao) VALUES('Terror')
INSERT INTO Genero(Descricao) VALUES('Ação')
INSERT INTO Genero(Descricao) VALUES('Aventura')
END
GO
IF OBJECT_ID('Pontuacao') IS NULL
CREATE TABLE Pontuacao (
	Id INT PRIMARY KEY IDENTITY(1,1),
	Pontuacao INT NOT NULL,
	Descricao VARCHAR(100) NOT NULL,
)
GO
IF NOT EXISTS(SELECT * FROM Pontuacao)
BEGIN
INSERT INTO Pontuacao(Pontuacao,Descricao) VALUES(1,'Muito ruim')
INSERT INTO Pontuacao(Pontuacao,Descricao) VALUES(2,'Ruim')
INSERT INTO Pontuacao(Pontuacao,Descricao) VALUES(3,'Neutro')
INSERT INTO Pontuacao(Pontuacao,Descricao) VALUES(4,'Bom')
INSERT INTO Pontuacao(Pontuacao,Descricao) VALUES(5,'Muito Bom')
END
GO
IF OBJECT_ID('AvaliacaoCatalogo') IS  NULL
CREATE TABLE AvaliacaoCatalogo(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Id_Usuario INT NOT NULL,
	Id_Catalogo INT NOT NULL,
	Pontuacao INT NOT NULL
)
IF OBJECT_ID('Comentario') IS NULL
CREATE TABLE Comentario
(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Id_Usuario INT,
	Id_Catalogo INT,
	Id_ComentarioRaiz INT,
	Texto VARCHAR(1000)

	CONSTRAINT FK_Comentario_Usuario FOREIGN KEY (Id_Usuario) REFERENCES Usuarios(Id),
	CONSTRAINT FK_Comentario_Catalogo FOREIGN KEY (Id_Catalogo) REFERENCES Catalogo(Id),
	CONSTRAINT FK_Comentario_ComentarioRaiz FOREIGN KEY (Id_ComentarioRaiz) REFERENCES Comentario(Id)
)
IF NOT EXISTS (SELECT * FROM Catalogo)
BEGIN
	INSERT INTO Catalogo(Titulo,Descricao) VALUES('Teste1','teste1')
	INSERT INTO Catalogo(Titulo,Descricao) VALUES('Teste2','teste2')
	INSERT INTO Catalogo(Titulo,Descricao) VALUES('Teste3','teste3')
	INSERT INTO Catalogo(Titulo,Descricao) VALUES('Teste4','teste4')
	INSERT INTO Catalogo(Titulo,Descricao) VALUES('Teste5','teste5')
END