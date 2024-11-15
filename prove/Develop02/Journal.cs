public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    //add a new entry 
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    //show journal
    public void Display()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }