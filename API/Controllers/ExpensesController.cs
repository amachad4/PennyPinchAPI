using Application.Expenses;
using Microsoft.AspNetCore.Mvc;
using Domain;
using Microsoft.AspNetCore.Authorization;


namespace API.Controllers;
public class ExpensesController : BaseApiController
{
    [HttpGet]
    public async Task<IActionResult> GetExpenses()
    {
        return HandleResult(await Mediator.Send(new List.Query()));
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetExpense(Guid id)
    {
        var result = await Mediator.Send(new Details.Query{Id = id});

        return HandleResult(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateExpense(Expense expense)
    {
        return HandleResult(await Mediator.Send(new Create.Command { Expense = expense }));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> EditExpense(Guid id, Expense expense)
    {
        expense.Id = id;
        return HandleResult(await Mediator.Send(new Edit.Command { Expense = expense }));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteExpense(Guid id)
    {
        return HandleResult(await Mediator.Send(new Delete.Command { Id = id }));
    }
}