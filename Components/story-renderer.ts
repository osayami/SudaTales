interface StoryParagraph {
  pid: string;
  text: string;
}

interface Story {
  id: string;
  title: string;
  language: string;
  paragraphs: StoryParagraph[];
}

interface StoriesPayload {
  stories: Story[];
}

async function loadStory(storyId: string): Promise<void> {
  const res = await fetch("/data/stories.json");
  const data: StoriesPayload = await res.json();

  const story = data.stories.find(s => s.id === storyId);
  if (!story) {
    console.error("Story not found:", storyId);
    return;
  }

  const article = document.querySelector("article");
  if (!article) return;

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
  const params = new URLSearchParams(window.location.search);
  const storyId = params.get("id") ?? "peacock-crow";
  loadStory(storyId);
});
