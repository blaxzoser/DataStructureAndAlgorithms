using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.datastructures
{

    public class HashTable
    {
        private const int INITIAL_SIZE = 16;
        private HashEntry[] _data; // LinkedList

        public class HashEntry
        {
            private readonly string _key;
            string _value;

            public HashEntry(string key, string value)
            {
                _key = key;
                _value = value;
                Next = null;
            }

            public HashEntry Next { get; set; }
            public string Key => _key;
            public string Value => _value;
        }

        public HashTable()
        {
            _data = new HashEntry[INITIAL_SIZE];
        }

        public void Put(string key,string value)
        {

            // Get the index
            int index = GetIndex(key);

            // Create the linked list entry
            HashEntry entry = new HashEntry(key, value);

            // If no entry there - add it
            if (_data[index] == null)
            {
                _data[index] = entry;
            }
            // Else handle collision by adding to end of linked list
            else
            {
                HashEntry entries = _data[index];
                // Walk to the end...
                while (entries.Next != null)
                {
                    entries = entries.Next;
                }
                // Add our new entry there
                entries.Next = entry;
            }
        }

        private int GetIndex(string key)
        {
            // Get the hash code
            int hashCode = key.GetHashCode();

            // Convert to index
            int index = (hashCode & 0x7fffffff) % INITIAL_SIZE;

            // Hack to force collision for testing
            if (key.Equals("John Smith") || key.Equals("Sandra Dee") || key.Equals("Tim Lee"))
            {
                index = 4;
            }

            return index;
        }

        public override string ToString()
        {
            int bucket = 0;
            StringBuilder hashTableStr = new StringBuilder();
            foreach(HashEntry entry in _data)
            {
                if (entry == null)
                {
                    continue;
                }
                hashTableStr.Append("\n bucket[")
                        .Append(bucket)
                        .Append("] = ")
                        .Append(entry.ToString());
                bucket++;
                HashEntry temp = entry.Next;
                while (temp != null)
                {
                    hashTableStr.Append(" -> ");
                    hashTableStr.Append(temp.ToString());
                    temp = temp.Next;
                }
            }
            return hashTableStr.ToString();
        }

        public string Get(string key)
        {

            // Get the index
            int index = GetIndex(key);

            // Get the current list of entries
            HashEntry entries = _data[index];

            // While there are elements in the linked list...
            while (entries != null)
            {
                if (entries.Key.Equals(key))    // Check for match
                    return entries.Value;       // if match found return
                entries = entries.Next;         // else go to next node in chain
            }

            return null;                         // return null if no match found
        }
    }
}
