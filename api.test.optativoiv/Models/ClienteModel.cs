using System.ComponentModel.DataAnnotations;

namespace api.test.optativoiv.Models
{
    public class ClienteModel
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public int Edad { get; set; }

        public string Email { get; set; }

        public string Telefono { get; set; }

        public string Ciudad { get; set; }

        public string Nacionalidad { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public int Documento { get; set; }
    }
}
