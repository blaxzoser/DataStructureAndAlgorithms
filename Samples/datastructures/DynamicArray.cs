using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.datastructures
{
    public class DynamicArray: List<string>
    {
        private  Object[] _data;
        private  int _initialCapacity;
        private int _size = 0;

        public DynamicArray(int initialCapicity)
        {
            _initialCapacity = initialCapicity;
            _data = new object[_initialCapacity];
        }

        public string Get(int index) => _data[index].ToString();
        public void Set(int index, string value) => _data[index] = value;

        public new void Add(string value) 
        {
            if(_size == _initialCapacity) 
            {
                Resize();
            }
            _data[_size] = value;
            _size++;
        }
 
        public  new void Insert(int index, string value) 
        {
            //CheckSize
            if (_size == _initialCapacity)
                Resize();

            //copy up
            for (int j = _size; j > index; j--)
            {
                _data[j] = _data[j-1];           
            }

            //Insert
            _data[index] = value;
            _size++;
        }

        public void Resize() 
        {
            Object[] newData = new Object[_initialCapacity * 2];
            for(int i = 0; i < _initialCapacity; i++) 
            {
                newData[i] = _data[i];
            }
            this._data = newData;
            this._initialCapacity = _initialCapacity * 2;
        }

        public int Size => _size;

        public void Delete(int index)
        {
            //Bad way :( but it works XD
            //Object[] newData = new Object[_size-1];
            //for (int i = 0; i < _size-1; i++)
            //{
            //    if(index != i) 
            //        newData[i] = _data[i];
            //    else
            //        newData[i] = _data[i+1];
            //}
            //_data = newData;

            for(int i = index; i < _size - 1; i++) 
            {
                _data[i] = _data[i + 1];
            }

            _size--;
        }

        public bool IsEmpty => _size == 0; 
    }
}
