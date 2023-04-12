function toggleMenu(){
    try {
        const toggleBtn = document.querySelector('[data-option="toggle"]')
        toggleBtn.addEventListener('click', function () {
            const element = document.querySelector(toggleBtn.getAttribute('data-target'))

            if (!element.classList.contains('open-menu')) {
                element.classList.add('open-menu')
            }

            else {
                element.classList.remove('open-menu')
            }
        })
    } catch { }
}
toggleMenu()


function footerPosition() {
    try {
        const footer = document.querySelector('#footer');
        const header = document.querySelector('#header');
        const headerHeight = header ? header.offsetHeight : 0;
        const footerHeight = footer ? footer.offsetHeight : 0;
        const fixedElementsHeight = headerHeight + footerHeight;
        const viewportHeight = window.innerHeight - fixedElementsHeight;
        const isTallerThanScreen = document.body.scrollHeight > viewportHeight;

        footer.classList.toggle('position-fixed-bottom', !isTallerThanScreen);
        footer.classList.toggle('position-static', isTallerThanScreen);

    } catch (error) {
        console.error(error);
    }
}

footerPosition();

window.addEventListener('resize', footerPosition);

window.onload = function () {
    const button = document.querySelector('#showMoreButton');
    const div = document.querySelector('#bestCollectionSecond');

    button.addEventListener('click', function () {
        if (div.classList.contains('d-none')) {
            div.classList.remove('d-none');
            div.classList.add('collection');
        } else {
            div.classList.remove('collection');
            div.classList.add('d-none');
        }
    });
};

