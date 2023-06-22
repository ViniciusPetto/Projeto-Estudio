using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Estudio
{
    class Modalidade
    {
        private string id, nome, diasAula, alunos;
        private float preco ;

        public Modalidade(string id, string nome, string alunos, string diasAula, float preco)
        {
            setId(id);
            setNome(nome);
            setAlunos(alunos);
            setDiasAula(diasAula);
            setPreco(preco);
        }

        private void setId(string id)
        {
            this.id = id;
        }

        private string getId()
        {
            return id;
        }

        private void setNome(string nome)
        {
            this.nome = nome;
        }

        private string getNome()
        {
            return nome;
        }

        private void setDiasAula(string diasAula)
        {
            this.diasAula = diasAula;
        }

        private string getDiasAula()
        {
            return diasAula;
        }

        private void setAlunos(string alunos)
        {
            this.alunos = alunos;
        }

        private string getAlunos()
        {
            return alunos;
        }

        private void setPreco(float preco)
        {
            this.preco = preco;
        }

        private float getPreco()
        {
            return preco;
        }

        public Modalidade(string nome)
        {
            setNome(nome);
        }

        public Modalidade()
        {

        }

        public bool cadastrarModalidade()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Modalidade (IDModalidade, nomeModalidade, diasModalidade, ativo, precoModalidade, qntdAlunos) values ('" + id + "','" + nome + "','" + diasAula + "', '0', '" + preco + "','" + alunos +"')",DAO_Conexao.con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad;
        }

        

        public bool consultarModalidade()
        {
            bool consult = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select * from Estudio_Modalidade where nomeModalidade = '" + nome + "'",DAO_Conexao.con);
                consult = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return consult;
        }

        public MySqlDataReader consultarTodasModalidade()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select * from Estudio_Modalidade where nomeModalidade = '" + nome + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarIDModalidade()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select IDModalidade from Estudio_Modalidade where nomeModalidade = '" + nome + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarQNTDModalidade()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select qntdAlunos from Estudio_Modalidade where nomeModalidade = '" + nome + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public MySqlDataReader consultarTodasModalidadeTurma()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("Select * from Estudio_Modalidade", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public bool atualizarModalidade()
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Modalidade set nomeModalidade = '" + nome + "', diasModalidade = '" + diasAula + "', precoModalidade = '" + preco + "', qntdAlunos = '" + alunos + "' where IDModalidade = '" + id + "'", DAO_Conexao.con);
                atualiza.ExecuteNonQuery();
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

        public bool reativarModalidade()
        {
            bool reat = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand reativa = new MySqlCommand("update Estudio_Modalidade set ativo = 0 where nomeModalidade = '" + nome + "'", DAO_Conexao.con);
                reativa.ExecuteNonQuery();
                reat = true;
                Console.WriteLine(reat);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return reat;
        }

        public bool excluirModalidade()
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Modalidade set ativo = 1 where nomeModalidade = '" + nome + "'", DAO_Conexao.con);
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
    }
}
