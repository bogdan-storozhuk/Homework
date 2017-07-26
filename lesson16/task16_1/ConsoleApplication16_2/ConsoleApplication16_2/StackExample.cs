using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16_2
{
    enum Operations
    {
        Push=1,
        Pop,
        Peek,
    }
    class StackExample<T>
    {
        T[] _arr=new T[10];
        private int _count;

        public StackExample()
        {
            _count = 0;
        }

        public void Push(T element)
        {
            if (_count == _arr.Length-1)
            {
                var tempArr = new T[_arr.Length + 10];
                var i = 0;
                for (; i< _count; i++)
                {
                    tempArr[i] = _arr[i];
                }
                tempArr[i] = element;
                _arr = tempArr;
            }
            else
            {
                _arr[_count] = element;
            }
            _count++;
        }

        public T Pop()
        {
            var temp = _arr[_count-1];
            _count--;
            return temp;

        }

        public T Peek()
        {
            return _arr[_count];
        }

        public void Print()
        {
            for (var i = 0; i < _count; i++)
            {
                Console.Write("{0},",_arr[i]);
            }
            Console.WriteLine();
        }
    }
}
