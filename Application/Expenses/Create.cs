using Domain;
using MediatR;
using Persistence;

namespace Application.Expenses;

public class Create
{
    public class Command : IRequest
    {
        public Expense Expense { get; set; }
    }

    public class Handler : IRequestHandler<Command>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            _context.Expenses.Add(request.Expense);
            await _context.SaveChangesAsync();
        }
    }
}