//Task06
//Define the data structure binary search tree with operations for "adding new element", "searching element" and "deleting elements". 
//It is not necessary to keep the tree balanced. Implement the standard methods from System.Object – ToString(), Equals(…), GetHashCode()
//and the operators for comparison  == and !=. Add and implement the ICloneable interface for deep copy of the tree. 
//Remark: Use two types – structure BinarySearchTree (for the tree) and class TreeNode (for the tree elements). 
//Implement IEnumerable<T> to traverse the tree.


using System;
using System.Collections.Generic;

namespace StudentSystem
{
    //------
    //Task06
    //------
    public struct BinarySearchTree<T> : IEnumerable<T>, ICloneable where T : IComparable
    {
        public TreeNode<T> Root { get; private set; }

        public BinarySearchTree(T value):this()
        {
            this.Root = new TreeNode<T>(value);
        }

        //Adds a new value under the TreeNode
        public bool AddElement(T pValue)
        {
            TreeNode<T> parentNode;
            TreeNode<T> currentNode;

            if (!FindNodeAndParent(pValue, out parentNode, out currentNode))
            {
                TreeNode<T> newNode = new TreeNode<T>(pValue);

                if (parentNode.Value.CompareTo(pValue) > 0)
                    parentNode.Left = newNode;
                else
                    parentNode.Right = newNode;
                return true;
            }
            else
                return false;
        }

        //Delete element
        public bool DeleteElement(T pValue)
        {
            TreeNode<T> parentNode;
            TreeNode<T> currentNode;

            if (FindNodeAndParent(pValue, out parentNode, out currentNode))
            {
                //If the found node has no child nodes then it is OK to delete
                if (currentNode.Left != null || currentNode.Right != null)
                    throw new InvalidOperationException(String.Format("The element you want to delete has child elements!"));
                else if (parentNode == currentNode)
                    throw new InvalidOperationException(String.Format("The element you want to delete is the root element!"));
                else
                {
                    if (parentNode.Left == currentNode)
                        parentNode.Left = null;
                    else
                        parentNode.Right = null;
                }
    
                return true;
            }
            else
                return false;
        }

        //Searches a node with a given value. 
        //If the search succeeds the method returns true and returns in the resultNode the found node
        //If the search fails the method returns false and null as resultNode
        public bool FindNode(T searchValue, out TreeNode<T> resultNode)
        {
            TreeNode<T> parentNode;
            bool result = FindNodeAndParent(searchValue, out parentNode, out resultNode);
            if (result == false)
                resultNode = null;

            return result;
        }

        //Searches a node with a given value. 
        //If the search succeeds the method returns true and returns as output parameters the parent node and the found node
        //If the search fails the method returns false and returns as output parameters the last node found and null
        public bool FindNodeAndParent(T searchValue, out TreeNode<T> parentNode, out TreeNode<T> currentNode)
        {
            bool resultFound = false;

            currentNode = this.Root;
            parentNode = this.Root;

            while ((!resultFound) && (currentNode != null))
            {
                int resultCompare = currentNode.Value.CompareTo(searchValue);
                if (resultCompare == 0)
                    resultFound = true;
                else
                {
                    parentNode = currentNode;
                
                    if (resultCompare > 0)
                        currentNode = currentNode.Left;
                    else
                        currentNode = currentNode.Right;
                }
            }

            return resultFound;
        }

        //Converts the Binary search tree to a List of values
        public List<T> ToValueList()
        {
            return ToValueList(this.Root);
        }

        //Converts a Binary search sub-tree to a List of values
        private List<T> ToValueList(TreeNode<T> node)
        {
            if (node == null)
                return new List<T>();
            else
            {
                List<T> result = new List<T>();
                if (node.Left != null)
                    result.AddRange(ToValueList(node.Left));

                result.Add(node.Value);

                if (node.Right != null)
                    result.AddRange(ToValueList(node.Right));
                return result;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            List<T> allValues = this.ToValueList();
            foreach (T value in allValues)
            {
                yield return value;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            return String.Join<T>(",", this.ToValueList().ToArray());
        }

        public override bool Equals(object obj)
        {
            if (!(obj is BinarySearchTree<T>))
                return false;

            BinarySearchTree<T> that = (BinarySearchTree<T>) obj;

            List<T> thisAsList = this.ToValueList();
            List<T> thatAsList = that.ToValueList();

            if (thisAsList.Count != thatAsList.Count)
                return false;

            for (int i = 0; i < thisAsList.Count; i++)
            {
                if (!thisAsList[i].Equals(thatAsList[i]))
                    return false;
            }
            return true;
        }

        public static bool operator ==(BinarySearchTree<T> firstBinaryTree, BinarySearchTree<T> secondBinaryTree)
        {
            return firstBinaryTree.Equals(secondBinaryTree);
        }

        public static bool operator !=(BinarySearchTree<T> firstBinaryTree, BinarySearchTree<T> secondBinaryTree)
        {
            return !firstBinaryTree.Equals(secondBinaryTree);
        }

        public override int GetHashCode()
        {
            List<T> allValues = this.ToValueList();
            int resultHashCode = 0;

            int step = allValues.Count / 16 + 1;
            for (int i = 0; i < allValues.Count; i+=step)
            {
                resultHashCode ^= allValues[i].GetHashCode();
            }

            return resultHashCode;
        }

        public object Clone()
        {
            BinarySearchTree<T> newBinarySearchTree = new BinarySearchTree<T>();
            newBinarySearchTree.Root = this.Root.Clone() as TreeNode<T>;

            return newBinarySearchTree;
        }
    }
}
