﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_Estudio
{
    class DAO_Conexao
    {
        public static MySqlConnection con;

        public static Boolean getConexao(String local, String banco, String user, String senha)
        {
            Boolean retorno = false;
            try
            {
                con = new MySqlConnection("server=" + local + ";User ID=" + user + ";database=" + banco + ";password=" + senha + ";SslMode=none");
                con.Open();
                retorno = true;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                con.Close();
            }
            finally
            {
                con.Close();
            }
            return retorno;
        }

        public static int getLogin(String user, String password)
        {
            int tipo = 0;
            try
            {
                con.Open();
                MySqlCommand login = new MySqlCommand("select * from Estudio_Login where usuario='" + user + "'&& senha='" + password+"'",con);
                MySqlDataReader resultado = login.ExecuteReader();

                if (resultado.Read())
                {
                    tipo = int.Parse(resultado["tipo"].ToString());
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return tipo;
        }

        public static Boolean CadLogin(string usuario, string senha, int tipo)
        {
            bool cad = false;
            try
            {
                con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Login (usuario, senha, tipo) values ('" + usuario + "','" + senha + "'," + tipo + ")", con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            return cad;
        }
    }
}
