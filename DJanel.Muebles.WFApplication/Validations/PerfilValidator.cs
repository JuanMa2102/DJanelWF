using DJanel.Muebles.Business.ViewModels.Usuarios;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DJanel.Muebles.WFApplication.Validations
{
    class PerfilValidator : AbstractValidator<PerfilViewModel>
    {
        public PerfilValidator(IUsuarioRepository usuarioService)
        {
            RuleFor(pass => pass.Password)
                .MinimumLength(6).MaximumLength(10).WithMessage("LA CONTRASEÑA DEBE TENER ENTRE 6 Y 10 CARACTERES")
                .When(x => x.Enable);

            RuleFor(passdos => passdos.PasswordDos)
             .NotEmpty().When(x => x.Enable).WithMessage("DEBE INGRESAR LA CONTRASEÑA.");

            RuleFor(passdos => passdos.PasswordDos)
              .Equal((x) => x.Password)
              .WithMessage("LAS CONTRASEÑAS NO COINCIDEN.")
              .When(x => x.Enable);


            RuleFor(x => x.Username)
                .NotEmpty()
                .WithMessage("INGRESE CUENTA.")
                .MaximumLength(200).WithMessage("EL NOMBRE DE USUARIO NO PUEDE SER MAYOR A 200 CARACTERES.")
                .MustAsync(async (Cuenta, x, context) =>
                {

                    int result = await usuarioService.EsCuentaUnica(Cuenta.Username);
                    if (result != 0)
                    {
                        if (result == Cuenta.IdUsuario)
                            return true;
                        else
                            return false;
                    }
                    else
                        return true;
                }).WithMessage("EL NOMBRE DE LA CUENTA YA EXISTE");

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