using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Garage_HomeWork_12
{
    public class MyArrayList
    {
        private object?[] _items;

        public MyArrayList()
        {
            _items = new object[0];
        }

        public MyArrayList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException("capacity is negative");
            else if (capacity == 0)
                _items = new object[0];
            else
                _items = new object[capacity];
        }

        public int Capacity
        {
            get { return _items.Length; }
            set
            {
                if (value < Count) throw new ArgumentOutOfRangeException("Value is smaller than count");
                if (value != _items.Length)
                {
                    if (value > 0)
                    {
                        object[] newItems = new object[value];
                        if (Count > 0)
                        {
                            Array.Copy(_items, newItems, Count);
                        }
                        _items = newItems;
                    }
                    else
                    {
                        _items = new object[4];
                    }
                }
            }
        }
        public int Count { get; private set; }

        public object? this[int index]
        {
            get
            {
                if (index >= 0 && index < Count) return _items[index];
                return null;
            }
            set
            {
                if (index >= 0 && index < Count)
                    _items[index] = value;
            }
        }

        public void Add(object? value)
        {
            CalculateCapacity(Count + 1);
            _items[Count] = value;
            Count++;
        }

        public void CalculateCapacity(int count)
        {
            if (count > _items.Length)
            {
                Capacity = _items.Length == 0 ? 4 : _items.Length * 2;
            }
            if (Capacity < count) Capacity = count;
        }
        public void RemoveAt(int index)
        {
            if (index >= 0 && index < Count && Count > 0)
            {
                object[] newArr = new object[Capacity];
                for (int i = 0, k = 0; i < Count; i++)
                {
                    if (i != index)
                    {
                        newArr[k] = _items[i]!;
                        k++;
                    }
                }
                _items = newArr;
                Count--;
                return;
            }
            throw new ArgumentException("wrong index");
        }
        public void Remove(object? obj)
        {
            for (int i = 0; i < Count; i++)
            {
                if (_items[i] == obj)
                {
                    RemoveAt(i); break;
                }
            }
        }

        public void TrimToSize()
        {
            Capacity = Count;
        }

        public void AddRange(ICollection collection)
        {
            if (collection != null && collection.Count > 0)
            {
                CalculateCapacity(Count + collection.Count);
                object[] newArr = new object[Capacity];
                Array.Copy(_items, newArr, _items.Length);
                collection.CopyTo(newArr, Count);
                Count += collection.Count;
                _items = newArr;
            }
        }
    }
}
