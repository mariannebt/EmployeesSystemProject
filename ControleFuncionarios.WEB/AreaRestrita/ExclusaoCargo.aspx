<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="ExclusaoCargo.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.ExclusaoCargo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <h4>Exclusão do Cargo</h4>
    <a href="/AreaRestrita/ConsultaCargo.aspx">Voltar</a>
    <hr />

    <div class="row">
        <div class="col-md-6">
            <label>Código do Cargo</label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ReadOnly="true"/>
            <br />

            <label>Nome do Cargo</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" ReadOnly="true"/>
            <br />

            <label>Descrição do Cargo</label>
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" ReadOnly="true"/>
            <br />

            <asp:Button ID="btnExcluir" runat="server"
                CssClass="btn btn-danger" Text="Excluir Cargo"
                OnClick="btnExcluir_Click" />

            <br />
            <br />
            <asp:Label ID="lblMensagem" runat="server" />


        </div>

    </div>


</asp:Content>
