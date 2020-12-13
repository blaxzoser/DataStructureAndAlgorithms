using NUnit.Framework;
using Samples.algorithms;

namespace Test.algorithms
{
    public class AVLTreeTest
    {
        private AVLTree _avlTree;

        [SetUp]
        public void SetUp()
        {
            _avlTree = new AVLTree();
        }

        [Test]
        public void LeftLeft()
        {
            _avlTree.Insert(30);
            _avlTree.Insert(20);
            _avlTree.Insert(10);

            _avlTree.PrintInOrderTraversal();

            /*
                  30
                 /         20
               20    >    /  \
              /         10    30
            10
             */
        }

        [Test]
        public void RightRight()
        {
            _avlTree.Insert(30);
            _avlTree.Insert(40);
            _avlTree.Insert(50);

            _avlTree.PrintInOrderTraversal();

            /*
            30
              \             40
              40      >    /  \
                \        30    50
                 50
             */
        }

        [Test]
        public void LeftRight()
        {
            _avlTree.Insert(30);
            _avlTree.Insert(20);
            _avlTree.Insert(25);

            _avlTree.PrintInOrderTraversal();

            /*
               30           30
              /            /          25
            20      >    25     >    /  \
              \         /          20    30
              25      20
             */
        }

        [Test]
        public void RightLeft()
        {
            _avlTree.Insert(30);
            _avlTree.Insert(40);
            _avlTree.Insert(35);

            _avlTree.PrintInOrderTraversal();

            /*
            30          30
              \           \             35
               40   >      35   >      /  \
              /              \       30    40
            35                40
             */
        }
    }
}
