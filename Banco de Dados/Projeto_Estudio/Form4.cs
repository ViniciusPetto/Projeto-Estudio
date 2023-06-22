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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno aluno = new Aluno(maskedTextBox1.Text);
            if (e.KeyChar == 13)
            {
                if (aluno.consultarAluno())
                {
                    MessageBox.Show("ALUNO ENCONTRADO!");
                    if (aluno.excluirAluno())
                    {
                        MessageBox.Show("ALUNO EXCLUÍDO!");
                    }
                }
                else
                {
                    MessageBox.Show("CPF DIGITADO INEXISTENTE!");
                }
            }
        }

        private void Form4_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}
