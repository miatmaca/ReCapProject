﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);     
            
            var result = validator.Validate(context);//Valid edilen yer
            if (!result.IsValid)//geçerli değilse 
            {
                throw new ValidationException(result.Errors);//hata fırlat
            }
        }

    }
}

    