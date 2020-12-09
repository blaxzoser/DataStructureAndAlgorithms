using System;

namespace Samples.datastructures
{
    /// <summary>
    /// LIFO Last in First Out
    /// </summary>
    public class Stack
    {

        private Node _head;
        private int _size;
        public class Node 
        {
            int _data;
            public Node Next { get; set; }
            public Node(int data)
            {
                this._data = data;
            }

            public int Data { get { return _data; } }
        }

        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="data"></param>
        public void Push(int data) 
        {
            //Create new node
            //Set it's next to be head
            //Set head to be the new one
            var newNode = new Node(data);
            newNode.Next = _head;            
            _head = newNode;
            _size++;
        }

        /// <summary>
        /// O(1)
        /// </summary>
        public int Pop() 
        {
            //Store the value you want to return
            //Set the current head.next to be the new head
            //return the value
            if (_head == null) throw new Exception("its empty the head");

            int data = _head.Data;
            _head = _head.Next;
            _size--;
            return data;
        }

        public int Peek() { return _head.Data; }

        public bool IsEmpty() { return _head == null; }

        public int Size => _size;
     
    }
}
