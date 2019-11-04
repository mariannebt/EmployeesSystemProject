<%@ Page Title="" Language="C#" MasterPageFile="~/AreaRestrita/Templates/Layout.Master" AutoEventWireup="true" CodeBehind="EdicaoTarefa.aspx.cs" Inherits="ControleFuncionarios.WEB.AreaRestrita.EdicaoTarefa" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPrincipal" runat="server">

    <h4>Edição de Tarefa</h4>
    <a href="/AreaRestrita/ConsultaTarefa.aspx">Voltar</a>
    <hr />
    <br />

    <div class="row">
        <div class="col-md-12">
             


           

                <div class="col-md-4">
                <label>Código da Tarefa:</label>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control"  ReadOnly="true"/>
                              
               <br />   
             </div>
            <div class="col-md-8">
                <label>Nome da Tarefa:</label>
                <asp:TextBox ID="txtNome" runat="server" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="requiredNome" runat="server" 
                   ControlToValidate="txtNome"
                   ErrorMessage="Por favor, informe o nome da tarefa"
                   ForeColor="Red"
                   Display="Dynamic"
                   ValidationGroup="formularioCadastro" />
               <asp:Label ID="lblErroNome" runat="server" />
               <br />   
             </div>
           
            

                    
         
            <div class="row">
                <div class="col-md-12">
                    <div class="col-md-6">
                        <br />
                        <label>Data Recebimento:</label>
                        <asp:TextBox ID="txtDataRecebimento" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="requiredDataRec" runat="server" 
                        ControlToValidate="txtDataRecebimento"
                        ErrorMessage="Por favor, informe a data de recebimento da tarefa"
                        ForeColor="Red"
                        Display="Dynamic"
                        ValidationGroup="formularioCadastro" />
                        <asp:Label ID="lblErroDataRec" runat="server" />
                    </div>
                    <div class="col-md-6">
                        <br />
                        <label>Data para Finalização:</label>
                        <asp:TextBox ID="txtDataFim" runat="server" CssClass="form-control" />
                        <asp:RequiredFieldValidator ID="requiredDataFim" runat="server" 
                        ControlToValidate="txtDataFim"
                        ErrorMessage="Por favor, informe a data de finalização da tarefa"
                        ForeColor="Red"
                        Display="Dynamic"
                        ValidationGroup="formularioCadastro" />
                        <asp:Label ID="lblErroDataFim" runat="server" />
                    </div>    
                   
                </div>

           </div>
            <br />

           
                    <div class="col-md-12">
                      <br />          
                        <label>Descrição da Tarefa:</label>
                        <asp:TextBox ID="txtDescricao" runat="server" CssClass="form-control" TextMode="MultiLine" />
                        <asp:RequiredFieldValidator ID="requiredDescricao" runat="server" 
                        ControlToValidate="txtDescricao"
                        ErrorMessage="Por favor, informe a descrição da tarefa"
                        ForeColor="Red"
                        Display="Dynamic"
                        ValidationGroup="formularioCadastro" />
                        <asp:Label ID="lblErroDescr" runat="server" />
                         <br />
                        <br />
                    </div>
                    <div class="col-md-12">
                        <div class="col-md-4">
                             <label>Status da Tarefa:</label>
                        </div>
                        <div class="col-md-4">
                             <asp:CheckBox ID="chkStatus1" runat="server" CssClass="form-control" Text="Pendente"/>                          
                        </div>
                        <div class="col-md-4">
                             <asp:CheckBox ID="chkStatus2" runat="server" CssClass="form-control" Text="Concluída"/>
                            <br />
                        </div>
                        <asp:Label ID="lblErroStatus" runat="server" />
                    <br />
                    <br />    
                   </div>
      
        <div>
            <br />
            <br />
                <asp:Button ID="btnEdicao" runat="server" Text="Editar" CssClass="btn btn-success" 
                    OnCLick="btnEdicao_Click"
                    ValidationGroup="formularioCadastro" />
                <br />
                <br />
                <asp:Label ID="lblMensagem" runat="server" />

       
         </div>      
    </div>  
 </div>
 

</asp:Content>
