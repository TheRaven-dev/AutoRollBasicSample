using System;
using System.Linq;


namespace AutoRoll.Helpers
{
    public class ItemHelpers
    {
        //purse String, checking if string has a number in it. 
        public static float TryPurse( String input)
        {
            float results = 0;
            if(input.Any(c => char.IsDigit(c)))
            {
                results = float.Parse(input);
            }
            return results;
        }
    }
}
