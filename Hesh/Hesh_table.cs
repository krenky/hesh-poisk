using System;
using System.Collections.Generic;
using System.Text;

namespace Hesh
{
    class Hesh_table
    {
        private const int V = 10;
        private string[] Table = new string[V];
        private int Key;
        private int Count = 0;

        public Hesh_table()
        {
            Key = V;
        }
        public Hesh_table(int key)
        {
            Key = key;
        }

        public string[] Table1 { get => Table; set => Table = value; }
        public int Key1 { get => Key; set => Key = value; }
        public int Count1 { get => Count; set => Count = value; }

        public void AddItem(string Item)
        {
            int SumItem = Hesh_Fun(Item); //поиск хеш функции           
            if(Count*2 < Table.Length)
            {
                if (Table[SumItem] == null)
                {
                    Table[SumItem] = Item;
                    Count++;
                }  // развилка если ячейка занята
                else
                {
                    for(int i = 0; i < V/2; i++)
                    {
                        if(Table[Hesh_Fun(Item, i)] == null)
                        {
                            Table[Hesh_Fun(Item, i)] = Item;
                            break;
                        }
                    }
                }
            } // развилка если закончится массив
            else
            {
                Array.Resize(ref Table, Table.Length*2);//увелеичение массива
                if (Table[SumItem] == null)
                {
                    Table[SumItem] = Item;
                    Count++;
                }
                else
                {
                    for (int i = 0; i < V / 2; i++)
                    {
                        if (Table[Hesh_Fun(Item, i)] == null)
                        {
                            Table[Hesh_Fun(Item, i)] = Item;
                            break;
                        }
                    }
                }
            }
        }
        public int Hesh_Fun(string Item) //хещ функция
        {
            int Hash = 0;
            foreach (int i in Item)
            {
                Hash = Hash + i;
            }
             return Hash % V;
        }
        public int Hesh_Fun(string Item, int Index)//хещ функция
        {
            int Hash = 0;
            foreach (int i in Item)
            {
                Hash = Hash + i;
            }
            Hash = ((Hash + Index) % V) + 1;
            return Hash;
        }
        public bool Search(string Item)//поиск
        {
            if (Table[Hesh_Fun(Item)] == Item)
            {
                return true;
            }
            else
            {
                for(int i = 0; i < Table.Length; i++)
                {
                    if (Hesh_Fun(Item, i) < Table.Length)
                    {
                        if (Table[Hesh_Fun(Item, i)] == Item)
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
        }
        public string Out()//вывод
        {
            string Str = "";
            for(int i = 0; i < Table.Length; i++)
            {
                if (Table[i] != null)
                {
                    Str = Str + "|| " + Table[i] + " ";
                }
            }
            return Str;
        }
    }
}