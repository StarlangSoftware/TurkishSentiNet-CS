using System.IO;
using NUnit.Framework;

namespace Test
{
    public class SentiSynSetTest
    {
        private global::SentiNet.SentiNet sentiNet;
        
        [SetUp]
        public void Setup()
        {
            sentiNet = new global::SentiNet.SentiNet();
        }

        [Test]
        public void SaveAsXml()
        {
            var outfile = new StreamWriter("test.xml");
            var sentiSynSet = sentiNet.GetSentiSynSet("TUR10-1093230");
            sentiSynSet.SaveAsXml(outfile);
            sentiSynSet = sentiNet.GetSentiSynSet("TUR10-0730690");
            sentiSynSet.SaveAsXml(outfile);
            sentiSynSet = sentiNet.GetSentiSynSet("TUR10-0969360");
            sentiSynSet.SaveAsXml(outfile);
            outfile.Close();
            var input = new StreamReader("test.xml");
            var line = input.ReadLine();
            Assert.AreEqual("<SYNSET><ID>TUR10-1093230</ID><PSCORE>0.25</PSCORE><NSCORE>0</NSCORE></SYNSET>", line);
            line = input.ReadLine();
            Assert.AreEqual("<SYNSET><ID>TUR10-0730690</ID><PSCORE>0</PSCORE><NSCORE>0</NSCORE></SYNSET>", line);
            line = input.ReadLine();
            Assert.AreEqual("<SYNSET><ID>TUR10-0969360</ID><PSCORE>0</PSCORE><NSCORE>1</NSCORE></SYNSET>", line);
        }

    }
}