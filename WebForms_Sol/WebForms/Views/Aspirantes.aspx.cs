using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace WebForms.Views
{
    public partial class Aspirantes : System.Web.UI.Page
    {
        #region Properties
        protected UserViewModel vmUser { get; set; }
        #endregion
        public Aspirantes()
        {
            this.vmUser = new UserViewModel();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
            if (Session["_personaSession"] == null) { Response.Redirect("Login.aspx"); }
            else
            {
                int rango = int.Parse(Session["_Rango"].ToString());
                if (rango > 1)
                {
                    Response.Redirect("Error.aspx");
                }
                else {
                    cargarDatos();
                }
            }
        }
        public void cargarDatos()
        {
            var aspirantes = this.vmUser.ObtenerAspirantes();
            gvUsers.DataSource = aspirantes;
            gvUsers.DataBind();
        }

        protected void btnEditAsp_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "showClientModalAsp();", true);
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvUsers.SelectedRow;
            Guid GUIDUsuarioSelected = Guid.Parse(gvUsers.DataKeys[row.RowIndex].Values["UIDUsuario"].ToString());
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "MyScript", "showClientModalAsp();", true);
        }
    }
}