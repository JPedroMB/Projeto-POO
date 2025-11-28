using System;
using System.Drawing;
using System.Windows.Forms;

namespace SupermercadoCaixa
{
    public partial class FormVendas : Form
    {
        public FormVendas()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Vendas";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblTitulo = new Label();
            lblTitulo.Text = "Tela de Vendas";
            lblTitulo.Font = new Font("Arial", 20, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(180, 150);
            this.Controls.Add(lblTitulo);

            Label lblInfo = new Label();
            lblInfo.Text = "Funcionalidade em desenvolvimento...";
            lblInfo.Font = new Font("Arial", 12);
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(150, 200);
            this.Controls.Add(lblInfo);
        }
    }
}
