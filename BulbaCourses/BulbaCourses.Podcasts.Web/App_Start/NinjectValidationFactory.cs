using System;
using FluentValidation;
using Ninject;

namespace BulbaCourses.Podcasts.Web.App_Start
{
    public class NinjectValidationFactory : ValidatorFactoryBase
    {
        private readonly IKernel _kernel;

        public NinjectValidationFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return (IValidator)_kernel.TryGet(validatorType);
        }
    }
}