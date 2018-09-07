namespace Calculations
{
    public class FrequencyBand
    {
        public FrequencyBand(int lowerBand, int higherBand, int frequency)
        {
            LowerBand = lowerBand;
            HigherBand = higherBand;
            Frequency = frequency;
        }

        public int Frequency { get; }
        public int HigherBand { get; }
        public int LowerBand { get; }

        public override bool Equals(object other)
        {
            var result = false;
            if (other != null && other.GetType() == typeof(FrequencyBand)) {
                var that = (FrequencyBand)other;
                result =
                    LowerBand.Equals(that.LowerBand) &&
                    HigherBand.Equals(that.HigherBand) &&
                    Frequency.Equals(that.Frequency);
            }
            return result;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Frequency;
                hashCode = (hashCode * 397) ^ HigherBand;
                hashCode = (hashCode * 397) ^ LowerBand;
                return hashCode;
            }
        }
    }
}