using Ecommerce.Models.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Categoria
    {
     

        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Por favor ingresar el Nombre de la Categoria:")]
        [StringLength(150, MinimumLength = 4)]
        public string Nombre { get; set; }


        // Relación 1 a muchos con Subcategoría
        public ICollection<Subcategoria>? Subcategorias { get; set; }

    }
}
