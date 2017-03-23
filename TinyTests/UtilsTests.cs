using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tiny;

namespace TinyTests
{
    [TestClass]
    public class UtilsTests
    {
        private const uint PrecalculatedCrc32Valuefor0X00110011 = 0x561036A9;

        [TestMethod]
        public void Crc32()
        {
            var crccalc = new Crc32();
            var calculatedvalue = crccalc.ComputeChecksum(BitConverter.GetBytes(0x00110011));

            Assert.IsTrue(calculatedvalue == PrecalculatedCrc32Valuefor0X00110011);

            var precalculatedvalueasarray = BitConverter.GetBytes(PrecalculatedCrc32Valuefor0X00110011);
            var calculatedvalueasbytearray = crccalc.ComputeChecksumBytes(BitConverter.GetBytes(0x00110011));

            Assert.IsTrue(precalculatedvalueasarray == calculatedvalueasbytearray);

        }
    }
}
