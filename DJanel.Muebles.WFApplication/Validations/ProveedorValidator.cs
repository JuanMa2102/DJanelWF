using DJanel.Muebles.Business.ViewModels.Proveedores;
using FluentValidation;

namespace DJanel.Muebles.WFApplication.Validations
{
    public class ProveedorValidator : AbstractValidator<ProveedorViewModel>
    {
        public ProveedorValidator()
        {
            RuleFor(x => x.Nombre_Empresa)
                .NotEmpty()
                .WithMessage("INGRESAR EL NOMBRE DE LA EMPRESA")
                .MaximumLength(200)
                .WithMessage("EL APELLIDO PATERNO NO PUEDE SER MAYOR A 200 CARACTERES.");

            RuleFor(x => x.Nombre_Propietario)
                .NotEmpty()
                .WithMessage("INGRESAR EL NOMBRE DEL PROPIETARIO DE LA EMPRESA.")
                .MaximumLength(200)
                .WithMessage("EL APELLIDO MATERNO NO PUEDE SER MAYOR A 200 CARACTERES.");

            RuleFor(x => x.Telefono)
                .NotEmpty()
                .WithMessage("INGRESAR EL TELEFONO DEL PROVEEDOR.")
                .MaximumLength(10)
                .WithMessage("EL TELEFONO NO PUEDE SER MAYOR A 10 DIGITOS.");

            RuleFor(x => x.Domicilio)
                .NotEmpty()
                .WithMessage("INGRESAR EL DOMICILIO DEL PROVEEDOR.")
                .MaximumLength(500)
                .WithMessage("EL NOMBRE NO PUEDE SER MAYOR A 500 CARACTERES.");
        }
    }
}
