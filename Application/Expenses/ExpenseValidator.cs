using FluentValidation;
using Domain;

namespace Application.Expenses;

public class ExpenseValidator : AbstractValidator<Expense>
{
    public ExpenseValidator()
    {
        RuleFor(x => x.Amount).NotEmpty();
        RuleFor(x => x.Date).NotEmpty();
        RuleFor(x => x.LkpCategory).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}