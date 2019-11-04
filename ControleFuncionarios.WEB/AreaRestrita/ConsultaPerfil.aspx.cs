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
    public partial class ConsultaPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CarregarPagina();
            }
        }

        private void CarregarPagina()
        {
            try
            {
                PerfilBusiness business = new PerfilBusiness();

                List<Perfil> lista = business.ConsultarTodos();

                gridPerfis.DataSource = lista;
                gridPerfis.DataBind();


            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = Color.Red;
            }
        }
    }
}