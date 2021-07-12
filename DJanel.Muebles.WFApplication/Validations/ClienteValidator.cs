using DJanel.Muebles.Business.ViewModels.Clientes;
using FluentValidation;

namespace DJanel.Muebles.WFApplication.Validations
{
    public class ClienteValidator : AbstractValidator<ClienteViewModel>
    {
        public ClienteValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("INGRESAR EL NOMBRE COMPLETO DEL USUARIO.")
                .MaximumLength(200)
                .WithMessage("EL NOMBRE NO PUEDE SER MAYOR A 200 CARACTERES.");

            RuleFor(x => x.Apellido_Pat)
                .NotEmpty()
                .WithMessage("INGRESAR EL APELLIDO PATERNO DEL USUARIO.")
                .MaximumLength(200)
                .WithMessage("EL APELLIDO PATERNO NO PUEDE SER MAYOR A 200 CARACTERES.");

            RuleFor(x => x.Apellido_Mat)
                .NotEmpty()
                .WithMessage("INGRESAR EL APELLIDO MATERNO DEL USUARIO.")
                .MaximumLength(200)
                .WithMessage("EL APELLIDO MATERNO NO PUEDE SER MAYOR A 200 CARACTERES.");

            RuleFor(x => x.Telefono)
                .NotEmpty()
                .WithMessage("INGRESAR EL TELEFONO DEL USUARIO.")
                .MaximumLength(10)
                .WithMessage("EL TELEFONO NO PUEDE SER MAYOR A 10 DIGITOS.");

            RuleFor(x => x.Domicilio)
                .NotEmpty()
                .WithMessage("INGRESAR EL DOMICILIO DEL USUARIO.")
                .MaximumLength(500)
                .WithMessage("EL NOMBRE NO PUEDE SER MAYOR A 500 CARACTERES.");
        }
    }
}
