using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios.Entidades
{
    /// <summary>
    /// Modelagem da Entidade Cargo
    /// </summary>
    public class Cargo
    {

        #region Atributos
        private int idCargo;
        private string nome;
        private string descricao;
        private decimal salario;
        private List<Tarefa> tarefas;
        private List<Funcionario> funcionarios;
        #endregion

        #region Contrutores
        public Cargo()
        {

        }

        public Cargo(int idCargo, string nome, string descricao, decimal salario, List<Tarefa> tarefas, List<Funcionario> funcionario)
        {
            IdCargo = idCargo;
            Nome = nome;
            Descricao = descricao;
            Salario = salario;
            Tarefas = tarefas;
            Funcionarios = funcionario;
        }
        #endregion

        #region Propriedades
        
        public int IdCargo
        {
            set { idCargo = value; }
            get { return idCargo; }
        }

        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        public string Descricao
        {
            set { descricao = value; }
            get { return descricao; }
        }

        public decimal Salario
        {
            set { salario = value; }
            get { return salario; }
        }

        public List<Tarefa> Tarefas
        {
            set { tarefas = value; }
            get { return tarefas; }
        }

        public List<Funcionario> Funcionarios
        {
            set { funcionarios = value; }
            get { return funcionarios; }
        }

        #endregion

        #region Override

        public override string ToString()
        {
            return "ID do Cargo: " + idCargo + ", Nome: " + nome + ", Descrição: " + descricao + ", Salário: " + salario;
        }
        #endregion
    }
}
