using System;
using System.Windows.Forms;
using PDV.Cadastro;

namespace PDV
{
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            InitializeComponent();
        }


        private void MenuSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuCadastrosFuncionario_Click(object sender, EventArgs e)
        {
            var formFuncionarios = new FormFuncionarios();
            formFuncionarios.ShowDialog(); // Não permite mexer na aba de trás
        }

        private void menuCadastrosCargos_Click(object sender, EventArgs e)
        {
            var formCargos = new FormCargos();
            formCargos.ShowDialog();
        }

        private void menuCadastrosClientes_Click(object sender, EventArgs e)
        {
            var formClientes = new FormClientes();
            formClientes.ShowDialog();
        }
    }
}
