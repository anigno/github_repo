//====================================================
//| Downloaded From                                  |
//| Visual C# Kicks - http://www.vcskicks.com/       |
//| License - http://www.vcskicks.com/license.html   |
//====================================================

using System;
using System.Collections;
using System.Collections.Generic;

namespace AnignoraDataTypes.Trees.AVLTrees
{
    /// <summary>
    /// A Binary Tree node that holds an element and references to other tree nodes
    /// </summary>
    public class BinaryTreeNode<T> where T : IComparable
    {

		#region (------  Fields  ------)


        private BinaryTree<T> tree;
        private BinaryTreeNode<T> leftChild;
        private BinaryTreeNode<T> rightChild;
        private BinaryTreeNode<T> parent;

        private T value;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        /// <summary>
        /// Create a new instance of a Binary Tree node
        /// </summary>
        public BinaryTreeNode(T value)
        {
            this.value = value;
        }

		#endregion (------  Constructors  ------)

		#region (------  Read only Properties  ------)

        /// <summary>
        /// Gets the number of children this node has
        /// </summary>
        public virtual int ChildCount
        {
            get
            {
                int count = 0;

                if (this.LeftChild != null)
                    count++;

                if (this.RightChild != null)
                    count++;

                return count;
            }
        }

        /// <summary>
        /// Gets whether the node has a left child node
        /// </summary>
        public virtual bool HasLeftChild
        {
            get { return (this.LeftChild != null); }
        }

        /// <summary>
        /// Gets whether the node has a right child node
        /// </summary>
        public virtual bool HasRightChild
        {
            get { return (this.RightChild != null); }
        }

        /// <summary>
        /// Gets whether the node is internal (has children nodes)
        /// </summary>
        public virtual bool IsInternal
        {
            get { return this.ChildCount > 0; }
        }

        /// <summary>
        /// Gets whether the node is a leaf (has no children)
        /// </summary>
        public virtual bool IsLeaf
        {
            get { return this.ChildCount == 0; }
        }

        /// <summary>
        /// Gets whether the node is the left child of its parent
        /// </summary>
        public virtual bool IsLeftChild
        {
            get { return this.Parent.LeftChild == this; }
        }

        /// <summary>
        /// Gets whether the node is the right child of its parent
        /// </summary>
        public virtual bool IsRightChild
        {
            get { return this.Parent.RightChild == this; }
        }

		#endregion (------  Read only Properties  ------)

		#region (------  Properties  ------)


        /// <summary>
        /// Gets or sets the Binary Tree the node belongs to
        /// </summary>
        public virtual BinaryTree<T> Tree
        {
            get { return tree; }
            set { tree = value; }
        }

        /// <summary>
        /// Gets or sets the left child node
        /// </summary>
        public virtual BinaryTreeNode<T> LeftChild
        {
            get { return leftChild; }
            set { leftChild = value; }
        }

        /// <summary>
        /// Gets or sets the right child node
        /// </summary>
        public virtual BinaryTreeNode<T> RightChild
        {
            get { return rightChild; }
            set { rightChild = value; }
        }

        /// <summary>
        /// Gets or sets the parent node
        /// </summary>
        public virtual BinaryTreeNode<T> Parent
        {
            get { return parent; }
            set { parent = value; }
        }


        /// <summary>
        /// The value stored at the node
        /// </summary>
        public virtual T Value
        {
            get { return value; }
            set { this.value = value; }
        }


		#endregion (------  Properties  ------)

    }

    /// <summary>
    /// Binary Tree data structure
    /// </summary>
    public class BinaryTree<T> : ICollection<T> where T : IComparable
    {

		#region (------  Enums  ------)

        /// <summary>
        /// Specifies the mode of scanning through the tree
        /// </summary>
        public enum TraversalMode
        {
            InOrder = 0,
            PostOrder,
            PreOrder
        }

		#endregion (------  Enums  ------)

		#region (------  Fields  ------)


private BinaryTreeNode<T> head;
        private Comparison<IComparable> comparer = CompareElements;

        private int size;

        private TraversalMode traversalMode = TraversalMode.InOrder;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

        /// <summary>
        /// Creates a new instance of a Binary Tree
        /// </summary>
        public BinaryTree()
        {
            head = null;
            size = 0;
        }

		#endregion (------  Constructors  ------)

		#region (------  Read only Properties  ------)

        /// <summary>
        /// Gets the number of elements stored in the tree
        /// </summary>
        public virtual int Count
        {
            get { return size; }
        }

        /// <summary>
        /// Gets whether the tree is read-only
        /// </summary>
        public virtual bool IsReadOnly
        {
            get { return false; }
        }

		#endregion (------  Read only Properties  ------)

		#region (------  Properties  ------)


        /// <summary>
        /// Gets or sets the root of the tree (the top-most node)
        /// </summary>
        public virtual BinaryTreeNode<T> Root
        {
            get { return head; }
            set { head = value; }
        }


        /// <summary>
        /// Gets or sets the traversal mode of the tree
        /// </summary>
        public virtual TraversalMode TraversalOrder
        {
            get { return traversalMode; }
            set { traversalMode = value; }
        }


		#endregion (------  Properties  ------)

		#region (------  Static Methods  ------)

        /// <summary>
        /// Compares two elements to determine their positions within the tree.
        /// </summary>
        public static int CompareElements(IComparable x, IComparable y)
        {
            return x.CompareTo(y);
        }

		#endregion (------  Static Methods  ------)

		#region (------  Private Methods  ------)

        /// <summary>
        /// Returns an enumerator to scan through the elements stored in tree.
        /// The enumerator uses the traversal set in the TraversalMode property.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

		#endregion (------  Private Methods  ------)

		#region (------  Public Methods  ------)

        /// <summary>
        /// Adds a new element to the tree
        /// </summary>
        public virtual void Add(T value)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(value);
            this.Add(node);
        }

        /// <summary>
        /// Adds a node to the tree
        /// </summary>
        public virtual void Add(BinaryTreeNode<T> node)
        {
            if (this.head == null) //first element being added
            {
                this.head = node; //set node as root of the tree
                node.Tree = this;
                size++;
            }
            else
            {
                if (node.Parent == null)
                    node.Parent = head; //start at head

                //Node is inserted on the left side if it is smaller or equal to the parent
                bool insertLeftSide = comparer((IComparable)node.Value, (IComparable)node.Parent.Value) <= 0;

                if (insertLeftSide) //insert on the left
                {
                    if (node.Parent.LeftChild == null)
                    {
                        node.Parent.LeftChild = node; //insert in left
                        size++;
                        node.Tree = this; //assign node to this binary tree
                    }
                    else
                    {
                        node.Parent = node.Parent.LeftChild; //scan down to left child
                        this.Add(node); //recursive call
                    }
                }
                else //insert on the right
                {
                    if (node.Parent.RightChild == null)
                    {
                        node.Parent.RightChild = node; //insert in right
                        size++;
                        node.Tree = this; //assign node to this binary tree
                    }
                    else
                    {
                        node.Parent = node.Parent.RightChild;
                        this.Add(node);
                    }
                }
            }
        }

        /// <summary>
        /// Removes all the elements stored in the tree
        /// </summary>
        public virtual void Clear()
        {
            //Remove children first, then parent
            //(Post-order traversal)
            IEnumerator<T> enumerator = GetPostOrderEnumerator();
            while (enumerator.MoveNext())
            {
                this.Remove(enumerator.Current);
            }
            enumerator.Dispose();
        }

        /// <summary>
        /// Returns whether a value is stored in the tree
        /// </summary>
        public virtual bool Contains(T value)
        {
            return (this.Find(value) != null);
        }

        /// <summary>
        /// Copies the elements in the tree to an array using the traversal mode specified.
        /// </summary>
        public virtual void CopyTo(T[] array)
        {
            this.CopyTo(array, 0);
        }

        /// <summary>
        /// Copies the elements in the tree to an array using the traversal mode specified.
        /// </summary>
        public virtual void CopyTo(T[] array, int startIndex)
        {
            IEnumerator<T> enumerator = this.GetEnumerator();

            for (int i = startIndex; i < array.Length; i++)
            {
                if (enumerator.MoveNext())
                    array[i] = enumerator.Current;
                else
                    break;
            }
        }

        /// <summary>
        /// Returns the first node in the tree with the parameter value.
        /// </summary>
        public virtual BinaryTreeNode<T> Find(T value)
        {
            BinaryTreeNode<T> node = this.head; //start at head
            while (node != null)
            {
                if (node.Value.Equals(value)) //parameter value found
                    return node;
                else
                {
                    //Search left if the value is smaller than the current node
                    bool searchLeft = comparer((IComparable)value, (IComparable)node.Value) < 0;

                    if (searchLeft)
                        node = node.LeftChild; //search left
                    else
                        node = node.RightChild; //search right
                }
            }

            return null; //not found
        }

        /// <summary>
        /// Returns the depth of a subtree rooted at the parameter value
        /// </summary>
        public virtual int GetDepth(T value)
        {
            BinaryTreeNode<T> node = this.Find(value);
            return this.GetDepth(node);
        }

        /// <summary>
        /// Returns the depth of a subtree rooted at the parameter node
        /// </summary>
        public virtual int GetDepth(BinaryTreeNode<T> startNode)
        {
            int depth = 0;

            if (startNode == null)
                return depth;

            BinaryTreeNode<T> parentNode = startNode.Parent; //start a node above
            while (parentNode != null)
            {
                depth++;
                parentNode = parentNode.Parent; //scan up towards the root
            }

            return depth;
        }

        /// <summary>
        /// Returns an enumerator to scan through the elements stored in tree.
        /// The enumerator uses the traversal set in the TraversalMode property.
        /// </summary>
        public virtual IEnumerator<T> GetEnumerator()
        {
            switch (this.TraversalOrder)
            {
                case TraversalMode.InOrder:
                    return GetInOrderEnumerator();
                case TraversalMode.PostOrder:
                    return GetPostOrderEnumerator();
                case TraversalMode.PreOrder:
                    return GetPreOrderEnumerator();
                default:
                    return GetInOrderEnumerator();
            }
        }

        /// <summary>
        /// Returns the height of the entire tree
        /// </summary>
        public virtual int GetHeight()
        {
            return this.GetHeight(this.Root);
        }

        /// <summary>
        /// Returns the height of the subtree rooted at the parameter value
        /// </summary>
        public virtual int GetHeight(T value)
        {
            //Find the value's node in tree
            BinaryTreeNode<T> valueNode = this.Find(value);
            if (value != null)
                return this.GetHeight(valueNode);
            else
                return 0;
        }

        /// <summary>
        /// Returns the height of the subtree rooted at the parameter node
        /// </summary>
        public virtual int GetHeight(BinaryTreeNode<T> startNode)
        {
            if (startNode == null)
                return 0;
            else
                return 1 + Math.Max((sbyte) GetHeight(startNode.LeftChild), (sbyte) GetHeight(startNode.RightChild));
        }

        /// <summary>
        /// Returns an enumerator that visits node in the order: left child, parent, right child
        /// </summary>
        public virtual IEnumerator<T> GetInOrderEnumerator()
        {
            return new BinaryTreeInOrderEnumerator(this);
        }

        /// <summary>
        /// Returns an enumerator that visits node in the order: left child, right child, parent
        /// </summary>
        public virtual IEnumerator<T> GetPostOrderEnumerator()
        {
            return new BinaryTreePostOrderEnumerator(this);
        }

        /// <summary>
        /// Returns an enumerator that visits node in the order: parent, left child, right child
        /// </summary>
        public virtual IEnumerator<T> GetPreOrderEnumerator()
        {
            return new BinaryTreePreOrderEnumerator(this);
        }

        /// <summary>
        /// Removes a value from the tree and returns whether the removal was successful.
        /// </summary>
        public virtual bool Remove(T value)
        {
            BinaryTreeNode<T> removeNode = Find(value);

            return this.Remove(removeNode);
        }

        /// <summary>
        /// Removes a node from the tree and returns whether the removal was successful.
        /// </summary>>
        public virtual bool Remove(BinaryTreeNode<T> removeNode)
        {
            if (removeNode == null || removeNode.Tree != this)
                return false; //value doesn't exist or not of this tree

            //Note whether the node to be removed is the root of the tree
            bool wasHead = (removeNode == head);

            if (this.Count == 1)
            {
                this.head = null; //only element was the root
                removeNode.Tree = null;
            }
            else if (removeNode.IsLeaf) //Case 1: No Children
            {
                //Remove node from its parent
                if (removeNode.IsLeftChild)
                    removeNode.Parent.LeftChild = null;
                else
                    removeNode.Parent.RightChild = null;

                removeNode.Tree = null;
                removeNode.Parent = null;
            }
            else if (removeNode.ChildCount == 1) //Case 2: One Child
            {
                if (removeNode.HasLeftChild)
                {
                    //Put left child node in place of the node to be removed
                    removeNode.LeftChild.Parent = removeNode.Parent; //update parent

                    if (wasHead)
                        this.Root = removeNode.LeftChild; //update root reference if needed

                    if (removeNode.IsLeftChild) //update the parent's child reference
                        removeNode.Parent.LeftChild = removeNode.LeftChild;
                    else
                        removeNode.Parent.RightChild = removeNode.LeftChild;
                }
                else //Has right child
                {
                    //Put left node in place of the node to be removed
                    removeNode.RightChild.Parent = removeNode.Parent; //update parent

                    if (wasHead)
                        this.Root = removeNode.RightChild; //update root reference if needed

                    if (removeNode.IsLeftChild) //update the parent's child reference
                        removeNode.Parent.LeftChild = removeNode.RightChild;
                    else
                        removeNode.Parent.RightChild = removeNode.RightChild;
                }

                removeNode.Tree = null;
                removeNode.Parent = null;
                removeNode.LeftChild = null;
                removeNode.RightChild = null;
            }
            else //Case 3: Two Children
            {
                //Find inorder predecessor (right-most node in left subtree)
                BinaryTreeNode<T> successorNode = removeNode.LeftChild;
                while (successorNode.RightChild != null)
                {
                    successorNode = successorNode.RightChild;
                }

                removeNode.Value = successorNode.Value; //replace value

                this.Remove(successorNode); //recursively remove the inorder predecessor
            }

            size--; //decrease total element count
            return true;
        }

		#endregion (------  Public Methods  ------)

		#region (------  Nested Classes  ------)


        /// <summary>
        /// Returns an inorder-traversal enumerator for the tree values
        /// </summary>
        internal class BinaryTreeInOrderEnumerator : IEnumerator<T>
        {

		#region (------  Fields  ------)


            private BinaryTree<T> tree;
            private BinaryTreeNode<T> current;
            internal Queue<BinaryTreeNode<T>> traverseQueue;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

            public BinaryTreeInOrderEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;

                //Build queue
                traverseQueue = new Queue<BinaryTreeNode<T>>();
                visitNode(this.tree.Root);
            }

		#endregion (------  Constructors  ------)

		#region (------  Read only Properties  ------)

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

		#endregion (------  Read only Properties  ------)

		#region (------  Private Methods  ------)

            private void visitNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                    return;
                else
                {
                    visitNode(node.LeftChild);
                    traverseQueue.Enqueue(node);
                    visitNode(node.RightChild);
                }
            }

		#endregion (------  Private Methods  ------)

		#region (------  Public Methods  ------)

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public bool MoveNext()
            {
                if (traverseQueue.Count > 0)
                    current = traverseQueue.Dequeue();
                else
                    current = null;

                return (current != null);
            }

            public void Reset()
            {
                current = null;
            }

		#endregion (------  Public Methods  ------)

        }
        /// <summary>
        /// Returns a postorder-traversal enumerator for the tree values
        /// </summary>
        internal class BinaryTreePostOrderEnumerator : IEnumerator<T>
        {

		#region (------  Fields  ------)


            private BinaryTree<T> tree;
            private BinaryTreeNode<T> current;
            internal Queue<BinaryTreeNode<T>> traverseQueue;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

            public BinaryTreePostOrderEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;

                //Build queue
                traverseQueue = new Queue<BinaryTreeNode<T>>();
                visitNode(this.tree.Root);
            }

		#endregion (------  Constructors  ------)

		#region (------  Read only Properties  ------)

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

		#endregion (------  Read only Properties  ------)

		#region (------  Private Methods  ------)

            private void visitNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                    return;
                else
                {
                    visitNode(node.LeftChild);
                    visitNode(node.RightChild);
                    traverseQueue.Enqueue(node);
                }
            }

		#endregion (------  Private Methods  ------)

		#region (------  Public Methods  ------)

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public bool MoveNext()
            {
                if (traverseQueue.Count > 0)
                    current = traverseQueue.Dequeue();
                else
                    current = null;

                return (current != null);
            }

            public void Reset()
            {
                current = null;
            }

		#endregion (------  Public Methods  ------)

        }
        /// <summary>
        /// Returns an preorder-traversal enumerator for the tree values
        /// </summary>
        internal class BinaryTreePreOrderEnumerator : IEnumerator<T>
        {

		#region (------  Fields  ------)


            private BinaryTree<T> tree;
            private BinaryTreeNode<T> current;
            internal Queue<BinaryTreeNode<T>> traverseQueue;

		#endregion (------  Fields  ------)

		#region (------  Constructors  ------)

            public BinaryTreePreOrderEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;

                //Build queue
                traverseQueue = new Queue<BinaryTreeNode<T>>();
                visitNode(this.tree.Root);
            }

		#endregion (------  Constructors  ------)

		#region (------  Read only Properties  ------)

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

		#endregion (------  Read only Properties  ------)

		#region (------  Private Methods  ------)

            private void visitNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                    return;
                else
                {
                    traverseQueue.Enqueue(node);
                    visitNode(node.LeftChild);
                    visitNode(node.RightChild);
                }
            }

		#endregion (------  Private Methods  ------)

		#region (------  Public Methods  ------)

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public bool MoveNext()
            {
                if (traverseQueue.Count > 0)
                    current = traverseQueue.Dequeue();
                else
                    current = null;

                return (current != null);
            }

            public void Reset()
            {
                current = null;
            }

		#endregion (------  Public Methods  ------)

        }
		#endregion (------  Nested Classes  ------)

    }
}