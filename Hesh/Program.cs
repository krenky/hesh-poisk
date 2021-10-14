using System;

namespace Hesh
{
    class Program
    {
        static void Main(string[] args)
        {
            Hesh_table _Table = new Hesh_table();
            int menu = 0;
            string Item = "";
            while (menu < 10)
            {
                Console.WriteLine("1: Add Item");
                Console.WriteLine("2: Search Item");
                Console.WriteLine();
                Console.WriteLine(_Table.Out());
                menu = Convert.ToInt32(Console.ReadLine());
                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Input new Item");
                        Item = Console.ReadLine();
                        _Table.AddItem(Item);
                        break;
                    case 2:
                        Console.WriteLine("Input new Item");
                        Item = Console.ReadLine();
                        Console.WriteLine(_Table.Search(Item));
                        break;
                }
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
