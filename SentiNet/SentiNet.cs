using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace SentiNet
{
    public class SentiNet
    {
        private Dictionary<string, SentiSynSet> _sentiSynSetList;

        /**
         * <summary>Accessor for a single SentiNet.SentiSynSet.</summary>
         * <param name="id">Id of the searched SentiNet.SentiSynSet.</param>
         * <returns>SentiNet.SentiSynSet with the given id.</returns>
         */
        public SentiSynSet GetSentiSynSet(string id)
        {
            return _sentiSynSetList[id];
        }

        /// <summary>
        /// Reads the Xml file that contains names of sentiSynSets and their positive, negative scores.
        /// </summary>
        /// <param name="stream">Xml document that contains the SentiNet.</param>
        private void LoadSentiNet(Stream stream)
        {
            String id = "";
            double positiveScore = 0.0, negativeScore = 0.0;
            XmlDocument doc = new XmlDocument();
            doc.Load(stream);
            _sentiSynSetList = new Dictionary<string, SentiSynSet>();
            foreach (XmlNode sentiSynSetNode in doc.DocumentElement.ChildNodes)
            {
                foreach (XmlNode partNode in sentiSynSetNode.ChildNodes)
                {
                    switch (partNode.Name)
                    {
                        case "ID":
                            id = partNode.InnerText;
                            break;
                        case "PSCORE":
                            positiveScore = Convert.ToDouble(partNode.InnerText);
                            break;
                        case "NSCORE":
                            negativeScore = Convert.ToDouble(partNode.InnerText);
                            break;
                    }
                }

                if (id.Length != 0)
                {
                    _sentiSynSetList.Add(id, new SentiSynSet(id, positiveScore, negativeScore));
                }

                id = "";
                positiveScore = 0.0;
                negativeScore = 0.0;
            }
        }

        /**
         * <summary>Constructor of Turkish SentiNet.SentiNet. Reads the turkish_sentinet.xml file from the resources directory. For each
         * sentiSynSet read, it adds it to the sentiSynSetList.</summary>
         */
        public SentiNet()
        {
            var assembly = typeof(SentiNet).Assembly;
            var stream = assembly.GetManifestResourceStream("SentiNet.turkish_sentinet.xml");
            LoadSentiNet(stream);
        }

        /// <summary>
        /// Constructor for the SentiLiteralNet class with the given domain SentiNet Xml document.
        /// </summary>
        /// <param name="fileName">File that contains domain SentiNet</param>
        public SentiNet(string fileName)
        {
            LoadSentiNet(File.OpenRead(fileName));
        }

        /**
         * <summary>Adds specified SentiNet.SentiSynSet to the SentiNet.SentiSynSet list.</summary>
         *
         * <param name="sentiSynSet">SentiNet.SentiSynSet to be added</param>
         */
        public void AddSentiSynSet(SentiSynSet sentiSynSet)
        {
            _sentiSynSetList.Add(sentiSynSet.GetId(), sentiSynSet);
        }

        /**
         * <summary>Removes specified SentiNet.SentiSynSet from the SentiNet.SentiSynSet list.</summary>
         *
         * <param name="sentiSynSet">SentiNet.SentiSynSet to be removed</param>
         */
        public void RemoveSynSet(SentiSynSet sentiSynSet)
        {
            _sentiSynSetList.Remove(sentiSynSet.GetId());
        }

        /**
         * <summary>Constructs and returns an {@link ArrayList} of ids, which are the ids of the {@link SentiSynSet}s having polarity
         * polarityType.</summary>
         * <param name="polarityType">PolarityTypes of the searched {@link SentiSynSet}s</param>
         * <returns>An {@link ArrayList} of id having polarityType polarityType.</returns>
         */
        private List<string> GetPolarity(PolarityType polarityType)
        {
            var result = new List<string>();
            foreach (var sentiSynSet in _sentiSynSetList.Values)
            {
                if (sentiSynSet.GetPolarity() == polarityType)
                {
                    result.Add(sentiSynSet.GetId());
                }
            }

            return result;
        }

        /**
         * <summary>Returns the ids of all positive {@link SentiSynSet}s.</summary>
         * <returns>An ArrayList of ids of all positive {@link SentiSynSet}s.</returns>
         */
        public List<string> GetPositives()
        {
            return GetPolarity(PolarityType.POSITIVE);
        }

        /**
         * <summary>Returns the ids of all negative {@link SentiSynSet}s.</summary>
         * <returns>An ArrayList of ids of all negative {@link SentiSynSet}s.</returns>
         */
        public List<string> GetNegatives()
        {
            return GetPolarity(PolarityType.NEGATIVE);
        }

        /**
         * <summary>Returns the ids of all neutral {@link SentiSynSet}s.</summary>
         * <returns>An ArrayList of ids of all neutral {@link SentiSynSet}s.</returns>
         */
        public List<string> GetNeutrals()
        {
            return GetPolarity(PolarityType.NEUTRAL);
        }

        /**
         * <summary>Method to write SynSets to the specified file in the XML format.</summary>
         *
         * <param name="fileName">file name to write XML files</param>
         */
        public void SaveAsXml(string fileName)
        {
            var outfile = new StreamWriter(fileName);
            outfile.WriteLine("<SYNSETS>");
            foreach (var synSet in _sentiSynSetList.Values)
            {
                synSet.SaveAsXml(outfile);
            }

            outfile.WriteLine("</SYNSETS>");
            outfile.Close();
        }
    }
}