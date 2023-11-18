using Application.Core;
using MediatR;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Expenses;

public class List
{
    public class Query : IRequest<Result<List<Expense>>>
    {
    }

    public class Handler : IRequestHandler<Query, Result<List<Expense>>>
    {
        private readonly DataContext _context;

        public Handler(DataContext context)
        {
            _context = context;
        }

        public async Task<Result<List<Expense>>> Handle(Query request, CancellationToken cancellationToken)
        {
            var expenses = await _context.Expenses.ToListAsync();
            return Result<List<Expense>>.Success(expenses);
        }
    }
}