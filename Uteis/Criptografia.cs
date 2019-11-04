using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ControleFuncionarios.Uteis
{/// <summary>
/// Classe de criptografia da senha do funcionario
/// </summary>
    public class Criptografia
    {
        public string EncriptarSenhar(string senha)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
          
            byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);
            
            byte[] hash = md5.ComputeHash(senhaBytes); //criptografando..

            string resultado = string.Empty; //vazio..

            foreach (byte b in hash)
            {
                resultado += b.ToString("X");
            }
            return resultado;

        }

    }
}
