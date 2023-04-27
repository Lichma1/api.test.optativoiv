using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using infraestructure.Models;

namespace infraestructure.Repository
{
    public class ClienteRepository
    {
        private string _connectionString;
        private Npgsql.NpgsqlConnection connection;
        public ClienteRepository(string connectionString)
        {
            this._connectionString = connectionString;
            this.connection = new Npgsql.NpgsqlConnection(this._connectionString);
        }

        public string insertarPersona(ClienteModel persona)
        {
            try
            {
                connection.Execute("insert into persona(nombre, apellido, documento, telefono, email, fechanacimiento, ciudad, nacionalidad) " +
                    " values(@nombre, @apellido, @documento, @telefono, @email, @fechanacimiento, @ciudad, @nacionalidad)", persona);
                return "Se inserto correctamente...";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public string modificarPersona(ClienteModel persona, int id) {
            try
            {
                connection.Execute($"UPDATE persona SET " +
                    "nombre = @nombre, " +
                    "apellido = @apellido, " +
                    "documento = @documento, " +
                    "telefono = @telefono " +
                    "email = @email, " +
                    "fechanacimiento = @fechanacimiento, " +
                    "ciudad = @ciudad, "+
                    "nacionalidad = @nacionalidad ," +
                    $"WHERE id = {id}", persona);
                return "Se modificaron los datos correctamente...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string eliminarPersona(int id)
        {
            try
            {
                connection.Execute($" DELETE FROM persona WHERE id = {id}");
                return "Se eliminó correctamente el registro...";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ClienteModel consultarPersona(int id)
        {
            try
            {
               return connection.QueryFirst<ClienteModel>($"SELECT * FROM persona WHERE id = {id}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<ClienteModel> listarPersona()
        {
            try
            {
                return connection.Query<ClienteModel>($"SELECT * FROM persona order by id asc");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
