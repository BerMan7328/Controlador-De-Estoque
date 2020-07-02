using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace _3M_New
{
    public partial class frmConfiguracaoDBA : Form
    {
        public void LimpaTela()
        {
            txtServidor.Clear();
            txtBanco.Clear();
            txtUsuario.Clear();
            txtSenha.Clear();
        }
        public frmConfiguracaoDBA()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter arquivo = new StreamWriter("ConfiguracaoBanco.txt", false);
                arquivo.WriteLine(txtServidor.Text);
                arquivo.WriteLine(txtBanco.Text);
                arquivo.WriteLine(txtUsuario.Text);
                arquivo.WriteLine(txtSenha.Text);
                arquivo.Close();
                MessageBox.Show("Arquivo Atualizado com Sucesso!");
                this.LimpaTela();
                this.Close();
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void frmConfiguracaoDBA_Load(object sender, EventArgs e)
        {
            try
            {
                StreamReader arquivo = new StreamReader("ConfiguracaoBanco.txt");
                txtServidor.Text = arquivo.ReadLine();
                txtBanco.Text = arquivo.ReadLine();
                txtUsuario.Text = arquivo.ReadLine();
                txtSenha.Text = arquivo.ReadLine();
                arquivo.Close();
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btTeste_Click(object sender, EventArgs e)
        {
            try
            {
                txtServidor.Text = txtServidor.Text;
                txtBanco.Text = txtBanco.Text;
                txtUsuario.Text = txtUsuario.Text;
                txtSenha.Text = txtSenha.Text;
                SqlConnection conexao = new SqlConnection();
                conexao.ConnectionString = DadosDaConexao.StringDeConexao;
                conexao.Open();
                conexao.Close();
                MessageBox.Show("Conexão Realizada com Sucesso!");
            }
            catch(Exception)
            {
                MessageBox.Show("Erro ao Se Conectar com o Banco de Dados\nVerifique as configurações ou contate o admin do sistema");
            }
        }
    }
}
