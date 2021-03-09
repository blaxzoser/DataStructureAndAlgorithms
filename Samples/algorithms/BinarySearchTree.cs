using System.Diagnostics;

namespace Samples.algorithms 
{
    public class BinarySearchTree
    {
        private Node _root;
        public Node Root => _root;
        public class Node
        {
            public string Value   { get; set; }
            public int Key   { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int key, string value)
            {
                Key = key;
                Value = value;
            }

            public Node Min()
            {
                if (Left == null)
                {
                    return this;
                }
                else
                {
                    return Left.Min();
                }
            }
        }

        public BinarySearchTree()
        {
            _root = null;
        }

        // Find
        public string Find(int key)
        {
            // First find the node
            Node node = Find(_root, key);

            // Then return the value
            return node == null ? null : node.Value;
        }

        private Node Find(Node node, int key)
        {
            if (node == null || node.Key == key)
            {
                return node;
            }
            else if (key < node.Key)
            {
                return Find(node.Left, key);
            }
            else if (key > node.Key)
            {
                return Find(node.Right, key);
            }
            return null;

            // Note: Duplicate keys aren't allowed (so we don't need to check for that)
        }

        // Insert
        public void Insert(int key, string value)
        {
            _root = InsertItem(_root, key, value);
        }

        public Node InsertItem(Node node, int key, string value)
        {
            // If null - set it here. We are done.
            if (node == null)
            {
                node = new Node(key, value); ;
                return node;
            }

            // Else
            // Walk until you find a node
            // that is null and set it there
            if (key < node.Key)
            {
                node.Left = InsertItem(node.Left, key, value);
            }
            if (key > node.Key)
            {
                node.Right = InsertItem(node.Right, key, value);
            }

            // If we get here we have have hit the bottom our or tree with a duplicate.
            // Since duplicates are not allowed in BSTs, simply ignore the duplicate,
            // and return our fully constructed tree. We are done!
            return node;
        }

        public bool CheckBST(Node root)
        {

            // left smaller
            bool leftOK = false;

            if (root.Left != null)
            {
                if (root.Left.Key < root.Key)
                {
                    leftOK = true;
                }
            }
            else
            {
                leftOK = true;
            }

            // right larger
            bool rightOK = false;

            if (root.Right != null)
            {
                if (root.Right.Key > root.Key)
                {
                    rightOK = true;
                }
            }
            else
            {
                rightOK = true;
            }

            // get distinct check for free via <>
            return leftOK && rightOK;
        }

        #region Delete 
        // Delete: Three cases
        // 1. No child
        // 2. One child
        // 3. Two children

        // First two are simple. Third is more complex.

        // Case 1: No child - simply remove from tree by nulling it.
        //
        // Case 2: One child - copy the child to the node to be deleted and delete the child

        // Case 3: Two children - re-gig the tree to turn into a Case 1 or a Case 2

        // For third case we first need to
        // 1. Find the right side min
        // 2. Copy it to the node we want to delete (creating a duplicate)
        // 3. Then delete the min value way down on the branch we just copied
        //
        // This works because you can represent a binary tree in more than one way.
        // Here we are taking advantage of that fact to make our more complicated
        // 3rd case delete more simple by transforming it into case 1.

        // Step 1: Create a minvalue function
        public int FindMinKey()
        {
            return FindMin(_root).Key;
        }

        public Node FindMin(Node node)
        {
            return node.Min();
        }

        public void Delete(int key)
        {
            _root = Delete(_root, key);
        }

        public Node Delete(Node node, int key)
        {
            if (node == null)
            {
                return null;
            }
            else if (key < node.Key)
            {
                node.Left = Delete(node.Left, key);
            }
            else if (key > node.Key)
            {
                node.Right = Delete(node.Right, key);
            }
            else
            { // Woohoo! Found you. This is the node we want to delete.

                // Case 1: No child
                if (node.Left == null && node.Right == null)
                {
                    node = null;
                }

                // Case 2: One child
                else if (node.Left == null)
                {
                    node = node.Right;
                }
                else if (node.Right == null)
                {
                    node = node.Left;
                }

                // Case 3: Two children
                else
                {
                    // Find the minimum node on the right (could also max the left...)
                    Node minRight = FindMin(node.Right);

                    // Duplicate it by copying its values here
                    node.Key = minRight.Key;
                    node.Value = minRight.Value;

                    // Now go ahead and delete the node we just duplicated (same key)
                    node.Right = Delete(node.Right, node.Key);
                }
            }

            return node;
        }

        #endregion 

        #region Print Binary Search Tree

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

        public void PrintPreOrderTraversal()
        {
            PreOrderTraversal(_root);
        }

        private void PreOrderTraversal(Node node)
        {
            if (node != null)
            {
                Debug.WriteLine(node.Key); // root
                PreOrderTraversal(node.Left);
                PreOrderTraversal(node.Right);
            }
        }

        public void PrintPostOrderTraversal()
        {
            PostOrderTraversal(_root);
        }

        private void PostOrderTraversal(Node node)
        {
            if (node != null)
            {
                PostOrderTraversal(node.Left);
                PostOrderTraversal(node.Right);
                Debug.WriteLine(node.Key);
            }
        }

        public void PrettyPrint()
        {
            // Hard coded print out of binary tree depth = 3

            int rootLeftKey = _root.Left == null ? 0 : _root.Left.Key;
            int rootRightKey = _root.Right == null ? 0 : _root.Right.Key;

            int rootLeftLeftKey = 0;
            int rootLeftRightKey = 0;

            if (_root.Left != null)
            {
                rootLeftLeftKey = _root.Left.Left == null ? 0 : _root.Left.Left.Key;
                rootLeftRightKey = _root.Left.Right == null ? 0 : _root.Left.Right.Key;
            }

            int rootRightLeftKey = 0;
            int rootRightRightKey = 0;

            if (_root.Right != null)
            {
                rootRightLeftKey = _root.Right.Left == null ? 0 : _root.Right.Left.Key;
                rootRightRightKey = _root.Right.Right == null ? 0 : _root.Right.Right.Key;
            }

            Debug.WriteLine("     " + _root.Key);
            Debug.WriteLine("   /  \\");
            Debug.WriteLine("  " + rootLeftKey + "    " + rootRightKey);
            Debug.WriteLine(" / \\  / \\");
            Debug.WriteLine(rootLeftLeftKey + "  " + rootLeftRightKey + " " + rootRightLeftKey + "   " + rootRightRightKey);
        }

        #endregion
    }
}
