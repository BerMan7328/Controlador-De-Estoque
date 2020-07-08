using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Ferramentas;

namespace _3M_New
{
    public partial class frmBackupDBA : Form
    {
        public frmBackupDBA()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "Backup Files |*.bak";
                d.ShowDialog();
                if (d.FileName != "")
                {
                    string nomeBanco = DadosDaConexao.banco;
                    string localBackup = d.FileName;
                    string conexao = @"Data Source=" + DadosDaConexao.servidor + ";Initial Catalog=master;User=" + DadosDaConexao.usuario + ";Password=" + DadosDaConexao.senha;
                    SQLServerBackup.BackupDataBase(conexao, nomeBanco, d.FileName);
                    MessageBox.Show("Backup Realizado com Sucesso!");
                }
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void btRestaurar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog d = new OpenFileDialog();
                d.Filter = "Backup Files |*.bak";
                d.ShowDialog();
                if (d.FileName != "")
                {
                    string nomeBanco = DadosDaConexao.banco;
                    string localBackup = d.FileName;
                    string conexao = @"Data Source=" + DadosDaConexao.servidor + ";Initial Catalog=master;User=" + DadosDaConexao.usuario + ";Password=" + DadosDaConexao.senha;
                    SQLServerBackup.RestauraDatabase(conexao, nomeBanco, d.FileName);
                    MessageBox.Show("Backup Reestaurado com Sucesso!");
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }
    }
}
