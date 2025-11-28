using System;
using System.Drawing;
using System.Windows.Forms;

namespace SupermercadoCaixa
{
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sistema de Caixa - Supermercado";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Menu Superior
            MenuStrip menuStrip = new MenuStrip();
            
            // Menu Cadastros
            ToolStripMenuItem menuCadastros = new ToolStripMenuItem("Cadastros");
            ToolStripMenuItem menuProdutos = new ToolStripMenuItem("Produtos");
            menuProdutos.Click += MenuProdutos_Click;
            menuCadastros.DropDownItems.Add(menuProdutos);
            
            // Menu Vendas
            ToolStripMenuItem menuVendas = new ToolStripMenuItem("Vendas");
            menuVendas.Click += MenuVendas_Click;
            
            // Menu Relatórios
            ToolStripMenuItem menuRelatorios = new ToolStripMenuItem("Relatórios");
            menuRelatorios.Click += MenuRelatorios_Click;
            
            // Menu Sobre
            ToolStripMenuItem menuSobre = new ToolStripMenuItem("Sobre");
            menuSobre.Click += MenuSobre_Click;
            
            menuStrip.Items.Add(menuCadastros);
            menuStrip.Items.Add(menuVendas);
            menuStrip.Items.Add(menuRelatorios);
            menuStrip.Items.Add(menuSobre);
            
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);

            // Label de boas-vindas
            Label lblTitulo = new Label();
            lblTitulo.Text = "Bem-vindo ao Sistema de Caixa";
            lblTitulo.Font = new Font("Arial", 24, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(200, 200);
            this.Controls.Add(lblTitulo);

            Label lblInstrucoes = new Label();
            lblInstrucoes.Text = "Utilize o menu acima para acessar as funcionalidades";
            lblInstrucoes.Font = new Font("Arial", 12);
            lblInstrucoes.AutoSize = true;
            lblInstrucoes.Location = new Point(230, 250);
            this.Controls.Add(lblInstrucoes);
        }

        private void MenuProdutos_Click(object sender, EventArgs e)
        {
            FormProdutos formProdutos = new FormProdutos();
            formProdutos.ShowDialog();
        }

        private void MenuVendas_Click(object sender, EventArgs e)
        {
            FormVendas formVendas = new FormVendas();
            formVendas.ShowDialog();
        }

        private void MenuRelatorios_Click(object sender, EventArgs e)
        {
            FormRelatorios formRelatorios = new FormRelatorios();
            formRelatorios.ShowDialog();
        }

        private void MenuSobre_Click(object sender, EventArgs e)
        {
            FormSobre formSobre = new FormSobre();
            formSobre.ShowDialog();
        }
    }
}
