
using System.Data;
using System.Windows.Forms;
using PDV.Models;

namespace PDV.Cadastro
{
    public partial class FormClientes : Form
    {
        string id, foto, desbloqueado, inadiplente ,radioBtn = "",alterouImagem = "não";
        int codCliente, idAnterior;
        bool emailAdress = false;
        private DataTable _dtClientesClone, dtClientes;

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            LimparCampos();
            DesabilitarCampos();
        }

        private void btnLimpar_Click(object sender, System.EventArgs e)
        {
            LimparCampos(null, null, null);
            btnNovo.Enabled = true;
        }

        private void FormClientes_Load(object sender, System.EventArgs e)
        {
            DesabilitarCampos();
            ListarFuncionarios();
        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            HabilitarCampos(); 
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HabilitarCampos();
        }

        public FormClientes()
        {
            InitializeComponent();

        https://www.youtube.com/watch?v=0UFtWnbzptI
        }


        #region Métodos
        private void Status()
        {
            
        }
        private void ListarFuncionarios()
        {
            dtClientes = FuncoesUteis.RetornarDataTableClientes(txtBuscarNome.Text,txtBuscarCpf.Text);
            _dtClientesClone = dtClientes.Copy();

            dgvClientes.DataSource = dtClientes; //DataSource: Para preencher o DataGridView com os dados dos funcionários
            AjustarGrid();
        }
        private void AjustarGrid() 
        {
            dgvClientes.Columns[0].HeaderText = "Id";
            dgvClientes.Columns[1].HeaderText = "Código";
            dgvClientes.Columns[2].HeaderText = "Nome";
            dgvClientes.Columns[3].HeaderText = "Cpf";
            dgvClientes.Columns[4].HeaderText = "Em aberto";
            dgvClientes.Columns[5].HeaderText = "Telefone";
            dgvClientes.Columns[6].HeaderText = "Email";
            dgvClientes.Columns[7].HeaderText = "Desbloqueado";
            dgvClientes.Columns[8].HeaderText = "Status";
            dgvClientes.Columns[9].HeaderText = "Endereço";
            dgvClientes.Columns[10].HeaderText = "Funcionário";
            dgvClientes.Columns[11].HeaderText = "Img";
            dgvClientes.Columns[12].HeaderText = "Data";

            //dgvFuncionarios.Columns[0].Width = 30;
            //dgvFuncionarios.Columns[1].Width = 170;
            //dgvFuncionarios.Columns[2].Width = 150;
            //dgvFuncionarios.Columns[3].Width = 100;
            //dgvFuncionarios.Columns[4].Width = 150;
            //dgvFuncionarios.Columns[5].Width = 90;
            //dgvFuncionarios.Columns[6].Width = 90;
            dgvClientes.Columns[0].Visible = false;
            dgvClientes.Columns[11].Visible = false;
            dgvClientes.Columns[4].DefaultCellStyle.Format = "c2";

        }
        private void HabilitarCampos()
        {
            btnSalvar.Enabled = true;

            txtNome.Enabled = true;
            txtCpf.Enabled = true;
            txtTelefone.Enabled = true;
            txtEndereco.Enabled = true;
            cbxInadiplente.Enabled = true;
            txtEmail.Enabled = true;
            txtValor.Enabled = true;

            //btnNovo.Enabled = true;
            //btnEditar.Enabled = false;
            //btnExcluir.Enabled = false;
        }
        private void DesabilitarCampos()
        {
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            btnSalvar.Enabled = false;
            txtNome.Enabled = false;
            txtCpf.Enabled = false;
            txtTelefone.Enabled = false;
            txtEndereco.Enabled = false;
            txtEmail.Enabled = false;
            cbxInadiplente.Enabled = false;
            txtValor.Enabled = false;
        }
        private void LimparCampos(TextBox campoTxt = null, MaskedTextBox campoMask = null, ComboBox campoCbx = null)
        {
            if (campoTxt != null)
            {
                campoTxt.Text = "";
                campoTxt.Focus();
            }

            if (campoMask != null)
            {
                campoMask.Text = "";
                campoMask.Focus();
            }

            if (campoCbx != null)
            {
                //campoCbx.Items.Clear();
                campoCbx.Focus();
            }
            if (campoTxt == null && campoMask == null && campoCbx == null)
            {
                txtNome.Text = "";
                txtCpf.Text = "";
                txtTelefone.Text = "";
                txtEndereco.Text = "";
                txtEmail.Text = "";
                cbxInadiplente.SelectedIndex = -1;
                LimparFoto();
            }
        }
        private void LimparFoto()
        {
            image.Image = Properties.Resources.photoimg;
            foto = "Image/photoimg.png";
        }
        #endregion Fim Métodos
    }
}
