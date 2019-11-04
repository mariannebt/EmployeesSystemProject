using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleFuncionarios.DAL;
using ControleFuncionarios.Entidades;
using ControleFuncionarios.BLL.Exceptions;

namespace ControleFuncionarios.BLL
{
    public class CargoBusiness
    {
        public void Cadastrar(Cargo c)
        {
            Perfil p = new Perfil();

            
                CargoRepositorio rep = new CargoRepositorio();
                rep.Insert(c);
            
        }

        public void Atualizar(Cargo c)
        {
            CargoRepositorio rep = new CargoRepositorio();
            rep.Update(c);


        }

        public void Excluir(int idCargo)
        {
            CargoRepositorio rep = new CargoRepositorio();
            rep.Delete(idCargo);

        }

        public List<Cargo> ConsultarTodos()
        {
            CargoRepositorio rep = new CargoRepositorio();

            return rep.FindAll();

        }

        public List<Cargo> ConsultarTodos(int idCargo)
        {
            CargoRepositorio rep = new CargoRepositorio();
            

            return rep.FindAll(idCargo);

        }

        public Cargo ConsultarPorId(int idCargo)
        {
            CargoRepositorio rep = new CargoRepositorio();

            Cargo c = rep.FindById(idCargo);

            return c;

        }

    }


    
}
