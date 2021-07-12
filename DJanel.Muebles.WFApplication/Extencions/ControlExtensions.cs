using FluentValidation;
using System.Windows.Forms;
using System;
using System.Reflection;
using System.Linq;
using FluentValidation.Results;

namespace DJanel.Muebles.WFApplication.Extencions
{
    public static class ControlExtensions
    {
        public static Control[] ToArrayControl(this Control.ControlCollection ctrl)
        {
            Control[] controls = new Control[ctrl.Count];
            int index = 0;
            foreach (Control control in ctrl)
            {
                controls[index] = control;
                index++;
            }
            return controls;
        }

        public static void ShowErrors(this Control container, ErrorProvider errorProvider, Type entityType, ValidationResult validationResults)
        {
            foreach (var pi in entityType.GetProperties())
            {
                var controlProperty = container.GetType().GetField(pi.Name + "Control", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (controlProperty != null)
                {
                    errorProvider.SetError((Control)controlProperty.GetValue(container),
                        string.Join(", ", validationResults.Errors.Where(x => x.PropertyName == pi.Name)
                        .Select(x => x.ErrorMessage)));
                }
            }

            }

        public static void CleanErrors(this Control container, ErrorProvider errorProvider, Type entityType)
        {
            foreach (var pi in entityType.GetProperties())
            {
                var controlProperty = container.GetType().GetField(pi.Name + "Control", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                if (controlProperty != null)
                {
                    errorProvider.SetError((Control)controlProperty.GetValue(container), string.Empty);
                }
            }
        }
    }
}