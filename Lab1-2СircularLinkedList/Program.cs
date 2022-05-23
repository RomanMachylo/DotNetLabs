using System;

namespace Lab1_circularLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList<string> circularList = new CircularLinkedList<string>();
            
            circularList.Add("Putin");
            circularList.Add("Julia");
            circularList.Add("Alice");
            circularList.Add("Jack");
            circularList.Add("Bob");
            circularList.Remove("Bob");
            circularList.Remove("Putin");
            Console.WriteLine("\nList:");
            foreach (var item in circularList)
                Console.WriteLine(item);
            System.Console.Write("\n");

            circularList.Clear(null);
        }
    }
}
