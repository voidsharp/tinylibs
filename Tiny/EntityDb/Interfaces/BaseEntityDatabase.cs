using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Tiny.EntityDb
{
    public abstract class BaseEntityDatabase<T> : IEnumerable<T>, IDisposable, IEntityDatabase<T> where T : struct
    {
        #region Fields
        protected Stream dataStream;
        protected IList<T> elements;
        #endregion

        #region Properties

        public int Count => elements.Count;

        #endregion

        public virtual void Commit()
        {
            InitIfNeeded();
        }

        protected BaseEntityDatabase(IDataStream dataStream)
        {
            this.dataStream = dataStream.GetStream;
        }

        public IEnumerator<T> GetEnumerator()
        {
            InitIfNeeded();
            return elements.GetEnumerator();
        }


        /// <summary>
        /// This method must be realised in inherited classes and must set internal 
        /// field <see cref="elements"/> to initialised (non-null) state.
        /// </summary>
        protected abstract void GetInitialData();

        public virtual int Add(T elementToAdd)
        {
            InitIfNeeded();
            elements.Add(elementToAdd);
            return Count;
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            InitIfNeeded();
            return elements.GetEnumerator();
        }

        public bool Remove(T itemToRemove)
        {
            InitIfNeeded();
            return elements.Remove(itemToRemove);
        }

        private void InitIfNeeded()
        {
            if (elements == null)
                GetInitialData();
        }

        public void Dispose()
        {
            if (elements != null)
                Commit();
        }
    }
}
