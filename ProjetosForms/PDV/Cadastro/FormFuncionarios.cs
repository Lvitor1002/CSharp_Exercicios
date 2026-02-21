using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using PDV.Models;

namespace PDV.Cadastro
{
    public partial class FormFuncionarios : Form
    {
        string foto;
        private int Id;
        bool alterouImagem = false;
        DataTable DtFuncionariosClone = new DataTable();

        public FormFuncionarios()
            =>InitializeComponent();
        
        #region Eventos 
        private void FormFuncionarios_Load(object sender, EventArgs e)
        {
            DesabilitarCampos();
            LimparFoto();
            ListarFuncionarios();
            ListarCargos();
            cbxCargo.Text = "Selecione um cargo";
        }
        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Tem certeza que deseja excluir este funcionário?", "Atenção", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.No)
                return;

            FuncoesUteis.ExcluirFuncionarios(Id);
            AjustarGrid();
            MessageBox.Show("Funcionário excluído com sucesso! \nÉ necessário reiniciar o sistema para aplicar as alterações.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if(!ValidarCampos())
                return;

            if(DtFuncionariosClone.Rows.Count == 0)
                return;
            
            foreach(DataRow linha in DtFuncionariosClone.Rows)
            {
                string cpfRegistrado = linha["cpf"].ToString();
                int idRegistrado = Convert.ToInt32(linha["id"]);

                if(cpfRegistrado == txtCpf.Text && idRegistrado != Id) // verifica se há cpf iguais para pessoas diferentes
                {
                    MessageBox.Show("CPF já está sendo utilizado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LimparCampos();
                    return;
                }
            }

            FuncoesUteis.EditarFuncionarios(Id, txtNome.Text, txtCpf.Text, txtCelular.Text, txtEndereco.Text, cbxCargo.Text, alterouImagem == true ? RetornarImagemTratada() : null);
            MessageBox.Show("Funcionário editado com sucesso! \nÉ necessário reiniciar o sistema para aplicar as alterações.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
       
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            HabilitarCampos(); 
        }
        private void btnImg_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();

            dialog.Filter = "Imagens(*.jpg; *.png) | *.jpg; *.png";
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                foto = dialog.FileName.ToString();
                image.ImageLocation = foto;
                alterouImagem = true;
            }
        }
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if(!ValidarCampos())
                return;

            FuncoesUteis.SalvarFuncionarios(txtNome.Text,txtCpf.Text,txtCelular.Text,txtEndereco.Text,cbxCargo.Text,RetornarImagemTratada());

            LimparFoto();
            MessageBox.Show("Funcionário cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ListarFuncionarios();
            btnNovo.Enabled = true;
            btnSalvar.Enabled = false;
            btnEditar.Enabled = false;
            btnExcluir.Enabled = false;
            LimparCampos();
            DesabilitarCampos();
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos(null,null,null);
            btnNovo.Enabled = true;
        }
        private void dgvFuncionarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFuncionarios.Rows.Count == 0)
                return;

            HabilitarCampos();
            btnEditar.Enabled = true;
            btnExcluir.Enabled = true;
            btnNovo.Enabled = false;
            btnSalvar.Enabled = false;

            Id = Convert.ToInt32(dgvFuncionarios.CurrentRow.Cells[0].Value);
            txtNome.Text = dgvFuncionarios.CurrentRow.Cells[1].Value.ToString();
            txtCpf.Text = dgvFuncionarios.CurrentRow.Cells[2].Value.ToString();
            txtCelular.Text = dgvFuncionarios.CurrentRow.Cells[3].Value.ToString();
            txtEndereco.Text = dgvFuncionarios.CurrentRow.Cells[4].Value.ToString();
            cbxCargo.Text = dgvFuncionarios.CurrentRow.Cells[5].Value.ToString();

            CapturarFotoDaGrid(e);
        }
        #endregion Fim Eventos

        
        
        #region Métodos
        
        private void ListarFuncionarios()
        {
            DataTable dtFuncionarios = FuncoesUteis.RetornarDataTableFuncionarios(cbxCargo.Text);
            DtFuncionariosClone = dtFuncionarios.Copy();

            dgvFuncionarios.DataSource = dtFuncionarios; //DataSource: Para preencher o DataGridView com os dados dos funcionários
            AjustarGrid();
        }
        private void ListarCargos()
        {
            DataTable dtCargos = FuncoesUteis.RetornarDataTableCargos();
            if(dtCargos.Rows.Count == 0)
                return;

            cbxCargo.DataSource = dtCargos; // DataSource: Para preencher o ComboBox com os cargos
            cbxCargo.DisplayMember = "nome"; // DisplayMember: Define qual coluna do DataTable será exibida no ComboBox
            //cbxCargo.ValueMember = "id"; // ValueMember: Define qual coluna do DataTable será usada como valor do ComboBox
        }
        private void AjustarGrid()
        {
            dgvFuncionarios.Columns[0].HeaderText = "Id";
            dgvFuncionarios.Columns[1].HeaderText = "Nome";
            dgvFuncionarios.Columns[2].HeaderText = "Cpf";
            dgvFuncionarios.Columns[3].HeaderText = "Telefone";
            dgvFuncionarios.Columns[4].HeaderText = "Endereço";
            dgvFuncionarios.Columns[5].HeaderText = "Cargo";
            dgvFuncionarios.Columns[6].HeaderText = "Data";
            dgvFuncionarios.Columns[7].HeaderText = "Foto";

            dgvFuncionarios.Columns[0].Width = 30;
            dgvFuncionarios.Columns[1].Width =170;
            dgvFuncionarios.Columns[2].Width =150;
            dgvFuncionarios.Columns[3].Width =100;
            dgvFuncionarios.Columns[4].Width =150;
            dgvFuncionarios.Columns[5].Width =90;
            dgvFuncionarios.Columns[6].Width =90;
            dgvFuncionarios.Columns[7].Visible = false;
        }

        private byte[] RetornarImagemTratada()
        {
            if(string.IsNullOrEmpty(foto))
                return null;

            FileStream fs = new FileStream(foto, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            return br.ReadBytes((int)fs.Length);
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrEmpty(txtNome.Text.Trim()))
            {
                MessageBox.Show("Preencha o campo nome.", "Campo Obrigatório",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparCampos(txtNome,null,null);
                return false;
            }
            if (txtCpf.Text == "   ,   ,   -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo cpf.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparCampos(null,txtCpf,null);
                return false;
            }
            if (string.IsNullOrEmpty(txtEndereco.Text.Trim()))
            {
                MessageBox.Show("Preencha o campo endereço.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparCampos(txtEndereco,null,null);
                return false;
            }
            if (txtCelular.Text == "(  )     -" || txtCpf.Text.Length < 14)
            {
                MessageBox.Show("Preencha o campo celular.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparCampos(null,txtCelular,null);
                return false;
            }
            if (string.IsNullOrEmpty(cbxCargo.Text.Trim()) || cbxCargo.Text == "Selecione um cargo")
            {
                MessageBox.Show("Campo cargo está incorreto.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                LimparCampos(null,null,cbxCargo);
                return false;
            }
            return true; 
        }
        private void HabilitarCampos()
        {
            btnSalvar.Enabled = true;

            txtNome.Enabled = true;
            txtCpf.Enabled = true;
            txtCelular.Enabled = true;
            txtEndereco.Enabled = true;
            cbxCargo.Enabled = true;
            btnImg.Enabled = true;

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
            txtCelular.Enabled = false;
            txtEndereco.Enabled = false;
            cbxCargo.Enabled = false;
            btnImg.Enabled = false;
        }
        private void LimparCampos(TextBox campoTxt = null, MaskedTextBox campoMask = null, ComboBox campoCbx = null)
        {
            if(campoTxt != null)
            {
                campoTxt.Text = "";
                campoTxt.Focus();
            }

            if(campoMask != null)
            {
                campoMask.Text = "";
                campoMask.Focus();
            }

            if(campoCbx != null)
            {
                //campoCbx.Items.Clear();
                campoCbx.Focus();
            }
            if(campoTxt == null && campoMask == null && campoCbx == null)
            {
                txtNome.Text = "";
                txtCpf.Text = "";
                txtCelular.Text = "";
                txtEndereco.Text = "";
                LimparFoto();
            }
        }
        private void LimparFoto()
        {
            image.Image = Properties.Resources.photoimg;
            foto = "Image/photoimg.png";
        }
        private void CapturarFotoDaGrid(DataGridViewCellEventArgs e)
        {
            if(dgvFuncionarios.CurrentRow.Cells[7].Value == DBNull.Value)
            {
                image.Image = Properties.Resources.photoimg;
                return;
            }
            byte[] imagem = (byte[])dgvFuncionarios.Rows[e.RowIndex].Cells[7].Value; //Captura a imagem em bytes do DataGridView
         
            MemoryStream ms = new MemoryStream(imagem); //Converte os bytes em um MemoryStream

            image.Image = Image.FromStream(ms); //Converte o MemoryStream em uma imagem e atribui ao PictureBox
        }
        #endregion Fim Métodos
    }
}

