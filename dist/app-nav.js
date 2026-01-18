"use strict";
class AppNav extends HTMLElement {
    connectedCallback() {
        this.render();
    }
    render() {
        this.innerHTML = `
      <nav class="app-nav">
        <a href="/index.html">Home</a>
        <a href="/stories.html">Stories</a>
        <a href="/submit.html">Submit</a>
      </nav>
    `;
    }
}
customElements.define("app-nav", AppNav);
