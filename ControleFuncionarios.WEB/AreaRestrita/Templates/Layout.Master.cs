using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Security;
using ControleFuncionarios.Entidades;


namespace ControleFuncionarios.WEB.AreaRestrita.Templates
{
    public partial class Layout : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( !IsPostBack)
            {
                Funcionario f = (Funcionario) Session["user"];

                lblNomeCol.Text = f.Nome.ToString();
                lblNomeCol.ForeColor = Color.DarkBlue;
                lblMatricula.Text = "Matrícula: " + Convert.ToString(f.Matricula);
                lblMatricula.ForeColor = Color.DarkBlue;
                
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();

            Session.Remove("user");
            Session.Abandon();

            Response.Redirect("\\Default.aspx");
        }
    }
}