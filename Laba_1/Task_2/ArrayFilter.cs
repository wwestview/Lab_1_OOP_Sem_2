using System.Threading.Channels;
using System;

delegate bool Filter(int number);
class Filters
{
    static void Main()
    {
        Console.Write("Enter your array: ");
        int[] array = Array.ConvertAll(Console.ReadLine().Trim().Split(), int.Parse);
        Console.Write("k: ");
        int k = int.Parse(Console.ReadLine());
        Filter cond = number => number % k == 0;
        int[] filtredWhere = array.Where(number =>cond(number)).ToArray();
        Console.WriteLine("Filtred with 'Where': " + string.Join(",", filtredWhere));
        int[] filtredManually = FilterArray(array, cond);
        Console.WriteLine("Filtred manually: " + string.Join(",", filtredManually));
    }
   static int[] FilterArray(int[] array, Filter cond)
    {
        int count = 0;
        foreach (var i in array)
        {
            if(cond(i)) count++;
        }
        int[] result =new int[count];
        int indx = 0;
        foreach (var i in array)
        {
            if (cond(i)) result[indx++] = i;
        }
        return result;
    }
   
}