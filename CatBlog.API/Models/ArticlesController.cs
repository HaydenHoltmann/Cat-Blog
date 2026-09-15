using System.IO;
using System.Text.Json;

namespace CatBlog.API.Models;

//Update Controller when updating Database Type

//Singleton Class
public class ArticlesController
{
    private static readonly string _articlePath = "../Data/Articles";

    //private static readonly string _articlePath = "../../Data/Articles";

    private static ArticlesController _controller;

    public List<Article> Articles
    {
        //Get From DB Source
        get
        {
            if (!Directory.Exists(_articlePath))
            {
                return new List<Article>();
            }

            List<Article> allArticles = new List<Article>();

            //Get path names from directory
            var paths = Directory.GetFiles(_articlePath);

            foreach (var path in paths)
            {
                var articleJson = File.ReadAllText(path);

                Article newArticle = JsonSerializer.Deserialize<Article>(articleJson);

                allArticles.Add(newArticle);
            }

            return allArticles;
        }
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
        if (!Directory.Exists(_articlePath))
        {
            Directory.CreateDirectory(_articlePath);
        }

        var jsonString = JsonSerializer.Serialize(newArticle);

        File.WriteAllText($"{_articlePath}/{newArticle.Title.Replace(" ", "_")}.json", jsonString);

        return true;
    }
}
