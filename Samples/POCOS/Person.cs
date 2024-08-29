using System;
using System.Collections.Generic;
using System.Text;

namespace Samples.POCOS
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public override bool Equals(object obj)
        {
            return this.Name == (obj as Person).Name;
        }
    }
}
