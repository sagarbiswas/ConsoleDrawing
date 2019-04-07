using System;

namespace Common.Utility
{
    public static class CommonUtility
    {
        public static int TryParseValue(ParseType parseType, dynamic val, dynamic defaultValue)
        {
           
            switch (parseType)
            {
                case ParseType.IntType:
                    int parseDefaultIntValue = 25;
                    return int.TryParse(val, out parseDefaultIntValue) ? Convert.ToInt16(val): defaultValue;
                case ParseType.DoubleType:
                    double parseDefaultDoubleValue = 25.0;
                    return double.TryParse(val, out parseDefaultDoubleValue) ? Convert.ToDouble(val) : defaultValue;
                default:
                    return defaultValue;
            }
        }

        public static void SwapNumber(ref int x, ref int y)
        {
            x = x + y;  
            y = x - y; 
            x = x - y;
        }
    }

}


