<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="EdicaoCargo.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.EdicaoCargo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">

    <h4>Edição de Cargo</h4>
    <a href="/AreaRestrita/ConsultaCargo.aspx">Voltar</a>
    <hr />
    <br />

    <div class="row">
        <div class="col-md-8">
            <label>Código do Cargo</label>
            <asp:TextBox ID="txtCodigo" runat="server"
                CssClass="form-control" ReadOnly="true" />
            <br />

             <label>Nome do Cargo</label>
            <asp:TextBox ID="txtNome" runat="server"
                CssClass="form-control" />
            <asp:RequiredFieldValidator ID="requiredNome" runat="server"
                ControlToValidate="txtNome"
                ErrorMessage="Por favor, informe o nome do cargo."
                ForeColor="Red"
                Display="Dynamic"
                ValidationGroup="formularioCargo" />
            <asp:Label ID="lblErroNome" runat="server" />
            <br />

             <label>Salário do Cargo</label>
            <asp:TextBox ID="txtSalario" runat="server"
                CssClass="form-control" />
            <asp:RequiredFieldValidator ID="requiredSalario" runat="server"
                ControlToValidate="txtSalario"
                ErrorMessage="Por favor, informe o salário referente ao cargo"
                ForeColor="Red"
                Display="Dynamic"
                ValidationGroup="formularioCargo" />
            <asp:Label ID="lblErroSalario" runat="server" />
            <br />

             <label>Descrição do Cargo</label>
            <asp:TextBox ID="txtDescricao" runat="server"
                CssClass="form-control" TextMode="MultiLine"/>
            <asp:RequiredFieldValidator ID="requiredDescricao" runat="server"
                ControlToValidate="txtDescricao"
                ErrorMessage="Por favor, informe a descrição do cargo"
                ForeColor="Red"
                Display="Dynamic"
                ValidationGroup="formularioCargo" />
            <asp:Label ID="lblErroDescricao" runat="server" />
            <br />

            <asp:Button ID="btnEdicao" runat="server"
                CssClass="btn btn-success"
                Text="Editar Cargo"
                ValidationGroup="formularioCargo"  
                OnClick="btnEdicao_Click" />
             <br />
             <br />
            <asp:Label ID="lblMensagem" runat="server" />
        </div>
    </div>

    
</asp:Content>
