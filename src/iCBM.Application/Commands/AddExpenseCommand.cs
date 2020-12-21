using Misio.Common.CQRS.Commands.Abstractions;
using System;
using System.Threading.Tasks;
using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using iCBM.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
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
        public string CategoryName { get; }
        public Guid? CategoryId { get; }
        public Guid? SupplierId { get; }
        
        public AddExpenseCommand(string name, string description, decimal amount, string currency, DateTime expenseTime, Guid? supplierId, Guid? categoryId, string categoryName)
        {
            Name = name;
            Description = description;
            Amount = amount;
            Currency = currency;
            ExpenseTime = expenseTime;
            SupplierId = supplierId;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
    }
    
    public class AddExpenseCommandHandler : ICommandHandler<AddExpenseCommand, Guid>
    {
        private readonly ICbmContext _ctx;

        public AddExpenseCommandHandler(ICbmContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Guid> Handle(AddExpenseCommand cmd)
        {
            Supplier supplier = null;

            if (cmd.SupplierId is not null)
            {
                supplier = await _ctx.Suppliers.FindAsync(cmd.SupplierId);
                supplier = supplier ?? throw new Exception();
            }

            var category = cmd.CategoryId switch
            {
                null => await _ctx.Categories.FindAsync(cmd.CategoryId),
                _ => await _ctx.Categories.SingleOrDefaultAsync(c => c.Name.Equals(cmd.CategoryName))
            };

            if (category is null)
            {
                throw new Exception();
            }
            
            var expense = Expense.New(cmd.Name, cmd.Description,
                new Money(cmd.Amount, Enumeration.FromDisplayName<Currency>(cmd.Currency)), 
                cmd.ExpenseTime, supplier, category);

            await _ctx.Expenses.AddAsync(expense);

            return expense.Id;
        }
    }
}
