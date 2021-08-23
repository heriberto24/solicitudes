using Data;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PersonaViewModel
    {
        protected PersonaRepository PersonaDb { get; set; }
        public PersonaViewModel()
        {
            this.PersonaDb = new PersonaRepository();
        }
        public bool Agregar(string nombre, string apellidoP,String apellidoM, String phone, bool sexo)
        {
            var id = this.PersonaDb.Insert(new Persona() { Nombre=nombre,ApellidoPaterno=apellidoP,ApellidoMaterno=apellidoM,NumeroTelefono=phone,Sexo=sexo});

            if (id == null)
                return true;
            else
                return false;
        }
        public Persona obtenerPersona(Guid UIDPersona) 
        {
            return this.PersonaDb.Get<Persona>(UIDPersona);
        }
    }
}
