using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SortsMethods
{
    class Program
    {
        public  static int max = 0;
        static void Main(string[] args)
        {
            
            bool control = true;
            while (control)
            {
                int key = 0;
                int range = 10;
                Menu();
                try
                {
                    key = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                  
                if (key == 1)
                {
                    Console.WriteLine("Please, enter range of array: ");
                    try
                    {
                        range = int.Parse(Console.ReadLine());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        break;
                    }
                    if (range >= 5 && range <= 100)
                    {
                        int[] array = new int[range];
                        Random rand = new Random();
                        for (int i = 0; i < array.Length; i++)
                            array[i] = rand.Next(-100, 100);
                        Console.WriteLine("Source Array:");
                        for (int i = 0; i < array.Length; i++)
                            Console.Write("{0}\t", array[i]);
                        Console.WriteLine();
                        Result(array);
                    }
                    else
                    {
                        Console.WriteLine("Sorry, wrong range... Try again)");
                    }
                }
                else
                {
                    if(key == 2)
                    control = false;
                    else
                        Console.WriteLine("Sorry, wrong enter...)");
                }
            }
            Console.ReadKey();
        }

        static void Menu()
        {
            string s = "Please,  choose the next action:\n" +
                "1. Enter range of array (from 5 to 100)\n"+
                "2. Exit\n";
            Console.WriteLine(s);
        }
        static void Result(int[] array)
        {

            Stopwatch st = new Stopwatch();
            int[] res = new int[array.Length];
            string[] names = new string[6];
            TimeSpan[] t = new TimeSpan[6];
            int[][] allMethods = new int[6][];

            st.Reset();
            st.Start();
            allMethods[0] = SortBubble(array);
            st.Stop();
            t[0] = st.Elapsed;
            names[0] = "****Bubble sort array:****";

            st.Reset();
            st.Start();
            allMethods[1] = CocktailSort(array);
            st.Stop();
            t[1] = st.Elapsed;
            names[1] = "****Cocktail sort array:****";

            st.Reset();
            st.Start();
            allMethods[2] = InsertionSort(array);
            st.Stop();
            t[2] = st.Elapsed;
            names[2] = "****Insertion sort array:****";

            st.Reset();
            st.Start();
            allMethods[3] = SelectionSort(array);
            st.Stop();
            t[3] = st.Elapsed;
            names[3] = "****Selection sort array:****";

            st.Reset();
            st.Start();
            allMethods[4] = MergeSort(array);
            st.Stop();
            t[4] = st.Elapsed;
            names[4] = "****Merge sort array:****";

            st.Reset();
            st.Start();
            max = 0;
            allMethods[5] = SortTree(array);
            st.Stop();
            t[5] = st.Elapsed;
            names[5] = "****Binary Tree sort array:****";

            OutputInfo(names, allMethods, t);
        }

        private static void OutputInfo(string[] names, int[][] allMethods, TimeSpan[] t)
        {
            for (int j = 0; j < names.Length; j++)
            {
                Console.WriteLine();
                Console.WriteLine(names[j]);
                for (int i = 0; i < allMethods[j].Length; i++)
                { Console.Write("{0}\t", allMethods[j][i]); }
                Console.WriteLine();
                Console.Write("Time: {0}\n", t[j]);
            }
        }

        /*1*/
        static int[] SortBubble(int[] mas) // сBubble sort array
        {

            // Difficulty: the worst - n^2, the  normal - n^2, the best - n
            // Difficulty(memory) : common -  n, additional - 1 
            int change;

            for (int i = 0; i < mas.Length; i++)
            {
                for (int j = i + 1; j < mas.Length; j++)
                {
                    if (mas[i] >= mas[j]) //  smallest element go down
                    {
                        change = mas[i];
                        mas[i] = mas[j];
                        mas[j] = change;
                    }
                }
            }

            return mas;
        }


        /*2*/
        static int[] CocktailSort(int[] mas)
        {  // Difficulty: the worst - n^2, the  normal - n^2, the best - n
            // Difficulty(memory) : common -  n, additional - 1 
            int change;
            bool flag;
            do
            {
                flag = false;
                for (int i = 0; i < mas.Length - 1; i++)
                {
                    if (mas[i] >= mas[i + 1])
                    {
                        change = mas[i];
                        mas[i] = mas[i + 1];
                        mas[i + 1] = change;
                        flag = true;
                    }

                }
                if (flag == false) break;
                flag = false;
                for (int l = mas.Length - 1; l > 0; l--)
                {
                    if (mas[l] < mas[l - 1])
                    {
                        change = mas[l];
                        mas[l] = mas[l - 1];
                        mas[l - 1] = change;
                        flag = true;
                    }

                }
            } while (flag);
            return mas;
        }

        /*3*/
        static int[] InsertionSort(int[] mas)
        {// Difficulty: the worst - n^2/2, the  normal - n^2/4, the best - n
            // Difficulty(memory) : common -  n, additional - 1 
            for (int i = 1; i < mas.Length; i++)
            {
                int buffer = mas[i];
                int j = i - 1;

                while (mas[j] > buffer && j >= 0)
                {
                    mas[j + 1] = mas[j];
                    j--;
                }
                mas[j + 1] = buffer;
            }

            return mas;
        }

        /*4*/
        static int[] SelectionSort(int[] mas)
        {// Difficulty: the worst - n^2/2, the  normal - n^2/4, the best - n
         // Difficulty(memory) : common -  n, additional - 1 


            int n = mas.Length;
            int buffer = 0;
            while (n > 0)
            {
                int maxEl = int.MinValue;
                for (int i = 0; i < n; i++)
                {
                    if (mas[i] > maxEl)
                    {
                        maxEl = mas[i];
                        buffer = i;
                    }
                }
                int change;
                change = mas[n - 1];
                mas[n - 1] = maxEl;
                mas[buffer] = change;
                n--;

            }
            return mas;
        }

        /*5*/
        static int[] MergeSort(int[] mas)   //bose-nelson merge
        {

            int m = 1;
            while (m < mas.Length)
            {
                int j = 0;
                while (j + m < mas.Length)
                {
                    BoseNelson(mas, j, m, m);
                    j = j + m + m;
                }
                m = m + m;
            }
            return mas;
        }

        static int[] BoseNelson(int[] mas, int j, int r, int m)
        {
            if (j + r < mas.Length)
            {
                if (m == 1)
                {
                    if (mas[j] > mas[j + r])
                    {
                        int buffer = mas[j];
                        mas[j] = mas[j + r];
                        mas[j + r] = buffer;
                    }
                    else
                    {
                        m = m / 2;
                        BoseNelson(mas, j, r, m);
                        if (j + r + m < mas.Length)
                        {
                            BoseNelson(mas, j + m, r, m);
                        }
                        BoseNelson(mas, j + m, r - m, m);
                    }
                }
            }
            return mas;
        }

        /*6*/
        static int[] SortTree(int[] arr) //binary tree sort (input)
        {
            Tree root = null;
            for (int i = 0; i < arr.Length; i++)
            {
                root = AddToTree(root, arr[i]);
            }
            TreeToArray(root, arr);
            return arr;
        }

        static Tree AddToTree(Tree root, int newValue) // building the tree
        {
            if (root == null)
            {
                root = new Tree();
                root.Value = newValue;
                root.Left = null;
                root.Right = null;
                return root;
            }
            if (root.Value < newValue)
                root.Right = AddToTree(root.Right, newValue);
            else root.Left = AddToTree(root.Left, newValue);
            return root;
        }

        static void TreeToArray(Tree root, int[] mas)
        {
            if (root == null) return;
            TreeToArray(root.Left, mas);
            mas[max++] = root.Value;
            TreeToArray(root.Right, mas);
        } // tree to array
    }
}
