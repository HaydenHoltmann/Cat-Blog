using System.IO;
using System.Text.Json;

namespace CatBlog.API.Models;

//Update Controller when updating Database Type

//Singleton Class
public class ArticlesController
{
    private static ArticlesController _controller;
    public List<Article> Articles
    {
        //Get From DB Source
        get { return new List<Article>(); }
    }

    private ArticlesController() { }

    public static ArticlesController GetInstance()
    {
        if (_controller == null)
        {
            return new ArticlesController();
        }
        else
        {
            return _controller;
        }
    }

    //Adds new article to db
    public bool AddArticle(Article newArticle)
    {
        if (!Directory.Exists("../Articles"))
        {
            Directory.CreateDirectory("../Articles");
        }

        var jsonString = JsonSerializer.Serialize(newArticle);

        File.WriteAllText($"../Articles/{newArticle.Title.Replace(" ", "_")}.json", jsonString);

        return true;
    }
}
