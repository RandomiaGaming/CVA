using System;
namespace CVA.Core
{
    public struct Range
    {
        public double min;
        public double max;
        public Range(double min, double max)
        {
            if(max < min)
            {
                throw new Exception("Minimum must be smaller than maximum.");
            }
            this.min = min;
            this.max = max;
        }
        public bool Incapsulates(double value)
        {
            return value >= min && value <= max;
        }
        public bool Incapsulates(Range range)
        {
            return Incapsulates(range.min) && Incapsulates(range.max);
        }
        public bool Overlaps(Range range)
        {
            return min <= range.max && max >= range.min;
        }
    }
}
