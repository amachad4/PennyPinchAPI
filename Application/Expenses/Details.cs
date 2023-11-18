using Application.Core;
using MediatR;
using Domain;
using Persistence;

namespace Application.Expenses;

public class Details
{
    public class Query : IRequest<Result<Expense>>
    {
        public Guid Id { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, Result<Expense>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
        public async Task<Result<Expense>> Handle(Query request, CancellationToken cancellationToken)
        {
            var expense = await _context.Expenses.FindAsync(request.Id);

            return Result<Expense>.Success(expense);
        }
    }
}