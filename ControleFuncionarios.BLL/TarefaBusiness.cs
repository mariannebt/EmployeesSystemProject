using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ControleFuncionarios.Entidades;
using ControleFuncionarios.DAL;

namespace ControleFuncionarios.BLL
{
    public class TarefaBusiness
    {
        public void Cadastrar(Tarefa t)
        {
            TarefaRepositorio rep = new TarefaRepositorio();
            rep.Insert(t);
        }

        public void Atualizar(Tarefa t)
        {
            TarefaRepositorio rep = new TarefaRepositorio();
            rep.Update(t);
        }

        public void Excluir(int idTarefa)
        {
            TarefaRepositorio rep = new TarefaRepositorio();
            rep.Delete(idTarefa);

        }

        public List<Tarefa> ConsultarTodas()
        {
            TarefaRepositorio rep = new TarefaRepositorio();
            List<Tarefa> lista = new List<Tarefa>();
            return lista = rep.FindAll();

        }

        public List<Tarefa> ConsultarTodas(int matricula)
        {
            TarefaRepositorio rep = new TarefaRepositorio();
            List<Tarefa> lista = new List<Tarefa>();
            return lista = rep.FindAll(matricula);

        }

        public List<Tarefa> ConsultarDDL(int idTarefa)
        {
            TarefaRepositorio rep = new TarefaRepositorio();
            List<Tarefa> lista = new List<Tarefa>();
            return lista = rep.FindList(idTarefa);

        }

        public List<Tarefa> ConsultarTodas(int matricula, DateTime dataIni, DateTime dataFim)
        {
            TarefaRepositorio rep = new TarefaRepositorio();
            List<Tarefa> lista = new List<Tarefa>();
            return lista = rep.FindAll(matricula, dataIni, dataFim);

        }

        public Tarefa ConsultarTarefa(int idTarefa)
        {
            TarefaRepositorio rep = new TarefaRepositorio();
            return rep.FindById(idTarefa);
        }

      
    }
}
