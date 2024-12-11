using System;

public class ChecklistGoal : Goal
{
    private int _target;  
    private int _bonus; 
    private int _amountCompleted; 

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0; 
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int amountCompleted) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = amountCompleted;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;  
        if (_amountCompleted >= _target)
        {
            return _points + _bonus; 
        }
        return _points; 
    }

    public string IsCompleteDetails()
    {
        return $"{_amountCompleted}/{_target}";
    }

    public override bool IsComplete() => _amountCompleted >= _target;

    public override string GetDatailsString()
    {
        return $"[{(_amountCompleted >= _target ? "X" : " ")}] {_name} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"Checklist Goal, {_name}, {_description}, {_points}, {_amountCompleted}, {_target}, {_bonus}";
    }
}