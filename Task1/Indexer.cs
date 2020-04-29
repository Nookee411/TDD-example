using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Indexer
    {
        private double[] array;
        private int startIndex;
        private int length;

        /// <summary>
        /// Constructor for 3 arguments. Checks if needed set contains in array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="startIndex"></param>
        /// <param name="length"></param>
        public Indexer(double[] array, int startIndex, int length)
        {
            if (length < 0 || startIndex < 0 || startIndex + length > array.Length)
                throw new ArgumentException();
            else
            {
                this.array = array;
                this.startIndex = startIndex;
                this.length = length;
            }
        }


        /// <summary>
        /// Returns length of set
        /// </summary>
        public int Length
        {
            get => length;
        }

        /// <summary>
        /// Returns starting index of the set
        /// </summary>
        public int StartIndex
        {
            get => startIndex;
        }

        /// <summary>
        /// Returns or sets value at needed index in set
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public double this[int index]
        {
            get
            {
                if (IndexCheck(index))
                    return array[index + startIndex];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (IndexCheck(index))
                    array[index + startIndex] = value;
                else
                    throw new IndexOutOfRangeException();
            }
        
        }

        private bool IndexCheck(int index)
        {
            if (index >= 0 || index >= length || index + startIndex >= array.Length)
                return true;
            else 
                return false;

        }
    }
}
