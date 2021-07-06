using NUnit.Framework;

namespace Test
{
    public class SentiLiteralNetTest
    {
        private global::SentiNet.SentiLiteralNet sentiNet;
        
        [SetUp]
        public void Setup()
        {
            sentiNet = new global::SentiNet.SentiLiteralNet();
        }

        [Test]
        public void GetPositives()
        {
            Assert.AreEqual(4335, sentiNet.GetPositives().Count);
        }
        
        [Test]
        public void GetNegatives()
        {
            Assert.AreEqual(13011, sentiNet.GetNegatives().Count);
        }

        [Test]
        public void GetNeutral()
        {
            Assert.AreEqual(62379, sentiNet.GetNeutrals().Count);
        }
    }
}