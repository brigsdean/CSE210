using System;

public class GratitudeDiary : Activity
{   
    private int _list; 
    public GratitudeDiary()
    {
        _name = "Gratitude Diary Activity";
        _description = "This activity will help you reflect by making you think about and write down things you are grateful for. \nClear your mind and concentrate on remembering the little things.\n";
    }

    public void Run()
    {
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("List as many things as possible for which you are grateful: ");
        Thread.Sleep(1000);
        Console.Write("You may begin in: ");
        ShowCountDown(3);
        Console.WriteLine();

        List<string> userResponse = GetList();
        _list = userResponse.Count;

        Console.WriteLine($"You listed {_list} items!");

        DisplayEndingMessage();
    }

    private List<string> GetList()
    {
        List<string> responses = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write(">>> "); 
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
            {
                responses.Add(input);
            }
        }

        return responses;
    }
}