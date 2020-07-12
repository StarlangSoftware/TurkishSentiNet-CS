using System.IO;

namespace SentiNet
{
    public class SentiSynSet
    {
        private readonly string _id;
        private readonly double _positiveScore;
        private readonly double _negativeScore;

        /**
         * <summary>Constructor of SentiNet.SentiSynSet. Gets input id, positiveScore, negativeScore and sets all corresponding attributes.</summary>
         * <param name="id">Id of the SentiNet.SentiSynSet.</param>
         * <param name="positiveScore">Positive score of the SentiNet.SentiSynSet.</param>
         * <param name="negativeScore">Negative score of the SentiNet.SentiSynSet.</param>
         */
        public SentiSynSet(string id, double positiveScore, double negativeScore) {
            _id = id;
            _positiveScore = positiveScore;
            _negativeScore = negativeScore;
        }

        /**
         * <summary>Accessor for the positiveScore attribute.</summary>
         * <returns>PositiveScore of the SentiNet.SentiSynSet.</returns>
         */
        public double GetPositiveScore() {
            return _positiveScore;
        }

        /**
         * <summary>Accessor for the negativeScore attribute.</summary>
         * <returns>NegativeScore of the SentiNet.SentiSynSet.</returns>
         */
        public double GetNegativeScore() {
            return _negativeScore;
        }

        /**
         * <summary>Returns the polarityType of the sentiSynSet. If the positive score is larger than the negative score, the polarity is
         * positive; if the negative score is larger than the positive score, the polarity is negative; if both positive
         * score and negative score are equal, the polarity is neutral.</summary>
         * <returns>SentiNet.PolarityType of the sentiSynSet.</returns>
         */
        public PolarityType GetPolarity()
        {
            if (_positiveScore > _negativeScore){
                return PolarityType.POSITIVE;
            }

            if (_positiveScore < _negativeScore){
                return PolarityType.NEGATIVE;
            }

            return PolarityType.NEUTRAL;
        }

        /**
         * <summary>Accessor for the id attribute.</summary>
         * <returns>Id of the SentiNet.SentiSynSet.</returns>
         */
        public string GetId(){
            return _id;
        }

        /**
         * <summary>Method to write SynSets to the specified file in the XML format.</summary>
         *
         * <param name="outfile">BufferedWriter to write XML files</param>
         */
        public void SaveAsXml(StreamWriter outfile) {
            outfile.Write("<SYNSET>");
            outfile.Write("<ID>" + _id + "</ID>");
            outfile.Write("<PSCORE>" + _positiveScore + "</PSCORE>");
            outfile.Write("<NSCORE>" + _negativeScore + "</NSCORE>");
            outfile.Write("</SYNSET>\n");
        }

    }
}