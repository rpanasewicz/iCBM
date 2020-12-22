using iCBM.Domain.Models;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;
using System;
using AutoMapper;

namespace iCBM.Application.Dtos
{
    public class ExpenseDto : IMapFrom<Expense>
    {
        public string Name { get; }
        public string Description { get; }
        public MoneyDto Amount { get; }
        public DateTime ExpenseTime { get; }

        public SupplierDto Supplier { get; }
        public CategoryDto Category { get; }

        public ExpenseDto(string name, string description, MoneyDto amount, DateTime expenseTime, CategoryDto category,
            SupplierDto supplier)
        {
            Name = name;
            Description = description;
            Amount = amount;
            ExpenseTime = expenseTime;
            Supplier = supplier;
            Category = category;
        }
    }
}