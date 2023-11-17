namespace Domain;

public class Expense
{
    public Guid Id { get; set; }
    public decimal Amount { get; set; }
    public int LkpCategory { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public Guid UserId { get; set; }
}