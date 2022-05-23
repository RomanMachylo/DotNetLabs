using System;
using System.Collections;
using System.Collections.Generic;
 
namespace Lab1_circularLinkedList
{
    public class CircularLinkedList<T> : IEnumerable<T>  
    {
        Node<T> head; 
        Node<T> tail; 
        public int count; 

        public CircularLinkedList(){
            insertion += DisplayMessage;
            deletion += DisplayMessage;
            deletionList += DisplayMessageClearList;
        }
        public delegate void EventHandler(string message, T data, string index);
        public delegate void ClearListHandler(string DisplayMessage);
        public event EventHandler insertion = delegate { } ;
        public event EventHandler deletion = delegate { };
        public event ClearListHandler deletionList = delegate { };
 
        public void Add(T data)
        {
            if (data == null) throw new ArgumentNullException("An Element must not be null!");

            Node<T> node = new Node<T>(data);

            if (head == null)
            {
                head = node;
                tail = node;
                tail.Next = head;
            }
            else
            {
                node.Next = head;
                tail.Next = node;
                tail = node;
            }
            count++;
            

            this.insertion?.Invoke("Added to List new data: ", data, "insertion");
        }
        public bool Remove(T data)
        {
            if (data == null) throw new ArgumentNullException("An Element must not be null!");

            Node<T> current = head;
            Node<T> previous = null;
 
            if (IsEmpty) return false;
 
            do
            {
                if (current.Data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;
 
                        if (current == tail)
                            tail = previous;
                    }
                    else 
                    {
                        if(count == 1)
                        {
                            head = tail = null;
                        }
                        else
                        {
                            head = current.Next;
                            tail.Next = current.Next;
                        }
                    }
                    count--;
                    this.deletion?.Invoke("Deleted from List data: ", data, "deletion");
                    return true;
                }
 
                previous = current;
                current = current.Next;
            } while (current != head);
 
            return false;
        }
 
        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }
 
        public void Clear(T data)
        {
            head = null;
            tail = null;
            count = 0;
            this.deletionList?.Invoke("Deleted all data from List");
        }
 
        public bool Contains(T data)
        {
            if (data == null) throw new ArgumentNullException("An Element must not be null!");
            Node<T> current = head;
            if (current == null) return false;
            do
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            while (current != head);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node<T> current = head;
            do
            {
                if (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
            while (current != head);
        }

        public static void DisplayMessage(string message, T data, string index) {
            Console.Write(message);
            if(index == "insertion") Console.ForegroundColor = ConsoleColor.Green;
            else if(index == "deletion") Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(data);
            Console.ResetColor();
        }
        public static void DisplayMessageClearList(string message) {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}