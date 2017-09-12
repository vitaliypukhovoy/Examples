using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');

        var arrRev = arr_temp.Reverse().ToArray();
        int[] arr = Array.ConvertAll(arrRev, s => int.Parse(s));

        List<int> arr1 = arr.ToList();

        arr1.ForEach(i => Console.Write("{0}\t", i));
        foreach (var item in arr)
            Console.Write(item + " ");


        //string[] arr_temp = Console.ReadLine().Split(' ');

        //var arrRev = arr_temp[0].Reverse().ToArray();
        //int[] arr = Array.ConvertAll(arrRev, s => (int)Char.GetNumericValue(s));
        ////List<int> arr1 = arr.ToList();

        ////arr1.ForEach(i => Console.Write("{0}\t", i));
        //foreach (var item in arr)
        //    Console.Write(item + " ");


        //int[] numbers = Console
        //.ReadLine()
        //.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
        //.Select(item => int.Parse(item))
        //.Reverse()
        //.ToArray();

        //foreach (int item in numbers)
        //    Console.Write(item);
    }
}


//4
//1 4 3 2
