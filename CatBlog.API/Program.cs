using CatBlog.API.Interfaces;
using CatBlog.API.Models;
using CatBlog.API.Services;
using Microsoft.AspNetCore.Http;

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

app.UseHttpsRedirection();

//Endpoints -------
app.MapGet(
        "/api/MeowrseCode",
        () =>
        {
            MeowrseCode mw = new MeowrseCode();

            //return mw.ToMeowrseCode("Hello World");
        }
    )
    .WithName("GetMeowrseCode");

app.MapPost(
        "/api/MeowrseCode",
        (string title, DateTime created, string author, string content, Article newArticle) =>
        {
            newArticle.Title = title;
            newArticle.Created = created;
            newArticle.Author = author;
            newArticle.Content = content;

            MeowrseCode mw = new MeowrseCode();

            mw.ToMeowrseCode(newArticle);
        }
    )
    .WithName("NewBlogPost");

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
    .WithName("ConvertToHuman");

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
