using System;

public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public void Display()
    {
        if (_isHidden)
        {
            Console.Write(new string('_', _text.Length) + " ");
        }
        else
        {
            Console.Write(_text + " ");
        }
    }

    public void Hide()
    {
        _isHidden = true;
    }
}
