﻿using  System; 
using System.Collections.Generic;

namespace Samples.datastructures
{  
    /// <summary>
   /// -Killer Feature-
   /// Random Access
   /// Fixed Capicity
   /// Dobule when resize
   /// </summary>
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

        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Get(int index) => _data[index] == null ? null: _data[index].ToString();
        
        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>

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
 
        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="index"></param>
        /// <param name="value"></param>
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

        /// <summary>
        /// Custum Contains
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool  Contains(object value) 
        {
            for (int i = 0; i < _data.Length; i++)
            {
                if (_data[i] == value)
                    return true;
            }

            return false;
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

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="index"></param>
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
            int i = index;
            for ( i = index; i < _size - 1; i++) 
            {
                _data[i] = _data[i + 1];
            }

            _data[i] = null;
            _size--;
        }

        public bool IsEmpty => _size == 0; 
    }
}
