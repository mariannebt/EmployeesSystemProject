using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios.BLL.Exceptions
{
    public class PerfilNaoPermiteException : Exception
    {
        public override string Message
        {
            get
            {
                return "Seu perfil não permite esta ação. Por favor, entre em contato com administrador do sistema.";
            }
        }
    }
}
