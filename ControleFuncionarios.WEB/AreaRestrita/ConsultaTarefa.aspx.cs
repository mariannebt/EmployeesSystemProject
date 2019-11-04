using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ControleFuncionarios.Entidades;
using ControleFuncionarios.BLL;

namespace ControleFuncionarios.WEB.AreaRestrita
{
    public partial class ConsultaTarefa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListarTarefa();
                CarregarTarefas();
            }


        }

        

        private void ListarTarefa()
        {
            try
            {
                TarefaBusiness business = new TarefaBusiness();
                Tarefa t = new Tarefa();
                List<Tarefa> lista = new List<Tarefa>();
                Funcionario f = (Funcionario)Session["user"];


                lista = business.ConsultarTodas(f.Matricula);

                gridTarefas.DataSource = lista;
                gridTarefas.DataBind();
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = Color.Red;
            }
        }

        private void CarregarTarefas()
        {
            try
            {
                TarefaBusiness business = new TarefaBusiness();
                List<Tarefa> lista = new List<Tarefa>();
                Funcionario f = (Funcionario)Session["user"];

                lista = business.ConsultarTodas(f.Matricula);

                ddlTarefa.DataSource = lista;
                ddlTarefa.DataTextField = "Nome";
                ddlTarefa.DataValueField ="IdTarefa";
                ddlTarefa.DataBind();

                ddlTarefa.Items.Insert(0, new ListItem("- Escolha uma Tarefa - ", ""));
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = Color.Red;
            }
        }

        protected void ddlTarefa_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if( !string.IsNullOrEmpty(ddlTarefa.SelectedValue))
                {
                    int codigo = int.Parse(ddlTarefa.SelectedValue);

                    TarefaBusiness business = new TarefaBusiness();
                    List<Tarefa> lista = new List<Tarefa>();
                    lista = business.ConsultarDDL(codigo);

                    gridTarefas.DataSource = lista;
                    gridTarefas.DataBind();                 

                }
                else
                {
                    ListarTarefa();
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = Color.Red;
            }
        }

    }
}