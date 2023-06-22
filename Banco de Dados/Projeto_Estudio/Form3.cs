using MySql.Data.MySqlClient;
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
    public partial class Form3 : Form
    {
        int opcao = 0;
        public Form3(int op)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            if(op == 1)
            {
                button1.Text = "CADASTRAR";
                opcao = 1;
            }
            else
            {
                button1.Text = "ATUALIZAR";
                opcao = 2;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Aluno a1 = new Aluno(maskedTextBox1.Text, textBox2.Text, textBox3.Text, textBox11.Text, textBox4.Text, textBox9.Text, maskedTextBox2.Text, textBox7.Text, textBox10.Text, maskedTextBox3.Text, textBox8.Text);
            if(opcao == 1)
            {
                if (a1.cadastrarAluno())
                    MessageBox.Show("CADASTRO REALIZADO COM SUCESSO!");
                else
                    MessageBox.Show("ERRO NO CADASTRO!");
            }
            else
            {
                if(a1.atualizarAluno())
                {
                    MessageBox.Show("ATUALIZAÇÃO REALIZADA COM SUCESSO!");
                }
            }
           
        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Aluno a1 = new Aluno(maskedTextBox1.Text);
            if (e.KeyChar == 13)
            {
                if(opcao == 1)
                {
                    if (a1.consultarAluno())
                    {
                        MessageBox.Show("ALUNO JÁ CADASTRADO!");
                    }
                    else
                    {
                        textBox2.Focus();
                    }
                }
                else
                {
                    MySqlDataReader r = a1.consultarAlunoUpdate();
                    if (r.Read())
                    {
                        textBox2.Text = r["nomeAluno"].ToString();
                        textBox3.Text = r["ruaAluno"].ToString();
                        textBox11.Text = r["numeroAluno"].ToString();
                        textBox4.Text = r["bairroAluno"].ToString();
                        textBox9.Text = r["complementoAluno"].ToString();
                        maskedTextBox2.Text = r["CEPAluno"].ToString();
                        textBox7.Text = r["cidadeAluno"].ToString();
                        textBox10.Text = r["estadoAluno"].ToString();
                        maskedTextBox3.Text = r["telefoneAluno"].ToString();
                        textBox8.Text = r["emailAluno"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("ALUNO NÃO CADASTRADO!");
                    }
                    DAO_Conexao.con.Close();
                }
            }
        }
    }
}
