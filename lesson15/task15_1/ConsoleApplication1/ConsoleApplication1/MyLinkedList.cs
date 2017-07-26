using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    enum Operations
    {
        Add = 1,
        RemoveFirst,
        RemoveLast,
        Contains
    }
    public  class MyLinkedList<T> where T:new()
    {
        private class Node<T> where T:new()
        {
            public T Value { get; set; }

            public Node(T Data) 
            {
                Value = Data;
            }

            public Node<T> Next { get; set; }

            public Node<T> Prev { get; set; }

        }

        private Node<T> Head { get;set; }
        private Node<T> Tail { get; set; }

        public bool Add(T newElem)
        {
            var newNode = new Node<T>(newElem);
            if (Head == null)
            {
                Head =Tail= newNode;
                return true;
            }
        

           // Tail.Next = newNode;
           // newNode.Prev = Tail;
          //  Tail = newNode;

            var currentTailNode = Tail;
            currentTailNode.Next = newNode;
            newNode.Prev = currentTailNode;
            Tail = currentTailNode.Next;

            return true;
        }

        public bool RemoveFirst()
        {
            if (Head == null) return false;
            Head = Head.Next;
            return true;
        }

        public bool RemoveLast()
        {
            if (Tail == null)
            {
                Head = null;
                return true;
            }

            if (Tail == Head)
            {
                Tail = null;
                Head = null;
                return true;
            }

            Tail = Tail.Prev;
            Tail.Next = null;
            return true;
        }

        

        public int GetLength()
        {
            var count = 0;
           
            var tempNode = Head;
            while (tempNode != null)
            {
                count++;
                tempNode = tempNode.Next;
            }

            return count;
        }

        public bool Contains(T value)
        {
            var tempNode = Head;
            while (tempNode != null)
            {
                if (Equals(tempNode.Value, value))
                {
                    return true;
                }

                tempNode = tempNode.Next;
            }

            return false;
        }

        public T[] ToArray()
        {
            var tempNode = Head;
            int count = 0;
            var arr=new T[GetLength()];
            while (tempNode != null)
            {
                arr[0] = tempNode.Value;
                tempNode = tempNode.Next;
                count++;
            }

            return arr;
        }

        public void Print()
        {
            var tempNode = Head;
            while (tempNode!=null)
            {
                Console.Write("{0},",tempNode.Value);
                tempNode = tempNode.Next;
            }
        }
    }
}
