using System.ComponentModel.DataAnnotations;

namespace Taller
{
    [MetadataType(typeof(CLIENTEMetadata))]
    public partial class CLIENTE
    {
        // Clase parcial para enlazar la metadata
    }

    public class CLIENTEMetadata
    {
        // Apellidos: obligatorio, máximo 50, solo letras y espacios
        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "Solo letras y espacios permitidos")]
        public string apellidos { get; set; }

        // Nombres: obligatorio, máximo 50, solo letras y espacios
        [Required(ErrorMessage = "El campo Nombres es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "Solo letras y espacios permitidos")]
        public string nombres { get; set; }

        // DUI: obligatorio, formato 123456789
        
        [Required(ErrorMessage = "El DUI es obligatorio")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "El DUI debe tener 9 dígitos y solo números")]

        public string dui { get; set; }

        // Dirección: obligatorio, máximo 100 caracteres
        [Required(ErrorMessage = "La Dirección es obligatoria")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string direccion { get; set; }

        // Teléfono 1: obligatorio, formato ####-####
        [Required(ErrorMessage = "El Teléfono 1 es obligatorio")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El Numero de teléfono debe tener 8 digitos y solo números")]
        public string tel1 { get; set; }



        // Teléfono 2: opcional, formato ####-####
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El Numero de teléfono debe tener 8 digitos y solo números")]

        public string tel2 { get; set; }

        // Email: opcional, máximo 50, formato correcto
        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string email { get; set; }
    }
}
