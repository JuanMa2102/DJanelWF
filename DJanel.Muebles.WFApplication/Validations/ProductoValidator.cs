using DJanel.Muebles.Business.ViewModels.Productos;
using DJanel.Muebles.DataAccess.Contracts.Repositories.General;
using FluentValidation;

namespace DJanel.Muebles.WFApplication.Validations
{
    public class ProductoValidator: AbstractValidator<ProductoViewModel>
    {
        public ProductoValidator(IProductoRepository productoRepository)
        {
            RuleFor(x => x.Nombre)
                .NotEmpty()
                .WithMessage("INGRESAR EL NOMBRE DEL PRODUCTO")
                .MaximumLength(200)
                .WithMessage("EL NOMBRE DEL PRODUCTO NO PUEDE SER MAYOR A 200 CARACTERES.");

            RuleFor(x => x.Precio)
                .NotEqual(0).WithMessage("NO DEBE DEJAR EL CAMPO DE PRECIO VACIO");

            RuleFor(x => x.Marca)
                .NotEmpty()
                .WithMessage("INGRESE LA MARCA DEL PRODUCTO.")
                .MaximumLength(100)
                .WithMessage("LA MARCA NO DEBE SER MAYOT A 100 DIGITOS.");

            RuleFor(x => x.Modelo)
                .NotEmpty()
                .WithMessage("INGRESAR EL MODELO DEL PRODUCTO.")
                .MaximumLength(100)
                .WithMessage("LA MARCA NO DEBE SER MAYOR A 100 CARACTERES.");

            RuleFor(producto => producto.ClaveBusqueda)
               .MustAsync(async (producto, x, context) =>
               {
                   if (producto.ClaveBusqueda != string.Empty)
                   {
                       int result = await productoRepository.ClaveExist(producto.ClaveBusqueda);
                       if (result > 0)
                       {
                           if (result == producto.IdProducto)
                               return true;
                           else
                               return false;
                       }
                       else
                           return true;
                   }
                   else return true;
               })
               .WithMessage("LA CLAVE YA EXISTE");
        }
    }
}
