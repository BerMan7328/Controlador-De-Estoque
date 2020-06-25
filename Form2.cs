using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3M_New
{
    public partial class Form2 : Form
    {
        public String operacao;
        public Form2()
        {
            InitializeComponent();
        }
        public void alteraBotoes(int op)
        {
            pnDados.Enabled = false;
            bttInserir.Enabled = false;
            bttAlterar.Enabled = false;
            bttLocalizar.Enabled = false;
            bttExcluir.Enabled = false;
            bttCancelar.Enabled = false;
            bttSalvar.Enabled = false;

            if (op == 1)
                {
                 bttInserir.Enabled = true;
                 bttLocalizar.Enabled = true;
                }
            if (op == 2)
                {
                 pnDados.Enabled = true;
                 bttSalvar.Enabled = true;
                 bttCancelar.Enabled = true;
                }   
            if (op == 3)
                {
                bttAlterar.Enabled = true;
                bttExcluir.Enabled = true;
                bttCancelar.Enabled = true;
                }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.alteraBotoes(1);
        }

        private void pnDados_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
