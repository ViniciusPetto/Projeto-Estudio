using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_Estudio
{
    public partial class Form6 : Form
    {
        int opcao = 0;
        public Form6(int op)
        {
            InitializeComponent();
            if (op == 1)
            {
                button1.Text = "EXCLUIR";
                opcao = 1;
            }
            if (op == 2)
            {
                button1.Text = "REATIVAR";
                opcao = 2;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modalidade m = new Modalidade(textBox1.Text);
            if (opcao == 1)
            {
                if (m.consultarModalidade())
                {
                    MessageBox.Show("MODALIDADE ENCONTRADA!");
                    if (m.excluirModalidade())
                    {
                        MessageBox.Show("MODALIDADE EXCLUÍDA!");
                    }
                }
                else
                {
                    MessageBox.Show("NOME DE MODALIDADE DIGITADO INEXISTENTE!");
                }
            }
            else
            {
                if (m.consultarModalidade())
                {
                    MessageBox.Show("MODALIDADE ENCONTRADA!");
                    if (m.reativarModalidade())
                    {
                        MessageBox.Show("MODALIDADE REATIVADA!");
                    }
                }
                else
                {
                    MessageBox.Show("NOME DE MODALIDADE DIGITADO INEXISTENTE!");
                }
            }
        }
    }
}
