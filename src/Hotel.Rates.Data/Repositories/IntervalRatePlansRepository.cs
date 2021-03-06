﻿using Hotel.Rates.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Data.Repositories
{
    public class IntervalRatePlansRepository : IRepository<IntervalRatePlan>
    {
        private readonly InventoryContext _inventoryContext;

        public IntervalRatePlansRepository(InventoryContext inventoryContext)
        {
            this._inventoryContext = inventoryContext;
        }
        public IntervalRatePlan Add(IntervalRatePlan entity)
        {
            _inventoryContext.IntervalRatePlans.Add(entity);
            return entity;
        }

        public IQueryable<IntervalRatePlan> All()
        {
            return _inventoryContext.IntervalRatePlans;
        }

        public int SaveChanges()
        {
            return _inventoryContext.SaveChanges();
        }
    }
}
