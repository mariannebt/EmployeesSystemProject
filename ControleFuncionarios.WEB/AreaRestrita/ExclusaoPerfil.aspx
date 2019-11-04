<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="ExclusaoPerfil.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.ExclusaoPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">

    <h4>Exclusão de Perfil</h4>
    <a href="/AreaRestrita/ConsultaPerfil.aspx">Voltar</a>
    <hr />

    <div class="row">
        <div class="col-md-6">
            <label>Código do Perfil:</label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ReadOnly="true"/>
            <br />

            <label>Nome do Perfil:</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" ReadOnly="true"/>
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
