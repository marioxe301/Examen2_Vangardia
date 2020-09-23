using Hotel.Rates.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Data.Repositories
{
    public class NightlyRatePlansRepository : IRepository<NightlyRatePlan>
    {
        private readonly InventoryContext _inventoryContext;

        public NightlyRatePlansRepository(InventoryContext inventoryContext)
        {
            this._inventoryContext = inventoryContext;
        }
        public NightlyRatePlan Add(NightlyRatePlan entity)
        {
            _inventoryContext.NightlyRatePlans.Add(entity);
            return entity;
        }

        public IQueryable<NightlyRatePlan> All()
        {
            return _inventoryContext.NightlyRatePlans;
        }

        public int SaveChanges()
        {
            return _inventoryContext.SaveChanges();
        }
    }
}
