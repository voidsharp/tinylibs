namespace Tiny.EntityDb
{
    public interface IEntityDatabase<in T> where T : struct
    {
        int Add(T itemToAdd);
        bool Remove(T elementToremove);
        int Count { get; }
        void Commit();

    }
}