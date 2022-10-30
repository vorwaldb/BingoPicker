using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingoNumberPicker
{
    class BingoNumber
    {
        //public string BingoNumber;

        static public string CreateBingoNumber(int number)
        {
            string bingoNum;
            string numString = number.ToString();

            if (number < 16)
            {
                if (number < 10)
                {
                    numString = "0" + number.ToString();
                }

                bingoNum = "B" + numString;
            }
            else if (number < 31)
            {
                bingoNum = "I" + numString;
            }
            else if (number < 46)
            {
                bingoNum = "N" + numString;
            }
            else if (number < 61)
            {
                bingoNum = "G" + numString;
            }
            else
            {
                bingoNum = "O" + numString;
            }

            return bingoNum;
        }

    }
}
