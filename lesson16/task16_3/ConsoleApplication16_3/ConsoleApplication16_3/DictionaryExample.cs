using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication16_3
{
    enum Operations
    {
        Add=1,
        Remove,
    }
    public class DictionaryExample<TKey, TValue>
    {
        private class Node<TKey, TValue>
        {
            public TKey Key { get; private set; }
            public TValue Value { get; private set; }

            public Node(TKey keyIn, TValue valueIn)
            {
                Key = keyIn;
                Value = valueIn;
            }

            public Node<TKey, TValue> Next { get; set; }
            public Node<TKey, TValue> Prev { get; set; }
        }
        private Node<TKey,TValue> Head { get; set; }
        private Node<TKey,TValue> Tail { get; set; }

        public TValue this[TKey index]
        {
            get
            {
                var temp = Head;
                while (temp.Key != null)
                {
                    if (temp.Key.Equals(index))
                    {
                        return temp.Value;
                    }
                }

                return default(TValue);
            }
        }
        public bool Add(TKey newKey,TValue newValue)
        {
            var newNode = new Node<TKey,TValue>(newKey,newValue);
            if (Head == null)
            {
                Head = Tail = newNode;
                return true;
            }
            var currentTailNode = Tail;
            currentTailNode.Next = newNode;
            newNode.Prev = currentTailNode;
            Tail = currentTailNode.Next;
            return true;
        }
        public void Print()
        {
            var tempNode = Head;
            while (tempNode != null)
            {
                Console.WriteLine("Key:{0},Value:{1}", tempNode.Key,tempNode.Value);
                tempNode = tempNode.Next;
            }
        }
        public bool Remove(TKey key)
        {
            var tempNode = Head;
            while (tempNode != null)
            {
                if (tempNode.Key.ToString() == key.ToString())
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
                    if (tempNode == Tail)
                    {
                        Tail = Tail.Prev;
                        Tail.Next = null;
                        return true;
                    }
                    if (tempNode == Head)
                    {
                        Head = Head.Next;
                        return true;
                    }
                    tempNode.Prev.Next = tempNode.Next;
                    tempNode.Next.Prev = tempNode.Prev;
                    return true;
                }

                tempNode = tempNode.Next;
            }

            return false;
        }
    }
}
