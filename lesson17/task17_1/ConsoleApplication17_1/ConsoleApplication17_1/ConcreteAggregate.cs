using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication17_1
{
    class ConcreteAggregate<T>:Aggregate<T>
    {
        private readonly ArrayList _items = new ArrayList();

        public override Iterator<T> CreateIterator()
        {
            return new ConcreteIterator<T>(this);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public T this[int index]
        {
            get { return (T)_items[index]; }
            set { _items.Insert(index, value); }
        }
    }
}
