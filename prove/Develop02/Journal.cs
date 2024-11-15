public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    //add entry
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    //show previous entries
    public void Display()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }