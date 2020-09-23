using Hotel.Rates.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Data.Repositories
{
    public class RatePlansRepository : IRepository<RatePlan>
    {
        private readonly InventoryContext _inventoryContext;

        public RatePlansRepository(InventoryContext inventoryContext)
        {
            this._inventoryContext = inventoryContext;
        }
        public RatePlan Add(RatePlan entity)
        {
            _inventoryContext.RatePlans.Add(entity);
            return entity;
        }

        public IQueryable<RatePlan> All()
        {
            return _inventoryContext.RatePlans;
        }

        public int SaveChanges()
        {
            return _inventoryContext.SaveChanges();
        }
    }
}
