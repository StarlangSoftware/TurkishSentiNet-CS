using NUnit.Framework;

namespace Test
{
    public class SentiNetTest
    {
        private global::SentiNet.SentiNet sentiNet;
        
        [SetUp]
        public void Setup()
        {
            sentiNet = new global::SentiNet.SentiNet();
        }

        [Test]
        public void GetPositives()
        {
            Assert.AreEqual(3100, sentiNet.GetPositives().Count);
        }
        
        [Test]
        public void GetNegatives()
        {
            Assert.AreEqual(10191, sentiNet.GetNegatives().Count);
        }

        [Test]
        public void GetNeutral()
        {
            Assert.AreEqual(63534, sentiNet.GetNeutrals().Count);
        }

    }
}