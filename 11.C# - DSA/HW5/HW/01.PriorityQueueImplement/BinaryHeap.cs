using System;
using System.Collections.Generic;

public class BinaryHeap<T> where T : IComparable<T>
{
    public BinaryHeap()
    {
        this.Count = 0;
    }

    public BinaryHeapNode<T> Root { get; private set; }

    public int Count { get; private set; }

    public void Insert(T addValue)
    {
        this.Count++;

        BinaryHeapNode<T> newNode = new BinaryHeapNode<T>(null, addValue);
        BinaryHeapNode<T> parentForAdd = this.BfsFirstNodeNoneOrOneChild();

        if (parentForAdd == null)
        {
            this.Root = newNode;
            return;
        }

        if (parentForAdd.LeftChild == null)
        {
            newNode.Parent = parentForAdd;
            parentForAdd.LeftChild = newNode;
        }
        else if (parentForAdd.RightChild == null)
        {
            newNode.Parent = parentForAdd;
            parentForAdd.RightChild = newNode;
        }

        this.BubbleNodeUp(newNode);
    }

    public T Delete()
    {
        BinaryHeapNode<T> lastChild = this.BfsLastChild();

        if (lastChild == null)
        {
            throw new InvalidOperationException("Binary Heap Empty");
        }

        this.Count--;
        T result = this.Root.Value;

        if (this.Root == lastChild)
        {
            this.Root = null;
            return result;
        }

        this.SetLastChildAsParent(lastChild);

        this.RootFallDown();

        return result;
    }

    private void SetLastChildAsParent(BinaryHeapNode<T> lastChild)
    {
        BinaryHeapNode<T> lastChildParent = lastChild.Parent;

        if (lastChildParent == null)
        {
            return;
        }

        if (lastChildParent.LeftChild == lastChild)
        {
            lastChildParent.LeftChild = null;
        }

        if (lastChildParent.RightChild == lastChild)
        {
            lastChildParent.RightChild = null;
        }

        lastChild.Parent = null;
        lastChild.LeftChild = this.Root.LeftChild;
        lastChild.RightChild = this.Root.RightChild;

        this.NodeOrEmptyChangeParent(this.Root.LeftChild, lastChild);
        this.NodeOrEmptyChangeParent(this.Root.RightChild, lastChild);
        this.Root = lastChild;
    }

    private void RootFallDown()
    {
        BinaryHeapNode<T> currentNode = this.Root;

        BinaryHeapNode<T> biggerChild = this.GetBiggerChild(currentNode);

        while (biggerChild != null)
        {
            this.ReplaceParentChild(biggerChild, currentNode);
            biggerChild = this.GetBiggerChild(currentNode);
        }
    }

    private void ReplaceParentChild(BinaryHeapNode<T> newParent, BinaryHeapNode<T> newChild)
    {
        if (this.Root == newChild)
        {
            this.Root = newParent;
        }

        if (newChild.LeftChild == newParent)
        {
            this.ReplaceParentChildLeft(newParent, newChild);
        }
        else
        {
            this.ReplaceParentChildRight(newParent, newChild);
        }               
    }

    private void ReplaceParentChildLeft(BinaryHeapNode<T> newParent, BinaryHeapNode<T> newChild)
    {
        BinaryHeapNode<T> parentParent = newChild.Parent;
        if (parentParent != null)
        {
            if (parentParent.LeftChild == newChild)
            {
                parentParent.LeftChild = newParent;
            }
            else
            {
                parentParent.RightChild = newParent;
            }
        }

        BinaryHeapNode<T> newChildCopy = new BinaryHeapNode<T>(newChild.Parent, newChild.Value);
        newChildCopy.LeftChild = newChild.LeftChild;
        newChildCopy.RightChild = newChild.RightChild;

        newChild.Parent = newParent;
        this.NodeOrEmptyChangeParent(newChild.RightChild, newParent);
        newChild.LeftChild = newParent.LeftChild;
        newChild.RightChild = newParent.RightChild;

        this.NodeOrEmptyChangeParent(newParent.LeftChild, newChild);
        this.NodeOrEmptyChangeParent(newParent.RightChild, newChild);

        newParent.Parent = newChildCopy.Parent;
        newParent.LeftChild = newChild;
        newParent.RightChild = newChildCopy.RightChild;
    }

    private void ReplaceParentChildRight(BinaryHeapNode<T> newParent, BinaryHeapNode<T> newChild)
    {
        BinaryHeapNode<T> parentParent = newChild.Parent;
        if (parentParent != null)
        {
            if (parentParent.LeftChild == newChild)
            {
                parentParent.LeftChild = newParent;
            }
            else
            {
                parentParent.RightChild = newParent;
            }
        }

        BinaryHeapNode<T> newChildCopy = new BinaryHeapNode<T>(newChild.Parent, newChild.Value);
        newChildCopy.LeftChild = newChild.LeftChild;
        newChildCopy.RightChild = newChild.RightChild;

        newChild.Parent = newParent;
        this.NodeOrEmptyChangeParent(newChild.LeftChild, newParent);
        newChild.LeftChild = newParent.LeftChild;
        newChild.RightChild = newParent.RightChild;

        this.NodeOrEmptyChangeParent(newParent.LeftChild, newChild);
        this.NodeOrEmptyChangeParent(newParent.RightChild, newChild);

        newParent.Parent = newChildCopy.Parent;
        newParent.LeftChild = newChildCopy.LeftChild;
        newParent.RightChild = newChild;
    }

    private BinaryHeapNode<T> GetBiggerChild(BinaryHeapNode<T> currentNode)
    {
        BinaryHeapNode<T> biggerChild = null;
        if ((currentNode.LeftChild != null) && (currentNode.LeftChild.CompareTo(currentNode) > 0))
        {
            biggerChild = currentNode.LeftChild;
        }

        if (biggerChild != null)
        {
            if ((currentNode.RightChild != null) && (currentNode.RightChild.CompareTo(biggerChild) > 0))
            {
                biggerChild = currentNode.RightChild;
            }
        }
        else
        {
            if ((currentNode.RightChild != null) && (currentNode.RightChild.CompareTo(currentNode) > 0))
            {
                biggerChild = currentNode.RightChild;
            }
        }

        return biggerChild;
    }

    private void BubbleNodeUp(BinaryHeapNode<T> node)
    {
        BinaryHeapNode<T> parent = node.Parent;

        while ((parent != null) && (node.CompareTo(parent) > 0))
        {
            this.ReplaceParentChild(node, parent);
            parent = node.Parent;
        }
    }

    private BinaryHeapNode<T> BfsLastChild()
    {
        Queue<BinaryHeapNode<T>> queue = new Queue<BinaryHeapNode<T>>();

        BinaryHeapNode<T> currentNode = this.Root;
        BinaryHeapNode<T> searchedNode = currentNode;
        while (currentNode != null)
        {
            searchedNode = currentNode;
            BinaryHeapNode<T> leftNode = currentNode.LeftChild;
            if (leftNode != null)
            {
                queue.Enqueue(leftNode);
            }

            BinaryHeapNode<T> rightNode = currentNode.RightChild;
            if (rightNode != null)
            {
                queue.Enqueue(rightNode);
            }

            try
            {
                currentNode = queue.Dequeue();
            }
            catch (InvalidOperationException)
            {
                break;
            }
        }

        return searchedNode;
    }

    private BinaryHeapNode<T> BfsFirstNodeNoneOrOneChild()
    {
        Queue<BinaryHeapNode<T>> queue = new Queue<BinaryHeapNode<T>>();

        BinaryHeapNode<T> currentNode = this.Root;
        BinaryHeapNode<T> searchedNode = null;
        while (currentNode != null)
        {
            BinaryHeapNode<T> leftNode = currentNode.LeftChild;
            if (leftNode != null)
            {
                queue.Enqueue(leftNode);
            }
            else
            {
                searchedNode = currentNode;
                break;
            }

            BinaryHeapNode<T> rightNode = currentNode.RightChild;
            if (rightNode != null)
            {
                queue.Enqueue(rightNode);
            }
            else
            {
                searchedNode = currentNode;
                break;
            }

            currentNode = queue.Dequeue();
        }

        return searchedNode;
    }
    
    private void NodeOrEmptyChangeParent(BinaryHeapNode<T> node, BinaryHeapNode<T> parent)
    {
        if (node != null)
        {
            node.Parent = parent;
        }
    }
}