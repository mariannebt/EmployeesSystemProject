using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ControleFuncionarios.Entidades;

namespace ControleFuncionarios.DAL
{
    public class CargoRepositorio : Conexao
    {
        public void Insert(Cargo c)
        {
            OpenConnection();

            string query = "insert into Cargo(Nome, Descricao, Salario) "
                            + "values (@Nome, @Descricao, @Salario)";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Descricao", c.Descricao);
            cmd.Parameters.AddWithValue("@Salario", c.Salario);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Update(Cargo c)
        {
            OpenConnection();

            string query = "update Cargo set Nome = @Nome, Descricao = @Descricao, Salario = @Salario "
                           + "where IdCargo = @IdCargo";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdCargo", c.IdCargo);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@Descricao", c.Descricao);
            cmd.Parameters.AddWithValue("@Salario", c.Salario);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Delete(int idCargo)
        {
            OpenConnection();

            string query = "delete from Cargo where IdCargo = @IdCargo";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdCargo", idCargo);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public List<Cargo> FindAll()
        {
            OpenConnection();

            string query = "select * from Cargo";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Cargo> lista = new List<Cargo>();

            while (dr.Read())
            {
                Cargo c = new Cargo();

                c.IdCargo = Convert.ToInt32(dr["IdCargo"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Descricao = Convert.ToString(dr["Descricao"]);
                c.Salario = Convert.ToDecimal(dr["Salario"]);

                lista.Add(c);
            }

            CloseConnection();
            return lista;
        }

        public List<Cargo> FindAll(int idCargo)
        {
            OpenConnection();

            string query = "select * from Cargo where IdCargo = @IdCargo";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdCargo", idCargo);
            
            dr = cmd.ExecuteReader();

            List<Cargo> lista = new List<Cargo>();

            while (dr.Read())
            {
                Cargo c = new Cargo();

                c.IdCargo = Convert.ToInt32(dr["IdCargo"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Descricao = Convert.ToString(dr["Descricao"]);
                c.Salario = Convert.ToDecimal(dr["Salario"]);

                lista.Add(c);
            }

            CloseConnection();
            return lista;
        }

        public Cargo FindById(int idCargo)
        {
            OpenConnection();

            string query = "select * from Cargo where IdCargo = @IdCargo";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("IdCargo", idCargo);
            dr = cmd.ExecuteReader();

            Cargo c = null;

            if (dr.Read())
            {
                c = new Cargo();

                c.IdCargo = Convert.ToInt32(dr["IdCargo"]);
                c.Nome = Convert.ToString(dr["Nome"]);
                c.Descricao = Convert.ToString(dr["Descricao"]);
                c.Salario = Convert.ToDecimal(dr["Salario"]);

            }

            CloseConnection();
            return c;
        }

    }
}
