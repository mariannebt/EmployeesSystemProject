using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFuncionarios.BLL.Exceptions
{
    public class DadosLoginIncorretosException : Exception
    {
        public override string Message
        {
            get
            {
                return "Matricula ou senha incorretos. Por favor, tente novamente.";
            }

        }

    }
}
