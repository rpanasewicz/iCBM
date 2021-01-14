using iCBM.Domain.Models;
using Misio.Common.CQRS.Queries.AutoMapper.Abstractions;
using System;

namespace iCBM.Application.Dtos
{
    public class ExpenseDto : IMapFrom<Expense>
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public MoneyDto Amount { get; }
        public DateTime ExpenseTime { get; }
        public Guid? SupplierId { get; }
        public Guid ConstructionStageId { get; }
        public Guid CategoryId { get; }

        public ExpenseDto(Guid id, string name, string description, MoneyDto amount, DateTime expenseTime,
            Guid? supplierId, Guid categoryId, Guid constructionStageId)
        {
            Id = id;
            Name = name;
            Description = description;
            Amount = amount;
            ExpenseTime = expenseTime;
            SupplierId = supplierId;
            CategoryId = categoryId;
            ConstructionStageId = constructionStageId;
        }
    }
}