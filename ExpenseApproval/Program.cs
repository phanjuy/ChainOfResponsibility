using ExpenseApproval;

var manager = new SeniorManager();
var vp = new VicePresident();
var coo = new COO();

manager.SetSupervisor(vp);
vp.SetSupervisor(coo);

var expense = new ExpenseReport("Monitor", 100);
Console.WriteLine(expense);
manager.ApproveRequest(expense);

expense = new ExpenseReport("Desk", 900);
Console.WriteLine(expense);
manager.ApproveRequest(expense);

expense = new ExpenseReport("Travel", 5_500);
Console.WriteLine(expense);
manager.ApproveRequest(expense);
