﻿namespace JixhDb.Data.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using Models.EntittyModels;

    public interface IRepository<T>
    {

        IEnumerable<T> Entities { get; }

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        T FirstOrDefault();

        T FirstOrDefault(Expression<Func<T, bool>> expression);

        IEnumerable<T> Where(Expression<Func<T, bool>> expression);

        bool Any(Expression<Func<T, bool>> expression);

        bool Contains(Expression<Func<T, bool>> expression);

        T Find(object id);

        int Count();

        int Count(Expression<Func<T, bool>> expression);

        void Remove(T entity);

        void Remove(int id);

        void RemoveRange(IEnumerable<T> entities);

    }
}
