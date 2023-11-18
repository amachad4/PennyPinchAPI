using MediatR;
using Domain;
using Persistence;

namespace Application.Expenses;

public class Details
{
    public class Query : IRequest<Expense>
    {
        public Guid Id { get; set; }
    }
    
    public class Handler : IRequestHandler<Query, Expense>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
        public async Task<Expense> Handle(Query request, CancellationToken cancellationToken)
        {
            return await _context.Expenses.FindAsync(request.Id);
        }
    }
}