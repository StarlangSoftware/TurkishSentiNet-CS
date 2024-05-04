using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SentiNet
{
    public class SentiLiteralNet
    {
        private Dictionary<string, SentiLiteral> _sentiLiteralList;

        /**
         * <summary>Accessor for a single SentiLiteral.</summary>
         * <param name="name">Id of the searched SentiLiteral.</param>
         * <returns>SentiLiteral with the given name.</returns>
         */
        public SentiLiteral GetSentiSynSet(string name)
        {
            return _sentiLiteralList[name];
        }

        /// <summary>
        /// Reads the Xml file that contains names of sentiSynSets and their positive, negative scores.
        /// </summary>
        /// <param name="stream">Xml document that contains the SentiNet.</param>
        private void LoadSentiNet(Stream stream)
        {
            String name = "";
            double positiveScore = 0.0, negativeScore = 0.0;
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            _sentiLiteralList = new Dictionary<string, SentiLiteral>();
            foreach (XmlNode sentiLiteralNode in doc.DocumentElement.ChildNodes)
            {
                foreach (XmlNode partNode in sentiLiteralNode.ChildNodes)
                {
                    switch (partNode.Name)
                    {
                        case "NAME":
                            name = partNode.InnerText;
                            break;
                        case "PSCORE":
                            positiveScore = Convert.ToDouble(partNode.InnerText);
                            break;
                        case "NSCORE":
                            negativeScore = Convert.ToDouble(partNode.InnerText);
                            break;
                    }
                }

                if (name.Length != 0)
                {
                    _sentiLiteralList.Add(name, new SentiLiteral(name, positiveScore, negativeScore));
                }

                name = "";
                positiveScore = 0.0;
                negativeScore = 0.0;
            }
        }

        /**
         * <summary>Constructor of Turkish SentiLiteralNet. Reads the turkish_sentiliteralnet.xml file from the resources directory. For each
         * sentiSynSet read, it adds it to the sentiSynSetList.</summary>
         */
        public SentiLiteralNet()
        {
            var assembly = typeof(SentiNet).Assembly;
            var stream = assembly.GetManifestResourceStream("SentiNet.turkish_sentiliteralnet.xml");
            LoadSentiNet(stream);
        }

        /// <summary>
        /// Constructor for the SentiLiteralNet class with the given domain SentiLiteralNet Xml document.
        /// </summary>
        /// <param name="fileName">File that contains domain SentiLiteralNet</param>
        public SentiLiteralNet(string fileName)
        {
            LoadSentiNet(File.OpenRead(fileName));
        }

        /**
         * <summary>Constructs and returns an {@link ArrayList} of ids, which are the ids of the {@link SentiLiteral}s having polarity
         * polarityType.</summary>
         * <param name="polarityType">PolarityTypes of the searched {@link SentiLiteral}s</param>
         * <returns>An {@link ArrayList} of id having polarityType polarityType.</returns>
         */
        private List<string> GetPolarity(PolarityType polarityType)
        {
            var result = new List<string>();
            foreach (var sentiLiteral in _sentiLiteralList.Values)
            {
                if (sentiLiteral.GetPolarity() == polarityType)
                {
                    result.Add(sentiLiteral.GetName());
                }
            }

            return result;
        }

        /**
         * <summary>Returns the ids of all positive {@link SentiLiteral}s.</summary>
         * <returns>An ArrayList of ids of all positive {@link SentiLiteral}s.</returns>
         */
        public List<string> GetPositives()
        {
            return GetPolarity(PolarityType.POSITIVE);
        }

        /**
         * <summary>Returns the ids of all negative {@link SentiLiteral}s.</summary>
         * <returns>An ArrayList of ids of all negative {@link SentiLiteral}s.</returns>
         */
        public List<string> GetNegatives()
        {
            return GetPolarity(PolarityType.NEGATIVE);
        }

        /**
         * <summary>Returns the ids of all neutral {@link SentiLiteral}s.</summary>
         * <returns>An ArrayList of ids of all neutral {@link SentiLiteral}s.</returns>
         */
        public List<string> GetNeutrals()
        {
            return GetPolarity(PolarityType.NEUTRAL);
        }

    }
}