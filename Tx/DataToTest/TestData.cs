namespace Tiny
{
    public struct TestData
    {
        public int Id;
        public string Name;


        //public override bool Equals(object obj)
        //{
        //    if (ReferenceEquals(null, obj)) return false;
        //    return obj is TestData && Equals((TestData)obj);
        //}




        public static bool operator ==(TestData c1, TestData c2)
        {
            return c1.Equals(c2);
        }

        public static bool operator !=(TestData c1, TestData c2)
        {
            return !c1.Equals(c2);
        }

    }

    public class FileData
    {
        public static string DatabaseFileContent =
"[{\"Id\":0,\"Name\":\"zuzuz0\"},{\"Id\":1,\"Name\":\"zuzuz1\"},{\"Id\":2,\"Name\":\"zuzuz2\"},{\"Id\":3,\"Name\":\"zuzuz3\"}]";



    }
}