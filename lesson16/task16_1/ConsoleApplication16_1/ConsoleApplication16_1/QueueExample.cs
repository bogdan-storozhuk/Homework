using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16_1
{
    enum Operations
    {
      Enqueue=1,
      Dequeue,
      Peek,
    }
    class QueueExample<T>
    {
        private T[] _arr=new T[10];
        private int _count;

        public QueueExample()
        {
            _count = 0;
            _arr = new T[10];
        }

        public QueueExample(int size)
        {
            _arr = new T[size];
            _count = 0;
        }


        public void Engueue(T element)
        {
                if (_arr.Length <=_count)
                {
                    var temparr = new T[_arr.Length + 10];
                    var i = 0;
                    for (; i < _arr.Length; i++)
                    {
                        temparr[i] = _arr[i];
                    }

                    temparr[i] = element;
                    _arr = temparr;
                }
                else
                {
                    _arr[_count] = element;
                }
                _count++;
        }

        public T Peek()
        {
            return _arr[0];
        }

        public T Dequeue()
        {
            var extractedElem = _arr[0];
            for (var i = 0; i < _count; i++)
            {
                _arr[i] = _arr[i + 1];
            }

            _count--;
            return extractedElem;
        }

        public int Count()
        {
            return _count;
        }

        public void Print()
        {
            for (var i = 0; i < Count(); i++)
            {
                Console.Write("{0},", _arr[i]);
            }
            Console.WriteLine();
        }
    }
}
