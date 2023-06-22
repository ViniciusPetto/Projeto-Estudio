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
    public partial class Form7 : Form
    {
        int opcao = 0;
        public Form7(int op)
        {
            InitializeComponent();
            if(op == 1)
            {
                button1.Text = "ATUALIZAR";
                int opcao = 1;
            }
            else
            {
                button1.Visible = false;
                int opcao = 2;
            }
        }

        private void button1_Click(object sender, KeyPressEventArgs e)
        {
            Modalidade m1 = new Modalidade(textBox4.Text);
            if (opcao == 1)
            {
                MySqlDataReader r = m1.consultarTodasModalidade();
                if (r.Read())
                {
                    textBox4.Text = r["nomeModalidade"].ToString();
                    textBox1.Text = r["precoModalidade"].ToString();
                    textBox2.Text = r["qntdAlunos"].ToString();
                    textBox3.Text = r["diasModalidade"].ToString();
                }
                else
                {
                    MessageBox.Show("MODALIDADE NÃO CADASTRADA!");
                }
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            textBox1.Enabled = false;
            textBox3.Enabled = false;
            textBox2.Enabled = false;

            Modalidade m1 = new Modalidade(textBox4.Text);
            if (e.KeyChar == 13)
            {
                MySqlDataReader r = m1.consultarTodasModalidade();
                if (r.Read())
                {
                    textBox4.Text = r["nomeModalidade"].ToString();
                    textBox1.Text = r["precoModalidade"].ToString();
                    textBox2.Text = r["qntdAlunos"].ToString();
                    textBox3.Text = r["diasModalidade"].ToString();
                }
                else
                {
                    MessageBox.Show("MODALIDADE NÃO CADASTRADA!");
                }
                DAO_Conexao.con.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
