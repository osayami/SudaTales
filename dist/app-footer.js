"use strict";
class AppFooter extends HTMLElement {
    connectedCallback() {
        const year = new Date().getFullYear();
        this.innerHTML = `
      <footer class="app-footer">
        <p>© ${year} Sudanese Multimedia Community</p>
        <p>Built with open web technologies.</p>
      </footer>
    `;
    }
}
customElements.define("app-footer", AppFooter);
