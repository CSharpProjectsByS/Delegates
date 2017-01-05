using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Delegaty
{
    class ComplexNumberListService<T>
    {
        AdderComplexNumber<T> adderCNumber;

        public delegate bool comparisonType(ComplexNumber<T> complexNumber1,
            ComplexNumber<T> complexNumber2);

        public delegate List<ComplexNumber<T>> sortAscendingD(List<ComplexNumber<T>> complexNumbers, 
            comparisonType porownaj);

        public comparisonType comparisonTypeD;
        public sortAscendingD sortAscendingDD;

        public Func<List<ComplexNumber<T>>, comparisonType, List<ComplexNumber<T>>>
                sortDescendingD;

        public ComplexNumberListService(AdderComplexNumber<T> adder)
        {
            adderCNumber = adder;

            comparisonTypeD = new comparisonType(compareComplexNumbers);
            sortAscendingDD = new sortAscendingD(sortAscending);
            sortDescendingD = sortDescending;
        }


        public List<ComplexNumber<T>> AddOneValue(List<ComplexNumber<T>> list, TextBox realPart, TextBox imaginePart)
        {
            T realPartValue = (T)Convert.ChangeType(realPart.Text, typeof(T));
            T imagineValue = (T)Convert.ChangeType(imaginePart.Text, typeof(T));

            list = adderCNumber.AddOneValue(list, realPartValue, imagineValue);

            return list;
        }

        public List<ComplexNumber<T>> AddMoreValue(List<ComplexNumber<T>> list, TextBox Number)
        {
            int numberOfComplexNumber = Int32.Parse(Number.Text);

            list = adderCNumber.AddMoreValues(list, numberOfComplexNumber);

            return list;
        }
        
        public bool compareComplexNumbers(ComplexNumber<T> complexNumber1,
            ComplexNumber<T> complexNumber2)
        {
            bool isFirstGreater = true;

            if (complexNumber1 < complexNumber2 || complexNumber1 == complexNumber2)
            {
                isFirstGreater = false;
            }

            return isFirstGreater;
        }


        public List<ComplexNumber<T>> sortAscending(List<ComplexNumber<T>> list,
            comparisonType porownaj)
        {
            bool warunek = true;
            ComplexNumber<T> pom;
            
            while (warunek)
            {
                warunek = false;
                for (int i = 0; i < list.Count - 1 ; i++)
                {
                    if (porownaj(list[i], list[i + 1]))
                    {
                        if (!warunek)
                        {
                            warunek = true;
                        }
                        pom = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = pom; 
                    }
                }
            }

            return list;  
        }


        public List<ComplexNumber<T>> sortDescending(List<ComplexNumber<T>> list,
            comparisonType porownaj)
        {
            bool warunek = true;
            ComplexNumber<T> pom;

            while (warunek)
            {
                warunek = false;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (!porownaj(list[i], list[i + 1]))
                    {
                        if (!warunek)
                        {
                            warunek = true;
                        }
                        pom = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = pom;
                    }
                }
            }

            return list;
        }



    }
}
