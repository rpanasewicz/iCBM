﻿using iCBM.Domain.Common;
using iCBM.Domain.Enums;
using Misio.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iCBM.Domain.Models
{
    public class Category : OwnedEntity
    {
        public string Name { get; private set; }
        public int ColorId { get; private set; }
        public string Icon { get; private set; }

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

        private Category() { } // For EF

        private Category(Guid id, string name, Color color, string icon, IEnumerable<Expense> expenses)
        {
            Id = id;
            Name = name;
            Color = color;
            Icon = icon;
            Expenses = expenses;
        }

        public static Category New(string name, Color color, string icon)
        {
            return new Category(Guid.NewGuid(), name, color, icon, Enumerable.Empty<Expense>());
        }

        public void Update(string name, Color color, string icon)
        {
            Name = name;
            Color = color;
            Icon = icon;
        }
    }
}
