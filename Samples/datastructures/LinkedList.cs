 using System;

namespace Samples.datastructures
{
    /// <summary>
    /// No random access
    /// No fixed Capacity
    /// Always the right size
    /// </summary>
    public class LinkedList
    {
        private class Node 
        {
            int _data;
            public Node Next { get; set; }
            public Node(int data) 
            {
                this._data = data;
            }

            public int Data { get { return _data; } }
        }

        private Node _head;

        /// <summary>
        /// O(1)
        /// </summary>
        /// <param name="data"></param>
        public void AddFront(int data) 
        {
            //Create new node
            Node newNode = new Node(data);

            //if head
            if (_head == null) 
            {
                _head = newNode;
                return;
            }

            //Set it's next to the current head 
            newNode.Next = _head;

            //Set current head be the new head
            _head = newNode;

        }

        public int GetFirst() 
        {
            return _head.Data;
        }

        public int GetLast() 
        { 
            if(_head == null) 
            {
                throw new Exception("Empty list");
            }

            var current = _head;

            // While we are not at the tail
            while (current.Next != null)
                current = current.Next; // O(n)
           //We at the tail
            return current.Data;

        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="data"></param>
        public void AddBack(int data )
        {
            var newNode = new Node(data);
            if(_head == null)
            {
                _head = newNode;
                return;
            }

            // Start at the head
            Node current = _head;
         
            // Walk back node = null
            while (current.Next != null)
                current = current.Next; 
                                        
            current.Next = newNode;
        }

        public int Size()
        {
            if (_head == null)
            {
                return 0;
            }

            // Start at the head
            Node current = _head;

            int count = 0;
            while (current != null) 
            {
                current = current.Next;
                count++; 
            }

            return count;
        }

        /// <summary>
        /// O(n)
        /// </summary>
        /// <param name="data"></param>
        public void DeleteValue(int data)
        {
            if (_head == null) return;
            if ( _head.Data == data)
            {
                _head = _head.Next;
                return;
            }
            var current = _head;

            while (current.Next != null)
            {
                if (current.Next.Data == data) 
                {
                    current.Next = _head.Next.Next;
                    return;
                }

                current = current.Next;
            }
        }

        public void Clear()
        {
            _head = null;
        }
    }
}
