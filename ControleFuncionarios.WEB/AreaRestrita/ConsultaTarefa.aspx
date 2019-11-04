<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="ConsultaTarefa.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.ConsultaTarefa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">

 <h4>Consulta de Tarefas</h4>
 <hr />
 <br />

   <div class="row">
        <div class="col-md-6">
            <label>Filtrar tarefa:</label>
           
             <asp:DropDownList ID="ddlTarefa" runat="server" CssClass="form-control" 
                OnSelectedIndexChanged="ddlTarefa_SelectedIndexChanged"
                AutoPostBack="true" />
        </div>
    </div>
    <br />

    <asp:Label ID="lblMensagem" runat="server" />
    <br />

    <asp:GridView ID="gridTarefas" runat="server"
        GridLines="None" CssClass="table table-hover"
        AutoGenerateColumns="false">

        <EmptyDataTemplate>
             Nenhum cargo foi encontrado.
        </EmptyDataTemplate>

         

        <Columns>
             <asp:TemplateField HeaderText="Código">
                <ItemTemplate>
                    <%# Eval("IdTarefa")%>
                </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Nome">
                <ItemTemplate>
                    <%# Eval("Nome")%>
                </ItemTemplate>
             </asp:TemplateField>
            
             <asp:TemplateField HeaderText="Data Recebimento">
               <ItemTemplate>
                   <%# Eval("DataEntrega" , "{0:dd/MM/yyyy}")%>
               </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Data Finalicação">
               <ItemTemplate>
                   <%# Eval("DataSolicitacao", "{0:dd/MM/yyyy}")%>
               </ItemTemplate>
             </asp:TemplateField>

            <asp:TemplateField HeaderText="Status">
               <ItemTemplate>
                   <%# Eval("Status")%>
               </ItemTemplate>
             </asp:TemplateField>

             <asp:TemplateField HeaderText="Edição/Exclusão">
               <ItemTemplate>
                  <a href='/AreaRestrita/EdicaoTarefa.aspx?id=<%# Eval("IdTarefa") %>' class="btn btn-primary btn-sm">  Editar </a>
                   
                  <a href='/AreaRestrita/ExclusaoTarefa.aspx?id=<%# Eval("IdTarefa") %>' class="btn btn-danger btn-sm"> Excluir </a>
               </ItemTemplate>
             </asp:TemplateField>

       </Columns>
    </asp:GridView>



</asp:Content>
