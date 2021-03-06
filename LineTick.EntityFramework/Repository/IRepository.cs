﻿using LineTick.EntityFramework.Entityes;
using System.Linq;

namespace LineTick.EntityFramework
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        IQueryable<TEntity> All { get; }
        TEntity GetItem(int id);
        TEntity Save(TEntity item);
        void Delete(TEntity item);
        void Delete(int id);
    }
}