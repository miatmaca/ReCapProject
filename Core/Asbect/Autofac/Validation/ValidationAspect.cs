using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.İnterceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Asbect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;//Exp : CarValidator
        }
        protected override void OnBefore(IInvocation invocation)
        {
           
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Reflection:Çalışma Anında devreye girme durumu
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];//Validater Tipini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);//Parametrelerini bak
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
