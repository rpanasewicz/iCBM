using iCBM.Domain.Enums;
using iCBM.Domain.Models;
using iCBM.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Misio.Common.CQRS.Commands.Abstractions;
using Misio.Domain.Types;
using System;
using System.Threading.Tasks;
using iCBM.Application.Exceptions;

namespace iCBM.Application.Commands.Expenses
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
        public Guid ConstructionStageId { get; }

        public AddExpenseCommand(string name, string description, decimal amount, string currency, DateTime expenseTime, string categoryName, Guid? categoryId, Guid? supplierId, Guid constructionStageId)
        {
            Name = name;
            Description = description;
            Amount = amount;
            Currency = currency;
            ExpenseTime = expenseTime;
            CategoryName = categoryName;
            CategoryId = categoryId;
            SupplierId = supplierId;
            ConstructionStageId = constructionStageId;
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
                supplier = supplier ?? throw new Exception("Supplier not found");
            }

            var category = cmd.CategoryId switch
            {
                not null => await _ctx.Categories.FindAsync(cmd.CategoryId),
                _ => await _ctx.Categories.SingleOrDefaultAsync(c => c.Name.Equals(cmd.CategoryName))
            };


            if (category is null)
                throw cmd.CategoryId switch
                {
                    not null => new ResourceNotFoundException(nameof(Category), cmd.CategoryId.Value),
                    _ => new ResourceNotFoundException(nameof(Category), cmd.CategoryName)
                };

            var constructionStage = await _ctx.ConstructionStages.FindAsync(cmd.ConstructionStageId);

            if (constructionStage is null)
                throw new ResourceNotFoundException(nameof(ConstructionStage), cmd.ConstructionStageId);

            var expense = Expense.New(cmd.Name, cmd.Description,
                new Money(cmd.Amount, Enumeration.FromDisplayName<Currency>(cmd.Currency)),
                cmd.ExpenseTime, supplier, category, constructionStage);

            await _ctx.Expenses.AddAsync(expense);

            return expense.Id;
        }
    }
}
