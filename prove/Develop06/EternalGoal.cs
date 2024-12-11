using System;

public class EternalGoal : Goal
{
    private bool _isComplete;

    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
        _isComplete = false;
    }

    public EternalGoal(string name, string description, int points, bool isComplete) : base(name, description, points)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        _isComplete = true; 
        return _points; 
    }

    public override bool IsComplete() => _isComplete;

    public override string GetDatailsString()
    {
        return $"[{(_isComplete ? "X" : " ")}] {_name} ({_description})";
    }

    public override string GetStringRepresentation()
    {
        return $"Eternal Goal, {_name}, {_description}, {_points}, {_isComplete}";
    }
}