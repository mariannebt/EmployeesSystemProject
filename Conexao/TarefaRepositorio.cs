using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ControleFuncionarios.Entidades;

namespace ControleFuncionarios.DAL
{
    public class TarefaRepositorio : Conexao
    {
        public void Insert(Tarefa t)
        {
            OpenConnection();
    
                string query = "insert into Tarefa(Nome, Descricao, Status, DataEntrega, DataSolicitacao, Matricula, IdCargo) "
                                + "values (@Nome, @Descricao, @Status, @DataEntrega, @DataSolicitacao, @Matricula, @IdCargo)";

                cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Nome", t.Nome);
                cmd.Parameters.AddWithValue("@Descricao", t.Descricao);
                cmd.Parameters.AddWithValue("@Status", t.Status);
                cmd.Parameters.AddWithValue("@DataEntrega", t.DataEntrega);
                cmd.Parameters.AddWithValue("@DataSolicitacao", t.DataSolicitacao);
                cmd.Parameters.AddWithValue("@Matricula", t.Funcionario.Matricula);
                cmd.Parameters.AddWithValue("@IdCargo", t.Cargo.IdCargo);
                cmd.ExecuteNonQuery();
              
            CloseConnection();
        }

        public void Update(Tarefa t)
        {
            OpenConnection();

            string query = "update Tarefa set Nome = @Nome, Descricao= @Descricao, Status = @Status, DataEntrega = @DataEntrega, DataSolicitacao = @DataSolicitacao "
                            + "where IdTarefa = @IdTarefa";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdTarefa", t.IdTarefa);
            cmd.Parameters.AddWithValue("@Nome", t.Nome);
            cmd.Parameters.AddWithValue("@Descricao", t.Descricao);
            cmd.Parameters.AddWithValue("@Status", t.Status);
            cmd.Parameters.AddWithValue("@DataEntrega", t.DataEntrega);
            cmd.Parameters.AddWithValue("@DataSolicitacao", t.DataSolicitacao);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public void Delete(int idTarefa)
        {
            OpenConnection();

            string query = "delete from Tarefa where IdTarefa = @IdTarefa";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdTarefa", idTarefa);
            cmd.ExecuteNonQuery();

            CloseConnection();
        }

        public List<Tarefa> FindAll()
        {
            OpenConnection();

            string query = "select t.Nome, t.Descricao, t.DataEntrega, t.DataSolicitacao, t.Status, f.Matricula, f.Nome as NomeFuncionario "
                            + "from Tarefa t inner join Funcionario f " +
                            "on f.Matricula = t.Matricula";

            cmd = new SqlCommand(query, con);
            dr = cmd.ExecuteReader();

            List<Tarefa> lista = new List<Tarefa>();

            while (dr.Read())
            {
                Tarefa t = new Tarefa();
                t.Funcionario = new Funcionario();

                t.IdTarefa = Convert.ToInt32(dr["IdTarefa"]);
                t.Nome = Convert.ToString(dr["Nome"]);
                t.Descricao = Convert.ToString(dr["Descricao"]);
                t.DataSolicitacao = Convert.ToDateTime(dr["DataSolicitacao"]);
                t.DataEntrega = Convert.ToDateTime(dr["DataEntrega"]);
                t.Funcionario.Matricula = Convert.ToInt32(dr["Matricula"]);
                t.Funcionario.Nome = Convert.ToString(dr["NomeFuncionario"]);

                string status = Convert.ToString(dr["Status"]);
                t.Status = (Status)Enum.Parse(typeof(Status), status);

                lista.Add(t);

            }
            CloseConnection();
            return lista;
        }


        public List<Tarefa> FindAll(int matricula)
        {
            OpenConnection();

            string query = "select IdTarefa, Nome, Descricao, Status, DataEntrega, DataSolicitacao "
                            + "from Tarefa "
                            + "where Matricula = @Matricula";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            dr = cmd.ExecuteReader();

            List<Tarefa> lista = new List<Tarefa>();

            while (dr.Read())
            {
                Tarefa t = new Tarefa();
                t.Funcionario = new Funcionario();

                t.IdTarefa = Convert.ToInt32(dr["IdTarefa"]);
                t.Nome = Convert.ToString(dr["Nome"]);
                t.Descricao = Convert.ToString(dr["Descricao"]);
                t.DataSolicitacao = Convert.ToDateTime(dr["DataSolicitacao"]);
                t.DataEntrega = Convert.ToDateTime(dr["DataEntrega"]);

                string status = Convert.ToString(dr["Status"]);
                t.Status = (Status)Enum.Parse(typeof(Status), status);

                lista.Add(t);

            }
            CloseConnection();
            return lista;
        }

        public List<Tarefa> FindList(int idTarefa)
        {
            OpenConnection();

            string query = "select IdTarefa, Nome, Descricao, Status, DataEntrega, DataSolicitacao "
                            + "from Tarefa "
                            + "where IdTarefa = @IdTarefa";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdTarefa", idTarefa);
            dr = cmd.ExecuteReader();

            List<Tarefa> lista = new List<Tarefa>();

            while (dr.Read())
            {
                Tarefa t = new Tarefa();
                
                t.IdTarefa = Convert.ToInt32(dr["IdTarefa"]);
                t.Nome = Convert.ToString(dr["Nome"]);
                t.Descricao = Convert.ToString(dr["Descricao"]);
                t.DataSolicitacao = Convert.ToDateTime(dr["DataSolicitacao"]);
                t.DataEntrega = Convert.ToDateTime(dr["DataEntrega"]);

                string status = Convert.ToString(dr["Status"]);
                t.Status = (Status)Enum.Parse(typeof(Status), status);

                lista.Add(t);

            }
            CloseConnection();
            return lista;
        }

        public List<Tarefa> FindAll(int matricula, DateTime dataIni, DateTime dataFim)
        {
            OpenConnection();

            string query = "select IdTarefa, Nome, Descricao, DataEntrega, DataSolicitacao, Status "
                            + "from Tarefa " 
                            + "where Matricula = @Matricula and DataEntrega between @DataIni and @DataFim " 
                            + "order by DataEntrega asc";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            cmd.Parameters.AddWithValue("@DataIni", dataIni);
            cmd.Parameters.AddWithValue("@DataFim", dataFim);
            dr = cmd.ExecuteReader();

            List<Tarefa> lista = new List<Tarefa>();

            while (dr.Read())
            {
                Tarefa t = new Tarefa();
                

                t.IdTarefa = Convert.ToInt32(dr["IdTarefa"]);
                t.Nome = Convert.ToString(dr["Nome"]);
                t.Descricao = Convert.ToString(dr["Descricao"]);
                t.DataSolicitacao = Convert.ToDateTime(dr["DataSolicitacao"]);
                t.DataEntrega = Convert.ToDateTime(dr["DataEntrega"]);
                

                string status = Convert.ToString(dr["Status"]);
                t.Status = (Status)Enum.Parse(typeof(Status), status);

                lista.Add(t);

            }
            CloseConnection();
            return lista;
        }


        public Tarefa FindById(int idTarefa)
        {
            OpenConnection();

            string query = "select IdTarefa, Nome, Descricao, DataEntrega, DataSolicitacao "
                            + "from Tarefa "                          
                            + "where IdTarefa = @IdTarefa";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdTarefa", idTarefa);
            dr = cmd.ExecuteReader();

            Tarefa t = null;

            if (dr.Read())
            {
                t = new Tarefa();
                t.Funcionario = new Funcionario();

                t.IdTarefa = Convert.ToInt32(dr["IdTarefa"]);
                t.Nome = Convert.ToString(dr["Nome"]);
                t.Descricao = Convert.ToString(dr["Descricao"]);
                t.DataSolicitacao = Convert.ToDateTime(dr["DataSolicitacao"]);
                t.DataEntrega = Convert.ToDateTime(dr["DataEntrega"]);
                
            }

            CloseConnection();
            return t;
        }

        public Tarefa FindById(int idTarefa, int matricula)
        {
            OpenConnection();

            string query = "select t.IdTarefa, t.Nome, t.Descricao, t.DataEntrega, t.DataSolicitacao, t.Status, f.Matricula, f.Nome as NomeFuncionario "
                            + "from Tarefa t inner join Funcionario f " +
                            "on f.Matricula = t.Matricula "
                            + "where IdTarefa = @IdTarefa and Matricula = @Matricula";

            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@IdTarefa", idTarefa);
            cmd.Parameters.AddWithValue("@Matricula", matricula);
            dr = cmd.ExecuteReader();

            Tarefa t = null;

            if (dr.Read())
            {
                t = new Tarefa();
                t.Funcionario = new Funcionario();

                t.IdTarefa = Convert.ToInt32(dr["IdTarefa"]);
                t.Nome = Convert.ToString(dr["Nome"]);
                t.Descricao = Convert.ToString(dr["Descricao"]);
                t.DataSolicitacao = Convert.ToDateTime(dr["DataSolicitacao"]);
                t.DataEntrega = Convert.ToDateTime(dr["DataEntrega"]);
                t.Funcionario.Matricula = Convert.ToInt32(dr["Matricula"]);
                t.Funcionario.Nome = Convert.ToString(dr["NomeFuncionario"]);

                string status = Convert.ToString(dr["Status"]);
                t.Status = (Status)Enum.Parse(typeof(Status), status);

            }

            CloseConnection();
            return t;
        }

        


    }
}
