using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.datastructures
{
    /// <summary>
    /// FIFO Fist in Fist Out
    /// </summary>
    public class Queue
    {
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

        private Node _head;
        private Node _tail;


        public void Add(int data)
        {
            // Create a new node
            // Set the current tail.next to point to this new node
            // Then set the new node to be the new tail

            Node newNode = new Node(data);
            if (_tail != null)
            {
                _tail.Next = newNode;
            }
            _tail = newNode;

            // handle case of first element where head is null
            if (_head == null)
            {
                _head = _tail;
            }
        }


        public int Remove()
        {
            // Save the data
            // Point the head to the next element (effectively removing it)
            // Then return the data

            int data = _head.Data;
            _head = _head.Next;

            // Handle queue now being empty
            if (_head == null)
            {
                _tail = null;
            }

            return data;
        }



        public int Peek() { return _head.Data; }
        public bool IsEmpty() { return _head == null; }
    }
}
