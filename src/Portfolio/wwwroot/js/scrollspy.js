export function observe(dotNetHelper, sectionIds) {
    let activeId = null;
    let frame = 0;

    const compute = () => {
        frame = 0;

        const sections = sectionIds
            .map(id => document.getElementById(id))
            .filter(section => section !== null);

        if (sections.length === 0) {
            return;
        }

        const line = (parseFloat(getComputedStyle(sections[0]).scrollMarginTop) || 0) + 8;
        const atBottom = window.innerHeight + window.scrollY
            >= document.documentElement.scrollHeight - 2;

        let nextId = null;

        if (atBottom) {
            nextId = sections[sections.length - 1].id;
        } else {
            for (const section of sections) {
                if (section.getBoundingClientRect().top <= line) {
                    nextId = section.id;
                }
            }
        }

        if (nextId !== activeId) {
            activeId = nextId;
            dotNetHelper.invokeMethodAsync('SetActiveSection', activeId);
        }
    };

    const schedule = () => {
        if (frame === 0) {
            frame = requestAnimationFrame(compute);
        }
    };

    const resizeObserver = new ResizeObserver(schedule);
    resizeObserver.observe(document.body);
    window.addEventListener('scroll', schedule, { passive: true });
    window.addEventListener('resize', schedule);
    schedule();

    return {
        disconnect() {
            cancelAnimationFrame(frame);
            window.removeEventListener('scroll', schedule);
            window.removeEventListener('resize', schedule);
            resizeObserver.disconnect();
        }
    };
}
