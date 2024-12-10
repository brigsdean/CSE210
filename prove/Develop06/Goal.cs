using System;


public abstract class Goal
{
    protected string _name; 
    protected string _description;
    protected int _points; 

    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public string Name => _name; 
    public string Description => _description; 
    public int Points => _points;


    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public abstract string GetDatailsString();

    public abstract string GetStringRepresentation();
}
