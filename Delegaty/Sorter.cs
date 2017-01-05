using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegaty
{
    class Sorter<T>
    {
        private List<ComplexNumber<T>> SortAscending(List<ComplexNumber<T>> complexNumberList)
        {
            bool warunek = true;
            while (warunek)
            {
                warunek = false;
                for (int i = 0; i < complexNumberList.Count - 1; i++)
                {
                    if (complexNumberList[i] > complexNumberList[i + 1])
                    {
                        var pom = complexNumberList[i];
                        complexNumberList[i] = complexNumberList[i + 1];
                        complexNumberList[i + 1] = pom;

                        if (!warunek)
                        {
                            warunek = true;
                        }
                    }
                }
            }

            return complexNumberList;
        }


        private List<ComplexNumber<T>> SortDescending(List<ComplexNumber<T>> complexNumberList)
        {
            bool warunek = true;
            while (warunek)
            {
                warunek = false;
                for (int i = 0; i < complexNumberList.Count - 1; i++)
                {
                    if (complexNumberList[i] < complexNumberList[i + 1])
                    {
                        var pom = complexNumberList[i];
                        complexNumberList[i] = complexNumberList[i + 1];
                        complexNumberList[i + 1] = pom;

                        if (!warunek)
                        {
                            warunek = true;
                        }
                    }
                }
            }

            return complexNumberList;
        }


        public List<ComplexNumber<T>> Sort(List<ComplexNumber<T>> list, bool isAscending)
        {
            if (isAscending)
            {
                list = SortAscending(list);
            }
            else
            {
                list = SortDescending(list);
            }

            return list;
        }


    }
}
