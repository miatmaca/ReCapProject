using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)//İş kurallarını gez
            {
                if (!logic.Success)//İşkuralı Başarısız ise
                {
                    return logic;//ErrorResult döndürür
                }

            }
            return null;
        }
    }
}
