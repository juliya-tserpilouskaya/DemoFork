using FluentValidation;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BulbaCourses.Video.Web.App_Start
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