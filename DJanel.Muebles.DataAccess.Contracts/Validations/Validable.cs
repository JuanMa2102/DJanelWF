using DJanel.Muebles.CrossCutting.Services;
using FluentValidation;
using FluentValidation.Results;
using System.Linq;

namespace DJanel.Muebles.DataAccess.Contracts.Validations
{
    public abstract class Validable
    {
        private ValidatorFactory validationFactory;

        private readonly IValidator validator;

        public Validable()
        {
            validationFactory = ServiceLocator.Instance.Resolve<ValidatorFactory>();
            validator = validationFactory.GetValidator(this.GetType());
        }

        public string Error
        {
            get
            {
                var validationResults = validator.Validate(this);
                if (validationResults.Errors.Count == 0) return string.Empty;
                if (validationResults.Errors.Count == 1)
                {
                    return validationResults.Errors.Select(x => x.ErrorMessage).FirstOrDefault();
                }
                else
                {
                    return "The entity is no valid";
                }
            }
        }

        public ValidationResult Validate()
        {
            return validator.Validate(this);
        }

        public string this[string columnName]
        {
            get
            {
                return Validate().Errors.Where(x => x.PropertyName == columnName)
                    .Select(x => x.ErrorMessage).FirstOrDefault();

            }
        }
    }
}