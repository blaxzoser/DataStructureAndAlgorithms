using System;
using System.Diagnostics.SymbolStore;
using System.Runtime.CompilerServices;

namespace System.Runtime.CompilerServices
{
    // Polyfill for IsExternalInit to support records in netstandard2.0
    internal static class IsExternalInit { }
}

namespace Samples.memory
{
    // Helper class for demonstrating Object/Class behavior
    public class PersonClass
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public PersonClass(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    // Helper record for demonstrating Record behavior
    public record PersonRecord(string Name, int Age);

    public class ValuesTypeVsReferenceType
    {

        #region String - ReferenceType
        /// <summary>
        /// This sample demonstrates how string equality works with reference types.
        /// Strings are immutable reference types that demonstrate string interning behavior.
        /// </summary>
        /// <returns>True if the strings are equal (which they will be due to string interning)</returns>
        public (bool isReferenceEquals,bool isValueEquals) SampleEqualsOnString()
        {
            // ========================================================================
            // VISUAL MEMORY REPRESENTATION:
            // ========================================================================
            //
            // STACK (Local Variables)          HEAP (String Objects)
            // ┌─────────────────┐             ┌─────────────────────┐
            // │ sampleA ────────┼─────────────►│ "luis"              │
            // │ (reference)     │             │ (interned string)   │
            // └─────────────────┘             └─────────────────────┘
            // ┌─────────────────┐                      ▲
            // │ sampleB ────────┼──────────────────────┘
            // │ (reference)     │             Both references point
            // └─────────────────┘             to the SAME object!
            //
            // ========================================================================
            // KEY CONCEPTS:
            // ========================================================================
            // 1. STRING INTERNING: When you create string literals with the same value,
            //    .NET stores them ONCE in the intern pool and reuses the reference.
            //    This is why sampleA and sampleB point to the SAME object in memory.
            //
            // 2. IMMUTABILITY: Strings cannot be changed after creation. Any "modification"
            //    creates a NEW string object. The original remains unchanged.
            //
            // 3. EQUALS() BEHAVIOR: String.Equals() compares the CONTENT (value) of strings,
            //    not just the reference. Even if they were different objects with the same
            //    content, Equals() would return true.
            //
            // ========================================================================
            // STEP-BY-STEP EXECUTION:
            // ========================================================================
            // Step 1: string sampleA = "luis";
            //   - .NET checks the intern pool for "luis"
            //   - If found, reuses existing reference
            //   - If not found, creates new string in intern pool
            //   - sampleA now points to this string object
            //
            // Step 2: string sampleB = "luis";
            //   - .NET checks the intern pool for "luis"
            //   - Finds existing "luis" from Step 1
            //   - sampleB gets the SAME reference as sampleA
            //   - Both variables now point to the SAME object
            //
            // Step 3: sampleA.Equals(sampleB)
            //   - Compares the content/value of both strings
            //   - Since both contain "luis", returns true
            //   - Note: sampleA == sampleB would also be true (reference equality)
            //   - Note: ReferenceEquals(sampleA, sampleB) would also be true (same object)
            //
            // ========================================================================
            // COMPARISON WITH NON-INTERNED STRINGS:
            // ========================================================================
            // If you create strings dynamically (not literals), they may NOT be interned:
            //
            //   string a = new string(new char[] { 'l', 'u', 'i', 's' });
            //   string b = new string(new char[] { 'l', 'u', 'i', 's' });
            //   // a and b are DIFFERENT objects, but...
            //   a.Equals(b)  // Returns TRUE (value comparison)
            //   a == b      // Returns TRUE (string == operator compares values)
            //   ReferenceEquals(a, b)  // Returns FALSE (different objects)
            //
            // ========================================================================

            // Save on Stack but it points to Heap (string value "luis")
            // They point to the same object due to string interning
            string sampleA = "luis";
            string sampleB = "luis";

            // This will return TRUE because:
            // 1. Both strings have the same content ("luis")
            // 2. Due to string interning, they reference the same object
            // 3. String.Equals() compares values, which are identical
            bool isReferenceEquals = ReferenceEquals(sampleA, sampleB);
            bool isValue = sampleA.Equals(sampleB);  // sampleA == sampleB
            return (isReferenceEquals,isValue);
        }

        /// <summary>
        /// This sample demonstrates string immutability - strings cannot be changed after creation.
        /// When you "modify" a string, you're actually creating a new string object and changing
        /// the reference. The original string object remains unchanged in memory.
        /// string is a Reference type
        /// </summary>
        public (bool isActualValue, bool isOriginalValue) SampleImmutableOnString()
        {
            // ========================================================================
            // VISUAL MEMORY REPRESENTATION:
            // ========================================================================
            //
            // BEFORE: string testA = "a";
            // ┌─────────────────┐             ┌─────────────────────┐
            // │ testA ──────────┼─────────────►│ "a"                  │
            // │ (reference)     │             │ (interned string)   │
            // └─────────────────┘             └─────────────────────┘
            //
            // AFTER: testA = "b";
            // ┌─────────────────┐             ┌─────────────────────┐
            // │ testA ──────────┼─────────────►│ "b"                  │
            // │ (reference)     │             │ (new interned string)│
            // └─────────────────┘             └─────────────────────┘
            //                                          │
            //                                          │ The "a" string still exists
            //                                          │ in memory (if referenced elsewhere)
            //                                          ▼
            //                                 ┌─────────────────────┐
            //                                 │ "a"                  │
            //                                 │ (still in memory,    │
            //                                 │  unchanged!)         │
            //                                 └─────────────────────┘
            //
            // KEY POINT: The variable testA now points to a DIFFERENT object.
            // The original "a" string was NOT modified - it's immutable!
            //
            // ========================================================================
            // KEY CONCEPTS:
            // ========================================================================
            // 1. IMMUTABILITY: Strings in .NET are immutable, meaning once created,
            //    they CANNOT be changed. Any operation that appears to "modify" a
            //    string actually creates a NEW string object.
            //
            // 2. REFERENCE REASSIGNMENT: When you write testA = "b", you're not
            //    changing the "a" string. Instead, you're:
            //    - Creating (or finding in intern pool) a new "b" string object
            //    - Changing the testA reference to point to the new "b" object
            //    - The original "a" object remains untouched in memory
            //
            // 3. MEMORY IMPLICATIONS: If no other references point to "a", it becomes
            //    eligible for garbage collection. However, if "a" is interned (which
            //    string literals are), it may remain in memory longer.
            //
            // 4. PERFORMANCE CONSIDERATION: Repeated string "modifications" can create
            //    many temporary string objects. Use StringBuilder for frequent concatenations.
            //
            // ========================================================================
            // STEP-BY-STEP EXECUTION:
            // ========================================================================
            // Step 1: string testA = "a";
            //   - .NET checks the intern pool for "a"
            //   - Creates "a" string object in intern pool (if not already present)
            //   - testA reference points to this "a" object
            //   - Memory: testA → "a" object
            //
            // Step 2: testA = "b";
            //   - .NET checks the intern pool for "b"
            //   - Creates "b" string object in intern pool (if not already present)
            //   - testA reference is UPDATED to point to the "b" object
            //   - Memory: testA → "b" object (NEW reference)
            //   - The "a" object is NOT modified - it still exists unchanged
            //   - If no other variables reference "a", it may be garbage collected
            //     (though interned strings persist longer)
            //
            // ========================================================================
            // WHAT IMMUTABILITY MEANS:
            // ========================================================================
            // You CANNOT do this (strings don't have methods that modify them):
            //
            //   string s = "hello";
            //   s[0] = 'H';  // ❌ COMPILE ERROR! Strings are immutable
            //   s.Modify(0, 'H'); // ❌ No such method exists
            //
            // Instead, you create NEW strings:
            //
            //   string s = "hello";
            //   s = "Hello";  // ✅ Creates new string, changes reference
            //   s = s.Replace('h', 'H'); // ✅ Returns NEW string
            //
            // ========================================================================
            // COMPARISON: IMMUTABLE vs MUTABLE:
            // ========================================================================
            // IMMUTABLE (String):
            //   string s = "hello";
            //   string t = s;        // Both s and t point to same "hello" object
            //   s = "world";         // s now points to "world", t still points to "hello"
            //   // t is still "hello" - the original object was NOT changed
            //
            // MUTABLE (StringBuilder):
            //   StringBuilder sb = new StringBuilder("hello");
            //   StringBuilder tb = sb;  // Both reference same StringBuilder object
            //   sb.Append(" world");    // Modifies the SAME object
            //   // tb also shows "hello world" - the object WAS changed
            //
            // ========================================================================
            // WHY STRINGS ARE IMMUTABLE:
            // ========================================================================
            // 1. THREAD SAFETY: Immutable objects are inherently thread-safe since
            //    they can't be modified after creation. Multiple threads can safely
            //    read the same string without synchronization.
            //
            // 2. SECURITY: Prevents accidental or malicious modification of string
            //    data, which is important for security-sensitive operations.
            //
            // 3. HASH CODE STABILITY: String hash codes never change, making them
            //    safe to use as dictionary keys without worrying about hash changes.
            //
            // 4. STRING INTERNING: Immutability enables string interning, allowing
            //    multiple references to safely share the same string object.
            //
            // ========================================================================

            // Step 1: testA points to the "a" string object
            string testA = "a";
            
            // Step 2: testA now points to a NEW "b" string object
            // The original "a" string is NOT modified - it remains unchanged in memory
            // This demonstrates immutability: you can't change "a", only point to a new string
            testA = "b";
            
            // At this point:
            // - testA references the "b" string object
            // - The "a" string object still exists in memory (in the intern pool)
            // - If no other code references "a", it may eventually be garbage collected
            //   (though interned strings persist for the application lifetime)
            
            // Demonstration: Show that testA now contains "b" (not "a")
            // This proves the reference was changed, not the original string object
            bool isNowB = testA == "b";  // Will be true - testA points to "b"
            bool isStillA = testA == "a"; // Will be false - testA no longer points to "a"
            // The original "a" string object was never modified - it's immutable!
            // We just changed which object testA references
            return ( isActualValue: isNowB, isOriginalValue: isStillA);

        }

        #endregion

        

        /// <summary>
        /// This sample demonstrates how equality works with value types.
        /// Integers are value types stored directly on the stack, not as references to heap objects.
        /// Int is a Values Type
        /// </summary>
        /// <returns>True if the integers have the same value</returns>
        public (bool isValue, bool isReference) SampleEqualsOnInt() 
        {
            // ========================================================================
            // VISUAL MEMORY REPRESENTATION:
            // ========================================================================
            //
            // STACK (Local Variables)          HEAP
            // ┌─────────────────┐             ┌─────────────────────┐
            // │ sampleA = 0     │             │                     │
            // │ (value stored   │             │  (No heap objects   │
            // │  directly)      │             │   for value types!) │
            // └─────────────────┘             └─────────────────────┘
            // ┌─────────────────┐
            // │ sampleB = 0     │
            // │ (value stored   │
            // │  directly)      │
            // └─────────────────┘
            //
            // KEY DIFFERENCE: Value types store the ACTUAL VALUE on the stack,
            // NOT a reference/pointer to a heap object!
            //
            // ========================================================================
            // KEY CONCEPTS:
            // ========================================================================
            // 1. VALUE TYPE STORAGE: Value types (like int, bool, double, structs)
            //    are stored DIRECTLY on the stack. The variable CONTAINS the value,
            //    not a reference to it. This is fundamentally different from reference types.
            //
            // 2. VALUE COPYING: When you assign one value type to another, you COPY
            //    the actual value. Each variable has its own independent copy.
            //
            // 3. EQUALS() BEHAVIOR: ValueType.Equals() compares the ACTUAL VALUES
            //    stored in the variables. Since both contain 0, they are equal.
            //
            // 4. NO HEAP ALLOCATION: Value types don't create objects on the heap,
            //    making them more memory-efficient for small data types.
            //
            // ========================================================================
            // STEP-BY-STEP EXECUTION:
            // ========================================================================
            // Step 1: int sampleA = 0;
            //   - Allocates space on the STACK for an integer (4 bytes)
            //   - Stores the value 0 directly in that stack location
            //   - No heap allocation occurs
            //   - sampleA now contains the value 0
            //
            // Step 2: int sampleB = 0;
            //   - Allocates a SEPARATE space on the STACK for another integer
            //   - Stores the value 0 directly in that new stack location
            //   - sampleB is a COMPLETELY INDEPENDENT variable from sampleA
            //   - Both happen to contain the same value (0), but they are separate
            //
            // Step 3: sampleA.Equals(sampleB)
            //   - Compares the actual VALUES stored in sampleA and sampleB
            //   - Since both contain 0, returns true
            //   - Note: sampleA == sampleB would also be true (value comparison)
            //   - Note: ReferenceEquals(sampleA, sampleB) would return FALSE
            //     (value types are boxed when passed to ReferenceEquals, creating
            //      different boxed objects even if values are the same)
            //
            // ========================================================================
            // COMPARISON: VALUE TYPES vs REFERENCE TYPES:
            // ========================================================================
            // VALUE TYPES (int, bool, struct, etc.):
            //   int a = 5;
            //   int b = 5;
            //   // a and b are SEPARATE variables with SEPARATE values
            //   a.Equals(b)           // Returns TRUE (same value)
            //   a == b               // Returns TRUE (value comparison)
            //   ReferenceEquals(a, b) // Returns FALSE (boxing creates different objects)
            //
            // REFERENCE TYPES (string, class, etc.):
            //   string a = "test";
            //   string b = "test";
            //   // a and b are references (pointers) to objects
            //   a.Equals(b)           // Returns TRUE (same content)
            //   a == b               // Returns TRUE (string == compares values)
            //   ReferenceEquals(a, b) // Returns TRUE (string interning - same object)
            //
            // ========================================================================
            // BOXING AND UNBOXING (Advanced):
            // ========================================================================
            // When you call .Equals() on a value type, it may involve boxing:
            //
            //   int x = 5;
            //   object boxed = x;  // Boxing: value type → reference type
            //   int y = (int)boxed; // Unboxing: reference type → value type
            //
            // However, modern .NET optimizes Equals() calls on value types to avoid
            // unnecessary boxing in many cases.
            //
            // ========================================================================

            // Value types are stored directly on the stack
            // Each variable contains its own copy of the value
            int sampleA = 0;
            int sampleB = 0;

            // This will return TRUE because:
            // 1. Both integers contain the same value (0)
            // 2. ValueType.Equals() compares the actual values stored in the variables
            // 3. Even though sampleA and sampleB are separate variables, their values are equal
            // Note: Modifying sampleA later would NOT affect sampleB (they're independent)

            var isValue = sampleA == sampleB; // sample.Equals(sampleB)
            var isReference = ReferenceEquals(isValue, sampleB);
            return (isValue,isReference);
        }

        #region Object/Class - ReferenceType

        /// <summary>
        /// This sample demonstrates how equality works with classes (reference types).
        /// Classes use reference equality by default - two objects with the same data
        /// are NOT equal unless they reference the same object in memory.
        /// Class is a Reference Type
        /// </summary>
        /// <returns>Tuple showing reference equality and value equality results</returns>
        public (bool isReferenceEquals, bool isValueEquals, bool isOperatorEquals) SampleEqualsOnClass()
        {
            // ========================================================================
            // VISUAL MEMORY REPRESENTATION:
            // ========================================================================
            //
            // STACK (Local Variables)          HEAP (PersonClass Objects)
            // ┌─────────────────┐             ┌─────────────────────────────┐
            // │ personA ────────┼─────────────►│ PersonClass                │
            // │ (reference)     │             │ ┌─────────────────────────┐ │
            // └─────────────────┘             │ │ Name = "John"            │ │
            // ┌─────────────────┐             │ │ Age = 30                │ │
            // │ personB ────────┼─────────────►│ └─────────────────────────┘ │
            // │ (reference)     │             │ (Object #1)                │
            // └─────────────────┘             └─────────────────────────────┘
            // ┌─────────────────┐             ┌─────────────────────────────┐
            // │ personC ────────┼─────────────►│ PersonClass                │
            // │ (reference)     │             │ ┌─────────────────────────┐ │
            // └─────────────────┘             │ │ Name = "John"            │ │
            //                                   │ │ Age = 30                │ │
            //                                   │ └─────────────────────────┘ │
            //                                   │ (Object #2 - DIFFERENT!)   │
            //                                   └─────────────────────────────┘
            //
            // KEY POINT: personA and personC point to DIFFERENT objects, even though
            // they have the same data. personA == personC returns FALSE!
            //
            // ========================================================================
            // KEY CONCEPTS:
            // ========================================================================
            // 1. REFERENCE EQUALITY: By default, classes use REFERENCE equality.
            //    Two objects are equal ONLY if they reference the SAME object in memory.
            //    Even if two objects have identical data, they are NOT equal if they
            //    are different instances (different memory addresses).
            //
            // 2. DEFAULT EQUALS() BEHAVIOR: Object.Equals() compares references by default.
            //    It returns true ONLY if both variables point to the same object.
            //
            // 3. == OPERATOR: The == operator also compares references for classes
            //    (unless overridden). personA == personB checks if they point to the
            //    same object, NOT if their data is the same.
            //
            // 4. VALUE EQUALITY: To compare by value, you must:
            //    - Override Equals() and GetHashCode()
            //    - Override == and != operators
            //    - Or use a Record type (which does this automatically)
            //
            // ========================================================================
            // STEP-BY-STEP EXECUTION:
            // ========================================================================
            // Step 1: PersonClass personA = new PersonClass("John", 30);
            //   - Allocates memory on the HEAP for a new PersonClass object
            //   - Sets Name = "John" and Age = 30
            //   - Creates a reference on the STACK (personA) pointing to this object
            //   - Memory: personA → PersonClass object #1
            //
            // Step 2: PersonClass personB = personA;
            //   - Copies the REFERENCE from personA to personB
            //   - personB now points to the SAME object as personA
            //   - Memory: personA → PersonClass object #1 ← personB
            //   - Both variables reference the SAME object
            //
            // Step 3: PersonClass personC = new PersonClass("John", 30);
            //   - Allocates memory on the HEAP for a NEW PersonClass object
            //   - Sets Name = "John" and Age = 30 (same data as personA)
            //   - Creates a reference on the STACK (personC) pointing to this NEW object
            //   - Memory: personA → PersonClass object #1
            //            personC → PersonClass object #2 (DIFFERENT object!)
            //
            // Step 4: Comparisons
            //   - ReferenceEquals(personA, personB) → TRUE (same object)
            //   - ReferenceEquals(personA, personC) → FALSE (different objects)
            //   - personA.Equals(personB) → TRUE (same object)
            //   - personA.Equals(personC) → FALSE (different objects, even with same data)
            //   - personA == personB → TRUE (same reference)
            //   - personA == personC → FALSE (different references)
            //
            // ========================================================================
            // COMPARISON: CLASS vs RECORD:
            // ========================================================================
            // CLASS (Reference Equality):
            //   PersonClass a = new PersonClass("John", 30);
            //   PersonClass b = new PersonClass("John", 30);
            //   a == b                    // FALSE (different references)
            //   a.Equals(b)               // FALSE (different references)
            //   ReferenceEquals(a, b)     // FALSE (different objects)
            //
            // RECORD (Value Equality):
            //   PersonRecord a = new PersonRecord("John", 30);
            //   PersonRecord b = new PersonRecord("John", 30);
            //   a == b                    // TRUE (same values)
            //   a.Equals(b)               // TRUE (same values)
            //   ReferenceEquals(a, b)     // FALSE (different objects, but equal by value)
            //
            // ========================================================================
            // WHEN TO USE CLASSES:
            // ========================================================================
            // Use classes when:
            // 1. You need reference semantics (sharing the same object instance)
            // 2. You need mutable objects (can change after creation)
            // 3. You need identity-based equality (two instances are never equal)
            // 4. You're building complex hierarchies with inheritance
            //
            // ========================================================================
            // MUTABILITY EXAMPLE:
            // ========================================================================
            // Classes are mutable by default:
            //
            //   PersonClass person = new PersonClass("John", 30);
            //   PersonClass samePerson = person;  // Both reference same object
            //   person.Age = 31;                  // Modifies the object
            //   // samePerson.Age is now also 31! (same object was modified)
            //
            // ========================================================================

            // Create first person object
            PersonClass personA = new PersonClass("John", 30);
            
            // Assign reference - personB points to the SAME object as personA
            PersonClass personB = personA;
            
            // Create a NEW person object with the SAME data
            // This is a DIFFERENT object in memory, even though data is identical
            PersonClass personC = new PersonClass("John", 30);

            // Reference equality checks
            bool isReferenceEquals = ReferenceEquals(personA, personB);  // TRUE - same object
            bool isReferenceEqualsDifferent = ReferenceEquals(personA, personC); // FALSE - different objects

            // Value equality checks (default behavior compares references)
            bool isValueEquals = personA.Equals(personB);  // TRUE - same object
            bool isValueEqualsDifferent = personA.Equals(personC); // FALSE - different objects (even with same data!)

            // Operator equality (also compares references by default)
            bool isOperatorEquals = personA == personB;  // TRUE - same reference
            bool isOperatorEqualsDifferent = personA == personC; // FALSE - different references

            // Demonstration: Modifying personA affects personB (same object)
            personA.Age = 31;
            bool personBAgeChanged = personB.Age == 31;  // TRUE - same object was modified
            bool personCAgeUnchanged = personC.Age == 30; // TRUE - different object, not affected

            return (isReferenceEquals, isValueEquals, isOperatorEquals);
        }

        /// <summary>
        /// This sample demonstrates how reference assignment works with classes.
        /// When you assign one class variable to another, you copy the REFERENCE,
        /// not the object itself. Both variables then point to the same object.
        /// </summary>
        public (bool sameObjectAfterModification, bool independentCopy) SampleReferenceAssignmentOnClass()
        {
            // ========================================================================
            // VISUAL MEMORY REPRESENTATION:
            // ========================================================================
            //
            // INITIAL: PersonClass original = new PersonClass("Alice", 25);
            // ┌──────────────┐             ┌─────────────────────────────┐
            // │ original ────┼─────────────►│ PersonClass                 │
            // │ (reference)  │             │ Name = "Alice"               │
            // └──────────────┘             │ Age = 25                     │
            //                               └─────────────────────────────┘
            //
            // AFTER: PersonClass copy = original;
            // ┌──────────────┐             ┌─────────────────────────────┐
            // │ original ────┼─────────────►│ PersonClass                 │
            // │ (reference)  │             │ Name = "Alice"               │
            // └──────────────┘             │ Age = 25                     │
            // ┌──────────────┐             │                              │
            // │ copy ────────┼─────────────┘
            // │ (reference)  │             Both references point to the
            // └──────────────┘             SAME object!
            //
            // AFTER MODIFICATION: original.Age = 30;
            // ┌──────────────┐             ┌─────────────────────────────┐
            // │ original ────┼─────────────►│ PersonClass                 │
            // │ (reference)  │             │ Name = "Alice"               │
            // └──────────────┘             │ Age = 30  ← CHANGED!        │
            // ┌──────────────┐             │                              │
            // │ copy ────────┼─────────────┘
            // │ (reference)  │             copy.Age is also 30!
            // └──────────────┘             (same object was modified)
            //
            // ========================================================================
            // KEY CONCEPTS:
            // ========================================================================
            // 1. REFERENCE COPYING: When you assign a class variable to another,
            //    you copy the REFERENCE (memory address), not the object itself.
            //    Both variables then point to the SAME object in memory.
            //
            // 2. SHARED STATE: Since both variables reference the same object,
            //    modifying the object through one variable affects the other.
            //    This is called "shared mutable state."
            //
            // 3. NO INDEPENDENT COPY: Unlike value types, assigning a class doesn't
            //    create an independent copy. To create a copy, you need to:
            //    - Implement ICloneable and call Clone()
            //    - Create a new object and copy properties manually
            //    - Use a copy constructor
            //
            // ========================================================================

            PersonClass original = new PersonClass("Alice", 25);
            
            // This copies the REFERENCE, not the object
            // Both variables now point to the SAME object
            PersonClass copy = original;

            // Modify through original
            original.Age = 30;

            // Check if copy was affected (it will be - same object!)
            bool sameObjectAfterModification = copy.Age == 30;  // TRUE - same object modified

            // To create an independent copy, you need to create a new object
            PersonClass independentCopy = new PersonClass(original.Name, original.Age);
            original.Age = 35;  // Modify original

            bool independentCopyUnaffected = independentCopy.Age == 30;  // TRUE - different object

            return (sameObjectAfterModification, independentCopyUnaffected);
        }

        #endregion

        #region Record - ReferenceType with Value Semantics

        /// <summary>
        /// This sample demonstrates how equality works with records (reference types with value semantics).
        /// Records use VALUE equality by default - two records with the same data ARE equal,
        /// even if they are different objects in memory.
        /// Record is a Reference Type with Value Semantics
        /// </summary>
        /// <returns>Tuple showing reference equality and value equality results</returns>
        public (bool isReferenceEquals, bool isValueEquals, bool isOperatorEquals) SampleEqualsOnRecord()
        {
            // ========================================================================
            // VISUAL MEMORY REPRESENTATION:
            // ========================================================================
            //
            // STACK (Local Variables)          HEAP (PersonRecord Objects)
            // ┌─────────────────┐             ┌─────────────────────────────┐
            // │ personA ────────┼─────────────►│ PersonRecord                │
            // │ (reference)     │             │ ┌─────────────────────────┐ │
            // └─────────────────┘             │ │ Name = "John"            │ │
            // ┌─────────────────┐             │ │ Age = 30                │ │
            // │ personB ────────┼─────────────►│ └─────────────────────────┘ │
            // │ (reference)     │             │ (Object #1)                │
            // └─────────────────┘             └─────────────────────────────┘
            // ┌─────────────────┐             ┌─────────────────────────────┐
            // │ personC ────────┼─────────────►│ PersonRecord                │
            // │ (reference)     │             │ ┌─────────────────────────┐ │
            // └─────────────────┘             │ │ Name = "John"            │ │
            //                                   │ │ Age = 30                │ │
            //                                   │ └─────────────────────────┘ │
            //                                   │ (Object #2 - DIFFERENT!)   │
            //                                   └─────────────────────────────┘
            //
            // KEY POINT: personA and personC point to DIFFERENT objects, BUT
            // they are considered EQUAL because they have the same values!
            // personA == personC returns TRUE (value equality)!
            //
            // ========================================================================
            // KEY CONCEPTS:
            // ========================================================================
            // 1. VALUE EQUALITY: Records use VALUE equality by default. Two records
            //    are equal if they have the same values for all properties, even if
            //    they are different objects in memory.
            //
            // 2. AUTOMATIC EQUALS() IMPLEMENTATION: Records automatically implement
            //    Equals() to compare all properties by value. You don't need to
            //    override it manually.
            //
            // 3. == OPERATOR: Records automatically override == and != operators to
            //    compare by value, not by reference.
            //
            // 4. IMMUTABILITY BY DEFAULT: Records are immutable by default (though
            //    you can make them mutable with the 'init' keyword or mutable properties).
            //
            // 5. WITH EXPRESSIONS: Records support 'with' expressions to create
            //    modified copies: var newRecord = oldRecord with { Age = 31 };
            //
            // ========================================================================
            // STEP-BY-STEP EXECUTION:
            // ========================================================================
            // Step 1: PersonRecord personA = new PersonRecord("John", 30);
            //   - Allocates memory on the HEAP for a new PersonRecord object
            //   - Sets Name = "John" and Age = 30
            //   - Creates a reference on the STACK (personA) pointing to this object
            //   - Memory: personA → PersonRecord object #1
            //
            // Step 2: PersonRecord personB = personA;
            //   - Copies the REFERENCE from personA to personB
            //   - personB now points to the SAME object as personA
            //   - Memory: personA → PersonRecord object #1 ← personB
            //
            // Step 3: PersonRecord personC = new PersonRecord("John", 30);
            //   - Allocates memory on the HEAP for a NEW PersonRecord object
            //   - Sets Name = "John" and Age = 30 (same data as personA)
            //   - Creates a reference on the STACK (personC) pointing to this NEW object
            //   - Memory: personA → PersonRecord object #1
            //            personC → PersonRecord object #2 (DIFFERENT object!)
            //
            // Step 4: Comparisons
            //   - ReferenceEquals(personA, personB) → TRUE (same object)
            //   - ReferenceEquals(personA, personC) → FALSE (different objects)
            //   - personA.Equals(personB) → TRUE (same object)
            //   - personA.Equals(personC) → TRUE (different objects, but SAME VALUES!)
            //   - personA == personB → TRUE (same reference)
            //   - personA == personC → TRUE (same values, even though different references!)
            //
            // ========================================================================
            // COMPARISON: RECORD vs CLASS:
            // ========================================================================
            // RECORD (Value Equality):
            //   PersonRecord a = new PersonRecord("John", 30);
            //   PersonRecord b = new PersonRecord("John", 30);
            //   a == b                    // TRUE (same values)
            //   a.Equals(b)               // TRUE (same values)
            //   ReferenceEquals(a, b)    // FALSE (different objects, but equal by value)
            //
            // CLASS (Reference Equality):
            //   PersonClass a = new PersonClass("John", 30);
            //   PersonClass b = new PersonClass("John", 30);
            //   a == b                    // FALSE (different references)
            //   a.Equals(b)               // FALSE (different references)
            //   ReferenceEquals(a, b)    // FALSE (different objects)
            //
            // ========================================================================
            // WHEN TO USE RECORDS:
            // ========================================================================
            // Use records when:
            // 1. You need value-based equality (two instances with same data are equal)
            // 2. You want immutable data structures
            // 3. You're working with data transfer objects (DTOs)
            // 4. You need with-expressions for creating modified copies
            // 5. You want automatic ToString(), Equals(), GetHashCode() implementations
            //
            // ========================================================================
            // IMMUTABILITY EXAMPLE:
            // ========================================================================
            // Records are immutable by default:
            //
            //   PersonRecord person = new PersonRecord("John", 30);
            //   // person.Age = 31;  // ❌ COMPILE ERROR! Records are immutable
            //
            //   // Use 'with' expression to create a modified copy:
            //   PersonRecord olderPerson = person with { Age = 31 };
            //   // person.Age is still 30, olderPerson.Age is 31
            //
            // ========================================================================
            // WITH EXPRESSIONS:
            // ========================================================================
            // Records support 'with' expressions to create modified copies:
            //
            //   PersonRecord original = new PersonRecord("John", 30);
            //   PersonRecord modified = original with { Age = 31 };
            //   // original is unchanged, modified is a new record with Age = 31
            //
            // ========================================================================

            // Create first person record
            PersonRecord personA = new PersonRecord("John", 30);
            
            // Assign reference - personB points to the SAME object as personA
            PersonRecord personB = personA;
            
            // Create a NEW person record with the SAME data
            // This is a DIFFERENT object in memory, but has the same values
            PersonRecord personC = new PersonRecord("John", 30);

            // Reference equality checks
            bool isReferenceEquals = ReferenceEquals(personA, personB);  // TRUE - same object
            bool isReferenceEqualsDifferent = ReferenceEquals(personA, personC); // FALSE - different objects

            // Value equality checks (records compare by VALUE, not reference)
            bool isValueEquals = personA.Equals(personB);  // TRUE - same object
            bool isValueEqualsDifferent = personA.Equals(personC); // TRUE - different objects, but SAME VALUES!

            // Operator equality (records override == to compare by VALUE)
            bool isOperatorEquals = personA == personB;  // TRUE - same reference
            bool isOperatorEqualsDifferent = personA == personC; // TRUE - same values, even though different references!

            return (isReferenceEquals, isValueEquals, isOperatorEquals);
        }

        /// <summary>
        /// This sample demonstrates immutability and 'with' expressions in records.
        /// Records are immutable by default, and you use 'with' expressions to create
        /// modified copies rather than modifying the original.
        /// </summary>
        public (bool originalUnchanged, bool copyIsNewObject, bool copyHasNewValue) SampleImmutabilityWithRecord()
        {
            // ========================================================================
            // VISUAL MEMORY REPRESENTATION:
            // ========================================================================
            //
            // INITIAL: PersonRecord original = new PersonRecord("Alice", 25);
            // ┌──────────────┐             ┌─────────────────────────────┐
            // │ original ────┼─────────────►│ PersonRecord                │
            // │ (reference)  │             │ Name = "Alice"               │
            // └──────────────┘             │ Age = 25                     │
            //                               └─────────────────────────────┘
            //
            // AFTER: PersonRecord modified = original with { Age = 30 };
            // ┌──────────────┐             ┌─────────────────────────────┐
            // │ original ────┼─────────────►│ PersonRecord                │
            // │ (reference)  │             │ Name = "Alice"               │
            // └──────────────┘             │ Age = 25  ← UNCHANGED!       │
            //                               └─────────────────────────────┘
            // ┌──────────────┐             ┌─────────────────────────────┐
            // │ modified ────┼─────────────►│ PersonRecord                │
            // │ (reference)  │             │ Name = "Alice"               │
            // └──────────────┘             │ Age = 30  ← NEW OBJECT!      │
            //                               └─────────────────────────────┘
            //
            // KEY POINT: 'with' creates a NEW object, original remains unchanged!
            //
            // ========================================================================
            // KEY CONCEPTS:
            // ========================================================================
            // 1. IMMUTABILITY: Records are immutable by default. Once created,
            //    you cannot modify their properties. This ensures thread safety
            //    and prevents accidental mutations.
            //
            // 2. WITH EXPRESSIONS: To create a modified version, use 'with' expressions.
            //    This creates a NEW record object with the specified changes, leaving
            //    the original unchanged.
            //
            // 3. COPY-ON-WRITE: The 'with' expression creates a shallow copy with
            //    the specified properties changed. Other properties are copied as-is.
            //
            // 4. MEMORY EFFICIENCY: Records can share internal data structures when
            //    possible, but each 'with' expression creates a new object.
            //
            // ========================================================================

            PersonRecord original = new PersonRecord("Alice", 25);
            
            // Create a modified copy using 'with' expression
            // This creates a NEW object, original remains unchanged
            PersonRecord modified = original with { Age = 30 };

            // Verify original is unchanged
            bool originalUnchanged = original.Age == 25;  // TRUE - original not modified

            // Verify modified is a different object
            bool copyIsNewObject = !ReferenceEquals(original, modified);  // TRUE - different objects

            // Verify modified has the new value
            bool copyHasNewValue = modified.Age == 30;  // TRUE - new value in copy

            // Both records have the same Name (copied from original)
            bool nameCopied = modified.Name == original.Name;  // TRUE - Name copied

            return (originalUnchanged, copyIsNewObject, copyHasNewValue);
        }

        /// <summary>
        /// This sample demonstrates the difference between Class and Record equality behavior.
        /// It shows side-by-side how classes use reference equality while records use value equality.
        /// </summary>
        public (bool classReferenceEquals, bool classValueEquals, bool recordReferenceEquals, bool recordValueEquals) SampleClassVsRecordComparison()
        {
            // ========================================================================
            // VISUAL COMPARISON:
            // ========================================================================
            //
            // CLASS BEHAVIOR:
            // ┌──────────────┐             ┌─────────────────────────────┐
            // │ classA ──────┼─────────────►│ PersonClass                  │
            // └──────────────┘             │ Name = "John", Age = 30       │
            //                               └─────────────────────────────┘
            // ┌──────────────┐             ┌─────────────────────────────┐
            // │ classB ──────┼─────────────►│ PersonClass                  │
            // └──────────────┘             │ Name = "John", Age = 30       │
            //                               └─────────────────────────────┘
            //                               (DIFFERENT objects)
            // classA == classB → FALSE (different references)
            // classA.Equals(classB) → FALSE (different references)
            //
            // RECORD BEHAVIOR:
            // ┌──────────────┐             ┌─────────────────────────────┐
            // │ recordA ─────┼─────────────►│ PersonRecord                 │
            // └──────────────┘             │ Name = "John", Age = 30      │
            //                               └─────────────────────────────┘
            // ┌──────────────┐             ┌─────────────────────────────┐
            // │ recordB ─────┼─────────────►│ PersonRecord                 │
            // └──────────────┘             │ Name = "John", Age = 30      │
            //                               └─────────────────────────────┘
            //                               (DIFFERENT objects, but...)
            // recordA == recordB → TRUE (same values!)
            // recordA.Equals(recordB) → TRUE (same values!)
            //
            // ========================================================================

            // Create two class instances with same data
            PersonClass classA = new PersonClass("John", 30);
            PersonClass classB = new PersonClass("John", 30);

            // Create two record instances with same data
            PersonRecord recordA = new PersonRecord("John", 30);
            PersonRecord recordB = new PersonRecord("John", 30);

            // Class comparisons (reference equality)
            bool classReferenceEquals = ReferenceEquals(classA, classB);  // FALSE - different objects
            bool classValueEquals = classA.Equals(classB);  // FALSE - different references (default behavior)

            // Record comparisons (value equality)
            bool recordReferenceEquals = ReferenceEquals(recordA, recordB);  // FALSE - different objects
            bool recordValueEquals = recordA.Equals(recordB);  // TRUE - same values!

            return (classReferenceEquals, classValueEquals, recordReferenceEquals, recordValueEquals);
        }

        #endregion
    }
}
