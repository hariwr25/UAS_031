using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_031
{
    class Node
    {
        public int ID;
        public string name;
        public Node next;
        public Node prev;
    }
    class DoubleLinkedList
    {
        Node START;
        public DoubleLinkedList()
        {
            START = null;
        }
        public void addNode()
        {
            int ID;
            string nm;
            Console.Write("\nMasukkan ID: ");
            ID = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama: ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.ID = ID;
            newnode.name = nm;
           
            if (START == null || ID <= START.ID)
            {
                if ((START != null) && (ID == START.ID))
                {
                    Console.WriteLine("\"nDuplicate ID not allowed");
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null &&
                ID >= current.ID; previous = current, current =
                current.next)
            {
                if (ID == current.ID)
                {
                    Console.WriteLine("\nDuplicate ID not allowed");
                    return;
                }
            }
            
            newnode.next = current;
            newnode.prev = previous;

            
            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }

      
        public bool Search(int ID, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                ID != current.ID; previous = current,
                current = current.next)
            { }
            
            return (current != null);
        }

        public bool delNode(int ID)
        {
            Node previous, current;
            previous = current = null;
            if (Search(ID, ref previous, ref current) == false)
                return false;
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;
            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }

        public void traverse()
        {

            if (listEmpty())
                Console.WriteLine("\nList is Empty");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of " +
                    "ID:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.ID + " "
                        + currentNode.name + "\n");
            }
        }

        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty");
            else
            {
                Console.WriteLine("\nRecords in the descending order of " +
                    "ID:\n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null;
                    currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.ID + " "
                        + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu" +
                        "\n 1. Masukkan data barang" +
                        "\n 2. Hapus data barang di dalam list" +
                        "\n 3. Tampilkan data" +
                        "\n 4. Cari data di dalam list" +
                        "\n 5. Exit \n" +
                        "\n Enter your choice (1-5): ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty()) ;
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the ID" +
                                    " whose record is to be deleted: ");
                                int ID = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(ID) == false)
                                    Console.WriteLine("Record not found");
                                else
                                    Console.WriteLine("Record with ID " + ID + " deleted \n");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the ID whose record you want to search: ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found");
                                else
                                {
                                    Console.WriteLine("\nRecord found");
                                    Console.WriteLine("\nID: " + curr.ID);
                                    Console.WriteLine("\nNama: " + curr.name);
                                }
                            }
                            break;
                        case '5':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Check for the values entered.");
                }
            }
        }
    }
}




/*
2. untuk mengurutkan data yang indri inginkan dan untuk menampilkan jenis barang yang sama
3.REAR & FRONT
4.a. 5 kedalaman
  b. 50, 48, 30, 20,15, 25, 32, 31, 35, 70 ,65, 90, 67, 69, 98,94,99 

*/