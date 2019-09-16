
USE M_OpFlix
SELECT * FROM Produtoras ORDER BY IdProdutora ASC
SELECT * FROM Plataformas ORDER BY IdPlataforma ASC
SELECT * FROM TiposTitulo ORDER BY IdTipoTitulo ASC
SELECT * FROM Categorias ORDER BY IdCategoria ASC
SELECT * FROM Usuarios ORDER BY IdUsuario ASC
SELECT * FROM Titulos ORDER BY IdTitulo ASC
SELECT * FROM Favoritos



CREATE PROCEDURE VerTitulos 
AS
SELECT Titulos.Nome, Titulos.Sinopse, Titulos.Duracao, 
TiposTitulo.IdTipoTitulo, Categorias.Categoria, 
Plataformas.Plataforma, Produtoras.Produtora

FROM Titulos
FULL JOIN TiposTitulo
ON Titulos.IdTipoTitulo = TiposTitulo.IdTipoTitulo
FULL JOIN Categorias
ON Categorias.IdCategoria = Titulos.IdCategoria
FULL JOIN Plataformas
ON Plataformas.IdPlataforma = Titulos.IdPlataforma
FULL JOIN Produtoras
ON Produtoras.IdProdutora = Titulos.IdProdutora

EXEC VerTitulos; --Proc para ver todos os títulos e suas respectivas características



CREATE PROCEDURE VerOsFilmesPreferidos
AS
SELECT Titulos.Nome, Usuarios.Nome, Favoritos.IdUsuario

FROM Titulos
JOIN Favoritos
ON Titulos.IdTitulo = Favoritos.IdTitulo
JOIN Usuarios
ON Usuarios.IdUsuario = Favoritos.IdUsuario

EXEC VerOsFilmesPreferidos --Mostra os títulos e os usuários que tornaram favoritos


SELECT COUNT(*) AS QuantidadeDeUsuarios FROM Usuarios; --Mostra a quantidade de usuários cadastrados
SELECT COUNT(*) AS QuantidadeDeTitulos FROM Titulos; --Mostra a quantidade de titulos cadastrados


CREATE PROCEDURE BuscarFilmePorCategoria
@Categoria VARCHAR(250)
AS
SELECT Titulos.Nome, Categorias.Categoria
FROM Titulos 
JOIN Categorias
ON Titulos.IdCategoria = Categorias.IdCategoria
WHERE Categoria = @Categoria; 

EXEC BuscarFilmePorCategoria 'Ação' --Busca o título pela categoria

CREATE PROCEDURE SelecionarQntdTitulosPorIdCategoria
@IdCategoria INT
AS
SELECT COUNT(*) AS QuantidadeDeTitulosPorIdCategoria 
FROM Titulos
WHERE IdCategoria = @IdCategoria; 

EXEC SelecionarQntdTitulosPorIdCategoria 5 --Mostra a quantidade de títulos de um Id de determinada Categoria


CREATE VIEW GenerosNasPlataformas
AS 
SELECT  Plataformas.IdPlataforma , Categorias.Categoria
FROM Plataformas 
JOIN Titulos
ON Plataformas.IdPlataforma = Titulos.IdPlataforma
JOIN Categorias
ON Categorias.IdCategoria = Titulos.IdCategoria
SELECT * FROM GenerosNasPlataformas WHERE IdPlataforma = 4 --View que mostra as categorias que passam em cada plataforma por categoria




CREATE PROCEDURE MostrarQuantosDiasFaltam
AS
SELECT Titulos.Nome, 
CASE
    WHEN DATEDIFF(DAY, GETDATE(), Titulos.DataLancamento) < 0 THEN  CAST(0 AS VARCHAR(200))
    ELSE DATEDIFF(DAY, GETDATE(), Titulos.DataLancamento)
END AS 'Dias Restanteasadadds'

FROM Titulos

EXEC  MostrarQuantosDiasFaltam --Mostra quantos dias faltam para o lançamento do título
















