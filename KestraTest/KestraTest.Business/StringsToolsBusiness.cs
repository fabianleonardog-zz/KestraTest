using KestraTest.Contracts.Business;
using System;
using System.Collections.Generic;
using System.Text;

namespace KestraTest.Business
{
    public class StringsToolsBusiness : IStringsToolsBusiness
    {
        public string MergeStrings(string a, string b)
        {
            string result = string.Empty;
            char[] arrayA = a.ToCharArray();
            char[] arrayB = b.ToCharArray();

            if(arrayA.Length >= arrayB.Length)
            {
                for(int i = 0; i <= arrayA.Length -1; i++)
                {
                    result += arrayA[i];
                    if (i < arrayB.Length)
                        result += arrayB[i];
                }
            }
            else
            {
                for (int i = 0; i <= arrayB.Length - 1; i++)
                {
                    if (i < arrayA.Length)
                        result += arrayA[i];
                    result += arrayB[i];
                }
            }

            return result;
        }
    }
}
