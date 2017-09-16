using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Tiny.EntityDb
{


    public class JsonEntityDatabase<T> : BaseEntityDatabase<T> where T : struct
    {
        bool disposed;
        bool isDbFileInitialised;
        private bool isChanged;

        public JsonEntityDatabase(IDataStream dataStream) : base(dataStream)
        {

        }

        public override int Add(T elementToAdd)
        {
            isChanged = true;
            return base.Add(elementToAdd);
        }

        public override void GetInitialData()
        {
            elements = ReadRecordsFromDatabase();
        }

        private IList<T> ReadRecordsFromDatabase()
        {
            dataStream.Position = 0;
            var streamReader = new StreamReader(dataStream, Encoding.UTF8);
            var serializedData = streamReader.ReadToEnd();
            var result = new List<T>();
            var r = JsonConvert.DeserializeObject<List<T>>(serializedData);
            if (r != null)
                result = r;
            return result;
        }

        private void SerializeAndSaveCollection(IEnumerable<T> listToSave)
        {
            //CheckForInit();
            dataStream.Seek(0, SeekOrigin.Begin);

            var sw = new StreamWriter(dataStream, Encoding.UTF8);
            var serializedData = new StringBuilder();

            serializedData.Append(JsonConvert.SerializeObject(elements));
            sw.Write(serializedData.ToString());
            sw.Flush();
        }



        public int Count => elements.Count();




        public override void Commit()
        {
            base.Commit();

            if (!isChanged) return;
            SerializeAndSaveCollection(elements);
            isChanged = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                Commit();
                // Free any other managed objects here.
                //
            }

            // Free any unmanaged objects here.
            //
            disposed = true;
        }




        ~JsonEntityDatabase()
        {

        }
    }

    #region Exceptions

    public class DataBaseInitException : Exception
    {
        public DataBaseInitException()
        {
        }

        public DataBaseInitException(string message) : base(message)
        {
        }

        public DataBaseInitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DataBaseInitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }

    #endregion


}
