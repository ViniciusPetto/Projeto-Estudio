using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Estudio
{
    internal class Turma
    {
        private string professor;
        private string dia_semana;
        private string hora;
        private string numAlunos;
        private int modalidade;

        private void setNumAlunos(string numAlunos)
        {
            this.numAlunos = numAlunos;
        }
        private string getNumAlunos()
        {
            return this.numAlunos;
        }

        private void setProfessor(string professor)
        {
            this.professor = professor;
        }
        private string getProfessor()
        {
            return this.professor;
        }

        private void setDiaSemana(string dia_semana)
        {
            this.dia_semana = dia_semana;
        }
        private string getDiaSemana()
        {
            return this.dia_semana;
        }

        private void setHora(string hora)
        {
            this.hora = hora;
        }
        private string getHora()
        {
            return this.hora;
        }

        private void setModalidade(int modalidade)
        {
            this.modalidade = modalidade;
        }
        private int getModalidade()
        {
            return this.modalidade;
        }

        public Turma(string professor, string dia_semana, string hora, int modalidade, string numAlunos)
        {
            setProfessor(professor);
            setDiaSemana(dia_semana);
            setHora(hora);
            setModalidade(modalidade);
            setNumAlunos(numAlunos);
        }


        public Turma(int modalidade)
        {
            setModalidade(modalidade);
        }


        public Turma(int modalidade, string dia_semana, string hora)
        {
            setModalidade(modalidade);
            setDiaSemana(dia_semana);
            setHora(hora);
        }


        public bool cadastrarTurma()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Turma (idModalidade, professorTurma, diassemanaTurma, horaTurma, numAlunosTurma) values ('" + modalidade + "','" + professor + "','" + dia_semana + "','" + hora + "','" + numAlunos + "')", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad;
        }


        public bool excluirModalidade()
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("delete from Estudio_Turma where idModalidade = '" + modalidade + "' and diassemanaTurma = '" + dia_semana + "' and horaTurma = '" + hora + "'", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return exc;
        }

        public MySqlDataReader consultarTurma()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select * from Estudio_Turma where idModalidade = '" + modalidade + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarTurma01()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select * from Estudio_Turma where idModalidade = '" + modalidade + "' and diassemanaTurma = '" + dia_semana + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }
    }
}
