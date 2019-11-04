using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ControleFuncionarios.Entidades;

namespace ControleFuncionarios.DAL
{
    public class FuncionarioRepositorio : Conexao
    {

        public void Insert(Funcionario f)
        {
            OpenConnection();

            string query = "insert into Funcionario(Nome, Email, Senha, DataAdmissao, IdCargo, IdPerfil) "
                            + "values(@Nome, @Email, @Senha, @DataAdmissao, @IdCargo, @IdPerfil)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", f.Nome);
            cmd.Parameters.AddWithValue("@Email", f.Email);
            cmd.Parameters.AddWithValue("@Senha", f.Senha);
            cmd.Parameters.AddWithValue("@DataAdmissao", f.DataAdmissao);
            cmd.Parameters.AddWithValue("@IdCargo", f.Cargo.IdCargo);
            cmd.Parameters.AddWithValue("@IdPerfil", f.Perfil.IdPerfil);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Update(Funcionario f)
        {
            OpenConnection();

            string query = "update Funcionario set Nome = @Nome, Email = @Email, Senha = @Senha, DataAdmissao=@DataAdmissao, IdCargo = @IdCargo "
                            + "where Matricula = @Matricula";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Matricula", f.Matricula);
            cmd.Parameters.AddWithValue("@Nome", f.Nome);
            cmd.Parameters.AddWithValue("@Email", f.Email);
            cmd.Parameters.AddWithValue("@Senha", f.Senha);
            cmd.Parameters.AddWithValue("@DataAdmissao", f.DataAdmissao);
            cmd.Parameters.AddWithValue("@IdCargo", f.Cargo.IdCargo);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Delete(int matricula)
        {
            OpenConnection();

            string query = "delete from Funcionario where Matricula = @Matricula";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public List<Funcionario> FindAll()
        {
            OpenConnection();

            string query = "select f.Matricula, f.Nome, f.Email, f.DataAdmissao, c.IdCargo, c.Nome as NomeCargo, c.Descricao, p.Nome as NomePerfil "
                            + "from Funcionario f inner join Cargo c and Perfil p " +
                            "on c.IdCargo = f.IdCargo and p.Perfil = f.Perfil";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Funcionario> lista = new List<Funcionario>();

            while (dr.Read())
            {
                Funcionario f = new Funcionario();
                f.Cargo = new Cargo();

                f.Matricula = Convert.ToInt32(dr["Matricula"]);
                f.Nome = Convert.ToString(dr["Nome"]);
                f.Email = Convert.ToString(dr["Email"]);
                f.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]);
                f.Cargo.IdCargo = Convert.ToInt32(dr["IdCargo"]);
                f.Cargo.Nome = Convert.ToString(dr["NomeCargo"]);
                f.Cargo.Descricao = Convert.ToString(dr["Descricao"]);
                f.Perfil.Nome = Convert.ToString(dr["NomePerfil"]);

                lista.Add(f);

            }
            CloseConnection();
            return lista;
        }


        public List<Funcionario> FindAll(int idCargo)
        {
            OpenConnection();

            string query = "select f.Matricula, f.Nome, f.Email, f.DataAdmissao, c.IdCargo, c.Nome as NomeCargo, c.Descricao "
                            + "from Funcionario f inner join Cargo c " +
                            "on c.IdCargo = f.IdCargo "
                            + "where f.IdCargo = @IdCargo";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdCargo", idCargo);
            dr = cmd.ExecuteReader();

            List<Funcionario> lista = new List<Funcionario>();

            while (dr.Read())
            {
                Funcionario f = new Funcionario();
                f.Cargo = new Cargo();

                f.Matricula = Convert.ToInt32(dr["Matricula"]);
                f.Nome = Convert.ToString(dr["Nome"]);
                f.Email = Convert.ToString(dr["Email"]);
                f.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]);
                f.Cargo.IdCargo = Convert.ToInt32(dr["IdCargo"]);
                f.Cargo.Nome = Convert.ToString(dr["NomeCargo"]);
                f.Cargo.Descricao = Convert.ToString(dr["Descricao"]);

                lista.Add(f);

            }
            CloseConnection();
            return lista;
        }

        public Funcionario FindById(int matricula)
        {
            OpenConnection();

            string query = "select f.Nome, f.Email, f.DataAdmissao, c.IdCargo, c.Nome as NomeCargo, c.Descricao, p.Nome as NomePerfil "
                            + "from Funcionario f inner join Cargo c and Perfil p "
                            + "on c.IdCargo = f.IdCargo and p.IdPerfil = f.IdPerfil "
                            + "where Matricula = @Matricula";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            dr = cmd.ExecuteReader();

            Funcionario f = null;

            if (dr.Read())
            {
                f = new Funcionario();
                f.Cargo = new Cargo();

                f.Matricula = Convert.ToInt32(dr["Matricula"]);
                f.Nome = Convert.ToString(dr["Nome"]);
                f.Email = Convert.ToString(dr["Email"]);
                f.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]);
                f.Cargo.IdCargo = Convert.ToInt32(dr["IdCargo"]);
                f.Cargo.Nome = Convert.ToString(dr["NomeCargo"]);
                f.Cargo.Descricao = Convert.ToString(dr["Descricao"]);
                f.Perfil.Nome = Convert.ToString(dr["NomePerfil"]);
            }

            CloseConnection();
            return f;
        }

        public Funcionario FindById(int matricula, string senha)
        {
            OpenConnection();

            string query = "select * from Funcionario where Matricula = @Matricula and Senha = @Senha";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            cmd.Parameters.AddWithValue("@Senha", senha);
            dr = cmd.ExecuteReader();

            Funcionario f = null;

            if (dr.Read())
            {
                f = new Funcionario();
                f.Cargo = new Cargo();
                f.Perfil = new Perfil();

                f.Matricula = Convert.ToInt32(dr["Matricula"]);
                f.Nome = Convert.ToString(dr["Nome"]);
                f.Email = Convert.ToString(dr["Email"]);
                f.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]);
                f.Cargo.IdCargo = Convert.ToInt32(dr["IdCargo"]);  
                f.Perfil.IdPerfil = Convert.ToInt32(dr["IdPerfil"]);
            }

            CloseConnection();
            return f;
        }

        public Funcionario FindById(string nome, DateTime dataAdmissao)
        {
            OpenConnection();

            string query = "select * from Funcionario where Nome = @Nome and DataAdmissao = @DataAdmissao";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@DataAdmissao", dataAdmissao);
            dr = cmd.ExecuteReader();

            Funcionario f = null;

            if (dr.Read())
            {
                f = new Funcionario();
                
                f.Matricula = Convert.ToInt32(dr["Matricula"]);
                f.Nome = Convert.ToString(dr["Nome"]);
                f.Email = Convert.ToString(dr["Email"]);
                f.DataAdmissao = Convert.ToDateTime(dr["DataAdmissao"]);

            }

            CloseConnection();
            return f;
        }


    }
}
