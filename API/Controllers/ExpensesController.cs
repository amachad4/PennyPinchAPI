using Application.Expenses;
using Microsoft.AspNetCore.Mvc;
using Domain;


namespace API.Controllers;

public class ExpensesController : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<Expense>>> GetExpenses()
    {
        return await Mediator.Send(new List.Query());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Expense>> GetExpense(Guid id)
    {
        return await Mediator.Send(new Details.Query{Id = id});
    }

    [HttpPost]
    public async Task<IActionResult> CreateExpense(Expense expense)
    {
        await Mediator.Send(new Create.Command { Expense = expense });
        return Ok();
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> EditExpense(Guid id, Expense expense)
    {
        expense.Id = id;
        await Mediator.Send(new Edit.Command { Expense = expense });
        return Ok();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteExpense(Guid id)
    {
        await Mediator.Send(new Delete.Command { Id = id });
        return Ok();
    }
}