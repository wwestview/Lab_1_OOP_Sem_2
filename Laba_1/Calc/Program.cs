public delegate double DlgFunction(double n);

public class Function
{
    public static DlgFunction[] Calc =
    {
        (x) => Math.Sqrt(Math.Abs(x)),
        (x) => x * x * x,
        (x) => x + 3.5
    };
}

public class Calculator
{
    static void Main()
    {
        Console.WriteLine("Вводьте послідовність виду 0 х, 1 х або 2 х (де х - число)");
        Console.WriteLine();
        Console.WriteLine("0 -- sqrt(abs(x))");
        Console.WriteLine();
        Console.WriteLine("1 -- x^3");
        Console.WriteLine();
        Console.WriteLine("2 -- x + 3,5");
        Console.WriteLine();
        while (true)
        {
            try
            {
                string[] input = Console.ReadLine().Trim().Split();
                int index = int.Parse(input[0]);
                double value = double.Parse(input[1]);

                Console.WriteLine("Відповідь : " + (Function.Calc[index](value)));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Сталася помилка: {ex.Message}");
                Console.WriteLine("Щоб вийти, натисніть будь-яку кнопку");
                Console.ReadKey();
                break;
            }
        }
    }
}
