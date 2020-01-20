using FluentValidation;
using Ninject;
using System;

namespace BulbaCourses.Analytics.Web.Ensure
{
    /// <summary>
    /// Represents Ninject Validation Factory
    /// </summary>
    public class NinjectValidationFactory : ValidatorFactoryBase
    {
        private readonly IKernel _kernel;

        /// <summary>
        /// Creates NinjectValidationFactory instance.
        /// </summary>
        /// <param name="kernel"></param>
        public NinjectValidationFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Creates a Validator instance.
        /// </summary>
        /// <param name="validatorType"></param>
        /// <returns></returns>
        public override IValidator CreateInstance(Type validatorType)
        {
            return (IValidator)_kernel.TryGet(validatorType);
        }
    }
}