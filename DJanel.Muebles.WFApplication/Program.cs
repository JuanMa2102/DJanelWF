using DJanel.Muebles.Business.Dependencies;
using DJanel.Muebles.Business.ViewModels.Clientes;
using DJanel.Muebles.Business.ViewModels.Productos;
using DJanel.Muebles.Business.ViewModels.Proveedores;
using DJanel.Muebles.Business.ViewModels.Usuarios;
using DJanel.Muebles.Business.ViewModels.Ventas;
using DJanel.Muebles.Business.ViewModelsReports.Compra;
using DJanel.Muebles.Business.ViewModelsReports.Productos;
using DJanel.Muebles.Business.ViewModelsReports.Ticket;
using DJanel.Muebles.Business.ViewModelsReports.Ventas;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using DJanel.Muebles.WFApplication.Forms.Usuarios;
using DJanel.Muebles.WFApplication.Validations;
using FluentValidation;
using System;
using System.Windows.Forms;

namespace DJanel.Muebles.WFApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NDcyMTY0QDMxMzkyZTMyMmUzMGN1S0pycTZWejVUMFp6cG45U3p5emRXNW1KNlp4SGlTM2VlcUxuSEU5VlE9");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InitializeContainer();
            Application.Run(new Login());
        }

        public static void InitializeContainer()
        {
            RegisterDependencies();
            if (!ServiceLocator.ContainerIsBuild)
                ServiceLocator.Instance.Build();
        }

        public static void RegisterDependencies()
        {
            Registrar.RegisterDependencies();
            RegisterViewModelDependencies();
            RegisterValidationDependencies();
        }

        private static void RegisterValidationDependencies()
        {
            ServiceLocator.Instance.Register<UsuarioValidator, IValidator<UsuarioViewModel>>();
            ServiceLocator.Instance.Register<LoginValidator, IValidator<LoginViewModel>>();
            ServiceLocator.Instance.Register<ProveedorValidator, IValidator<ProveedorViewModel>>();
            ServiceLocator.Instance.Register<ProductoValidator, IValidator<ProductoViewModel>>();
            ServiceLocator.Instance.Register<ProductoCompraValidator, IValidator<ProductoCompraViewModel>>();
            ServiceLocator.Instance.Register<ClienteValidator, IValidator<ClienteViewModel>>();
            ServiceLocator.Instance.Register<VentaValidator, IValidator<VentaViewModel>>();
            ServiceLocator.Instance.Register<PerfilValidator, IValidator<PerfilViewModel>>();
        }

        private static void RegisterViewModelDependencies()
        {
            ServiceLocator.Instance.Register<ValidatorFactory>();
            ServiceLocator.Instance.Register<UsuarioViewModel>();
            ServiceLocator.Instance.Register<LoginViewModel>();
            ServiceLocator.Instance.Register<ProveedorViewModel>();
            ServiceLocator.Instance.Register<ProveedorGridViewModel>();
            ServiceLocator.Instance.Register<ProductoViewModel>();
            ServiceLocator.Instance.Register<ProductoGridViewModel>();
            ServiceLocator.Instance.Register<ProductoCompraViewModel>();
            ServiceLocator.Instance.Register<ClienteViewModel>();
            ServiceLocator.Instance.Register<ClienteGridViewModel>();
            ServiceLocator.Instance.Register<VentaViewModel>();
            ServiceLocator.Instance.Register<PerfilViewModel>();

            /*---------------------REPORTES----------------------------*/
            
            ServiceLocator.Instance.Register<VentaReporteViewModel>();
            ServiceLocator.Instance.Register<CompraReporteViewModel>();
            ServiceLocator.Instance.Register<TicketViewModel>();
            ServiceLocator.Instance.Register<ProductoReporteViewModel>();
        }
    }
}
