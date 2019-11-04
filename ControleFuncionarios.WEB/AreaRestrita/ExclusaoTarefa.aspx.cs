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
    public partial class ExclusaoTarefa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CarregarTarefa();
            }
        }

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                TarefaBusiness business = new TarefaBusiness();
                int idTarefa = int.Parse(txtCodigo.Text);

                business.Excluir(idTarefa);

                Tarefa t = new Tarefa();

                lblMensagem.Text = "Tarefa " + t.Nome + " excluída com sucesso.";
                lblMensagem.ForeColor = Color.DarkBlue;

                btnExcluir.Enabled = false;
            }
            catch (Exception ex)
            {
                lblMensagem.Text = ex.Message;
                lblMensagem.ForeColor = Color.Red;
            }
        }

        private void CarregarTarefa()
        {
            int idTarefa = int.Parse(Request.QueryString["id"]);
            TarefaBusiness business = new TarefaBusiness();

            Tarefa t = business.ConsultarTarefa(idTarefa);

            txtCodigo.Text = t.IdTarefa.ToString();
            txtNome.Text = t.Nome;
            txtDescricao.Text = t.Descricao;

        }
    }
}