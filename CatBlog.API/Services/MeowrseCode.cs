using CatBlog.API.Interfaces;
using CatBlog.API.Models;
using CatBlog.API.Morse;

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

        var keys = Meows.Keys;

        foreach (var meow in meows)
        {
            foreach (var key in keys)
            {
                if (meow.ToString() == Meows[key])
                {
                    morse += key.ToString();
                }
                else
                {
                    morse += " ";
                }
            }
        }

        Console.WriteLine($"MeowrseCode ToHumanCode: {morse}");
        return Morse.Morse.ToString(morse);
    }
}
