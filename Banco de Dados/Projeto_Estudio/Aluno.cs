using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Estudio
{
    class Aluno
    {
        #region
        private string Senha;
        #endregion
        private string CPF;
        private string Nome;
        private string Rua;
        private string Numero;
        private string Bairro;
        private string Complemento;
        private string CEP;
        private string Cidade;
        private string Estado;
        private string Telefone;
        private string Email;

        public Aluno(string cpf, string nome, string rua, string numero, string bairro, string complemento, string cep, string cidade, string estado, string telefone, string email)
        {
            setCPF(cpf);
            setNome(nome);
            setRua(rua);
            setNumero(numero);
            setBairro(bairro);
            setComplemento(complemento);
            setCEP(cep);
            setCidade(cidade);
            setEstado(estado);
            setTelefone(telefone);
            setEmail(email);
        }

        private void setCPF(string cpf)
        {
            this.CPF = cpf;
        }
        private string getCPF()
        {
            return CPF;
        }

        private void setNome(string nome)
        {
            this.Nome = nome;
        }
        private string getNome()
        {
            return Nome;
        }

        private void setRua(string rua)
        {
            this.Rua = rua;
        }
        private string getRua()
        {
            return Rua;
        }

        private void setNumero(string numero)
        {
            this.Numero = numero;
        }
        private string getNumero()
        {
            return Numero;
        }
        private void setBairro(string bairro)
        {
            this.Bairro = bairro;
        }
        private string getBairro()
        {
            return Bairro;
        }
        private void setComplemento(string complemento)
        {
            this.Complemento = complemento;
        }
        private string getComplemento()
        {
            return Complemento;
        }
        private void setCEP(string cep)
        {
            this.CEP = cep;
        }
        private string getCEP()
        {
            return CEP;
        }
        private void setCidade(string cidade)
        {
            this.Cidade = cidade;
        }
        private string getCidade()
        {
            return Cidade;
        }
        private void setEstado(string estado)
        {
            this.Estado = estado;
        }
        private string getEstado()
        {
            return Estado;
        }
        private void setTelefone(string telefone)
        {
            this.Telefone = telefone;
        }
        private string getTelefone()
        {
            return Telefone;
        }
        private void setEmail(string email)
        {
            this.Email = email;
        }
        private string getEmail()
        {
            return Email;
        }

        public Aluno(string cpf)
        {
            setCPF(cpf);
        }

        public bool cadastrarAluno()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Aluno (CPFAluno, nomeAluno, ruaAluno, numeroAluno, bairroAluno, complementoAluno, CEPAluno, cidadeAluno, estadoAluno, telefoneAluno, emailAluno) values ('" + CPF + "','" + Nome + "','" + Rua + "','" + Numero + "','" + Bairro + "','" + Complemento + "','" + CEP + "','" + Cidade + "','" + Estado + "','" + Telefone + "','" + Email + "')", DAO_Conexao.con);
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

        public bool excluirAluno()
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Aluno set ativo = 1 where CPFAluno = '" + this.CPF + "'", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                exc = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return exc;
        }

        public bool consultarAluno()
        {
            bool consult = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Aluno where CPFAluno = '" + this.CPF + "'", DAO_Conexao.con);
                Console.WriteLine("select * from Estudio_Aluno where CPFAluno = '" + this.CPF + "'");
                MySqlDataReader resultado = consulta.ExecuteReader();
                if (resultado.Read())
                {
                    consult = true;
                }
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

        public MySqlDataReader consultarAlunoUpdate()
        {
            MySqlDataReader resultado = null;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consulta = new MySqlCommand("select * from Estudio_Aluno where CPFAluno = '" + this.CPF + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return resultado;
        }

        public bool atualizarAluno()
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand atualiza = new MySqlCommand("update Estudio_Aluno set nomeAluno = '" + Nome + "', ruaAluno = '" + Rua + "', numeroAluno = '" + Numero + "', bairroAluno = '" + Bairro + "', complementoAluno = '" + Complemento + "', CEPAluno = '" + CEP + "', cidadeAluno = '" + Cidade + "', estadoAluno = '" + Estado + "', telefoneAluno = '" + Telefone + "', emailAluno = '" + Email + "' where CPFAluno = '" + CPF +"'", DAO_Conexao.con);
                atualiza.ExecuteNonQuery();
                exc = true;
            }
            catch(Exception ex)
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