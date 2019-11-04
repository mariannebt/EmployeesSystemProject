<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="ConsultaCargo.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.ConsultaCargo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <h4>Consulta de Cargos</h4>
    <hr />
    <br />

    <div class="row">
        <div class="col-md-6">
            <label>Selecione o cargo desejado:</label>
            <asp:DropDownList ID="ddlCargo" runat="server" CssClass="form-control" 
                OnSelectedIndexChanged="ddlCargo_SelectedIndexChanged"
                AutoPostBack="true" />
            
        </div>
    </div>
    <br />

    <asp:Label ID="lblMensagem" runat="server" />
    <br />

    <asp:GridView ID="gridCargos" runat="server"
        GridLines="None" CssClass="table table-hover"
        AutoGenerateColumns="false">

        <EmptyDataTemplate>
             Nenhum cargo foi encontrado.
        </EmptyDataTemplate>

         

        <Columns>
             <asp:TemplateField HeaderText="Código">
                <ItemTemplate>
                    <%# Eval("IdCargo")%>
                </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Nome do Cargo">
                <ItemTemplate>
                    <%# Eval("Nome")%>
                </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Descrição">
               <ItemTemplate>
                   <%# Eval("Descricao")%>
               </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Edição/Exclusão">
               <ItemTemplate>
                  <a href='/AreaRestrita/EdicaoCargo.aspx?id=<%# Eval("IdCargo") %>' class="btn btn-primary btn-sm">  Editar </a>
                   
                  <a href='/AreaRestrita/ExclusaoCargo.aspx?id=<%# Eval("IdCargo") %>' class="btn btn-danger btn-sm"> Excluir </a>
               </ItemTemplate>
             </asp:TemplateField>

       </Columns>
    </asp:GridView>

</asp:Content>
