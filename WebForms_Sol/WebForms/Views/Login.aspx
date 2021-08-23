<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout/SiteHead.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebForms.Views.Usuarios" %>

<asp:Content ID="Content2" ContentPlaceHolderID="phBody" runat="server">
    <asp:UpdatePanel runat="server" ID="upBody">
        <ContentTemplate>
            <div class="container loginCard">
                <div class="d-flex justify-content-center h-100">
                    <div class="card-header">
                        <h3>Sign In</h3>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="input-field col s12">
                                <label class="active">Email</label>
                                <asp:TextBox runat="server" ID="txtEmail" CssClass="validate white-text" type="email" />
                            </div>
                            <div class="input-field col s12">
                                <label class="active">Password</label>
                                <asp:TextBox runat="server" ID="txtPassword" CssClass="validate white-text" type="password" />
                            </div>
                            <div class=" col s12">
                                <div class=" sticky-action center">
                                    <asp:LinkButton Text="Enviar" runat="server" ID="btnLoginModal" OnClick="LogButton_Click"
                                        CssClass="btn waves-effect waves-green #1b5e20 green darken-4">
                                                    Ingresar <i class="material-icons right">login</i>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <div class="justify-content-center links">
                            ¿No tienes una cuenta?
                                <asp:LinkButton ID="btnRegistro" OnClick="btnRegistro_Click" Text="Acceder"
                                    runat="server">Registrate</asp:LinkButton>
                        </div>
                        <div class="d-flex justify-content-center">
                            <asp:LinkButton ID="recordarBtn" OnClick="recordarBtn_Click" Text="Acceder" class=""
                                runat="server">¿Olvidaste tu contraseña?</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sModal" runat="server">
    <%--MODAL--%>
    <div id="mdlUserForm" class="modal">
        <%--UPDATE PANEL--%>
        <asp:UpdatePanel runat="server" ID="upUserForm">
            <ContentTemplate>
                <%--CONTENT--%>
                <div class="modal-content">
                    <h4>Formulario de registro</h4>
                    <div class="row">
                        <div class="row">
                            <div class="input-field col s4">
                                <label class="active">Nombre(s)</label>
                                <asp:TextBox runat="server" ID="txtFirstNameReg"></asp:TextBox>
                            </div>
                            <div class="input-field col s4">
                                <label class="active">Apellido Paterno</label>
                                <asp:TextBox runat="server" ID="txtLastNameReg"></asp:TextBox>
                            </div>
                            <div class="input-field col s4">
                                <label class="active">Apellido Materno</label>
                                <asp:TextBox runat="server" ID="txtSencondLastNameReg"></asp:TextBox>
                            </div>
                            <div class="input-field col s4">
                                <label class="active">Numero de telefono</label>
                                <asp:TextBox runat="server" MaxLength="10" type="number" ID="txtPhoneNumbreReg"></asp:TextBox>
                            </div>
                            <div class="input-field col s4">
                                <select id="slcSexo" runat="server" class="browser-default">
                                    <option value="" disabled selected>Sexo</option>
                                    <option value="false">Femenino</option>
                                    <option value="true">Masculino</option>
                                </select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s8">
                                <label class="active">Email</label>
                                <asp:TextBox runat="server" ID="txtEmailReg" CssClass="validate" type="email"></asp:TextBox>
                            </div>
                            <div class="input-field col s4">
                                <label class="active">Password</label>
                                <asp:TextBox runat="server" ID="txtPasswordReg" CssClass="validate" type="password" />
                            </div>
                            <div class="row" id="rowNotification" visible="false" runat="server">
                                <div class="row">
                                    <div class="input-field col s8">
                                        <asp:TextBox value="" Enabled="false" ID="modalNotification" type="text" class="validate" runat="server" />
                                        <label for="disabled"></label>
                                    </div>
                                    <div class="input-field col s4">
                                        <asp:LinkButton ID="closeBtnNot" CssClass="btn-block" OnClick="closeBtnNot_Click" runat="server">
                                            <span class="material-icons">close</span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <asp:LinkButton Text="Cancelar" runat="server" ID="btnCancelarRegistro" OnClick="btnCancelarRegistro_Click"
                        CssClass="btn waves-effect waves-light #b71c1c red darken-4">
                        Cancelar <i class="material-icons right">close</i>
                    </asp:LinkButton>
                    <asp:LinkButton Text="Guardar" runat="server" ID="btnUserFormSave" OnClick="btnUserFormSave_Click"
                        CssClass="btn waves-effect waves-green #1b5e20 green darken-4">
                        Guardar <i class="material-icons right">save</i>
                    </asp:LinkButton>
                </div>
                <%--CONTENT--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--UPDATE PANEL--%>
    </div>
    <%--MODAL--%>
</asp:Content>
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="phScripts">
    <script>
        function showClientModal() {
            $('#mdlUserForm').modal('open');
        }
        function hideClientModal() {
            $('#mdlUserForm').modal('close');
        }
    </script>
</asp:Content>
