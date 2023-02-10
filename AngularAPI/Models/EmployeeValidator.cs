using FluentValidation;
namespace AngularAPI.Models
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.Name).Length(3,25).WithMessage("Lütfen geçerli aralıkta isim girin.");
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.Phone).NotNull();
            RuleFor(x => x.Salary).NotNull();
            RuleFor(x => x.Department).Length(1, 15);
            RuleFor(x => x.Order).NotNull().Must(s => s>0).WithMessage("Order Negatif Değer alamaz!");
        }
    }
}
