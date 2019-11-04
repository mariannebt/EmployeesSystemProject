using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ControleFuncionarios.Entidades;

namespace ControleFuncionarios.DAL
{
    public class PerfilRepositorio : Conexao
    {
        public void Insert(Perfil p)
        {
            OpenConnection();

            string query = "insert into Perfil(Nome) values(@Nome)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", p.Nome);
            cmd.ExecuteNonQuery();


            CloseConnection();
        }

        public void Update(Perfil p)
        {
            OpenConnection();

            string query = "update Perfil set Nome = @Nome where IdPerfil = @IdPerfil";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("IdPerfil", p.IdPerfil);
            cmd.Parameters.AddWithValue("@Nome", p.Nome);
            cmd.ExecuteNonQuery();


            CloseConnection();
        }

        public void Delete(int idPerfil)
        {
            OpenConnection();

            string query = "delete from Perfil where IdPerfil = @IdPerfil";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("IdPerfil", idPerfil);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public List<Perfil> FindAll()
        {
            OpenConnection();

            string query = "select * from Perfil";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Perfil> lista = new List<Perfil>();

            while (dr.Read())
            {
                Perfil p = new Perfil();
                
                p.IdPerfil = Convert.ToInt32(dr["IdPerfil"]);
                p.Nome = Convert.ToString(dr["Nome"]);
               
                lista.Add(p);

            }

            CloseConnection();
            return lista;
        }

        public Perfil FindById(int idPerfil)
        {
            OpenConnection();

            string query = "select * from Perfil where IdPerfil = @IdPerfil";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdPerfil", idPerfil);
            dr = cmd.ExecuteReader();

            Perfil p = null;

            if (dr.Read())
            {
                p = new Perfil();

                p.IdPerfil = Convert.ToInt32(dr["IdPerfil"]);
                p.Nome = Convert.ToString(dr["Nome"]);

            }

            CloseConnection();
            return p;
        }
    }
}
