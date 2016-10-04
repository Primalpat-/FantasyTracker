﻿namespace FantasyTracker.Logic.Extensions.Integers
{
    public static class OrdinalExtension
    {
        public static string ToOrdinal(this int number)
        {
            if (number <= 0)
                return number.ToString();

            if (number%100 == 11 || number%100 == 12 || number%100 == 13)
                return $"{number}th";

            switch (number%10)
            {
                case 1:
                    return $"{number}st";
                case 2:
                    return $"{number}nd";
                case 3:
                    return $"{number}rd";
                default:
                    return $"{number}th";
            }
        }
    }
}
