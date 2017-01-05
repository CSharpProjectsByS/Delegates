using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegaty
{
    class AdderComplexNumber<T>
    {
        private Random random = new Random();

        public List<ComplexNumber<T>> AddOneValue(List<ComplexNumber<T>> list,T realPart, T imaginePart)
        {
            
            ComplexNumber<T> cNumber = new ComplexNumber<T>(realPart, imaginePart);

            list.Add(cNumber);

            return list;
        }

        public List<ComplexNumber<T>> AddMoreValues(List<ComplexNumber<T>> list, int numberValues)
        {
            

            ComplexNumber<T> complexNumber;

            for ( int i = 0; i < numberValues; i++ )
            {
                complexNumber = CreateRandomComplexNumber();
                list.Add(complexNumber);    
            }

            return list;
        }

        private ComplexNumber<T> CreateRandomComplexNumber()
        {
            T realValue = randomNumber();
            T imagineValue = randomNumber();

            return new ComplexNumber<T>(realValue, imagineValue);               
        }

        private T randomNumber()
        {
            double number = random.Next(22) + 0;
            number += random.NextDouble();

            T numberT = (T) Convert.ChangeType(number, typeof(T));

            return numberT;
        }



    }
}
