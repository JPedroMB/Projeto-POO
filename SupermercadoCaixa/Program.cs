using System;
using System.Windows.Forms;

namespace SupermercadoCaixa
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            // Inicializa o banco de dados
            Database.InitializeDatabase();
            
            Application.Run(new FormPrincipal());
        }
    }
}
