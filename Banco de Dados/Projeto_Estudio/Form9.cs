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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PEGA O NOME DIGITADO NO TEXTBOX MODALIDADE, DE EXCLUIR TURMA, CONSULTA NA TABELA MODALIDADE, PEGA O ID DA MODALIDADE DIGITADA E COLOCA NA VARIÁVEL "MODALIDADE", PARA SER USADA
            int modalidade;

            Modalidade m = new Modalidade(textBox1.Text);
            MySqlDataReader r = m.consultarIDModalidade();
            if (r.Read())
            {
                Console.WriteLine("Modalidade encontrada!");
                modalidade = int.Parse(r["IDModalidade"].ToString());
            }
            else
            {
                Console.WriteLine("Modalidade não encontrada!");
                modalidade = 0;
            }
            DAO_Conexao.con.Close();



            //EXECUTA A EXCLUSÃO DE MODALIDADE, PEGANDO O CONTEÚDO DOS DIAS DA SEMANA (TEXTBOX2) E HORA (TEXTBOX3) MAIS A VARIÁVEL COM O ID DO NOME DA MODALIDADE DIGITADA
            Turma t = new Turma(modalidade, textBox2.Text, textBox3.Text);
            if (t.excluirModalidade())
            {
                MessageBox.Show("MODALIDADE EXCLUÍDA!");
            }
            else
            {
                MessageBox.Show("ERRO NA EXCLUSÃO DA MODALIDADE!");
            }
        }
    }
}
