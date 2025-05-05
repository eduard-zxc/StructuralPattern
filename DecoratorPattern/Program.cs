public interface IText
{
    string GetFormattedText();
}

public class PlainText : IText
{
    private string _text;

    public PlainText(string text)
    {
        _text = text;
    }

    public string GetFormattedText()
    {
        return _text;
    }
}

public abstract class TextDecorator : IText
{
    protected IText _text;

    public TextDecorator(IText text)
    {
        _text = text;
    }

    public abstract string GetFormattedText();
}

public class BoldText : TextDecorator
{
    public BoldText(IText text) : base(text) { }

    public override string GetFormattedText()
    {
        return _text.GetFormattedText() + " with bold";
    }
}

public class ItalicText : TextDecorator
{
    public ItalicText(IText text) : base(text) { }

    public override string GetFormattedText()
    {
        return _text.GetFormattedText() + " with italic";
    }
}

public class UnderlineText : TextDecorator
{
    public UnderlineText(IText text) : base(text) { }

    public override string GetFormattedText()
    {
        return _text.GetFormattedText() + " with underline";
    }
}

public class ColoredText : TextDecorator
{
    private string _color;

    public ColoredText(IText text, string color) : base(text)
    {
        _color = color;
    }

    public override string GetFormattedText()
    {
        return _text.GetFormattedText() + $" in {_color} color";
    }
}

public class Program
{
    public static void Main()
    {
        IText text = new PlainText("Hello World");
        Console.WriteLine(text.GetFormattedText());

        text = new BoldText(text);
        Console.WriteLine(text.GetFormattedText());

        text = new ItalicText(text);
        Console.WriteLine(text.GetFormattedText());

        text = new UnderlineText(text);
        Console.WriteLine(text.GetFormattedText());

        text = new ColoredText(text, "red");
        Console.WriteLine(text.GetFormattedText());

        IText text2 = new BoldText(new ItalicText(new ColoredText(new PlainText("Goodbye World"), "blue")));
        Console.WriteLine(text2.GetFormattedText());
    }
}