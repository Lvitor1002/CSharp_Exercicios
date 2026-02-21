namespace PDV
{
    partial class formPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formPrincipal));
            this.MenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.MenuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastrosFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastrosClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastrosUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastrosCargos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastrosFornecedor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutosProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutosEstoque = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoviFluxo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoviLancaVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoviInOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMoviDespesas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRelatorio = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorioProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorioVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorioInOut = new System.Windows.Forms.ToolStripMenuItem();
            this.menuRelatorioDespesas = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.img3 = new System.Windows.Forms.PictureBox();
            this.MenuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img3)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuPrincipal
            // 
            this.MenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuCadastro,
            this.toolStripMenuItem2,
            this.menuMoviFluxo,
            this.MenuRelatorio,
            this.MenuSair});
            this.MenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MenuPrincipal.Name = "MenuPrincipal";
            this.MenuPrincipal.Size = new System.Drawing.Size(497, 26);
            this.MenuPrincipal.TabIndex = 0;
            this.MenuPrincipal.Text = "menuStrip1";
            // 
            // MenuCadastro
            // 
            this.MenuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastrosFuncionario,
            this.menuCadastrosClientes,
            this.menuCadastrosUsuarios,
            this.menuCadastrosCargos,
            this.menuCadastrosFornecedor});
            this.MenuCadastro.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuCadastro.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.MenuCadastro.Name = "MenuCadastro";
            this.MenuCadastro.Size = new System.Drawing.Size(93, 22);
            this.MenuCadastro.Text = "Cadastros";
            // 
            // menuCadastrosFuncionario
            // 
            this.menuCadastrosFuncionario.Name = "menuCadastrosFuncionario";
            this.menuCadastrosFuncionario.Size = new System.Drawing.Size(166, 22);
            this.menuCadastrosFuncionario.Text = "Funcionários";
            this.menuCadastrosFuncionario.Click += new System.EventHandler(this.menuCadastrosFuncionario_Click);
            // 
            // menuCadastrosClientes
            // 
            this.menuCadastrosClientes.Name = "menuCadastrosClientes";
            this.menuCadastrosClientes.Size = new System.Drawing.Size(166, 22);
            this.menuCadastrosClientes.Text = "Clientes";
            this.menuCadastrosClientes.Click += new System.EventHandler(this.menuCadastrosClientes_Click);
            // 
            // menuCadastrosUsuarios
            // 
            this.menuCadastrosUsuarios.Name = "menuCadastrosUsuarios";
            this.menuCadastrosUsuarios.Size = new System.Drawing.Size(166, 22);
            this.menuCadastrosUsuarios.Text = "Usuários";
            // 
            // menuCadastrosCargos
            // 
            this.menuCadastrosCargos.Name = "menuCadastrosCargos";
            this.menuCadastrosCargos.Size = new System.Drawing.Size(166, 22);
            this.menuCadastrosCargos.Text = "Cargos";
            this.menuCadastrosCargos.Click += new System.EventHandler(this.menuCadastrosCargos_Click);
            // 
            // menuCadastrosFornecedor
            // 
            this.menuCadastrosFornecedor.Name = "menuCadastrosFornecedor";
            this.menuCadastrosFornecedor.Size = new System.Drawing.Size(166, 22);
            this.menuCadastrosFornecedor.Text = "Fornecedor";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuProdutosProdutos,
            this.menuProdutosEstoque});
            this.toolStripMenuItem2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem2.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(83, 22);
            this.toolStripMenuItem2.Text = "Produtos";
            // 
            // menuProdutosProdutos
            // 
            this.menuProdutosProdutos.Name = "menuProdutosProdutos";
            this.menuProdutosProdutos.Size = new System.Drawing.Size(139, 22);
            this.menuProdutosProdutos.Text = "Produtos";
            // 
            // menuProdutosEstoque
            // 
            this.menuProdutosEstoque.Name = "menuProdutosEstoque";
            this.menuProdutosEstoque.Size = new System.Drawing.Size(139, 22);
            this.menuProdutosEstoque.Text = "Estoque";
            // 
            // menuMoviFluxo
            // 
            this.menuMoviFluxo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem9,
            this.menuMoviLancaVenda,
            this.menuMoviInOut,
            this.menuMoviDespesas});
            this.menuMoviFluxo.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMoviFluxo.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.menuMoviFluxo.Name = "menuMoviFluxo";
            this.menuMoviFluxo.Size = new System.Drawing.Size(130, 22);
            this.menuMoviFluxo.Text = "Movimentações";
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(200, 22);
            this.toolStripMenuItem9.Text = "Fluxo de Caxia";
            // 
            // menuMoviLancaVenda
            // 
            this.menuMoviLancaVenda.Name = "menuMoviLancaVenda";
            this.menuMoviLancaVenda.Size = new System.Drawing.Size(200, 22);
            this.menuMoviLancaVenda.Text = "Lançar Venda";
            // 
            // menuMoviInOut
            // 
            this.menuMoviInOut.Name = "menuMoviInOut";
            this.menuMoviInOut.Size = new System.Drawing.Size(200, 22);
            this.menuMoviInOut.Text = "Entradas / Saídas";
            // 
            // menuMoviDespesas
            // 
            this.menuMoviDespesas.Name = "menuMoviDespesas";
            this.menuMoviDespesas.Size = new System.Drawing.Size(200, 22);
            this.menuMoviDespesas.Text = "Despesas";
            // 
            // MenuRelatorio
            // 
            this.MenuRelatorio.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuRelatorioProdutos,
            this.menuRelatorioVendas,
            this.menuRelatorioInOut,
            this.menuRelatorioDespesas});
            this.MenuRelatorio.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuRelatorio.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.MenuRelatorio.Name = "MenuRelatorio";
            this.MenuRelatorio.Size = new System.Drawing.Size(91, 22);
            this.MenuRelatorio.Text = "Relatórios";
            // 
            // menuRelatorioProdutos
            // 
            this.menuRelatorioProdutos.Name = "menuRelatorioProdutos";
            this.menuRelatorioProdutos.Size = new System.Drawing.Size(200, 22);
            this.menuRelatorioProdutos.Text = "Produtos";
            // 
            // menuRelatorioVendas
            // 
            this.menuRelatorioVendas.Name = "menuRelatorioVendas";
            this.menuRelatorioVendas.Size = new System.Drawing.Size(200, 22);
            this.menuRelatorioVendas.Text = "Vendas";
            // 
            // menuRelatorioInOut
            // 
            this.menuRelatorioInOut.Name = "menuRelatorioInOut";
            this.menuRelatorioInOut.Size = new System.Drawing.Size(200, 22);
            this.menuRelatorioInOut.Text = "Entradas / Saídas";
            // 
            // menuRelatorioDespesas
            // 
            this.menuRelatorioDespesas.Name = "menuRelatorioDespesas";
            this.menuRelatorioDespesas.Size = new System.Drawing.Size(200, 22);
            this.menuRelatorioDespesas.Text = "Despesas";
            // 
            // MenuSair
            // 
            this.MenuSair.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuSair.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.MenuSair.Name = "MenuSair";
            this.MenuSair.Size = new System.Drawing.Size(49, 22);
            this.MenuSair.Text = "Sair";
            this.MenuSair.Click += new System.EventHandler(this.MenuSair_Click);
            // 
            // img3
            // 
            this.img3.Location = new System.Drawing.Point(134, 182);
            this.img3.Name = "img3";
            this.img3.Size = new System.Drawing.Size(50, 50);
            this.img3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.img3.TabIndex = 4;
            this.img3.TabStop = false;
            // 
            // formPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(497, 450);
            this.Controls.Add(this.img3);
            this.Controls.Add(this.MenuPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MenuPrincipal;
            this.MaximizeBox = false;
            this.Name = "formPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.MenuPrincipal.ResumeLayout(false);
            this.MenuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.img3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem MenuSair;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem MenuRelatorio;
        private System.Windows.Forms.PictureBox img3;
        private System.Windows.Forms.ToolStripMenuItem MenuCadastro;
        private System.Windows.Forms.ToolStripMenuItem menuCadastrosFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuCadastrosClientes;
        private System.Windows.Forms.ToolStripMenuItem menuCadastrosUsuarios;
        private System.Windows.Forms.ToolStripMenuItem menuCadastrosCargos;
        private System.Windows.Forms.ToolStripMenuItem menuCadastrosFornecedor;
        private System.Windows.Forms.ToolStripMenuItem menuProdutosProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuProdutosEstoque;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorioProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorioVendas;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorioInOut;
        private System.Windows.Forms.ToolStripMenuItem menuRelatorioDespesas;
        private System.Windows.Forms.ToolStripMenuItem menuMoviFluxo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem menuMoviLancaVenda;
        private System.Windows.Forms.ToolStripMenuItem menuMoviInOut;
        private System.Windows.Forms.ToolStripMenuItem menuMoviDespesas;
    }
}

