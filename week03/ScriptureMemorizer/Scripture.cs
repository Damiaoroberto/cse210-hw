using System;
using System.Collections.Generic;

public class Scripture
{
    private List<Word> _words;
    private Reference _reference;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        foreach (var word in text.Split(' '))
        {
            _words.Add(new Word(word));
        }
    }

    public void DisplayScripture()
    {
        Console.WriteLine(_reference.GetReference());
        foreach (var word in _words)
        {
            word.Display();
        }
    }

    public string GetReference()
    {
        return _reference.GetReference();
    }

    public void HideRandomWord()
    {
        Random rand = new Random();
        int index = rand.Next(_words.Count);
        while (_words[index].IsHidden)
        {
            index = rand.Next(_words.Count);
        }

        _words[index].Hide();
    }
}
