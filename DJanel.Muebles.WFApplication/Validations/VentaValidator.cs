using DJanel.Muebles.Business.ViewModels.Ventas;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.WFApplication.Validations
{
    public class VentaValidator : AbstractValidator<VentaViewModel>
    {
        public VentaValidator()
        {
            RuleFor(Venta => Venta.Lista)
                .NotEmpty()
                .WithMessage("NO HAY DATOS EN LA TABLA");


            RuleFor(Venta => Venta.NombreCliente)
                .NotEmpty()
                .WithMessage("DEBE SELECCIONAR UN CLIENTE");


            RuleFor(Venta => Venta.Pago)
                .NotEmpty()
                .WithMessage("DEBE INGRESAR UN PAGO")
                .Must( (venta, context) =>
                {

                    if (venta.Pago < venta.Total) return false;
                    else return true;
                }).WithMessage("EL PAGO NO CUBRE EL TOTAL DE LA VENTA");

        }
    }
}
