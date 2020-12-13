using NUnit.Framework;
using Samples.algorithms;

namespace Test.algorithms
{
    public class BinarySearchTreeTest
    {
        private BinarySearchTree _binarySearchTree;
        
        [SetUp]
        public void Setup()
        {
            _binarySearchTree = new BinarySearchTree();
        }

        [Test]
        public void Insert()
        {
            _binarySearchTree.Insert(5, "e");
            _binarySearchTree.Insert(3, "c");
            _binarySearchTree.Insert(2, "b");
            _binarySearchTree.Insert(4, "d");
            _binarySearchTree.Insert(7, "g");
            _binarySearchTree.Insert(6, "f");
            _binarySearchTree.Insert(8, "h");

            Assert.AreEqual("e", _binarySearchTree.Find(5));
            Assert.AreEqual("c", _binarySearchTree.Find(3));
            Assert.AreEqual("b", _binarySearchTree.Find(2));
            Assert.AreEqual("d", _binarySearchTree.Find(4));
            Assert.AreEqual("g", _binarySearchTree.Find(7));
            Assert.AreEqual("f", _binarySearchTree.Find(6));
            Assert.AreEqual("h", _binarySearchTree.Find(8));
            Assert.AreEqual(null, _binarySearchTree.Find(99));

            _binarySearchTree.PrettyPrint();

            //_binarySearchTree.PrintInOrderTraversal();
            //_binarySearchTree.PrintPreOrderTraversal();
            //_binarySearchTree.PrintPostOrderTraversal();
        }



        [Test]
        public void MinKey()
        {
            _binarySearchTree.Insert(5, "e");
            _binarySearchTree.Insert(3, "c");
            _binarySearchTree.Insert(2, "b");
            _binarySearchTree.PrettyPrint();
            Assert.AreEqual(2, _binarySearchTree.FindMinKey());
        }


        [Test]
        public void DeleteNoChild()
        {
            _binarySearchTree.Insert(5, "e");
            _binarySearchTree.Insert(3, "c");
            _binarySearchTree.Insert(2, "b");
            _binarySearchTree.Insert(4, "d");
            _binarySearchTree.Insert(7, "g");
            _binarySearchTree.Insert(6, "f");
            _binarySearchTree.Insert(8, "h");
            _binarySearchTree.PrettyPrint();

            _binarySearchTree.Delete(2);

            Assert.Null(_binarySearchTree.Find(2));

            _binarySearchTree.PrettyPrint();
        }


        [Test]
        public void DeleteOneChild()
        {
            _binarySearchTree.Insert(5, "e");
            _binarySearchTree.Insert(3, "c");
            _binarySearchTree.Insert(2, "b");
            _binarySearchTree.Insert(4, "d");
            _binarySearchTree.Insert(7, "g");
            _binarySearchTree.Insert(6, "f");
            //        bst.insert(8, "h");
            _binarySearchTree.PrettyPrint();

            _binarySearchTree.Delete(7);
            Assert.Null(_binarySearchTree.Find(7));
            _binarySearchTree.PrettyPrint();
        }

        [Test]
        public void DeleteTwoChildren()
        {
            _binarySearchTree.Insert(5, "e");
            _binarySearchTree.Insert(3, "c");
            _binarySearchTree.Insert(2, "b");
            _binarySearchTree.Insert(4, "d");
            _binarySearchTree.Insert(7, "g");
            _binarySearchTree.Insert(6, "f");
            _binarySearchTree.Insert(8, "h");
            _binarySearchTree.PrettyPrint();

            _binarySearchTree.Delete(7);
            Assert.Null(_binarySearchTree.Find(7));
            _binarySearchTree.PrettyPrint();
        }

        [Test]
        public void CheckBST1()
        {
            _binarySearchTree.Insert(5, "e");
            _binarySearchTree.Insert(3, "c");
            _binarySearchTree.Insert(2, "b");
            _binarySearchTree.Insert(4, "d");
            _binarySearchTree.Insert(7, "g");
            _binarySearchTree.Insert(6, "f");

            _binarySearchTree.PrettyPrint();
            Assert.IsTrue(_binarySearchTree.CheckBST(_binarySearchTree.Root));
        }

    }
}
