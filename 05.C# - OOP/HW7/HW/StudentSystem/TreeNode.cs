//Task06
//Define the data structure binary search tree with operations for "adding new element", "searching element" and "deleting elements". 
//It is not necessary to keep the tree balanced. Implement the standard methods from System.Object – ToString(), Equals(…), GetHashCode()
//and the operators for comparison  == and !=. Add and implement the ICloneable interface for deep copy of the tree. 
//Remark: Use two types – structure BinarySearchTree (for the tree) and class TreeNode (for the tree elements). 
//Implement IEnumerable<T> to traverse the tree.

using System;
namespace StudentSystem
{
    //------
    //Task06
    //------
    public class TreeNode<T> : ICloneable where T:IComparable
    {
        public T Value { get; private set; }
        public TreeNode<T> Left { get; set; }
        public TreeNode<T> Right { get; set; }

        public TreeNode(T pValue)
        {
            this.Value = pValue;
        }

        public TreeNode(T pValue, TreeNode<T> pLeft = null, TreeNode<T> pRight = null)
            :this(pValue)
        {
            this.Left = pLeft;
            this.Right = pRight;
        }

        public object Clone()
        {
            TreeNode<T> newTreeNode = new TreeNode<T>(this.Value);
            if (this.Left != null)
                newTreeNode.Left = this.Left.Clone() as TreeNode<T>;

            if (this.Right != null)
                newTreeNode.Right = this.Right.Clone() as TreeNode<T>;

            return newTreeNode;
        }

        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
