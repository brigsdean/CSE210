using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity 
{
    private int _count;
    private List<string> _prompts; 

    public ListingActivity()
    {
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life \nby having you list as many things as you can in a certain area.\n";
        
        _prompts = new List<string>
        {
            "--- Who are people that you appreciate? ---",
            "--- What are personal strengths of yours? ---",
            "--- Who are people that you have helped this week? ---",
            "--- When have you felt the Holy Ghost this month? ---",
            "--- Who are some of your personal heroes? ---"
        };  
    }

    public void Run()
    {
        DisplayStartingMessage();

        string prompt = GetRandomPrompt(); 
        Console.Clear();
        Console.WriteLine("List as many responses you can to the following prompt: \n");
        Console.WriteLine(prompt);
        Console.WriteLine();
        Console.Write("You may begin in: ");
        ShowCountDown(5); 
        Console.WriteLine();

        List<string> userResponse = GetListFromUser(); 
        _count = userResponse.Count;

        Console.WriteLine($"You listed {_count} items!");

        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
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