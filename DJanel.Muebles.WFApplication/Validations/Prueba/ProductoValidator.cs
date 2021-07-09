using DJanel.Muebles.Business.ViewModels.Prueba;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.WFApplication.Validations.Prueba
{
    public class ProductoValidator: AbstractValidator<ProductoViewModel>
    {
        public ProductoValidator()
        {
            
        }

    }
}