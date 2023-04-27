using infraestructure.Models;
using infraestructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ClienteService
    {
        private ClienteRepository repositoryPersona;

        public ClienteService(string connectionString)
        {
            this.repositoryPersona = new ClienteRepository(connectionString);
        }

        public string insertarPersona(ClienteModel persona)
        {
            return validarDatosPersona(persona) ? repositoryPersona.insertarPersona(persona) : throw new Exception("Error en la validacion");   
        }

        public string modificarPersona(ClienteModel persona, int id)
        {
            if (repositoryPersona.consultarPersona(id) != null)
                return validarDatosPersona(persona) ?
                    repositoryPersona.modificarPersona(persona, id) :
                    throw new Exception("Error en la validacion");
            else
                return "No se encontraron los datos de esta persona";
        }

        public string eliminarPersona(int id)
        {
            return repositoryPersona.eliminarPersona(id);
        }

        public ClienteModel consultarPersona(int id)
        {
            return repositoryPersona.consultarPersona(id);
        }

        public IEnumerable<ClienteModel> listarPersona()
        {
            return repositoryPersona.listarPersona();
        }

        private bool validarDatosPersona(ClienteModel persona)
        {
            //if (persona.Nombre.Trim().Length < 2)
            //{
            //    return false;
            //}

            return true;
        }
    }
}
