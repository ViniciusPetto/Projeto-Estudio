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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (DAO_Conexao.getConexao("143.106.241.3", "cl201029", "cl201029", "cl*10042002"))
                Console.WriteLine("Conectado");
            else
                Console.WriteLine("Erro de conexão");
        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int tipo = DAO_Conexao.getLogin(textBox1.Text, textBox2.Text);

            if (tipo == 1)
            {
                MessageBox.Show("LOGADO COMO ADMINISTADOR!");
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
            }
            else if (tipo == 2)
            {
                MessageBox.Show("LOGADO COMO FUNCIONÁRIO!");
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
                cadastrarLoginToolStripMenuItem.Enabled = false;
            }
        }

        private void sAIRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cadastrarLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 cadLogin = new Form2();
            cadLogin.MdiParent = this;
            cadLogin.Show();
        }

        private void cadastrarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 cadAluno = new Form3(1);
            cadAluno.MdiParent = this;
            cadAluno.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void sAIRToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 atualizaAluno = new Form3(2);
            atualizaAluno.MdiParent = this;
            atualizaAluno.Show();
        }

        private void sAIRToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form4 excluirAluno = new Form4();
            excluirAluno.MdiParent = this;
            excluirAluno.Show();
        }

        private void sAIRToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //MÉTODO VAZIO
        }

        private void cadastrarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void excluirModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void cadastrarModalidadeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 cadastrarModalidade = new Form5(1);
            cadastrarModalidade.MdiParent = this;
            cadastrarModalidade.Show();
        }

        private void excluirModalidadeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form6 excluirModalidade = new Form6(1);
            excluirModalidade.MdiParent = this;
            excluirModalidade.Show();
        }

        private void sAIRToolStripMenuItem2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void atualizarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 atualizarModalidade = new Form5(2);
            atualizarModalidade.MdiParent = this;
            atualizarModalidade.Show();
        }

        private void consultarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 atualizarModalidade = new Form7(2);
            atualizarModalidade.MdiParent = this;
            atualizarModalidade.Show();
        }

        private void reativarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 reativarModalidade = new Form6(2);
            reativarModalidade.MdiParent = this;
            reativarModalidade.Show();
        }

        private void cadastrarTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 cadastraTurma = new Form8();
            cadastraTurma.MdiParent = this;
            cadastraTurma.Show();
        }

        private void excluirTurmaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 excluiTurma = new Form9();
            excluiTurma.MdiParent = this;
            excluiTurma.Show();
        }
    }
}
