using System;
using NUnit.Framework;
using Task1;

namespace TestProject1
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void TestCorrectInput()
        {
            long a_initial, a, b_initial, b;

            a_initial = a = 100;
            b_initial = b = 200;

            Task1.Program.Swap(ref a, ref b);
            
            Assert.AreEqual(b_initial, a, 0.001, "Swap did not occur for a");
            Assert.AreEqual(a_initial, b, 0.001, "Swap did not occur for b");
        }
    }
}