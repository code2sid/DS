using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSPractice
{
    public class BubbleSort
    {
        //o(n2)
        public int[] sort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        array[j] = array[j] + array[j + 1];
                        array[j + 1] = array[j] - array[j + 1];
                        array[j] = array[j] - array[j + 1];
                    }
                }
            }

            return array;
        }
    }

    public class InsertionSort
    {
        //o(n2)
        public int[] sort(int[] array)
        {
            int item, pos;
            for (int i = 1; i < array.Length; i++)
            {
                item = array[i];
                pos = i;
                while (pos > 0 && array[pos - 1] > item)
                {
                    array[pos] = array[pos - 1];
                    pos--;
                }

                if (pos != i)
                    array[pos] = item;
            }
            return array;
        }
    }

    public class SelectionSort
    {
        //o(n2)
        public int[] sort(int[] array)
        {
            int min = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                        min = j;
                }

                if (min != i)
                {
                    array[i] = array[i] + array[min];
                    array[min] = array[i] - array[min];
                    array[i] = array[i] - array[min];
                }
            }

            return array;
        }
    }
}
