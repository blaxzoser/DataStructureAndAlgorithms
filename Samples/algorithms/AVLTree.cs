using System.Diagnostics;

namespace Samples.algorithms
{
    public class Node
    {
        public int Key { get; set; }
        public int Height { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int d)
        {
            Key = d;
            Height = 1;
        }
    }

    /// <summary>
    /// Regular BST Insert
    /// Track the height
    /// Determine balance factor======= difference in height cant be>1
    /// 4 cases
    /// </summary>
    public class AVLTree
    {
        private Node _root;

        // A utility function to get the height of the tree
        public int Height(Node N) => N == null ? 0 : N.Height;

        // A utility function to get maximum of two integers
        public int Max(int a, int b) => (a > b) ? a : b;


        // A utility function to right rotate subtree rooted with y
        // See the diagram given above.
        public Node RightRotate(Node y)
        {
            Node x = y.Left;
            Node T2 = x.Right;

            // Perform rotation
            x.Right = y;
            y.Left = T2;

            // Update heights
            y.Height = Max(Height(y.Left), Height(y.Right)) + 1;
            x.Height = Max(Height(x.Left), Height(x.Right)) + 1;

            // Return new root
            return x;
        }

        // A utility function to left rotate subtree rooted with x
        // See the diagram given above.
        public Node LeftRotate(Node x)
        {
            Node y = x.Right;
            Node T2 = y.Left;

            // Perform rotation
            y.Left = x;
            x.Right = T2;

            //  Update heights
            x.Height = Max(Height(x.Left), Height(x.Right)) + 1;
            y.Height = Max(Height(y.Left), Height(y.Right)) + 1;

            // Return new root
            return y;
        }

        // Get Balance factor of node N
        public int GetBalance(Node N)
        {
            if (N == null)
                return 0;

            return Height(N.Left) - Height(N.Right);
        }

        void Insert(int key)
        {
            _root = Insert(_root, key);
        }

        public Node Insert(Node node, int key)
        {

            /* 1.  Perform the normal BST insertion */
            if (node == null)
                return (new Node(key));

            if (key < node.Key)
                node.Left = Insert(node.Left, key);
            else if (key > node.Key)
                node.Right = Insert(node.Right, key);
            else // Duplicate keys not allowed
                return node;

            /* 2. Update height of this ancestor node */
            node.Height = 1 + Max(Height(node.Left),
                    Height(node.Right));

            /* 3. Get the balance factor of this ancestor
                  node to check whether this node became
                  unbalanced */
            int balance = GetBalance(node);

            // If this node becomes unbalanced, then there
            // are 4 cases Left Left Case
            if (balance > 1 && key < node.Left.Key)
            {
                return RightRotate(node);
            }

            // Right Right Case
            if (balance < -1 && key > node.Right.Key)
            {
                return LeftRotate(node);
            }

            // Left Right Case
            if (balance > 1 && key > node.Left.Key)
            {
                node.Left = LeftRotate(node.Left);
                return RightRotate(node);
            }

            // Right Left Case
            if (balance < -1 && key < node.Right.Key)
            {
                node.Right = RightRotate(node.Right);
                return LeftRotate(node);
            }

            /* return the (unchanged) node pointer */
            return node;
        }


        public void PrintInOrderTraversal()
        {
            InOrderTraversal(_root);
        }

        private void InOrderTraversal(Node node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Debug.WriteLine(node.Key);
                InOrderTraversal(node.Right);
            }
        }
    }
}
