<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="CadastroPerfil.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.CadastroPerfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">

    <h4>Cadastro de Perfil</h4>
    <hr />

    <div class="row">
        <div class="col-md-6">
            <label>Informe o nome do perfil:</label>
            <asp:TextBox ID="txtNomePerfil" runat="server" CssClass="form-control" />
            <asp:RequiredFieldValidator ID="requiredPerfil" runat="server"
                ControlToValidate="txtNomePerfil"
                ErrorMessage="Por favor, informe o nome do Perfil"
                ForeColor="Red"
                Display="Dynamic"
                ValidationGroup="formularioPerfil"
            />
            <asp:Label ID="lblErroNomePerfil" runat="server" />
            <br />
            <br />

            <asp:Button ID="btnCadastroPerfil" runat="server"
                Text="Cadastrar Perfil"
                CssClass ="btn btn-success"
                ValidationGroup="formularioPerfil"
                OnClick="btnCadastroPerfil_Click" />
            <br />
            <br />
            <asp:Label ID="lblMensagem" runat="server" />

        </div>
    </div>


</asp:Content>
