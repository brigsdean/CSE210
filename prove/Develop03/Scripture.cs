using System;
public class Scripture
{
    private Reference _reference;
    private List<Word> _words; 
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(" ").Select(word => new Word(word)).ToList();
    }
    public void HideRandomWords( int numberToHide)
    {
        Random random = new Random();
        List<Word> visibleWords = _words.Where(word => ! word.IsHidden()).ToList();
        List<Word> wordsToHide = visibleWords.OrderBy(x => random.Next()).Take(numberToHide).ToList();

        foreach (Word word in wordsToHide)
        {
            word.Hide();
        }
    }
    public string GetFullText()
    {
        return $"{_reference.GetDisplayText()}\n{string.Join(" ", _words.Select(word => word.GetDisplayText()))}\n";
    }
    public string GetDisplayText() 
    {   
        return $"{_reference.GetDisplayText()}\n{string.Join(" ", _words.Select(word => word.GetDisplayText()))}\n";
    }
    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }
}