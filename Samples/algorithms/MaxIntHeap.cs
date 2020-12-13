using System;
using System.Diagnostics;


namespace Samples.algorithms
{
    /// <summary>
    /// Extremely Fast
    /// Compact
    /// Few Lines
    /// </summary>
    public class MaxIntHeap
    {
        private int _capactity = 10;
        private int _size = 0;

        public MaxIntHeap() 
        {
            Items  = new int[_capactity];
        }

        public int[] Items { get; set; }


        private int LeftChildIndex(int parentIndex) { return 2 * parentIndex + 1; }
        private int RightChildIndex(int parentIndex) { return 2 * parentIndex + 2; }
        private int ParentIndex(int childIndex) { return (childIndex - 1) / 2; }


        private bool HasLeftChild(int index) { return LeftChildIndex(index) < _size; }
        private bool HasRightChild(int index) { return RightChildIndex(index) < _size; }
        private bool HasParent(int index) { return ParentIndex(index) >= 0; }

        private int LeftChild(int index) { return Items[LeftChildIndex(index)]; }
        private int RightChild(int index) { return Items[RightChildIndex(index)]; }
        private int Parent(int index) { return Items[ParentIndex(index)]; }

        /// <summary>
        /// Heap Order
        /// Insert- Up
        /// Extract - Down
        /// 2 divide
        /// -Peek O(1)
        /// -Heapify O(log n)
        /// </summary>
        /// <returns></returns>
        public int ExtractMax()
        {
            if (_size == 0) throw new ArgumentException();
            int item = Items[0];        // grab the max
            Items[0] = Items[_size - 1]; // swap top and bottom
            _size--;                     // effectively deletes last entry (max)
            HeapifyDown();              // reorder
            return item;                // return max
        }

        private void EnsureCapactity()
        {
            if (_size == _capactity)
            {
                Array.Copy(Items, Items, _capactity * 2);
                _capactity *= 2;
            }
        }

        public void Insert(int item)
        {
            EnsureCapactity();
            Items[_size] = item; // put in last spot
            _size++;
            HeapifyUp();
        }

        /// <summary>
        /// O(log n)
        /// Single run
        /// </summary>
        public void HeapifyUp()
        {
            int index = _size - 1;       // start at last element
                                        // while my parents are less than me...
            while (HasParent(index) && Parent(index) < Items[index])
            {
                Swap(ParentIndex(index), index);
                index = ParentIndex(index); // walk upwards to next node
            }
        }

        /// <summary>
        /// O(log n)
        /// Single run
        /// </summary>
        public void HeapifyDown()
        {
            int index = 0; // start at the top

            // as long as I have children
            // note: Only need to check left because if no left, there is no right
            while (HasLeftChild(index))
            {

                // take the larger of the two indexes
                int largerChildIndex = LeftChildIndex(index);
                if (HasRightChild(index) && RightChild(index) > LeftChild(index))
                {
                    largerChildIndex = RightChildIndex(index);
                }

                // now compare

                // if I am larger than the items of my two children...
                // then everything is good. I am sorted.
                if (Items[index] > Items[largerChildIndex])
                {
                    break;
                }
                else
                {
                    //  we are still not in order - swap
                    Swap(index, largerChildIndex);
                }

                // then move down to smaller child
                index = largerChildIndex;
            }
        }

        public void Print()
        {
            for (int i = 0; i < _size; i++)
            {
                Debug.WriteLine(i + "[" + Items[i] + "]");
            }
        }

        private void Swap(int indexOne, int indexTwo)
        {
            int temp = Items[indexOne];
            Items[indexOne] = Items[indexTwo];
            Items[indexTwo] = temp;
        }

    }
}
