<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="ConsultaPerfil.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.ConsultaPerfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <h4>Consulta de Perfil</h4>
    <hr />
    <br />

    <div class="row">
        <div class="col-md-10">
            <asp:Label ID="lblMensagem" runat="server" />
             <br />

             <asp:GridView ID="gridPerfis" runat="server"
                    GridLines="None" CssClass="table table-hover"
                    AutoGenerateColumns="false">

                <Columns>
                <asp:TemplateField HeaderText="Código">
                    <ItemTemplate>
                        <%# Eval("IdPerfil")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nome">
                    <ItemTemplate>
                        <%# Eval("Nome")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Edição/Exclusão">
                    <ItemTemplate>
                        <a href='/AreaRestrita/EdicaoPerfil.aspx?id=<%# Eval("IdPerfil") %>' class="btn btn-primary btn-sm">Editar </a>

                        <a href='/AreaRestrita/ExclusaoPerfil.aspx?id=<%# Eval("IdPerfil") %>' class="btn btn-danger btn-sm">Excluir </a>
                    </ItemTemplate>
                </asp:TemplateField>

                </Columns>
            </asp:GridView>
       </div>
     </div>

</asp:Content>
