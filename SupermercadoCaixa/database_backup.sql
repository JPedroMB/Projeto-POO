-- Script de criação do banco de dados SQLite
-- Sistema de Caixa de Supermercado

-- Tabela de Produtos
CREATE TABLE IF NOT EXISTS Produtos (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Nome TEXT NOT NULL,
    Preco REAL NOT NULL,
    Quantidade INTEGER NOT NULL
);

-- Dados de exemplo
INSERT INTO Produtos (Nome, Preco, Quantidade) VALUES 
('Arroz 5kg', 25.90, 50),
('Feijão 1kg', 8.50, 30),
('Macarrão 500g', 4.20, 100),
('Óleo de Soja 900ml', 6.80, 40),
('Açúcar 1kg', 5.30, 60),
('Café 500g', 12.90, 25),
('Leite 1L', 4.50, 80),
('Sabão em Pó 1kg', 11.20, 35);
