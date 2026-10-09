// Color mode helpers for the ThemeToggle component, loaded as a JavaScript module:
// https://learn.microsoft.com/aspnet/core/blazor/javascript-interoperability/call-javascript-from-dotnet#javascript-isolation-in-javascript-modules
// The initial theme is applied by the inline script in index.html, which reads the same "theme" key.

export function getTheme() {
    return document.documentElement.getAttribute('data-bs-theme') === 'dark' ? 'dark' : 'light';
}

export function setTheme(theme) {
    document.documentElement.setAttribute('data-bs-theme', theme);
    try {
        localStorage.setItem('theme', theme);
    } catch {
        // localStorage can be unavailable (privacy settings): the choice only lasts for this page.
    }
}
