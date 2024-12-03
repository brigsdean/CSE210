using System;
using System.Collections.Generic;
using System.Threading;

public class BreathingActivity : Activity
{

    public BreathingActivity()
    {
        _name = "Breating Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. \nClear your mind and focus on your breathing.\n";
    }

    public void Run()
    {
        DisplayStartingMessage();

        for (int i = 0; i < _duration / 6; i++)
        {   
            Console.WriteLine();
            Console.Write("Breathe in...");
            ShowCountDown(5);
            Console.WriteLine();
            Console.Write("Now breathe out...");
            ShowCountDown(5);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
}