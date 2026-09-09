using CatBlog.API.Interfaces;
using CatBlog.API.Models;
using CatBlog.API.Services;

var builder = WebApplication.CreateBuilder(args);

//Services -------
// Add services to the container.
builder.Services.AddOpenApi();
builder.Services.AddScoped<IMeowrseCode, MeowrseCode>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
    });
}

//For frontend
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseHttpsRedirection();

//Endpoints -------
app.MapGet(
        "/api/Articles",
        () =>
        {
            var controller = ArticlesController.GetInstance();

            return controller.Articles;
        }
    )
    .WithName("GetArticles");

app.MapPost(
        "/api/MeowrseCode",
        (Article newArticle) =>
        {
            /*newArticle.Title = title;
            newArticle.Created = created;
            newArticle.Author = author;
            newArticle.Content = content;*/

            MeowrseCode mw = new MeowrseCode();

            mw.ToMeowrseCode(newArticle);
        }
    )
    .WithName("PostNewBlog");

app.MapGet(
        "/api/HumanCode",
        (string meows) =>
        {
            MeowrseCode mw = new MeowrseCode();

            if (meows is not "Meow" or "meow" or "Meoow" or "meoow")
            {
                //TODO: Return Error
                //return Results.BadRequest();
            }

            return mw.ToHumanCode(meows);
        }
    )
    .WithName("GetToHuman");

//Test Endpoints
app.MapPost(
        "/api/testPost",
        (string testValue) =>
        {
            Console.WriteLine(testValue);
            return testValue;
        }
    )
    .DisableAntiforgery()
    .WithName("TestPost");

app.Run();

//Example Endpoints -------
/* Example GET endpoint
app.MapGet(
        "/weatherforecast",
        () =>
        {
            return "Hello World";
        }
    )
    .WithName("GetWeatherForecast");
*/
