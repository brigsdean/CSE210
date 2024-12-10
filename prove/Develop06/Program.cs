using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

// bare minimum of what i think is needed
class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}