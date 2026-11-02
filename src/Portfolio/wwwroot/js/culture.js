export function getCulture() {
    try {
        return localStorage.getItem('culture');
    } catch {
        return null;
    }
}

export function setCulture(culture) {
    try {
        localStorage.setItem('culture', culture);
    } catch {
    }
}
