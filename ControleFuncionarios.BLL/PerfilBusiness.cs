using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFuncionarios.DAL;
using ControleFuncionarios.Entidades;

namespace ControleFuncionarios.BLL
{
    public class PerfilBusiness
    {
        public void Cadastrar(Perfil p)
        {
            PerfilRepositorio rep = new PerfilRepositorio();
            rep.Insert(p);

        }

        public void Atualizar(Perfil p)
        {
            PerfilRepositorio rep = new PerfilRepositorio();
            rep.Update(p);
        }

        public void Excluir(int idPerfil)
        {
            PerfilRepositorio rep = new PerfilRepositorio();
            rep.Delete(idPerfil);
        }

        public List<Perfil> ConsultarTodos()
        {
            PerfilRepositorio rep = new PerfilRepositorio();
            List<Perfil> lista = rep.FindAll();
            return lista;
        }

        public Perfil ConsultarPerfil(int idPerfil)
        {
            PerfilRepositorio rep = new PerfilRepositorio();
            Perfil p = rep.FindById(idPerfil);
            return p;
        }
    }
}
