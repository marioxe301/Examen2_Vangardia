using Hotel.Rates.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Data.Repositories
{
    public class RoomsRepository : IRepository<Room>
    {
        private readonly InventoryContext _inventoryContext;

        public RoomsRepository(InventoryContext inventoryContext)
        {
            this._inventoryContext = inventoryContext;
        }
        public Room Add(Room entity)
        {
            _inventoryContext.Rooms.Add(entity);
            return entity;
        }

        public IQueryable<Room> All()
        {
            return _inventoryContext.Rooms;
        }

        public int SaveChanges()
        {
            return _inventoryContext.SaveChanges();
        }
    }
}
