using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ControleFuncionarios.BLL;
using ControleFuncionarios.Entidades;

namespace ControleFuncionarios.WEB.AreaRestrita
{
    public partial class ConsultaCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConsultarCargo();
                CarregarCargo();
            }

        }
        private void CarregarCargo()
        {
            try
            {
                CargoBusiness business = new CargoBusiness();
                List<Cargo> lista = business.ConsultarTodos();

                ddlCargo.DataSource = lista;
                ddlCargo.DataTextField = "Nome";
                ddlCargo.DataValueField = "IdCargo";
                ddlCargo.DataBind();

                ddlCargo.Items.Insert(0, new ListItem("- Escolha um Cargo - ", ""));

            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = Color.Red;
            }
        }

        private void ConsultarCargo()
        {
            try
            {
                CargoBusiness business = new CargoBusiness();
                List<Cargo> lista = business.ConsultarTodos();

                gridCargos.DataSource = lista;
                gridCargos.DataBind();

            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = Color.Red;
            }
            
        }

       
        protected void ddlCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if( !string.IsNullOrEmpty(ddlCargo.SelectedValue))
                {
                    int codigo = int.Parse(ddlCargo.SelectedValue);

                    CargoBusiness business = new CargoBusiness();
                    List<Cargo> lista = business.ConsultarTodos(codigo);

                    gridCargos.DataSource = lista;
                    gridCargos.DataBind();

                }
                else
                {
                    ConsultarCargo();
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