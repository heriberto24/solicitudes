using Dapper;
using Data;
using Model.Entities;
using Model.Models;
using Model.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserViewModel
    {
        protected UserRepository UserDb { get; }
        protected PersonaRepository PersonaDb { get; set; }
        protected TipoDeUsuarioRepository TipoUsuarioDb { get; set; }
        public UserViewModel()
        {
            this.UserDb = new UserRepository();
            this.PersonaDb = new PersonaRepository();
            this.TipoUsuarioDb = new TipoDeUsuarioRepository();
        }
        public bool Agregar(string nombre, string apellidoP, String apellidoM, String phone, bool sexo, string email, string password)
        {
            bool status = false;
            Guid UIDTipoPersona = Guid.Parse("AF48623B-386E-4F88-8207-6DD3B5CB686E");
            Guid UIDTipoUsuarioRef = Guid.Parse("5E5AD52B-0E5A-4E2A-BFF3-5CB70ED57713");
            var personaid = this.PersonaDb.Insert(new Persona() { 
                Nombre = nombre, 
                ApellidoPaterno = apellidoP, 
                ApellidoMaterno = apellidoM, 
                NumeroTelefono = phone, 
                Sexo = sexo, 
                UIDTipoPersonaRef=UIDTipoPersona
            });
            Guid UIDPersona = Guid.Parse(personaid.ToString());
            var id = this.UserDb.Insert(new User() {
                Email = email,
                Password = password,
                UIDPersonaRef = UIDPersona,
                UIDTipoUsuarioRef = UIDTipoUsuarioRef,
                Status = status
            });

            if (id == null)
                return false;
            else
            {
                return true;
            }
        }
        public User ObtenerUsuario(Guid uid)
        {
            return this.UserDb.Get<User>(uid);
        }
        public IEnumerable<UsersGrid> ObtenerUsuarioByAccess(string email, string password)
        {
            string query = $@"
            select * from Usuarios 
            where Email = @usuario and Password = @password;";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@usuario", email);
            parameters.Add("@password", password);
            return this.UserDb.Query<UsersGrid>(query, parameters);
        }
        public IEnumerable<RangoGrid> ObtenerRangoDeUsuario(Guid UIDUsuario) 
        {
            string query = $@"
            select T.Rango from Usuarios as U,TiposUsuarios as T 
            where U.UIDTipoUsuarioRef = T.UIDTipoUsuario and UIDUsuario = @UIDUsuario;";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@UIDUsuario", UIDUsuario);
            return this.TipoUsuarioDb.Query<RangoGrid>(query, parameters);
        }
        public IEnumerable<UsersGrid> VerificarExiste(string email)
        {
            string query = $@"
            select * from Usuarios 
            where Email = @usuario;";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@usuario", email);
            return this.UserDb.Query<UsersGrid>(query, parameters);
        }
        public IEnumerable<AspirantesGrid> ObtenerAspirantes()
        {
            string query = $@"
            select U.UIDUsuario,U.Status,U.Email,P.Nombre,P.ApellidoPaterno,P.ApellidoMaterno 
            from Usuarios as U, Personas as P 
            where U.UIDPersonaRef=P.UIDPersona and U.UIDTipoUsuarioRef='5E5AD52B-0E5A-4E2A-BFF3-5CB70ED57713';";

            DynamicParameters parameters = new DynamicParameters();
            return this.UserDb.Query<AspirantesGrid>(query, parameters);
        }
    }
}