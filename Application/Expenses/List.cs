using Application.Core;
using MediatR;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses;

public record Expenses
{
    public List<Expense> Data {
        get;
    }

    public Expenses(List<Expense> expenses)
    {
        Data = expenses;
    }
}

public class List
{
    public class Query : IRequest<Result<Expenses>>
    {
    }

    public class Handler : IRequestHandler<Query, Result<Expenses>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<Expenses>> Handle(Query request, CancellationToken cancellationToken)
        {
            var expenses = await _context.Expenses.ToListAsync();
            return Result<Expenses>.Success(new Expenses(expenses));
        }
    }
}