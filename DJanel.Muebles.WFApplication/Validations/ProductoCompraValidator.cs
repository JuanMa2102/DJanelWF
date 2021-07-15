using DJanel.Muebles.Business.ViewModels.Productos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.WFApplication.Validations
{
    public class ProductoCompraValidator : AbstractValidator<ProductoCompraViewModel>
    {
        public ProductoCompraValidator()
        {
            RuleFor(x => x.Cantidad)
               .NotEqual(0).WithMessage("NO DEBE DEJAR EL CAMPO DE CANTIDAD VACIO");
            RuleFor(x => x.Costo)
               .NotEqual(0).WithMessage("NO DEBE DEJAR EL CAMPO DE COSTO DE COMPRA VACIO");
            RuleFor(x => x.Total)
               .NotEqual(0).WithMessage("NO DEBE DEJAR EL CAMPO DE TOTAL VACIO");
        }
    }
}
