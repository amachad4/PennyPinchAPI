using Microsoft.AspNetCore.Mvc;
using Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

public class ExpensesController : BaseApiController
{
    private readonly DataContext _context;

    public ExpensesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<List<Expense>>> GetExpenses()
    {
        return await _context.Expenses.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Expense>> GetExpense(Guid id)
    {
        return await _context.Expenses.FindAsync(id);
    }
}