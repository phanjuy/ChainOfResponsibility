namespace ExpenseApproval;

internal record ExpenseReport(string Name, int Amount);

internal interface IManager
{
    void SetSupervisor(IManager manager);
    void ApproveRequest(ExpenseReport expenseReport);
}

internal class SeniorManager : IManager
{
    private IManager? _manager;

    public void ApproveRequest(ExpenseReport expenseReport)
    {
        if (expenseReport.Amount < 500)
        {
            Console.WriteLine("Approved by SeniorManager");
            return;
        }
        _manager?.ApproveRequest(expenseReport);
    }

    public void SetSupervisor(IManager manager)
    {
        _manager = manager;
    }
}

internal class VicePresident : IManager
{
    private IManager? _manager;

    public void ApproveRequest(ExpenseReport expenseReport)
    {
        if (expenseReport.Amount < 1_000)
        {
            Console.WriteLine("Approved by VicePresident");
            return;
        }
        _manager?.ApproveRequest(expenseReport);
    }

    public void SetSupervisor(IManager manager)
    {
        _manager = manager;
    }
}

internal class COO : IManager
{
    private IManager? _manager;

    public void ApproveRequest(ExpenseReport expenseReport)
    {
        if (expenseReport.Amount < 5_000)
            Console.WriteLine("Approved by COO");
        else
            Console.WriteLine("Not approved");
    }

    public void SetSupervisor(IManager manager)
    {
        _manager = manager;
    }
}