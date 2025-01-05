
using Ecommerce.Datos.Data;
using Ecommerce.Models;
using Ecommerce.Services.Definicion;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Services.Implementacion
{
    public class ProductosInterface : IProductosInterface
    {
        private EcommerceContext _EcommerceContext;

        public ProductosInterface(EcommerceContext _ecommerceContext) 
        {
            _EcommerceContext = _ecommerceContext;

        }

        public Producto ProductoDetail(Guid Id)
        {
            var producto = _EcommerceContext.Productos
    .Where(a => a.Id == Id)    // Filtra por el Id específico del producto
    .Include(a => a.Categoria)  // Incluir la relación de Categoría
    .Include(a => a.ProductoImagens) // Incluir la relación de ProductoImagens
    .FirstOrDefault();  // Devuelve el primer (o único) resultado o null si no lo encuentra

            return producto;
        }

        public List<Producto> ProductosPantallaPrincipal()
        {
         
            return   _EcommerceContext.Productos.Where(a => a.Promocionado).ToList();
        }
                
    }
}
