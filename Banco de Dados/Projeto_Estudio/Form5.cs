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
    public partial class Form5 : Form
    {
        int opcao = 0;
        public Form5(int op)
        {
            InitializeComponent();
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

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modalidade m1 = new Modalidade(textBox1.Text, textBox2.Text, textBox4.Text, textBox5.Text, float.Parse(textBox3.Text));

            if (opcao == 1)
            {
                if (m1.cadastrarModalidade())
                    MessageBox.Show("CADASTRO REALIZADO COM SUCESSO!");
                else
                    MessageBox.Show("ERRO NO CADASTRO!");
            }
            else
            {
                if (m1.atualizarModalidade())
                {
                    MessageBox.Show("MODALIDADE ATUALIZADA COM SUCESSO!");
                }
                else
                {
                    textBox2.Focus();
                }
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Modalidade m1 = new Modalidade(textBox2.Text);
            if (e.KeyChar == 13)
            {
                if (opcao == 1)
                {
                    if (m1.consultarModalidade())
                    {
                        MessageBox.Show("MODALIDADE JÁ CADASTRADA!");
                    }
                    else
                    {
                        textBox1.Focus();
                    }
                }
                else
                {
                    MySqlDataReader r = m1.consultarTodasModalidade();
                    if (r.Read())
                    {
                        textBox1.Text = r["IDModalidade"].ToString();
                        textBox2.Text = r["nomeModalidade"].ToString();
                        textBox3.Text = r["precoModalidade"].ToString();
                        textBox4.Text = r["qntdAlunos"].ToString();
                        textBox5.Text = r["diasModalidade"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("MODALIDADE NÃO CADASTRADA!");
                    }
                    DAO_Conexao.con.Close();
                }
            }
        }
    }
}
