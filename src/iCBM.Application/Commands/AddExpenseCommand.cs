using Misio.Common.CQRS.Commands.Abstractions;
using System;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using iCBM.Domain.Models;
using Misio.Domain.Types;

namespace iCBM.Application.Commands
{
    public class AddExpenseCommand : ICommand
    {
        public string Name { get; set; }
        public string Description { get; }
        public decimal Amount { get; }
        public string Currency { get; }
        public DateTime ExpenseTime { get; }
        
        public AddExpenseCommand(string name, string description, decimal amount, string currency, DateTime expenseTime)
        {
            Name = name;
            Description = description;
            Amount = amount;
            Currency = currency;
            ExpenseTime = expenseTime;
        }
    }
    
    public class AddExpenseCommandHandler : ICommandHandler<AddExpenseCommand>
    {
        private readonly ICbmContext _ctx;

        public AddExpenseCommandHandler(ICbmContext ctx)
        {
            _ctx = ctx;
        }

        public Task<Unit> Handle(AddExpenseCommand cmd)
        {
            var expense = Expense.New(cmd.Name, cmd.Description,
                new Money(cmd.Amount, Enumeration.FromDisplayName<Currency>(cmd.Currency)), 
                cmd.ExpenseTime);

            _ctx.Expenses.Add((expense));

            return Unit.Task;
        }
    }
}
