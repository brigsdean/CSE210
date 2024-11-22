using System;

public class Reference 
{

     private string _book {get; set;}
    private int _chapter {get; set;}
    private int _verse {get; set;}
    private int _endVerse {get; set;}

     public Reference (string book, int chapter, int verse)
     {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }
    public Reference (string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText() //retorna a referencia formatada
    {
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}