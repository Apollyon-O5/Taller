using System.ComponentModel.DataAnnotations;

namespace Taller
{
    [MetadataType(typeof(PROVEEDORMetadata))]
    public partial class PROVEEDOR
    {
        // Clase parcial para enlazar la metadata
    }

    public class PROVEEDORMetadata
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria")]
        [StringLength(200, ErrorMessage = "Máximo 200 caracteres")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "El teléfono debe tener 8 dígitos y solo números")]
        public string telefono { get; set; }

        [Required(ErrorMessage = "La sucursal es obligatoria")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string sucursal { get; set; }

        [EmailAddress(ErrorMessage = "Correo electrónico no válido")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string email { get; set; }
    }
}
