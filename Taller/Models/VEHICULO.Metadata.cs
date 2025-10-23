using System.ComponentModel.DataAnnotations;

namespace Taller
{
    [MetadataType(typeof(VEHICULOMetadata))]
    public partial class VEHICULO
    {
        // Clase parcial para enlazar metadata
    }

    public class VEHICULOMetadata
    {
        [Required(ErrorMessage = "La marca es obligatoria")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string marca { get; set; }

        [Required(ErrorMessage = "El modelo es obligatorio")]
        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string modelo { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        [Range(1900, 2100, ErrorMessage = "El año debe estar entre 1900 y 2100")]
        public short año { get; set; }

        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string color { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un cliente")]
        public int idcliente { get; set; }
    }
}
