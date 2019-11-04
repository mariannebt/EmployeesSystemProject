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
    public partial class EdicaoPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CarregarPagina();
            }
        }

        protected void btnCadastroPerfil_Click(object sender, EventArgs e)
        {
            if (ValidateField())
            {
                try
                {
                    PerfilBusiness business = new PerfilBusiness();
                    int idPerfil = int.Parse(txtCodigo.Text);
                    Perfil p = business.ConsultarPerfil(idPerfil);

                    p.Nome = txtNomePerfil.Text;
                    p.IdPerfil = int.Parse(txtCodigo.Text);

                    business.Atualizar(p);

                    lblMensagem.Text = "Perfil " + p.Nome + " atualizado com sucesso.";
                    lblMensagem.ForeColor = Color.DarkBlue;
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                    lblMensagem.ForeColor = Color.Red;
                }
            }
        }

        private bool ValidateField()
        {
            bool resultado = true;

            if (string.IsNullOrWhiteSpace(txtNomePerfil.Text))
            {
                lblErroNomePerfil.Text = "Favor, informar o nome do perfil";
                lblErroNomePerfil.ForeColor = Color.Red;

                resultado = false;
            }
            return resultado;

        }

        private void CarregarPagina()
        {
            int idPerfil = int.Parse(Request.QueryString["id"]);

            PerfilBusiness business = new PerfilBusiness();
            Perfil p = business.ConsultarPerfil(idPerfil);

            txtNomePerfil.Text = p.Nome;
            txtCodigo.Text = p.IdPerfil.ToString();
        }
    }
}