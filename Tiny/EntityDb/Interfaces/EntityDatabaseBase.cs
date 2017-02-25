using System;
using System.Collections;
using System.Collections.Generic;

namespace Tiny.EntityDb
{
    public abstract class EntityDatabaseBase<T> : IEntityDatabase<T> where T : IEqualityComparer
    {
        public virtual int Add(T itemToAdd)
        {
            throw new NotImplementedException("inherit this class, bitch, can't instantiate");
        }


        public virtual void Commit()
        {
            throw new NotImplementedException("inherit this class, bitch, can't instantiate");
        }

        public virtual IEnumerable<T> FirstOrDefault(Func<T, bool> predicate)
        {
            throw new NotImplementedException("inherit this class, bitch, can't instantiate");
        }



        public virtual IEnumerable<T> GetAllElements()
        {
            throw new NotImplementedException("inherit this class, bitch, can't instantiate");
        }

    }
}
