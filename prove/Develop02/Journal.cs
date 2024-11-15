public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    //here to add entry
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }
    public void Display()
    {
        foreach (var entry in _entries)
        {
            entry.Display();
        }
    }
    public void SaveToFile(string file)
    {
        bool fileExists = File.Exists(file);

        using (StreamWriter writer = new StreamWriter(file, true))
        {   
            if (!fileExists)
            {
                writer.WriteLine("Date,Prompt,Entry");
            }
            foreach (var entry in _entries)
            {
                writer.WriteLine($"{entry._date},{entry._prompt},{entry._entryText}");
            }
        }
    }
    //load journal entries from a file
    public void LoadFromFile(string file)
    {
        if (File.Exists(file))
        {
            _entries.Clear();

            using (StreamReader reader = new StreamReader(file))
            {
                reader.ReadLine();
                string line;
                while ((line = reader.ReadLine()) != null)
                {   
                    var parts = line.Split(new[] { ',' }, 3);
                    if (parts.Length == 3)
                    {
                        AddEntry(new Entry { _date = parts[0], _prompt = parts[1], _entryText = parts[2] });
                    }
                }
            }
        }
    }
}
//almost lost this entire page because i accidently copied another page over it