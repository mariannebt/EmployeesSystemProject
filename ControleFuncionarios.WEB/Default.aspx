<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ControleFuncionarios.WEB.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ASControl</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.min.css" rel="stylesheet" />

    <script src="Scripts/jquery-1.9.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

</head>
<body class="container">
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            <div class="row">
            <div class="col-md-4 col-md-offset-4">

                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4>Autenticação de Colaborador</h4>                        
                    </div>
                    <div class="panel-body">
                        Para acessar o sistema, informe seus dados abaixo:
                        <hr />

                        <label>Login:</label>
                        <asp:TextBox ID="txtLogin" runat="server"
                            CssClass="form-control" />
                        <asp:Label ID="lblErroLogin" runat="server" />
                        <asp:RequiredFieldValidator ID="requiredLogin" runat="server" 
                                        ControlToValidate="txtLogin"
                                        ErrorMessage="Por favor, informe seu login"
                                        ForeColor="Red"
                                        Display="Dynamic" 
                                        ValidationGroup="formularioAcesso" />
                             
                        <br />

                        <label>Senha:</label>
                        <asp:TextBox ID="txtSenha" runat="server"
                            CssClass="form-control" TextMode="Password" />
                        <asp:Label ID="lblErroSenhaAc" runat="server" />
                         <asp:RequiredFieldValidator ID="requiredSenha" runat="server" 
                                        ControlToValidate="txtLogin"
                                        ErrorMessage="Por favor, informe sua senha"
                                        ForeColor="Red"
                                        Display="Dynamic" 
                                        ValidationGroup="formularioAcesso" />

                    </div>
                    <div class="panel-footer">
                        <asp:Button ID="btnAcesso" runat="server"
                            Text="Acessar" CssClass="btn btn-primary" 
                            OnClick="btnAcesso_Click" 
                            ValidationGroup="formularioAcesso" />
                        <br />
                        <br />
                         <asp:Label ID="lblMensagemAcessar" runat="server" />

                        <hr />

                        Não possui acesso? Solicite 
                        <a href="#" data-target="#janela1" data-toggle="modal">
                          aqui
                        </a>

                        <br />

                         Esqueceu a senha? Altere 
                        <a href="#" data-target="#janela2" data-toggle="modal">
                          aqui 
                        </a>

                    </div>
                </div>
            </div>
            </div>

            <div id="janela1" class="modal fade" >
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header bg-primary">
                        <h3>Requisição de Criação de Conta Colaborador</h3>
                    </div>
                    <div class="modal-body">

                        <div class="row">
                            <div class="col-md-12">
                                <label>Nome do Colaborador:</label>
                                <asp:TextBox ID="txtNome" runat="server"
                                    CssClass="form-control" />
                                <asp:Label ID="lblErroNome" runat="server" />
                                <asp:RequiredFieldValidator ID="requiredNome" runat="server" 
                                        ControlToValidate="txtNome"
                                        ErrorMessage="Por favor, informe o nome do colaborador"
                                        ForeColor="Red"
                                        Display="Dynamic" 
                                        ValidationGroup="formularioCadastro" />
                                <asp:RegularExpressionValidator ID="regexNome" runat="server"
                                    ControlToValidate="txtNome"
                                    ErrorMessage="Apenas letras, de 6 a 50 caracteres"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ValidationGroup="formularioCadastro" 
                                    ValidationExpression="^[A-Za-zÀ-Üà-ü\s]{6,50}$" />
                            </div>
                        </div>

                        <br />
                       
                        <div class="row">
                            <div class="col-md-12">
                                <label>Informe seu e-mail:</label>
                                <asp:TextBox ID="TxtEmail" runat="server"
                                    CssClass="form-control" />
                                <asp:Label ID="lblErroEmail" runat="server" />
                                <asp:RequiredFieldValidator ID="requiredEmailAcesso" runat="server"
                                    ControlToValidate="TxtEmail"
                                    ErrorMessage="Por favor, informe o e-mail do colaborador"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ValidationGroup="formularioCadastro" />
                     
                                   
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-3">
                                <label>Data Admissão:</label>
                                <asp:TextBox ID="txtAdmissao" runat="server"
                                    CssClass="form-control" />
                                <asp:Label ID="lblErroData" runat="server" type="date" />
                                <asp:RequiredFieldValidator ID="requiredDataAdmissao" runat="server"
                                    ControlToValidate="txtAdmissao"
                                    ErrorMessage="Por favor, informe a data de admissão do colaborador"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ValidationGroup="formularioCadastro" />
                            </div>

                             <div class="col-md-3">
                                <label>Perfil:</label>
                                 <asp:DropDownList ID="ddlPerfil" runat="server" CssClass="form-control"/>
                                <asp:Label ID="lblErroPerfil" runat="server" />
                                    
                            </div>

                            <div class="col-md-6">
                                <label>Cargo:</label>
                                <asp:DropDownList ID="ddlCargo" runat="server" CssClass="form-control"/>
                                <asp:Label ID="lblErroCargo" runat="server" />
                                
                            </div>
                        </div>
                                               
                        <br />

                        <div class="row">
                            <div class="col-md-6">
                                <label>Senha:</label>
                                <asp:TextBox ID="txtSenhaAcesso" runat="server"
                                   CssClass="form-control" TextMode="Password" />
                                <asp:Label ID="lblErroSenha" runat="server" />
                                <asp:RequiredFieldValidator ID="requiredSenhaAcesso" runat="server"
                                    ControlToValidate="txtSenhaAcesso"
                                    ErrorMessage="Por favor, informe a senha do colaborador"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ValidationGroup="formularioCadastro" />
                                 <asp:RegularExpressionValidator ID="regexSenhaAcesso" runat="server"
                                    ControlToValidate="txtSenhaAcesso"
                                    ErrorMessage="Senha inválida. Sua senha deve ter de 5 a 10 caracteres e deve conter ao menos um número, uma letra e
                                     não pode conter caracter especial."
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ValidationGroup="formularioCadastro" 
                                    ValidationExpression="(?!^[0-9]*$)(?!^[a-zA-Z]*$)^([a-zA-Z0-9]{5,10})$" />

                            </div>
                            <div class="col-md-6">
                                <label>Confirmar Senha:</label>
                                <asp:TextBox ID="txtSenhaConfirm" runat="server"
                                   CssClass="form-control" TextMode="Password" />
                                <asp:Label ID="lblErroConfirma" runat="server" />
                                <asp:RequiredFieldValidator ID="requiredSenhaConfirma" runat="server"
                                    ControlToValidate="txtSenhaConfirm"
                                    ErrorMessage="Por favor, confirme a senha do colaborador"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ValidationGroup="formularioCadastro" />
                                <asp:CompareValidator ID="compareSenha" runat="server"
                                    ControlToValidate="txtSenhaConfirm"
                                    ControlToCompare="txtSenhaAcesso"
                                    ErrorMessage="Senhas não conferem"
                                    ForeColor="Red"
                                    Display="Dynamic"
                                    ValidationGroup="formularioCadastro" />
                            </div>
                        </div>

                        <br />
  
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnCadastro" runat="server"
                            Text="Criar Conta" 
                            CssClass="btn btn-success" 
                            OnClick="btnCadastro_Click1" 
                            ValidationGroup="formularioCadastro" />

                         
                    </div>
                    
                </div>
                <asp:Label ID="lblMensagemCriar" runat="server" />
            </div>
                
        </div>   
            
    </div>

        <div id="janela2" class="modal fade">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header bg-primary">
                        <h3>Alterar Senha de Colaborador</h3>
                    </div>
                    <div class="modal-body">
                       
                        <div class="row">
                            <div class="col-md-12">
                                <label>Login:</label>
                                <asp:TextBox ID="txtLoginSemSenha" runat="server"
                                    CssClass="form-control" />
                            </div>
                        </div>
                        <br />

                        <div class="row">
                            <div class="col-md-12">
                                <label>Informe E-mail:</label>
                                <asp:TextBox ID="txtEmailSemSenha" runat="server"
                                    CssClass="form-control" />
                            </div>
                        </div>
                        <br />                    
 
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnAlterarSenha" runat="server"
                            Text="Solicitar Nova Senha" 
                            CssClass="btn btn-success" />
                         <asp:Label ID="lblMensagemSenha" runat="server" />
                    </div>

                </div>
            </div>
           
    

        </div>
    </form>
</body>
</html>
