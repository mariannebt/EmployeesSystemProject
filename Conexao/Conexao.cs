using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ControleFuncionarios.Entidades;

namespace ControleFuncionarios.DAL
{
    /// <summary>
    /// Classe de Conexao com o Banco de Dados
    /// </summary>
    public class Conexao
    {
        protected SqlConnection con;
        protected SqlCommand cmd;
        protected SqlDataReader dr;
        protected SqlTransaction tr;


        protected void OpenConnection()
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\USER\Desktop\Marianne\Temas Projeto\Semana setembro\ProjetoControleFuncionarios\ProjetoControleFuncionarios\ControleFuncionarios.WEB\App_Data\Banco.mdf;Integrated Security=True");
            con.Open();
        }


        protected void CloseConnection()
        {
            con.Close();
        }
    }
    
}