using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tiny.EntityDb
{
    public class JsonEntityDatabase<T> : EntityDatabaseBase<T> where T : class, IEqualityComparer
    {
        bool isChanged = false;
        private IList<T> elements = new List<T>();
        public override int Add(T itemToAdd)
        {
            elements.Add(itemToAdd);
            isChanged = true;
            return elements.Count;
        }

        public override IEnumerable<T> FirstOrDefault(Func<T, bool> predicate)
        {
            yield return elements.FirstOrDefault(predicate);
        }
    }
}
