<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Layout/SiteHead.Master" AutoEventWireup="true" CodeBehind="Aspirantes.aspx.cs" Inherits="WebForms.Views.Aspirantes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="phStyles" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phBody" runat="server">
    <div class="row justify-content-center">
        <div class="col s12">
            <asp:GridView CssClass="responsive-table highlight" runat="server" ID="gvUsers" 
                AutoGenerateColumns="false" DataKeyNames="UIDUsuario" OnRowCommand="gvUsers_RowCommand" OnSelectedIndexChanged="gvUsers_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Usuario" DataField="Email" />
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Apellido paterno" DataField="apellidoPaterno" />
                    <asp:BoundField HeaderText="Apellido materno" DataField="apellidoMaterno" />
                    <asp:BoundField HeaderText="Status" DataField="Status"/>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton CommandName="Select" CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" runat="server" ID="btnEditAsp" OnClick="btnEditAsp_Click">
                                <i class="material-icons">edit</i>
                            </asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <asp:LinkButton Text="prueba" ID="btnprueba" OnClick="Unnamed_Click" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="sModal" runat="server">
    <div id="mdlAspiranteObservable" class="modal">
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
                                <asp:TextBox runat="server" ID="txtNameSelected"></asp:TextBox>
                            </div>
                            <div class="input-field col s4">
                                <label class="active">Apellido Paterno</label>
                                <asp:TextBox runat="server" ID="txtLastSelected"></asp:TextBox>
                            </div>
                            <div class="input-field col s4">
                                <label class="active">Apellido Materno</label>
                                <asp:TextBox runat="server" ID="txtSecondSelected"></asp:TextBox>
                            </div>
                            <div class="input-field col s4">
                                <label class="active">Numero de telefono</label>
                                <asp:TextBox runat="server" MaxLength="10" type="number" ID="txtPhoneSelected"></asp:TextBox>
                            </div>
                            <div class="input-field col s4">
                                <select id="txtSexoSelected" runat="server" class="browser-default">
                                    <option value="" disabled selected>Sexo</option>
                                    <option value="false">Femenino</option>
                                    <option value="true">Masculino</option>
                                </select>
                            </div>
                        </div>
                        <div class="row">
                            <div class="input-field col s8">
                                <label class="active">Email</label>
                                <asp:TextBox runat="server" ID="txtEmailSelected" CssClass="validate" type="email"></asp:TextBox>
                            </div>
                            <div class="input-field col s4">
                                <label class="active">Password</label>
                                <asp:TextBox runat="server" ID="txtPasswordSelected" CssClass="validate" type="password" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--CONTENT--%>
            </ContentTemplate>
        </asp:UpdatePanel>
        <%--UPDATE PANEL--%>
    </div>
</asp:Content>
<asp:Content runat="server" ID="Content4" ContentPlaceHolderID="phScripts">
    <script>
        function showClientModalAsp() {
            $('#mdlUserForm').modal('open');
        }
        function hideClientModalAsp() {
            $('#mdlUserForm').modal('close');
        }
    </script>
</asp:Content>
