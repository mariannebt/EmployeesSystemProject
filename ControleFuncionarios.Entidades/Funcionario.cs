using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios.Entidades
{
    /// <summary>
    /// Modelagem da Entidade Funcionario
    /// </summary>
    public class Funcionario
    {
        #region Atributos

        private int matricula;
        private string nome;
        private string senha;
        private string email;
        private DateTime dataAdmissao;
        private Cargo cargo;
        private List<Tarefa> tarefas;
        private Perfil perfil;
        #endregion

        #region Contrutores

        public Funcionario()
        {

        }

        public Funcionario(int matricula, string nome, string senha, string email, DateTime dataAdmissao, Cargo cargo, List<Tarefa> tarefas)
        {
            Matricula = matricula;
            Nome = nome;
            Senha = senha;
            Email = email;
            DataAdmissao = dataAdmissao;
            Cargo = cargo;
            Tarefas = tarefas;
        }
        #endregion

        #region Propriedades

        public int Matricula
        {
            set { matricula = value; }
            get { return matricula; }
        }

        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        public string Senha
        {
            set { senha = value; }
            get { return senha; }
        }

        public string Email
        {
            set { email = value; }
            get { return email; }
        }

        public DateTime DataAdmissao
        {
            set { dataAdmissao = value; }
            get { return dataAdmissao; }
        }

        public Cargo Cargo
        {
            set { cargo = value; }
            get { return cargo; }
        }

        public List<Tarefa> Tarefas
        {
            set { tarefas = value; }
            get { return tarefas; }
        }

        public Perfil Perfil
        {
            set { perfil = value; }
            get { return perfil; }
        } 
        #endregion

        #region Override
        public override string ToString()
        {
            return "Matrícula do Funcionário: " + matricula + ", Nome: " + nome + ", E-mail " + email + ", Data da Admissão: " + dataAdmissao;
        }
        #endregion



    }
}
