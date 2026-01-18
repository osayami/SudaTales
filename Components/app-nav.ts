class AppNav extends HTMLElement {
  connectedCallback(): void {
    this.render();
  }

  private render(): void {
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
