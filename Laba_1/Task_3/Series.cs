using System;

public delegate double Series(int n);

public class SeriesTerm
{
   public static double SumSeries(Series s, double precision)
    {
        double sum = 0.0;
        int n = 1;
        double currTerm;

        while ((currTerm = s(n)) > precision || currTerm < -precision)
        {
            sum += currTerm;
            n++;
        }

        return sum;
    }

    public static double GeometrySumSeries(int n) => 1.0 / Math.Pow(2, n - 1);

    public static double ExpSumSeries(int n) => 1.0 / Factorial(n);

    public static double AlternatingGeometricSeriesTerm(int n) => Math.Pow(-1, n - 1) / Math.Pow(2, n - 1);

    private static double Factorial(int n)
    {
        double result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }
}

class Serieses
{
    static void Main()
    {
        Console.Write("Enter precision: ");
        double precision = double.Parse(Console.ReadLine());
        Console.WriteLine("Geometric: " + SeriesTerm.SumSeries(SeriesTerm.GeometrySumSeries, precision));
        Console.WriteLine("Exponential: " + SeriesTerm.SumSeries(SeriesTerm.ExpSumSeries, precision));
        Console.WriteLine("Alternating: " + SeriesTerm.SumSeries(SeriesTerm.AlternatingGeometricSeriesTerm, precision));
    }
}
