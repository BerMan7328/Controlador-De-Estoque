using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace _3M_New
{
    public partial class frmConsultaProduto : Form
    {
        public int codigo = 0;
        public frmConsultaProduto()
        {
            InitializeComponent();
        }

        private void frmConsultaProduto_Load(object sender, EventArgs e)
        {
            btLocalizar_Click(sender, e);
            dgvDados.Columns[0].HeaderText = "Código";
            dgvDados.Columns[1].HeaderText = "Produto";
            dgvDados.Columns[2].HeaderText = "Descricao";
            dgvDados.Columns[3].HeaderText = "Valor Pago";
            dgvDados.Columns[4].HeaderText = "Valor Venda";
            dgvDados.Columns[5].HeaderText = "Quantidade";
            dgvDados.Columns[6].HeaderText = "Código Unidade de Medida";
            dgvDados.Columns[7].HeaderText = "Código Categoria";
            dgvDados.Columns[8].HeaderText = "Código SubCategoria";
            dgvDados.Columns[9].HeaderText = "Unidade De Medida";
            dgvDados.Columns[10].HeaderText = "Categoria";
            dgvDados.Columns[11].HeaderText = "SubCategoria";

            dgvDados.Columns["cat_cod"].Visible = false;
            dgvDados.Columns["scat_cod"].Visible = false;
            dgvDados.Columns["umed_cod"].Visible = false;

        }

        private void btLocalizar_Click(object sender, EventArgs e)
        {
            DALConexao cx = new DALConexao(DadosDaConexao.StringDeConexao);
            BLLProduto bll = new BLLProduto(cx);
            dgvDados.DataSource = bll.Localizar(txtProduto.Text);
        }

        private void dgvDados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.codigo = Convert.ToInt32(dgvDados.Rows[e.RowIndex].Cells[0].Value);
                this.Close();
            }
        }
    }
}
