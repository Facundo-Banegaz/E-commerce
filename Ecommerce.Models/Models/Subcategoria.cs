using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models.Models
{
    public class Subcategoria
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Nombre:")]
        [Required(ErrorMessage = "Por favor ingresar el Nombre de la Subcategoría:")]
        [StringLength(150, MinimumLength = 4)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Por favor selecciona una imagen.")]
        [Display(Name = "Imagen")]
        public string Imagen { get; set; }

        public Categoria Categoria { get; set; }


        public ICollection<Producto>? Productos { get; set; }
       

    }
}
