using System;
using System.Data.SQLite;
using System.IO;

namespace SupermercadoCaixa
{
    public static class Database
    {
        private static string connectionString = "Data Source=supermercado.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static void InitializeDatabase()
        {
            if (!File.Exists("supermercado.db"))
            {
                SQLiteConnection.CreateFile("supermercado.db");
            }

            using (var conn = GetConnection())
            {
                conn.Open();

                string createTableProdutos = @"
                    CREATE TABLE IF NOT EXISTS Produtos (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Nome TEXT NOT NULL,
                        Preco REAL NOT NULL,
                        Quantidade INTEGER NOT NULL
                    )";

                using (var cmd = new SQLiteCommand(createTableProdutos, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                // Insere alguns produtos de exemplo se a tabela estiver vazia
                string checkData = "SELECT COUNT(*) FROM Produtos";
                using (var cmd = new SQLiteCommand(checkData, conn))
                {
                    long count = (long)cmd.ExecuteScalar();
                    if (count == 0)
                    {
                        string insertSample = @"
                            INSERT INTO Produtos (Nome, Preco, Quantidade) VALUES 
                            ('Arroz 5kg', 25.90, 50),
                            ('Feijão 1kg', 8.50, 30),
                            ('Macarrão 500g', 4.20, 100),
                            ('Óleo de Soja 900ml', 6.80, 40)";
                        
                        using (var cmdInsert = new SQLiteCommand(insertSample, conn))
                        {
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }
}
