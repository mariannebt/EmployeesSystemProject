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
    public partial class ExclusaoCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int codigo = int.Parse(Request.QueryString["id"]);

                CargoBusiness business = new CargoBusiness();
                Cargo c = business.ConsultarPorId(codigo);

                txtCodigo.Text = c.IdCargo.ToString();
                txtNome.Text = c.Nome;
                txtDescricao.Text = c.Descricao;
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                CargoBusiness business = new CargoBusiness();
                int codigo = int.Parse(txtCodigo.Text);
                business.Excluir(codigo);
                Cargo c = new Cargo();

                lblMensagem.Text = "Cargo " + c.Nome + " excluído com sucesso.";
                lblMensagem.ForeColor = Color.DarkBlue;

                txtCodigo.Text = string.Empty;
                txtNome.Text = string.Empty;
                txtDescricao.Text = string.Empty;

                btnExcluir.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = Color.Red;
            }
            
        }
    }
}