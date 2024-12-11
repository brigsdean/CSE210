using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;


public class GoalManager
{
    private List<Goal> _goals = new List<Goal>(); 
    private int _score; 

    public GoalManager()
    {
        _score = 0; 
    }

    public void Start()
    {
        bool run = true;

        while (run)
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            DisplayMenu(); 
            string choice = Console.ReadLine(); 

            switch (choice)
            {
                case "1":
                    CreateGoal(); 
                    break;
                case "2":
                    ListGoalDetails(); 
                    break;
                case "3":
                    SaveGoals(); 
                    break;
                case "4":
                    LoadGoals(); 
                    break;
                case "5":
                    RecordEvent(); 
                    break;
                case "6":
                    DeleteGoal(); 
                    break;
                case "7":
                    run = false; 
                    break;
                default:
                    Console.WriteLine("Invalid choice, please try again."); 
                    Thread.Sleep(2000);
                    break;
            }
        }
    }
   
    private void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Save Goals");
        Console.WriteLine("4. Load Goals");
        Console.WriteLine("5. Record Event");
        Console.WriteLine("6. Delete Goal");
        Console.WriteLine("7. Quit");
        Console.Write("Select a choice from the menu: ");
    }

    private void DisplayPlayerInfo()
    {   
        Console.WriteLine($"You have {_score} points.\n");
    }
    private void ListGoalDetails()
    {
        Console.WriteLine("The goals are: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            if (_goals[i] is ChecklistGoal checklistGoal)
            {
                Console.WriteLine($"{i + 1}. {checklistGoal.GetDatailsString()}");
            }
            else
            {
                Console.WriteLine($"{i + 1}. {_goals[i].GetDatailsString()}");
            }
        }
        Thread.Sleep(2000);
    }
    private void CreateGoal()
    {
        Console.WriteLine("The types of Goals are: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goals");
        Console.Write("Which type of goal would you like to create? ");

        string choice = Console.ReadLine();

        switch (choice)
        {
            case "1":
                _goals.Add(CreateSimpleGoal());
                break;
            case "2":
                _goals.Add(CreateEternalGoal());
                break;
            case "3":
                _goals.Add(CreateChecklistGoal()); 
                break;
            default:
                Console.WriteLine("Invalid choice, please try again.");
                Thread.Sleep(1000);
                break;
        }
    }
    private SimpleGoal CreateSimpleGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        return new SimpleGoal(name, description, points);
    }
    private EternalGoal CreateEternalGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        return new EternalGoal(name, description, points);
    }
    private ChecklistGoal CreateChecklistGoal()
    {
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());
        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
        int target = int.Parse(Console.ReadLine());
        Console.Write("What is the bonus for accomplishing in that many times? ");
        int bonus = int.Parse(Console.ReadLine());
        return new ChecklistGoal(name, description, points, target, bonus);
    }
    private void RecordEvent()
    {
        Console.WriteLine("The goals are: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }

        Console.Write("Which goal have you completed? Enter the number: ");
        int goalIndex;
        if (!int.TryParse(Console.ReadLine(), out goalIndex) || goalIndex < 1 || goalIndex > _goals.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid goal number.");
            Thread.Sleep(2000);
            return;
        }

        var selectedGoal = _goals[goalIndex - 1];
        int pointsEarned = selectedGoal.RecordEvent(); 
        _score += pointsEarned;

        Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
        Console.WriteLine($"You now have {_score} points.\n");

        Thread.Sleep(2000);
    }
    private void DeleteGoal()
    {
        Console.WriteLine("The goals are: ");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }

        Console.Write("Which goal would you like to delete? Enter the number: ");
        int goalIndex;
        if (!int.TryParse(Console.ReadLine(), out goalIndex) || goalIndex < 1 || goalIndex > _goals.Count)
        {
            Console.WriteLine("Invalid input. Please enter a valid goal number.");
            Thread.Sleep(2000);
            return;
        }

        _goals.RemoveAt(goalIndex - 1); 

        Console.WriteLine("Goal deleted successfully!");
        Console.WriteLine("OBS:. After deleting, Save to permanently delete the txt file.");
        Thread.Sleep(2000);
    }
    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            foreach (var goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.WriteLine("Goals saved successfully!");
        Thread.Sleep(2000);
    }
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            _goals.Clear();

            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(", ");
                if (parts.Length < 4)
                {
                    continue;
                }
                string type = parts[0];
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                switch (type)
                {
                    case "Simple Goal":
                        bool isComplete = bool.Parse(parts[4]);
                        _goals.Add(new SimpleGoal(name, description, points, isComplete));
                        break;
                    case "Eternal Goal":
                        bool eternalIsComplete = bool.Parse(parts[4]);
                        _goals.Add(new EternalGoal(name, description, points, eternalIsComplete)); 
                        break;
                    case "Checklist Goal":
                        int amountCompleted = int.Parse(parts[4]);
                        int target = int.Parse(parts[5]);
                        int bonus = int.Parse(parts[6]); 
                        _goals.Add(new ChecklistGoal(name, description, points, target, bonus, amountCompleted));
                        break;
                    default:
                        Console.WriteLine("Unknown goal type found in file.");
                        break;
                }
            }
            Console.WriteLine("Goals loaded successfully!");
            Thread.Sleep(1000);
        }
        else
        {
            Console.WriteLine("No saved goals found.");
            Thread.Sleep(1000);
        }
    }
}
