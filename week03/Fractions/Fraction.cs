using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    // no argument constructor 
    public Fraction()
    {
        _top = 1; 
        _bottom = 1;
    }

    // one argument constructor
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // two argument constructor
    public Fraction(int top, int bottom)
    {
        _top = top; 
        _bottom = bottom; 
    }

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
        
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // representation 
    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }

    public double GetDecimalValue()
    {
        // cast top to a double and make C# perform decimal division
        return (double)_top / (double)_bottom;
    }

}