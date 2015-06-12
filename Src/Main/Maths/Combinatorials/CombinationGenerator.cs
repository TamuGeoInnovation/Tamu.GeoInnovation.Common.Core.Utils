using System;
using System.Collections;

namespace USC.GISResearchLab.Common.Core.Maths.Combinatorials
{
    public class CombinationGenerator
    {

        public static ArrayList GetMultiSetCombinations(int n, string[][] sets, string[] combination, ArrayList combinations)
        {
            if (n == sets.Length)
            {
                // copy the final combination to a new string array so it is'nt overwritten in subsequent recursive calls
                // could possibly get around this with byref function param

                string[] newCombination = new string[sets.Length];
                Array.Copy(combination, newCombination, sets.Length);
                combinations.Add(newCombination);
            }
            else
            {
                string[] setValues = sets[n];
                foreach (string setValue in setValues)
                {
                    combination[n] = setValue;
                    GetMultiSetCombinations(n + 1, sets, combination, combinations);
                }
            }
            return combinations;
        }
    }
}
