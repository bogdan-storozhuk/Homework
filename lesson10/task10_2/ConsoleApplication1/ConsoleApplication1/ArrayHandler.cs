using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum Operations
    {
        Add=1,
        Contains,
        GetByIndex,
    }
    class ArrayHandler
    {
        private int[] _insideArray;
        private int count;

        public ArrayHandler()
        {
            _insideArray = new int[10];
            count = 0;
        }

        public ArrayHandler(int count)
        {
            _insideArray = new int[count];
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public int this[int index]
        {
            get { return _insideArray[index]; }
           
        }
        public void Add(int newElem)
        {
            if (_insideArray.Length <= count)
            {
                var tempArray = new int[_insideArray.Length + 10];

                int i = 0;
                for (; i < _insideArray.Length; i++)
                {
                    tempArray[i] = _insideArray[i];
                }

                tempArray[i] = newElem;

                _insideArray = tempArray;
            }
            else
            {
                _insideArray[count] = newElem;
            }

            count++;
        }

        public bool Contains(int value)
        {
            return _insideArray.Contains(value);
        }

        public bool CheckIfExist(int index)
        {
            if (index < _insideArray.Length)
            {
                return true;
            }
            Console.WriteLine("Element doesn't exist");
            return false;
        }
        public void GetByIndex(int index)
        {
            if (CheckIfExist(index))
            {
                Console.WriteLine(_insideArray[index]);
            }
        }
    }
}
