using System;
using System.Drawing;
using System.Windows.Forms;

namespace SupermercadoCaixa
{
    public partial class FormSobre : Form
    {
        public FormSobre()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sobre";
            this.Size = new Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitulo = new Label();
            lblTitulo.Text = "Sistema de Caixa - Supermercado";
            lblTitulo.Font = new Font("Arial", 16, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(80, 50);
            this.Controls.Add(lblTitulo);

            Label lblVersao = new Label();
            lblVersao.Text = "Versão 1.0";
            lblVersao.Font = new Font("Arial", 12);
            lblVersao.AutoSize = true;
            lblVersao.Location = new Point(190, 90);
            this.Controls.Add(lblVersao);

            Label lblDescricao = new Label();
            lblDescricao.Text = "Sistema desenvolvido para gerenciamento\nde produtos e vendas de supermercado.";
            lblDescricao.Font = new Font("Arial", 11);
            lblDescricao.AutoSize = true;
            lblDescricao.Location = new Point(90, 130);
            this.Controls.Add(lblDescricao);

            Label lblAutor = new Label();
            lblAutor.Text = "Desenvolvido em C# com Windows Forms";
            lblAutor.Font = new Font("Arial", 10);
            lblAutor.AutoSize = true;
            lblAutor.Location = new Point(110, 190);
            this.Controls.Add(lblAutor);

            Button btnFechar = new Button();
            btnFechar.Text = "Fechar";
            btnFechar.Location = new Point(200, 240);
            btnFechar.Size = new Size(100, 30);
            btnFechar.Click += (s, e) => this.Close();
            this.Controls.Add(btnFechar);
        }
    }
}
