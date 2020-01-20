using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentValidation;
using Ninject;

namespace BulbaCourses.TextMaterials_Presentations.Web
{
    public class NinjectValidationFactory : ValidatorFactoryBase
    {
        private IKernel _kernel;

        public NinjectValidationFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return (IValidator) _kernel.TryGet(validatorType);
        }
    }
}