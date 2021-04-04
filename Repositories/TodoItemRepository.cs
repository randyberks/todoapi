using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Database;

namespace TodoApi.Repositories
{
    public class TodoItemRepository : IRepository<TodoItem>
    {

        private readonly DBContext _context;

        public TodoItemRepository(DBContext context)
        {
            _context = context;
        }

        public IEnumerable<TodoItem> FindAll()
        {
            return _context.TodoItems.ToList();
        }

        public void Create(TodoItem item)
        {
            _context.TodoItems.Add(item);
            _context.SaveChanges();
        }

        public TodoItem FindById(long id)
        {
            return _context.TodoItems.Find(id);
        }

        public void Update(long id, TodoItem item)
        {
            _context.Entry(item).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException e)
            {
                if (ExistsById(item.ID))
                {
                    throw new Exception("Object has been modified elsewhere");
                }
                else
                {
                    throw;
                }
            }
            
        }

        public void DeleteById(long id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null)
            {
                throw new Exception("Item not found");
            }

            _context.TodoItems.Remove(item);
            _context.SaveChanges();
        }

        public bool ExistsById(long id)
        {
            return _context.TodoItems.Any(e => e.ID == id);
        }
    }
}