using System;

namespace murphy_linkedlist
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();
            list.Menu();
            //add items here for example
        }

    }
    class Node
    {
        public string data;
        public Node next; //reference to next node in list
        public Node(string d) //constructor
        {
            data = d;
            next = null;
        }
    }
    class LinkedList
    {
        private Node head;
        public void Menu()
        {
            bool loop = true;
            while (loop)
            {
                Console.WriteLine("Please enter a number:\n" +
                "1. Show Head\n" +
                "2. Add Item to End\n" +
                "3. Add Item to Front\n" +
                "4. Remove Item\n" +
                "5. Search for Item\n" +
                "6. Print\n" +
                "7. Exit");
                string line = Console.ReadLine();
                int num;
                if (int.TryParse(line, out num))
                {
                    switch (num)
                    {
                        case 1:
                            getFirst();
                            break;
                        case 2:
                            Console.WriteLine("Enter a string to add to the list:");
                            Add(Console.ReadLine());
                            break;
                        case 3:
                            Console.WriteLine("Enter a string to add to the list:");
                            addFirst(Console.ReadLine());
                            break;
                        case 4:
                            Console.WriteLine("Enter an item to remove from the list:");
                            Remove(Console.ReadLine());
                            break;
                        case 5:
                            Console.WriteLine("Enter an item to search from the list:");
                            Contains(Console.ReadLine());
                            break;
                        case 6:
                            PrintAllNodes();
                            break;
                        case 7:
                            Console.WriteLine("Exiting...");
                            loop = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid menu number.");
                }
            }
        }
        public Node addFirst(string data)
        {
            if(head == null)
            {
                head = new Node(data);
            }
            else
            {
                Node newHead = new Node(data);
                newHead.next = head;
                head = newHead;
            }
            return head;
        }
        public Node Add(string data)
        {
            if (head == null)
            {
                head = new Node(data);
                return head;
            }
            else
            {
                Node current = head;
                while ( current.next != null)
                {
                    current = current.next;
                }
                current.next = new Node(data);
                return current.next;
            }
        }
        public bool Remove(string data) //WIP
        {
            bool removed = false;
            if (head == null)
            {
                Console.WriteLine("There is no data in the linked list.");
                return removed;
            }
            else
            {
                Node current = head;
                Node previous = null;

                while (data != current.data && current != null)
                {
                    previous = current;
                    current = current.next;
                }
                if (current != null)
                {
                    if (previous == null)
                    {
                        head = current.next;
                    }
                    else
                    {
                        previous.next = current.next;
                        current = null;
                    }
                    current = null;
                    removed = true;
                }
                return removed;
            }
        }

        public Node Contains(string data)
        {
            if (head == null)
            {
                Console.WriteLine("There is no data in the linked list.");
                return null;
            }
            else
            { 
                Node current = head;
                try
                {
                    while (current.data != data)
                    {
                        current = current.next;
                    }
                    Console.WriteLine("The linked list contains " + data);
                    return current;
                }
                catch
                {
                    Console.WriteLine("There is no match in the linked list.");
                    return null;
                }
            }
        }
        public void getFirst()
        {
            Node current = head;
            if (current == null)
            {
                Console.WriteLine("There is no data in the linked list.");
            }
            else
            {
                Console.WriteLine(current.data);
            }
        }

        public void PrintAllNodes()
        {
            Node current = head;
            if (current == null)
            {
                Console.WriteLine("There is no data in the linked list.");
            }
            else
            {
                while (current != null)
                {
                    Console.WriteLine(current.data);
                    current = current.next;
                }
            }
        }
    }
}
