using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wakalni.database;
using wakalni.Entities;
using wakalni.services.Interfaces;

namespace wakalni.services
{
    public class ItemService : ITransientService
    {
        private DataBaseContext _context;

        public ItemService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<Item> GetItem(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task<ICollection<Item>> GetItems(int page, int pageSize)
        {
            return await _context.Items.Skip(page * pageSize)
                .Take(pageSize).ToListAsync();
        }

        public async Task<int> Create(Item item)
        {
            _context.Items.Add(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<int> AddType(Item item, ItemType itemType)
        {
            item.ItemTypes.Add(new Item_ItemType { Item = item, ItemType = itemType });
            return await Update(item);
        }

        public async Task<int> Delete(Item item)
        {
            _context.Items.Remove(item);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> Delete(int itemId)
        {
            Item item = await _context.Items.FindAsync(itemId);
            if (item == null)
            {
                throw new ArgumentException($"item with id {itemId} not found");
            }
            return await Delete(item);
        }

        public bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.Id == id);
        }
    }
}
