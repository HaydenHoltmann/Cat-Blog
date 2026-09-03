using System.Collections.Generic;

namespace CatBlog.API.Morse;

public class Morse
{
    public static Dictionary<char, string> MorseCode { get; set; } =
        new Dictionary<char, string>()
        {
            { 'A', "._" },
            { 'B', "_..." },
            { 'C', "_._." },
            { 'D', "_.." },
            { 'E', "." },
            { 'F', ".._." },
            { 'G', "__." },
            { 'H', "...." },
            { 'I', ".." },
            { 'J', ".___" },
            { 'K', "_._" },
            { 'L', "._.." },
            { 'M', "__" },
            { 'N', "_." },
            { 'O', "___" },
            { 'P', ".__." },
            { 'Q', "__._" },
            { 'R', "._." },
            { 'S', "..." },
            { 'T', "_" },
            { 'U', ".._" },
            { 'V', "..._" },
            { 'W', ".__" },
            { 'X', "_.._" },
            { 'Y', "_.__" },
            { 'Z', "__.." },
            { '0', "-----" },
            { '1', ".----" },
            { '2', "..___" },
            { '3', "...__" },
            { '4', "...._" },
            { '5', "....." },
            { '6', "_...." },
            { '7', "__..." },
            { '8', "___.." },
            { '9', "____." },
            { '.', "._._._" },
            { ',', "__..__" },
            { '!', "_._.__" },
            { '?', "..__.." },
            { '/', "_.._." },
            { '=', "_..._" },
            { ':', "___..." },
            { '\'', ".____." },
            { '-', "_...._" },
            { '(', "_.__." },
            { ')', "_.__._" },
            { '\"', "._.._." },
            { '@', ".__._." },
            { '_', "..__._" },
        };

    public static string ToMorse(string content)
    {
        string morse = "";
        string finalContent = content.ToUpper().Replace(" ", "_");

        foreach (char letter in finalContent)
        {
            if (MorseCode.ContainsKey(letter))
            {
                morse += $"{MorseCode[letter]} ";
            }
        }

        return morse;
    }

    public static string ToString(string morse)
    {
        string output = "";
        List<string> morseCharacters = morse.Split(" ").ToList<string>();

        var keys = MorseCode.Keys;

        foreach (string character in morseCharacters)
        {
            foreach (var key in keys)
            {
                if (character == MorseCode[key])
                {
                    if (key.ToString() == "_")
                    {
                        output += " ";
                    }
                    else
                    {
                        output += key.ToString();
                    }
                }
            }
        }

        Console.WriteLine($"Morse ToString: {output}");
        return output;
    }
}
