using DJanel.Muebles.Business.Dependencies;
using DJanel.Muebles.Business.ViewModels.Prueba;
using DJanel.Muebles.CrossCutting.Services;
using DJanel.Muebles.DataAccess.Contracts.Validations;
using DJanel.Muebles.WFApplication.Forms.Login;
using DJanel.Muebles.WFApplication.Forms.Prueba;
using DJanel.Muebles.WFApplication.Validations.Prueba;
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
            ServiceLocator.Instance.Register<ProductoValidator, IValidator<ProductoViewModel>>();
        }

        private static void RegisterViewModelDependencies()
        {
            ServiceLocator.Instance.Register<ValidatorFactory>();
            ServiceLocator.Instance.Register<ProductoViewModel>();
        }
    }
}
