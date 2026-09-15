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
  const titleBox = document.getElementById("title-box");
  const contentBox = document.getElementById("content-box");

  //TODO: Change this
  const currentAuthor = "Cat Catington";


  fetch("/api/MeowrseCode", {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify({
      title: titleBox.value,
      created: new Date(),
      author: `By: ${currentAuthor}`,
      content: contentBox.value
    })
  }).then(response => {
    //Reset input values
    titleBox.value = "";
    contentBox.value = "";

    //Reset articles
    window.location.reload();
  });

}

function getProfile() {
  const profileName = document.getElementById("profile-name");
  const profileAge = document.getElementById("profile-age");
  const profileBio = document.getElementById("profile-bio");

  fetch("/api/Profile/Get").then(response => response.json()).then(data => {
    profileName.textContent += data.name;
    profileAge.textContent += data.age;
    profileBio.textContent += data.bio;

  }).catch(error => console.log(error));

}

function cleanDate(date) {
  return date.substring(0, date.indexOf("T"));
}

function toggleProfile() {
  const profileInfoElement = document.getElementById("profile-info");
  const profilePictureElement = document.getElementById("profile-picture");

  profileInfoElement.classList.toggle("open");
  profilePictureElement.classList.toggle("open");
}

loadArticles();
getProfile();

const postButton = document.getElementById("post-button");
postButton.onclick = createNewPost;

const profilePicture = document.getElementById("profile-picture");
profilePicture.onclick = toggleProfile;

