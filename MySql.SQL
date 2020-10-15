CREATE DATABASE BaseProdutos;
USE BaseProdutos;

CREATE TABLE Categoria 
(
	IdCategoria INT auto_increment primary key,
	Nome VARCHAR(100) UNIQUE NOT NULL,
	DataCadastro DATETIME NOT NULL,
	DataAlteracao DATETIME NULL
);

CREATE TABLE Produto 
(
	IdProduto INT auto_increment primary key,
	IdCategoria INT NOT NULL,
    foreign key (IdCategoria) references Categoria(IdCategoria),
	Nome VARCHAR(100) NOT NULL,
	Valor DECIMAL(10,2) NOT NULL,
	DataCadastro DATETIME NOT NULL,
	DataAlteracao DATETIME NULL
);

INSERT INTO Categoria
(Nome, DataCadastro)
Values
('Carro', now()),
('Moto', now());

INSERT INTO Produto
(IdCategoria, Nome, Valor, DataCadastro)
VALUES
((SELECT IdCategoria FROM Categoria Where Nome = 'Carro'), 'Gol', 30000, now()),
((SELECT IdCategoria FROM Categoria Where Nome = 'Carro'), 'Astra', 25000, now()),
((SELECT IdCategoria FROM Categoria Where Nome = 'Carro'), 'Montana', 23000, now()),
((SELECT IdCategoria FROM Categoria Where Nome = 'Moto'), 'Titan', 9000, now()),
((SELECT IdCategoria FROM Categoria Where Nome = 'Moto'), 'Tornado', 10000, now()),
((SELECT IdCategoria FROM Categoria Where Nome = 'Moto'), 'Falcon', 11000, now());
