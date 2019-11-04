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
    public partial class EdicaoCargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                   
                    CargoBusiness business = new CargoBusiness();

                    int codigo = int.Parse(Request.QueryString["id"]);

                    Cargo c = business.ConsultarPorId(codigo);

                    txtCodigo.Text = c.IdCargo.ToString();
                    txtNome.Text = c.Nome;
                    txtSalario.Text = c.Salario.ToString();
                    txtDescricao.Text = c.Descricao.ToString();

                    business.Atualizar(c);
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
                lblErroNome.Text = "Por Favor, informe o nome do cargo";
                lblErroNome.ForeColor = Color.Red;
                resultado = false;
            }
            if (string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                lblErroSalario.Text = "Por Favor, informe o salário referente ao cargo";
                lblErroSalario.ForeColor = Color.Red;
                resultado = false;
            }
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                lblErroDescricao.Text = "Por Favor, informe a descrição do cargo";
                lblErroDescricao.ForeColor = Color.Red;
                resultado = false;
            }

            return resultado;
        }

       
        protected void Atualizar()
        {
            lblErroNome.Text = string.Empty;
            lblErroSalario.Text = string.Empty;
            lblErroDescricao.Text = string.Empty;
            lblMensagem.Text = string.Empty;

            if (ValidateField())
            {
                try
                {
                    CargoBusiness business = new CargoBusiness();
                    Cargo c = new Cargo();

                    c.IdCargo = int.Parse(txtCodigo.Text);
                    c.Nome = txtNome.Text;
                    c.Salario = decimal.Parse(txtSalario.Text);
                    c.Descricao = txtDescricao.Text;

                    business.Atualizar(c);
                    lblMensagem.Text = "Cargo " + c.Nome + " atualizado com sucesso.";
                }
                catch (Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                    lblMensagem.ForeColor = Color.Red;
                }
            }
        }

        protected void btnEdicao_Click(object sender, EventArgs e)
        {
            Atualizar();

        }

    }
}