using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Web.Security;
using ControleFuncionarios.Entidades;
using ControleFuncionarios.BLL;


namespace ControleFuncionarios.WEB
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblErroSenhaAc.Text = string.Empty;
                lblErroLogin.Text = string.Empty;
                lblMensagemAcessar.Text = string.Empty;

                if( ! IsPostBack)
                {
                    PreenchendoCadastro();
                }
                
            }
            catch (Exception ex)
            {
                lblMensagemAcessar.Text = ex.Message;
                lblMensagemAcessar.ForeColor = Color.Red;
            }
        }

      

        private bool ValidateField()
        {
            bool resultado = true;

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                lblErroNome.Text = "Por favor, informe o nome do colaborador";
                lblErroNome.ForeColor = Color.Red;

                resultado = false;
            }

            if (string.IsNullOrWhiteSpace(TxtEmail.Text))
            {
                lblErroEmail.Text = "Por favor, informe o e-mail do colaborador";
                lblErroEmail.ForeColor = Color.Red;

                resultado = false;
            }

            if (string.IsNullOrWhiteSpace(txtAdmissao.Text))
            {
                lblErroData.Text = "Por favor, informe a data de admissão do colaborador";
                lblErroData.ForeColor = Color.Red;

                resultado = false;
            }

            if (string.IsNullOrWhiteSpace(txtSenhaAcesso.Text))
            {
                lblErroSenha.Text = "Por favor, informe a senha do colaborador";
                lblErroSenha.ForeColor = Color.Red;

                resultado = false;
            }

            if (string.IsNullOrWhiteSpace(txtSenhaConfirm.Text))
            {
                lblErroConfirma.Text = "Por favor, confirme a senha do colaborador";
                lblErroConfirma.ForeColor = Color.Red;

                resultado = false;
            }

            if (string.IsNullOrWhiteSpace(ddlCargo.SelectedValue))
            {
                lblErroCargo.Text = "Por favor, informe o cargo do colaborador";
                lblErroCargo.ForeColor = Color.Red;

                resultado = false;
            }

            if (string.IsNullOrWhiteSpace(ddlPerfil.SelectedValue))
            {
                lblErroPerfil.Text = "Por favor, informe o perfil do colaborador";
                lblErroPerfil.ForeColor = Color.Red;

                resultado = false;
            }

            return resultado;
        }



        private void PreenchendoCadastro()
        {
            CargoBusiness business = new CargoBusiness();
            List<Cargo> lista = business.ConsultarTodos();

            ddlCargo.DataSource = lista;
            ddlCargo.DataValueField = "IdCargo";
            ddlCargo.DataTextField = "Nome";
            ddlCargo.DataBind();

            ddlCargo.Items.Insert(0, new ListItem("- Selecione um Cargo - ", ""));

            PerfilBusiness pbusiness = new PerfilBusiness();
            List<Perfil> todos = pbusiness.ConsultarTodos();

            ddlPerfil.DataSource = todos;
            ddlPerfil.DataValueField = "IdPerfil";
            ddlPerfil.DataTextField = "Nome";
            ddlPerfil.DataBind();

            ddlPerfil.Items.Insert(0, new ListItem("- Selecione um Perfil -", ""));

        }

        protected void btnCadastro_Click1(object sender, EventArgs e)
        {
            lblErroNome.Text = string.Empty;
            lblErroEmail.Text = string.Empty;
            lblErroCargo.Text = string.Empty;
            lblErroPerfil.Text = string.Empty;
            lblErroSenha.Text = string.Empty;
            lblErroConfirma.Text = string.Empty;

            if (ValidateField())
            {
                try
                {

                    Funcionario f = new Funcionario();
                    f.Cargo = new Cargo();
                    f.Perfil = new Perfil();

                    f.Nome = txtNome.Text;
                    f.Email = TxtEmail.Text;
                    f.DataAdmissao = DateTime.Parse(txtAdmissao.Text);
                    f.Senha = txtSenhaAcesso.Text;
                    f.Cargo.IdCargo = int.Parse(ddlCargo.SelectedValue);
                    f.Perfil.IdPerfil = int.Parse(ddlPerfil.SelectedValue);


                    FuncionarioBusiness business = new FuncionarioBusiness();

                    

                    if (business.ConsultarExiste(f.Nome, f.DataAdmissao) != null)
                    {
                        business.Cadastrar(f);

                        lblMensagemCriar.Text = "Conta do Colaborador criada com sucesso";
                        lblMensagemCriar.ForeColor = Color.DarkBlue;

                        txtNome.Text = string.Empty;
                        TxtEmail.Text = string.Empty;
                        txtAdmissao.Text = string.Empty;
                        txtSenhaAcesso.Text = string.Empty;
                        txtSenhaConfirm.Text = string.Empty;
                        ddlCargo.Text = string.Empty;
                        ddlPerfil.Text = string.Empty;
                    }
                    else
                    {
                        throw new Exception();
                    }                   

                }
                catch (Exception ex)
                {
                    lblMensagemCriar.Text = ex.Message;
                    lblMensagemCriar.ForeColor = Color.Red;
                }
            }

        }

        protected void btnAcesso_Click(object sender, EventArgs e)
        {
            try
            {
                FuncionarioBusiness business = new FuncionarioBusiness();

                int login = int.Parse(txtLogin.Text);
                Funcionario f = business.Autenticar(login, txtSenha.Text);

                string matricula = Convert.ToString(f.Matricula);

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(matricula, false, 5);

                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName,FormsAuthentication.Encrypt(ticket));

                Response.Cookies.Add(cookie);

                Session["user"] = f;

                Response.Redirect("/AreaRestrita/Home.aspx");

            }
            catch (Exception ex)
            {
                lblMensagemAcessar.Text = ex.Message;
                lblMensagemAcessar.ForeColor = Color.Red;
            }
        }

        private bool ValidateAcessFields()
        {
            bool resultado = true;

            FuncionarioBusiness business = new FuncionarioBusiness();
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                lblErroLogin.Text = "Por favor, informe seu login";
                lblErroLogin.ForeColor = Color.Red;
                resultado = false;
            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                lblErroSenhaAc.Text = "Por favor, informe sua senha";
                lblErroSenhaAc.ForeColor = Color.Red;
                resultado = false;
            }
            
            return resultado;
        }
        
        

    }
}