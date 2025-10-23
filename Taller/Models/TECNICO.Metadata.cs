using System.ComponentModel.DataAnnotations;

namespace Taller
{
    [MetadataType(typeof(TECNICOMetadata))]
    public partial class TECNICO
    {
        // Clase parcial para enlazar la metadata
    }

    public class TECNICOMetadata
    {
        [Required(ErrorMessage = "El campo Apellidos es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "Solo letras y espacios permitidos")]
        public string apellidos { get; set; }

        [Required(ErrorMessage = "El campo Nombres es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        [RegularExpression(@"^[a-zA-ZáéíóúÁÉÍÓÚüÜñÑ\s]+$", ErrorMessage = "Solo letras y espacios permitidos")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "El DUI es obligatorio")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "El DUI debe tener 9 dígitos y solo números")]
        public string dui { get; set; }

        [Required(ErrorMessage = "El Teléfono 1 es obligatorio")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener 8 dígitos y solo números")]
        public string tel1 { get; set; }

        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener 8 dígitos y solo números")]
        public string tel2 { get; set; }

        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string email { get; set; }
    }
}
