using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using ControleFuncionarios.Entidades;
using ControleFuncionarios.BLL;
using ControleFuncionarios.WEB.AreaRestrita.Templates;

namespace ControleFuncionarios.WEB.AreaRestrita
{
    public partial class CadastroTarefa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( ! IsPostBack)
            {
                lblErroDataFim.Text= string.Empty;
                lblErroDataRec.Text = string.Empty;
                lblErroDescr.Text = string.Empty;
                lblErroNome.Text = string.Empty;
                lblErroStatus.Text = string.Empty;
                lblMensagem.Text = string.Empty;
            }
        }

        protected void btnCadastro_Click(object sender, EventArgs e)
        {
            if (ValidateFields())
            {
                try
                {
                    TarefaBusiness business = new TarefaBusiness();
                    Tarefa t = new Tarefa();
                    t.Funcionario = new Funcionario();
                    t.Cargo = new Cargo();

                    t.Nome = txtNome.Text;
                    t.Descricao = txtDescricao.Text;
                    t.DataSolicitacao = DateTime.Parse(txtDataRecebimento.Text);
                    t.DataEntrega = DateTime.Parse(txtDataFim.Text);
                    Funcionario f = (Funcionario) Session["user"];
                    t.Funcionario.Matricula = f.Matricula;
                    t.Cargo.IdCargo = f.Cargo.IdCargo;

                    if (chkStatus1.Checked)
                    {
                        string status = "Pendente";

                        t.Status = (Status)Enum.Parse(typeof(Status), status);
                    }
                    else
                    {
                        if (chkStatus2.Checked)
                        {
                            string status = "Concluida";

                            t.Status = (Status)Enum.Parse(typeof(Status), status);
                        }
                    }

                    business.Cadastrar(t);
                    lblMensagem.Text = "Tarefa " + t.Nome + " cadastrada com sucesso.";
                    lblMensagem.ForeColor = Color.DarkBlue;

                    txtNome.Text = string.Empty;
                    txtDescricao.Text = string.Empty;
                    txtDataRecebimento.Text = string.Empty;
                    txtDataFim.Text = string.Empty;
                    lblErroDataFim.Text = string.Empty;
                    lblErroDataRec.Text = string.Empty;
                    lblErroDescr.Text = string.Empty;
                    lblErroNome.Text = string.Empty;
                    lblErroStatus.Text = string.Empty;
                    
                    
                    chkStatus1.Checked = false;
                    chkStatus1.Enabled = true;
                    chkStatus2.Checked = false;
                    chkStatus2.Enabled = true;
                }
                catch(Exception ex)
                {
                    lblMensagem.Text = ex.Message;
                }
            }
        }

        
        private bool ValidateFields()
        {
            bool resultado = true;

            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                lblErroNome.Text = "Por favor, informe o nome da tarefa";
                lblErroNome.ForeColor = Color.Red;
                resultado = false;
            }


            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                lblErroDescr.Text = "Por favor, informe a descrição da tarefa";
                lblErroDescr.ForeColor = Color.Red;
                resultado = false;
            }


            if (string.IsNullOrWhiteSpace(txtDataRecebimento.Text))
            {
                lblErroDataRec.Text = "Por favor, informe a data de recebimento da tarefa";
                lblErroDataRec.ForeColor = Color.Red;
                resultado = false;
            }

            if (string.IsNullOrWhiteSpace(txtDataFim.Text))
            {
                lblErroDataFim.Text = "Por favor, informe a data de finalização da tarefa";
                lblErroDataFim.ForeColor = Color.Red;
                resultado = false;
            }


            if (DateTime.Parse(txtDataFim.Text) < DateTime.Parse(txtDataRecebimento.Text))
            {
                lblErroDataFim.Text = "Data de entrega deve ser maior que a data de recebimento.";
                lblErroDataFim.ForeColor = Color.Red;
                resultado = false;
            }

            if (! chkStatus1.Checked && ! chkStatus2.Checked)
            {
                lblErroStatus.Text = "Por favor, informe o status da tarefa";
                lblErroStatus.ForeColor = Color.Red;
                resultado = false;
            }

            if (chkStatus1.Checked && chkStatus2.Checked)
            {
                lblErroStatus.Text = "Por favor, informe apenas um status para a tarefa";
                lblErroStatus.ForeColor = Color.Red;
                chkStatus1.Enabled = true;
                chkStatus2.Enabled = true;
                resultado = false;
            }

            if (chkStatus1.Checked && ! chkStatus2.Checked)
            {
                chkStatus2.Enabled = false;
                
            }

            if (chkStatus2.Checked && ! chkStatus1.Checked)
            {
                chkStatus1.Enabled = false;

            }


            return resultado;
        }

        
    }
}