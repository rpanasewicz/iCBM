using System;
using iCBM.Domain.Models;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;

namespace iCBM.Application.Dtos
{
    public class ExpenseListItemDto : IMapFrom<Expense>
    {
        public string Name { get; }
        public MoneyDto Amount { get; }
        public DateTime ExpenseTime { get; }
        public Guid CategoryId { get; }
        public string SupplierName { get; }
        public string CategoryName { get; }
        public string CategoryColorName { get; }
        public string CategoryIcon { get; }

        public ExpenseListItemDto(string name, MoneyDto amount, DateTime expenseTime, Guid categoryId, string supplierName, string categoryName, string categoryColorName, string categoryIcon)
        {
            Name = name;
            Amount = amount;
            ExpenseTime = expenseTime;
            CategoryId = categoryId;
            SupplierName = supplierName;
            CategoryName = categoryName;
            CategoryColorName = categoryColorName;
            CategoryIcon = categoryIcon;
        }
    }
}