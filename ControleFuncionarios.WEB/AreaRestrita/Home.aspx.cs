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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                try
                {
                    Funcionario f = (Funcionario)Session["user"];

                    TarefaBusiness business = new TarefaBusiness();
                    Tarefa t = new Tarefa();

                    DateTime dataAtual = StartOfWeek(DateTime.Now);
                    DateTime dataFinal = EndOfWeek(DateTime.Now);
                    List<Tarefa> lista = business.ConsultarTodas(f.Matricula, dataAtual, dataFinal);

                    listTarefasSemana.DataSource = lista;
                    listTarefasSemana.DataBind();
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                    lblMensagem.ForeColor = Color.Red;
                }
            }
        }

        private DateTime StartOfWeek(DateTime dt)
        {
            int diff = dt.DayOfWeek - DayOfWeek.Sunday;
            if (diff < 0)
            {
                diff += 7;
            }
            return dt.AddDays(-1 * diff).Date;
        }

        private DateTime EndOfWeek(DateTime dt)
        {
            return StartOfWeek(dt).AddDays(6).AddHours(23).AddMinutes(59);
        }

    }
}