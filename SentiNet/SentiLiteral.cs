namespace SentiNet
{
    public class SentiLiteral
    {
        private readonly string _name;
        private readonly double _positiveScore;
        private readonly double _negativeScore;

        /**
         * <summary>Constructor of SentiLiteral. Gets input name, positiveScore, negativeScore and sets all corresponding attributes.</summary>
         * <param name="name">Id of the SentiLiteral.</param>
         * <param name="positiveScore">Positive score of the SentiLiteral.</param>
         * <param name="negativeScore">Negative score of the SentiLiteral.</param>
         */
        public SentiLiteral(string name, double positiveScore, double negativeScore) {
            _name = name;
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
         * <summary>Returns the polarityType of the SentiLiteral. If the positive score is larger than the negative score, the polarity is
         * positive; if the negative score is larger than the positive score, the polarity is negative; if both positive
         * score and negative score are equal, the polarity is neutral.</summary>
         * <returns>SentiNet.PolarityType of the SentiLiteral.</returns>
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
         * <returns>Name of the SentiLiteral.</returns>
         */
        public string GetName(){
            return _name;
        }

    }
}