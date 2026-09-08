class ArticleCard extends HTMLElement {

  static get observedAttributes() {
    return ["card-title", "card-date", "card-author"];
  }

  attributeChangedCallback(name, oldValue, newValue) {
    if (name === "card-title") {
      const titleElement = this.shadowRoot.getElementById("TheTitle");

      titleElement.textContent = newValue;
    }
    else if (name === "card-date") {
      const dateElement = this.shadowRoot.getElementById("TheDate");

      dateElement.textContent = newValue;
    }
    else if (name === "card-author") {
      const authorElement = this.shadowRoot.getElementById("TheAuthor");

      authorElement.textContent = newValue;
    }
  }

  constructor() {
    super();


    const shadow = this.attachShadow({ mode: "open" });
    shadow.innerHTML = `
      <style>
      h1, h5, h6{
      margin: 0;
      padding: 0;
      }

      .card{
      display: flex;
      flex-direction: column;
      border: 4px solid;
      border-radius: 1rem;
      padding: 1rem;
      margin-bottom: 1rem;
      overflow: hidden;
      text-overflow: ellipsis;
      background-color: #EFE6DD;
      height: 8rem;
      }

      #info{
      display: flex;
      justify-content: space-between;
      margin: 0.5rem;
      }

      #content{
      /*height: 5rem;*/
      margin: 0.5rem;
      }

      </style>

      <div class="card">
        <h3 id="TheTitle"></h3>
        <div id="info">
        <h6 id="TheDate"></h6> 
        <h6 id="TheAuthor">By: </h6>
        </div>
        <div id="content">
        <h5>
            <slot></slot>
          </h5>
        </div>
      </div>
      `;
  }


}



customElements.define("article-card", ArticleCard);
