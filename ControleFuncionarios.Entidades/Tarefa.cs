using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ControleFuncionarios.Entidades
{
    /// <summary>
    /// Modelagem da Entidade Tarefa
    /// </summary>
    public class Tarefa
    {
        #region Atributos
        private int idTarefa;  
        private string nome;
        private string descricao;
        private DateTime dataSolicitacao;
        private DateTime dataEntrega;
        private Status status;
        private Funcionario funcionario;
        private Cargo cargo;
        #endregion

        #region Contrutores
        public Tarefa()
        {
                
        }

        public Tarefa(int idTarefa, string nome, string descricao, DateTime dataSolicitacao, DateTime dataEntrega, Status status)
        {
            IdTarefa = idTarefa;
            Nome = nome;
            Descricao = descricao;
            DataSolicitacao = dataSolicitacao;
            DataEntrega = dataEntrega;
            Status = status;
            
        }


        #endregion

        #region Propriedades

        public int IdTarefa
        {
            set { idTarefa = value; }
            get { return idTarefa; }            
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

        public DateTime DataSolicitacao
        {
            set { dataSolicitacao = value; }
            get { return dataSolicitacao; }            
        }

        public DateTime DataEntrega
        {
            set { dataEntrega = value; }
            get { return dataEntrega; }            
        }

        public Status Status
        {
            set { status = value; }
            get { return status; }            
        }

        public Funcionario Funcionario
        {
            set { funcionario = value; }
            get { return funcionario; }
        }

        public Cargo Cargo
        {
            set { cargo = value; }
            get { return cargo; }
        }
        #endregion

        #region Override
        public override string ToString()
        {
            return "Id: " + idTarefa + ", Nome: " + nome+ "Descricao: " + descricao + ", Data que a Tarefa foi solicitada: " + DataSolicitacao + ", Data que a Tarefa foi entregue: " + dataEntrega + ", Status: " + status;
        }
        #endregion

    }
}
