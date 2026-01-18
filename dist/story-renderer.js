"use strict";
async function loadStory(storyId) {
    const res = await fetch("/data/stories.json");
    const data = await res.json();
    const story = data.stories.find(s => s.id === storyId);
    if (!story) {
        console.error("Story not found:", storyId);
        return;
    }
    const article = document.querySelector("article");
    if (!article)
        return;
    article.innerHTML = `<h1>${story.title}</h1>`;
    for (const p of story.paragraphs) {
        const el = document.createElement("paragraph-block");
        el.setAttribute("pid", p.pid);
        el.textContent = p.text;
        article.appendChild(el);
    }
}
/* --- bootstrap --- */
document.addEventListener("DOMContentLoaded", () => {
    var _a;
    const params = new URLSearchParams(window.location.search);
    const storyId = (_a = params.get("id")) !== null && _a !== void 0 ? _a : "peacock-crow";
    loadStory(storyId);
});
