using System.Text.RegularExpressions;
using CatBlog.API.Interfaces;
using CatBlog.API.Models;

namespace CatBlog.API.Services;

public class MeowrseCode : IMeowrseCode
{
    public Dictionary<char, string> Meows { get; set; } =
        new Dictionary<char, string>() { { '.', "Meow" }, { '_', "Meoow" } };

    public void ToMeowrseCode(Article currentArticle)
    {
        string meowrse = "";

        foreach (char code in Morse.Morse.ToMorse(currentArticle.Content))
        {
            if (Char.IsWhiteSpace(code))
            {
                meowrse += code;
            }
            else
            {
                if (Meows.ContainsKey(code))
                {
                    meowrse += Meows[code];
                }
            }
        }

        //Replaces Human in Content with Meows
        currentArticle.Content = meowrse;

        ArticlesController articlesController = ArticlesController.GetInstance();

        articlesController.AddArticle(currentArticle);
    }

    public string ToHumanCode(string meows)
    {
        string morse = "";
        List<string> meowList = meows.Split(" ").ToList<string>();

        var keys = Meows.Keys;

        foreach (var meow in meowList)
        {
            List<string> eachMeow = Regex.Split(meow, $"(?<=[w])").ToList<string>();

            foreach (var letter in eachMeow)
            {
                foreach (var key in keys)
                {
                    if (inputRefactor(letter.ToString()) == Meows[key])
                    {
                        morse += key.ToString();
                    }
                }
            }

            morse += " ";
        }

        return Morse.Morse.ToString(morse);
    }

    private string inputRefactor(string input)
    {
        input.ToLower();

        return input.Replace("m", "M");
    }
}
