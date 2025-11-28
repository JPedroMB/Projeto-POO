# Sistema de Caixa de Supermercado

Esse read.me foi feito com a ajuda da IA (Claude).

Sistema desenvolvido em C# com Windows Forms para gerenciamento de produtos de supermercado.

## Funcionalidades

- ✅ **CRUD de Produtos** - Cadastro completo com Create, Read, Update e Delete
- ✅ **Menu com 4 telas** - Produtos, Vendas, Relatórios e Sobre
- ✅ **Banco de dados SQLite** - Armazenamento local dos dados
- ✅ **Interface simples e funcional**

## Requisitos

- .NET 6.0 ou superior
- Windows (para executar Windows Forms)
- Visual Studio 2022 ou superior (recomendado)

## Como executar

1. Clone o repositório:
```bash
git clone [url-do-repositorio]
```

2. Abra o projeto no Visual Studio:
   - Abra o arquivo `SupermercadoCaixa.csproj`

3. Restaure os pacotes NuGet (o Visual Studio faz automaticamente)

4. Execute o projeto (F5)

## Estrutura do Projeto

```
SupermercadoCaixa/
├── Program.cs              # Ponto de entrada da aplicação
├── Database.cs             # Gerenciamento do banco SQLite
├── Produto.cs              # Classe modelo Produto
├── FormPrincipal.cs        # Tela principal com menu
├── FormProdutos.cs         # Tela de CRUD de produtos
├── FormVendas.cs           # Tela de vendas
├── FormRelatorios.cs       # Tela de relatórios
├── FormSobre.cs            # Tela sobre o sistema
└── database_backup.sql     # Script de backup do banco
```

## Banco de Dados

O sistema utiliza SQLite e cria automaticamente o arquivo `supermercado.db` na primeira execução.

Para restaurar o banco a partir do backup:
```bash
sqlite3 supermercado.db < database_backup.sql
```

## Funcionalidades do CRUD de Produtos

- **Create (Criar)**: Adicionar novos produtos com nome, preço e quantidade
- **Read (Ler)**: Visualizar todos os produtos cadastrados em uma grade
- **Update (Atualizar)**: Editar informações de produtos existentes
- **Delete (Excluir)**: Remover produtos do sistema

## Tecnologias Utilizadas

- C# 10
- .NET 6.0
- Windows Forms
- SQLite
- System.Data.SQLite

## Observações

- As telas de Vendas e Relatórios estão preparadas para implementação futura
- O banco de dados vem com produtos de exemplo pré-cadastrados
- O sistema valida todos os campos antes de inserir ou atualizar dados

## Autor

Projeto desenvolvido para disciplina de Redes de Computadores
