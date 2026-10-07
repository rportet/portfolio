# Portfolio Rémy Portet : spécification de la direction « Modulaire » (1c)

Cible technique : Blazor WebAssembly avec Bootstrap 5.3.
Maquette de référence : `Portfolio Directions.dc.html`, option **1c** (desktop en thème clair à 1120 px, mobile en thème sombre à 375 px).

Principes :
- Mobile-first. La mise en page passe en desktop à partir de `lg` (≥ 992 px).
- Pas d'ombre au repos. Les surfaces se détachent par un fond et une bordure de 1 px.
- Deux accents de même luminosité et de même chroma : un **indigo** (accent principal) et un **orange brûlé** (accent secondaire, réservé au CV et au badge « Stage »).
- Le thème est porté par l'attribut `data-bs-theme="light|dark"` sur `<html>` (color modes de Bootstrap 5.3).

---

## 0. Méthode de personnalisation

Bootstrap 5.3 se personnalise à deux niveaux :

1. **Variables CSS globales** (`--bs-*`) redéfinies dans `:root, [data-bs-theme=light]` et `[data-bs-theme=dark]`. C'est suffisant pour le fond, le texte, les bordures, les liens, les arrondis et les polices.
2. **Variables CSS de composant** (`--bs-btn-*`, `--bs-nav-link-*`, `--bs-badge-*`…). Les classes `.btn-primary` et autres sont compilées depuis Sass : changer `--bs-primary` **ne recolore pas** `.btn-primary`. Il faut redéfinir ses `--bs-btn-*`, ou créer une classe dédiée (voir §5).

Si le projet compile Sass (par exemple avec `AspNetCore.SassCompiler`), on peut aussi fixer `$primary`, `$font-family-sans-serif`, `$border-radius`, etc. Les équivalents Sass sont indiqués entre crochets quand c'est utile.

Les variables propres au projet sont préfixées `--rp-`.

---

## 1. Palette

Tous les couples texte/fond listés ci-dessous respectent WCAG AA (≥ 4,5:1). Le ratio mesuré est indiqué.

### 1.1 Thème clair

| Rôle | Hex | Variable Bootstrap | Remarque |
|---|---|---|---|
| Fond de page | `#F7F7F8` | `--bs-body-bg` | |
| Surface (cards, en-tête) | `#FFFFFF` | `--bs-secondary-bg` + `--rp-surface` | |
| Surface 2 (chips, tags, sélecteur FR/EN) | `#EFEFF2` | `--bs-tertiary-bg` | |
| Texte principal | `#121216` | `--bs-body-color`, `--bs-emphasis-color` | |
| Texte secondaire (dates, méta) | `#55555F` | `--bs-secondary-color` | 6,9:1 sur le fond |
| Texte courant dans les cards | `#3A3A44` | `--rp-text-muted-strong` | |
| Texte de navigation | `#4A4A55` | `--bs-nav-link-color` | 8,7:1 sur blanc |
| Bordure | `#E3E3E8` | `--bs-border-color` | |
| Bordure en pointillés (placeholder) | `#D6D6DD` | `--rp-border-dashed` | Sert aussi à la ligne de la timeline |
| Point de timeline passé | `#8A8A96` | `--rp-timeline-dot-muted` | Élément non textuel, ≥ 3:1 |
| **Accent indigo** | `#484DD2` | `--bs-primary` (`--bs-primary-rgb: 72,77,210`) [`$primary`] | Texte blanc : 6,4:1 |
| Indigo au survol | `#3B39BD` | `--rp-primary-hover`, `--bs-link-hover-color` | |
| Indigo en texte | `#3632B6` | `--bs-primary-text-emphasis`, `--bs-link-color` | |
| Indigo, fond teinté | `#EBE9FB` | `--bs-primary-bg-subtle` | Texte `#3632B6` : 7,7:1 |
| **Accent orange** | `#B72200` | `--rp-accent-2` | Texte blanc : 6,5:1 |
| Orange au survol | `#9B1700` | `--rp-accent-2-hover` | |
| Orange en texte | `#9B2300` | `--rp-accent-2-text` | |
| Orange, fond teinté | `#FBE9DF` | `--rp-accent-2-bg-subtle` | Texte `#9B2300` : 6,8:1 |
| Bloc Contact : fond | `#121216` | `--rp-contrast-bg` | Bloc inversé |
| Bloc Contact : texte secondaire | `#B8B8C4` | `--rp-contrast-muted` | 9,5:1 |
| Bloc Contact : accent | `#93A4FF` | `--rp-contrast-accent` | 8,0:1 |
| Bloc Contact : bordure | `#3A3A44` | `--rp-contrast-border` | |
| Anneau de focus | `rgba(72,77,210,.40)` | `--bs-focus-ring-color` | |

### 1.2 Thème sombre

| Rôle | Hex | Variable Bootstrap | Remarque |
|---|---|---|---|
| Fond de page | `#101014` | `--bs-body-bg` | |
| Surface (cards, en-tête) | `#1A1A20` | `--bs-secondary-bg` + `--rp-surface` | |
| Surface 2 (chips, tags, bouton menu) | `#2A2A33` | `--bs-tertiary-bg` | |
| Texte principal | `#F1F1F4` | `--bs-body-color`, `--bs-emphasis-color` | |
| Texte secondaire | `#A6A6B3` | `--bs-secondary-color` | 7,2:1 sur une surface, 5,9:1 sur la surface 2 |
| Texte courant dans les cards | `#D4D4DC` | `--rp-text-muted-strong` | |
| Texte de navigation | `#C4C4CF` | `--bs-nav-link-color` | |
| Bordure | `#2A2A33` | `--bs-border-color` | |
| Bordure en pointillés, ligne de timeline | `#3A3A44` | `--rp-border-dashed` | |
| Point de timeline passé | `#F1F1F4` | `--rp-timeline-dot-muted` | |
| **Accent indigo** | `#93A4FF` | `--bs-primary` (`--bs-primary-rgb: 147,164,255`) | Texte `#101014` sur l'accent : 8,1:1 |
| Indigo au survol | `#ADBEFF` | `--rp-primary-hover`, `--bs-link-hover-color` | |
| Indigo en texte | `#C9C4FF` | `--bs-primary-text-emphasis`, `--bs-link-color` | |
| Indigo, fond teinté | `#2B2850` | `--bs-primary-bg-subtle` | Texte `#C9C4FF` : 8,4:1 |
| **Accent orange** | `#FA8C58` | `--rp-accent-2` | Texte `#101014` : 8,1:1 |
| Orange au survol | `#FFAB82` | `--rp-accent-2-hover` | |
| Orange en texte | `#FFC8A8` | `--rp-accent-2-text` | |
| Orange, fond teinté | `#3D2A1F` | `--rp-accent-2-bg-subtle` | Texte `#FFC8A8` : 9,1:1 |
| Bloc Contact : fond | `#F1F1F4` | `--rp-contrast-bg` | Le bloc reste inversé, donc clair |
| Bloc Contact : texte secondaire | `#4A4A55` | `--rp-contrast-muted` | |
| Bloc Contact : accent | `#484DD2` | `--rp-contrast-accent` | |
| Bloc Contact : bordure | `#C9C9D2` | `--rp-contrast-border` | |
| Anneau de focus | `rgba(147,164,255,.50)` | `--bs-focus-ring-color` | |

### 1.3 États de survol et d'interaction

| Élément | Clair | Sombre |
|---|---|---|
| Card ou tuile cliquable (survol) | Bordure → `#484DD2` + `--rp-shadow-hover` | Fond → `#20202A`, bordure → `#93A4FF` |
| Bouton primaire | Fond `#484DD2` → `#3B39BD` | Fond `#93A4FF` → `#ADBEFF` |
| Bouton CV (orange) | `#B72200` → `#9B1700` | `#FA8C58` → `#FFAB82` |
| Lien de navigation | `#4A4A55` → `#121216` | `#C4C4CF` → `#F1F1F4` |
| Lien de navigation actif (section visible) | `#121216` + soulignement 2 px `#484DD2` | `#F1F1F4` + soulignement `#93A4FF` |
| Bouton pilule à contour (bloc Contact) | Fond → `rgba(255,255,255,.08)` | Fond → `rgba(16,16,20,.06)` |
| Flèche de tuile / de card | Décalage `translate(2px,-2px)` (↗) ou `translateX(3px)` (→), 150 ms | idem |
| Focus clavier (tous éléments) | `box-shadow: 0 0 0 .25rem var(--bs-focus-ring-color)` | idem |

Respecter `prefers-reduced-motion: reduce` : supprimer les translations.

---

## 2. Typographie

### 2.1 Familles (Google Fonts)

| Usage | Police | Variable Bootstrap | Repli |
|---|---|---|---|
| Titres, logo, chiffres de la stack, e-mail | **Bricolage Grotesque** (Google Fonts, axe optique 12–96) | `--rp-font-display` (`--bs-heading-font-family` n'existe pas : appliquer sur `h1–h3`, `.display-*`) | `system-ui, sans-serif` |
| Texte courant, UI, tags | **Figtree** (Google Fonts) | `--bs-body-font-family` [`$font-family-sans-serif`] | `system-ui, -apple-system, "Segoe UI", sans-serif` |
| Légendes techniques (placeholders uniquement) | Monospace système | `--bs-font-monospace` | `ui-monospace, Menlo, Consolas, monospace` |

Chargement (dans `index.html`, en `<head>`) :

```html
<link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Bricolage+Grotesque:opsz,wght@12..96,700;12..96,800&family=Figtree:wght@400;500;600;700&display=swap" rel="stylesheet">
```

Pour un site sur GitHub Pages, on peut auto-héberger ces polices (fichiers woff2 dans `wwwroot/fonts`) pour éviter l'appel à Google.

### 2.2 Échelle

Tailles fluides avec `clamp()` entre 375 px et 1200 px. Valeurs en px pour mobile → desktop.

| Niveau | Police | Mobile → desktop | Graisse | Interligne | Interlettrage | Variable / classe |
|---|---|---|---|---|---|---|
| Nom (H1 du hero) | Bricolage | 60 → 112 px · `clamp(3.75rem, 2.27rem + 6.3vw, 7rem)` | 800 | 0.88 | −0.045em | `--rp-fs-display`, `.display-1` redéfinie |
| E-mail (bloc Contact) | Bricolage | 30 → 56 px · `clamp(1.875rem, 1.14rem + 3.15vw, 3.5rem)` | 800 | 1.0 | −0.035em | `--rp-fs-contact` |
| Titre de section (H2) | Bricolage | 32 → 48 px · `clamp(2rem, 1.55rem + 1.94vw, 3rem)` | 800 | 1.1 | −0.03em | `--rp-fs-h2` (`h2`, `.h2`) |
| Valeurs de la stack | Bricolage | 22 → 30 px | 700 | 1.1 (desktop) / 1.25 (mobile, une ligne par stack) | −0.02em | `--rp-fs-stack` |
| Titre de card (expérience, projet) | Bricolage | 21 → 28 px | 700 | 1.1–1.15 | −0.02em | `--rp-fs-h3` (`h3`, `.h3`) |
| Titre de timeline (formation) | Bricolage | 21 → 26 px | 700 | 1.15 | −0.02em | `h3` avec `--rp-fs-h3` |
| Logo « rémy.portet » | Bricolage | 17 → 20 px | 800 | 1 | −0.02em | `.navbar-brand` |
| Accroche (lead) | Figtree | 16 → 19 px | 400 | 1.55 | 0 | `.lead` → `--rp-fs-lead` |
| Texte courant | Figtree | 15 → 16 px | 400 | 1.55 | 0 | `--bs-body-font-size: 1rem`, `--bs-body-line-height: 1.55` |
| Description dans une card | Figtree | 14 → 15 px | 400 | 1.55 | 0 | `.small` adaptée |
| Navigation | Figtree | 15 px | 500 | 1.2 | 0 | `--bs-nav-link-font-size`, `--bs-nav-link-font-weight` |
| Libellé de tuile (GitHub, CV…) | Figtree | 15 → 17 px | 600 | 1.2 | 0 | `.btn` personnalisé |
| Surtitre (« Stack principale ») | Figtree | 12 → 13 px | 700 | 1.2 | 0.06em, majuscules | `.rp-overline` |
| Dates, méta | Figtree | 13 → 14 px | 600 | 1.3 | 0 | `--bs-secondary-color` |
| Badge (type de contrat, intitulé) | Figtree | 12 → 13 px | 600 | 1 | 0 | `--bs-badge-font-size`, `--bs-badge-font-weight` |
| Tag de technologie | Figtree | 12 → 13 px | 500 | 1 | 0 | `.rp-tag` |
| Pied de page | Figtree | 13 px | 400 | 1.4 | 0 | `.small` |

Règles : `text-wrap: pretty` sur les paragraphes, `text-wrap: balance` sur les H2. Longueur maximale de l'accroche : `max-width: 32.5rem` (520 px).

---

## 3. Espacements, arrondis, ombres, largeur

### 3.1 Largeur et gouttières

| Élément | Valeur | Bootstrap |
|---|---|---|
| Largeur max du contenu | 1200 px | `$container-max-widths: (xxl: 1200px)`, ou `.container` avec `max-width: 1200px` |
| Marge latérale de page | 12 px mobile → 20 px desktop | `--bs-gutter-x` du container : `1.5rem` → surcharger `.container { --bs-gutter-x: 1.5rem }` (12 px de chaque côté) puis `2.5rem` en `lg` |
| Gouttière entre blocs | 10 px mobile → 16 px desktop | `.g-2` (8 px) trop serré : définir `--bs-gutter-x/y: .625rem` → `1rem` (`.g-3` en `lg`) |

### 3.2 Échelle d'espacement

Bootstrap `$spacer: 1rem`. On ajoute deux paliers pour les grands écarts entre sections :
`$spacers: (…, 6: 4.5rem, 7: 6rem)`. Sans Sass, utiliser `--rp-space-section`.

| Usage | Mobile | Desktop | Utilitaire |
|---|---|---|---|
| Écart entre sections | 40 px | 72 px avant Formation, 48 px ensuite | `--rp-space-section: clamp(2.5rem, 1.5rem + 4vw, 4.5rem)` |
| Titre de section → contenu | 20 px | 28–36 px | `mb-4` / `mb-lg-5` (adapter) |
| Padding de la card du hero | 28 × 20 px | 48 × 44 px | `p-4` / `p-lg-5` personnalisés |
| Padding des cards (expérience, stack) | 22 × 20 px | 32 px | `--rp-card-pad: 1.25rem` → `2rem` |
| Padding des tuiles de lien | 16 px | 22 × 24 px | |
| Padding de l'en-tête | 4 / 4 / 4 / 16 px | 14 / 16 / 14 / 24 px | |
| Entre tags | 5 px | 6 px | `gap-1` + surcharge |
| Padding d'un tag | 5 × 10 px | 6 × 12 px | |

### 3.3 Arrondis

| Élément | Mobile | Desktop | Variable Bootstrap |
|---|---|---|---|
| Grandes cards (hero, stack, expérience, projet, Contact) | 20 px | 24 px | `--bs-border-radius-xl` → `1.25rem` / `1.5rem` [`$border-radius-xl`] |
| Tuiles de lien | 16 px | 20 px | `--bs-border-radius-lg` → `1rem` / `1.25rem` |
| En-tête | 14 px | 16 px | `--bs-border-radius` → `.875rem` / `1rem` |
| Bouton menu (hamburger) | 10 px | — | `--bs-border-radius-sm: .625rem` |
| Tags, badges, sélecteur FR/EN, pilules | 999 px | 999 px | `--bs-border-radius-pill` (déjà `50rem`) |
| Boutons ronds (thème, flèche de projet) | 50 % | 50 % | `.rounded-circle` |

### 3.4 Ombres

Aucune ombre au repos (`$enable-shadows: false`, valeur par défaut). Au survol des éléments cliquables, en thème clair seulement :

| Variable | Valeur |
|---|---|
| `--bs-box-shadow-sm` | `0 1px 2px rgba(18,18,22,.04)` |
| `--rp-shadow-hover` (clair) | `0 8px 24px -8px rgba(18,18,22,.14)` |
| `--rp-shadow-hover` (sombre) | `none` (un changement de fond suffit) |

### 3.5 Bordures

`--bs-border-width: 1px`. Les placeholders de projet utilisent `2px dashed var(--rp-border-dashed)`. La ligne de la timeline fait 2 px.

---

## 4. Bloc de variables (référence)

```css
:root, [data-bs-theme=light] {
  --bs-body-font-family: "Figtree", system-ui, -apple-system, "Segoe UI", sans-serif;
  --bs-body-font-size: 1rem;
  --bs-body-line-height: 1.55;
  --rp-font-display: "Bricolage Grotesque", system-ui, sans-serif;

  --bs-body-bg: #F7F7F8;        --bs-body-bg-rgb: 247,247,248;
  --bs-body-color: #121216;     --bs-body-color-rgb: 18,18,22;
  --bs-emphasis-color: #121216;
  --bs-secondary-color: #55555F;
  --bs-secondary-bg: #FFFFFF;
  --bs-tertiary-bg: #EFEFF2;
  --bs-border-color: #E3E3E8;

  --bs-primary: #484DD2;        --bs-primary-rgb: 72,77,210;
  --bs-primary-text-emphasis: #3632B6;
  --bs-primary-bg-subtle: #EBE9FB;
  --bs-primary-border-subtle: #C9C6F4;
  --bs-link-color: #3632B6;     --bs-link-color-rgb: 54,50,182;
  --bs-link-hover-color: #3B39BD; --bs-link-hover-color-rgb: 59,57,189;
  --bs-focus-ring-color: rgba(72,77,210,.40);

  --bs-border-radius: 1rem;
  --bs-border-radius-sm: .625rem;
  --bs-border-radius-lg: 1.25rem;
  --bs-border-radius-xl: 1.5rem;

  --rp-surface: #FFFFFF;
  --rp-text-muted-strong: #3A3A44;
  --rp-nav: #4A4A55;
  --rp-border-dashed: #D6D6DD;
  --rp-timeline-dot-muted: #8A8A96;
  --rp-primary-hover: #3B39BD;
  --rp-on-primary: #FFFFFF;
  --rp-accent-2: #B72200;  --rp-accent-2-hover: #9B1700;
  --rp-accent-2-text: #9B2300;  --rp-accent-2-bg-subtle: #FBE9DF;
  --rp-on-accent-2: #FFFFFF;
  --rp-contrast-bg: #121216;  --rp-contrast-color: #FFFFFF;
  --rp-contrast-muted: #B8B8C4;  --rp-contrast-accent: #93A4FF;
  --rp-contrast-border: #3A3A44;
  --rp-surface-hover: #FFFFFF;
  --rp-shadow-hover: 0 8px 24px -8px rgba(18,18,22,.14);
}

[data-bs-theme=dark] {
  --bs-body-bg: #101014;        --bs-body-bg-rgb: 16,16,20;
  --bs-body-color: #F1F1F4;     --bs-body-color-rgb: 241,241,244;
  --bs-emphasis-color: #F1F1F4;
  --bs-secondary-color: #A6A6B3;
  --bs-secondary-bg: #1A1A20;
  --bs-tertiary-bg: #2A2A33;
  --bs-border-color: #2A2A33;

  --bs-primary: #93A4FF;        --bs-primary-rgb: 147,164,255;
  --bs-primary-text-emphasis: #C9C4FF;
  --bs-primary-bg-subtle: #2B2850;
  --bs-primary-border-subtle: #3E3A72;
  --bs-link-color: #C9C4FF;     --bs-link-color-rgb: 201,196,255;
  --bs-link-hover-color: #ADBEFF; --bs-link-hover-color-rgb: 173,190,255;
  --bs-focus-ring-color: rgba(147,164,255,.50);

  --rp-surface: #1A1A20;
  --rp-text-muted-strong: #D4D4DC;
  --rp-nav: #C4C4CF;
  --rp-border-dashed: #3A3A44;
  --rp-timeline-dot-muted: #F1F1F4;
  --rp-primary-hover: #ADBEFF;
  --rp-on-primary: #101014;
  --rp-accent-2: #FA8C58;  --rp-accent-2-hover: #FFAB82;
  --rp-accent-2-text: #FFC8A8;  --rp-accent-2-bg-subtle: #3D2A1F;
  --rp-on-accent-2: #101014;
  --rp-contrast-bg: #F1F1F4;  --rp-contrast-color: #101014;
  --rp-contrast-muted: #4A4A55;  --rp-contrast-accent: #484DD2;
  --rp-contrast-border: #C9C9D2;
  --rp-surface-hover: #20202A;
  --rp-shadow-hover: none;
}

@media (max-width: 991.98px) {
  :root {
    --bs-border-radius: .875rem;
    --bs-border-radius-lg: 1rem;
    --bs-border-radius-xl: 1.25rem;
  }
}
```

Note : en thème sombre, la maquette mobile utilise la teinte indigo claire `#93A4FF` comme fond de la card « Stack principale » avec le texte `#101014`. En thème clair, ce fond est `#484DD2` avec le texte blanc. Les deux passent par `--bs-primary` / `--rp-on-primary`.

---

## 5. Composants

Grille : mobile-first, une colonne par défaut, passage en desktop à `lg`.

### 5.1 En-tête (`<SiteHeader>`)

- **Desktop** : barre `--rp-surface`, bordure 1 px, rayon `--bs-border-radius`, collée en haut (`sticky-top` avec `top: 20px`). Trois zones en `d-flex justify-content-between align-items-center` :
  - le logo « rémy.portet » (Bricolage 800) ;
  - les liens d'ancre Formation · Expériences · Projets · Contact (Figtree 15/500, `gap: 28px`) ;
  - le **sélecteur de langue** : deux pilules dans un conteneur `--bs-tertiary-bg`, la langue active en fond `--bs-body-color` et texte `--bs-body-bg` (`role="group"`, `aria-pressed`) ;
  - le **bouton de thème** : rond de 36 px sur `--bs-tertiary-bg`, avec un cercle à moitié plein comme icône (`aria-label="Passer en thème sombre"`).
- **Lien actif** : soulignement 2 px `--bs-primary`, décalé de 6 px, suivi au scroll (Scrollspy Bootstrap ou `IntersectionObserver` via JS interop).
- **Mobile** : barre rayon 14 px, padding réduit. Logo à gauche ; à droite trois cibles de **44 × 44 px** : la langue (un seul bouton qui affiche la langue courante et bascule FR ↔ EN), le thème, et le menu (deux traits de 16 × 2 px sur `--bs-tertiary-bg`, rayon 10 px). Le menu ouvre un `offcanvas-top` ou un `collapse` avec les 4 ancres en grand (Bricolage 28/700). Il se ferme au clic sur un lien.
- Thème : lire `prefers-color-scheme` au premier chargement, mémoriser le choix dans `localStorage`, appliquer `data-bs-theme` sur `<html>` **avant** le démarrage de Blazor (script inline dans `index.html`) pour éviter un flash.

### 5.2 Hero en blocs (`<Hero>`)

Grille `row g-3` (gouttière 10 px en mobile).

| Bloc | Colonnes | Contenu |
|---|---|---|
| Card de présentation | `col-12 col-lg-8` | Badge « Développeur informatique » (pilule `--bs-tertiary-bg`, pastille de 8 px `--bs-primary`), H1 « Rémy / Portet » sur deux lignes, accroche `.lead` |
| Card « Stack principale » | `col-12 col-lg-4` | Fond `--bs-primary`, texte `--rp-on-primary`. Surtitre, puis deux groupes « Web » / « Mobile » séparés par un filet `rgba(255,255,255,.35)` ; le surtitre est poussé en haut (`mt-auto` sur le contenu) |
| 4 tuiles de lien | `col-6 col-lg-3` | GitHub ↗, LinkedIn ↗, E-mail ↗ sur `--rp-surface` avec bordure ; **CV (PDF) ↓** sur `--rp-accent-2` |

- Mobile : empilement ; les tuiles forment une grille 2 × 2. Sur la card stack en mobile, une stack par ligne, sans le filet ni les libellés « Web/Mobile ».
- Tuile : `<a>` sur toute sa surface, libellé à gauche, flèche à droite (`justify-content-between`). GitHub et LinkedIn en `target="_blank" rel="noopener"` ; l'e-mail en `mailto:` ; le CV en lien `download` vers `wwwroot/cv/remy-portet-cv.pdf`.
- Survol : voir §1.3.

### 5.3 Titre de section (`<SectionTitle>`)

`h2` Bricolage 800, sans surtitre ni numéro. Chaque `<section>` porte un `id` (`formation`, `experiences`, `projets`, `contact`) et `scroll-margin-top: 96px` pour compenser l'en-tête collant.

### 5.4 Timeline de formation (`<EducationTimeline>`)

- **Desktop** : frise **horizontale chronologique** (de gauche à droite : Bac 2022 → CPGE 2022–2023 → BUT 2023–2026), en `row row-cols-3`. Une ligne de 2 px `--rp-border-dashed` passe sous les points (positionnée en absolu à `top: 7px`).
  - Point de 16 px : Bac = cercle vide, bordure 2 px `--rp-timeline-dot-muted` ; CPGE = disque `--bs-body-color` ; BUT = disque `--bs-primary` (étape la plus récente).
  - Contenu : date (Figtree 14/600, `--bs-secondary-color`), titre (Bricolage 26/700), sous-titre (15 px secondaire).
  - **Ligne discrète du Bac** : pas de titre Bricolage, uniquement « Bac général maths-physique » en 16 px `--bs-secondary-color`.
- **Mobile** : timeline **verticale, la plus récente en haut** (BUT → CPGE → Bac). On utilise `flex-column-reverse` sur le même balisage, ou `order-*`. Ligne verticale 2 px à gauche, points de 14 px, le Bac réduit à une ligne de 14 px avec un point de 10 px.
- Sémantique : `<ol>` avec un `<li>` par étape, et des `<time>` pour les dates.

### 5.5 Card d'expérience (`<ExperienceCard>`)

- Grille `row g-3`, chaque card en `col-12 col-lg-6` (alternance puis stage).
- Card : `--rp-surface`, bordure, rayon `--bs-border-radius-xl`, padding `--rp-card-pad`.
- En-tête de card (`d-flex justify-content-between`) :
  - **badge de type** en pilule : « Alternance · 3e année » en `--bs-primary-bg-subtle` / `--bs-primary-text-emphasis` ; « Stage · 2e année » en `--rp-accent-2-bg-subtle` / `--rp-accent-2-text` ;
  - période alignée à droite (14/600, secondaire).
- Titre `h3` (Bricolage), description d'une à deux lignes (`--rp-text-muted-strong`), puis la liste des tags (§5.7).
- **Mobile** : badge raccourci (« Alternance », « Stage »), description masquée (`d-none d-md-block`) pour garder une lecture en moins d'une minute. Les tags restent visibles.
- La card n'est pas cliquable : pas d'état de survol.

### 5.6 Card de projet (`<ProjectCard>`)

- Grille : le premier projet est mis en avant en `col-12 col-lg-7`, les suivants en `col-12 col-md-6 col-lg-5`. À partir de 3 projets, passer en `row-cols-1 row-cols-md-2` uniforme.
- Structure :
  - image en `.ratio .ratio-16x9` (mobile `16x10`), `object-fit: cover`, coins hauts arrondis par le `overflow: hidden` de la card ;
  - corps `d-flex justify-content-between align-items-end`, avec à gauche le titre (Bricolage 28/700), l'accroche (15 px) et les tags, à droite un **bouton rond de 52 px** (44 px en mobile) `--bs-body-color` / `--bs-body-bg` portant une flèche →.
- **Toute la card est cliquable** : le titre est un `<a href="projets/{slug}">` avec `.stretched-link`. Survol : bordure `--bs-primary` + `--rp-shadow-hover`, la flèche avance de 3 px.
- Mobile : les tags sont masqués sous l'accroche (`d-none d-sm-flex`), la flèche reste à droite.
- Données : `Projects.json` dans `wwwroot/data` (slug, titre FR/EN, accroche FR/EN, tags, image, URL du repo, URL de la démo).
- Placeholder (pas de projet) : bordure `2px dashed --rp-border-dashed`, rayon xl. À ne pas publier en production.

### 5.7 Tag de technologie (`.rp-tag`)

- Pilule : `--bs-tertiary-bg`, texte `--bs-body-color`, Figtree 13/500 (12 en mobile), padding 6 × 12 px (5 × 10 en mobile).
- Liste en `<ul class="d-flex flex-wrap gap-1">` avec un `<li>` par tag, et `aria-label="Technologies"` sur la liste.
- Non interactif : pas de survol ni de curseur pointeur.
- Base Bootstrap possible : `.badge.rounded-pill` en redéfinissant `--bs-badge-color`, `--bs-badge-font-size`, `--bs-badge-font-weight` et `--bs-badge-padding-x/y`.

### 5.8 Badge (`.rp-badge`)

Même forme que le tag, en 13/600. Les variantes de couleur sont décrites au §5.5. Le badge du hero ajoute une pastille de couleur de 8 px.

### 5.9 Boutons

| Variante | Usage | Styles |
|---|---|---|
| `.btn-primary` redéfini | Actions principales (page projet : « Voir la démo ») | `--bs-btn-bg: var(--bs-primary)`, `--bs-btn-color: var(--rp-on-primary)`, `--bs-btn-hover-bg: var(--rp-primary-hover)`, `--bs-btn-border-radius: var(--bs-border-radius-pill)`, padding 12 × 18 px, Figtree 15/600 |
| `.btn-rp-accent` (nouvelle) | Uniquement le CV | Mêmes variables, avec `--rp-accent-2`, `--rp-accent-2-hover` et `--rp-on-accent-2` |
| `.btn-outline-rp-contrast` | Liens dans le bloc Contact | Fond transparent, bordure `--rp-contrast-border`, texte `--rp-contrast-color`, rayon pilule |
| Bouton rond (thème, flèche) | Icône seule | 36 / 44 / 52 px, `.rounded-circle`, `aria-label` obligatoire |

Cible tactile minimale de 44 × 44 px en mobile pour toutes les variantes.

### 5.10 Bloc Contact (`<ContactBlock>`)

- Bloc pleine largeur du container, fond `--rp-contrast-bg`, rayon xl, padding 56 × 44 px (28 × 20 en mobile).
- **Desktop** : `d-flex justify-content-between align-items-end`. À gauche, le libellé « Contact » (`--rp-contrast-muted`) puis l'e-mail en Bricolage 56/800 sur deux lignes (« remy.portet » / « @email.com », la seconde en `--rp-contrast-accent`). À droite, les boutons GitHub ↗, LinkedIn ↗ et CV ↓ (le CV en `.btn-rp-accent`).
- **Mobile** : empilement, e-mail en 30 px, boutons sur une ligne avec retour à la ligne si besoin. Le CV peut être omis ici, puisqu'il est déjà dans le hero.
- L'e-mail est un lien `mailto:`. Ajouter un bouton « Copier » discret qui donne un retour « Copié » via `aria-live` (optionnel).
- Pas de formulaire.

### 5.11 Pied de page (`<SiteFooter>`)

Ligne de 13 px en `--bs-secondary-color`, « © 2026 Rémy Portet » à gauche et « Blazor WebAssembly · GitHub Pages » à droite. En mobile, les deux mentions s'empilent et se centrent.

---

## 6. Accessibilité et i18n

- Contrastes vérifiés : voir les ratios au §1.
- Ordre des titres : un seul `h1` (le nom), un `h2` par section, des `h3` pour les cards et les étapes.
- Lien d'évitement « Aller au contenu » en premier élément focusable.
- Langue : attribut `lang` mis à jour sur `<html>` au changement FR/EN ; textes dans `Resources/*.resx` ou des JSON par langue ; route `/en/...` optionnelle pour l'indexation.
- Images de projet : un `alt` descriptif par capture.

---

## 7. Hors périmètre de cette spécification

La page de détail d'un projet (titre, contexte, choix techniques, captures, liens vers le repo et la démo) n'est pas encore maquettée. Elle reprendra les composants ci-dessus : en-tête, cards, tags, boutons et bloc Contact.
