using Entities.Concrete;
using FluentValidation;

public class BrandValidator : AbstractValidator<Brand>
{
    public BrandValidator()
    {
       
        RuleFor(p => p.BrandName).MinimumLength(2);
       
    }


}
