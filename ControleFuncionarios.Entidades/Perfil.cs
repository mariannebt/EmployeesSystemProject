using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios.Entidades
{
    /// <summary>
    /// Modelagem da Entidade Perfil do Funcionário
    /// </summary>
    public class Perfil
    {
        #region Atributos
        private int idPerfil;
        private string nome;
        #endregion

        #region Construtores

        public Perfil()
        {

        }

        public Perfil(int idPerfil, string nome)
        {
            IdPerfil = idPerfil;
            Nome = nome;
        }

        #endregion

        #region Propriedades

        public int IdPerfil
        {
            set { idPerfil = value; }
            get { return idPerfil; }
        }

        public string Nome
        {
            set { nome = value; }
            get { return nome; }
        }

        #endregion

        #region Override
        public override string ToString()
        {
            return "Id perfil: " + idPerfil + ", nome do perfil: " + nome;
        }
        #endregion



    }
}
