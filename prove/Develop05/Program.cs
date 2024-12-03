using System;
using System.Collections.Generic;
using System.Threading;

class Program
{   
    static void Main(string[] args)
    {
        
        bool run = true;

        while (run)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start Breathing activity.");
            Console.WriteLine("2. Start Reflecting activity.");
            Console.WriteLine("3. Start Listing activity.");
            Console.WriteLine("4. Start Gratitude Diary activity.");
            Console.WriteLine("5. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();
            Console.Clear();
            switch (choice)
            {
                case "1":
                    new BreathingActivity().Run(); 
                    break;
                case "2":
                    new ReflectingActivity().Run();
                    break;
                case "3":
                    new ListingActivity().Run();
                    break;
                case "4":
                    new GratitudeDiary().Run();
                    break;
                case "5":
                    run = false; 
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again.");
                    Thread.Sleep(2000);
                    break;
            }
        }

    }
}