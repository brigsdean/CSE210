using System;
public class Activity
{

    protected string _name;
    protected string _description; 
    protected int _duration;

    public void DisplayStartingMessage()
    {   
        Console.WriteLine($" ≫ Welcome to the {_name}."); 
        Console.WriteLine($"\nDescription: {_description}");
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(5);

    }
    public void DisplayEndingMessage()
    {   
        Console.WriteLine();
        Console.WriteLine("Well Done!!\n");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(4);

    }
    public void ShowSpinner( int seconds)
    {
         List<string> animationString = new List<string>
        {
            "|",
            "/",
            "-",
            "\\",
            "|",   
            "/",
            "-",
            "\\"
        };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int counter = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(animationString[counter % animationString.Count]);
            Thread.Sleep(300); 
            Console.Write("\b \b"); 

            counter++;
        }

        Console.Write(" ");
        Console.Write("\b \b");
    }
    public void ShowCountDown( int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

}

