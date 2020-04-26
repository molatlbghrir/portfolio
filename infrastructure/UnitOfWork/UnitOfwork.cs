using Core.Interfaces;
using infrastructure.repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.UnitOfWork
{
    public class UnitOfwork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DataContext _context;
        private IGenericRepository<T> _entity;

        public IGenericRepository<T> entity => _entity ?? (_entity = new GenericRepository<T>(_context));

        public UnitOfwork(DataContext context)
        {
            _context = context;
        }
        
        

        

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
