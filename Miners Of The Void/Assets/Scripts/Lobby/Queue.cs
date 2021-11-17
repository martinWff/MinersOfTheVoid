using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueueNode<T>
{
    private T data;
    private QueueNode<T> next;

    public T Data
    {
        get { return data; }
        set { data = value; }
    }

    public QueueNode<T> Next
    {
        get { return next; }
        set { next = value; }
    }

    public QueueNode(T value) //este
    {
        data = value;
        next = null;
    }
}

public class Queue<T>
{
    private QueueNode<T> front;
    private QueueNode<T> back;
    public Queue()
    {
        front = null;
        back = null;
    }
    public void Enqueue(T value)
    {
        QueueNode<T> newnode = new QueueNode<T>(value);
        if (back == null)
        {
            back = newnode;
            front = newnode;
        } else
        {
            back.Next = newnode;
            back = newnode;
        }
     }
    public QueueNode<T> Dequeue()
    {
        if (front == null) return null;
        else
        {
            QueueNode<T> node = front;
            front = front.Next;
            if (front == null) back = null;
            return node;
        }
    }
    public bool IsEmpty()
    {
        return front == null;
    }
    public QueueNode<T> Front()
    {
        return front;

    }
    public QueueNode<T> Back()
    {
        return back;
    }

}



