using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DailyQuestion
{
    public class Onebitand2bitCharacters
    {
        public bool IsLastCharacterOneBit(int[] bitSequence)
        {
            int index = 0;
            int length = bitSequence.Length;

            while(index < length - 1)
            {
                if(bitSequence[index] == 1)
                {
                    index += 2; 
                }

                else
                {
                    index += 1;
                }
            }

            return index == length - 1;
        }
    }
}