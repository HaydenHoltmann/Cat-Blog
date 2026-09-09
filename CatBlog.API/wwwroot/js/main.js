function loadArticles() {
  fetch("/api/Articles")
    .then(response => response.json())
    .then(data => {
      data.forEach((article, index) => {
        const articleDiv = document.getElementById("articles");

        const newArticle = document.createElement("article-card");

        newArticle.textContent = article.content;
        newArticle.setAttribute("id", index.textContent);
        newArticle.setAttribute("card-title", article.title);
        newArticle.setAttribute("card-date", cleanDate(article.created));
        newArticle.setAttribute("card-author", article.author);

        articleDiv.append(newArticle);
      });
    })
    .catch(error => console.log(error));
}

function createNewPost() {
  fetch("/api/MeowrseCode", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({
      title: "Test Title",
      created: "2026-09-03T00:00:00",
      author: "Test Author",
      content: "Test Content"
    })
  }).then(response => response.json()).then(data => console.log(data));

  console.log(JSON.stringify({
    title: "Test Title",
    created: "2026-09-03T00:00:00",
    author: "Test Author",
    content: "Test Content"
  }));
}

function cleanDate(date) {
  return date.substring(0, date.indexOf("T"));
}

loadArticles();

const postButton = document.getElementById("post-button");
postButton.onclick = createNewPost;

