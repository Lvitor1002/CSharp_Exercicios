using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using PDV.Models;

namespace PDV.Cadastro
{
    public partial class FormCargos : Form
    {
        private int _Id;
        DataTable DtCargosClone = new DataTable();

        public FormCargos()
            =>InitializeComponent();

        private void FormCargos_Load(object sender, EventArgs e)
        {
            txtNome.Enabled = false;
            label1.Enabled = false;
            ListarCargos();
        }
        private void AjustarGrid()
        {
            dgvCargos.Columns[0].HeaderText = "Id";
            dgvCargos.Columns[1].HeaderText = "Nome";
            dgvCargos.Columns[2].HeaderText = "Data";
            dgvCargos.Columns[0].Visible = false;
        }
        private void ListarCargos()
        {
            DataTable dtCargos = FuncoesUteis.RetornarDataTableCargos();

            dgvCargos.DataSource = dtCargos; //DataSource: Para preencher o DataGridView com os dados dos cargos
            AjustarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Tem certeza que deseja excluir este cargo?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            FuncoesUteis.ExcluirCargos(_Id);
            AjustarGrid();
            MessageBox.Show("Cargo excluído com sucesso! \nÉ necessário reiniciar o sistema para aplicar as alterações.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvCargos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCargos.Rows.Count == 0)
                return;

            HabilitarCampos();
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = false;

            _Id = Convert.ToInt32(dgvCargos.CurrentRow.Cells[0].Value);
            txtNome.Text = dgvCargos.CurrentRow.Cells[1].Value.ToString();
            dtpData.Text =  dgvCargos.CurrentRow.Cells[2].Value.ToString();

        }

        private void HabilitarCampos()
        {
            btnSalvar.Enabled = true;
            txtNome.Enabled = true;
            label1.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                MessageBox.Show("Preencha o campo nome.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Text = "";
                return;
            }

            bool nomeExiste = dgvCargos.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow && string.Equals(txtNome.Text.Trim(), r.Cells[1].Value?.ToString(),StringComparison.OrdinalIgnoreCase));
       
            if (nomeExiste)
            {
                MessageBox.Show($"Nome '{txtNome.Text}' já existe!","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            FuncoesUteis.SalvarCargos(txtNome.Text);

            MessageBox.Show("Cargo cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
            ListarCargos();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            txtNome.Text = "";
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = "";
            btnNovo.Enabled = true;
            txtNome.Enabled = false;
            label1.Enabled = false;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                MessageBox.Show("Preencha o campo nome.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNome.Text = "";
                return;
            }
            bool nomeExiste = dgvCargos.Rows.Cast<DataGridViewRow>().Any(r => !r.IsNewRow && string.Equals(txtNome.Text.Trim(), r.Cells[1].Value?.ToString(), StringComparison.OrdinalIgnoreCase));
            if (nomeExiste)
            {
                MessageBox.Show($"Cargo '{txtNome.Text}' já cadastrado! Tente outro..", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            FuncoesUteis.EditarCargos(_Id, txtNome.Text);
            MessageBox.Show("Cargo editado com sucesso! \nÉ necessário reiniciar o sistema para aplicar as alterações.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            AjustarGrid();
        }

        private void btnNovo_Click(object sender, EventArgs e)
            =>HabilitarCampos();
    }
}