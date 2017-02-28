using System.Collections;

namespace Tiny
{
    public class TestData : IEqualityComparer
    {
        public int Id;
        public string Name;

        bool IEqualityComparer.Equals(object x, object y)
        {
            var a = x as TestData;
            var b = y as TestData;
            return a.Id == b.Id && a.Name == b.Name;
        }

        public int GetHashCode(object obj)
        {
            unchecked
            {
                var s = obj as TestData;
                int hash = 45;
                hash = hash * 45 + s.Id.GetHashCode();
                hash = hash * 45 + s.Name.GetHashCode();

                return hash;
            }
        }
    }
}