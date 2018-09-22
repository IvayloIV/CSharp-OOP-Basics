using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    public int Count { get; private set; }

    private Node Head { get; set; }

    private Node Tail { get; set; }


    public void Add(T element)
    {
        var newNode = new Node(element);
        if (this.Count == 0)
        {
            this.Tail = this.Head = newNode;
        }
        else
        {
            newNode.Prev = this.Tail;
            this.Tail.Next = newNode;
            this.Tail = newNode;
        }
        this.Count++;
    }

    public bool Remove(T element)
    {
        var tempHead = this.Head;
        while (tempHead != null)
        {
            if (EqualityComparer<T>.Default.Equals(tempHead.Value, element))
            {
                var lastElement = tempHead.Prev;
                var nextElement = tempHead.Next;

                if (lastElement != null)
                {
                    lastElement.Next = nextElement;
                }
                else
                {
                    this.Head = this.Head.Next;
                }
                if (nextElement != null)
                {
                    nextElement.Prev = lastElement;
                }
                else
                {
                    this.Tail = this.Tail.Prev;
                }
                this.Count--;
                return true;
            }
            tempHead = tempHead.Next;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        var head = this.Head;
        while (head != null)
        {
            yield return head.Value;
            head = head.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    private class Node
    {
        public T Value { get; private set; }

        public Node Prev { get; set; }

        public Node Next { get; set; }

        public Node(T value)
        {
            this.Value = value;
        }
    }
}