using System.ComponentModel.DataAnnotations;

namespace Taller
{
    [MetadataType(typeof(SERVICIOMetadata))]
    public partial class SERVICIO
    {
        // Clase parcial para enlazar metadata
    }

    public class SERVICIOMetadata
    {
        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 10000, ErrorMessage = "El precio debe estar entre 0.01 y 10,000")]
        public decimal precio { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un técnico")]
        public int idtecnico { get; set; }
    }
}
