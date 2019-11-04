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
    public partial class ExclusaoPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( !IsPostBack)
            {
                CarregarPagina();
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                PerfilBusiness business = new PerfilBusiness();
                int idPerfil = int.Parse(txtCodigo.Text);
                Perfil p = business.ConsultarPerfil(idPerfil);

                p.Nome = txtNome.Text;
                p.IdPerfil = int.Parse(txtCodigo.Text);

                business.Excluir(p.IdPerfil);
                lblMensagem.Text = "Perfil " + p.Nome + " excluído com sucesso.";
                lblMensagem.ForeColor = Color.DarkBlue;

                btnExcluir.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = Color.Red;
            }
        }

        private void CarregarPagina()
        {
            int idPerfil = int.Parse(Request.QueryString["id"]);

            PerfilBusiness business = new PerfilBusiness();
            Perfil p = business.ConsultarPerfil(idPerfil);

            txtNome.Text = p.Nome;
            txtCodigo.Text = p.IdPerfil.ToString();
        }
    }
}