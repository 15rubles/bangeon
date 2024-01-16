using System;
using Unity.VisualScripting;

namespace Tool
{
    public static class NumericTools
    {
        private const double TOLERANCE = 0.1f;
        public static bool Equals(this float a, float b)
        {
            return Math.Abs(a - b) < TOLERANCE;
        }
    }
}