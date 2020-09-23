
using Hotel.Rates.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Data.Repositories
{
    public class SeasonsRepository : IRepository<Season>
    {
        private readonly InventoryContext _inventoryContext;

        public SeasonsRepository(InventoryContext inventoryContext)
        {
            this._inventoryContext = inventoryContext;
        }
        public Season Add(Season entity)
        {
            _inventoryContext.Seasons.Add(entity);
            return entity;
        }

        public IQueryable<Season> All()
        {
           return _inventoryContext.Seasons;
        }

        public int SaveChanges()
        {
            return _inventoryContext.SaveChanges();
        }
    }
}
