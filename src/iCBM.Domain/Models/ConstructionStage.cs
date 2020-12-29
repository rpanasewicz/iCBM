using System;
using System.Collections.Generic;
using System.Linq;
using iCBM.Domain.Common;
using iCBM.Domain.Enums;
using Misio.Domain.Types;

namespace iCBM.Domain.Models
{
    public class ConstructionStage : OwnedEntity
    {
        public string Name { get; private set; }
        public int ColorId { get; private set; }
        public string Icon { get; private set; }
        public DateTime PlannedStartDate { get; private set; }
        public DateTime PlannedFinishDate { get; private set; }
        public DateTime? ActualStartDate { get; private set; }
        public DateTime? ActualFinishDate { get; private set; }

        public Color Color
        {
            get => Enumeration.FromValue<Color>(ColorId);
            private set => ColorId = value.Id;
        }

        private ISet<Expense> _expenses;

        public IEnumerable<Expense> Expenses
        {
            get => _expenses.AsEnumerable();
            private set => _expenses = new HashSet<Expense>(value);
        }

        private ConstructionStage() { }
        
        private ConstructionStage(Guid id, string name, Color color, string icon, DateTime plannedStartDate,
            DateTime plannedFinishDate, DateTime? actualStartDate, DateTime? actualFinishDate,
            IEnumerable<Expense> expenses)
        {
            Id = id;
            Name = name;
            Color = color;
            Icon = icon;
            Expenses = expenses;
            PlannedStartDate = plannedStartDate;
            PlannedFinishDate = plannedFinishDate;
            ActualStartDate = actualStartDate;
            ActualFinishDate = actualFinishDate;
        }

        public static ConstructionStage New(string name, Color color, string icon, DateTime plannedStartDate,
            DateTime plannedFinishDate, DateTime? actualStartDate, DateTime? actualFinishDate)
        {
            return new ConstructionStage(Guid.NewGuid(), name, color, icon, plannedStartDate, plannedFinishDate, actualStartDate,
                actualFinishDate, Enumerable.Empty<Expense>());
        }
        
        public void Update(string name, Color color, string icon, DateTime plannedStartDate,
            DateTime plannedFinishDate, DateTime? actualStartDate, DateTime? actualFinishDate)
        {
            Name = name;
            Color = color;
            Icon = icon;
            PlannedStartDate = plannedStartDate;
            PlannedFinishDate = plannedFinishDate;
            ActualStartDate = actualStartDate;
            ActualFinishDate = actualFinishDate;
        }
    }
}
