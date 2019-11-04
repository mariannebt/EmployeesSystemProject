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
    public partial class CadastroPerfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    lblErroNomePerfil.Text = string.Empty;
                    lblMensagem.Text = string.Empty;

                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                }
            }

        }

        protected void btnCadastroPerfil_Click(object sender, EventArgs e)
        {
            if (ValidateField())
            {
                try
                {
                    PerfilBusiness business = new PerfilBusiness();
                    Perfil p = new Perfil();

                    p.Nome = txtNomePerfil.Text;

                    business.Cadastrar(p);

                    lblMensagem.Text = "Perfil " + p.Nome + " cadastrado com sucesso.";
                    lblMensagem.ForeColor = Color.DarkBlue;

                    txtNomePerfil.Text = string.Empty;
                 
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
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
    }
}