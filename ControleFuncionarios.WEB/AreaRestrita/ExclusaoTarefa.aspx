<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="ExclusaoTarefa.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.ExclusaoTarefa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">
        <h4>Exclusão de Tarefa</h4>
    <a href="/AreaRestrita/ConsultaTarefa.aspx">Voltar</a>
    <hr />

    <div class="row">
        <div class="col-md-6">
            <label>Código da Tarefa</label>
            <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control" ReadOnly="true" />
            <br />

            <label>Nome da Tarefa</label>
            <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" ReadOnly="true" />
            <br />

            <label>Descrição da Tarefa</label>
            <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" ReadOnly="true" />
            <br />

           <asp:Button ID="btnExcluir" runat="server" 
               Text="Excluir" CssClass="btn btn-danger"  OnClick="btnExcluir_Click"/>

            <br />
            <br />
            <asp:Label ID="lblMensagem" runat="server" />


        </div>

    </div>


</asp:Content>
