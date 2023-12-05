using System;
using System.Collections.Generic;

abstract class Character
{
    protected char symbol;
    protected string font;
    protected int size;
    protected string color;

    public abstract void Display(int row, int column);
}

class ConcreteCharacter : Character
{
    public ConcreteCharacter(char symbol, string font, int size, string color)
    {
        this.symbol = symbol;
        this.font = font;
        this.size = size;
        this.color = color;
    }

    public override void Display(int row, int column)
    {
        Console.WriteLine("Symbol: " + symbol + ", Font: " + font + ", Size: " + size + ", Color: " + color + ", Row: " + row + ", Column: " + column);
    }
}

class CharacterFactory
{
    private Dictionary<char, Character> characters = new Dictionary<char, Character>();

    public Character GetCharacter(char key, string font, int size, string color)
    {
        if (characters.ContainsKey(key))
        {
            return characters[key];
        }
        else
        {
            Character character = new ConcreteCharacter(key, font, size, color);
            characters.Add(key, character);
            return character;
        }
    }
}

class Program
{
    static void Main()
    {
        CharacterFactory factory = new CharacterFactory();
        Character char1 = factory.GetCharacter('a', "Arial", 12, "Black");
        Character char2 = factory.GetCharacter('b', "Times New Roman", 14, "Red");
        Character char3 = factory.GetCharacter('a', "Arial", 12, "Black"); 
        char1.Display(1, 1);
        char2.Display(2, 3);
        char3.Display(3, 5);
    }
}