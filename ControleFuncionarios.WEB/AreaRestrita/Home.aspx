<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">
    <h4>Tarefas pendentes na semana</h4>
    <hr />
    <br />

    <asp:Label ID="lblMensagem" runat="server" />

    <asp:ListView ID="listTarefasSemana" runat="server" >
        <ItemTemplate>
            <div class="col-md-4">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <strong><a href="/AreaRestrita/ConsultaTarefa.aspx"><%# Eval("Nome")%></a></strong>
                        <br />

                    </div>
                    <div class="panel-body">
                        Data Finalização: <%# Eval("DataEntrega", "{0:dd/MM/yyyy}")%>
                        Status: <%# Eval("Status")%>
                        <br />

                    </div>
              </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

   

</asp:Content>
