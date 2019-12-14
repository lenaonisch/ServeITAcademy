﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_NumberToWords.Numbers
{
    public class MoreThanHundred : Dozen
    {
        private List<KeyValuePair<int, string>> _ranks = new List<KeyValuePair<int, string>>()
        {
            new KeyValuePair<int, string>( 1000000, " million" ),
            new KeyValuePair<int, string>( 1000, " thousand" ),
            new KeyValuePair<int, string>( 100, " hundred" )
        };

        protected override string GetWord(int number, int divider = 1000000)
        {    
            while(number >= _ranks.Last().Key)
            {
                if (number / divider > 0) // than get how many dividers are in number
                {
                    string dividersInNumber = this.GetWord(number / divider, divider) + _ranks.Find(t => t.Key == divider).Value;
                    if (dividersInNumber != "")
                    {
                        string tail = this.GetWord(number % divider);
                        if (tail != "")
                        {
                            return dividersInNumber + " " + tail;
                        }
                        else
                        {
                            return dividersInNumber;
                        }
                    }
                }
                else
                {
                    int rankIndex = _ranks.FindIndex(t => t.Key == divider) + 1;
                    if (rankIndex < _ranks.Count)
                    {
                        return this.GetWord(number, _ranks[rankIndex].Key);
                    }
                    
                }
            }

            return base.GetWord(number % divider);
        }
    }
}
