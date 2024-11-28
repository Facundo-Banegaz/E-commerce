using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Models;

namespace Ecommerce.Services.Definicion
{
    public interface IProductosInterface
    {
        public List<Producto> ProductosPantallaPrincipal();

        public Producto ProductoDetail(Guid Id);
    }
}
