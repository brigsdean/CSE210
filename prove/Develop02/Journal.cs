public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    //add a new entry to the journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    //display all entries in the journal
    public void Display()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }