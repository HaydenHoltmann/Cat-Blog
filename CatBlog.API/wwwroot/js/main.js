fetch("/api/Articles")
  .then(response => response.json())
  .then(data => {
    data.forEach((article, index) => {
      const articleDiv = document.getElementById("articles");

      const newArticle = document.createElement("article-card");

      newArticle.textContent = article.content;
      newArticle.setAttribute("id", index.textContent);
      newArticle.setAttribute("card-title", article.title);
      console.log(`The date: ${article.created}`);
      newArticle.setAttribute("card-date", cleanDate(article.created));
      newArticle.setAttribute("card-author", article.author);

      articleDiv.append(newArticle);
    });
  })
  .catch(error => console.log(error));

function cleanDate(date) {
  return date.substring(0, date.indexOf("T"));
}



