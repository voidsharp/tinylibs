using System;
using System.Collections;
using System.Collections.Generic;

namespace Tiny.EntityDb
{
    public interface IEntityDatabase<T> where T : IEqualityComparer
    {
        IEnumerable<T> GetAllElements();
        int Add(T itemToAdd);
        void Commit();
        IEnumerable<T> FirstOrDefault(Func<T, bool> predicate);
    }
}