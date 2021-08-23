using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace WebForms.Views
{
    public partial class Usuarios : System.Web.UI.Page
    {
        #region "Properties
        protected UserViewModel VmUser { get; set; }
        protected PersonaViewModel vmPersona { get; set; }
        #endregion
        public Usuarios() 
        {
            this.VmUser = new UserViewModel();
            this.vmPersona = new PersonaViewModel();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
        }
        #region Login
        protected void LogButton_Click(object sender, EventArgs e)
        {
            var acceso = "";
            var emailData = txtEmail.Text.Trim();
            var passwordData = txtPassword.Text.Trim();
            if (emailData.Trim() == "" || passwordData.Trim() == "")
            {
                acceso = "Faltan datos";
                MostrarToast(acceso);

            }
            else
            {
                var obtenidos = this.VmUser.ObtenerUsuarioByAccess(emailData, passwordData);
                if (obtenidos.Count() != 1)
                {
                    acceso = "acceso denegado";
                    MostrarToast(acceso);
                }
                else
                {
                    var UIDPersona = obtenidos.Single().UIDPersonaRef;
                    var UIDUsuario = obtenidos.Single().UIDUsuario;
                    var rango = this.VmUser.ObtenerRangoDeUsuario(UIDUsuario);
                    Session["_Rango"] = rango.Single().Rango;
                    Session["_personaSession"] = UIDPersona;
                    Response.Redirect("Home.aspx");
                }
            }
        }
        protected void closeBtnNot_Click(object sender, EventArgs e)
        {
            modalNotification.Text = "";
            rowNotification.Visible = false;
        }

        protected void BtnLoginOp_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "showClientModalLog();", true);
        }
        #endregion

        #region Registro
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "showClientModal();", true);
        }
        protected void btnUserFormSave_Click(object sender, EventArgs e)
        {
            if (filtrarDatos())
            {
                var acceso = "";
                var firstName = txtFirstNameReg.Text.Trim();
                var lastName = txtLastNameReg.Text.Trim();
                var secondLastName = txtSencondLastNameReg.Text.Trim();
                var phone = txtPhoneNumbreReg.Text.Trim();
                var email = txtEmailReg.Text.Trim();
                bool sexo = bool.Parse(slcSexo.Value);
                var passwword = txtPasswordReg.Text.Trim();
                if (existe())
                {
                    modalNotification.Text = "El email ya tiene un usuario registrado";
                    rowNotification.Visible = true;
                }
                else
                {
                    var agregado = this.VmUser.Agregar(firstName, lastName, secondLastName, phone, sexo, email, passwword);
                    if (agregado) {
                        acceso = "El usuario se agrego correctamente";
                        MostrarToast(acceso);
                    }
                    else
                    { 
                        acceso = "El usuario no se pudo agregar";
                        MostrarToast(acceso);
                    }
                    LimpiarCamposRegistro();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "hideClientModal();", true);
                }
            }
            else
            {

            }
        }
        protected void btnCancelarRegistro_Click(object sender, EventArgs e)
        {
            LimpiarCamposRegistro();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "hideClientModal();", true);
        }
        #endregion

        #region Herramientas
        protected bool existe() 
        {
            var email = txtEmailReg.Text.Trim();
            var obtenidos = this.VmUser.VerificarExiste(email);
            if (obtenidos.Count() != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        protected void LimpiarCamposRegistro()
        {
            txtFirstNameReg.Text = ("");
            txtLastNameReg.Text = ("");
            txtSencondLastNameReg.Text = ("");
            txtPhoneNumbreReg.Text = ("");
            txtEmailReg.Text = ("");
            slcSexo.Value = ("");
            txtPasswordReg.Text = ("");
        }
        protected void LimpiarCamposLogin() 
        {
            txtEmail.Text = ("");
            txtPassword.Text = ("");
        }
        protected void MostrarToast( string acceso)
        {
            string javaScript = "M.toast({ html: '" + acceso + "', classes: 'rounded'});";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", javaScript, true);
        }
        protected bool filtrarDatos()
        {
            var concatenado = "";
            var filtrado = "";
            var firstName = txtFirstNameReg.Text.Trim();
            if (firstName=="")
            {
                txtFirstNameReg.CssClass = "invalid";
                concatenado = "1";
            }
            var lastName = txtLastNameReg.Text.Trim();
            if (lastName=="")
            {
                txtLastNameReg.CssClass = "invalid";
                concatenado = "1";
            }
            var secondLastName = txtSencondLastNameReg.Text.Trim();
            if (secondLastName=="")
            {
                txtSencondLastNameReg.CssClass = "invalid";
                concatenado = "1";
            }
            var phone = txtPhoneNumbreReg.Text.Trim();
            if (phone == "" || phone.Length > 10)
            {
                txtPhoneNumbreReg.CssClass = "invalid";
                concatenado = "1";
            }
            var email = txtEmailReg.Text.Trim();
            if (email == "")
            {
                txtEmailReg.CssClass = "invalid";
                concatenado = "1";
            }
            var sexo = slcSexo.Value;
            if (sexo == "")
            {
                concatenado = "1";
            }
            var passwword = txtPasswordReg.Text.Trim();
            if (passwword == "")
            {
                txtPasswordReg.CssClass = "invalid";
                concatenado = "1";
            }
            if (concatenado == "") 
            {
                return true;
            }
            else
            {
                filtrado = "Los campos no se llenaron correctamente";
                modalNotification.Text = filtrado;
                rowNotification.Visible = true;
                return false;
            }
        }
        #endregion

        protected void recordarBtn_Click(object sender, EventArgs e)
        {

        }
    }
}