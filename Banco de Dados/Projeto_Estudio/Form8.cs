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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            Modalidade m = new Modalidade();
            MySqlDataReader r = m.consultarTodasModalidadeTurma();
            while (r.Read())
            {
                dataGridView1.Rows.Add(r["nomeModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }




        private void button1_Click(object sender, EventArgs e)
        {
            int modalidade;
            string numAlunos;

            //BUSCA ID DA MODALIDADE NO TEXTBOX DE TURMA PARA CADASTRAR NA TABELA ATRAVÉS DA VARIÁVEL "MODALIDADE"
            Modalidade m = new Modalidade(textBox1.Text);
            MySqlDataReader r = m.consultarIDModalidade();
            if (r.Read())
                modalidade = int.Parse(r["IDModalidade"].ToString());
            else
            {
                modalidade = 0;
                MessageBox.Show("MODALIDADE NÃO ENCONTRADA!");
            }
            DAO_Conexao.con.Close();


            //BUSCA QUANTIDADE DE ALUNOS DA MODALIDADE NO TEXTBOX DE TURMA PARA CADASTRAR NA TABELA ATRAVÉS DA VARIÁVEL "NUMALUNOS"
            MySqlDataReader p = m.consultarQNTDModalidade();
            if (p.Read())
                numAlunos = p["qntdAlunos"].ToString();
            else
            {
                numAlunos = null;
                MessageBox.Show("QUANTIDADE DE ALUNOS NÃO PREENCHIDA!");
            }
            DAO_Conexao.con.Close();


            //REGISTRA NO BANCO DE DADOS
            Turma t = new Turma(textBox2.Text, textBox3.Text, textBox4.Text, modalidade, numAlunos);
            if (t.cadastrarTurma())
            {
                MessageBox.Show("CADASTRO REALIZADO COM SUCESSO!");
            }
            else
            {
                MessageBox.Show("ERRO NO CADASTRO!");
            }
        }

        //SELECIONA O VALOR DO DATAGRIDVIEW E COLOCA NO TEXTBOX
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1[e.ColumnIndex, e.RowIndex].Value.ToString();
        }
    }
}
