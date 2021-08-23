using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ViewModel;

namespace WebForms.Views.Layout
{
    public partial class SiteMaterialize : System.Web.UI.MasterPage
    {
        #region "Properties
        protected PersonaViewModel vmPersona { get; set; }
        #endregion
        public SiteMaterialize()
        {
            this.vmPersona = new PersonaViewModel();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_personaSession"] == null) 
            {
                footerMaster.Visible = false;
                navigation.Visible = false;
                closeBtn.Visible = false;
                slideout.Visible = false;
            }
            else
            {
                body.Attributes.Add("class", "backgroundBodyIn");
                var PersonaActiva = Session["_personaSession"].ToString();
                var personaIniciada = this.vmPersona.obtenerPersona( Guid.Parse(PersonaActiva));
                txtNombreUsuarioIniciado.Text = personaIniciada.Nombre + " " + personaIniciada.ApellidoPaterno + " " + personaIniciada.ApellidoMaterno;
                int rango = int.Parse(Session["_Rango"].ToString());
                if (rango > 1)
                {
                    divideAdm.Visible = false;
                    adminSep.Visible = false;
                    aspirantesBtn.Visible = false;
                }
                else
                {
                    divideAdm.Visible = true;
                    adminSep.Visible = true;
                    aspirantesBtn.Visible = true;
                }
            }
        }

        protected void closeBtn_Click(object sender, EventArgs e)
        {
            Session["_personaSession"] = null;
            Response.Redirect("Login.aspx");
        }

        protected void aspirantesBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Aspirantes.aspx");
        }
    }
}