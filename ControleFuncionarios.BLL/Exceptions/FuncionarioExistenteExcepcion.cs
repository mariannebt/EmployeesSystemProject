using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios.BLL.Exceptions
{
    public class FuncionarioExistenteExcepcion : Exception
    {
        public override string Message
        {
            get
            {
                return "Usuário provavelmente já existe. Por favor, procure o administrador.";
            }

        }
    }
}
