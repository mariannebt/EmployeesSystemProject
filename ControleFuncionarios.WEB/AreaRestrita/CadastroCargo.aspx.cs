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
    public partial class CadastroCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( !IsPostBack)
            {
                lblErroNome.Text = string.Empty;
                lblErroSalario.Text = string.Empty;
                lblErroDescricao.Text = string.Empty;
            }
                
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            if (ValidateField())
            {
                try
                {
                    CargoBusiness business = new CargoBusiness();
                    Cargo c = new Cargo();

                    c.Nome = txtNome.Text;
                    c.Salario = decimal.Parse(txtSalario.Text);
                    c.Descricao = txtDescricao.Text;

                    business.Cadastrar(c);

                    lblMensagem.Text = "Cargo " + c.Nome + " cadastrado com sucesso.";
                    lblMensagem.ForeColor = Color.DarkBlue;

                    txtNome.Text = string.Empty;
                    txtSalario.Text = string.Empty;
                    txtDescricao.Text = string.Empty;
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

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                lblErroNome.Text = "Por favor, informe o nome do cargo.";
                resultado = false;
            }

            if (string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                lblErroSalario.Text = "Por favor, informe o salário referente ao cargo.";
                resultado = false;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                lblErroDescricao.Text = "Por favor, informe a descrição do cargo.";
                resultado = false;
            }


            return resultado;
        }
    }
}