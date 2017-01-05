using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty
{
    class ComplexNumber<T>
    {
        public T realPart { get; set; }
        public T imaginePart { get; set; }

        public ComplexNumber(T realValue, T imagineValue)
        {
            realPart = realValue;
            imaginePart = imagineValue;
        }

        public static bool operator > (ComplexNumber<T> number1, ComplexNumber<T> number2) 
        {
            bool isGreater = false;

            if (IsGreaterThan(number1.realPart, number2.realPart))
            {
                isGreater = true;
            }
            else 
                if (IsEqualsTo(number1.realPart, number2.realPart) && 
                    IsGreaterThan(number1.imaginePart, number2.imaginePart))
            {
                isGreater = true;
            }

            return isGreater;
        }

        public static bool operator < (ComplexNumber<T> number1, ComplexNumber<T> number2)
        {
            bool isSmaller = false;

            if (IsSmallerThan(number1.realPart, number2.realPart))
            {
                isSmaller = true;
            }
            else
                if (IsEqualsTo(number1.realPart, number2.realPart) &&
                    IsSmallerThan(number1.imaginePart, number2.imaginePart))
            {
                isSmaller = true;
            }

            return isSmaller;
        }


        private static bool IsGreaterThan(T part1, T part2) 
        {
            return System.Collections.Generic.Comparer<T>.Default.Compare(part1, part2) > 0;
        }

        private static bool IsSmallerThan(T part1, T part2) 
        {
            return System.Collections.Generic.Comparer<T>.Default.Compare(part1, part2) < 0;
        }

        private static bool IsEqualsTo(T part1, T part2)
        {
            return System.Collections.Generic.Comparer<T>.Default.Compare(part1, part2) == 0;
        }

        public override string ToString()
        {
            return realPart + " + j" + imaginePart;
        }
    }
}
