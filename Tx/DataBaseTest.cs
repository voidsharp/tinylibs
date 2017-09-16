using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;
using Tiny;
using Tiny.EntityDb;



namespace Tx
{


    [TestClass]
    public class DataBaseTest
    {


        [TestMethod]
        public void TestCommit()
        {
            var st1 = new MemoryStream();
            //var st1 = new FileStream("D:\\data.txt", FileMode.OpenOrCreate);
            var ds1 = new DataStream(st1);
            //Encoding.UTF8.GetBytes(FileData.DatabaseFileContent)
            var db1 = new JsonEntityDatabase<TestData>(ds1);
            db1.GetInitialData();

            var s = db1.Count;

            db1.Add(new TestData { Id = 0, Name = "zuzuz0" });
            db1.Add(new TestData { Id = 1, Name = "zuzuz1" });
            db1.Add(new TestData { Id = 2, Name = "zuzuz2" });
            db1.Add(new TestData { Id = 3, Name = "zuzuz3" });

            var n = db1.FirstOrDefault(a => a.Id == 1);
            Assert.IsTrue(n == db1.ElementAt(1));

            db1.Commit();

            //var ms2 = new MemoryStream();
            //var ds2 = new DataStream(ms2);
            //var streamProvider2 = new DataStreamProvider(ds1);
            //var db2 = new JsonEntityDatabase<TestData>(streamProvider2.DataStream);

            //Assert.IsTrue(db2.ElementAt(0) == db1.ElementAt(0));



        }

        [TestMethod]
        public void TestReadingData()
        {
            //var mStream = new MemoryStream(Encoding.UTF8.GetBytes(FileData.DatabaseFileContent.ToString()));
            var mStream = new FileStream("D:\\data.txt", FileMode.OpenOrCreate);
            var ds1 = new DataStream(mStream);
            var dsp1 = new DataStreamProvider(ds1);

            var db = new JsonEntityDatabase<TestData>(dsp1.DataStream);

            var objToTest = new TestData { Id = 0, Name = "zuzuz0" };
            var readedObject = db.ElementAt(0);

            Assert.IsTrue(objToTest == readedObject);


        }

        //[TestMethod]
        //public void TestReadFromMemoryStream()
        //{
        //    var mStream = new MemoryStream(Encoding.UTF8.GetBytes(FileData.DatabaseFileContent));


        //    var database = new JsonEntityDatabase<TestData>(mStream);
        //    var collection = database.GetAllElements().ToList();

        //    var objToTest = new TestData { Id = 0, Name = "zuzuz0" };


        //    foreach (var testData in database)
        //    {
        //        MessageBox.Show(testData.Name);
        //    }

        //    Assert.IsTrue(objToTest == collection.FirstOrDefault());

        //}

        [TestMethod]
        public void AssertThatTwoIdenticalObjectAreEquals()
        {

            var objToTest = new TestData { Id = 0, Name = "zuzuz0" };
            var objToTest2 = new TestData { Id = 0, Name = "zuzuz0" };

            Assert.IsTrue(objToTest == objToTest2);
        }






    }
}
