<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="CadastroCargo.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.CadastroCargo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <h4>Cadastro de Cargo</h4>
    <hr />

    <div class="row">
        <div class="col-md-12">
            <label>Informe o Nome do Cargo:</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="requiredNome" runat="server"
                ControlToValidate="txtNome"
                ErrorMessage="Por favor, informe o nome do cargo."
                ForeColor="Red"
                Display="Dynamic"
                ValidationGroup="formularioCargo"
             />
            <asp:Label ID="lblErroNome" runat="server" />
            <br />

            <label>Informe o Salário referente ao Cargo:</label>
            <asp:TextBox ID="txtSalario" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="requiredSalario" runat="server"
                ControlToValidate="txtSalario"
                ErrorMessage="Por favor, informe o salário referente ao cargo."
                ForeColor="Red"
                Display="Dynamic"
                ValidationGroup="formularioCargo"
             />
            <asp:Label ID="lblErroSalario" runat="server" />
            <br />

            <label>Informe a Descrição do Cargo:</label>
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" TextMode="MultiLine" />
            <asp:RequiredFieldValidator ID="requiredDescricao" runat="server"
                ControlToValidate="txtDescricao"
                ErrorMessage="Por favor, informe a descrição do cargo."
                ForeColor="Red"
                Display="Dynamic"
                ValidationGroup="formularioCargo"
             />
            <asp:Label ID="lblErroDescricao" runat="server" />
            <br />
            <br />

            <asp:Button ID="btnCadastro" runat="server" CssClass="btn btn-success" Text="Cadastrar Cargo"
                ValidationGroup="formularioCargo"
                OnClick="btnCadastro_Click"/>
            <br />
            <br />

            <asp:Label ID="lblMensagem" runat="server" />
        </div>
    </div>


</asp:Content>
