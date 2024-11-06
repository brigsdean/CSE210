using System;

class Program
{

    // do not use Debug anyway will use last working version and not current version
    static void Main(string[] args)
    {
        Console.WriteLine("what is your first name? ");
        string first = Console.ReadLine();

        Console.Write("what is your last name? ");
        string last = Console.ReadLine();

        Console.WriteLine($"your name is {last}, {first} {last}");
    }
}