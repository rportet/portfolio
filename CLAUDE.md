# CLAUDE.md

Guidance for Claude Code when working in this repository.

## Project

Personal portfolio of Rémy Portet, junior .NET developer.
Goal: a clean, responsive, maintainable site that showcases his skills to recruiters.
The repository itself is public and is part of the portfolio: code quality, commit history
and pull requests are read by recruiters.

Rémy is a junior developer learning professional and agentic workflows. For any non-trivial
choice, explain the reasoning briefly in the pull request description.

## Tech stack

- .NET 10, Blazor WebAssembly **standalone** (no server).
- Bootstrap 5.3, **CSS only**. Do not use Bootstrap's JavaScript plugins (collapse, offcanvas,
  scrollspy…): interactivity is implemented in Blazor components (C#), with minimal JS interop
  only when the browser API requires it (localStorage, `data-bs-theme`, IntersectionObserver).
- Hosted on GitHub Pages, deployed by GitHub Actions (`.github/workflows/deploy.yml`).
- Tests (later): xUnit + bUnit in `tests/Portfolio.Tests`.

## Repository layout

```
Portfolio.slnx
docs/design-spec.md          → design specification (source of truth for visuals)
src/Portfolio/
├── Components/              → reusable components (ProjectCard, ExperienceCard, Tag…)
├── Layout/                  → MainLayout, SiteHeader, SiteFooter
├── Pages/                   → Home, ProjectDetail, NotFound
├── Models/                  → C# records for content (Project, Experience, Education…)
├── Services/                → IContentService and its JSON implementation
├── Resources/               → SharedResource.resx (fr, default) / SharedResource.en.resx
└── wwwroot/
    ├── data/                → content JSON files
    ├── css/                 → theme.css (design tokens), app.css (global styles)
    ├── fonts/               → self-hosted fonts
    ├── images/
    └── cv/
```

## Commands

- Build: `dotnet build`
- Run locally: `dotnet run --project src/Portfolio`
- Publish (as CI does): `dotnet publish src/Portfolio/Portfolio.csproj -c Release -o release`
- Tests (once the test project exists): `dotnet test`

Always run `dotnet build` (and `dotnet test` when tests exist) before declaring a task done.

## Architecture rules

- **Content is data, not markup.** Education, experiences and projects live in JSON files in
  `wwwroot/data/`, deserialized into typed records in `Models/`. Adding a project must never
  require editing a component.
- **Localized content**: one JSON file per content type, with localized fields keyed by culture
  (`{ "fr": "…", "en": "…" }`). Non-translatable fields (slug, tags, URLs, dates) are not duplicated.
- **UI strings** (labels, buttons, section titles) go in `Resources/*.resx` and are read through
  `IStringLocalizer<SharedResource>`. No hard-coded user-facing text in components.
- Components get content through `IContentService` (injected), never by fetching JSON directly.
- Supported cultures: `fr` (default) and `en`. The culture is set at startup from the stored
  choice; changing language stores the choice and reloads the app (Microsoft's recommended
  approach for Blazor WebAssembly).
- Component-specific styles use CSS isolation (`Component.razor.css`).

## Design rules

- Follow `docs/design-spec.md`. When the spec does not cover a case, ask instead of inventing.
- **Never hard-code colors, font sizes or radii** in components: use the CSS variables
  (`--bs-*` and the project's `--rp-*` tokens) defined in `wwwroot/css/theme.css`.
- `theme.css` must be loaded after `bootstrap.min.css`.
- Light/dark theme uses Bootstrap color modes (`data-bs-theme` on `<html>`). The initial theme is
  applied by an inline script in `index.html` before Blazor starts, to avoid a flash.
- Mobile-first; desktop layout from the `lg` breakpoint.

## Accessibility

- One `h1` per page, one `h2` per section, `h3` for cards and steps.
- Every icon-only button has an `aria-label`. Touch targets ≥ 44 × 44 px on mobile.
- Visible keyboard focus on every interactive element; respect `prefers-reduced-motion`.
- Update the `lang` attribute of `<html>` when the culture changes.

## Sources (mandatory)

For any change to configuration, infrastructure, build, deployment or dependencies:
- base it on official documentation first (Microsoft Learn, GitHub Docs, getbootstrap.com,
  official sample repositories such as `dotnet/blazor-samples`);
- cite the source URL in the pull request description, and in a code comment when the
  reason for a line is not obvious;
- state explicitly when something comes from community practice rather than official docs.

## Git workflow

- Never commit directly to `main`. One branch and one pull request per task, kept small.
- After implementing a task, **stop before committing**: leave the changes uncommitted, list the modified files with a one-line summary each, and wait for Rémy's review. Commit only when he explicitly says so, then propose the commit message(s).
- Never push without explicit approval.- Branch names: `feat/…`, `fix/…`, `ci/…`, `docs/…`, `chore/…`.
- Commit messages in English, following Conventional Commits (`feat:`, `fix:`, `ci:`, `docs:`…).
- Ask before adding any NuGet package, npm package or third-party GitHub Action.
- Never commit secrets, personal data other than what is already public on the site, or
  build output (`bin/`, `obj/`, `release/`).

## Deployment notes

- The site is currently served at `https://rportet.github.io/portfolio/`.
- The `<base href>` stays `/` in source; the workflow rewrites it at deploy time from `BASE_HREF`.
- On the future switch to `https://rportet.github.io/`, two values change: `BASE_HREF` in the
  workflow and `segmentCount` in `wwwroot/404.html`. Do not change them without being asked.