using Application.Core;
using AutoMapper;
using MediatR;
using Persistence;
using Domain;
using FluentValidation;

namespace Application.Expenses;

public class Edit
{
    public class Command : IRequest<Result<Unit>>
    {
        public Expense Expense { get; set; }
    }
    
    public class CommandValidator : AbstractValidator<Command>
    {
        public CommandValidator()
        {
            RuleFor(x => x.Expense).SetValidator(new ExpenseValidator());
        }
    }

    public class Handler : IRequestHandler<Command, Result<Unit>>
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public Handler(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(Command request, CancellationToken cancellationToken)
        {
            var expense = await _context.Expenses.FindAsync(request.Expense.Id);

            if (expense is null) return null;
            _mapper.Map(request.Expense, expense);
            var result = await _context.SaveChangesAsync() > 0;

            if (!result)
            {
                return Result<Unit>.Failure("Could not update the expense");
            }

            return Result<Unit>.Success(Unit.Value);
        }
    }
}