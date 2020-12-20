using Misio.Common.CQRS.Commands.Abstractions;
using System;
using System.Threading.Tasks;
using iCBM.Domain.Models;
using Misio.Domain.Types;

namespace iCBM.Application.Commands
{
    public class AddExpenseCommand : ICommand<Guid>
    {
        public string Name { get; set; }
        public string Description { get; }
        public decimal Amount { get; }
        public string Currency { get; }
        public DateTime ExpenseTime { get; }
        public Guid? SupplierId { get; }
        
        public AddExpenseCommand(string name, string description, decimal amount, string currency, DateTime expenseTime, Guid? supplierId)
        {
            Name = name;
            Description = description;
            Amount = amount;
            Currency = currency;
            ExpenseTime = expenseTime;
            SupplierId = supplierId;
        }
    }
    
    public class AddExpenseCommandHandler : ICommandHandler<AddExpenseCommand, Guid>
    {
        private readonly ICbmContext _ctx;

        public AddExpenseCommandHandler(ICbmContext ctx)
        {
            _ctx = ctx;
        }

        public Task<Guid> Handle(AddExpenseCommand cmd)
        {
            Supplier supplier = null;

            if (cmd.SupplierId is not null)
            {
                supplier = _ctx.Suppliers.Find(cmd.SupplierId);
                supplier = supplier ?? throw new Exception();
            }
            
            var expense = Expense.New(cmd.Name, cmd.Description,
                new Money(cmd.Amount, Enumeration.FromDisplayName<Currency>(cmd.Currency)), 
                cmd.ExpenseTime, supplier);

            _ctx.Expenses.Add((expense));

            return Task.FromResult(expense.Id);
        }
    }
}
