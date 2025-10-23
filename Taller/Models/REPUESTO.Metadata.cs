using System.ComponentModel.DataAnnotations;

namespace Taller
{
    [MetadataType(typeof(REPUESTOMetadata))]
    public partial class REPUESTO
    {
        // Clase parcial para enlazar metadata
    }

    public class REPUESTOMetadata
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        [StringLength(50, ErrorMessage = "Máximo 50 caracteres")]
        public string marca { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, 100000, ErrorMessage = "El precio debe estar entre 0.01 y 100,000")]
        public decimal precio_u { get; set; }

        [StringLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string estado { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un proveedor")]
        public int idproveedor { get; set; }
    }
}
