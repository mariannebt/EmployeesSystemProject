using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFuncionarios.Entidades;
using ControleFuncionarios.DAL;
using ControleFuncionarios.Uteis;
using ControleFuncionarios.BLL.Exceptions;


namespace ControleFuncionarios.BLL
{
    public class FuncionarioBusiness
    {
        
        public void Cadastrar(Funcionario f)
        {
            FuncionarioRepositorio rep = new FuncionarioRepositorio();
            Criptografia cripto = new Criptografia();

            f.Senha = cripto.EncriptarSenhar(f.Senha);
            rep.Insert(f);

        }
        
        public void Atualizar(Funcionario f)
        {
            FuncionarioRepositorio rep = new FuncionarioRepositorio();
            Criptografia cripto = new Criptografia();

            f.Senha = cripto.EncriptarSenhar(f.Senha);
            rep.Update(f);
        }

        public void Excluir(int matricula)
        {
            FuncionarioRepositorio rep = new FuncionarioRepositorio();

            rep.Delete(matricula);
        }

        public Funcionario Autenticar(int matricula, string senha)
        {
            FuncionarioRepositorio rep = new FuncionarioRepositorio();

            Criptografia criptografia = new Criptografia();

            Funcionario f = rep.FindById(matricula, criptografia.EncriptarSenhar(senha));

            if (f != null)
            {
                return f;
            }
            else
            {
                throw new DadosLoginIncorretosException();
            }
        }

        public Funcionario ConsultarExiste(string nome, DateTime dataAdmissao)
        {
            FuncionarioRepositorio rep = new FuncionarioRepositorio();

            Funcionario f = rep.FindById(nome, dataAdmissao);

            if (f != null)
            {
                return f;
            }
            else
            {
                throw new FuncionarioExistenteExcepcion();
            }


        }
    }
}
